using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class frmEmpresa
	{
	
#region "Upgrade Support "
		private static frmEmpresa m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmEmpresa DefInstance
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
		public frmEmpresa():base(){
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			InitializeHelp();
			InitializecmdEmpresa();
			InitializechkEmpresa();
			InitializeoptEmpresa();
			InitializelblEmpresa();
			InitializepnlEmpresa();
			InitializefraEmpresa();
			InitializemskEmpresa();
			InitializecmbEmpresa();
			InitializetxtEmpresa();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static frmEmpresa CreateInstance()
	{
			frmEmpresa theInstance = new frmEmpresa();
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
	private  System.Windows.Forms.Button _cmdEmpresa_2;
	private  System.Windows.Forms.Button _cmdEmpresa_1;
	private  System.Windows.Forms.Button _cmdEmpresa_0;
	private  System.Windows.Forms.Label _pnlEmpresa_0Label_Text;
	private  AxThreed.AxSSPanel _pnlEmpresa_0;
	private  AxThreed.AxSSPanel _pnlEmpresa_1;
	private  AxThreed.AxSSPanel _pnlEmpresa_2;
	private  System.Windows.Forms.Label _pnlEmpresa_3Label_Text;
	private  AxThreed.AxSSPanel _pnlEmpresa_3;
	private  AxThreed.AxSSPanel _pnlEmpresa_4;
	private  System.Windows.Forms.Label _pnlEmpresa_5Label_Text;
	private  AxThreed.AxSSPanel _pnlEmpresa_5;
	private  AxThreed.AxSSPanel _pnlEmpresa_6;
	private  AxThreed.AxSSFrame _fraEmpresa_0;
	private  System.Windows.Forms.ComboBox _cmbEmpresa_0;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_0;
	private  System.Windows.Forms.TextBox _txtEmpresa_3;
	private  System.Windows.Forms.TextBox _txtEmpresa_2;
	private  System.Windows.Forms.TextBox _txtEmpresa_1;
	private  System.Windows.Forms.TextBox _txtEmpresa_0;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_1;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_2;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_3;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_4;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_5;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_6;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_7;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_8;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_9;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_10;
	private  System.Windows.Forms.Label _lblEmpresa_15;
	private  System.Windows.Forms.Label _lblEmpresa_14;
	private  System.Windows.Forms.Label _lblEmpresa_13;
	private  System.Windows.Forms.Label _lblEmpresa_12;
	private  System.Windows.Forms.Label _lblEmpresa_11;
	private  System.Windows.Forms.Label _lblEmpresa_10;
	private  System.Windows.Forms.Label _lblEmpresa_9;
	private  System.Windows.Forms.Label _lblEmpresa_8;
	private  System.Windows.Forms.Label _lblEmpresa_7;
	private  System.Windows.Forms.Label _lblEmpresa_6;
	private  System.Windows.Forms.Label _lblEmpresa_5;
	private  System.Windows.Forms.Label _lblEmpresa_4;
	private  System.Windows.Forms.Label _lblEmpresa_3;
	private  System.Windows.Forms.Label _lblEmpresa_2;
	private  System.Windows.Forms.Label _lblEmpresa_1;
	private  System.Windows.Forms.Label _lblEmpresa_0;
	private  AxThreed.AxSSFrame _fraEmpresa_1;
	private  System.Windows.Forms.TabPage _tabEmpresa_TabPage0;
	private  System.Windows.Forms.ComboBox _cmbEmpresa_2;
	private  System.Windows.Forms.TextBox _txtEmpresa_11;
	private  System.Windows.Forms.TextBox _txtEmpresa_10;
	private  System.Windows.Forms.TextBox _txtEmpresa_9;
	private  System.Windows.Forms.TextBox _txtEmpresa_8;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_12;
	private  System.Windows.Forms.Label _lblEmpresa_21;
	private  System.Windows.Forms.Label _lblEmpresa_20;
	private  System.Windows.Forms.Label _lblEmpresa_19;
	private  System.Windows.Forms.Label _lblEmpresa_18;
	private  System.Windows.Forms.Label _lblEmpresa_17;
	private  System.Windows.Forms.Label _lblEmpresa_16;
	private  AxThreed.AxSSFrame _fraEmpresa_3;
	private  System.Windows.Forms.ComboBox _cmbEmpresa_1;
	private  System.Windows.Forms.TextBox _txtEmpresa_7;
	private  System.Windows.Forms.TextBox _txtEmpresa_6;
	private  System.Windows.Forms.TextBox _txtEmpresa_5;
	private  System.Windows.Forms.TextBox _txtEmpresa_4;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_11;
	private  System.Windows.Forms.Label _lblEmpresa_31;
	private  System.Windows.Forms.Label _lblEmpresa_30;
	private  System.Windows.Forms.Label _lblEmpresa_29;
	private  System.Windows.Forms.Label _lblEmpresa_28;
	private  System.Windows.Forms.Label _lblEmpresa_27;
	private  System.Windows.Forms.Label _lblEmpresa_26;
	private  AxThreed.AxSSFrame _fraEmpresa_2;
	private  System.Windows.Forms.TabPage _tabEmpresa_TabPage1;
	private  System.Windows.Forms.Button _cmdEmpresa_4;
	private  System.Windows.Forms.Button _cmdEmpresa_3;
	private  System.Windows.Forms.RadioButton _optEmpresa_2;
	private  System.Windows.Forms.RadioButton _optEmpresa_1;
	private  System.Windows.Forms.RadioButton _optEmpresa_0;
	private  System.Windows.Forms.TextBox _txtEmpresa_13;
	private  System.Windows.Forms.TextBox _txtEmpresa_12;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_13;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_14;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_15;
	private  System.Windows.Forms.Label _lblEmpresa_32;
	private  System.Windows.Forms.Label _lblEmpresa_25;
	private  System.Windows.Forms.Label _lblEmpresa_24;
	private  System.Windows.Forms.Label _lblEmpresa_23;
	private  System.Windows.Forms.Label _lblEmpresa_22;
	private  AxThreed.AxSSFrame _fraEmpresa_5;
	private  AxThreed.AxSSFrame _fraEmpresa_4;
	private  System.Windows.Forms.TabPage _tabEmpresa_TabPage2;
	private  System.Windows.Forms.Button _cmdEmpresa_5;
	private  System.Windows.Forms.ComboBox _cmbEmpresa_3;
	private  System.Windows.Forms.TextBox _txtEmpresa_21;
	private  System.Windows.Forms.Label _pnlEmpresa_7Label_Text;
	private  AxThreed.AxSSPanel _pnlEmpresa_7;
	private  System.Windows.Forms.Label _pnlEmpresa_8Label_Text;
	private  AxThreed.AxSSPanel _pnlEmpresa_8;
	private  System.Windows.Forms.Label _lblEmpresa_46;
	private  AxThreed.AxSSFrame _fraEmpresa_7;
	private  System.Windows.Forms.TextBox _txtEmpresa_20;
	private  System.Windows.Forms.TextBox _txtEmpresa_19;
	private  System.Windows.Forms.TextBox _txtEmpresa_18;
	private  System.Windows.Forms.TextBox _txtEmpresa_17;
	private  System.Windows.Forms.TextBox _txtEmpresa_16;
	private  System.Windows.Forms.TextBox _txtEmpresa_15;
	private  System.Windows.Forms.TextBox _txtEmpresa_14;
	private  System.Windows.Forms.Label _lblEmpresa_39;
	private  System.Windows.Forms.Label _lblEmpresa_38;
	private  System.Windows.Forms.Label _lblEmpresa_37;
	private  System.Windows.Forms.Label _lblEmpresa_36;
	private  System.Windows.Forms.Label _lblEmpresa_35;
	private  System.Windows.Forms.Label _lblEmpresa_34;
	private  System.Windows.Forms.Label _lblEmpresa_33;
	private  AxThreed.AxSSFrame _fraEmpresa_6;
	private  System.Windows.Forms.TabPage _tabEmpresa_TabPage3;
	private  System.Windows.Forms.Label _lblEmpresa_40;
	private  System.Windows.Forms.Label _lblEmpresa_41;
	private  System.Windows.Forms.Label _lblEmpresa_42;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_16;
	private  System.Windows.Forms.CheckBox _chkEmpresa_3;
	private  System.Windows.Forms.CheckBox _chkEmpresa_2;
	private  System.Windows.Forms.CheckBox _chkEmpresa_1;
	private  AxThreed.AxSSFrame _fraEmpresa_13;
	private  System.Windows.Forms.RadioButton _optEmpresa_11;
	private  System.Windows.Forms.RadioButton _optEmpresa_10;
	private  System.Windows.Forms.RadioButton _optEmpresa_12;
	private  AxThreed.AxSSFrame _fraEmpresa_12;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_17;
	private  AxMSMask.AxMaskEdBox _mskEmpresa_18;
	private  System.Windows.Forms.Label _lblEmpresa_44;
	private  System.Windows.Forms.Label _lblEmpresa_43;
	private  AxThreed.AxSSFrame _fraEmpresa_11;
	private  System.Windows.Forms.RadioButton _optEmpresa_9;
	private  System.Windows.Forms.RadioButton _optEmpresa_7;
	private  System.Windows.Forms.RadioButton _optEmpresa_8;
	private  AxThreed.AxSSFrame _fraEmpresa_10;
	private  System.Windows.Forms.RadioButton _optEmpresa_6;
	private  System.Windows.Forms.RadioButton _optEmpresa_5;
	private  AxThreed.AxSSFrame _fraEmpresa_9;
	private  System.Windows.Forms.RadioButton _optEmpresa_4;
	private  System.Windows.Forms.RadioButton _optEmpresa_3;
	private  AxThreed.AxSSFrame _fraEmpresa_8;
	private  System.Windows.Forms.CheckBox _chkEmpresa_0;
	private  System.Windows.Forms.ComboBox _cmbEmpresa_4;
	private  System.Windows.Forms.ComboBox _cmbEmpresa_5;
	private  System.Windows.Forms.TabPage _tabEmpresa_TabPage4;
	public  System.Windows.Forms.TabControl tabEmpresa;
	public System.Windows.Forms.CheckBox[] chkEmpresa = new System.Windows.Forms.CheckBox[4];
	public System.Windows.Forms.ComboBox[] cmbEmpresa = new System.Windows.Forms.ComboBox[6];
	public System.Windows.Forms.Button[] cmdEmpresa = new System.Windows.Forms.Button[6];
	public AxThreed.AxSSFrame[] fraEmpresa = new AxThreed.AxSSFrame[14];
	public System.Windows.Forms.Label[] lblEmpresa = new System.Windows.Forms.Label[47];
	public AxMSMask.AxMaskEdBox[] mskEmpresa = new AxMSMask.AxMaskEdBox[19];
	public System.Windows.Forms.RadioButton[] optEmpresa = new System.Windows.Forms.RadioButton[13];
	public AxThreed.AxSSPanel[] pnlEmpresa = new AxThreed.AxSSPanel[9];
	public System.Windows.Forms.TextBox[] txtEmpresa = new System.Windows.Forms.TextBox[22];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpresa));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._cmdEmpresa_2 = new System.Windows.Forms.Button();
            this._cmdEmpresa_1 = new System.Windows.Forms.Button();
            this._cmdEmpresa_0 = new System.Windows.Forms.Button();
            this.tabEmpresa = new System.Windows.Forms.TabControl();
            this._tabEmpresa_TabPage2 = new System.Windows.Forms.TabPage();
            this._fraEmpresa_4 = new AxThreed.AxSSFrame();
            this._optEmpresa_2 = new System.Windows.Forms.RadioButton();
            this._cmdEmpresa_3 = new System.Windows.Forms.Button();
            this._cmdEmpresa_4 = new System.Windows.Forms.Button();
            this._optEmpresa_1 = new System.Windows.Forms.RadioButton();
            this._fraEmpresa_5 = new AxThreed.AxSSFrame();
            this._mskEmpresa_15 = new AxMSMask.AxMaskEdBox();
            this._lblEmpresa_32 = new System.Windows.Forms.Label();
            this._mskEmpresa_13 = new AxMSMask.AxMaskEdBox();
            this._mskEmpresa_14 = new AxMSMask.AxMaskEdBox();
            this._lblEmpresa_23 = new System.Windows.Forms.Label();
            this._lblEmpresa_22 = new System.Windows.Forms.Label();
            this._lblEmpresa_25 = new System.Windows.Forms.Label();
            this._lblEmpresa_24 = new System.Windows.Forms.Label();
            this._txtEmpresa_13 = new System.Windows.Forms.TextBox();
            this._txtEmpresa_12 = new System.Windows.Forms.TextBox();
            this._optEmpresa_0 = new System.Windows.Forms.RadioButton();
            this._tabEmpresa_TabPage0 = new System.Windows.Forms.TabPage();
            this._fraEmpresa_0 = new AxThreed.AxSSFrame();
            this._pnlEmpresa_3 = new AxThreed.AxSSPanel();
            this._pnlEmpresa_3Label_Text = new System.Windows.Forms.Label();
            this._pnlEmpresa_2 = new AxThreed.AxSSPanel();
            this._pnlEmpresa_1 = new AxThreed.AxSSPanel();
            this._pnlEmpresa_6 = new AxThreed.AxSSPanel();
            this._pnlEmpresa_5 = new AxThreed.AxSSPanel();
            this._pnlEmpresa_5Label_Text = new System.Windows.Forms.Label();
            this._pnlEmpresa_4 = new AxThreed.AxSSPanel();
            this._pnlEmpresa_0 = new AxThreed.AxSSPanel();
            this._pnlEmpresa_0Label_Text = new System.Windows.Forms.Label();
            this._fraEmpresa_1 = new AxThreed.AxSSFrame();
            this._lblEmpresa_12 = new System.Windows.Forms.Label();
            this._lblEmpresa_13 = new System.Windows.Forms.Label();
            this._lblEmpresa_10 = new System.Windows.Forms.Label();
            this._lblEmpresa_11 = new System.Windows.Forms.Label();
            this._lblEmpresa_14 = new System.Windows.Forms.Label();
            this._mskEmpresa_9 = new AxMSMask.AxMaskEdBox();
            this._mskEmpresa_8 = new AxMSMask.AxMaskEdBox();
            this._lblEmpresa_15 = new System.Windows.Forms.Label();
            this._mskEmpresa_10 = new AxMSMask.AxMaskEdBox();
            this._lblEmpresa_9 = new System.Windows.Forms.Label();
            this._lblEmpresa_2 = new System.Windows.Forms.Label();
            this._lblEmpresa_3 = new System.Windows.Forms.Label();
            this._lblEmpresa_0 = new System.Windows.Forms.Label();
            this._lblEmpresa_1 = new System.Windows.Forms.Label();
            this._lblEmpresa_4 = new System.Windows.Forms.Label();
            this._lblEmpresa_7 = new System.Windows.Forms.Label();
            this._lblEmpresa_8 = new System.Windows.Forms.Label();
            this._lblEmpresa_5 = new System.Windows.Forms.Label();
            this._lblEmpresa_6 = new System.Windows.Forms.Label();
            this._txtEmpresa_2 = new System.Windows.Forms.TextBox();
            this._txtEmpresa_1 = new System.Windows.Forms.TextBox();
            this._txtEmpresa_0 = new System.Windows.Forms.TextBox();
            this._cmbEmpresa_0 = new System.Windows.Forms.ComboBox();
            this._mskEmpresa_0 = new AxMSMask.AxMaskEdBox();
            this._txtEmpresa_3 = new System.Windows.Forms.TextBox();
            this._mskEmpresa_1 = new AxMSMask.AxMaskEdBox();
            this._mskEmpresa_5 = new AxMSMask.AxMaskEdBox();
            this._mskEmpresa_6 = new AxMSMask.AxMaskEdBox();
            this._mskEmpresa_7 = new AxMSMask.AxMaskEdBox();
            this._mskEmpresa_2 = new AxMSMask.AxMaskEdBox();
            this._mskEmpresa_3 = new AxMSMask.AxMaskEdBox();
            this._mskEmpresa_4 = new AxMSMask.AxMaskEdBox();
            this._tabEmpresa_TabPage1 = new System.Windows.Forms.TabPage();
            this._fraEmpresa_3 = new AxThreed.AxSSFrame();
            this._mskEmpresa_12 = new AxMSMask.AxMaskEdBox();
            this._lblEmpresa_21 = new System.Windows.Forms.Label();
            this._txtEmpresa_9 = new System.Windows.Forms.TextBox();
            this._txtEmpresa_8 = new System.Windows.Forms.TextBox();
            this._lblEmpresa_20 = new System.Windows.Forms.Label();
            this._lblEmpresa_17 = new System.Windows.Forms.Label();
            this._lblEmpresa_16 = new System.Windows.Forms.Label();
            this._lblEmpresa_19 = new System.Windows.Forms.Label();
            this._lblEmpresa_18 = new System.Windows.Forms.Label();
            this._cmbEmpresa_2 = new System.Windows.Forms.ComboBox();
            this._txtEmpresa_11 = new System.Windows.Forms.TextBox();
            this._txtEmpresa_10 = new System.Windows.Forms.TextBox();
            this._fraEmpresa_2 = new AxThreed.AxSSFrame();
            this._mskEmpresa_11 = new AxMSMask.AxMaskEdBox();
            this._lblEmpresa_31 = new System.Windows.Forms.Label();
            this._txtEmpresa_5 = new System.Windows.Forms.TextBox();
            this._txtEmpresa_4 = new System.Windows.Forms.TextBox();
            this._lblEmpresa_30 = new System.Windows.Forms.Label();
            this._lblEmpresa_27 = new System.Windows.Forms.Label();
            this._lblEmpresa_26 = new System.Windows.Forms.Label();
            this._lblEmpresa_29 = new System.Windows.Forms.Label();
            this._lblEmpresa_28 = new System.Windows.Forms.Label();
            this._cmbEmpresa_1 = new System.Windows.Forms.ComboBox();
            this._txtEmpresa_7 = new System.Windows.Forms.TextBox();
            this._txtEmpresa_6 = new System.Windows.Forms.TextBox();
            this._tabEmpresa_TabPage4 = new System.Windows.Forms.TabPage();
            this._fraEmpresa_9 = new AxThreed.AxSSFrame();
            this._optEmpresa_6 = new System.Windows.Forms.RadioButton();
            this._optEmpresa_5 = new System.Windows.Forms.RadioButton();
            this._fraEmpresa_10 = new AxThreed.AxSSFrame();
            this._optEmpresa_9 = new System.Windows.Forms.RadioButton();
            this._optEmpresa_7 = new System.Windows.Forms.RadioButton();
            this._optEmpresa_8 = new System.Windows.Forms.RadioButton();
            this._fraEmpresa_11 = new AxThreed.AxSSFrame();
            this._mskEmpresa_18 = new AxMSMask.AxMaskEdBox();
            this._mskEmpresa_17 = new AxMSMask.AxMaskEdBox();
            this._lblEmpresa_43 = new System.Windows.Forms.Label();
            this._lblEmpresa_44 = new System.Windows.Forms.Label();
            this._fraEmpresa_8 = new AxThreed.AxSSFrame();
            this._optEmpresa_4 = new System.Windows.Forms.RadioButton();
            this._optEmpresa_3 = new System.Windows.Forms.RadioButton();
            this._cmbEmpresa_5 = new System.Windows.Forms.ComboBox();
            this._cmbEmpresa_4 = new System.Windows.Forms.ComboBox();
            this._chkEmpresa_0 = new System.Windows.Forms.CheckBox();
            this._fraEmpresa_12 = new AxThreed.AxSSFrame();
            this._optEmpresa_11 = new System.Windows.Forms.RadioButton();
            this._optEmpresa_10 = new System.Windows.Forms.RadioButton();
            this._optEmpresa_12 = new System.Windows.Forms.RadioButton();
            this._lblEmpresa_41 = new System.Windows.Forms.Label();
            this._lblEmpresa_40 = new System.Windows.Forms.Label();
            this._lblEmpresa_42 = new System.Windows.Forms.Label();
            this._fraEmpresa_13 = new AxThreed.AxSSFrame();
            this._chkEmpresa_3 = new System.Windows.Forms.CheckBox();
            this._chkEmpresa_2 = new System.Windows.Forms.CheckBox();
            this._chkEmpresa_1 = new System.Windows.Forms.CheckBox();
            this._mskEmpresa_16 = new AxMSMask.AxMaskEdBox();
            this._tabEmpresa_TabPage3 = new System.Windows.Forms.TabPage();
            this._fraEmpresa_7 = new AxThreed.AxSSFrame();
            this._txtEmpresa_21 = new System.Windows.Forms.TextBox();
            this._cmbEmpresa_3 = new System.Windows.Forms.ComboBox();
            this._cmdEmpresa_5 = new System.Windows.Forms.Button();
            this._pnlEmpresa_7 = new AxThreed.AxSSPanel();
            this._pnlEmpresa_7Label_Text = new System.Windows.Forms.Label();
            this._lblEmpresa_46 = new System.Windows.Forms.Label();
            this._pnlEmpresa_8 = new AxThreed.AxSSPanel();
            this._pnlEmpresa_8Label_Text = new System.Windows.Forms.Label();
            this._fraEmpresa_6 = new AxThreed.AxSSFrame();
            this._lblEmpresa_39 = new System.Windows.Forms.Label();
            this._lblEmpresa_38 = new System.Windows.Forms.Label();
            this._txtEmpresa_14 = new System.Windows.Forms.TextBox();
            this._txtEmpresa_16 = new System.Windows.Forms.TextBox();
            this._txtEmpresa_15 = new System.Windows.Forms.TextBox();
            this._lblEmpresa_34 = new System.Windows.Forms.Label();
            this._lblEmpresa_33 = new System.Windows.Forms.Label();
            this._lblEmpresa_35 = new System.Windows.Forms.Label();
            this._lblEmpresa_37 = new System.Windows.Forms.Label();
            this._lblEmpresa_36 = new System.Windows.Forms.Label();
            this._txtEmpresa_19 = new System.Windows.Forms.TextBox();
            this._txtEmpresa_20 = new System.Windows.Forms.TextBox();
            this._txtEmpresa_17 = new System.Windows.Forms.TextBox();
            this._txtEmpresa_18 = new System.Windows.Forms.TextBox();
            this.tabEmpresa.SuspendLayout();
            this._tabEmpresa_TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_4)).BeginInit();
            this._fraEmpresa_4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_5)).BeginInit();
            this._fraEmpresa_5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_14)).BeginInit();
            this._tabEmpresa_TabPage0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_0)).BeginInit();
            this._fraEmpresa_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_3)).BeginInit();
            this._pnlEmpresa_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_5)).BeginInit();
            this._pnlEmpresa_5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_0)).BeginInit();
            this._pnlEmpresa_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_1)).BeginInit();
            this._fraEmpresa_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_4)).BeginInit();
            this._tabEmpresa_TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_3)).BeginInit();
            this._fraEmpresa_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_2)).BeginInit();
            this._fraEmpresa_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_11)).BeginInit();
            this._tabEmpresa_TabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_9)).BeginInit();
            this._fraEmpresa_9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_10)).BeginInit();
            this._fraEmpresa_10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_11)).BeginInit();
            this._fraEmpresa_11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_8)).BeginInit();
            this._fraEmpresa_8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_12)).BeginInit();
            this._fraEmpresa_12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_13)).BeginInit();
            this._fraEmpresa_13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_16)).BeginInit();
            this._tabEmpresa_TabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_7)).BeginInit();
            this._fraEmpresa_7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_7)).BeginInit();
            this._pnlEmpresa_7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_8)).BeginInit();
            this._pnlEmpresa_8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_6)).BeginInit();
            this._fraEmpresa_6.SuspendLayout();
            this.SuspendLayout();
            // 
            // _cmdEmpresa_2
            // 
            this._cmdEmpresa_2.BackColor = System.Drawing.SystemColors.Control;
            this._cmdEmpresa_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmdEmpresa_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._cmdEmpresa_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmdEmpresa_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cmdEmpresa_2.Location = new System.Drawing.Point(392, 400);
            this._cmdEmpresa_2.Name = "_cmdEmpresa_2";
            this._cmdEmpresa_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmdEmpresa_2.Size = new System.Drawing.Size(89, 21);
            this._cmdEmpresa_2.TabIndex = 69;
            this._cmdEmpresa_2.Tag = "";
            this._cmdEmpresa_2.Text = "Imprimir";
            this._cmdEmpresa_2.UseVisualStyleBackColor = false;
            this._cmdEmpresa_2.Click += new System.EventHandler(this.cmdEmpresa_Click);
            // 
            // _cmdEmpresa_1
            // 
            this._cmdEmpresa_1.BackColor = System.Drawing.SystemColors.Control;
            this._cmdEmpresa_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmdEmpresa_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._cmdEmpresa_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmdEmpresa_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cmdEmpresa_1.Location = new System.Drawing.Point(280, 400);
            this._cmdEmpresa_1.Name = "_cmdEmpresa_1";
            this._cmdEmpresa_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmdEmpresa_1.Size = new System.Drawing.Size(89, 21);
            this._cmdEmpresa_1.TabIndex = 68;
            this._cmdEmpresa_1.Tag = "";
            this._cmdEmpresa_1.Text = "Cancelar";
            this._cmdEmpresa_1.UseVisualStyleBackColor = false;
            this._cmdEmpresa_1.Click += new System.EventHandler(this.cmdEmpresa_Click);
            // 
            // _cmdEmpresa_0
            // 
            this._cmdEmpresa_0.BackColor = System.Drawing.SystemColors.Control;
            this._cmdEmpresa_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmdEmpresa_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._cmdEmpresa_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmdEmpresa_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cmdEmpresa_0.Location = new System.Drawing.Point(168, 400);
            this._cmdEmpresa_0.Name = "_cmdEmpresa_0";
            this._cmdEmpresa_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmdEmpresa_0.Size = new System.Drawing.Size(89, 21);
            this._cmdEmpresa_0.TabIndex = 67;
            this._cmdEmpresa_0.Tag = "";
            this._cmdEmpresa_0.Text = "Aceptar";
            this._cmdEmpresa_0.UseVisualStyleBackColor = false;
            this._cmdEmpresa_0.Click += new System.EventHandler(this.cmdEmpresa_Click);
            // 
            // tabEmpresa
            // 
            this.tabEmpresa.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabEmpresa.Controls.Add(this._tabEmpresa_TabPage2);
            this.tabEmpresa.Controls.Add(this._tabEmpresa_TabPage0);
            this.tabEmpresa.Controls.Add(this._tabEmpresa_TabPage1);
            this.tabEmpresa.Controls.Add(this._tabEmpresa_TabPage4);
            this.tabEmpresa.Controls.Add(this._tabEmpresa_TabPage3);
            this.tabEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabEmpresa.ItemSize = new System.Drawing.Size(126, 18);
            this.tabEmpresa.Location = new System.Drawing.Point(0, 0);
            this.tabEmpresa.Multiline = true;
            this.tabEmpresa.Name = "tabEmpresa";
            this.tabEmpresa.SelectedIndex = 4;
            this.tabEmpresa.Size = new System.Drawing.Size(639, 389);
            this.tabEmpresa.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabEmpresa.TabIndex = 70;
            this.tabEmpresa.Tag = "";
            // 
            // _tabEmpresa_TabPage2
            // 
            this._tabEmpresa_TabPage2.Controls.Add(this._fraEmpresa_4);
            this._tabEmpresa_TabPage2.Location = new System.Drawing.Point(4, 43);
            this._tabEmpresa_TabPage2.Name = "_tabEmpresa_TabPage2";
            this._tabEmpresa_TabPage2.Size = new System.Drawing.Size(631, 342);
            this._tabEmpresa_TabPage2.TabIndex = 0;
            this._tabEmpresa_TabPage2.Tag = "";
            this._tabEmpresa_TabPage2.Text = "Representantes";
            // 
            // _fraEmpresa_4
            // 
            this._fraEmpresa_4.Controls.Add(this._optEmpresa_2);
            this._fraEmpresa_4.Controls.Add(this._cmdEmpresa_3);
            this._fraEmpresa_4.Controls.Add(this._cmdEmpresa_4);
            this._fraEmpresa_4.Controls.Add(this._optEmpresa_1);
            this._fraEmpresa_4.Controls.Add(this._fraEmpresa_5);
            this._fraEmpresa_4.Controls.Add(this._optEmpresa_0);
            this._fraEmpresa_4.Location = new System.Drawing.Point(8, 60);
            this._fraEmpresa_4.Name = "_fraEmpresa_4";
            this._fraEmpresa_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_fraEmpresa_4.OcxState")));
            this._fraEmpresa_4.Size = new System.Drawing.Size(617, 225);
            this._fraEmpresa_4.TabIndex = 110;
            this._fraEmpresa_4.Tag = "";
            this._fraEmpresa_4.Enter += new System.EventHandler(this._fraEmpresa_4_Enter);
            // 
            // _optEmpresa_2
            // 
            this._optEmpresa_2.BackColor = System.Drawing.SystemColors.Control;
            this._optEmpresa_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._optEmpresa_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEmpresa_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optEmpresa_2.Location = new System.Drawing.Point(440, 28);
            this._optEmpresa_2.Name = "_optEmpresa_2";
            this._optEmpresa_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optEmpresa_2.Size = new System.Drawing.Size(124, 17);
            this._optEmpresa_2.TabIndex = 30;
            this._optEmpresa_2.TabStop = true;
            this._optEmpresa_2.Tag = "";
            this._optEmpresa_2.Text = "Representante 3";
            this._optEmpresa_2.UseVisualStyleBackColor = false;
            this._optEmpresa_2.CheckedChanged += new System.EventHandler(this.optEmpresa_CheckedChanged);
            // 
            // _cmdEmpresa_3
            // 
            this._cmdEmpresa_3.BackColor = System.Drawing.SystemColors.Control;
            this._cmdEmpresa_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmdEmpresa_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._cmdEmpresa_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmdEmpresa_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cmdEmpresa_3.Location = new System.Drawing.Point(152, 184);
            this._cmdEmpresa_3.Name = "_cmdEmpresa_3";
            this._cmdEmpresa_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmdEmpresa_3.Size = new System.Drawing.Size(145, 25);
            this._cmdEmpresa_3.TabIndex = 36;
            this._cmdEmpresa_3.Tag = "";
            this._cmdEmpresa_3.Text = "Borrar Representante";
            this._cmdEmpresa_3.UseVisualStyleBackColor = false;
            this._cmdEmpresa_3.Click += new System.EventHandler(this.cmdEmpresa_Click);
            // 
            // _cmdEmpresa_4
            // 
            this._cmdEmpresa_4.BackColor = System.Drawing.SystemColors.Control;
            this._cmdEmpresa_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmdEmpresa_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._cmdEmpresa_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmdEmpresa_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cmdEmpresa_4.Location = new System.Drawing.Point(352, 184);
            this._cmdEmpresa_4.Name = "_cmdEmpresa_4";
            this._cmdEmpresa_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmdEmpresa_4.Size = new System.Drawing.Size(105, 25);
            this._cmdEmpresa_4.TabIndex = 37;
            this._cmdEmpresa_4.Tag = "";
            this._cmdEmpresa_4.Text = "Capturar Firmas";
            this._cmdEmpresa_4.UseVisualStyleBackColor = false;
            this._cmdEmpresa_4.Click += new System.EventHandler(this.cmdEmpresa_Click);
            // 
            // _optEmpresa_1
            // 
            this._optEmpresa_1.BackColor = System.Drawing.SystemColors.Control;
            this._optEmpresa_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._optEmpresa_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEmpresa_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optEmpresa_1.Location = new System.Drawing.Point(240, 28);
            this._optEmpresa_1.Name = "_optEmpresa_1";
            this._optEmpresa_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optEmpresa_1.Size = new System.Drawing.Size(117, 17);
            this._optEmpresa_1.TabIndex = 29;
            this._optEmpresa_1.TabStop = true;
            this._optEmpresa_1.Tag = "";
            this._optEmpresa_1.Text = "Representante 2";
            this._optEmpresa_1.UseVisualStyleBackColor = false;
            this._optEmpresa_1.CheckedChanged += new System.EventHandler(this.optEmpresa_CheckedChanged);
            // 
            // _fraEmpresa_5
            // 
            this._fraEmpresa_5.Controls.Add(this._mskEmpresa_15);
            this._fraEmpresa_5.Controls.Add(this._lblEmpresa_32);
            this._fraEmpresa_5.Controls.Add(this._mskEmpresa_13);
            this._fraEmpresa_5.Controls.Add(this._mskEmpresa_14);
            this._fraEmpresa_5.Controls.Add(this._lblEmpresa_23);
            this._fraEmpresa_5.Controls.Add(this._lblEmpresa_22);
            this._fraEmpresa_5.Controls.Add(this._lblEmpresa_25);
            this._fraEmpresa_5.Controls.Add(this._lblEmpresa_24);
            this._fraEmpresa_5.Controls.Add(this._txtEmpresa_13);
            this._fraEmpresa_5.Controls.Add(this._txtEmpresa_12);
            this._fraEmpresa_5.Location = new System.Drawing.Point(24, 56);
            this._fraEmpresa_5.Name = "_fraEmpresa_5";
            this._fraEmpresa_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_fraEmpresa_5.OcxState")));
            this._fraEmpresa_5.Size = new System.Drawing.Size(577, 113);
            this._fraEmpresa_5.TabIndex = 111;
            this._fraEmpresa_5.Tag = "";
            // 
            // _mskEmpresa_15
            // 
            this._mskEmpresa_15.Location = new System.Drawing.Point(453, 69);
            this._mskEmpresa_15.Name = "_mskEmpresa_15";
            this._mskEmpresa_15.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_15.OcxState")));
            this._mskEmpresa_15.Size = new System.Drawing.Size(97, 19);
            this._mskEmpresa_15.TabIndex = 35;
            this._mskEmpresa_15.Tag = "";
            this._mskEmpresa_15.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_15.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_15.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_15.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _lblEmpresa_32
            // 
            this._lblEmpresa_32.AutoSize = true;
            this._lblEmpresa_32.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_32.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_32.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_32.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_32.Location = new System.Drawing.Point(416, 72);
            this._lblEmpresa_32.Name = "_lblEmpresa_32";
            this._lblEmpresa_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_32.Size = new System.Drawing.Size(27, 13);
            this._lblEmpresa_32.TabIndex = 116;
            this._lblEmpresa_32.Tag = "";
            this._lblEmpresa_32.Text = "Fax";
            // 
            // _mskEmpresa_13
            // 
            this._mskEmpresa_13.Location = new System.Drawing.Point(96, 69);
            this._mskEmpresa_13.Name = "_mskEmpresa_13";
            this._mskEmpresa_13.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_13.OcxState")));
            this._mskEmpresa_13.Size = new System.Drawing.Size(129, 19);
            this._mskEmpresa_13.TabIndex = 33;
            this._mskEmpresa_13.Tag = "";
            this._mskEmpresa_13.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_13.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_13.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_13.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _mskEmpresa_14
            // 
            this._mskEmpresa_14.Location = new System.Drawing.Point(288, 69);
            this._mskEmpresa_14.Name = "_mskEmpresa_14";
            this._mskEmpresa_14.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_14.OcxState")));
            this._mskEmpresa_14.Size = new System.Drawing.Size(89, 19);
            this._mskEmpresa_14.TabIndex = 34;
            this._mskEmpresa_14.Tag = "";
            this._mskEmpresa_14.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_14.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_14.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_14.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _lblEmpresa_23
            // 
            this._lblEmpresa_23.AutoSize = true;
            this._lblEmpresa_23.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_23.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_23.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_23.Location = new System.Drawing.Point(32, 48);
            this._lblEmpresa_23.Name = "_lblEmpresa_23";
            this._lblEmpresa_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_23.Size = new System.Drawing.Size(46, 13);
            this._lblEmpresa_23.TabIndex = 113;
            this._lblEmpresa_23.Tag = "";
            this._lblEmpresa_23.Text = "Puesto";
            // 
            // _lblEmpresa_22
            // 
            this._lblEmpresa_22.AutoSize = true;
            this._lblEmpresa_22.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_22.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_22.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_22.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_22.Location = new System.Drawing.Point(32, 24);
            this._lblEmpresa_22.Name = "_lblEmpresa_22";
            this._lblEmpresa_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_22.Size = new System.Drawing.Size(50, 13);
            this._lblEmpresa_22.TabIndex = 112;
            this._lblEmpresa_22.Tag = "";
            this._lblEmpresa_22.Text = "Nombre";
            // 
            // _lblEmpresa_25
            // 
            this._lblEmpresa_25.AutoSize = true;
            this._lblEmpresa_25.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_25.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_25.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_25.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_25.Location = new System.Drawing.Point(256, 72);
            this._lblEmpresa_25.Name = "_lblEmpresa_25";
            this._lblEmpresa_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_25.Size = new System.Drawing.Size(29, 13);
            this._lblEmpresa_25.TabIndex = 115;
            this._lblEmpresa_25.Tag = "";
            this._lblEmpresa_25.Text = "Ext.";
            // 
            // _lblEmpresa_24
            // 
            this._lblEmpresa_24.AutoSize = true;
            this._lblEmpresa_24.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_24.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_24.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_24.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_24.Location = new System.Drawing.Point(32, 72);
            this._lblEmpresa_24.Name = "_lblEmpresa_24";
            this._lblEmpresa_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_24.Size = new System.Drawing.Size(57, 13);
            this._lblEmpresa_24.TabIndex = 114;
            this._lblEmpresa_24.Tag = "";
            this._lblEmpresa_24.Text = "Teléfono";
            // 
            // _txtEmpresa_13
            // 
            this._txtEmpresa_13.AcceptsReturn = true;
            this._txtEmpresa_13.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_13.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_13.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_13.Location = new System.Drawing.Point(96, 45);
            this._txtEmpresa_13.MaxLength = 15;
            this._txtEmpresa_13.Name = "_txtEmpresa_13";
            this._txtEmpresa_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_13.Size = new System.Drawing.Size(230, 20);
            this._txtEmpresa_13.TabIndex = 32;
            this._txtEmpresa_13.Tag = "";
            this._txtEmpresa_13.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_13.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_13.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_13.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_13.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _txtEmpresa_12
            // 
            this._txtEmpresa_12.AcceptsReturn = true;
            this._txtEmpresa_12.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_12.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_12.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_12.Location = new System.Drawing.Point(96, 21);
            this._txtEmpresa_12.MaxLength = 35;
            this._txtEmpresa_12.Name = "_txtEmpresa_12";
            this._txtEmpresa_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_12.Size = new System.Drawing.Size(454, 20);
            this._txtEmpresa_12.TabIndex = 31;
            this._txtEmpresa_12.Tag = "";
            this._txtEmpresa_12.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_12.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_12.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_12.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_12.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _optEmpresa_0
            // 
            this._optEmpresa_0.BackColor = System.Drawing.SystemColors.Control;
            this._optEmpresa_0.Checked = true;
            this._optEmpresa_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._optEmpresa_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEmpresa_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optEmpresa_0.Location = new System.Drawing.Point(48, 28);
            this._optEmpresa_0.Name = "_optEmpresa_0";
            this._optEmpresa_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optEmpresa_0.Size = new System.Drawing.Size(121, 17);
            this._optEmpresa_0.TabIndex = 28;
            this._optEmpresa_0.TabStop = true;
            this._optEmpresa_0.Tag = "";
            this._optEmpresa_0.Text = "Representante 1";
            this._optEmpresa_0.UseVisualStyleBackColor = false;
            this._optEmpresa_0.CheckedChanged += new System.EventHandler(this.optEmpresa_CheckedChanged);
            // 
            // _tabEmpresa_TabPage0
            // 
            this._tabEmpresa_TabPage0.Controls.Add(this._fraEmpresa_0);
            this._tabEmpresa_TabPage0.Controls.Add(this._fraEmpresa_1);
            this._tabEmpresa_TabPage0.Location = new System.Drawing.Point(4, 43);
            this._tabEmpresa_TabPage0.Name = "_tabEmpresa_TabPage0";
            this._tabEmpresa_TabPage0.Size = new System.Drawing.Size(631, 342);
            this._tabEmpresa_TabPage0.TabIndex = 1;
            this._tabEmpresa_TabPage0.Tag = "";
            this._tabEmpresa_TabPage0.Text = "Datos Generales";
            // 
            // _fraEmpresa_0
            // 
            this._fraEmpresa_0.Controls.Add(this._pnlEmpresa_3);
            this._fraEmpresa_0.Controls.Add(this._pnlEmpresa_2);
            this._fraEmpresa_0.Controls.Add(this._pnlEmpresa_1);
            this._fraEmpresa_0.Controls.Add(this._pnlEmpresa_6);
            this._fraEmpresa_0.Controls.Add(this._pnlEmpresa_5);
            this._fraEmpresa_0.Controls.Add(this._pnlEmpresa_4);
            this._fraEmpresa_0.Controls.Add(this._pnlEmpresa_0);
            this._fraEmpresa_0.Location = new System.Drawing.Point(8, 4);
            this._fraEmpresa_0.Name = "_fraEmpresa_0";
            this._fraEmpresa_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_fraEmpresa_0.OcxState")));
            this._fraEmpresa_0.Size = new System.Drawing.Size(617, 73);
            this._fraEmpresa_0.TabIndex = 71;
            this._fraEmpresa_0.Tag = "";
            // 
            // _pnlEmpresa_3
            // 
            this._pnlEmpresa_3.Controls.Add(this._pnlEmpresa_3Label_Text);
            this._pnlEmpresa_3.Location = new System.Drawing.Point(8, 40);
            this._pnlEmpresa_3.Name = "_pnlEmpresa_3";
            this._pnlEmpresa_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlEmpresa_3.OcxState")));
            this._pnlEmpresa_3.Size = new System.Drawing.Size(67, 27);
            this._pnlEmpresa_3.TabIndex = 76;
            this._pnlEmpresa_3.Tag = "";
            // 
            // _pnlEmpresa_3Label_Text
            // 
            this._pnlEmpresa_3Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._pnlEmpresa_3Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._pnlEmpresa_3Label_Text.Location = new System.Drawing.Point(0, 0);
            this._pnlEmpresa_3Label_Text.Name = "_pnlEmpresa_3Label_Text";
            this._pnlEmpresa_3Label_Text.Size = new System.Drawing.Size(65, 25);
            this._pnlEmpresa_3Label_Text.TabIndex = 0;
            this._pnlEmpresa_3Label_Text.Tag = "";
            this._pnlEmpresa_3Label_Text.Text = "  Empresa";
            this._pnlEmpresa_3Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _pnlEmpresa_2
            // 
            this._pnlEmpresa_2.Location = new System.Drawing.Point(424, 12);
            this._pnlEmpresa_2.Name = "_pnlEmpresa_2";
            this._pnlEmpresa_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlEmpresa_2.OcxState")));
            this._pnlEmpresa_2.Size = new System.Drawing.Size(185, 25);
            this._pnlEmpresa_2.TabIndex = 75;
            this._pnlEmpresa_2.Tag = "";
            // 
            // _pnlEmpresa_1
            // 
            this._pnlEmpresa_1.Location = new System.Drawing.Point(80, 12);
            this._pnlEmpresa_1.Name = "_pnlEmpresa_1";
            this._pnlEmpresa_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlEmpresa_1.OcxState")));
            this._pnlEmpresa_1.Size = new System.Drawing.Size(337, 25);
            this._pnlEmpresa_1.TabIndex = 74;
            this._pnlEmpresa_1.Tag = "";
            // 
            // _pnlEmpresa_6
            // 
            this._pnlEmpresa_6.Location = new System.Drawing.Point(496, 40);
            this._pnlEmpresa_6.Name = "_pnlEmpresa_6";
            this._pnlEmpresa_6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlEmpresa_6.OcxState")));
            this._pnlEmpresa_6.Size = new System.Drawing.Size(113, 25);
            this._pnlEmpresa_6.TabIndex = 79;
            this._pnlEmpresa_6.Tag = "";
            // 
            // _pnlEmpresa_5
            // 
            this._pnlEmpresa_5.Controls.Add(this._pnlEmpresa_5Label_Text);
            this._pnlEmpresa_5.Location = new System.Drawing.Point(424, 40);
            this._pnlEmpresa_5.Name = "_pnlEmpresa_5";
            this._pnlEmpresa_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlEmpresa_5.OcxState")));
            this._pnlEmpresa_5.Size = new System.Drawing.Size(67, 27);
            this._pnlEmpresa_5.TabIndex = 78;
            this._pnlEmpresa_5.Tag = "";
            // 
            // _pnlEmpresa_5Label_Text
            // 
            this._pnlEmpresa_5Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._pnlEmpresa_5Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._pnlEmpresa_5Label_Text.Location = new System.Drawing.Point(0, 0);
            this._pnlEmpresa_5Label_Text.Name = "_pnlEmpresa_5Label_Text";
            this._pnlEmpresa_5Label_Text.Size = new System.Drawing.Size(65, 25);
            this._pnlEmpresa_5Label_Text.TabIndex = 0;
            this._pnlEmpresa_5Label_Text.Tag = "";
            this._pnlEmpresa_5Label_Text.Text = "  Número";
            this._pnlEmpresa_5Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _pnlEmpresa_4
            // 
            this._pnlEmpresa_4.Location = new System.Drawing.Point(80, 40);
            this._pnlEmpresa_4.Name = "_pnlEmpresa_4";
            this._pnlEmpresa_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlEmpresa_4.OcxState")));
            this._pnlEmpresa_4.Size = new System.Drawing.Size(337, 25);
            this._pnlEmpresa_4.TabIndex = 77;
            this._pnlEmpresa_4.Tag = "";
            // 
            // _pnlEmpresa_0
            // 
            this._pnlEmpresa_0.Controls.Add(this._pnlEmpresa_0Label_Text);
            this._pnlEmpresa_0.Location = new System.Drawing.Point(8, 12);
            this._pnlEmpresa_0.Name = "_pnlEmpresa_0";
            this._pnlEmpresa_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlEmpresa_0.OcxState")));
            this._pnlEmpresa_0.Size = new System.Drawing.Size(67, 27);
            this._pnlEmpresa_0.TabIndex = 73;
            this._pnlEmpresa_0.Tag = "";
            // 
            // _pnlEmpresa_0Label_Text
            // 
            this._pnlEmpresa_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._pnlEmpresa_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._pnlEmpresa_0Label_Text.Location = new System.Drawing.Point(0, 0);
            this._pnlEmpresa_0Label_Text.Name = "_pnlEmpresa_0Label_Text";
            this._pnlEmpresa_0Label_Text.Size = new System.Drawing.Size(65, 25);
            this._pnlEmpresa_0Label_Text.TabIndex = 0;
            this._pnlEmpresa_0Label_Text.Tag = "";
            this._pnlEmpresa_0Label_Text.Text = "  Grupo";
            this._pnlEmpresa_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _fraEmpresa_1
            // 
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_12);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_13);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_10);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_11);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_14);
            this._fraEmpresa_1.Controls.Add(this._mskEmpresa_9);
            this._fraEmpresa_1.Controls.Add(this._mskEmpresa_8);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_15);
            this._fraEmpresa_1.Controls.Add(this._mskEmpresa_10);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_9);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_2);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_3);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_0);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_1);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_4);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_7);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_8);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_5);
            this._fraEmpresa_1.Controls.Add(this._lblEmpresa_6);
            this._fraEmpresa_1.Controls.Add(this._txtEmpresa_2);
            this._fraEmpresa_1.Controls.Add(this._txtEmpresa_1);
            this._fraEmpresa_1.Controls.Add(this._txtEmpresa_0);
            this._fraEmpresa_1.Controls.Add(this._cmbEmpresa_0);
            this._fraEmpresa_1.Controls.Add(this._mskEmpresa_0);
            this._fraEmpresa_1.Controls.Add(this._txtEmpresa_3);
            this._fraEmpresa_1.Controls.Add(this._mskEmpresa_1);
            this._fraEmpresa_1.Controls.Add(this._mskEmpresa_5);
            this._fraEmpresa_1.Controls.Add(this._mskEmpresa_6);
            this._fraEmpresa_1.Controls.Add(this._mskEmpresa_7);
            this._fraEmpresa_1.Controls.Add(this._mskEmpresa_2);
            this._fraEmpresa_1.Controls.Add(this._mskEmpresa_3);
            this._fraEmpresa_1.Controls.Add(this._mskEmpresa_4);
            this._fraEmpresa_1.Location = new System.Drawing.Point(8, 76);
            this._fraEmpresa_1.Name = "_fraEmpresa_1";
            this._fraEmpresa_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_fraEmpresa_1.OcxState")));
            this._fraEmpresa_1.Size = new System.Drawing.Size(617, 273);
            this._fraEmpresa_1.TabIndex = 72;
            this._fraEmpresa_1.Tag = "";
            // 
            // _lblEmpresa_12
            // 
            this._lblEmpresa_12.AutoSize = true;
            this._lblEmpresa_12.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_12.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_12.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_12.Location = new System.Drawing.Point(351, 152);
            this._lblEmpresa_12.Name = "_lblEmpresa_12";
            this._lblEmpresa_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_12.Size = new System.Drawing.Size(113, 13);
            this._lblEmpresa_12.TabIndex = 92;
            this._lblEmpresa_12.Tag = "";
            this._lblEmpresa_12.Text = "Credito Acumulado";
            // 
            // _lblEmpresa_13
            // 
            this._lblEmpresa_13.AutoSize = true;
            this._lblEmpresa_13.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_13.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_13.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_13.Location = new System.Drawing.Point(357, 184);
            this._lblEmpresa_13.Name = "_lblEmpresa_13";
            this._lblEmpresa_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_13.Size = new System.Drawing.Size(107, 13);
            this._lblEmpresa_13.TabIndex = 93;
            this._lblEmpresa_13.Tag = "";
            this._lblEmpresa_13.Text = "Mínimo a facturar";
            // 
            // _lblEmpresa_10
            // 
            this._lblEmpresa_10.AutoSize = true;
            this._lblEmpresa_10.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_10.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_10.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_10.Location = new System.Drawing.Point(420, 88);
            this._lblEmpresa_10.Name = "_lblEmpresa_10";
            this._lblEmpresa_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_10.Size = new System.Drawing.Size(44, 13);
            this._lblEmpresa_10.TabIndex = 90;
            this._lblEmpresa_10.Tag = "";
            this._lblEmpresa_10.Text = "Sector";
            // 
            // _lblEmpresa_11
            // 
            this._lblEmpresa_11.AutoSize = true;
            this._lblEmpresa_11.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_11.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_11.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_11.Location = new System.Drawing.Point(268, 120);
            this._lblEmpresa_11.Name = "_lblEmpresa_11";
            this._lblEmpresa_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_11.Size = new System.Drawing.Size(196, 13);
            this._lblEmpresa_11.TabIndex = 91;
            this._lblEmpresa_11.Tag = "";
            this._lblEmpresa_11.Text = "Vencimiento Crédito(dd/mm/yyyy)";
            // 
            // _lblEmpresa_14
            // 
            this._lblEmpresa_14.AutoSize = true;
            this._lblEmpresa_14.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_14.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_14.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_14.Location = new System.Drawing.Point(384, 216);
            this._lblEmpresa_14.Name = "_lblEmpresa_14";
            this._lblEmpresa_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_14.Size = new System.Drawing.Size(80, 13);
            this._lblEmpresa_14.TabIndex = 94;
            this._lblEmpresa_14.Tag = "";
            this._lblEmpresa_14.Text = "Día de Corte";
            // 
            // _mskEmpresa_9
            // 
            this._mskEmpresa_9.Location = new System.Drawing.Point(152, 245);
            this._mskEmpresa_9.Name = "_mskEmpresa_9";
            this._mskEmpresa_9.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_9.OcxState")));
            this._mskEmpresa_9.Size = new System.Drawing.Size(73, 19);
            this._mskEmpresa_9.TabIndex = 14;
            this._mskEmpresa_9.Tag = "";
            this._mskEmpresa_9.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_9.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_9.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_9.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _mskEmpresa_8
            // 
            this._mskEmpresa_8.Location = new System.Drawing.Point(464, 213);
            this._mskEmpresa_8.Name = "_mskEmpresa_8";
            this._mskEmpresa_8.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_8.OcxState")));
            this._mskEmpresa_8.Size = new System.Drawing.Size(81, 19);
            this._mskEmpresa_8.TabIndex = 13;
            this._mskEmpresa_8.Tag = "";
            this._mskEmpresa_8.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_8.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_8.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_8.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _lblEmpresa_15
            // 
            this._lblEmpresa_15.AutoSize = true;
            this._lblEmpresa_15.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_15.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_15.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_15.Location = new System.Drawing.Point(281, 248);
            this._lblEmpresa_15.Name = "_lblEmpresa_15";
            this._lblEmpresa_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_15.Size = new System.Drawing.Size(183, 13);
            this._lblEmpresa_15.TabIndex = 95;
            this._lblEmpresa_15.Tag = "";
            this._lblEmpresa_15.Text = "Plazo de no cobro de intereses";
            // 
            // _mskEmpresa_10
            // 
            this._mskEmpresa_10.Location = new System.Drawing.Point(464, 245);
            this._mskEmpresa_10.Name = "_mskEmpresa_10";
            this._mskEmpresa_10.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_10.OcxState")));
            this._mskEmpresa_10.Size = new System.Drawing.Size(81, 19);
            this._mskEmpresa_10.TabIndex = 15;
            this._mskEmpresa_10.Tag = "";
            this._mskEmpresa_10.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_10.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_10.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_10.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _lblEmpresa_9
            // 
            this._lblEmpresa_9.AutoSize = true;
            this._lblEmpresa_9.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_9.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_9.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_9.Location = new System.Drawing.Point(421, 56);
            this._lblEmpresa_9.Name = "_lblEmpresa_9";
            this._lblEmpresa_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_9.Size = new System.Drawing.Size(43, 13);
            this._lblEmpresa_9.TabIndex = 89;
            this._lblEmpresa_9.Tag = "";
            this._lblEmpresa_9.Text = "R.F.C.";
            // 
            // _lblEmpresa_2
            // 
            this._lblEmpresa_2.AutoSize = true;
            this._lblEmpresa_2.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_2.Location = new System.Drawing.Point(16, 88);
            this._lblEmpresa_2.Name = "_lblEmpresa_2";
            this._lblEmpresa_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_2.Size = new System.Drawing.Size(119, 13);
            this._lblEmpresa_2.TabIndex = 82;
            this._lblEmpresa_2.Tag = "";
            this._lblEmpresa_2.Text = "Principal Accionista";
            // 
            // _lblEmpresa_3
            // 
            this._lblEmpresa_3.AutoSize = true;
            this._lblEmpresa_3.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_3.Location = new System.Drawing.Point(16, 120);
            this._lblEmpresa_3.Name = "_lblEmpresa_3";
            this._lblEmpresa_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_3.Size = new System.Drawing.Size(72, 13);
            this._lblEmpresa_3.TabIndex = 83;
            this._lblEmpresa_3.Tag = "";
            this._lblEmpresa_3.Text = "No. Cartera";
            // 
            // _lblEmpresa_0
            // 
            this._lblEmpresa_0.AutoSize = true;
            this._lblEmpresa_0.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_0.Location = new System.Drawing.Point(16, 24);
            this._lblEmpresa_0.Name = "_lblEmpresa_0";
            this._lblEmpresa_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_0.Size = new System.Drawing.Size(86, 13);
            this._lblEmpresa_0.TabIndex = 80;
            this._lblEmpresa_0.Tag = "";
            this._lblEmpresa_0.Text = "Nombre Largo";
            // 
            // _lblEmpresa_1
            // 
            this._lblEmpresa_1.AutoSize = true;
            this._lblEmpresa_1.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_1.Location = new System.Drawing.Point(16, 56);
            this._lblEmpresa_1.Name = "_lblEmpresa_1";
            this._lblEmpresa_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_1.Size = new System.Drawing.Size(84, 13);
            this._lblEmpresa_1.TabIndex = 81;
            this._lblEmpresa_1.Tag = "";
            this._lblEmpresa_1.Text = "Nombre Corto";
            // 
            // _lblEmpresa_4
            // 
            this._lblEmpresa_4.AutoSize = true;
            this._lblEmpresa_4.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_4.Location = new System.Drawing.Point(16, 152);
            this._lblEmpresa_4.Name = "_lblEmpresa_4";
            this._lblEmpresa_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_4.Size = new System.Drawing.Size(132, 13);
            this._lblEmpresa_4.TabIndex = 84;
            this._lblEmpresa_4.Tag = "";
            this._lblEmpresa_4.Text = "CréditoTotal Asignado";
            // 
            // _lblEmpresa_7
            // 
            this._lblEmpresa_7.AutoSize = true;
            this._lblEmpresa_7.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_7.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_7.Location = new System.Drawing.Point(16, 248);
            this._lblEmpresa_7.Name = "_lblEmpresa_7";
            this._lblEmpresa_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_7.Size = new System.Drawing.Size(111, 13);
            this._lblEmpresa_7.TabIndex = 87;
            this._lblEmpresa_7.Tag = "";
            this._lblEmpresa_7.Text = "Período de Gracia";
            // 
            // _lblEmpresa_8
            // 
            this._lblEmpresa_8.AutoSize = true;
            this._lblEmpresa_8.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_8.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_8.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_8.Location = new System.Drawing.Point(418, 24);
            this._lblEmpresa_8.Name = "_lblEmpresa_8";
            this._lblEmpresa_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_8.Size = new System.Drawing.Size(46, 13);
            this._lblEmpresa_8.TabIndex = 88;
            this._lblEmpresa_8.Tag = "";
            this._lblEmpresa_8.Text = "Cliente";
            // 
            // _lblEmpresa_5
            // 
            this._lblEmpresa_5.AutoSize = true;
            this._lblEmpresa_5.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_5.Location = new System.Drawing.Point(16, 184);
            this._lblEmpresa_5.Name = "_lblEmpresa_5";
            this._lblEmpresa_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_5.Size = new System.Drawing.Size(112, 13);
            this._lblEmpresa_5.TabIndex = 85;
            this._lblEmpresa_5.Tag = "";
            this._lblEmpresa_5.Text = "% Mínimo de Pago";
            // 
            // _lblEmpresa_6
            // 
            this._lblEmpresa_6.AutoSize = true;
            this._lblEmpresa_6.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_6.Location = new System.Drawing.Point(16, 216);
            this._lblEmpresa_6.Name = "_lblEmpresa_6";
            this._lblEmpresa_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_6.Size = new System.Drawing.Size(101, 13);
            this._lblEmpresa_6.TabIndex = 86;
            this._lblEmpresa_6.Tag = "";
            this._lblEmpresa_6.Text = "Cuenta Contable";
            // 
            // _txtEmpresa_2
            // 
            this._txtEmpresa_2.AcceptsReturn = true;
            this._txtEmpresa_2.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_2.Location = new System.Drawing.Point(152, 85);
            this._txtEmpresa_2.MaxLength = 35;
            this._txtEmpresa_2.Name = "_txtEmpresa_2";
            this._txtEmpresa_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_2.Size = new System.Drawing.Size(246, 20);
            this._txtEmpresa_2.TabIndex = 4;
            this._txtEmpresa_2.Tag = "";
            this._txtEmpresa_2.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_2.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_2.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_2.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _txtEmpresa_1
            // 
            this._txtEmpresa_1.AcceptsReturn = true;
            this._txtEmpresa_1.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_1.Location = new System.Drawing.Point(152, 53);
            this._txtEmpresa_1.MaxLength = 24;
            this._txtEmpresa_1.Name = "_txtEmpresa_1";
            this._txtEmpresa_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_1.Size = new System.Drawing.Size(246, 20);
            this._txtEmpresa_1.TabIndex = 2;
            this._txtEmpresa_1.Tag = "";
            this._txtEmpresa_1.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_1.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_1.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_1.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _txtEmpresa_0
            // 
            this._txtEmpresa_0.AcceptsReturn = true;
            this._txtEmpresa_0.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_0.Location = new System.Drawing.Point(152, 21);
            this._txtEmpresa_0.MaxLength = 45;
            this._txtEmpresa_0.Name = "_txtEmpresa_0";
            this._txtEmpresa_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_0.Size = new System.Drawing.Size(246, 20);
            this._txtEmpresa_0.TabIndex = 0;
            this._txtEmpresa_0.Tag = "";
            this._txtEmpresa_0.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_0.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_0.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_0.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _cmbEmpresa_0
            // 
            this._cmbEmpresa_0.BackColor = System.Drawing.SystemColors.Window;
            this._cmbEmpresa_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmbEmpresa_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbEmpresa_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._cmbEmpresa_0.Location = new System.Drawing.Point(464, 84);
            this._cmbEmpresa_0.Name = "_cmbEmpresa_0";
            this._cmbEmpresa_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmbEmpresa_0.Size = new System.Drawing.Size(137, 21);
            this._cmbEmpresa_0.TabIndex = 5;
            this._cmbEmpresa_0.Tag = "";
            this._cmbEmpresa_0.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresa_SelectedIndexChanged);
            this._cmbEmpresa_0.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEmpresa_Validating);
            // 
            // _mskEmpresa_0
            // 
            this._mskEmpresa_0.Location = new System.Drawing.Point(464, 21);
            this._mskEmpresa_0.Name = "_mskEmpresa_0";
            this._mskEmpresa_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_0.OcxState")));
            this._mskEmpresa_0.Size = new System.Drawing.Size(137, 19);
            this._mskEmpresa_0.TabIndex = 1;
            this._mskEmpresa_0.Tag = "";
            this._mskEmpresa_0.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_0.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_0.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_0.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _txtEmpresa_3
            // 
            this._txtEmpresa_3.AcceptsReturn = true;
            this._txtEmpresa_3.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_3.Location = new System.Drawing.Point(152, 213);
            this._txtEmpresa_3.MaxLength = 40;
            this._txtEmpresa_3.Name = "_txtEmpresa_3";
            this._txtEmpresa_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_3.Size = new System.Drawing.Size(222, 20);
            this._txtEmpresa_3.TabIndex = 12;
            this._txtEmpresa_3.Tag = "";
            this._txtEmpresa_3.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_3.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_3.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_3.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _mskEmpresa_1
            // 
            this._mskEmpresa_1.Location = new System.Drawing.Point(464, 53);
            this._mskEmpresa_1.Name = "_mskEmpresa_1";
            this._mskEmpresa_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_1.OcxState")));
            this._mskEmpresa_1.Size = new System.Drawing.Size(137, 19);
            this._mskEmpresa_1.TabIndex = 3;
            this._mskEmpresa_1.Tag = "";
            this._mskEmpresa_1.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_1.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_1.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_1.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _mskEmpresa_5
            // 
            this._mskEmpresa_5.Location = new System.Drawing.Point(464, 149);
            this._mskEmpresa_5.Name = "_mskEmpresa_5";
            this._mskEmpresa_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_5.OcxState")));
            this._mskEmpresa_5.Size = new System.Drawing.Size(137, 19);
            this._mskEmpresa_5.TabIndex = 9;
            this._mskEmpresa_5.Tag = "";
            this._mskEmpresa_5.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_5.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_5.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_5.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _mskEmpresa_6
            // 
            this._mskEmpresa_6.Location = new System.Drawing.Point(152, 181);
            this._mskEmpresa_6.Name = "_mskEmpresa_6";
            this._mskEmpresa_6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_6.OcxState")));
            this._mskEmpresa_6.Size = new System.Drawing.Size(105, 19);
            this._mskEmpresa_6.TabIndex = 10;
            this._mskEmpresa_6.Tag = "";
            this._mskEmpresa_6.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_6.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_6.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_6.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _mskEmpresa_7
            // 
            this._mskEmpresa_7.Location = new System.Drawing.Point(464, 181);
            this._mskEmpresa_7.Name = "_mskEmpresa_7";
            this._mskEmpresa_7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_7.OcxState")));
            this._mskEmpresa_7.Size = new System.Drawing.Size(137, 19);
            this._mskEmpresa_7.TabIndex = 11;
            this._mskEmpresa_7.Tag = "";
            this._mskEmpresa_7.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_7.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_7.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_7.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _mskEmpresa_2
            // 
            this._mskEmpresa_2.Location = new System.Drawing.Point(152, 117);
            this._mskEmpresa_2.Name = "_mskEmpresa_2";
            this._mskEmpresa_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_2.OcxState")));
            this._mskEmpresa_2.Size = new System.Drawing.Size(105, 19);
            this._mskEmpresa_2.TabIndex = 6;
            this._mskEmpresa_2.Tag = "";
            this._mskEmpresa_2.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_2.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_2.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_2.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _mskEmpresa_3
            // 
            this._mskEmpresa_3.Location = new System.Drawing.Point(464, 117);
            this._mskEmpresa_3.Name = "_mskEmpresa_3";
            this._mskEmpresa_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_3.OcxState")));
            this._mskEmpresa_3.Size = new System.Drawing.Size(137, 19);
            this._mskEmpresa_3.TabIndex = 7;
            this._mskEmpresa_3.Tag = "";
            this._mskEmpresa_3.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_3.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_3.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_3.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _mskEmpresa_4
            // 
            this._mskEmpresa_4.Location = new System.Drawing.Point(152, 149);
            this._mskEmpresa_4.Name = "_mskEmpresa_4";
            this._mskEmpresa_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_4.OcxState")));
            this._mskEmpresa_4.Size = new System.Drawing.Size(145, 19);
            this._mskEmpresa_4.TabIndex = 8;
            this._mskEmpresa_4.Tag = "";
            this._mskEmpresa_4.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_4.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_4.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_4.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _tabEmpresa_TabPage1
            // 
            this._tabEmpresa_TabPage1.Controls.Add(this._fraEmpresa_3);
            this._tabEmpresa_TabPage1.Controls.Add(this._fraEmpresa_2);
            this._tabEmpresa_TabPage1.Location = new System.Drawing.Point(4, 43);
            this._tabEmpresa_TabPage1.Name = "_tabEmpresa_TabPage1";
            this._tabEmpresa_TabPage1.Size = new System.Drawing.Size(631, 342);
            this._tabEmpresa_TabPage1.TabIndex = 2;
            this._tabEmpresa_TabPage1.Tag = "";
            this._tabEmpresa_TabPage1.Text = "Domicilio";
            // 
            // _fraEmpresa_3
            // 
            this._fraEmpresa_3.Controls.Add(this._mskEmpresa_12);
            this._fraEmpresa_3.Controls.Add(this._lblEmpresa_21);
            this._fraEmpresa_3.Controls.Add(this._txtEmpresa_9);
            this._fraEmpresa_3.Controls.Add(this._txtEmpresa_8);
            this._fraEmpresa_3.Controls.Add(this._lblEmpresa_20);
            this._fraEmpresa_3.Controls.Add(this._lblEmpresa_17);
            this._fraEmpresa_3.Controls.Add(this._lblEmpresa_16);
            this._fraEmpresa_3.Controls.Add(this._lblEmpresa_19);
            this._fraEmpresa_3.Controls.Add(this._lblEmpresa_18);
            this._fraEmpresa_3.Controls.Add(this._cmbEmpresa_2);
            this._fraEmpresa_3.Controls.Add(this._txtEmpresa_11);
            this._fraEmpresa_3.Controls.Add(this._txtEmpresa_10);
            this._fraEmpresa_3.Location = new System.Drawing.Point(8, 188);
            this._fraEmpresa_3.Name = "_fraEmpresa_3";
            this._fraEmpresa_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_fraEmpresa_3.OcxState")));
            this._fraEmpresa_3.Size = new System.Drawing.Size(617, 153);
            this._fraEmpresa_3.TabIndex = 103;
            this._fraEmpresa_3.Tag = "";
            // 
            // _mskEmpresa_12
            // 
            this._mskEmpresa_12.Location = new System.Drawing.Point(453, 117);
            this._mskEmpresa_12.Name = "_mskEmpresa_12";
            this._mskEmpresa_12.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_12.OcxState")));
            this._mskEmpresa_12.Size = new System.Drawing.Size(113, 19);
            this._mskEmpresa_12.TabIndex = 27;
            this._mskEmpresa_12.Tag = "";
            this._mskEmpresa_12.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_12.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_12.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_12.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _lblEmpresa_21
            // 
            this._lblEmpresa_21.AutoSize = true;
            this._lblEmpresa_21.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_21.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_21.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_21.Location = new System.Drawing.Point(416, 120);
            this._lblEmpresa_21.Name = "_lblEmpresa_21";
            this._lblEmpresa_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_21.Size = new System.Drawing.Size(31, 13);
            this._lblEmpresa_21.TabIndex = 109;
            this._lblEmpresa_21.Tag = "";
            this._lblEmpresa_21.Text = "C.P.";
            // 
            // _txtEmpresa_9
            // 
            this._txtEmpresa_9.AcceptsReturn = true;
            this._txtEmpresa_9.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_9.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_9.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_9.Location = new System.Drawing.Point(104, 45);
            this._txtEmpresa_9.MaxLength = 25;
            this._txtEmpresa_9.Name = "_txtEmpresa_9";
            this._txtEmpresa_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_9.Size = new System.Drawing.Size(462, 20);
            this._txtEmpresa_9.TabIndex = 23;
            this._txtEmpresa_9.Tag = "";
            this._txtEmpresa_9.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_9.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_9.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_9.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_9.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _txtEmpresa_8
            // 
            this._txtEmpresa_8.AcceptsReturn = true;
            this._txtEmpresa_8.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_8.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_8.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_8.Location = new System.Drawing.Point(208, 21);
            this._txtEmpresa_8.MaxLength = 35;
            this._txtEmpresa_8.Name = "_txtEmpresa_8";
            this._txtEmpresa_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_8.Size = new System.Drawing.Size(358, 20);
            this._txtEmpresa_8.TabIndex = 22;
            this._txtEmpresa_8.Tag = "";
            this._txtEmpresa_8.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_8.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_8.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_8.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_8.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _lblEmpresa_20
            // 
            this._lblEmpresa_20.AutoSize = true;
            this._lblEmpresa_20.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_20.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_20.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_20.Location = new System.Drawing.Point(48, 120);
            this._lblEmpresa_20.Name = "_lblEmpresa_20";
            this._lblEmpresa_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_20.Size = new System.Drawing.Size(46, 13);
            this._lblEmpresa_20.TabIndex = 108;
            this._lblEmpresa_20.Tag = "";
            this._lblEmpresa_20.Text = "Estado";
            // 
            // _lblEmpresa_17
            // 
            this._lblEmpresa_17.AutoSize = true;
            this._lblEmpresa_17.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_17.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_17.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_17.Location = new System.Drawing.Point(48, 48);
            this._lblEmpresa_17.Name = "_lblEmpresa_17";
            this._lblEmpresa_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_17.Size = new System.Drawing.Size(49, 13);
            this._lblEmpresa_17.TabIndex = 105;
            this._lblEmpresa_17.Tag = "";
            this._lblEmpresa_17.Text = "Colonia";
            // 
            // _lblEmpresa_16
            // 
            this._lblEmpresa_16.AutoSize = true;
            this._lblEmpresa_16.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_16.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_16.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_16.Location = new System.Drawing.Point(48, 24);
            this._lblEmpresa_16.Name = "_lblEmpresa_16";
            this._lblEmpresa_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_16.Size = new System.Drawing.Size(155, 13);
            this._lblEmpresa_16.TabIndex = 104;
            this._lblEmpresa_16.Tag = "";
            this._lblEmpresa_16.Text = "Domicilio (Calle y Número)";
            // 
            // _lblEmpresa_19
            // 
            this._lblEmpresa_19.AutoSize = true;
            this._lblEmpresa_19.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_19.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_19.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_19.Location = new System.Drawing.Point(48, 96);
            this._lblEmpresa_19.Name = "_lblEmpresa_19";
            this._lblEmpresa_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_19.Size = new System.Drawing.Size(46, 13);
            this._lblEmpresa_19.TabIndex = 107;
            this._lblEmpresa_19.Tag = "";
            this._lblEmpresa_19.Text = "Ciudad";
            // 
            // _lblEmpresa_18
            // 
            this._lblEmpresa_18.AutoSize = true;
            this._lblEmpresa_18.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_18.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_18.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_18.Location = new System.Drawing.Point(48, 72);
            this._lblEmpresa_18.Name = "_lblEmpresa_18";
            this._lblEmpresa_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_18.Size = new System.Drawing.Size(96, 13);
            this._lblEmpresa_18.TabIndex = 106;
            this._lblEmpresa_18.Tag = "";
            this._lblEmpresa_18.Text = "Pob./Del./Mun.";
            // 
            // _cmbEmpresa_2
            // 
            this._cmbEmpresa_2.BackColor = System.Drawing.SystemColors.Window;
            this._cmbEmpresa_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmbEmpresa_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbEmpresa_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._cmbEmpresa_2.Location = new System.Drawing.Point(104, 116);
            this._cmbEmpresa_2.Name = "_cmbEmpresa_2";
            this._cmbEmpresa_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmbEmpresa_2.Size = new System.Drawing.Size(249, 21);
            this._cmbEmpresa_2.TabIndex = 26;
            this._cmbEmpresa_2.Tag = "";
            this._cmbEmpresa_2.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresa_SelectedIndexChanged);
            this._cmbEmpresa_2.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEmpresa_Validating);
            // 
            // _txtEmpresa_11
            // 
            this._txtEmpresa_11.AcceptsReturn = true;
            this._txtEmpresa_11.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_11.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_11.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_11.Location = new System.Drawing.Point(104, 93);
            this._txtEmpresa_11.MaxLength = 25;
            this._txtEmpresa_11.Name = "_txtEmpresa_11";
            this._txtEmpresa_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_11.Size = new System.Drawing.Size(462, 20);
            this._txtEmpresa_11.TabIndex = 25;
            this._txtEmpresa_11.Tag = "";
            this._txtEmpresa_11.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_11.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_11.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_11.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_11.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _txtEmpresa_10
            // 
            this._txtEmpresa_10.AcceptsReturn = true;
            this._txtEmpresa_10.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_10.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_10.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_10.Location = new System.Drawing.Point(144, 69);
            this._txtEmpresa_10.MaxLength = 25;
            this._txtEmpresa_10.Name = "_txtEmpresa_10";
            this._txtEmpresa_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_10.Size = new System.Drawing.Size(422, 20);
            this._txtEmpresa_10.TabIndex = 24;
            this._txtEmpresa_10.Tag = "";
            this._txtEmpresa_10.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_10.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_10.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_10.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_10.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _fraEmpresa_2
            // 
            this._fraEmpresa_2.Controls.Add(this._mskEmpresa_11);
            this._fraEmpresa_2.Controls.Add(this._lblEmpresa_31);
            this._fraEmpresa_2.Controls.Add(this._txtEmpresa_5);
            this._fraEmpresa_2.Controls.Add(this._txtEmpresa_4);
            this._fraEmpresa_2.Controls.Add(this._lblEmpresa_30);
            this._fraEmpresa_2.Controls.Add(this._lblEmpresa_27);
            this._fraEmpresa_2.Controls.Add(this._lblEmpresa_26);
            this._fraEmpresa_2.Controls.Add(this._lblEmpresa_29);
            this._fraEmpresa_2.Controls.Add(this._lblEmpresa_28);
            this._fraEmpresa_2.Controls.Add(this._cmbEmpresa_1);
            this._fraEmpresa_2.Controls.Add(this._txtEmpresa_7);
            this._fraEmpresa_2.Controls.Add(this._txtEmpresa_6);
            this._fraEmpresa_2.Location = new System.Drawing.Point(8, 20);
            this._fraEmpresa_2.Name = "_fraEmpresa_2";
            this._fraEmpresa_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_fraEmpresa_2.OcxState")));
            this._fraEmpresa_2.Size = new System.Drawing.Size(617, 153);
            this._fraEmpresa_2.TabIndex = 96;
            this._fraEmpresa_2.Tag = "";
            // 
            // _mskEmpresa_11
            // 
            this._mskEmpresa_11.Location = new System.Drawing.Point(453, 117);
            this._mskEmpresa_11.Name = "_mskEmpresa_11";
            this._mskEmpresa_11.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_11.OcxState")));
            this._mskEmpresa_11.Size = new System.Drawing.Size(113, 19);
            this._mskEmpresa_11.TabIndex = 21;
            this._mskEmpresa_11.Tag = "";
            this._mskEmpresa_11.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_11.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_11.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_11.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _lblEmpresa_31
            // 
            this._lblEmpresa_31.AutoSize = true;
            this._lblEmpresa_31.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_31.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_31.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_31.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_31.Location = new System.Drawing.Point(48, 24);
            this._lblEmpresa_31.Name = "_lblEmpresa_31";
            this._lblEmpresa_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_31.Size = new System.Drawing.Size(155, 13);
            this._lblEmpresa_31.TabIndex = 102;
            this._lblEmpresa_31.Tag = "";
            this._lblEmpresa_31.Text = "Domicilio (Calle y Número)";
            // 
            // _txtEmpresa_5
            // 
            this._txtEmpresa_5.AcceptsReturn = true;
            this._txtEmpresa_5.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_5.Location = new System.Drawing.Point(104, 45);
            this._txtEmpresa_5.MaxLength = 25;
            this._txtEmpresa_5.Name = "_txtEmpresa_5";
            this._txtEmpresa_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_5.Size = new System.Drawing.Size(462, 20);
            this._txtEmpresa_5.TabIndex = 17;
            this._txtEmpresa_5.Tag = "";
            this._txtEmpresa_5.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_5.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_5.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_5.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_5.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _txtEmpresa_4
            // 
            this._txtEmpresa_4.AcceptsReturn = true;
            this._txtEmpresa_4.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_4.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_4.Location = new System.Drawing.Point(208, 21);
            this._txtEmpresa_4.MaxLength = 35;
            this._txtEmpresa_4.Name = "_txtEmpresa_4";
            this._txtEmpresa_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_4.Size = new System.Drawing.Size(358, 20);
            this._txtEmpresa_4.TabIndex = 16;
            this._txtEmpresa_4.Tag = "";
            this._txtEmpresa_4.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_4.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_4.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_4.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _lblEmpresa_30
            // 
            this._lblEmpresa_30.AutoSize = true;
            this._lblEmpresa_30.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_30.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_30.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_30.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_30.Location = new System.Drawing.Point(48, 48);
            this._lblEmpresa_30.Name = "_lblEmpresa_30";
            this._lblEmpresa_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_30.Size = new System.Drawing.Size(49, 13);
            this._lblEmpresa_30.TabIndex = 101;
            this._lblEmpresa_30.Tag = "";
            this._lblEmpresa_30.Text = "Colonia";
            // 
            // _lblEmpresa_27
            // 
            this._lblEmpresa_27.AutoSize = true;
            this._lblEmpresa_27.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_27.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_27.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_27.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_27.Location = new System.Drawing.Point(48, 120);
            this._lblEmpresa_27.Name = "_lblEmpresa_27";
            this._lblEmpresa_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_27.Size = new System.Drawing.Size(46, 13);
            this._lblEmpresa_27.TabIndex = 98;
            this._lblEmpresa_27.Tag = "";
            this._lblEmpresa_27.Text = "Estado";
            // 
            // _lblEmpresa_26
            // 
            this._lblEmpresa_26.AutoSize = true;
            this._lblEmpresa_26.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_26.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_26.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_26.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_26.Location = new System.Drawing.Point(416, 120);
            this._lblEmpresa_26.Name = "_lblEmpresa_26";
            this._lblEmpresa_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_26.Size = new System.Drawing.Size(31, 13);
            this._lblEmpresa_26.TabIndex = 97;
            this._lblEmpresa_26.Tag = "";
            this._lblEmpresa_26.Text = "C.P.";
            // 
            // _lblEmpresa_29
            // 
            this._lblEmpresa_29.AutoSize = true;
            this._lblEmpresa_29.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_29.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_29.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_29.Location = new System.Drawing.Point(48, 72);
            this._lblEmpresa_29.Name = "_lblEmpresa_29";
            this._lblEmpresa_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_29.Size = new System.Drawing.Size(96, 13);
            this._lblEmpresa_29.TabIndex = 100;
            this._lblEmpresa_29.Tag = "";
            this._lblEmpresa_29.Text = "Pob./Del./Mun.";
            // 
            // _lblEmpresa_28
            // 
            this._lblEmpresa_28.AutoSize = true;
            this._lblEmpresa_28.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_28.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_28.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_28.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_28.Location = new System.Drawing.Point(48, 96);
            this._lblEmpresa_28.Name = "_lblEmpresa_28";
            this._lblEmpresa_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_28.Size = new System.Drawing.Size(46, 13);
            this._lblEmpresa_28.TabIndex = 99;
            this._lblEmpresa_28.Tag = "";
            this._lblEmpresa_28.Text = "Ciudad";
            // 
            // _cmbEmpresa_1
            // 
            this._cmbEmpresa_1.BackColor = System.Drawing.SystemColors.Window;
            this._cmbEmpresa_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmbEmpresa_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbEmpresa_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._cmbEmpresa_1.Location = new System.Drawing.Point(104, 116);
            this._cmbEmpresa_1.Name = "_cmbEmpresa_1";
            this._cmbEmpresa_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmbEmpresa_1.Size = new System.Drawing.Size(249, 21);
            this._cmbEmpresa_1.TabIndex = 20;
            this._cmbEmpresa_1.Tag = "";
            this._cmbEmpresa_1.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresa_SelectedIndexChanged);
            this._cmbEmpresa_1.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEmpresa_Validating);
            // 
            // _txtEmpresa_7
            // 
            this._txtEmpresa_7.AcceptsReturn = true;
            this._txtEmpresa_7.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_7.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_7.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_7.Location = new System.Drawing.Point(104, 93);
            this._txtEmpresa_7.MaxLength = 25;
            this._txtEmpresa_7.Name = "_txtEmpresa_7";
            this._txtEmpresa_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_7.Size = new System.Drawing.Size(462, 20);
            this._txtEmpresa_7.TabIndex = 19;
            this._txtEmpresa_7.Tag = "";
            this._txtEmpresa_7.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_7.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_7.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_7.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_7.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _txtEmpresa_6
            // 
            this._txtEmpresa_6.AcceptsReturn = true;
            this._txtEmpresa_6.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_6.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_6.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_6.Location = new System.Drawing.Point(144, 69);
            this._txtEmpresa_6.MaxLength = 25;
            this._txtEmpresa_6.Name = "_txtEmpresa_6";
            this._txtEmpresa_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_6.Size = new System.Drawing.Size(422, 20);
            this._txtEmpresa_6.TabIndex = 18;
            this._txtEmpresa_6.Tag = "";
            this._txtEmpresa_6.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_6.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_6.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_6.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_6.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _tabEmpresa_TabPage4
            // 
            this._tabEmpresa_TabPage4.Controls.Add(this._fraEmpresa_9);
            this._tabEmpresa_TabPage4.Controls.Add(this._fraEmpresa_10);
            this._tabEmpresa_TabPage4.Controls.Add(this._fraEmpresa_11);
            this._tabEmpresa_TabPage4.Controls.Add(this._fraEmpresa_8);
            this._tabEmpresa_TabPage4.Controls.Add(this._cmbEmpresa_5);
            this._tabEmpresa_TabPage4.Controls.Add(this._cmbEmpresa_4);
            this._tabEmpresa_TabPage4.Controls.Add(this._chkEmpresa_0);
            this._tabEmpresa_TabPage4.Controls.Add(this._fraEmpresa_12);
            this._tabEmpresa_TabPage4.Controls.Add(this._lblEmpresa_41);
            this._tabEmpresa_TabPage4.Controls.Add(this._lblEmpresa_40);
            this._tabEmpresa_TabPage4.Controls.Add(this._lblEmpresa_42);
            this._tabEmpresa_TabPage4.Controls.Add(this._fraEmpresa_13);
            this._tabEmpresa_TabPage4.Controls.Add(this._mskEmpresa_16);
            this._tabEmpresa_TabPage4.Location = new System.Drawing.Point(4, 43);
            this._tabEmpresa_TabPage4.Name = "_tabEmpresa_TabPage4";
            this._tabEmpresa_TabPage4.Size = new System.Drawing.Size(631, 342);
            this._tabEmpresa_TabPage4.TabIndex = 3;
            this._tabEmpresa_TabPage4.Tag = "";
            this._tabEmpresa_TabPage4.Text = "Datos Adicionales";
            // 
            // _fraEmpresa_9
            // 
            this._fraEmpresa_9.Controls.Add(this._optEmpresa_6);
            this._fraEmpresa_9.Controls.Add(this._optEmpresa_5);
            this._fraEmpresa_9.Location = new System.Drawing.Point(320, 68);
            this._fraEmpresa_9.Name = "_fraEmpresa_9";
            this._fraEmpresa_9.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_fraEmpresa_9.OcxState")));
            this._fraEmpresa_9.Size = new System.Drawing.Size(297, 49);
            this._fraEmpresa_9.TabIndex = 133;
            this._fraEmpresa_9.Tag = "";
            // 
            // _optEmpresa_6
            // 
            this._optEmpresa_6.BackColor = System.Drawing.SystemColors.Control;
            this._optEmpresa_6.Checked = true;
            this._optEmpresa_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._optEmpresa_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEmpresa_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optEmpresa_6.Location = new System.Drawing.Point(152, 18);
            this._optEmpresa_6.Name = "_optEmpresa_6";
            this._optEmpresa_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optEmpresa_6.Size = new System.Drawing.Size(89, 19);
            this._optEmpresa_6.TabIndex = 55;
            this._optEmpresa_6.TabStop = true;
            this._optEmpresa_6.Tag = "";
            this._optEmpresa_6.Text = "Individual";
            this._optEmpresa_6.UseVisualStyleBackColor = false;
            this._optEmpresa_6.CheckedChanged += new System.EventHandler(this.optEmpresa_CheckedChanged);
            // 
            // _optEmpresa_5
            // 
            this._optEmpresa_5.BackColor = System.Drawing.SystemColors.Control;
            this._optEmpresa_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._optEmpresa_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEmpresa_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optEmpresa_5.Location = new System.Drawing.Point(48, 18);
            this._optEmpresa_5.Name = "_optEmpresa_5";
            this._optEmpresa_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optEmpresa_5.Size = new System.Drawing.Size(89, 19);
            this._optEmpresa_5.TabIndex = 54;
            this._optEmpresa_5.TabStop = true;
            this._optEmpresa_5.Tag = "";
            this._optEmpresa_5.Text = "Corporativo";
            this._optEmpresa_5.UseVisualStyleBackColor = false;
            this._optEmpresa_5.CheckedChanged += new System.EventHandler(this.optEmpresa_CheckedChanged);
            // 
            // _fraEmpresa_10
            // 
            this._fraEmpresa_10.Controls.Add(this._optEmpresa_9);
            this._fraEmpresa_10.Controls.Add(this._optEmpresa_7);
            this._fraEmpresa_10.Controls.Add(this._optEmpresa_8);
            this._fraEmpresa_10.Location = new System.Drawing.Point(16, 124);
            this._fraEmpresa_10.Name = "_fraEmpresa_10";
            this._fraEmpresa_10.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_fraEmpresa_10.OcxState")));
            this._fraEmpresa_10.Size = new System.Drawing.Size(289, 105);
            this._fraEmpresa_10.TabIndex = 134;
            this._fraEmpresa_10.Tag = "";
            // 
            // _optEmpresa_9
            // 
            this._optEmpresa_9.BackColor = System.Drawing.SystemColors.Control;
            this._optEmpresa_9.Cursor = System.Windows.Forms.Cursors.Default;
            this._optEmpresa_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEmpresa_9.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optEmpresa_9.Location = new System.Drawing.Point(24, 72);
            this._optEmpresa_9.Name = "_optEmpresa_9";
            this._optEmpresa_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optEmpresa_9.Size = new System.Drawing.Size(233, 13);
            this._optEmpresa_9.TabIndex = 58;
            this._optEmpresa_9.TabStop = true;
            this._optEmpresa_9.Tag = "";
            this._optEmpresa_9.Text = "Libre (La Empresa realiza sus pagos)";
            this._optEmpresa_9.UseVisualStyleBackColor = false;
            this._optEmpresa_9.CheckedChanged += new System.EventHandler(this.optEmpresa_CheckedChanged);
            // 
            // _optEmpresa_7
            // 
            this._optEmpresa_7.BackColor = System.Drawing.SystemColors.Control;
            this._optEmpresa_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._optEmpresa_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEmpresa_7.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optEmpresa_7.Location = new System.Drawing.Point(24, 24);
            this._optEmpresa_7.Name = "_optEmpresa_7";
            this._optEmpresa_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optEmpresa_7.Size = new System.Drawing.Size(89, 13);
            this._optEmpresa_7.TabIndex = 56;
            this._optEmpresa_7.TabStop = true;
            this._optEmpresa_7.Tag = "";
            this._optEmpresa_7.Text = "Automático";
            this._optEmpresa_7.UseVisualStyleBackColor = false;
            this._optEmpresa_7.CheckedChanged += new System.EventHandler(this.optEmpresa_CheckedChanged);
            // 
            // _optEmpresa_8
            // 
            this._optEmpresa_8.BackColor = System.Drawing.SystemColors.Control;
            this._optEmpresa_8.Checked = true;
            this._optEmpresa_8.Cursor = System.Windows.Forms.Cursors.Default;
            this._optEmpresa_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEmpresa_8.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optEmpresa_8.Location = new System.Drawing.Point(24, 48);
            this._optEmpresa_8.Name = "_optEmpresa_8";
            this._optEmpresa_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optEmpresa_8.Size = new System.Drawing.Size(81, 13);
            this._optEmpresa_8.TabIndex = 57;
            this._optEmpresa_8.TabStop = true;
            this._optEmpresa_8.Tag = "";
            this._optEmpresa_8.Text = "Individual";
            this._optEmpresa_8.UseVisualStyleBackColor = false;
            this._optEmpresa_8.CheckedChanged += new System.EventHandler(this.optEmpresa_CheckedChanged);
            // 
            // _fraEmpresa_11
            // 
            this._fraEmpresa_11.Controls.Add(this._mskEmpresa_18);
            this._fraEmpresa_11.Controls.Add(this._mskEmpresa_17);
            this._fraEmpresa_11.Controls.Add(this._lblEmpresa_43);
            this._fraEmpresa_11.Controls.Add(this._lblEmpresa_44);
            this._fraEmpresa_11.Location = new System.Drawing.Point(320, 124);
            this._fraEmpresa_11.Name = "_fraEmpresa_11";
            this._fraEmpresa_11.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_fraEmpresa_11.OcxState")));
            this._fraEmpresa_11.Size = new System.Drawing.Size(297, 89);
            this._fraEmpresa_11.TabIndex = 135;
            this._fraEmpresa_11.Tag = "";
            // 
            // _mskEmpresa_18
            // 
            this._mskEmpresa_18.Location = new System.Drawing.Point(112, 53);
            this._mskEmpresa_18.Name = "_mskEmpresa_18";
            this._mskEmpresa_18.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_18.OcxState")));
            this._mskEmpresa_18.Size = new System.Drawing.Size(105, 19);
            this._mskEmpresa_18.TabIndex = 60;
            this._mskEmpresa_18.Tag = "";
            this._mskEmpresa_18.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_18.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_18.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_18.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _mskEmpresa_17
            // 
            this._mskEmpresa_17.Location = new System.Drawing.Point(112, 29);
            this._mskEmpresa_17.Name = "_mskEmpresa_17";
            this._mskEmpresa_17.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_17.OcxState")));
            this._mskEmpresa_17.Size = new System.Drawing.Size(73, 19);
            this._mskEmpresa_17.TabIndex = 59;
            this._mskEmpresa_17.Tag = "";
            this._mskEmpresa_17.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_17.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_17.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_17.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _lblEmpresa_43
            // 
            this._lblEmpresa_43.AutoSize = true;
            this._lblEmpresa_43.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_43.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_43.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_43.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_43.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_43.Location = new System.Drawing.Point(48, 32);
            this._lblEmpresa_43.Name = "_lblEmpresa_43";
            this._lblEmpresa_43.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_43.Size = new System.Drawing.Size(56, 13);
            this._lblEmpresa_43.TabIndex = 136;
            this._lblEmpresa_43.Tag = "";
            this._lblEmpresa_43.Text = "Sucursal";
            // 
            // _lblEmpresa_44
            // 
            this._lblEmpresa_44.AutoSize = true;
            this._lblEmpresa_44.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_44.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_44.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_44.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_44.Location = new System.Drawing.Point(48, 56);
            this._lblEmpresa_44.Name = "_lblEmpresa_44";
            this._lblEmpresa_44.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_44.Size = new System.Drawing.Size(47, 13);
            this._lblEmpresa_44.TabIndex = 137;
            this._lblEmpresa_44.Tag = "";
            this._lblEmpresa_44.Text = "Cuenta";
            // 
            // _fraEmpresa_8
            // 
            this._fraEmpresa_8.Controls.Add(this._optEmpresa_4);
            this._fraEmpresa_8.Controls.Add(this._optEmpresa_3);
            this._fraEmpresa_8.Location = new System.Drawing.Point(16, 68);
            this._fraEmpresa_8.Name = "_fraEmpresa_8";
            this._fraEmpresa_8.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_fraEmpresa_8.OcxState")));
            this._fraEmpresa_8.Size = new System.Drawing.Size(289, 49);
            this._fraEmpresa_8.TabIndex = 132;
            this._fraEmpresa_8.Tag = "";
            // 
            // _optEmpresa_4
            // 
            this._optEmpresa_4.BackColor = System.Drawing.SystemColors.Control;
            this._optEmpresa_4.Checked = true;
            this._optEmpresa_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._optEmpresa_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEmpresa_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optEmpresa_4.Location = new System.Drawing.Point(160, 18);
            this._optEmpresa_4.Name = "_optEmpresa_4";
            this._optEmpresa_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optEmpresa_4.Size = new System.Drawing.Size(81, 19);
            this._optEmpresa_4.TabIndex = 53;
            this._optEmpresa_4.TabStop = true;
            this._optEmpresa_4.Tag = "";
            this._optEmpresa_4.Text = "Individual";
            this._optEmpresa_4.UseVisualStyleBackColor = false;
            this._optEmpresa_4.CheckedChanged += new System.EventHandler(this.optEmpresa_CheckedChanged);
            // 
            // _optEmpresa_3
            // 
            this._optEmpresa_3.BackColor = System.Drawing.SystemColors.Control;
            this._optEmpresa_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._optEmpresa_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEmpresa_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optEmpresa_3.Location = new System.Drawing.Point(40, 18);
            this._optEmpresa_3.Name = "_optEmpresa_3";
            this._optEmpresa_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optEmpresa_3.Size = new System.Drawing.Size(73, 19);
            this._optEmpresa_3.TabIndex = 52;
            this._optEmpresa_3.TabStop = true;
            this._optEmpresa_3.Tag = "";
            this._optEmpresa_3.Text = "Empresa";
            this._optEmpresa_3.UseVisualStyleBackColor = false;
            this._optEmpresa_3.CheckedChanged += new System.EventHandler(this.optEmpresa_CheckedChanged);
            // 
            // _cmbEmpresa_5
            // 
            this._cmbEmpresa_5.BackColor = System.Drawing.SystemColors.Window;
            this._cmbEmpresa_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmbEmpresa_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbEmpresa_5.ForeColor = System.Drawing.SystemColors.WindowText;
            this._cmbEmpresa_5.Location = new System.Drawing.Point(480, 40);
            this._cmbEmpresa_5.Name = "_cmbEmpresa_5";
            this._cmbEmpresa_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmbEmpresa_5.Size = new System.Drawing.Size(137, 21);
            this._cmbEmpresa_5.TabIndex = 51;
            this._cmbEmpresa_5.Tag = "";
            this._cmbEmpresa_5.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresa_SelectedIndexChanged);
            this._cmbEmpresa_5.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEmpresa_Validating);
            // 
            // _cmbEmpresa_4
            // 
            this._cmbEmpresa_4.BackColor = System.Drawing.SystemColors.Window;
            this._cmbEmpresa_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmbEmpresa_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbEmpresa_4.ForeColor = System.Drawing.SystemColors.WindowText;
            this._cmbEmpresa_4.Location = new System.Drawing.Point(96, 16);
            this._cmbEmpresa_4.Name = "_cmbEmpresa_4";
            this._cmbEmpresa_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmbEmpresa_4.Size = new System.Drawing.Size(177, 21);
            this._cmbEmpresa_4.TabIndex = 48;
            this._cmbEmpresa_4.Tag = "";
            this._cmbEmpresa_4.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresa_SelectedIndexChanged);
            this._cmbEmpresa_4.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEmpresa_Validating);
            // 
            // _chkEmpresa_0
            // 
            this._chkEmpresa_0.BackColor = System.Drawing.SystemColors.Control;
            this._chkEmpresa_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._chkEmpresa_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chkEmpresa_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._chkEmpresa_0.Location = new System.Drawing.Point(24, 44);
            this._chkEmpresa_0.Name = "_chkEmpresa_0";
            this._chkEmpresa_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._chkEmpresa_0.Size = new System.Drawing.Size(105, 13);
            this._chkEmpresa_0.TabIndex = 50;
            this._chkEmpresa_0.Tag = "";
            this._chkEmpresa_0.Text = "Skip Payment";
            this._chkEmpresa_0.UseVisualStyleBackColor = false;
            this._chkEmpresa_0.CheckStateChanged += new System.EventHandler(this.chkEmpresa_CheckStateChanged);
            // 
            // _fraEmpresa_12
            // 
            this._fraEmpresa_12.Controls.Add(this._optEmpresa_11);
            this._fraEmpresa_12.Controls.Add(this._optEmpresa_10);
            this._fraEmpresa_12.Controls.Add(this._optEmpresa_12);
            this._fraEmpresa_12.Location = new System.Drawing.Point(16, 236);
            this._fraEmpresa_12.Name = "_fraEmpresa_12";
            this._fraEmpresa_12.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_fraEmpresa_12.OcxState")));
            this._fraEmpresa_12.Size = new System.Drawing.Size(289, 113);
            this._fraEmpresa_12.TabIndex = 138;
            this._fraEmpresa_12.Tag = "";
            // 
            // _optEmpresa_11
            // 
            this._optEmpresa_11.BackColor = System.Drawing.SystemColors.Control;
            this._optEmpresa_11.Cursor = System.Windows.Forms.Cursors.Default;
            this._optEmpresa_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEmpresa_11.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optEmpresa_11.Location = new System.Drawing.Point(32, 56);
            this._optEmpresa_11.Name = "_optEmpresa_11";
            this._optEmpresa_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optEmpresa_11.Size = new System.Drawing.Size(121, 13);
            this._optEmpresa_11.TabIndex = 62;
            this._optEmpresa_11.TabStop = true;
            this._optEmpresa_11.Tag = "";
            this._optEmpresa_11.Text = "Purchasing Card";
            this._optEmpresa_11.UseVisualStyleBackColor = false;
            this._optEmpresa_11.CheckedChanged += new System.EventHandler(this.optEmpresa_CheckedChanged);
            // 
            // _optEmpresa_10
            // 
            this._optEmpresa_10.BackColor = System.Drawing.SystemColors.Control;
            this._optEmpresa_10.Checked = true;
            this._optEmpresa_10.Cursor = System.Windows.Forms.Cursors.Default;
            this._optEmpresa_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEmpresa_10.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optEmpresa_10.Location = new System.Drawing.Point(32, 24);
            this._optEmpresa_10.Name = "_optEmpresa_10";
            this._optEmpresa_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optEmpresa_10.Size = new System.Drawing.Size(105, 13);
            this._optEmpresa_10.TabIndex = 61;
            this._optEmpresa_10.TabStop = true;
            this._optEmpresa_10.Tag = "";
            this._optEmpresa_10.Text = "Business Card";
            this._optEmpresa_10.UseVisualStyleBackColor = false;
            this._optEmpresa_10.CheckedChanged += new System.EventHandler(this.optEmpresa_CheckedChanged);
            // 
            // _optEmpresa_12
            // 
            this._optEmpresa_12.BackColor = System.Drawing.SystemColors.Control;
            this._optEmpresa_12.Cursor = System.Windows.Forms.Cursors.Default;
            this._optEmpresa_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEmpresa_12.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optEmpresa_12.Location = new System.Drawing.Point(32, 88);
            this._optEmpresa_12.Name = "_optEmpresa_12";
            this._optEmpresa_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optEmpresa_12.Size = new System.Drawing.Size(121, 13);
            this._optEmpresa_12.TabIndex = 63;
            this._optEmpresa_12.TabStop = true;
            this._optEmpresa_12.Tag = "";
            this._optEmpresa_12.Text = "Distribution Line";
            this._optEmpresa_12.UseVisualStyleBackColor = false;
            this._optEmpresa_12.CheckedChanged += new System.EventHandler(this.optEmpresa_CheckedChanged);
            // 
            // _lblEmpresa_41
            // 
            this._lblEmpresa_41.AutoSize = true;
            this._lblEmpresa_41.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_41.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_41.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_41.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_41.Location = new System.Drawing.Point(328, 20);
            this._lblEmpresa_41.Name = "_lblEmpresa_41";
            this._lblEmpresa_41.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_41.Size = new System.Drawing.Size(144, 13);
            this._lblEmpresa_41.TabIndex = 130;
            this._lblEmpresa_41.Tag = "";
            this._lblEmpresa_41.Text = "Identificador Tabla MCC";
            // 
            // _lblEmpresa_40
            // 
            this._lblEmpresa_40.AutoSize = true;
            this._lblEmpresa_40.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_40.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_40.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_40.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_40.Location = new System.Drawing.Point(24, 20);
            this._lblEmpresa_40.Name = "_lblEmpresa_40";
            this._lblEmpresa_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_40.Size = new System.Drawing.Size(67, 13);
            this._lblEmpresa_40.TabIndex = 129;
            this._lblEmpresa_40.Tag = "";
            this._lblEmpresa_40.Text = "Mes Fiscal";
            // 
            // _lblEmpresa_42
            // 
            this._lblEmpresa_42.AutoSize = true;
            this._lblEmpresa_42.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_42.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_42.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_42.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_42.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_42.Location = new System.Drawing.Point(328, 44);
            this._lblEmpresa_42.Name = "_lblEmpresa_42";
            this._lblEmpresa_42.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_42.Size = new System.Drawing.Size(126, 13);
            this._lblEmpresa_42.TabIndex = 131;
            this._lblEmpresa_42.Tag = "";
            this._lblEmpresa_42.Text = "Estructura de Gastos";
            // 
            // _fraEmpresa_13
            // 
            this._fraEmpresa_13.Controls.Add(this._chkEmpresa_3);
            this._fraEmpresa_13.Controls.Add(this._chkEmpresa_2);
            this._fraEmpresa_13.Controls.Add(this._chkEmpresa_1);
            this._fraEmpresa_13.Location = new System.Drawing.Point(320, 220);
            this._fraEmpresa_13.Name = "_fraEmpresa_13";
            this._fraEmpresa_13.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_fraEmpresa_13.OcxState")));
            this._fraEmpresa_13.Size = new System.Drawing.Size(297, 129);
            this._fraEmpresa_13.TabIndex = 139;
            this._fraEmpresa_13.Tag = "";
            // 
            // _chkEmpresa_3
            // 
            this._chkEmpresa_3.BackColor = System.Drawing.SystemColors.Control;
            this._chkEmpresa_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._chkEmpresa_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chkEmpresa_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._chkEmpresa_3.Location = new System.Drawing.Point(24, 88);
            this._chkEmpresa_3.Name = "_chkEmpresa_3";
            this._chkEmpresa_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._chkEmpresa_3.Size = new System.Drawing.Size(201, 29);
            this._chkEmpresa_3.TabIndex = 66;
            this._chkEmpresa_3.Tag = "";
            this._chkEmpresa_3.Text = "Generar Reporte de Detalle de Movimiento";
            this._chkEmpresa_3.UseVisualStyleBackColor = false;
            this._chkEmpresa_3.CheckStateChanged += new System.EventHandler(this.chkEmpresa_CheckStateChanged);
            // 
            // _chkEmpresa_2
            // 
            this._chkEmpresa_2.BackColor = System.Drawing.SystemColors.Control;
            this._chkEmpresa_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._chkEmpresa_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chkEmpresa_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._chkEmpresa_2.Location = new System.Drawing.Point(24, 56);
            this._chkEmpresa_2.Name = "_chkEmpresa_2";
            this._chkEmpresa_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._chkEmpresa_2.Size = new System.Drawing.Size(145, 21);
            this._chkEmpresa_2.TabIndex = 65;
            this._chkEmpresa_2.Tag = "";
            this._chkEmpresa_2.Text = "Generar SBF (Diario)";
            this._chkEmpresa_2.UseVisualStyleBackColor = false;
            this._chkEmpresa_2.CheckStateChanged += new System.EventHandler(this.chkEmpresa_CheckStateChanged);
            // 
            // _chkEmpresa_1
            // 
            this._chkEmpresa_1.BackColor = System.Drawing.SystemColors.Control;
            this._chkEmpresa_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._chkEmpresa_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chkEmpresa_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._chkEmpresa_1.Location = new System.Drawing.Point(24, 24);
            this._chkEmpresa_1.Name = "_chkEmpresa_1";
            this._chkEmpresa_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._chkEmpresa_1.Size = new System.Drawing.Size(161, 21);
            this._chkEmpresa_1.TabIndex = 64;
            this._chkEmpresa_1.Tag = "";
            this._chkEmpresa_1.Text = "Generar SBF (Por Corte)";
            this._chkEmpresa_1.UseVisualStyleBackColor = false;
            this._chkEmpresa_1.CheckStateChanged += new System.EventHandler(this.chkEmpresa_CheckStateChanged);
            // 
            // _mskEmpresa_16
            // 
            this._mskEmpresa_16.Location = new System.Drawing.Point(480, 17);
            this._mskEmpresa_16.Name = "_mskEmpresa_16";
            this._mskEmpresa_16.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mskEmpresa_16.OcxState")));
            this._mskEmpresa_16.Size = new System.Drawing.Size(137, 19);
            this._mskEmpresa_16.TabIndex = 49;
            this._mskEmpresa_16.Tag = "";
            this._mskEmpresa_16.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskEmpresa_KeyPressEvent);
            this._mskEmpresa_16.Enter += new System.EventHandler(this.mskEmpresa_Enter);
            this._mskEmpresa_16.Leave += new System.EventHandler(this.mskEmpresa_Leave);
            this._mskEmpresa_16.Validating += new System.ComponentModel.CancelEventHandler(this.mskEmpresa_Validating);
            // 
            // _tabEmpresa_TabPage3
            // 
            this._tabEmpresa_TabPage3.Controls.Add(this._fraEmpresa_7);
            this._tabEmpresa_TabPage3.Controls.Add(this._fraEmpresa_6);
            this._tabEmpresa_TabPage3.Location = new System.Drawing.Point(4, 43);
            this._tabEmpresa_TabPage3.Name = "_tabEmpresa_TabPage3";
            this._tabEmpresa_TabPage3.Size = new System.Drawing.Size(631, 342);
            this._tabEmpresa_TabPage3.TabIndex = 4;
            this._tabEmpresa_TabPage3.Tag = "";
            this._tabEmpresa_TabPage3.Text = "Teléfonos de la Empresa";
            // 
            // _fraEmpresa_7
            // 
            this._fraEmpresa_7.Controls.Add(this._txtEmpresa_21);
            this._fraEmpresa_7.Controls.Add(this._cmbEmpresa_3);
            this._fraEmpresa_7.Controls.Add(this._cmdEmpresa_5);
            this._fraEmpresa_7.Controls.Add(this._pnlEmpresa_7);
            this._fraEmpresa_7.Controls.Add(this._lblEmpresa_46);
            this._fraEmpresa_7.Controls.Add(this._pnlEmpresa_8);
            this._fraEmpresa_7.Location = new System.Drawing.Point(8, 188);
            this._fraEmpresa_7.Name = "_fraEmpresa_7";
            this._fraEmpresa_7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_fraEmpresa_7.OcxState")));
            this._fraEmpresa_7.Size = new System.Drawing.Size(617, 129);
            this._fraEmpresa_7.TabIndex = 125;
            this._fraEmpresa_7.Tag = "";
            // 
            // _txtEmpresa_21
            // 
            this._txtEmpresa_21.AcceptsReturn = true;
            this._txtEmpresa_21.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_21.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_21.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_21.Location = new System.Drawing.Point(240, 93);
            this._txtEmpresa_21.MaxLength = 15;
            this._txtEmpresa_21.Name = "_txtEmpresa_21";
            this._txtEmpresa_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_21.Size = new System.Drawing.Size(86, 20);
            this._txtEmpresa_21.TabIndex = 46;
            this._txtEmpresa_21.Tag = "";
            this._txtEmpresa_21.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_21.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_21.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_21.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_21.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _cmbEmpresa_3
            // 
            this._cmbEmpresa_3.BackColor = System.Drawing.SystemColors.Window;
            this._cmbEmpresa_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmbEmpresa_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbEmpresa_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._cmbEmpresa_3.Location = new System.Drawing.Point(64, 56);
            this._cmbEmpresa_3.Name = "_cmbEmpresa_3";
            this._cmbEmpresa_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmbEmpresa_3.Size = new System.Drawing.Size(505, 21);
            this._cmbEmpresa_3.TabIndex = 45;
            this._cmbEmpresa_3.Tag = "";
            this._cmbEmpresa_3.SelectedIndexChanged += new System.EventHandler(this.cmbEmpresa_SelectedIndexChanged);
            this._cmbEmpresa_3.Validating += new System.ComponentModel.CancelEventHandler(this.cmbEmpresa_Validating);
            // 
            // _cmdEmpresa_5
            // 
            this._cmdEmpresa_5.BackColor = System.Drawing.SystemColors.Control;
            this._cmdEmpresa_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmdEmpresa_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._cmdEmpresa_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmdEmpresa_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cmdEmpresa_5.Location = new System.Drawing.Point(496, 90);
            this._cmdEmpresa_5.Name = "_cmdEmpresa_5";
            this._cmdEmpresa_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmdEmpresa_5.Size = new System.Drawing.Size(73, 25);
            this._cmdEmpresa_5.TabIndex = 47;
            this._cmdEmpresa_5.Tag = "";
            this._cmdEmpresa_5.Text = "Buscar";
            this._cmdEmpresa_5.UseVisualStyleBackColor = false;
            this._cmdEmpresa_5.Click += new System.EventHandler(this.cmdEmpresa_Click);
            // 
            // _pnlEmpresa_7
            // 
            this._pnlEmpresa_7.Controls.Add(this._pnlEmpresa_7Label_Text);
            this._pnlEmpresa_7.Location = new System.Drawing.Point(64, 32);
            this._pnlEmpresa_7.Name = "_pnlEmpresa_7";
            this._pnlEmpresa_7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlEmpresa_7.OcxState")));
            this._pnlEmpresa_7.Size = new System.Drawing.Size(83, 19);
            this._pnlEmpresa_7.TabIndex = 127;
            this._pnlEmpresa_7.Tag = "";
            // 
            // _pnlEmpresa_7Label_Text
            // 
            this._pnlEmpresa_7Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._pnlEmpresa_7Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._pnlEmpresa_7Label_Text.Location = new System.Drawing.Point(0, 0);
            this._pnlEmpresa_7Label_Text.Name = "_pnlEmpresa_7Label_Text";
            this._pnlEmpresa_7Label_Text.Size = new System.Drawing.Size(81, 17);
            this._pnlEmpresa_7Label_Text.TabIndex = 0;
            this._pnlEmpresa_7Label_Text.Tag = "";
            this._pnlEmpresa_7Label_Text.Text = "Nómina";
            this._pnlEmpresa_7Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _lblEmpresa_46
            // 
            this._lblEmpresa_46.AutoSize = true;
            this._lblEmpresa_46.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_46.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_46.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_46.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_46.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_46.Location = new System.Drawing.Point(112, 96);
            this._lblEmpresa_46.Name = "_lblEmpresa_46";
            this._lblEmpresa_46.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_46.Size = new System.Drawing.Size(114, 13);
            this._lblEmpresa_46.TabIndex = 126;
            this._lblEmpresa_46.Tag = "";
            this._lblEmpresa_46.Text = "Número de Nómina";
            // 
            // _pnlEmpresa_8
            // 
            this._pnlEmpresa_8.Controls.Add(this._pnlEmpresa_8Label_Text);
            this._pnlEmpresa_8.Location = new System.Drawing.Point(152, 32);
            this._pnlEmpresa_8.Name = "_pnlEmpresa_8";
            this._pnlEmpresa_8.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlEmpresa_8.OcxState")));
            this._pnlEmpresa_8.Size = new System.Drawing.Size(419, 19);
            this._pnlEmpresa_8.TabIndex = 128;
            this._pnlEmpresa_8.Tag = "";
            // 
            // _pnlEmpresa_8Label_Text
            // 
            this._pnlEmpresa_8Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._pnlEmpresa_8Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._pnlEmpresa_8Label_Text.Location = new System.Drawing.Point(0, 0);
            this._pnlEmpresa_8Label_Text.Name = "_pnlEmpresa_8Label_Text";
            this._pnlEmpresa_8Label_Text.Size = new System.Drawing.Size(417, 17);
            this._pnlEmpresa_8Label_Text.TabIndex = 0;
            this._pnlEmpresa_8Label_Text.Tag = "";
            this._pnlEmpresa_8Label_Text.Text = "Nombre";
            this._pnlEmpresa_8Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _fraEmpresa_6
            // 
            this._fraEmpresa_6.Controls.Add(this._lblEmpresa_39);
            this._fraEmpresa_6.Controls.Add(this._lblEmpresa_38);
            this._fraEmpresa_6.Controls.Add(this._txtEmpresa_14);
            this._fraEmpresa_6.Controls.Add(this._txtEmpresa_16);
            this._fraEmpresa_6.Controls.Add(this._txtEmpresa_15);
            this._fraEmpresa_6.Controls.Add(this._lblEmpresa_34);
            this._fraEmpresa_6.Controls.Add(this._lblEmpresa_33);
            this._fraEmpresa_6.Controls.Add(this._lblEmpresa_35);
            this._fraEmpresa_6.Controls.Add(this._lblEmpresa_37);
            this._fraEmpresa_6.Controls.Add(this._lblEmpresa_36);
            this._fraEmpresa_6.Controls.Add(this._txtEmpresa_19);
            this._fraEmpresa_6.Controls.Add(this._txtEmpresa_20);
            this._fraEmpresa_6.Controls.Add(this._txtEmpresa_17);
            this._fraEmpresa_6.Controls.Add(this._txtEmpresa_18);
            this._fraEmpresa_6.Location = new System.Drawing.Point(8, 28);
            this._fraEmpresa_6.Name = "_fraEmpresa_6";
            this._fraEmpresa_6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_fraEmpresa_6.OcxState")));
            this._fraEmpresa_6.Size = new System.Drawing.Size(617, 129);
            this._fraEmpresa_6.TabIndex = 117;
            this._fraEmpresa_6.Tag = "";
            // 
            // _lblEmpresa_39
            // 
            this._lblEmpresa_39.AutoSize = true;
            this._lblEmpresa_39.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_39.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_39.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_39.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_39.Location = new System.Drawing.Point(456, 24);
            this._lblEmpresa_39.Name = "_lblEmpresa_39";
            this._lblEmpresa_39.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_39.Size = new System.Drawing.Size(35, 13);
            this._lblEmpresa_39.TabIndex = 124;
            this._lblEmpresa_39.Tag = "";
            this._lblEmpresa_39.Text = "Lada";
            // 
            // _lblEmpresa_38
            // 
            this._lblEmpresa_38.AutoSize = true;
            this._lblEmpresa_38.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_38.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_38.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_38.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_38.Location = new System.Drawing.Point(264, 48);
            this._lblEmpresa_38.Name = "_lblEmpresa_38";
            this._lblEmpresa_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_38.Size = new System.Drawing.Size(59, 13);
            this._lblEmpresa_38.TabIndex = 123;
            this._lblEmpresa_38.Tag = "";
            this._lblEmpresa_38.Text = "Fax Lada";
            // 
            // _txtEmpresa_14
            // 
            this._txtEmpresa_14.AcceptsReturn = true;
            this._txtEmpresa_14.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_14.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_14.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_14.Location = new System.Drawing.Point(88, 21);
            this._txtEmpresa_14.MaxLength = 10;
            this._txtEmpresa_14.Name = "_txtEmpresa_14";
            this._txtEmpresa_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_14.Size = new System.Drawing.Size(134, 20);
            this._txtEmpresa_14.TabIndex = 38;
            this._txtEmpresa_14.Tag = "";
            this._txtEmpresa_14.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_14.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_14.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_14.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_14.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _txtEmpresa_16
            // 
            this._txtEmpresa_16.AcceptsReturn = true;
            this._txtEmpresa_16.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_16.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_16.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_16.Location = new System.Drawing.Point(496, 21);
            this._txtEmpresa_16.MaxLength = 9;
            this._txtEmpresa_16.Name = "_txtEmpresa_16";
            this._txtEmpresa_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_16.Size = new System.Drawing.Size(86, 20);
            this._txtEmpresa_16.TabIndex = 40;
            this._txtEmpresa_16.Tag = "";
            this._txtEmpresa_16.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_16.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_16.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_16.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_16.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _txtEmpresa_15
            // 
            this._txtEmpresa_15.AcceptsReturn = true;
            this._txtEmpresa_15.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_15.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_15.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_15.Location = new System.Drawing.Point(328, 21);
            this._txtEmpresa_15.MaxLength = 5;
            this._txtEmpresa_15.Name = "_txtEmpresa_15";
            this._txtEmpresa_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_15.Size = new System.Drawing.Size(94, 20);
            this._txtEmpresa_15.TabIndex = 39;
            this._txtEmpresa_15.Tag = "";
            this._txtEmpresa_15.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_15.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_15.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_15.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_15.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _lblEmpresa_34
            // 
            this._lblEmpresa_34.AutoSize = true;
            this._lblEmpresa_34.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_34.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_34.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_34.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_34.Location = new System.Drawing.Point(32, 48);
            this._lblEmpresa_34.Name = "_lblEmpresa_34";
            this._lblEmpresa_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_34.Size = new System.Drawing.Size(27, 13);
            this._lblEmpresa_34.TabIndex = 119;
            this._lblEmpresa_34.Tag = "";
            this._lblEmpresa_34.Text = "Fax";
            // 
            // _lblEmpresa_33
            // 
            this._lblEmpresa_33.AutoSize = true;
            this._lblEmpresa_33.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_33.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_33.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_33.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_33.Location = new System.Drawing.Point(32, 24);
            this._lblEmpresa_33.Name = "_lblEmpresa_33";
            this._lblEmpresa_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_33.Size = new System.Drawing.Size(57, 13);
            this._lblEmpresa_33.TabIndex = 118;
            this._lblEmpresa_33.Tag = "";
            this._lblEmpresa_33.Text = "Teléfono";
            // 
            // _lblEmpresa_35
            // 
            this._lblEmpresa_35.AutoSize = true;
            this._lblEmpresa_35.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_35.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_35.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_35.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_35.Location = new System.Drawing.Point(32, 72);
            this._lblEmpresa_35.Name = "_lblEmpresa_35";
            this._lblEmpresa_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_35.Size = new System.Drawing.Size(37, 13);
            this._lblEmpresa_35.TabIndex = 120;
            this._lblEmpresa_35.Tag = "";
            this._lblEmpresa_35.Text = "Email";
            // 
            // _lblEmpresa_37
            // 
            this._lblEmpresa_37.AutoSize = true;
            this._lblEmpresa_37.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_37.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_37.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_37.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_37.Location = new System.Drawing.Point(264, 24);
            this._lblEmpresa_37.Name = "_lblEmpresa_37";
            this._lblEmpresa_37.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_37.Size = new System.Drawing.Size(62, 13);
            this._lblEmpresa_37.TabIndex = 122;
            this._lblEmpresa_37.Tag = "";
            this._lblEmpresa_37.Text = "Extension";
            // 
            // _lblEmpresa_36
            // 
            this._lblEmpresa_36.AutoSize = true;
            this._lblEmpresa_36.BackColor = System.Drawing.SystemColors.Control;
            this._lblEmpresa_36.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEmpresa_36.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEmpresa_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEmpresa_36.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEmpresa_36.Location = new System.Drawing.Point(32, 96);
            this._lblEmpresa_36.Name = "_lblEmpresa_36";
            this._lblEmpresa_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEmpresa_36.Size = new System.Drawing.Size(51, 13);
            this._lblEmpresa_36.TabIndex = 121;
            this._lblEmpresa_36.Tag = "";
            this._lblEmpresa_36.Text = "Internet";
            // 
            // _txtEmpresa_19
            // 
            this._txtEmpresa_19.AcceptsReturn = true;
            this._txtEmpresa_19.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_19.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_19.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_19.Location = new System.Drawing.Point(88, 69);
            this._txtEmpresa_19.MaxLength = 70;
            this._txtEmpresa_19.Name = "_txtEmpresa_19";
            this._txtEmpresa_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_19.Size = new System.Drawing.Size(494, 20);
            this._txtEmpresa_19.TabIndex = 43;
            this._txtEmpresa_19.Tag = "";
            this._txtEmpresa_19.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_19.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_19.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_19.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_19.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _txtEmpresa_20
            // 
            this._txtEmpresa_20.AcceptsReturn = true;
            this._txtEmpresa_20.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_20.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_20.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_20.Location = new System.Drawing.Point(88, 93);
            this._txtEmpresa_20.MaxLength = 70;
            this._txtEmpresa_20.Name = "_txtEmpresa_20";
            this._txtEmpresa_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_20.Size = new System.Drawing.Size(494, 20);
            this._txtEmpresa_20.TabIndex = 44;
            this._txtEmpresa_20.Tag = "";
            this._txtEmpresa_20.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_20.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_20.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_20.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_20.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _txtEmpresa_17
            // 
            this._txtEmpresa_17.AcceptsReturn = true;
            this._txtEmpresa_17.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_17.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_17.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_17.Location = new System.Drawing.Point(88, 45);
            this._txtEmpresa_17.MaxLength = 10;
            this._txtEmpresa_17.Name = "_txtEmpresa_17";
            this._txtEmpresa_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_17.Size = new System.Drawing.Size(134, 20);
            this._txtEmpresa_17.TabIndex = 41;
            this._txtEmpresa_17.Tag = "";
            this._txtEmpresa_17.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_17.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_17.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_17.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_17.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // _txtEmpresa_18
            // 
            this._txtEmpresa_18.AcceptsReturn = true;
            this._txtEmpresa_18.BackColor = System.Drawing.SystemColors.Window;
            this._txtEmpresa_18.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtEmpresa_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtEmpresa_18.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtEmpresa_18.Location = new System.Drawing.Point(328, 45);
            this._txtEmpresa_18.MaxLength = 9;
            this._txtEmpresa_18.Name = "_txtEmpresa_18";
            this._txtEmpresa_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtEmpresa_18.Size = new System.Drawing.Size(94, 20);
            this._txtEmpresa_18.TabIndex = 42;
            this._txtEmpresa_18.Tag = "";
            this._txtEmpresa_18.TextChanged += new System.EventHandler(this.txtEmpresa_TextChanged);
            this._txtEmpresa_18.Enter += new System.EventHandler(this.txtEmpresa_Enter);
            this._txtEmpresa_18.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEmpresa_KeyPress);
            this._txtEmpresa_18.Leave += new System.EventHandler(this.txtEmpresa_Leave);
            this._txtEmpresa_18.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmpresa_Validating);
            // 
            // frmEmpresa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(635, 430);
            this.Controls.Add(this._cmdEmpresa_2);
            this.Controls.Add(this.tabEmpresa);
            this.Controls.Add(this._cmdEmpresa_0);
            this.Controls.Add(this._cmdEmpresa_1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(77, 170);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmEmpresa";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Empresa";
            this.Activated += new System.EventHandler(this.frmEmpresa_Activated);
            this.Closed += new System.EventHandler(this.frmEmpresa_Closed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.frmEmpresa_KeyPress);
            this.tabEmpresa.ResumeLayout(false);
            this._tabEmpresa_TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_4)).EndInit();
            this._fraEmpresa_4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_5)).EndInit();
            this._fraEmpresa_5.ResumeLayout(false);
            this._fraEmpresa_5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_14)).EndInit();
            this._tabEmpresa_TabPage0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_0)).EndInit();
            this._fraEmpresa_0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_3)).EndInit();
            this._pnlEmpresa_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_5)).EndInit();
            this._pnlEmpresa_5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_0)).EndInit();
            this._pnlEmpresa_0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_1)).EndInit();
            this._fraEmpresa_1.ResumeLayout(false);
            this._fraEmpresa_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_4)).EndInit();
            this._tabEmpresa_TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_3)).EndInit();
            this._fraEmpresa_3.ResumeLayout(false);
            this._fraEmpresa_3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_2)).EndInit();
            this._fraEmpresa_2.ResumeLayout(false);
            this._fraEmpresa_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_11)).EndInit();
            this._tabEmpresa_TabPage4.ResumeLayout(false);
            this._tabEmpresa_TabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_9)).EndInit();
            this._fraEmpresa_9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_10)).EndInit();
            this._fraEmpresa_10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_11)).EndInit();
            this._fraEmpresa_11.ResumeLayout(false);
            this._fraEmpresa_11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_8)).EndInit();
            this._fraEmpresa_8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_12)).EndInit();
            this._fraEmpresa_12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_13)).EndInit();
            this._fraEmpresa_13.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._mskEmpresa_16)).EndInit();
            this._tabEmpresa_TabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_7)).EndInit();
            this._fraEmpresa_7.ResumeLayout(false);
            this._fraEmpresa_7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_7)).EndInit();
            this._pnlEmpresa_7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pnlEmpresa_8)).EndInit();
            this._pnlEmpresa_8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._fraEmpresa_6)).EndInit();
            this._fraEmpresa_6.ResumeLayout(false);
            this._fraEmpresa_6.PerformLayout();
            this.ResumeLayout(false);

	}
	void  InitializecmdEmpresa()
	{
			this.cmdEmpresa[2] = _cmdEmpresa_2;
			this.cmdEmpresa[1] = _cmdEmpresa_1;
			this.cmdEmpresa[0] = _cmdEmpresa_0;
			this.cmdEmpresa[4] = _cmdEmpresa_4;
			this.cmdEmpresa[3] = _cmdEmpresa_3;
			this.cmdEmpresa[5] = _cmdEmpresa_5;
	}
	void  InitializechkEmpresa()
	{
			this.chkEmpresa[0] = _chkEmpresa_0;
			this.chkEmpresa[3] = _chkEmpresa_3;
			this.chkEmpresa[2] = _chkEmpresa_2;
			this.chkEmpresa[1] = _chkEmpresa_1;
	}
	void  InitializeoptEmpresa()
	{
			this.optEmpresa[2] = _optEmpresa_2;
			this.optEmpresa[1] = _optEmpresa_1;
			this.optEmpresa[0] = _optEmpresa_0;
			this.optEmpresa[4] = _optEmpresa_4;
			this.optEmpresa[3] = _optEmpresa_3;
			this.optEmpresa[6] = _optEmpresa_6;
			this.optEmpresa[5] = _optEmpresa_5;
			this.optEmpresa[9] = _optEmpresa_9;
			this.optEmpresa[7] = _optEmpresa_7;
			this.optEmpresa[8] = _optEmpresa_8;
			this.optEmpresa[11] = _optEmpresa_11;
			this.optEmpresa[10] = _optEmpresa_10;
			this.optEmpresa[12] = _optEmpresa_12;
	}
	void  InitializelblEmpresa()
	{
			this.lblEmpresa[15] = _lblEmpresa_15;
			this.lblEmpresa[14] = _lblEmpresa_14;
			this.lblEmpresa[13] = _lblEmpresa_13;
			this.lblEmpresa[12] = _lblEmpresa_12;
			this.lblEmpresa[11] = _lblEmpresa_11;
			this.lblEmpresa[10] = _lblEmpresa_10;
			this.lblEmpresa[9] = _lblEmpresa_9;
			this.lblEmpresa[8] = _lblEmpresa_8;
			this.lblEmpresa[7] = _lblEmpresa_7;
			this.lblEmpresa[6] = _lblEmpresa_6;
			this.lblEmpresa[5] = _lblEmpresa_5;
			this.lblEmpresa[4] = _lblEmpresa_4;
			this.lblEmpresa[3] = _lblEmpresa_3;
			this.lblEmpresa[2] = _lblEmpresa_2;
			this.lblEmpresa[1] = _lblEmpresa_1;
			this.lblEmpresa[0] = _lblEmpresa_0;
			this.lblEmpresa[31] = _lblEmpresa_31;
			this.lblEmpresa[30] = _lblEmpresa_30;
			this.lblEmpresa[29] = _lblEmpresa_29;
			this.lblEmpresa[28] = _lblEmpresa_28;
			this.lblEmpresa[27] = _lblEmpresa_27;
			this.lblEmpresa[26] = _lblEmpresa_26;
			this.lblEmpresa[21] = _lblEmpresa_21;
			this.lblEmpresa[20] = _lblEmpresa_20;
			this.lblEmpresa[19] = _lblEmpresa_19;
			this.lblEmpresa[18] = _lblEmpresa_18;
			this.lblEmpresa[17] = _lblEmpresa_17;
			this.lblEmpresa[16] = _lblEmpresa_16;
			this.lblEmpresa[32] = _lblEmpresa_32;
			this.lblEmpresa[25] = _lblEmpresa_25;
			this.lblEmpresa[24] = _lblEmpresa_24;
			this.lblEmpresa[23] = _lblEmpresa_23;
			this.lblEmpresa[22] = _lblEmpresa_22;
			this.lblEmpresa[39] = _lblEmpresa_39;
			this.lblEmpresa[38] = _lblEmpresa_38;
			this.lblEmpresa[37] = _lblEmpresa_37;
			this.lblEmpresa[36] = _lblEmpresa_36;
			this.lblEmpresa[35] = _lblEmpresa_35;
			this.lblEmpresa[34] = _lblEmpresa_34;
			this.lblEmpresa[33] = _lblEmpresa_33;
			this.lblEmpresa[46] = _lblEmpresa_46;
			this.lblEmpresa[44] = _lblEmpresa_44;
			this.lblEmpresa[43] = _lblEmpresa_43;
			this.lblEmpresa[42] = _lblEmpresa_42;
			this.lblEmpresa[41] = _lblEmpresa_41;
			this.lblEmpresa[40] = _lblEmpresa_40;
	}
	void  InitializepnlEmpresa()
	{
			this.pnlEmpresa[0] = _pnlEmpresa_0;
			this.pnlEmpresa[1] = _pnlEmpresa_1;
			this.pnlEmpresa[2] = _pnlEmpresa_2;
			this.pnlEmpresa[3] = _pnlEmpresa_3;
			this.pnlEmpresa[4] = _pnlEmpresa_4;
			this.pnlEmpresa[5] = _pnlEmpresa_5;
			this.pnlEmpresa[6] = _pnlEmpresa_6;
			this.pnlEmpresa[7] = _pnlEmpresa_7;
			this.pnlEmpresa[8] = _pnlEmpresa_8;
	}
	void  InitializefraEmpresa()
	{
			this.fraEmpresa[0] = _fraEmpresa_0;
			this.fraEmpresa[1] = _fraEmpresa_1;
			this.fraEmpresa[2] = _fraEmpresa_2;
			this.fraEmpresa[3] = _fraEmpresa_3;
			this.fraEmpresa[5] = _fraEmpresa_5;
			this.fraEmpresa[4] = _fraEmpresa_4;
			this.fraEmpresa[6] = _fraEmpresa_6;
			this.fraEmpresa[7] = _fraEmpresa_7;
			this.fraEmpresa[8] = _fraEmpresa_8;
			this.fraEmpresa[9] = _fraEmpresa_9;
			this.fraEmpresa[10] = _fraEmpresa_10;
			this.fraEmpresa[11] = _fraEmpresa_11;
			this.fraEmpresa[12] = _fraEmpresa_12;
			this.fraEmpresa[13] = _fraEmpresa_13;
	}
	void  InitializemskEmpresa()
	{
			this.mskEmpresa[0] = _mskEmpresa_0;
			this.mskEmpresa[1] = _mskEmpresa_1;
			this.mskEmpresa[2] = _mskEmpresa_2;
			this.mskEmpresa[3] = _mskEmpresa_3;
			this.mskEmpresa[4] = _mskEmpresa_4;
			this.mskEmpresa[5] = _mskEmpresa_5;
			this.mskEmpresa[6] = _mskEmpresa_6;
			this.mskEmpresa[7] = _mskEmpresa_7;
			this.mskEmpresa[8] = _mskEmpresa_8;
			this.mskEmpresa[9] = _mskEmpresa_9;
			this.mskEmpresa[10] = _mskEmpresa_10;
			this.mskEmpresa[11] = _mskEmpresa_11;
			this.mskEmpresa[12] = _mskEmpresa_12;
			this.mskEmpresa[13] = _mskEmpresa_13;
			this.mskEmpresa[14] = _mskEmpresa_14;
			this.mskEmpresa[15] = _mskEmpresa_15;
			this.mskEmpresa[17] = _mskEmpresa_17;
			this.mskEmpresa[18] = _mskEmpresa_18;
			this.mskEmpresa[16] = _mskEmpresa_16;
	}
	void  InitializecmbEmpresa()
	{
			this.cmbEmpresa[5] = _cmbEmpresa_5;
			this.cmbEmpresa[4] = _cmbEmpresa_4;
			this.cmbEmpresa[0] = _cmbEmpresa_0;
			this.cmbEmpresa[1] = _cmbEmpresa_1;
			this.cmbEmpresa[2] = _cmbEmpresa_2;
			this.cmbEmpresa[3] = _cmbEmpresa_3;
	}
	void  InitializetxtEmpresa()
	{
			this.txtEmpresa[3] = _txtEmpresa_3;
			this.txtEmpresa[2] = _txtEmpresa_2;
			this.txtEmpresa[1] = _txtEmpresa_1;
			this.txtEmpresa[0] = _txtEmpresa_0;
			this.txtEmpresa[7] = _txtEmpresa_7;
			this.txtEmpresa[6] = _txtEmpresa_6;
			this.txtEmpresa[5] = _txtEmpresa_5;
			this.txtEmpresa[4] = _txtEmpresa_4;
			this.txtEmpresa[11] = _txtEmpresa_11;
			this.txtEmpresa[10] = _txtEmpresa_10;
			this.txtEmpresa[9] = _txtEmpresa_9;
			this.txtEmpresa[8] = _txtEmpresa_8;
			this.txtEmpresa[13] = _txtEmpresa_13;
			this.txtEmpresa[12] = _txtEmpresa_12;
			this.txtEmpresa[20] = _txtEmpresa_20;
			this.txtEmpresa[19] = _txtEmpresa_19;
			this.txtEmpresa[18] = _txtEmpresa_18;
			this.txtEmpresa[17] = _txtEmpresa_17;
			this.txtEmpresa[16] = _txtEmpresa_16;
			this.txtEmpresa[15] = _txtEmpresa_15;
			this.txtEmpresa[14] = _txtEmpresa_14;
			this.txtEmpresa[21] = _txtEmpresa_21;
	}
#endregion 
}
}