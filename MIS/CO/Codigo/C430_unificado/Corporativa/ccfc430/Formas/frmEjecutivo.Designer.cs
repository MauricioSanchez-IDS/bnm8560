using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmEjecutivo
	{
	
#region "Upgrade Support "
		private static frmEjecutivo m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmEjecutivo DefInstance
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
		public frmEjecutivo():base(){
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
			InitializeoptEjecutivos();
			InitializelblEjecutivos();
			InitializefraDatosAdicionales();
			InitializeID_MEE_ETT_TXT();
			InitializecmdEjecutivos();
			InitializefraEjecutivos();
			InitializecmbEjecutivos();
			InitializechkEjecutivos();
			InitializemskEjecutivos();
			InitializepnlEjecutivos();
			InitializetxtEjecutivos();
			tabEjecutivosPreviousTab = tabEjecutivos.SelectedIndex;
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static frmEjecutivo CreateInstance()
	{
			frmEjecutivo theInstance = new frmEjecutivo();
            //AIS-1905 ACANTILLO
			//theInstance.Form_Load();
			//The MDI form in the VB6 project had its
			//AutoShowChildren property set to True
			//To simulate the VB6 behavior, we need to
			//automatically Show the form whenever it
			//is loaded.  If you do not want this behavior
			//then delete the following line of code
			//UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing.
			//theInstance.Show();
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
	private  System.Windows.Forms.Button _cmdEjecutivos_0;
	private  System.Windows.Forms.Button _cmdEjecutivos_1;
	private  System.Windows.Forms.Button _cmdEjecutivos_2;
        private System.Windows.Forms.RadioButton _optEjecutivos_1;
        private System.Windows.Forms.RadioButton _optEjecutivos_0;
	private  System.Windows.Forms.Panel _pnlEjecutivos_0;
	private  System.Windows.Forms.ComboBox _cmbEjecutivos_0;
	private  AxMSMask.AxMaskEdBox _mskEjecutivos_0;
	private  System.Windows.Forms.TextBox _txtEjecutivos_6;
	private  System.Windows.Forms.TextBox _txtEjecutivos_5;
	private  System.Windows.Forms.TextBox _txtEjecutivos_4;
	private  System.Windows.Forms.TextBox _txtEjecutivos_3;
	private  System.Windows.Forms.TextBox _txtEjecutivos_2;
	private  AxMSMask.AxMaskEdBox _mskEjecutivos_1;
	private  AxMSMask.AxMaskEdBox _mskEjecutivos_2;
	private  AxMSMask.AxMaskEdBox _mskEjecutivos_3;
	private  AxMSMask.AxMaskEdBox _mskEjecutivos_4;
	private  AxMSMask.AxMaskEdBox _mskEjecutivos_5;
	private  System.Windows.Forms.Label _lblEjecutivos_14;
	private  System.Windows.Forms.Label _lblEjecutivos_13;
	private  System.Windows.Forms.Label _lblEjecutivos_12;
	private  System.Windows.Forms.Label _lblEjecutivos_11;
	private  System.Windows.Forms.Label _lblEjecutivos_10;
	private  System.Windows.Forms.Label _lblEjecutivos_9;
	private  System.Windows.Forms.Label _lblEjecutivos_8;
	private  System.Windows.Forms.Label _lblEjecutivos_7;
	private  System.Windows.Forms.Label _lblEjecutivos_6;
	private  System.Windows.Forms.Label _lblEjecutivos_5;
	private  System.Windows.Forms.Label _lblEjecutivos_4;
	private  System.Windows.Forms.Label _lblEjecutivos_3;
	private  System.Windows.Forms.Label _lblEjecutivos_2;
	private  System.Windows.Forms.GroupBox _fraEjecutivos_1;
	private  System.Windows.Forms.TextBox _txtEjecutivos_1;
	private  System.Windows.Forms.TextBox _txtEjecutivos_0;
	private  System.Windows.Forms.Label _lblEjecutivos_1;
	private  System.Windows.Forms.Label _lblEjecutivos_0;
	private  System.Windows.Forms.GroupBox _fraEjecutivos_0;
	private  System.Windows.Forms.TabPage _tabEjecutivos_TabPage0;
	private  System.Windows.Forms.ComboBox _cmbEjecutivos_1;
	private  System.Windows.Forms.TextBox _txtEjecutivos_9;
	private  System.Windows.Forms.TextBox _txtEjecutivos_8;
	private  System.Windows.Forms.TextBox _txtEjecutivos_7;
	private  AxMSMask.AxMaskEdBox _mskEjecutivos_6;
	private  AxMSMask.AxMaskEdBox _mskEjecutivos_7;
	private  AxMSMask.AxMaskEdBox _mskEjecutivos_8;
	private  AxMSMask.AxMaskEdBox _mskEjecutivos_9;
	private  System.Windows.Forms.Label _lblEjecutivos_22;
	private  System.Windows.Forms.Label _lblEjecutivos_21;
	private  System.Windows.Forms.Label _lblEjecutivos_20;
	private  System.Windows.Forms.Label _lblEjecutivos_19;
	private  System.Windows.Forms.Label _lblEjecutivos_18;
	private  System.Windows.Forms.Label _lblEjecutivos_17;
	private  System.Windows.Forms.Label _lblEjecutivos_16;
	private  System.Windows.Forms.Label _lblEjecutivos_15;
	private  System.Windows.Forms.GroupBox _fraEjecutivos_2;
	private  System.Windows.Forms.ComboBox _cmbEjecutivos_2;
	private  System.Windows.Forms.TextBox _txtEjecutivos_13;
	private  System.Windows.Forms.TextBox _txtEjecutivos_12;
	private  System.Windows.Forms.TextBox _txtEjecutivos_11;
	private  System.Windows.Forms.TextBox _txtEjecutivos_10;
	private  AxMSMask.AxMaskEdBox _mskEjecutivos_10;
	private  AxMSMask.AxMaskEdBox _mskEjecutivos_11;
	private  System.Windows.Forms.Label _lblEjecutivos_29;
	private  System.Windows.Forms.Label _lblEjecutivos_28;
	private  System.Windows.Forms.Label _lblEjecutivos_27;
	private  System.Windows.Forms.Label _lblEjecutivos_26;
	private  System.Windows.Forms.Label _lblEjecutivos_25;
	private  System.Windows.Forms.Label _lblEjecutivos_24;
	private  System.Windows.Forms.Label _lblEjecutivos_23;
	private  System.Windows.Forms.GroupBox _fraEjecutivos_3;
	private  System.Windows.Forms.TabPage _tabEjecutivos_TabPage1;
	public  System.Windows.Forms.ComboBox ID_MEM_PERSONA;
	public  System.Windows.Forms.TextBox txtAtencionA;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_7;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_9;
	private  System.Windows.Forms.GroupBox _fraDatosAdicionales_3;
        private System.Windows.Forms.RadioButton _optEjecutivos_6;
        private System.Windows.Forms.RadioButton _optEjecutivos_7;
        private System.Windows.Forms.RadioButton _optEjecutivos_8;
	private  System.Windows.Forms.GroupBox _fraEjecutivos_7;
	private  System.Windows.Forms.CheckBox _chkEjecutivos_1;
	private  System.Windows.Forms.CheckBox _chkEjecutivos_0;
	private  System.Windows.Forms.GroupBox _fraEjecutivos_4;
        private System.Windows.Forms.RadioButton _optEjecutivos_2;
        private System.Windows.Forms.RadioButton _optEjecutivos_3;
	private  System.Windows.Forms.GroupBox _fraEjecutivos_5;
	private  System.Windows.Forms.CheckBox _chkEjecutivos_3;
	private  System.Windows.Forms.CheckBox _chkEjecutivos_2;
	private  System.Windows.Forms.GroupBox _fraEjecutivos_6;
	private  AxMSMask.AxMaskEdBox _mskEjecutivos_12;
        private System.Windows.Forms.RadioButton _optEjecutivos_4;
        private System.Windows.Forms.RadioButton _optEjecutivos_5;
	private  System.Windows.Forms.Panel _pnlEjecutivos_1;
	private  System.Windows.Forms.Label _lblEjecutivos_31;
	private  System.Windows.Forms.Label _lblEjecutivos_30;
	private  System.Windows.Forms.TabPage _tabEjecutivos_TabPage2;
	public  System.Windows.Forms.TabControl tabEjecutivos;
	public System.Windows.Forms.Label[] ID_MEE_ETT_TXT = new System.Windows.Forms.Label[10];
	public System.Windows.Forms.CheckBox[] chkEjecutivos = new System.Windows.Forms.CheckBox[4];
	public System.Windows.Forms.ComboBox[] cmbEjecutivos = new System.Windows.Forms.ComboBox[3];
	public System.Windows.Forms.Button[] cmdEjecutivos = new System.Windows.Forms.Button[3];
	public System.Windows.Forms.GroupBox[] fraDatosAdicionales = new System.Windows.Forms.GroupBox[4];
	public System.Windows.Forms.GroupBox[] fraEjecutivos = new System.Windows.Forms.GroupBox[8];
	public System.Windows.Forms.Label[] lblEjecutivos = new System.Windows.Forms.Label[32];
	public AxMSMask.AxMaskEdBox[] mskEjecutivos = new AxMSMask.AxMaskEdBox[13];
        public System.Windows.Forms.RadioButton[] optEjecutivos = new System.Windows.Forms.RadioButton[9];
	public System.Windows.Forms.Panel[] pnlEjecutivos = new System.Windows.Forms.Panel[2];
	public System.Windows.Forms.TextBox[] txtEjecutivos = new System.Windows.Forms.TextBox[14];
	private Artinsoft.VB6.Gui.ListControlHelper ListBoxComboBoxHelper1;
	private int tabEjecutivosPreviousTab;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEjecutivo));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._cmdEjecutivos_0 = new System.Windows.Forms.Button();
            this._cmdEjecutivos_1 = new System.Windows.Forms.Button();
            this._cmdEjecutivos_2 = new System.Windows.Forms.Button();
            this.tabEjecutivos = new System.Windows.Forms.TabControl();
            this._tabEjecutivos_TabPage0 = new System.Windows.Forms.TabPage();
            this._fraEjecutivos_1 = new System.Windows.Forms.GroupBox();
            this._lblEjecutivos_12 = new System.Windows.Forms.Label();
            this._lblEjecutivos_13 = new System.Windows.Forms.Label();
            this._lblEjecutivos_10 = new System.Windows.Forms.Label();
            this._lblEjecutivos_11 = new System.Windows.Forms.Label();
            this._mskEjecutivos_4 = new AxMSMask.AxMaskEdBox();
            this._mskEjecutivos_3 = new AxMSMask.AxMaskEdBox();
            this._lblEjecutivos_14 = new System.Windows.Forms.Label();
            this._mskEjecutivos_5 = new AxMSMask.AxMaskEdBox();
            this._lblEjecutivos_4 = new System.Windows.Forms.Label();
            this._lblEjecutivos_5 = new System.Windows.Forms.Label();
            this._lblEjecutivos_2 = new System.Windows.Forms.Label();
            this._lblEjecutivos_3 = new System.Windows.Forms.Label();
            this._lblEjecutivos_8 = new System.Windows.Forms.Label();
            this._lblEjecutivos_9 = new System.Windows.Forms.Label();
            this._lblEjecutivos_6 = new System.Windows.Forms.Label();
            this._lblEjecutivos_7 = new System.Windows.Forms.Label();
            this._mskEjecutivos_2 = new AxMSMask.AxMaskEdBox();
            this._mskEjecutivos_0 = new AxMSMask.AxMaskEdBox();
            this._txtEjecutivos_6 = new System.Windows.Forms.TextBox();
            this._pnlEjecutivos_0 = new System.Windows.Forms.Panel();
            this._optEjecutivos_1 = new System.Windows.Forms.RadioButton();
            this._optEjecutivos_0 = new System.Windows.Forms.RadioButton();
            this._cmbEjecutivos_0 = new System.Windows.Forms.ComboBox();
            this._txtEjecutivos_5 = new System.Windows.Forms.TextBox();
            this._txtEjecutivos_2 = new System.Windows.Forms.TextBox();
            this._mskEjecutivos_1 = new AxMSMask.AxMaskEdBox();
            this._txtEjecutivos_4 = new System.Windows.Forms.TextBox();
            this._txtEjecutivos_3 = new System.Windows.Forms.TextBox();
            this._fraEjecutivos_0 = new System.Windows.Forms.GroupBox();
            this._txtEjecutivos_0 = new System.Windows.Forms.TextBox();
            this._txtEjecutivos_1 = new System.Windows.Forms.TextBox();
            this._lblEjecutivos_0 = new System.Windows.Forms.Label();
            this._lblEjecutivos_1 = new System.Windows.Forms.Label();
            this._tabEjecutivos_TabPage1 = new System.Windows.Forms.TabPage();
            this._fraEjecutivos_2 = new System.Windows.Forms.GroupBox();
            this._lblEjecutivos_22 = new System.Windows.Forms.Label();
            this._lblEjecutivos_21 = new System.Windows.Forms.Label();
            this._mskEjecutivos_9 = new AxMSMask.AxMaskEdBox();
            this._mskEjecutivos_7 = new AxMSMask.AxMaskEdBox();
            this._mskEjecutivos_8 = new AxMSMask.AxMaskEdBox();
            this._lblEjecutivos_20 = new System.Windows.Forms.Label();
            this._lblEjecutivos_16 = new System.Windows.Forms.Label();
            this._lblEjecutivos_15 = new System.Windows.Forms.Label();
            this._lblEjecutivos_17 = new System.Windows.Forms.Label();
            this._lblEjecutivos_19 = new System.Windows.Forms.Label();
            this._lblEjecutivos_18 = new System.Windows.Forms.Label();
            this._mskEjecutivos_6 = new AxMSMask.AxMaskEdBox();
            this._txtEjecutivos_9 = new System.Windows.Forms.TextBox();
            this._cmbEjecutivos_1 = new System.Windows.Forms.ComboBox();
            this._txtEjecutivos_7 = new System.Windows.Forms.TextBox();
            this._txtEjecutivos_8 = new System.Windows.Forms.TextBox();
            this._fraEjecutivos_3 = new System.Windows.Forms.GroupBox();
            this._lblEjecutivos_29 = new System.Windows.Forms.Label();
            this._lblEjecutivos_28 = new System.Windows.Forms.Label();
            this._txtEjecutivos_10 = new System.Windows.Forms.TextBox();
            this._lblEjecutivos_24 = new System.Windows.Forms.Label();
            this._lblEjecutivos_23 = new System.Windows.Forms.Label();
            this._lblEjecutivos_25 = new System.Windows.Forms.Label();
            this._lblEjecutivos_27 = new System.Windows.Forms.Label();
            this._lblEjecutivos_26 = new System.Windows.Forms.Label();
            this._txtEjecutivos_11 = new System.Windows.Forms.TextBox();
            this._cmbEjecutivos_2 = new System.Windows.Forms.ComboBox();
            this._txtEjecutivos_13 = new System.Windows.Forms.TextBox();
            this._txtEjecutivos_12 = new System.Windows.Forms.TextBox();
            this._mskEjecutivos_11 = new AxMSMask.AxMaskEdBox();
            this._mskEjecutivos_10 = new AxMSMask.AxMaskEdBox();
            this._tabEjecutivos_TabPage2 = new System.Windows.Forms.TabPage();
            this._mskEjecutivos_12 = new AxMSMask.AxMaskEdBox();
            this._fraEjecutivos_6 = new System.Windows.Forms.GroupBox();
            this._chkEjecutivos_3 = new System.Windows.Forms.CheckBox();
            this._chkEjecutivos_2 = new System.Windows.Forms.CheckBox();
            this._pnlEjecutivos_1 = new System.Windows.Forms.Panel();
            this._optEjecutivos_4 = new System.Windows.Forms.RadioButton();
            this._optEjecutivos_5 = new System.Windows.Forms.RadioButton();
            this._lblEjecutivos_30 = new System.Windows.Forms.Label();
            this._lblEjecutivos_31 = new System.Windows.Forms.Label();
            this._fraEjecutivos_5 = new System.Windows.Forms.GroupBox();
            this._optEjecutivos_2 = new System.Windows.Forms.RadioButton();
            this._optEjecutivos_3 = new System.Windows.Forms.RadioButton();
            this._fraDatosAdicionales_3 = new System.Windows.Forms.GroupBox();
            this.txtAtencionA = new System.Windows.Forms.TextBox();
            this.ID_MEM_PERSONA = new System.Windows.Forms.ComboBox();
            this._ID_MEE_ETT_TXT_9 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_7 = new System.Windows.Forms.Label();
            this._fraEjecutivos_7 = new System.Windows.Forms.GroupBox();
            this._optEjecutivos_6 = new System.Windows.Forms.RadioButton();
            this._optEjecutivos_7 = new System.Windows.Forms.RadioButton();
            this._optEjecutivos_8 = new System.Windows.Forms.RadioButton();
            this._fraEjecutivos_4 = new System.Windows.Forms.GroupBox();
            this._chkEjecutivos_1 = new System.Windows.Forms.CheckBox();
            this._chkEjecutivos_0 = new System.Windows.Forms.CheckBox();
            this.ListBoxComboBoxHelper1 = new Artinsoft.VB6.Gui.ListControlHelper(this.components);
            this.ssTabHelper1 = new Artinsoft.VB6.Gui.SSTabHelper(this.components);
            this.tabEjecutivos.SuspendLayout();
            this._tabEjecutivos_TabPage0.SuspendLayout();
            this._fraEjecutivos_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_0)).BeginInit();
            this._pnlEjecutivos_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_1)).BeginInit();
            this._fraEjecutivos_0.SuspendLayout();
            this._tabEjecutivos_TabPage1.SuspendLayout();
            this._fraEjecutivos_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_6)).BeginInit();
            this._fraEjecutivos_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_10)).BeginInit();
            this._tabEjecutivos_TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_12)).BeginInit();
            this._fraEjecutivos_6.SuspendLayout();
            this._pnlEjecutivos_1.SuspendLayout();
            this._fraEjecutivos_5.SuspendLayout();
            this._fraDatosAdicionales_3.SuspendLayout();
            this._fraEjecutivos_7.SuspendLayout();
            this._fraEjecutivos_4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssTabHelper1)).BeginInit();
            this.SuspendLayout();
            // 
            // _cmdEjecutivos_0
            // 
            this._cmdEjecutivos_0.BackColor = System.Drawing.SystemColors.Control;
            this._cmdEjecutivos_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmdEjecutivos_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._cmdEjecutivos_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmdEjecutivos_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cmdEjecutivos_0.Location = new System.Drawing.Point(144, 432);
            this._cmdEjecutivos_0.Name = "_cmdEjecutivos_0";
            this._cmdEjecutivos_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmdEjecutivos_0.Size = new System.Drawing.Size(89, 21);
            this._cmdEjecutivos_0.TabIndex = 84;
            this._cmdEjecutivos_0.Tag = "";
            this._cmdEjecutivos_0.Text = "Aceptar";
            this._cmdEjecutivos_0.UseVisualStyleBackColor = false;
            this._cmdEjecutivos_0.Click += new System.EventHandler(this.cmdEjecutivos_Click);
            // 
            // _cmdEjecutivos_1
            // 
            this._cmdEjecutivos_1.BackColor = System.Drawing.SystemColors.Control;
            this._cmdEjecutivos_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmdEjecutivos_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._cmdEjecutivos_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmdEjecutivos_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cmdEjecutivos_1.Location = new System.Drawing.Point(256, 432);
            this._cmdEjecutivos_1.Name = "_cmdEjecutivos_1";
            this._cmdEjecutivos_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmdEjecutivos_1.Size = new System.Drawing.Size(89, 21);
            this._cmdEjecutivos_1.TabIndex = 83;
            this._cmdEjecutivos_1.Tag = "";
            this._cmdEjecutivos_1.Text = "Cancelar";
            this._cmdEjecutivos_1.UseVisualStyleBackColor = false;
            this._cmdEjecutivos_1.Click += new System.EventHandler(this.cmdEjecutivos_Click);
            // 
            // _cmdEjecutivos_2
            // 
            this._cmdEjecutivos_2.BackColor = System.Drawing.SystemColors.Control;
            this._cmdEjecutivos_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmdEjecutivos_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._cmdEjecutivos_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmdEjecutivos_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cmdEjecutivos_2.Location = new System.Drawing.Point(368, 432);
            this._cmdEjecutivos_2.Name = "_cmdEjecutivos_2";
            this._cmdEjecutivos_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmdEjecutivos_2.Size = new System.Drawing.Size(89, 21);
            this._cmdEjecutivos_2.TabIndex = 82;
            this._cmdEjecutivos_2.Tag = "";
            this._cmdEjecutivos_2.Text = "Imprimir";
            this._cmdEjecutivos_2.UseVisualStyleBackColor = false;
            this._cmdEjecutivos_2.Click += new System.EventHandler(this.cmdEjecutivos_Click);
            // 
            // tabEjecutivos
            // 
            this.ssTabHelper1.SetActiveTabFontStyle(this.tabEjecutivos, Artinsoft.VB6.Gui.SSTabHelper.ActiveTabFontStyleEnum.Default);
            this.tabEjecutivos.Controls.Add(this._tabEjecutivos_TabPage0);
            this.tabEjecutivos.Controls.Add(this._tabEjecutivos_TabPage1);
            this.tabEjecutivos.Controls.Add(this._tabEjecutivos_TabPage2);
            this.tabEjecutivos.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabEjecutivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEjecutivos.ItemSize = new System.Drawing.Size(199, 18);
            this.tabEjecutivos.Location = new System.Drawing.Point(0, 0);
            this.tabEjecutivos.Multiline = true;
            this.tabEjecutivos.Name = "tabEjecutivos";
            this.tabEjecutivos.SelectedIndex = 0;
            this.tabEjecutivos.Size = new System.Drawing.Size(605, 429);
            this.tabEjecutivos.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabEjecutivos.TabIndex = 38;
            this.tabEjecutivos.Tag = "";
            this.ssTabHelper1.SetUseMnemonic(this.tabEjecutivos, true);
            this.tabEjecutivos.SelectedIndexChanged += new System.EventHandler(this.tabEjecutivos_SelectedIndexChanged);
            // 
            // _tabEjecutivos_TabPage0
            // 
            this._tabEjecutivos_TabPage0.BackColor = System.Drawing.Color.Transparent;
            this._tabEjecutivos_TabPage0.Controls.Add(this._fraEjecutivos_1);
            this._tabEjecutivos_TabPage0.Controls.Add(this._fraEjecutivos_0);
            this._tabEjecutivos_TabPage0.Location = new System.Drawing.Point(4, 22);
            this._tabEjecutivos_TabPage0.Name = "_tabEjecutivos_TabPage0";
            this._tabEjecutivos_TabPage0.Size = new System.Drawing.Size(597, 403);
            this._tabEjecutivos_TabPage0.TabIndex = 0;
            this._tabEjecutivos_TabPage0.Tag = "";
            this._tabEjecutivos_TabPage0.Text = "Datos &Generales";
            this._tabEjecutivos_TabPage0.UseVisualStyleBackColor = true;
            // 
            // _fraEjecutivos_1
            // 
            this._fraEjecutivos_1.Controls.Add(this._lblEjecutivos_12);
            this._fraEjecutivos_1.Controls.Add(this._lblEjecutivos_13);
            this._fraEjecutivos_1.Controls.Add(this._lblEjecutivos_10);
            this._fraEjecutivos_1.Controls.Add(this._lblEjecutivos_11);
            this._fraEjecutivos_1.Controls.Add(this._mskEjecutivos_4);
            this._fraEjecutivos_1.Controls.Add(this._mskEjecutivos_3);
            this._fraEjecutivos_1.Controls.Add(this._lblEjecutivos_14);
            this._fraEjecutivos_1.Controls.Add(this._mskEjecutivos_5);
            this._fraEjecutivos_1.Controls.Add(this._lblEjecutivos_4);
            this._fraEjecutivos_1.Controls.Add(this._lblEjecutivos_5);
            this._fraEjecutivos_1.Controls.Add(this._lblEjecutivos_2);
            this._fraEjecutivos_1.Controls.Add(this._lblEjecutivos_3);
            this._fraEjecutivos_1.Controls.Add(this._lblEjecutivos_8);
            this._fraEjecutivos_1.Controls.Add(this._lblEjecutivos_9);
            this._fraEjecutivos_1.Controls.Add(this._lblEjecutivos_6);
            this._fraEjecutivos_1.Controls.Add(this._lblEjecutivos_7);
            this._fraEjecutivos_1.Controls.Add(this._mskEjecutivos_2);
            this._fraEjecutivos_1.Controls.Add(this._mskEjecutivos_0);
            this._fraEjecutivos_1.Controls.Add(this._txtEjecutivos_6);
            this._fraEjecutivos_1.Controls.Add(this._pnlEjecutivos_0);
            this._fraEjecutivos_1.Controls.Add(this._cmbEjecutivos_0);
            this._fraEjecutivos_1.Controls.Add(this._txtEjecutivos_5);
            this._fraEjecutivos_1.Controls.Add(this._txtEjecutivos_2);
            this._fraEjecutivos_1.Controls.Add(this._mskEjecutivos_1);
            this._fraEjecutivos_1.Controls.Add(this._txtEjecutivos_4);
            this._fraEjecutivos_1.Controls.Add(this._txtEjecutivos_3);
            this._fraEjecutivos_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraEjecutivos_1.Location = new System.Drawing.Point(13, 68);
            this._fraEjecutivos_1.Name = "_fraEjecutivos_1";
            this._fraEjecutivos_1.Size = new System.Drawing.Size(577, 321);
            this._fraEjecutivos_1.TabIndex = 40;
            this._fraEjecutivos_1.TabStop = false;
            this._fraEjecutivos_1.Tag = "";
            this._fraEjecutivos_1.Text = "Datos del Ejecutivo";
            // 
            // _lblEjecutivos_12
            // 
            this._lblEjecutivos_12.AutoSize = true;
            this._lblEjecutivos_12.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_12.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_12.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_12.Location = new System.Drawing.Point(24, 248);
            this._lblEjecutivos_12.Name = "_lblEjecutivos_12";
            this._lblEjecutivos_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_12.Size = new System.Drawing.Size(112, 13);
            this._lblEjecutivos_12.TabIndex = 62;
            this._lblEjecutivos_12.Tag = "";
            this._lblEjecutivos_12.Text = "Correo Electrónico";
            // 
            // _lblEjecutivos_13
            // 
            this._lblEjecutivos_13.AutoSize = true;
            this._lblEjecutivos_13.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_13.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_13.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_13.Location = new System.Drawing.Point(24, 285);
            this._lblEjecutivos_13.Name = "_lblEjecutivos_13";
            this._lblEjecutivos_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_13.Size = new System.Drawing.Size(35, 13);
            this._lblEjecutivos_13.TabIndex = 63;
            this._lblEjecutivos_13.Tag = "";
            this._lblEjecutivos_13.Text = "Sexo";
            // 
            // _lblEjecutivos_10
            // 
            this._lblEjecutivos_10.AutoSize = true;
            this._lblEjecutivos_10.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_10.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_10.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_10.Location = new System.Drawing.Point(304, 184);
            this._lblEjecutivos_10.Name = "_lblEjecutivos_10";
            this._lblEjecutivos_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_10.Size = new System.Drawing.Size(143, 13);
            this._lblEjecutivos_10.TabIndex = 60;
            this._lblEjecutivos_10.Tag = "";
            this._lblEjecutivos_10.Text = "Límite disposiciones (%)";
            // 
            // _lblEjecutivos_11
            // 
            this._lblEjecutivos_11.AutoSize = true;
            this._lblEjecutivos_11.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_11.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_11.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_11.Location = new System.Drawing.Point(24, 216);
            this._lblEjecutivos_11.Name = "_lblEjecutivos_11";
            this._lblEjecutivos_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_11.Size = new System.Drawing.Size(101, 13);
            this._lblEjecutivos_11.TabIndex = 61;
            this._lblEjecutivos_11.Tag = "";
            this._lblEjecutivos_11.Text = "Cuenta Contable";
            // 
            // _mskEjecutivos_4
            // 
            this._mskEjecutivos_4.Location = new System.Drawing.Point(455, 181);
            this._mskEjecutivos_4.Name = "_mskEjecutivos_4";
            this._mskEjecutivos_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEjecutivos_4.OcxState")));
            this._mskEjecutivos_4.Size = new System.Drawing.Size(98, 19);
            this._mskEjecutivos_4.TabIndex = 8;
            this._mskEjecutivos_4.Tag = "";
            this._mskEjecutivos_4.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEjecutivos_KeyPressEvent);
            this._mskEjecutivos_4.Enter += new System.EventHandler(this.mskEjecutivos_Enter);
            this._mskEjecutivos_4.Leave += new System.EventHandler(this.mskEjecutivos_Leave);
            this._mskEjecutivos_4.Validating += new System.ComponentModel.CancelEventHandler(this.mskEjecutivos_Validating);
            // 
            // _mskEjecutivos_3
            // 
            this._mskEjecutivos_3.Location = new System.Drawing.Point(144, 181);
            this._mskEjecutivos_3.Name = "_mskEjecutivos_3";
            this._mskEjecutivos_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEjecutivos_3.OcxState")));
            this._mskEjecutivos_3.Size = new System.Drawing.Size(141, 19);
            this._mskEjecutivos_3.TabIndex = 7;
            this._mskEjecutivos_3.Tag = "";
            this._mskEjecutivos_3.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEjecutivos_KeyPressEvent);
            this._mskEjecutivos_3.Enter += new System.EventHandler(this.mskEjecutivos_Enter);
            this._mskEjecutivos_3.Leave += new System.EventHandler(this.mskEjecutivos_Leave);
            this._mskEjecutivos_3.Validating += new System.ComponentModel.CancelEventHandler(this.mskEjecutivos_Validating);
            // 
            // _lblEjecutivos_14
            // 
            this._lblEjecutivos_14.AutoSize = true;
            this._lblEjecutivos_14.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_14.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_14.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_14.Location = new System.Drawing.Point(408, 280);
            this._lblEjecutivos_14.Name = "_lblEjecutivos_14";
            this._lblEjecutivos_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_14.Size = new System.Drawing.Size(80, 13);
            this._lblEjecutivos_14.TabIndex = 64;
            this._lblEjecutivos_14.Tag = "";
            this._lblEjecutivos_14.Text = "Día de Corte";
            // 
            // _mskEjecutivos_5
            // 
            this._mskEjecutivos_5.Location = new System.Drawing.Point(496, 277);
            this._mskEjecutivos_5.Name = "_mskEjecutivos_5";
            this._mskEjecutivos_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEjecutivos_5.OcxState")));
            this._mskEjecutivos_5.Size = new System.Drawing.Size(57, 19);
            this._mskEjecutivos_5.TabIndex = 13;
            this._mskEjecutivos_5.Tag = "";
            this._mskEjecutivos_5.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEjecutivos_KeyPressEvent);
            this._mskEjecutivos_5.Enter += new System.EventHandler(this.mskEjecutivos_Enter);
            this._mskEjecutivos_5.Leave += new System.EventHandler(this.mskEjecutivos_Leave);
            this._mskEjecutivos_5.Validating += new System.ComponentModel.CancelEventHandler(this.mskEjecutivos_Validating);
            // 
            // _lblEjecutivos_4
            // 
            this._lblEjecutivos_4.AutoSize = true;
            this._lblEjecutivos_4.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_4.Location = new System.Drawing.Point(24, 88);
            this._lblEjecutivos_4.Name = "_lblEjecutivos_4";
            this._lblEjecutivos_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_4.Size = new System.Drawing.Size(31, 13);
            this._lblEjecutivos_4.TabIndex = 54;
            this._lblEjecutivos_4.Tag = "";
            this._lblEjecutivos_4.Text = "RFC";
            // 
            // _lblEjecutivos_5
            // 
            this._lblEjecutivos_5.AutoSize = true;
            this._lblEjecutivos_5.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_5.Location = new System.Drawing.Point(352, 88);
            this._lblEjecutivos_5.Name = "_lblEjecutivos_5";
            this._lblEjecutivos_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_5.Size = new System.Drawing.Size(95, 13);
            this._lblEjecutivos_5.TabIndex = 55;
            this._lblEjecutivos_5.Tag = "";
            this._lblEjecutivos_5.Text = "No.  de Nómina";
            // 
            // _lblEjecutivos_2
            // 
            this._lblEjecutivos_2.AutoSize = true;
            this._lblEjecutivos_2.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_2.Location = new System.Drawing.Point(24, 24);
            this._lblEjecutivos_2.Name = "_lblEjecutivos_2";
            this._lblEjecutivos_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_2.Size = new System.Drawing.Size(50, 13);
            this._lblEjecutivos_2.TabIndex = 52;
            this._lblEjecutivos_2.Tag = "";
            this._lblEjecutivos_2.Text = "Nombre";
            // 
            // _lblEjecutivos_3
            // 
            this._lblEjecutivos_3.AutoSize = true;
            this._lblEjecutivos_3.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_3.Location = new System.Drawing.Point(24, 56);
            this._lblEjecutivos_3.Name = "_lblEjecutivos_3";
            this._lblEjecutivos_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_3.Size = new System.Drawing.Size(120, 13);
            this._lblEjecutivos_3.TabIndex = 53;
            this._lblEjecutivos_3.Tag = "";
            this._lblEjecutivos_3.Text = "Nombre (Grabación)";
            // 
            // _lblEjecutivos_8
            // 
            this._lblEjecutivos_8.AutoSize = true;
            this._lblEjecutivos_8.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_8.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_8.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_8.Location = new System.Drawing.Point(24, 152);
            this._lblEjecutivos_8.Name = "_lblEjecutivos_8";
            this._lblEjecutivos_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_8.Size = new System.Drawing.Size(47, 13);
            this._lblEjecutivos_8.TabIndex = 58;
            this._lblEjecutivos_8.Tag = "";
            this._lblEjecutivos_8.Text = "Cuenta";
            // 
            // _lblEjecutivos_9
            // 
            this._lblEjecutivos_9.AutoSize = true;
            this._lblEjecutivos_9.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_9.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_9.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_9.Location = new System.Drawing.Point(24, 184);
            this._lblEjecutivos_9.Name = "_lblEjecutivos_9";
            this._lblEjecutivos_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_9.Size = new System.Drawing.Size(86, 13);
            this._lblEjecutivos_9.TabIndex = 59;
            this._lblEjecutivos_9.Tag = "";
            this._lblEjecutivos_9.Text = "Límite Crédito";
            // 
            // _lblEjecutivos_6
            // 
            this._lblEjecutivos_6.AutoSize = true;
            this._lblEjecutivos_6.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_6.Location = new System.Drawing.Point(24, 120);
            this._lblEjecutivos_6.Name = "_lblEjecutivos_6";
            this._lblEjecutivos_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_6.Size = new System.Drawing.Size(104, 13);
            this._lblEjecutivos_6.TabIndex = 56;
            this._lblEjecutivos_6.Tag = "";
            this._lblEjecutivos_6.Text = "Centro de Costos";
            // 
            // _lblEjecutivos_7
            // 
            this._lblEjecutivos_7.AutoSize = true;
            this._lblEjecutivos_7.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_7.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_7.Location = new System.Drawing.Point(401, 120);
            this._lblEjecutivos_7.Name = "_lblEjecutivos_7";
            this._lblEjecutivos_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_7.Size = new System.Drawing.Size(46, 13);
            this._lblEjecutivos_7.TabIndex = 57;
            this._lblEjecutivos_7.Tag = "";
            this._lblEjecutivos_7.Text = "Sueldo";
            // 
            // _mskEjecutivos_2
            // 
            this._mskEjecutivos_2.Location = new System.Drawing.Point(456, 117);
            this._mskEjecutivos_2.Name = "_mskEjecutivos_2";
            this._mskEjecutivos_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEjecutivos_2.OcxState")));
            this._mskEjecutivos_2.Size = new System.Drawing.Size(98, 19);
            this._mskEjecutivos_2.TabIndex = 5;
            this._mskEjecutivos_2.Tag = "";
            this._mskEjecutivos_2.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEjecutivos_KeyPressEvent);
            this._mskEjecutivos_2.Enter += new System.EventHandler(this.mskEjecutivos_Enter);
            this._mskEjecutivos_2.Leave += new System.EventHandler(this.mskEjecutivos_Leave);
            this._mskEjecutivos_2.Validating += new System.ComponentModel.CancelEventHandler(this.mskEjecutivos_Validating);
            // 
            // _mskEjecutivos_0
            // 
            this._mskEjecutivos_0.Location = new System.Drawing.Point(144, 85);
            this._mskEjecutivos_0.Name = "_mskEjecutivos_0";
            this._mskEjecutivos_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEjecutivos_0.OcxState")));
            this._mskEjecutivos_0.Size = new System.Drawing.Size(141, 19);
            this._mskEjecutivos_0.TabIndex = 2;
            this._mskEjecutivos_0.Tag = "";
            this._mskEjecutivos_0.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEjecutivos_KeyPressEvent);
            this._mskEjecutivos_0.Enter += new System.EventHandler(this.mskEjecutivos_Enter);
            this._mskEjecutivos_0.Leave += new System.EventHandler(this.mskEjecutivos_Leave);
            this._mskEjecutivos_0.Validating += new System.ComponentModel.CancelEventHandler(this.mskEjecutivos_Validating);
            // 
            // _txtEjecutivos_6
            // 
            this._txtEjecutivos_6.AcceptsReturn = true;
            this._txtEjecutivos_6.BackColor = System.Drawing.SystemColors.Window;
            this._txtEjecutivos_6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEjecutivos_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEjecutivos_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEjecutivos_6.Location = new System.Drawing.Point(144, 245);
            this._txtEjecutivos_6.MaxLength = 70;
            this._txtEjecutivos_6.Name = "_txtEjecutivos_6";
            this._txtEjecutivos_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEjecutivos_6.Size = new System.Drawing.Size(409, 20);
            this._txtEjecutivos_6.TabIndex = 10;
            this._txtEjecutivos_6.Tag = "";
            this._txtEjecutivos_6.Enter += new System.EventHandler(this.txtEjecutivos_Enter);
            this._txtEjecutivos_6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEjecutivos_KeyPress);
            this._txtEjecutivos_6.Leave += new System.EventHandler(this.txtEjecutivos_Leave);
            this._txtEjecutivos_6.Validating += new System.ComponentModel.CancelEventHandler(this.txtEjecutivos_Validating);
            // 
            // _pnlEjecutivos_0
            // 
            this._pnlEjecutivos_0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this._pnlEjecutivos_0.Controls.Add(this._optEjecutivos_1);
            this._pnlEjecutivos_0.Controls.Add(this._optEjecutivos_0);
            this._pnlEjecutivos_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._pnlEjecutivos_0.Location = new System.Drawing.Point(144, 275);
            this._pnlEjecutivos_0.Name = "_pnlEjecutivos_0";
            this._pnlEjecutivos_0.Size = new System.Drawing.Size(217, 33);
            this._pnlEjecutivos_0.TabIndex = 48;
            this._pnlEjecutivos_0.Tag = "";
            // 
            // _optEjecutivos_1
            // 
            this._optEjecutivos_1.BackColor = System.Drawing.SystemColors.Control;
            this._optEjecutivos_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEjecutivos_1.Location = new System.Drawing.Point(120, 8);
            this._optEjecutivos_1.Name = "_optEjecutivos_1";
            this._optEjecutivos_1.Size = new System.Drawing.Size(92, 20);
            this._optEjecutivos_1.TabIndex = 12;
            this._optEjecutivos_1.Tag = "";
            this._optEjecutivos_1.Text = "Masculino";
            this._optEjecutivos_1.UseVisualStyleBackColor = false;
            this._optEjecutivos_1.CheckedChanged += new System.EventHandler(this._optEjecutivos_1_CheckedChanged);
            // 
            // _optEjecutivos_0
            // 
            this._optEjecutivos_0.BackColor = System.Drawing.SystemColors.Control;
            this._optEjecutivos_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEjecutivos_0.Location = new System.Drawing.Point(11, 8);
            this._optEjecutivos_0.Name = "_optEjecutivos_0";
            this._optEjecutivos_0.Size = new System.Drawing.Size(100, 20);
            this._optEjecutivos_0.TabIndex = 11;
            this._optEjecutivos_0.Tag = "";
            this._optEjecutivos_0.Text = "Femenino";
            this._optEjecutivos_0.UseVisualStyleBackColor = false;
            this._optEjecutivos_0.CheckedChanged += new System.EventHandler(this._optEjecutivos_0_CheckedChanged);
            // 
            // _cmbEjecutivos_0
            // 
            this._cmbEjecutivos_0.BackColor = System.Drawing.SystemColors.Window;
            this._cmbEjecutivos_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmbEjecutivos_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbEjecutivos_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this._cmbEjecutivos_0, new int[0]);
            this._cmbEjecutivos_0.Location = new System.Drawing.Point(144, 116);
            this._cmbEjecutivos_0.Name = "_cmbEjecutivos_0";
            this._cmbEjecutivos_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmbEjecutivos_0.Size = new System.Drawing.Size(189, 21);
            this._cmbEjecutivos_0.TabIndex = 4;
            this._cmbEjecutivos_0.Tag = "";
            this._cmbEjecutivos_0.SelectedIndexChanged += new System.EventHandler(this.cmbEjecutivos_SelectedIndexChanged);
            this._cmbEjecutivos_0.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEjecutivos_Validating);
            // 
            // _txtEjecutivos_5
            // 
            this._txtEjecutivos_5.AcceptsReturn = true;
            this._txtEjecutivos_5.BackColor = System.Drawing.SystemColors.Window;
            this._txtEjecutivos_5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEjecutivos_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEjecutivos_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEjecutivos_5.Location = new System.Drawing.Point(144, 213);
            this._txtEjecutivos_5.MaxLength = 40;
            this._txtEjecutivos_5.Name = "_txtEjecutivos_5";
            this._txtEjecutivos_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEjecutivos_5.Size = new System.Drawing.Size(409, 20);
            this._txtEjecutivos_5.TabIndex = 9;
            this._txtEjecutivos_5.Tag = "";
            this._txtEjecutivos_5.Enter += new System.EventHandler(this.txtEjecutivos_Enter);
            this._txtEjecutivos_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEjecutivos_KeyPress);
            this._txtEjecutivos_5.Leave += new System.EventHandler(this.txtEjecutivos_Leave);
            this._txtEjecutivos_5.Validating += new System.ComponentModel.CancelEventHandler(this.txtEjecutivos_Validating);
            // 
            // _txtEjecutivos_2
            // 
            this._txtEjecutivos_2.AcceptsReturn = true;
            this._txtEjecutivos_2.BackColor = System.Drawing.SystemColors.Window;
            this._txtEjecutivos_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEjecutivos_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEjecutivos_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEjecutivos_2.Location = new System.Drawing.Point(144, 21);
            this._txtEjecutivos_2.MaxLength = 45;
            this._txtEjecutivos_2.Name = "_txtEjecutivos_2";
            this._txtEjecutivos_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEjecutivos_2.Size = new System.Drawing.Size(409, 20);
            this._txtEjecutivos_2.TabIndex = 0;
            this._txtEjecutivos_2.Tag = "";
            this._txtEjecutivos_2.Enter += new System.EventHandler(this.txtEjecutivos_Enter);
            this._txtEjecutivos_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEjecutivos_KeyPress);
            this._txtEjecutivos_2.Leave += new System.EventHandler(this.txtEjecutivos_Leave);
            this._txtEjecutivos_2.Validating += new System.ComponentModel.CancelEventHandler(this.txtEjecutivos_Validating);
            // 
            // _mskEjecutivos_1
            // 
            this._mskEjecutivos_1.Location = new System.Drawing.Point(456, 85);
            this._mskEjecutivos_1.Name = "_mskEjecutivos_1";
            this._mskEjecutivos_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEjecutivos_1.OcxState")));
            this._mskEjecutivos_1.Size = new System.Drawing.Size(98, 19);
            this._mskEjecutivos_1.TabIndex = 3;
            this._mskEjecutivos_1.Tag = "";
            this._mskEjecutivos_1.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEjecutivos_KeyPressEvent);
            this._mskEjecutivos_1.Enter += new System.EventHandler(this.mskEjecutivos_Enter);
            this._mskEjecutivos_1.Leave += new System.EventHandler(this.mskEjecutivos_Leave);
            this._mskEjecutivos_1.Validating += new System.ComponentModel.CancelEventHandler(this.mskEjecutivos_Validating);
            // 
            // _txtEjecutivos_4
            // 
            this._txtEjecutivos_4.AcceptsReturn = true;
            this._txtEjecutivos_4.BackColor = System.Drawing.SystemColors.Window;
            this._txtEjecutivos_4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEjecutivos_4.Enabled = false;
            this._txtEjecutivos_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEjecutivos_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEjecutivos_4.Location = new System.Drawing.Point(144, 149);
            this._txtEjecutivos_4.MaxLength = 16;
            this._txtEjecutivos_4.Name = "_txtEjecutivos_4";
            this._txtEjecutivos_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEjecutivos_4.Size = new System.Drawing.Size(141, 20);
            this._txtEjecutivos_4.TabIndex = 6;
            this._txtEjecutivos_4.Tag = "";
            this._txtEjecutivos_4.Enter += new System.EventHandler(this.txtEjecutivos_Enter);
            this._txtEjecutivos_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEjecutivos_KeyPress);
            this._txtEjecutivos_4.Leave += new System.EventHandler(this.txtEjecutivos_Leave);
            this._txtEjecutivos_4.Validating += new System.ComponentModel.CancelEventHandler(this.txtEjecutivos_Validating);
            // 
            // _txtEjecutivos_3
            // 
            this._txtEjecutivos_3.AcceptsReturn = true;
            this._txtEjecutivos_3.BackColor = System.Drawing.SystemColors.Window;
            this._txtEjecutivos_3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEjecutivos_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEjecutivos_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEjecutivos_3.Location = new System.Drawing.Point(144, 53);
            this._txtEjecutivos_3.MaxLength = 26;
            this._txtEjecutivos_3.Name = "_txtEjecutivos_3";
            this._txtEjecutivos_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEjecutivos_3.Size = new System.Drawing.Size(409, 20);
            this._txtEjecutivos_3.TabIndex = 1;
            this._txtEjecutivos_3.Tag = "";
            this._txtEjecutivos_3.Enter += new System.EventHandler(this.txtEjecutivos_Enter);
            this._txtEjecutivos_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEjecutivos_KeyPress);
            this._txtEjecutivos_3.Leave += new System.EventHandler(this.txtEjecutivos_Leave);
            this._txtEjecutivos_3.Validating += new System.ComponentModel.CancelEventHandler(this.txtEjecutivos_Validating);
            // 
            // _fraEjecutivos_0
            // 
            this._fraEjecutivos_0.Controls.Add(this._txtEjecutivos_0);
            this._fraEjecutivos_0.Controls.Add(this._txtEjecutivos_1);
            this._fraEjecutivos_0.Controls.Add(this._lblEjecutivos_0);
            this._fraEjecutivos_0.Controls.Add(this._lblEjecutivos_1);
            this._fraEjecutivos_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraEjecutivos_0.Location = new System.Drawing.Point(13, 5);
            this._fraEjecutivos_0.Name = "_fraEjecutivos_0";
            this._fraEjecutivos_0.Size = new System.Drawing.Size(577, 55);
            this._fraEjecutivos_0.TabIndex = 39;
            this._fraEjecutivos_0.TabStop = false;
            this._fraEjecutivos_0.Tag = "";
            this._fraEjecutivos_0.Text = "Nombre de la Empresa";
            // 
            // _txtEjecutivos_0
            // 
            this._txtEjecutivos_0.AcceptsReturn = true;
            this._txtEjecutivos_0.BackColor = System.Drawing.SystemColors.Window;
            this._txtEjecutivos_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEjecutivos_0.Enabled = false;
            this._txtEjecutivos_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEjecutivos_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEjecutivos_0.Location = new System.Drawing.Point(72, 21);
            this._txtEjecutivos_0.MaxLength = 0;
            this._txtEjecutivos_0.Name = "_txtEjecutivos_0";
            this._txtEjecutivos_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEjecutivos_0.Size = new System.Drawing.Size(329, 20);
            this._txtEjecutivos_0.TabIndex = 46;
            this._txtEjecutivos_0.Tag = "";
            this._txtEjecutivos_0.Enter += new System.EventHandler(this.txtEjecutivos_Enter);
            this._txtEjecutivos_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEjecutivos_KeyPress);
            this._txtEjecutivos_0.Leave += new System.EventHandler(this.txtEjecutivos_Leave);
            this._txtEjecutivos_0.Validating += new System.ComponentModel.CancelEventHandler(this.txtEjecutivos_Validating);
            // 
            // _txtEjecutivos_1
            // 
            this._txtEjecutivos_1.AcceptsReturn = true;
            this._txtEjecutivos_1.BackColor = System.Drawing.SystemColors.Window;
            this._txtEjecutivos_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEjecutivos_1.Enabled = false;
            this._txtEjecutivos_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEjecutivos_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEjecutivos_1.Location = new System.Drawing.Point(472, 21);
            this._txtEjecutivos_1.MaxLength = 0;
            this._txtEjecutivos_1.Name = "_txtEjecutivos_1";
            this._txtEjecutivos_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEjecutivos_1.Size = new System.Drawing.Size(73, 20);
            this._txtEjecutivos_1.TabIndex = 47;
            this._txtEjecutivos_1.Tag = "";
            this._txtEjecutivos_1.Enter += new System.EventHandler(this.txtEjecutivos_Enter);
            this._txtEjecutivos_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEjecutivos_KeyPress);
            this._txtEjecutivos_1.Leave += new System.EventHandler(this.txtEjecutivos_Leave);
            this._txtEjecutivos_1.Validating += new System.ComponentModel.CancelEventHandler(this.txtEjecutivos_Validating);
            // 
            // _lblEjecutivos_0
            // 
            this._lblEjecutivos_0.AutoSize = true;
            this._lblEjecutivos_0.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_0.Location = new System.Drawing.Point(16, 24);
            this._lblEjecutivos_0.Name = "_lblEjecutivos_0";
            this._lblEjecutivos_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_0.Size = new System.Drawing.Size(50, 13);
            this._lblEjecutivos_0.TabIndex = 50;
            this._lblEjecutivos_0.Tag = "";
            this._lblEjecutivos_0.Text = "Nombre";
            // 
            // _lblEjecutivos_1
            // 
            this._lblEjecutivos_1.AutoSize = true;
            this._lblEjecutivos_1.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_1.Location = new System.Drawing.Point(416, 24);
            this._lblEjecutivos_1.Name = "_lblEjecutivos_1";
            this._lblEjecutivos_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_1.Size = new System.Drawing.Size(50, 13);
            this._lblEjecutivos_1.TabIndex = 51;
            this._lblEjecutivos_1.Tag = "";
            this._lblEjecutivos_1.Text = "Número";
            // 
            // _tabEjecutivos_TabPage1
            // 
            this._tabEjecutivos_TabPage1.BackColor = System.Drawing.Color.Transparent;
            this._tabEjecutivos_TabPage1.Controls.Add(this._fraEjecutivos_2);
            this._tabEjecutivos_TabPage1.Controls.Add(this._fraEjecutivos_3);
            this._tabEjecutivos_TabPage1.Location = new System.Drawing.Point(4, 22);
            this._tabEjecutivos_TabPage1.Name = "_tabEjecutivos_TabPage1";
            this._tabEjecutivos_TabPage1.Size = new System.Drawing.Size(597, 403);
            this._tabEjecutivos_TabPage1.TabIndex = 2;
            this._tabEjecutivos_TabPage1.Tag = "";
            this._tabEjecutivos_TabPage1.Text = "Domicilio";
            this._tabEjecutivos_TabPage1.UseVisualStyleBackColor = true;
            // 
            // _fraEjecutivos_2
            // 
            this._fraEjecutivos_2.Controls.Add(this._lblEjecutivos_22);
            this._fraEjecutivos_2.Controls.Add(this._lblEjecutivos_21);
            this._fraEjecutivos_2.Controls.Add(this._mskEjecutivos_9);
            this._fraEjecutivos_2.Controls.Add(this._mskEjecutivos_7);
            this._fraEjecutivos_2.Controls.Add(this._mskEjecutivos_8);
            this._fraEjecutivos_2.Controls.Add(this._lblEjecutivos_20);
            this._fraEjecutivos_2.Controls.Add(this._lblEjecutivos_16);
            this._fraEjecutivos_2.Controls.Add(this._lblEjecutivos_15);
            this._fraEjecutivos_2.Controls.Add(this._lblEjecutivos_17);
            this._fraEjecutivos_2.Controls.Add(this._lblEjecutivos_19);
            this._fraEjecutivos_2.Controls.Add(this._lblEjecutivos_18);
            this._fraEjecutivos_2.Controls.Add(this._mskEjecutivos_6);
            this._fraEjecutivos_2.Controls.Add(this._txtEjecutivos_9);
            this._fraEjecutivos_2.Controls.Add(this._cmbEjecutivos_1);
            this._fraEjecutivos_2.Controls.Add(this._txtEjecutivos_7);
            this._fraEjecutivos_2.Controls.Add(this._txtEjecutivos_8);
            this._fraEjecutivos_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraEjecutivos_2.Location = new System.Drawing.Point(13, 5);
            this._fraEjecutivos_2.Name = "_fraEjecutivos_2";
            this._fraEjecutivos_2.Size = new System.Drawing.Size(577, 177);
            this._fraEjecutivos_2.TabIndex = 41;
            this._fraEjecutivos_2.TabStop = false;
            this._fraEjecutivos_2.Tag = "";
            this._fraEjecutivos_2.Text = "Domicilio de Envio";
            // 
            // _lblEjecutivos_22
            // 
            this._lblEjecutivos_22.AutoSize = true;
            this._lblEjecutivos_22.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_22.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_22.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_22.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_22.Location = new System.Drawing.Point(424, 152);
            this._lblEjecutivos_22.Name = "_lblEjecutivos_22";
            this._lblEjecutivos_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_22.Size = new System.Drawing.Size(27, 13);
            this._lblEjecutivos_22.TabIndex = 72;
            this._lblEjecutivos_22.Tag = "";
            this._lblEjecutivos_22.Text = "Fax";
            // 
            // _lblEjecutivos_21
            // 
            this._lblEjecutivos_21.AutoSize = true;
            this._lblEjecutivos_21.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_21.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_21.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_21.Location = new System.Drawing.Point(272, 152);
            this._lblEjecutivos_21.Name = "_lblEjecutivos_21";
            this._lblEjecutivos_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_21.Size = new System.Drawing.Size(62, 13);
            this._lblEjecutivos_21.TabIndex = 71;
            this._lblEjecutivos_21.Tag = "";
            this._lblEjecutivos_21.Text = "Extensión";
            // 
            // _mskEjecutivos_9
            // 
            this._mskEjecutivos_9.Location = new System.Drawing.Point(456, 149);
            this._mskEjecutivos_9.Name = "_mskEjecutivos_9";
            this._mskEjecutivos_9.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEjecutivos_9.OcxState")));
            this._mskEjecutivos_9.Size = new System.Drawing.Size(102, 19);
            this._mskEjecutivos_9.TabIndex = 21;
            this._mskEjecutivos_9.Tag = "";
            this._mskEjecutivos_9.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEjecutivos_KeyPressEvent);
            this._mskEjecutivos_9.Enter += new System.EventHandler(this.mskEjecutivos_Enter);
            this._mskEjecutivos_9.Leave += new System.EventHandler(this.mskEjecutivos_Leave);
            this._mskEjecutivos_9.Validating += new System.ComponentModel.CancelEventHandler(this.mskEjecutivos_Validating);
            // 
            // _mskEjecutivos_7
            // 
            this._mskEjecutivos_7.Location = new System.Drawing.Point(136, 149);
            this._mskEjecutivos_7.Name = "_mskEjecutivos_7";
            this._mskEjecutivos_7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEjecutivos_7.OcxState")));
            this._mskEjecutivos_7.Size = new System.Drawing.Size(102, 19);
            this._mskEjecutivos_7.TabIndex = 19;
            this._mskEjecutivos_7.Tag = "";
            this._mskEjecutivos_7.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEjecutivos_KeyPressEvent);
            this._mskEjecutivos_7.Enter += new System.EventHandler(this.mskEjecutivos_Enter);
            this._mskEjecutivos_7.Leave += new System.EventHandler(this.mskEjecutivos_Leave);
            this._mskEjecutivos_7.Validating += new System.ComponentModel.CancelEventHandler(this.mskEjecutivos_Validating);
            // 
            // _mskEjecutivos_8
            // 
            this._mskEjecutivos_8.Location = new System.Drawing.Point(336, 149);
            this._mskEjecutivos_8.Name = "_mskEjecutivos_8";
            this._mskEjecutivos_8.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEjecutivos_8.OcxState")));
            this._mskEjecutivos_8.Size = new System.Drawing.Size(57, 19);
            this._mskEjecutivos_8.TabIndex = 20;
            this._mskEjecutivos_8.Tag = "";
            this._mskEjecutivos_8.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEjecutivos_KeyPressEvent);
            this._mskEjecutivos_8.Enter += new System.EventHandler(this.mskEjecutivos_Enter);
            this._mskEjecutivos_8.Leave += new System.EventHandler(this.mskEjecutivos_Leave);
            this._mskEjecutivos_8.Validating += new System.ComponentModel.CancelEventHandler(this.mskEjecutivos_Validating);
            // 
            // _lblEjecutivos_20
            // 
            this._lblEjecutivos_20.AutoSize = true;
            this._lblEjecutivos_20.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_20.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_20.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_20.Location = new System.Drawing.Point(16, 152);
            this._lblEjecutivos_20.Name = "_lblEjecutivos_20";
            this._lblEjecutivos_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_20.Size = new System.Drawing.Size(101, 13);
            this._lblEjecutivos_20.TabIndex = 70;
            this._lblEjecutivos_20.Tag = "";
            this._lblEjecutivos_20.Text = "Teléfono Oficina";
            // 
            // _lblEjecutivos_16
            // 
            this._lblEjecutivos_16.AutoSize = true;
            this._lblEjecutivos_16.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_16.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_16.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_16.Location = new System.Drawing.Point(16, 56);
            this._lblEjecutivos_16.Name = "_lblEjecutivos_16";
            this._lblEjecutivos_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_16.Size = new System.Drawing.Size(49, 13);
            this._lblEjecutivos_16.TabIndex = 66;
            this._lblEjecutivos_16.Tag = "";
            this._lblEjecutivos_16.Text = "Colonia";
            // 
            // _lblEjecutivos_15
            // 
            this._lblEjecutivos_15.AutoSize = true;
            this._lblEjecutivos_15.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_15.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_15.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_15.Location = new System.Drawing.Point(16, 24);
            this._lblEjecutivos_15.Name = "_lblEjecutivos_15";
            this._lblEjecutivos_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_15.Size = new System.Drawing.Size(92, 13);
            this._lblEjecutivos_15.TabIndex = 65;
            this._lblEjecutivos_15.Tag = "";
            this._lblEjecutivos_15.Text = "Calle y Número";
            // 
            // _lblEjecutivos_17
            // 
            this._lblEjecutivos_17.AutoSize = true;
            this._lblEjecutivos_17.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_17.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_17.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_17.Location = new System.Drawing.Point(16, 88);
            this._lblEjecutivos_17.Name = "_lblEjecutivos_17";
            this._lblEjecutivos_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_17.Size = new System.Drawing.Size(96, 13);
            this._lblEjecutivos_17.TabIndex = 67;
            this._lblEjecutivos_17.Tag = "";
            this._lblEjecutivos_17.Text = "Pob./Del./Mun.";
            // 
            // _lblEjecutivos_19
            // 
            this._lblEjecutivos_19.AutoSize = true;
            this._lblEjecutivos_19.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_19.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_19.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_19.Location = new System.Drawing.Point(392, 120);
            this._lblEjecutivos_19.Name = "_lblEjecutivos_19";
            this._lblEjecutivos_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_19.Size = new System.Drawing.Size(85, 13);
            this._lblEjecutivos_19.TabIndex = 69;
            this._lblEjecutivos_19.Tag = "";
            this._lblEjecutivos_19.Text = "Código Postal";
            // 
            // _lblEjecutivos_18
            // 
            this._lblEjecutivos_18.AutoSize = true;
            this._lblEjecutivos_18.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_18.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_18.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_18.Location = new System.Drawing.Point(16, 120);
            this._lblEjecutivos_18.Name = "_lblEjecutivos_18";
            this._lblEjecutivos_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_18.Size = new System.Drawing.Size(46, 13);
            this._lblEjecutivos_18.TabIndex = 68;
            this._lblEjecutivos_18.Tag = "";
            this._lblEjecutivos_18.Text = "&Estado";
            // 
            // _mskEjecutivos_6
            // 
            this._mskEjecutivos_6.Location = new System.Drawing.Point(480, 117);
            this._mskEjecutivos_6.Name = "_mskEjecutivos_6";
            this._mskEjecutivos_6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEjecutivos_6.OcxState")));
            this._mskEjecutivos_6.Size = new System.Drawing.Size(76, 19);
            this._mskEjecutivos_6.TabIndex = 18;
            this._mskEjecutivos_6.Tag = "";
            this._mskEjecutivos_6.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEjecutivos_KeyPressEvent);
            this._mskEjecutivos_6.Enter += new System.EventHandler(this.mskEjecutivos_Enter);
            this._mskEjecutivos_6.Leave += new System.EventHandler(this.mskEjecutivos_Leave);
            this._mskEjecutivos_6.Validating += new System.ComponentModel.CancelEventHandler(this.mskEjecutivos_Validating);
            // 
            // _txtEjecutivos_9
            // 
            this._txtEjecutivos_9.AcceptsReturn = true;
            this._txtEjecutivos_9.BackColor = System.Drawing.SystemColors.Window;
            this._txtEjecutivos_9.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEjecutivos_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEjecutivos_9.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEjecutivos_9.Location = new System.Drawing.Point(136, 85);
            this._txtEjecutivos_9.MaxLength = 21;
            this._txtEjecutivos_9.Name = "_txtEjecutivos_9";
            this._txtEjecutivos_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEjecutivos_9.Size = new System.Drawing.Size(417, 20);
            this._txtEjecutivos_9.TabIndex = 16;
            this._txtEjecutivos_9.Tag = "";
            this._txtEjecutivos_9.Enter += new System.EventHandler(this.txtEjecutivos_Enter);
            this._txtEjecutivos_9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEjecutivos_KeyPress);
            this._txtEjecutivos_9.Leave += new System.EventHandler(this.txtEjecutivos_Leave);
            this._txtEjecutivos_9.Validating += new System.ComponentModel.CancelEventHandler(this.txtEjecutivos_Validating);
            // 
            // _cmbEjecutivos_1
            // 
            this._cmbEjecutivos_1.BackColor = System.Drawing.SystemColors.Window;
            this._cmbEjecutivos_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmbEjecutivos_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbEjecutivos_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbEjecutivos_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this._cmbEjecutivos_1, new int[0]);
            this._cmbEjecutivos_1.Location = new System.Drawing.Point(136, 116);
            this._cmbEjecutivos_1.Name = "_cmbEjecutivos_1";
            this._cmbEjecutivos_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmbEjecutivos_1.Size = new System.Drawing.Size(200, 21);
            this._cmbEjecutivos_1.TabIndex = 17;
            this._cmbEjecutivos_1.Tag = "";
            this._cmbEjecutivos_1.SelectedIndexChanged += new System.EventHandler(this.cmbEjecutivos_SelectedIndexChanged);
            this._cmbEjecutivos_1.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEjecutivos_Validating);
            // 
            // _txtEjecutivos_7
            // 
            this._txtEjecutivos_7.AcceptsReturn = true;
            this._txtEjecutivos_7.BackColor = System.Drawing.SystemColors.Window;
            this._txtEjecutivos_7.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEjecutivos_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEjecutivos_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEjecutivos_7.Location = new System.Drawing.Point(136, 21);
            this._txtEjecutivos_7.MaxLength = 35;
            this._txtEjecutivos_7.Name = "_txtEjecutivos_7";
            this._txtEjecutivos_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEjecutivos_7.Size = new System.Drawing.Size(417, 20);
            this._txtEjecutivos_7.TabIndex = 14;
            this._txtEjecutivos_7.Tag = "";
            this._txtEjecutivos_7.Enter += new System.EventHandler(this.txtEjecutivos_Enter);
            this._txtEjecutivos_7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEjecutivos_KeyPress);
            this._txtEjecutivos_7.Leave += new System.EventHandler(this.txtEjecutivos_Leave);
            this._txtEjecutivos_7.Validating += new System.ComponentModel.CancelEventHandler(this.txtEjecutivos_Validating);
            // 
            // _txtEjecutivos_8
            // 
            this._txtEjecutivos_8.AcceptsReturn = true;
            this._txtEjecutivos_8.BackColor = System.Drawing.SystemColors.Window;
            this._txtEjecutivos_8.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEjecutivos_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEjecutivos_8.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEjecutivos_8.Location = new System.Drawing.Point(136, 53);
            this._txtEjecutivos_8.MaxLength = 25;
            this._txtEjecutivos_8.Name = "_txtEjecutivos_8";
            this._txtEjecutivos_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEjecutivos_8.Size = new System.Drawing.Size(417, 20);
            this._txtEjecutivos_8.TabIndex = 15;
            this._txtEjecutivos_8.Tag = "";
            this._txtEjecutivos_8.Enter += new System.EventHandler(this.txtEjecutivos_Enter);
            this._txtEjecutivos_8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEjecutivos_KeyPress);
            this._txtEjecutivos_8.Leave += new System.EventHandler(this.txtEjecutivos_Leave);
            this._txtEjecutivos_8.Validating += new System.ComponentModel.CancelEventHandler(this.txtEjecutivos_Validating);
            // 
            // _fraEjecutivos_3
            // 
            this._fraEjecutivos_3.Controls.Add(this._lblEjecutivos_29);
            this._fraEjecutivos_3.Controls.Add(this._lblEjecutivos_28);
            this._fraEjecutivos_3.Controls.Add(this._txtEjecutivos_10);
            this._fraEjecutivos_3.Controls.Add(this._lblEjecutivos_24);
            this._fraEjecutivos_3.Controls.Add(this._lblEjecutivos_23);
            this._fraEjecutivos_3.Controls.Add(this._lblEjecutivos_25);
            this._fraEjecutivos_3.Controls.Add(this._lblEjecutivos_27);
            this._fraEjecutivos_3.Controls.Add(this._lblEjecutivos_26);
            this._fraEjecutivos_3.Controls.Add(this._txtEjecutivos_11);
            this._fraEjecutivos_3.Controls.Add(this._cmbEjecutivos_2);
            this._fraEjecutivos_3.Controls.Add(this._txtEjecutivos_13);
            this._fraEjecutivos_3.Controls.Add(this._txtEjecutivos_12);
            this._fraEjecutivos_3.Controls.Add(this._mskEjecutivos_11);
            this._fraEjecutivos_3.Controls.Add(this._mskEjecutivos_10);
            this._fraEjecutivos_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraEjecutivos_3.Location = new System.Drawing.Point(13, 188);
            this._fraEjecutivos_3.Name = "_fraEjecutivos_3";
            this._fraEjecutivos_3.Size = new System.Drawing.Size(577, 209);
            this._fraEjecutivos_3.TabIndex = 42;
            this._fraEjecutivos_3.TabStop = false;
            this._fraEjecutivos_3.Tag = "";
            this._fraEjecutivos_3.Text = "Domicilio Particular";
            // 
            // _lblEjecutivos_29
            // 
            this._lblEjecutivos_29.AutoSize = true;
            this._lblEjecutivos_29.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_29.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_29.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_29.Location = new System.Drawing.Point(16, 184);
            this._lblEjecutivos_29.Name = "_lblEjecutivos_29";
            this._lblEjecutivos_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_29.Size = new System.Drawing.Size(112, 13);
            this._lblEjecutivos_29.TabIndex = 79;
            this._lblEjecutivos_29.Tag = "";
            this._lblEjecutivos_29.Text = "Teléfono Domicilio";
            // 
            // _lblEjecutivos_28
            // 
            this._lblEjecutivos_28.AutoSize = true;
            this._lblEjecutivos_28.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_28.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_28.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_28.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_28.Location = new System.Drawing.Point(392, 152);
            this._lblEjecutivos_28.Name = "_lblEjecutivos_28";
            this._lblEjecutivos_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_28.Size = new System.Drawing.Size(85, 13);
            this._lblEjecutivos_28.TabIndex = 78;
            this._lblEjecutivos_28.Tag = "";
            this._lblEjecutivos_28.Text = "Código Postal";
            // 
            // _txtEjecutivos_10
            // 
            this._txtEjecutivos_10.AcceptsReturn = true;
            this._txtEjecutivos_10.BackColor = System.Drawing.SystemColors.Window;
            this._txtEjecutivos_10.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEjecutivos_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEjecutivos_10.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEjecutivos_10.Location = new System.Drawing.Point(136, 21);
            this._txtEjecutivos_10.MaxLength = 35;
            this._txtEjecutivos_10.Name = "_txtEjecutivos_10";
            this._txtEjecutivos_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEjecutivos_10.Size = new System.Drawing.Size(425, 20);
            this._txtEjecutivos_10.TabIndex = 22;
            this._txtEjecutivos_10.Tag = "";
            this._txtEjecutivos_10.Enter += new System.EventHandler(this.txtEjecutivos_Enter);
            this._txtEjecutivos_10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEjecutivos_KeyPress);
            this._txtEjecutivos_10.Leave += new System.EventHandler(this.txtEjecutivos_Leave);
            this._txtEjecutivos_10.Validating += new System.ComponentModel.CancelEventHandler(this.txtEjecutivos_Validating);
            // 
            // _lblEjecutivos_24
            // 
            this._lblEjecutivos_24.AutoSize = true;
            this._lblEjecutivos_24.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_24.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_24.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_24.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_24.Location = new System.Drawing.Point(16, 56);
            this._lblEjecutivos_24.Name = "_lblEjecutivos_24";
            this._lblEjecutivos_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_24.Size = new System.Drawing.Size(49, 13);
            this._lblEjecutivos_24.TabIndex = 74;
            this._lblEjecutivos_24.Tag = "";
            this._lblEjecutivos_24.Text = "Colonia";
            // 
            // _lblEjecutivos_23
            // 
            this._lblEjecutivos_23.AutoSize = true;
            this._lblEjecutivos_23.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_23.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_23.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_23.Location = new System.Drawing.Point(16, 24);
            this._lblEjecutivos_23.Name = "_lblEjecutivos_23";
            this._lblEjecutivos_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_23.Size = new System.Drawing.Size(92, 13);
            this._lblEjecutivos_23.TabIndex = 73;
            this._lblEjecutivos_23.Tag = "";
            this._lblEjecutivos_23.Text = "Calle y Número";
            // 
            // _lblEjecutivos_25
            // 
            this._lblEjecutivos_25.AutoSize = true;
            this._lblEjecutivos_25.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_25.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_25.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_25.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_25.Location = new System.Drawing.Point(16, 88);
            this._lblEjecutivos_25.Name = "_lblEjecutivos_25";
            this._lblEjecutivos_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_25.Size = new System.Drawing.Size(96, 13);
            this._lblEjecutivos_25.TabIndex = 75;
            this._lblEjecutivos_25.Tag = "";
            this._lblEjecutivos_25.Text = "Pob./Del./Mun.";
            // 
            // _lblEjecutivos_27
            // 
            this._lblEjecutivos_27.AutoSize = true;
            this._lblEjecutivos_27.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_27.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_27.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_27.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_27.Location = new System.Drawing.Point(16, 152);
            this._lblEjecutivos_27.Name = "_lblEjecutivos_27";
            this._lblEjecutivos_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_27.Size = new System.Drawing.Size(46, 13);
            this._lblEjecutivos_27.TabIndex = 77;
            this._lblEjecutivos_27.Tag = "";
            this._lblEjecutivos_27.Text = "Estado";
            // 
            // _lblEjecutivos_26
            // 
            this._lblEjecutivos_26.AutoSize = true;
            this._lblEjecutivos_26.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_26.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_26.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_26.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_26.Location = new System.Drawing.Point(16, 120);
            this._lblEjecutivos_26.Name = "_lblEjecutivos_26";
            this._lblEjecutivos_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_26.Size = new System.Drawing.Size(46, 13);
            this._lblEjecutivos_26.TabIndex = 76;
            this._lblEjecutivos_26.Tag = "";
            this._lblEjecutivos_26.Text = "Ciudad";
            // 
            // _txtEjecutivos_11
            // 
            this._txtEjecutivos_11.AcceptsReturn = true;
            this._txtEjecutivos_11.BackColor = System.Drawing.SystemColors.Window;
            this._txtEjecutivos_11.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEjecutivos_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEjecutivos_11.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEjecutivos_11.Location = new System.Drawing.Point(136, 53);
            this._txtEjecutivos_11.MaxLength = 25;
            this._txtEjecutivos_11.Name = "_txtEjecutivos_11";
            this._txtEjecutivos_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEjecutivos_11.Size = new System.Drawing.Size(425, 20);
            this._txtEjecutivos_11.TabIndex = 23;
            this._txtEjecutivos_11.Tag = "";
            this._txtEjecutivos_11.Enter += new System.EventHandler(this.txtEjecutivos_Enter);
            this._txtEjecutivos_11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEjecutivos_KeyPress);
            this._txtEjecutivos_11.Leave += new System.EventHandler(this.txtEjecutivos_Leave);
            this._txtEjecutivos_11.Validating += new System.ComponentModel.CancelEventHandler(this.txtEjecutivos_Validating);
            // 
            // _cmbEjecutivos_2
            // 
            this._cmbEjecutivos_2.BackColor = System.Drawing.SystemColors.Window;
            this._cmbEjecutivos_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmbEjecutivos_2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._cmbEjecutivos_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbEjecutivos_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this._cmbEjecutivos_2, new int[0]);
            this._cmbEjecutivos_2.Location = new System.Drawing.Point(136, 148);
            this._cmbEjecutivos_2.Name = "_cmbEjecutivos_2";
            this._cmbEjecutivos_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmbEjecutivos_2.Size = new System.Drawing.Size(200, 21);
            this._cmbEjecutivos_2.TabIndex = 26;
            this._cmbEjecutivos_2.Tag = "";
            this._cmbEjecutivos_2.SelectedIndexChanged += new System.EventHandler(this.cmbEjecutivos_SelectedIndexChanged);
            this._cmbEjecutivos_2.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEjecutivos_Validating);
            // 
            // _txtEjecutivos_13
            // 
            this._txtEjecutivos_13.AcceptsReturn = true;
            this._txtEjecutivos_13.BackColor = System.Drawing.SystemColors.Window;
            this._txtEjecutivos_13.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEjecutivos_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEjecutivos_13.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEjecutivos_13.Location = new System.Drawing.Point(136, 117);
            this._txtEjecutivos_13.MaxLength = 25;
            this._txtEjecutivos_13.Name = "_txtEjecutivos_13";
            this._txtEjecutivos_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEjecutivos_13.Size = new System.Drawing.Size(425, 20);
            this._txtEjecutivos_13.TabIndex = 25;
            this._txtEjecutivos_13.Tag = "";
            this._txtEjecutivos_13.Enter += new System.EventHandler(this.txtEjecutivos_Enter);
            this._txtEjecutivos_13.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEjecutivos_KeyPress);
            this._txtEjecutivos_13.Leave += new System.EventHandler(this.txtEjecutivos_Leave);
            this._txtEjecutivos_13.Validating += new System.ComponentModel.CancelEventHandler(this.txtEjecutivos_Validating);
            // 
            // _txtEjecutivos_12
            // 
            this._txtEjecutivos_12.AcceptsReturn = true;
            this._txtEjecutivos_12.BackColor = System.Drawing.SystemColors.Window;
            this._txtEjecutivos_12.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEjecutivos_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEjecutivos_12.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEjecutivos_12.Location = new System.Drawing.Point(136, 85);
            this._txtEjecutivos_12.MaxLength = 25;
            this._txtEjecutivos_12.Name = "_txtEjecutivos_12";
            this._txtEjecutivos_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEjecutivos_12.Size = new System.Drawing.Size(425, 20);
            this._txtEjecutivos_12.TabIndex = 24;
            this._txtEjecutivos_12.Tag = "";
            this._txtEjecutivos_12.Enter += new System.EventHandler(this.txtEjecutivos_Enter);
            this._txtEjecutivos_12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEjecutivos_KeyPress);
            this._txtEjecutivos_12.Leave += new System.EventHandler(this.txtEjecutivos_Leave);
            this._txtEjecutivos_12.Validating += new System.ComponentModel.CancelEventHandler(this.txtEjecutivos_Validating);
            // 
            // _mskEjecutivos_11
            // 
            this._mskEjecutivos_11.Location = new System.Drawing.Point(136, 181);
            this._mskEjecutivos_11.Name = "_mskEjecutivos_11";
            this._mskEjecutivos_11.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEjecutivos_11.OcxState")));
            this._mskEjecutivos_11.Size = new System.Drawing.Size(153, 19);
            this._mskEjecutivos_11.TabIndex = 28;
            this._mskEjecutivos_11.Tag = "";
            this._mskEjecutivos_11.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEjecutivos_KeyPressEvent);
            this._mskEjecutivos_11.Enter += new System.EventHandler(this.mskEjecutivos_Enter);
            this._mskEjecutivos_11.Leave += new System.EventHandler(this.mskEjecutivos_Leave);
            this._mskEjecutivos_11.Validating += new System.ComponentModel.CancelEventHandler(this.mskEjecutivos_Validating);
            // 
            // _mskEjecutivos_10
            // 
            this._mskEjecutivos_10.Location = new System.Drawing.Point(485, 152);
            this._mskEjecutivos_10.Name = "_mskEjecutivos_10";
            this._mskEjecutivos_10.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEjecutivos_10.OcxState")));
            this._mskEjecutivos_10.Size = new System.Drawing.Size(76, 19);
            this._mskEjecutivos_10.TabIndex = 27;
            this._mskEjecutivos_10.Tag = "";
            this._mskEjecutivos_10.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEjecutivos_KeyPressEvent);
            this._mskEjecutivos_10.Enter += new System.EventHandler(this.mskEjecutivos_Enter);
            this._mskEjecutivos_10.Leave += new System.EventHandler(this.mskEjecutivos_Leave);
            this._mskEjecutivos_10.Validating += new System.ComponentModel.CancelEventHandler(this.mskEjecutivos_Validating);
            // 
            // _tabEjecutivos_TabPage2
            // 
            this._tabEjecutivos_TabPage2.BackColor = System.Drawing.Color.Transparent;
            this._tabEjecutivos_TabPage2.Controls.Add(this._mskEjecutivos_12);
            this._tabEjecutivos_TabPage2.Controls.Add(this._fraEjecutivos_6);
            this._tabEjecutivos_TabPage2.Controls.Add(this._pnlEjecutivos_1);
            this._tabEjecutivos_TabPage2.Controls.Add(this._lblEjecutivos_30);
            this._tabEjecutivos_TabPage2.Controls.Add(this._lblEjecutivos_31);
            this._tabEjecutivos_TabPage2.Controls.Add(this._fraEjecutivos_5);
            this._tabEjecutivos_TabPage2.Controls.Add(this._fraDatosAdicionales_3);
            this._tabEjecutivos_TabPage2.Controls.Add(this._fraEjecutivos_7);
            this._tabEjecutivos_TabPage2.Controls.Add(this._fraEjecutivos_4);
            this._tabEjecutivos_TabPage2.Location = new System.Drawing.Point(4, 22);
            this._tabEjecutivos_TabPage2.Name = "_tabEjecutivos_TabPage2";
            this._tabEjecutivos_TabPage2.Size = new System.Drawing.Size(597, 403);
            this._tabEjecutivos_TabPage2.TabIndex = 1;
            this._tabEjecutivos_TabPage2.Tag = "";
            this._tabEjecutivos_TabPage2.Text = "Datos Adicionales";
            this._tabEjecutivos_TabPage2.UseVisualStyleBackColor = true;
            // 
            // _mskEjecutivos_12
            // 
            this._mskEjecutivos_12.Location = new System.Drawing.Point(472, 137);
            this._mskEjecutivos_12.Name = "_mskEjecutivos_12";
            this._mskEjecutivos_12.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEjecutivos_12.OcxState")));
            this._mskEjecutivos_12.Size = new System.Drawing.Size(98, 19);
            this._mskEjecutivos_12.TabIndex = 35;
            this._mskEjecutivos_12.Tag = "";
            this._mskEjecutivos_12.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEjecutivos_KeyPressEvent);
            this._mskEjecutivos_12.Enter += new System.EventHandler(this.mskEjecutivos_Enter);
            this._mskEjecutivos_12.Leave += new System.EventHandler(this.mskEjecutivos_Leave);
            this._mskEjecutivos_12.Validating += new System.ComponentModel.CancelEventHandler(this.mskEjecutivos_Validating);
            // 
            // _fraEjecutivos_6
            // 
            this._fraEjecutivos_6.Controls.Add(this._chkEjecutivos_3);
            this._fraEjecutivos_6.Controls.Add(this._chkEjecutivos_2);
            this._fraEjecutivos_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraEjecutivos_6.Location = new System.Drawing.Point(24, 164);
            this._fraEjecutivos_6.Name = "_fraEjecutivos_6";
            this._fraEjecutivos_6.Size = new System.Drawing.Size(265, 137);
            this._fraEjecutivos_6.TabIndex = 45;
            this._fraEjecutivos_6.TabStop = false;
            this._fraEjecutivos_6.Tag = "";
            // 
            // _chkEjecutivos_3
            // 
            this._chkEjecutivos_3.BackColor = System.Drawing.SystemColors.Control;
            this._chkEjecutivos_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._chkEjecutivos_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chkEjecutivos_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._chkEjecutivos_3.Location = new System.Drawing.Point(32, 64);
            this._chkEjecutivos_3.Name = "_chkEjecutivos_3";
            this._chkEjecutivos_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._chkEjecutivos_3.Size = new System.Drawing.Size(113, 18);
            this._chkEjecutivos_3.TabIndex = 37;
            this._chkEjecutivos_3.Tag = "";
            this._chkEjecutivos_3.Text = "Cuenta Control";
            this._chkEjecutivos_3.UseVisualStyleBackColor = false;
            this._chkEjecutivos_3.CheckStateChanged += new System.EventHandler(this.chkEjecutivos_CheckStateChanged);
            // 
            // _chkEjecutivos_2
            // 
            this._chkEjecutivos_2.BackColor = System.Drawing.SystemColors.Control;
            this._chkEjecutivos_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._chkEjecutivos_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chkEjecutivos_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._chkEjecutivos_2.Location = new System.Drawing.Point(32, 24);
            this._chkEjecutivos_2.Name = "_chkEjecutivos_2";
            this._chkEjecutivos_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._chkEjecutivos_2.Size = new System.Drawing.Size(113, 19);
            this._chkEjecutivos_2.TabIndex = 36;
            this._chkEjecutivos_2.Tag = "";
            this._chkEjecutivos_2.Text = "Skip Payment";
            this._chkEjecutivos_2.UseVisualStyleBackColor = false;
            this._chkEjecutivos_2.CheckStateChanged += new System.EventHandler(this.chkEjecutivos_CheckStateChanged);
            // 
            // _pnlEjecutivos_1
            // 
            this._pnlEjecutivos_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this._pnlEjecutivos_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._pnlEjecutivos_1.Controls.Add(this._optEjecutivos_4);
            this._pnlEjecutivos_1.Controls.Add(this._optEjecutivos_5);
            this._pnlEjecutivos_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._pnlEjecutivos_1.Location = new System.Drawing.Point(112, 130);
            this._pnlEjecutivos_1.Name = "_pnlEjecutivos_1";
            this._pnlEjecutivos_1.Size = new System.Drawing.Size(177, 33);
            this._pnlEjecutivos_1.TabIndex = 49;
            this._pnlEjecutivos_1.Tag = "";
            // 
            // _optEjecutivos_4
            // 
            this._optEjecutivos_4.Location = new System.Drawing.Point(8, 8);
            this._optEjecutivos_4.Name = "_optEjecutivos_4";
            this._optEjecutivos_4.Size = new System.Drawing.Size(74, 20);
            this._optEjecutivos_4.TabIndex = 33;
            this._optEjecutivos_4.Tag = "";
            this._optEjecutivos_4.Text = "Mexicana";
            // 
            // _optEjecutivos_5
            // 
            this._optEjecutivos_5.Location = new System.Drawing.Point(88, 8);
            this._optEjecutivos_5.Name = "_optEjecutivos_5";
            this._optEjecutivos_5.Size = new System.Drawing.Size(74, 20);
            this._optEjecutivos_5.TabIndex = 34;
            this._optEjecutivos_5.Tag = "";
            this._optEjecutivos_5.Text = "Extranjera";
            // 
            // _lblEjecutivos_30
            // 
            this._lblEjecutivos_30.AutoSize = true;
            this._lblEjecutivos_30.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_30.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_30.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_30.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_30.Location = new System.Drawing.Point(24, 140);
            this._lblEjecutivos_30.Name = "_lblEjecutivos_30";
            this._lblEjecutivos_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_30.Size = new System.Drawing.Size(81, 13);
            this._lblEjecutivos_30.TabIndex = 80;
            this._lblEjecutivos_30.Tag = "";
            this._lblEjecutivos_30.Text = "Nacionalidad";
            // 
            // _lblEjecutivos_31
            // 
            this._lblEjecutivos_31.AutoSize = true;
            this._lblEjecutivos_31.BackColor = System.Drawing.SystemColors.Control;
            this._lblEjecutivos_31.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEjecutivos_31.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEjecutivos_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEjecutivos_31.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEjecutivos_31.Location = new System.Drawing.Point(320, 140);
            this._lblEjecutivos_31.Name = "_lblEjecutivos_31";
            this._lblEjecutivos_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEjecutivos_31.Size = new System.Drawing.Size(130, 13);
            this._lblEjecutivos_31.TabIndex = 81;
            this._lblEjecutivos_31.Tag = "";
            this._lblEjecutivos_31.Text = "Tabla MCC / Negocio";
            // 
            // _fraEjecutivos_5
            // 
            this._fraEjecutivos_5.Controls.Add(this._optEjecutivos_2);
            this._fraEjecutivos_5.Controls.Add(this._optEjecutivos_3);
            this._fraEjecutivos_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraEjecutivos_5.Location = new System.Drawing.Point(320, 20);
            this._fraEjecutivos_5.Name = "_fraEjecutivos_5";
            this._fraEjecutivos_5.Size = new System.Drawing.Size(249, 97);
            this._fraEjecutivos_5.TabIndex = 44;
            this._fraEjecutivos_5.TabStop = false;
            this._fraEjecutivos_5.Tag = "";
            this._fraEjecutivos_5.Text = "Tipo de Facturación";
            // 
            // _optEjecutivos_2
            // 
            this._optEjecutivos_2.Location = new System.Drawing.Point(40, 32);
            this._optEjecutivos_2.Name = "_optEjecutivos_2";
            this._optEjecutivos_2.Size = new System.Drawing.Size(100, 18);
            this._optEjecutivos_2.TabIndex = 31;
            this._optEjecutivos_2.Tag = "";
            this._optEjecutivos_2.Text = "Corporativo";
            this._optEjecutivos_2.CheckedChanged += new System.EventHandler(this._optEjecutivos_2_CheckedChanged);
            // 
            // _optEjecutivos_3
            // 
            this._optEjecutivos_3.Location = new System.Drawing.Point(40, 64);
            this._optEjecutivos_3.Name = "_optEjecutivos_3";
            this._optEjecutivos_3.Size = new System.Drawing.Size(100, 18);
            this._optEjecutivos_3.TabIndex = 32;
            this._optEjecutivos_3.Tag = "";
            this._optEjecutivos_3.Text = "Individual";
            this._optEjecutivos_3.CheckedChanged += new System.EventHandler(this._optEjecutivos_3_CheckedChanged);
            // 
            // _fraDatosAdicionales_3
            // 
            this._fraDatosAdicionales_3.BackColor = System.Drawing.SystemColors.Control;
            this._fraDatosAdicionales_3.Controls.Add(this.txtAtencionA);
            this._fraDatosAdicionales_3.Controls.Add(this.ID_MEM_PERSONA);
            this._fraDatosAdicionales_3.Controls.Add(this._ID_MEE_ETT_TXT_9);
            this._fraDatosAdicionales_3.Controls.Add(this._ID_MEE_ETT_TXT_7);
            this._fraDatosAdicionales_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraDatosAdicionales_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._fraDatosAdicionales_3.Location = new System.Drawing.Point(24, 308);
            this._fraDatosAdicionales_3.Name = "_fraDatosAdicionales_3";
            this._fraDatosAdicionales_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._fraDatosAdicionales_3.Size = new System.Drawing.Size(545, 81);
            this._fraDatosAdicionales_3.TabIndex = 89;
            this._fraDatosAdicionales_3.TabStop = false;
            this._fraDatosAdicionales_3.Tag = "";
            // 
            // txtAtencionA
            // 
            this.txtAtencionA.AcceptsReturn = true;
            this.txtAtencionA.BackColor = System.Drawing.Color.White;
            this.txtAtencionA.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtAtencionA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAtencionA.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtAtencionA.Location = new System.Drawing.Point(96, 48);
            this.txtAtencionA.MaxLength = 45;
            this.txtAtencionA.Name = "txtAtencionA";
            this.txtAtencionA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtAtencionA.Size = new System.Drawing.Size(376, 20);
            this.txtAtencionA.TabIndex = 90;
            this.txtAtencionA.Tag = "";
            this.txtAtencionA.Enter += new System.EventHandler(this.txtAtencionA_Enter);
            this.txtAtencionA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAtencionA_KeyPress);
            // 
            // ID_MEM_PERSONA
            // 
            this.ID_MEM_PERSONA.BackColor = System.Drawing.SystemColors.Window;
            this.ID_MEM_PERSONA.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_PERSONA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_MEM_PERSONA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_PERSONA.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this.ID_MEM_PERSONA, new int[] {
            0,
            0,
            0});
            this.ID_MEM_PERSONA.Items.AddRange(new object[] {
            "1 PERSONA MORAL",
            "2 PERSONA FISICA",
            "3 PERSONA FISICA C/ACT. EMPRESARIAL"});
            this.ID_MEM_PERSONA.Location = new System.Drawing.Point(96, 16);
            this.ID_MEM_PERSONA.Name = "ID_MEM_PERSONA";
            this.ID_MEM_PERSONA.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_PERSONA.Size = new System.Drawing.Size(375, 21);
            this.ID_MEM_PERSONA.TabIndex = 91;
            this.ID_MEM_PERSONA.Tag = "";
            // 
            // _ID_MEE_ETT_TXT_9
            // 
            this._ID_MEE_ETT_TXT_9.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_9.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_9.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_9.Location = new System.Drawing.Point(16, 50);
            this._ID_MEE_ETT_TXT_9.Name = "_ID_MEE_ETT_TXT_9";
            this._ID_MEE_ETT_TXT_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_9.Size = new System.Drawing.Size(73, 17);
            this._ID_MEE_ETT_TXT_9.TabIndex = 92;
            this._ID_MEE_ETT_TXT_9.Tag = "";
            this._ID_MEE_ETT_TXT_9.Text = "&Atención A: ";
            // 
            // _ID_MEE_ETT_TXT_7
            // 
            this._ID_MEE_ETT_TXT_7.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_7.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_7.Location = new System.Drawing.Point(16, 17);
            this._ID_MEE_ETT_TXT_7.Name = "_ID_MEE_ETT_TXT_7";
            this._ID_MEE_ETT_TXT_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_7.Size = new System.Drawing.Size(55, 17);
            this._ID_MEE_ETT_TXT_7.TabIndex = 93;
            this._ID_MEE_ETT_TXT_7.Tag = "";
            this._ID_MEE_ETT_TXT_7.Text = "&Persona";
            // 
            // _fraEjecutivos_7
            // 
            this._fraEjecutivos_7.Controls.Add(this._optEjecutivos_6);
            this._fraEjecutivos_7.Controls.Add(this._optEjecutivos_7);
            this._fraEjecutivos_7.Controls.Add(this._optEjecutivos_8);
            this._fraEjecutivos_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraEjecutivos_7.Location = new System.Drawing.Point(320, 164);
            this._fraEjecutivos_7.Name = "_fraEjecutivos_7";
            this._fraEjecutivos_7.Size = new System.Drawing.Size(249, 137);
            this._fraEjecutivos_7.TabIndex = 85;
            this._fraEjecutivos_7.TabStop = false;
            this._fraEjecutivos_7.Tag = "";
            this._fraEjecutivos_7.Text = "Tipo de Bloqueo";
            // 
            // _optEjecutivos_6
            // 
            this._optEjecutivos_6.Location = new System.Drawing.Point(40, 32);
            this._optEjecutivos_6.Name = "_optEjecutivos_6";
            this._optEjecutivos_6.Size = new System.Drawing.Size(136, 26);
            this._optEjecutivos_6.TabIndex = 86;
            this._optEjecutivos_6.Tag = "";
            this._optEjecutivos_6.Text = "No maneja bloqueo";
            this._optEjecutivos_6.CheckedChanged += new System.EventHandler(this._optEjecutivos_6_CheckedChanged);
            // 
            // _optEjecutivos_7
            // 
            this._optEjecutivos_7.Location = new System.Drawing.Point(40, 64);
            this._optEjecutivos_7.Name = "_optEjecutivos_7";
            this._optEjecutivos_7.Size = new System.Drawing.Size(135, 26);
            this._optEjecutivos_7.TabIndex = 87;
            this._optEjecutivos_7.Tag = "";
            this._optEjecutivos_7.Text = "Bloqueo por MCC";
            this._optEjecutivos_7.CheckedChanged += new System.EventHandler(this._optEjecutivos_7_CheckedChanged);
            // 
            // _optEjecutivos_8
            // 
            this._optEjecutivos_8.Location = new System.Drawing.Point(40, 96);
            this._optEjecutivos_8.Name = "_optEjecutivos_8";
            this._optEjecutivos_8.Size = new System.Drawing.Size(192, 24);
            this._optEjecutivos_8.TabIndex = 88;
            this._optEjecutivos_8.Tag = "";
            this._optEjecutivos_8.Text = "Bloqueo por No. de Negocio";
            this._optEjecutivos_8.CheckedChanged += new System.EventHandler(this._optEjecutivos_8_CheckedChanged);
            // 
            // _fraEjecutivos_4
            // 
            this._fraEjecutivos_4.Controls.Add(this._chkEjecutivos_1);
            this._fraEjecutivos_4.Controls.Add(this._chkEjecutivos_0);
            this._fraEjecutivos_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraEjecutivos_4.Location = new System.Drawing.Point(24, 20);
            this._fraEjecutivos_4.Name = "_fraEjecutivos_4";
            this._fraEjecutivos_4.Size = new System.Drawing.Size(265, 97);
            this._fraEjecutivos_4.TabIndex = 43;
            this._fraEjecutivos_4.TabStop = false;
            this._fraEjecutivos_4.Tag = "";
            this._fraEjecutivos_4.Text = "Plástico Pin";
            // 
            // _chkEjecutivos_1
            // 
            this._chkEjecutivos_1.BackColor = System.Drawing.SystemColors.Control;
            this._chkEjecutivos_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._chkEjecutivos_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chkEjecutivos_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._chkEjecutivos_1.Location = new System.Drawing.Point(32, 64);
            this._chkEjecutivos_1.Name = "_chkEjecutivos_1";
            this._chkEjecutivos_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._chkEjecutivos_1.Size = new System.Drawing.Size(113, 18);
            this._chkEjecutivos_1.TabIndex = 30;
            this._chkEjecutivos_1.Tag = "";
            this._chkEjecutivos_1.Text = "Generar Pin";
            this._chkEjecutivos_1.UseVisualStyleBackColor = false;
            this._chkEjecutivos_1.CheckStateChanged += new System.EventHandler(this.chkEjecutivos_CheckStateChanged);
            // 
            // _chkEjecutivos_0
            // 
            this._chkEjecutivos_0.BackColor = System.Drawing.SystemColors.Control;
            this._chkEjecutivos_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._chkEjecutivos_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chkEjecutivos_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._chkEjecutivos_0.Location = new System.Drawing.Point(32, 32);
            this._chkEjecutivos_0.Name = "_chkEjecutivos_0";
            this._chkEjecutivos_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._chkEjecutivos_0.Size = new System.Drawing.Size(129, 18);
            this._chkEjecutivos_0.TabIndex = 29;
            this._chkEjecutivos_0.Tag = "";
            this._chkEjecutivos_0.Text = "Generar Plástico";
            this._chkEjecutivos_0.UseVisualStyleBackColor = false;
            this._chkEjecutivos_0.CheckStateChanged += new System.EventHandler(this.chkEjecutivos_CheckStateChanged);
            // 
            // frmEjecutivo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Menu;
            this.ClientSize = new System.Drawing.Size(602, 462);
            this.Controls.Add(this._cmdEjecutivos_1);
            this.Controls.Add(this._cmdEjecutivos_0);
            this.Controls.Add(this.tabEjecutivos);
            this.Controls.Add(this._cmdEjecutivos_2);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(225, 265);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEjecutivo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Tarjetahabientes Empresa";
            this.Activated += new System.EventHandler(this.frmEjecutivo_Activated);
            this.Closed += new System.EventHandler(this.frmEjecutivo_Closed);
            this.Load += new System.EventHandler(this.Form_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEjecutivo_KeyPress);
            this.tabEjecutivos.ResumeLayout(false);
            this._tabEjecutivos_TabPage0.ResumeLayout(false);
            this._fraEjecutivos_1.ResumeLayout(false);
            this._fraEjecutivos_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_0)).EndInit();
            this._pnlEjecutivos_0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_1)).EndInit();
            this._fraEjecutivos_0.ResumeLayout(false);
            this._fraEjecutivos_0.PerformLayout();
            this._tabEjecutivos_TabPage1.ResumeLayout(false);
            this._fraEjecutivos_2.ResumeLayout(false);
            this._fraEjecutivos_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_6)).EndInit();
            this._fraEjecutivos_3.ResumeLayout(false);
            this._fraEjecutivos_3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_10)).EndInit();
            this._tabEjecutivos_TabPage2.ResumeLayout(false);
            this._tabEjecutivos_TabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEjecutivos_12)).EndInit();
            this._fraEjecutivos_6.ResumeLayout(false);
            this._pnlEjecutivos_1.ResumeLayout(false);
            this._fraEjecutivos_5.ResumeLayout(false);
            this._fraDatosAdicionales_3.ResumeLayout(false);
            this._fraDatosAdicionales_3.PerformLayout();
            this._fraEjecutivos_7.ResumeLayout(false);
            this._fraEjecutivos_4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ssTabHelper1)).EndInit();
            this.ResumeLayout(false);

	}
	void  InitializeoptEjecutivos()
	{
			this.optEjecutivos[6] = _optEjecutivos_6;
			this.optEjecutivos[7] = _optEjecutivos_7;
			this.optEjecutivos[8] = _optEjecutivos_8;
			this.optEjecutivos[1] = _optEjecutivos_1;
			this.optEjecutivos[0] = _optEjecutivos_0;
			this.optEjecutivos[2] = _optEjecutivos_2;
			this.optEjecutivos[3] = _optEjecutivos_3;
			this.optEjecutivos[4] = _optEjecutivos_4;
			this.optEjecutivos[5] = _optEjecutivos_5;
	}
	void  InitializelblEjecutivos()
	{
			this.lblEjecutivos[1] = _lblEjecutivos_1;
			this.lblEjecutivos[0] = _lblEjecutivos_0;
			this.lblEjecutivos[14] = _lblEjecutivos_14;
			this.lblEjecutivos[13] = _lblEjecutivos_13;
			this.lblEjecutivos[12] = _lblEjecutivos_12;
			this.lblEjecutivos[11] = _lblEjecutivos_11;
			this.lblEjecutivos[10] = _lblEjecutivos_10;
			this.lblEjecutivos[9] = _lblEjecutivos_9;
			this.lblEjecutivos[8] = _lblEjecutivos_8;
			this.lblEjecutivos[7] = _lblEjecutivos_7;
			this.lblEjecutivos[6] = _lblEjecutivos_6;
			this.lblEjecutivos[5] = _lblEjecutivos_5;
			this.lblEjecutivos[4] = _lblEjecutivos_4;
			this.lblEjecutivos[3] = _lblEjecutivos_3;
			this.lblEjecutivos[2] = _lblEjecutivos_2;
			this.lblEjecutivos[22] = _lblEjecutivos_22;
			this.lblEjecutivos[21] = _lblEjecutivos_21;
			this.lblEjecutivos[20] = _lblEjecutivos_20;
			this.lblEjecutivos[19] = _lblEjecutivos_19;
			this.lblEjecutivos[18] = _lblEjecutivos_18;
			this.lblEjecutivos[17] = _lblEjecutivos_17;
			this.lblEjecutivos[16] = _lblEjecutivos_16;
			this.lblEjecutivos[15] = _lblEjecutivos_15;
			this.lblEjecutivos[29] = _lblEjecutivos_29;
			this.lblEjecutivos[28] = _lblEjecutivos_28;
			this.lblEjecutivos[27] = _lblEjecutivos_27;
			this.lblEjecutivos[26] = _lblEjecutivos_26;
			this.lblEjecutivos[25] = _lblEjecutivos_25;
			this.lblEjecutivos[24] = _lblEjecutivos_24;
			this.lblEjecutivos[23] = _lblEjecutivos_23;
			this.lblEjecutivos[31] = _lblEjecutivos_31;
			this.lblEjecutivos[30] = _lblEjecutivos_30;
	}
	void  InitializefraDatosAdicionales()
	{
			this.fraDatosAdicionales[3] = _fraDatosAdicionales_3;
	}
	void  InitializeID_MEE_ETT_TXT()
	{
			this.ID_MEE_ETT_TXT[7] = _ID_MEE_ETT_TXT_7;
			this.ID_MEE_ETT_TXT[9] = _ID_MEE_ETT_TXT_9;
	}
	void  InitializecmdEjecutivos()
	{
			this.cmdEjecutivos[0] = _cmdEjecutivos_0;
			this.cmdEjecutivos[1] = _cmdEjecutivos_1;
			this.cmdEjecutivos[2] = _cmdEjecutivos_2;
	}
	void  InitializefraEjecutivos()
	{
			this.fraEjecutivos[7] = _fraEjecutivos_7;
			this.fraEjecutivos[0] = _fraEjecutivos_0;
			this.fraEjecutivos[1] = _fraEjecutivos_1;
			this.fraEjecutivos[2] = _fraEjecutivos_2;
			this.fraEjecutivos[3] = _fraEjecutivos_3;
			this.fraEjecutivos[4] = _fraEjecutivos_4;
			this.fraEjecutivos[5] = _fraEjecutivos_5;
			this.fraEjecutivos[6] = _fraEjecutivos_6;
	}
	void  InitializecmbEjecutivos()
	{
			this.cmbEjecutivos[0] = _cmbEjecutivos_0;
			this.cmbEjecutivos[1] = _cmbEjecutivos_1;
			this.cmbEjecutivos[2] = _cmbEjecutivos_2;
	}
	void  InitializechkEjecutivos()
	{
			this.chkEjecutivos[1] = _chkEjecutivos_1;
			this.chkEjecutivos[0] = _chkEjecutivos_0;
			this.chkEjecutivos[3] = _chkEjecutivos_3;
			this.chkEjecutivos[2] = _chkEjecutivos_2;
	}
	void  InitializemskEjecutivos()
	{
			this.mskEjecutivos[0] = _mskEjecutivos_0;
			this.mskEjecutivos[1] = _mskEjecutivos_1;
			this.mskEjecutivos[2] = _mskEjecutivos_2;
			this.mskEjecutivos[3] = _mskEjecutivos_3;
			this.mskEjecutivos[4] = _mskEjecutivos_4;
			this.mskEjecutivos[5] = _mskEjecutivos_5;
			this.mskEjecutivos[6] = _mskEjecutivos_6;
			this.mskEjecutivos[7] = _mskEjecutivos_7;
			this.mskEjecutivos[8] = _mskEjecutivos_8;
			this.mskEjecutivos[9] = _mskEjecutivos_9;
			this.mskEjecutivos[10] = _mskEjecutivos_10;
			this.mskEjecutivos[11] = _mskEjecutivos_11;
			this.mskEjecutivos[12] = _mskEjecutivos_12;
	}
	void  InitializepnlEjecutivos()
	{
			this.pnlEjecutivos[0] = _pnlEjecutivos_0;
			this.pnlEjecutivos[1] = _pnlEjecutivos_1;
	}
	void  InitializetxtEjecutivos()
	{
			this.txtEjecutivos[1] = _txtEjecutivos_1;
			this.txtEjecutivos[0] = _txtEjecutivos_0;
			this.txtEjecutivos[6] = _txtEjecutivos_6;
			this.txtEjecutivos[5] = _txtEjecutivos_5;
			this.txtEjecutivos[4] = _txtEjecutivos_4;
			this.txtEjecutivos[3] = _txtEjecutivos_3;
			this.txtEjecutivos[2] = _txtEjecutivos_2;
			this.txtEjecutivos[9] = _txtEjecutivos_9;
			this.txtEjecutivos[8] = _txtEjecutivos_8;
			this.txtEjecutivos[7] = _txtEjecutivos_7;
			this.txtEjecutivos[13] = _txtEjecutivos_13;
			this.txtEjecutivos[12] = _txtEjecutivos_12;
			this.txtEjecutivos[11] = _txtEjecutivos_11;
			this.txtEjecutivos[10] = _txtEjecutivos_10;
	}
#endregion 

        private Artinsoft.VB6.Gui.SSTabHelper ssTabHelper1;
}
}