using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORMNUNI
	{
	
#region "Upgrade Support "
		private static CORMNUNI m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORMNUNI DefInstance
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
		public CORMNUNI():base(){
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
			InitializetxtTexto_Cat();
			InitializefrmFrame();
			InitializetxtTexto();
			InitializeLST_REPO();
			InitializeFRAM_REP();
			InitializecmbCombo();
			InitializetxtTexto_Rep();
			InitializemkbMaskebox_Rep();
			InitializemkbMaskebox_Cat();
			InitializemkbMaskebox();
			InitializePAN_REP();
			InitializetabStab();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORMNUNI CreateInstance()
	{
			CORMNUNI theInstance = new CORMNUNI();
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
	public  System.Windows.Forms.Button ID_MEE_CER_PB;
	public  System.Windows.Forms.Button ID_MEE_ALT_PB;
	public  System.Windows.Forms.Button ID_MEE_IMP_PB;
	private  System.Windows.Forms.TextBox _txtTexto_3;
	private  System.Windows.Forms.TextBox _txtTexto_2;
	private  System.Windows.Forms.ComboBox _cmbCombo_0;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_0;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_1;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_2;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_3;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_4;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_5;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_6;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_7;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_8;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_9;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_10;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_11;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_12;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_13;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_15;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_16;
	private  System.Windows.Forms.Label _lblEtiqueta_20;
	private  System.Windows.Forms.Label _lblEtiqueta_19;
	private  System.Windows.Forms.Label _lblEtiqueta_18;
	private  System.Windows.Forms.Label _lblEtiqueta_17;
	private  System.Windows.Forms.Label _lblEtiqueta_16;
	private  System.Windows.Forms.Label _lblEtiqueta_15;
	private  System.Windows.Forms.Label _lblEtiqueta_14;
	private  System.Windows.Forms.Label _lblEtiqueta_13;
	private  System.Windows.Forms.Label _lblEtiqueta_12;
	private  System.Windows.Forms.Label _lblEtiqueta_11;
	private  System.Windows.Forms.Label _lblEtiqueta_10;
	private  System.Windows.Forms.Label _lblEtiqueta_9;
	private  System.Windows.Forms.Label _lblEtiqueta_8;
	private  System.Windows.Forms.Label _lblEtiqueta_7;
	private  System.Windows.Forms.Label _lblEtiqueta_6;
	private  System.Windows.Forms.Label _lblEtiqueta_5;
	private  System.Windows.Forms.Label _lblEtiqueta_3;
	private  System.Windows.Forms.Label _lblEtiqueta_2;
	private  System.Windows.Forms.Label _lblEtiqueta_4;
	private  AxThreed.AxSSFrame _frmFrame_1;
	private  System.Windows.Forms.TextBox _txtTexto_1;
	private  System.Windows.Forms.TextBox _txtTexto_0;
	private  System.Windows.Forms.Label _lblEtiqueta_0;
	private  System.Windows.Forms.Label _lblEtiqueta_1;
	private  AxThreed.AxSSFrame _frmFrame_0;
	private  System.Windows.Forms.TabPage __tabStab_0_TabPage0;
	private  System.Windows.Forms.Label _PAN_REP_8Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_8;
	private  System.Windows.Forms.Label _PAN_REP_4Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_4;
	private  System.Windows.Forms.Label _PAN_REP_3Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_3;
	private  System.Windows.Forms.Label _PAN_REP_2Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_2;
	private  System.Windows.Forms.Label _PAN_REP_1Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_1;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Rep_0;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Rep_1;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Rep_2;
	private  System.Windows.Forms.Label _lblEtiqueta_22;
	private  System.Windows.Forms.Label _lblEtiqueta_40;
	private  System.Windows.Forms.Label _lblEtiqueta_38;
	private  AxThreed.AxSSFrame _frmFrame_3;
	private  System.Windows.Forms.TextBox _txtTexto_Rep_0;
	private  System.Windows.Forms.TextBox _txtTexto_Rep_1;
	private  System.Windows.Forms.Label _lblEtiqueta_27;
	private  System.Windows.Forms.Label _lblEtiqueta_21;
	private  AxThreed.AxSSFrame _frmFrame_2;
	private  System.Windows.Forms.Label _PAN_REP_0Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_0;
	private  System.Windows.Forms.ListBox _LST_REPO_0;
	public  System.Windows.Forms.Button CMD_ACT_REP;
	public  System.Windows.Forms.CheckBox CHK_REP;
	private  System.Windows.Forms.ComboBox _CMB_REPO_0;
	private  System.Windows.Forms.ComboBox _CMB_REPO_3;
	private  System.Windows.Forms.ComboBox _CMB_REPO_2;
	private  System.Windows.Forms.ComboBox _CMB_REPO_1;
	private  System.Windows.Forms.Label _lblEtiqueta_34;
	private  System.Windows.Forms.Label _lblEtiqueta_23;
	private  System.Windows.Forms.Label _lblEtiqueta_26;
	private  System.Windows.Forms.Label _lblEtiqueta_25;
	private  System.Windows.Forms.Label _lblEtiqueta_24;
	private  AxThreed.AxSSFrame _FRAM_REP_0;
	private  System.Windows.Forms.TabPage __tabStab_0_TabPage1;
	public  System.Windows.Forms.ListBox LST_CAT;
	private  System.Windows.Forms.TextBox _txtTexto_Cat_1;
	private  System.Windows.Forms.TextBox _txtTexto_Cat_0;
	private  System.Windows.Forms.Label _lblEtiqueta_29;
	private  System.Windows.Forms.Label _lblEtiqueta_28;
	private  AxThreed.AxSSFrame _frmFrame_4;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Cat_0;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Cat_1;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Cat_2;
	private  System.Windows.Forms.Label _lblEtiqueta_32;
	private  System.Windows.Forms.Label _lblEtiqueta_31;
	private  System.Windows.Forms.Label _lblEtiqueta_30;
	private  AxThreed.AxSSFrame _frmFrame_5;
	public  System.Windows.Forms.Button CMD_ACT_CAT;
	public  System.Windows.Forms.ComboBox CMB_CAT;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Cat_3;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Cat_4;
	private  System.Windows.Forms.Label _lblEtiqueta_36;
	private  System.Windows.Forms.Label _lblEtiqueta_35;
	private  System.Windows.Forms.Label _lblEtiqueta_33;
	public  AxThreed.AxSSFrame FRAM_CAT;
	private  System.Windows.Forms.Label _PAN_REP_5Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_5;
	private  System.Windows.Forms.Label _PAN_REP_6Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_6;
	private  System.Windows.Forms.Label _PAN_REP_7Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_7;
	private  System.Windows.Forms.Label _PAN_REP_9Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_9;
	private  System.Windows.Forms.TabPage __tabStab_0_TabPage2;
	private  System.Windows.Forms.TabControl _tabStab_0;
	public System.Windows.Forms.ComboBox[] CMB_REPO = new System.Windows.Forms.ComboBox[4];
	public AxThreed.AxSSFrame[] FRAM_REP = new AxThreed.AxSSFrame[1];
	public System.Windows.Forms.ListBox[] LST_REPO = new System.Windows.Forms.ListBox[1];
	public AxThreed.AxSSPanel[] PAN_REP = new AxThreed.AxSSPanel[10];
	public System.Windows.Forms.ComboBox[] cmbCombo = new System.Windows.Forms.ComboBox[1];
	public AxThreed.AxSSFrame[] frmFrame = new AxThreed.AxSSFrame[6];
	public System.Windows.Forms.Label[] lblEtiqueta = new System.Windows.Forms.Label[41];
	public AxMSMask.AxMaskEdBox[] mkbMaskebox = new AxMSMask.AxMaskEdBox[17];
	public AxMSMask.AxMaskEdBox[] mkbMaskebox_Cat = new AxMSMask.AxMaskEdBox[5];
	public AxMSMask.AxMaskEdBox[] mkbMaskebox_Rep = new AxMSMask.AxMaskEdBox[3];
	public System.Windows.Forms.TabControl[] tabStab = new System.Windows.Forms.TabControl[1];
	public System.Windows.Forms.TextBox[] txtTexto = new System.Windows.Forms.TextBox[4];
	public System.Windows.Forms.TextBox[] txtTexto_Cat = new System.Windows.Forms.TextBox[2];
	public System.Windows.Forms.TextBox[] txtTexto_Rep = new System.Windows.Forms.TextBox[2];
	private Artinsoft.VB6.Gui.ListControlHelper ListBoxComboBoxHelper1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORMNUNI));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_MEE_CER_PB = new System.Windows.Forms.Button();
            this.ID_MEE_ALT_PB = new System.Windows.Forms.Button();
            this.ID_MEE_IMP_PB = new System.Windows.Forms.Button();
            this._tabStab_0 = new System.Windows.Forms.TabControl();
            this.@__tabStab_0_TabPage0 = new System.Windows.Forms.TabPage();
            this._frmFrame_1 = new AxThreed.AxSSFrame();
            this._lblEtiqueta_16 = new System.Windows.Forms.Label();
            this._lblEtiqueta_17 = new System.Windows.Forms.Label();
            this._lblEtiqueta_15 = new System.Windows.Forms.Label();
            this._lblEtiqueta_13 = new System.Windows.Forms.Label();
            this._lblEtiqueta_14 = new System.Windows.Forms.Label();
            this._lblEtiqueta_18 = new System.Windows.Forms.Label();
            this._mkbMaskebox_15 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_13 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_16 = new AxMSMask.AxMaskEdBox();
            this._lblEtiqueta_19 = new System.Windows.Forms.Label();
            this._lblEtiqueta_20 = new System.Windows.Forms.Label();
            this._lblEtiqueta_5 = new System.Windows.Forms.Label();
            this._lblEtiqueta_6 = new System.Windows.Forms.Label();
            this._lblEtiqueta_3 = new System.Windows.Forms.Label();
            this._lblEtiqueta_4 = new System.Windows.Forms.Label();
            this._lblEtiqueta_2 = new System.Windows.Forms.Label();
            this._lblEtiqueta_7 = new System.Windows.Forms.Label();
            this._lblEtiqueta_11 = new System.Windows.Forms.Label();
            this._lblEtiqueta_12 = new System.Windows.Forms.Label();
            this._lblEtiqueta_10 = new System.Windows.Forms.Label();
            this._lblEtiqueta_8 = new System.Windows.Forms.Label();
            this._lblEtiqueta_9 = new System.Windows.Forms.Label();
            this._mkbMaskebox_2 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_1 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_4 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_3 = new AxMSMask.AxMaskEdBox();
            this._txtTexto_2 = new System.Windows.Forms.TextBox();
            this._txtTexto_3 = new System.Windows.Forms.TextBox();
            this._mkbMaskebox_0 = new AxMSMask.AxMaskEdBox();
            this._cmbCombo_0 = new System.Windows.Forms.ComboBox();
            this._mkbMaskebox_10 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_9 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_12 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_11 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_6 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_5 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_8 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_7 = new AxMSMask.AxMaskEdBox();
            this._frmFrame_0 = new AxThreed.AxSSFrame();
            this._txtTexto_0 = new System.Windows.Forms.TextBox();
            this._txtTexto_1 = new System.Windows.Forms.TextBox();
            this._lblEtiqueta_1 = new System.Windows.Forms.Label();
            this._lblEtiqueta_0 = new System.Windows.Forms.Label();
            this.@__tabStab_0_TabPage2 = new System.Windows.Forms.TabPage();
            this._PAN_REP_5 = new AxThreed.AxSSPanel();
            this._PAN_REP_5Label_Text = new System.Windows.Forms.Label();
            this.FRAM_CAT = new AxThreed.AxSSFrame();
            this._mkbMaskebox_Cat_4 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_Cat_3 = new AxMSMask.AxMaskEdBox();
            this.CMB_CAT = new System.Windows.Forms.ComboBox();
            this._lblEtiqueta_33 = new System.Windows.Forms.Label();
            this._lblEtiqueta_35 = new System.Windows.Forms.Label();
            this._lblEtiqueta_36 = new System.Windows.Forms.Label();
            this.CMD_ACT_CAT = new System.Windows.Forms.Button();
            this._PAN_REP_6 = new AxThreed.AxSSPanel();
            this._PAN_REP_6Label_Text = new System.Windows.Forms.Label();
            this._PAN_REP_9 = new AxThreed.AxSSPanel();
            this._PAN_REP_9Label_Text = new System.Windows.Forms.Label();
            this._PAN_REP_7 = new AxThreed.AxSSPanel();
            this._PAN_REP_7Label_Text = new System.Windows.Forms.Label();
            this.LST_CAT = new System.Windows.Forms.ListBox();
            this._frmFrame_4 = new AxThreed.AxSSFrame();
            this._txtTexto_Cat_0 = new System.Windows.Forms.TextBox();
            this._txtTexto_Cat_1 = new System.Windows.Forms.TextBox();
            this._lblEtiqueta_28 = new System.Windows.Forms.Label();
            this._lblEtiqueta_29 = new System.Windows.Forms.Label();
            this._frmFrame_5 = new AxThreed.AxSSFrame();
            this._mkbMaskebox_Cat_2 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_Cat_1 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_Cat_0 = new AxMSMask.AxMaskEdBox();
            this._lblEtiqueta_32 = new System.Windows.Forms.Label();
            this._lblEtiqueta_30 = new System.Windows.Forms.Label();
            this._lblEtiqueta_31 = new System.Windows.Forms.Label();
            this.@__tabStab_0_TabPage1 = new System.Windows.Forms.TabPage();
            this._frmFrame_2 = new AxThreed.AxSSFrame();
            this._txtTexto_Rep_1 = new System.Windows.Forms.TextBox();
            this._txtTexto_Rep_0 = new System.Windows.Forms.TextBox();
            this._lblEtiqueta_21 = new System.Windows.Forms.Label();
            this._lblEtiqueta_27 = new System.Windows.Forms.Label();
            this._frmFrame_3 = new AxThreed.AxSSFrame();
            this._mkbMaskebox_Rep_2 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_Rep_1 = new AxMSMask.AxMaskEdBox();
            this._mkbMaskebox_Rep_0 = new AxMSMask.AxMaskEdBox();
            this._lblEtiqueta_22 = new System.Windows.Forms.Label();
            this._lblEtiqueta_38 = new System.Windows.Forms.Label();
            this._lblEtiqueta_40 = new System.Windows.Forms.Label();
            this._PAN_REP_1 = new AxThreed.AxSSPanel();
            this._PAN_REP_1Label_Text = new System.Windows.Forms.Label();
            this._FRAM_REP_0 = new AxThreed.AxSSFrame();
            this._CMB_REPO_1 = new System.Windows.Forms.ComboBox();
            this._lblEtiqueta_34 = new System.Windows.Forms.Label();
            this._CMB_REPO_3 = new System.Windows.Forms.ComboBox();
            this._CMB_REPO_2 = new System.Windows.Forms.ComboBox();
            this._lblEtiqueta_25 = new System.Windows.Forms.Label();
            this._lblEtiqueta_24 = new System.Windows.Forms.Label();
            this._lblEtiqueta_23 = new System.Windows.Forms.Label();
            this._lblEtiqueta_26 = new System.Windows.Forms.Label();
            this._CMB_REPO_0 = new System.Windows.Forms.ComboBox();
            this.CMD_ACT_REP = new System.Windows.Forms.Button();
            this.CHK_REP = new System.Windows.Forms.CheckBox();
            this._LST_REPO_0 = new System.Windows.Forms.ListBox();
            this._PAN_REP_0 = new AxThreed.AxSSPanel();
            this._PAN_REP_0Label_Text = new System.Windows.Forms.Label();
            this._PAN_REP_4 = new AxThreed.AxSSPanel();
            this._PAN_REP_4Label_Text = new System.Windows.Forms.Label();
            this._PAN_REP_8 = new AxThreed.AxSSPanel();
            this._PAN_REP_8Label_Text = new System.Windows.Forms.Label();
            this._PAN_REP_2 = new AxThreed.AxSSPanel();
            this._PAN_REP_2Label_Text = new System.Windows.Forms.Label();
            this._PAN_REP_3 = new AxThreed.AxSSPanel();
            this._PAN_REP_3Label_Text = new System.Windows.Forms.Label();
            this.ListBoxComboBoxHelper1 = new Artinsoft.VB6.Gui.ListControlHelper(this.components);
            this._tabStab_0.SuspendLayout();
            this.@__tabStab_0_TabPage0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._frmFrame_1)).BeginInit();
            this._frmFrame_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._frmFrame_0)).BeginInit();
            this._frmFrame_0.SuspendLayout();
            this.@__tabStab_0_TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_5)).BeginInit();
            this._PAN_REP_5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.FRAM_CAT)).BeginInit();
            this.FRAM_CAT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_6)).BeginInit();
            this._PAN_REP_6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_9)).BeginInit();
            this._PAN_REP_9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_7)).BeginInit();
            this._PAN_REP_7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._frmFrame_4)).BeginInit();
            this._frmFrame_4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._frmFrame_5)).BeginInit();
            this._frmFrame_5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_0)).BeginInit();
            this.@__tabStab_0_TabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._frmFrame_2)).BeginInit();
            this._frmFrame_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._frmFrame_3)).BeginInit();
            this._frmFrame_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Rep_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Rep_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Rep_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_1)).BeginInit();
            this._PAN_REP_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._FRAM_REP_0)).BeginInit();
            this._FRAM_REP_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_0)).BeginInit();
            this._PAN_REP_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_4)).BeginInit();
            this._PAN_REP_4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_8)).BeginInit();
            this._PAN_REP_8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_2)).BeginInit();
            this._PAN_REP_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_3)).BeginInit();
            this._PAN_REP_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_MEE_CER_PB
            // 
            this.ID_MEE_CER_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEE_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEE_CER_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEE_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEE_CER_PB.Location = new System.Drawing.Point(276, 424);
            this.ID_MEE_CER_PB.Name = "ID_MEE_CER_PB";
            this.ID_MEE_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_CER_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEE_CER_PB.TabIndex = 20;
            this.ID_MEE_CER_PB.Tag = "Cancela";
            this.ID_MEE_CER_PB.Text = "Cancelar";
            this.ID_MEE_CER_PB.UseVisualStyleBackColor = false;
            this.ID_MEE_CER_PB.Click += new System.EventHandler(this.ID_MEE_CER_PB_Click);
            // 
            // ID_MEE_ALT_PB
            // 
            this.ID_MEE_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEE_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEE_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEE_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEE_ALT_PB.Location = new System.Drawing.Point(193, 423);
            this.ID_MEE_ALT_PB.Name = "ID_MEE_ALT_PB";
            this.ID_MEE_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_ALT_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEE_ALT_PB.TabIndex = 19;
            this.ID_MEE_ALT_PB.Tag = "";
            this.ID_MEE_ALT_PB.Text = "Aceptar";
            this.ID_MEE_ALT_PB.UseVisualStyleBackColor = false;
            this.ID_MEE_ALT_PB.Click += new System.EventHandler(this.ID_MEE_ALT_PB_Click);
            // 
            // ID_MEE_IMP_PB
            // 
            this.ID_MEE_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEE_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEE_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEE_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEE_IMP_PB.Location = new System.Drawing.Point(361, 424);
            this.ID_MEE_IMP_PB.Name = "ID_MEE_IMP_PB";
            this.ID_MEE_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_IMP_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEE_IMP_PB.TabIndex = 21;
            this.ID_MEE_IMP_PB.Tag = "";
            this.ID_MEE_IMP_PB.Text = "&Imprimir";
            this.ID_MEE_IMP_PB.UseVisualStyleBackColor = false;
            this.ID_MEE_IMP_PB.Visible = false;
            this.ID_MEE_IMP_PB.Click += new System.EventHandler(this.ID_MEE_IMP_PB_Click);
            // 
            // _tabStab_0
            // 
            this._tabStab_0.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this._tabStab_0.Controls.Add(this.@__tabStab_0_TabPage0);
            this._tabStab_0.Controls.Add(this.@__tabStab_0_TabPage2);
            this._tabStab_0.Controls.Add(this.@__tabStab_0_TabPage1);
            this._tabStab_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._tabStab_0.ItemSize = new System.Drawing.Size(192, 18);
            this._tabStab_0.Location = new System.Drawing.Point(23, 7);
            this._tabStab_0.Multiline = true;
            this._tabStab_0.Name = "_tabStab_0";
            this._tabStab_0.SelectedIndex = 0;
            this._tabStab_0.Size = new System.Drawing.Size(583, 411);
            this._tabStab_0.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this._tabStab_0.TabIndex = 23;
            this._tabStab_0.Tag = "";
            // 
            // __tabStab_0_TabPage0
            // 
            this.@__tabStab_0_TabPage0.Controls.Add(this._frmFrame_1);
            this.@__tabStab_0_TabPage0.Controls.Add(this._frmFrame_0);
            this.@__tabStab_0_TabPage0.Location = new System.Drawing.Point(4, 43);
            this.@__tabStab_0_TabPage0.Name = "__tabStab_0_TabPage0";
            this.@__tabStab_0_TabPage0.Size = new System.Drawing.Size(575, 364);
            this.@__tabStab_0_TabPage0.TabIndex = 0;
            this.@__tabStab_0_TabPage0.Tag = "";
            this.@__tabStab_0_TabPage0.Text = "Unidades";
            // 
            // _frmFrame_1
            // 
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_16);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_17);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_15);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_13);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_14);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_18);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_15);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_13);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_16);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_19);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_20);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_5);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_6);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_3);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_4);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_2);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_7);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_11);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_12);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_10);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_8);
            this._frmFrame_1.Controls.Add(this._lblEtiqueta_9);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_2);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_1);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_4);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_3);
            this._frmFrame_1.Controls.Add(this._txtTexto_2);
            this._frmFrame_1.Controls.Add(this._txtTexto_3);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_0);
            this._frmFrame_1.Controls.Add(this._cmbCombo_0);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_10);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_9);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_12);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_11);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_6);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_5);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_8);
            this._frmFrame_1.Controls.Add(this._mkbMaskebox_7);
            this._frmFrame_1.Location = new System.Drawing.Point(16, 54);
            this._frmFrame_1.Name = "_frmFrame_1";
            this._frmFrame_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_frmFrame_1.OcxState")));
            this._frmFrame_1.Size = new System.Drawing.Size(550, 318);
            this._frmFrame_1.TabIndex = 27;
            this._frmFrame_1.Tag = "";
            // 
            // _lblEtiqueta_16
            // 
            this._lblEtiqueta_16.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_16.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_16.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_16.Location = new System.Drawing.Point(296, 236);
            this._lblEtiqueta_16.Name = "_lblEtiqueta_16";
            this._lblEtiqueta_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_16.Size = new System.Drawing.Size(25, 17);
            this._lblEtiqueta_16.TabIndex = 43;
            this._lblEtiqueta_16.Tag = "";
            this._lblEtiqueta_16.Text = "Fax";
            // 
            // _lblEtiqueta_17
            // 
            this._lblEtiqueta_17.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_17.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_17.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_17.Location = new System.Drawing.Point(392, 236);
            this._lblEtiqueta_17.Name = "_lblEtiqueta_17";
            this._lblEtiqueta_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_17.Size = new System.Drawing.Size(33, 17);
            this._lblEtiqueta_17.TabIndex = 44;
            this._lblEtiqueta_17.Tag = "";
            this._lblEtiqueta_17.Text = "Celular";
            // 
            // _lblEtiqueta_15
            // 
            this._lblEtiqueta_15.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_15.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_15.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_15.Location = new System.Drawing.Point(144, 236);
            this._lblEtiqueta_15.Name = "_lblEtiqueta_15";
            this._lblEtiqueta_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_15.Size = new System.Drawing.Size(73, 17);
            this._lblEtiqueta_15.TabIndex = 42;
            this._lblEtiqueta_15.Tag = "";
            this._lblEtiqueta_15.Text = "Extensión";
            // 
            // _lblEtiqueta_13
            // 
            this._lblEtiqueta_13.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_13.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_13.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_13.Location = new System.Drawing.Point(344, 209);
            this._lblEtiqueta_13.Name = "_lblEtiqueta_13";
            this._lblEtiqueta_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_13.Size = new System.Drawing.Size(73, 17);
            this._lblEtiqueta_13.TabIndex = 39;
            this._lblEtiqueta_13.Tag = "";
            this._lblEtiqueta_13.Text = "Codigo Postal";
            // 
            // _lblEtiqueta_14
            // 
            this._lblEtiqueta_14.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_14.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_14.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_14.Location = new System.Drawing.Point(8, 236);
            this._lblEtiqueta_14.Name = "_lblEtiqueta_14";
            this._lblEtiqueta_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_14.Size = new System.Drawing.Size(73, 17);
            this._lblEtiqueta_14.TabIndex = 41;
            this._lblEtiqueta_14.Tag = "";
            this._lblEtiqueta_14.Text = "Telefono";
            // 
            // _lblEtiqueta_18
            // 
            this._lblEtiqueta_18.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_18.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_18.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_18.Location = new System.Drawing.Point(8, 263);
            this._lblEtiqueta_18.Name = "_lblEtiqueta_18";
            this._lblEtiqueta_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_18.Size = new System.Drawing.Size(41, 17);
            this._lblEtiqueta_18.TabIndex = 45;
            this._lblEtiqueta_18.Tag = "";
            this._lblEtiqueta_18.Text = "e-mail";
            // 
            // _mkbMaskebox_15
            // 
            this._mkbMaskebox_15.Location = new System.Drawing.Point(168, 288);
            this._mkbMaskebox_15.Name = "_mkbMaskebox_15";
            this._mkbMaskebox_15.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_15.OcxState")));
            this._mkbMaskebox_15.Size = new System.Drawing.Size(89, 21);
            this._mkbMaskebox_15.TabIndex = 17;
            this._mkbMaskebox_15.Tag = "";
            this._mkbMaskebox_15.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _mkbMaskebox_13
            // 
            this._mkbMaskebox_13.Location = new System.Drawing.Point(432, 234);
            this._mkbMaskebox_13.Name = "_mkbMaskebox_13";
            this._mkbMaskebox_13.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_13.OcxState")));
            this._mkbMaskebox_13.Size = new System.Drawing.Size(89, 21);
            this._mkbMaskebox_13.TabIndex = 15;
            this._mkbMaskebox_13.Tag = "";
            this._mkbMaskebox_13.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _mkbMaskebox_16
            // 
            this._mkbMaskebox_16.Location = new System.Drawing.Point(296, 288);
            this._mkbMaskebox_16.Name = "_mkbMaskebox_16";
            this._mkbMaskebox_16.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_16.OcxState")));
            this._mkbMaskebox_16.Size = new System.Drawing.Size(41, 21);
            this._mkbMaskebox_16.TabIndex = 18;
            this._mkbMaskebox_16.Tag = "";
            this._mkbMaskebox_16.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _lblEtiqueta_19
            // 
            this._lblEtiqueta_19.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_19.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_19.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_19.Location = new System.Drawing.Point(80, 290);
            this._lblEtiqueta_19.Name = "_lblEtiqueta_19";
            this._lblEtiqueta_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_19.Size = new System.Drawing.Size(89, 17);
            this._lblEtiqueta_19.TabIndex = 46;
            this._lblEtiqueta_19.Tag = "";
            this._lblEtiqueta_19.Text = "Copiar de Unidad";
            // 
            // _lblEtiqueta_20
            // 
            this._lblEtiqueta_20.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_20.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_20.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_20.Location = new System.Drawing.Point(264, 290);
            this._lblEtiqueta_20.Name = "_lblEtiqueta_20";
            this._lblEtiqueta_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_20.Size = new System.Drawing.Size(25, 17);
            this._lblEtiqueta_20.TabIndex = 47;
            this._lblEtiqueta_20.Tag = "";
            this._lblEtiqueta_20.Text = "Nivel";
            // 
            // _lblEtiqueta_5
            // 
            this._lblEtiqueta_5.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_5.Location = new System.Drawing.Point(8, 46);
            this._lblEtiqueta_5.Name = "_lblEtiqueta_5";
            this._lblEtiqueta_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_5.Size = new System.Drawing.Size(53, 17);
            this._lblEtiqueta_5.TabIndex = 31;
            this._lblEtiqueta_5.Tag = "";
            this._lblEtiqueta_5.Text = "Nombre";
            // 
            // _lblEtiqueta_6
            // 
            this._lblEtiqueta_6.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_6.Location = new System.Drawing.Point(8, 72);
            this._lblEtiqueta_6.Name = "_lblEtiqueta_6";
            this._lblEtiqueta_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_6.Size = new System.Drawing.Size(69, 19);
            this._lblEtiqueta_6.TabIndex = 32;
            this._lblEtiqueta_6.Tag = "";
            this._lblEtiqueta_6.Text = "Responsable";
            // 
            // _lblEtiqueta_3
            // 
            this._lblEtiqueta_3.AutoSize = true;
            this._lblEtiqueta_3.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_3.Location = new System.Drawing.Point(136, 18);
            this._lblEtiqueta_3.Name = "_lblEtiqueta_3";
            this._lblEtiqueta_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_3.Size = new System.Drawing.Size(72, 13);
            this._lblEtiqueta_3.TabIndex = 30;
            this._lblEtiqueta_3.Tag = "";
            this._lblEtiqueta_3.Text = "Unidad Padre";
            // 
            // _lblEtiqueta_4
            // 
            this._lblEtiqueta_4.AutoSize = true;
            this._lblEtiqueta_4.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_4.Location = new System.Drawing.Point(304, 18);
            this._lblEtiqueta_4.Name = "_lblEtiqueta_4";
            this._lblEtiqueta_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_4.Size = new System.Drawing.Size(31, 13);
            this._lblEtiqueta_4.TabIndex = 28;
            this._lblEtiqueta_4.Tag = "";
            this._lblEtiqueta_4.Text = "Nivel";
            // 
            // _lblEtiqueta_2
            // 
            this._lblEtiqueta_2.AutoSize = true;
            this._lblEtiqueta_2.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_2.Location = new System.Drawing.Point(8, 18);
            this._lblEtiqueta_2.Name = "_lblEtiqueta_2";
            this._lblEtiqueta_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_2.Size = new System.Drawing.Size(41, 13);
            this._lblEtiqueta_2.TabIndex = 29;
            this._lblEtiqueta_2.Tag = "";
            this._lblEtiqueta_2.Text = "Unidad";
            // 
            // _lblEtiqueta_7
            // 
            this._lblEtiqueta_7.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_7.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_7.Location = new System.Drawing.Point(8, 99);
            this._lblEtiqueta_7.Name = "_lblEtiqueta_7";
            this._lblEtiqueta_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_7.Size = new System.Drawing.Size(131, 19);
            this._lblEtiqueta_7.TabIndex = 33;
            this._lblEtiqueta_7.Tag = "";
            this._lblEtiqueta_7.Text = "Domicilio (C&alle y Número)";
            // 
            // _lblEtiqueta_11
            // 
            this._lblEtiqueta_11.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_11.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_11.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_11.Location = new System.Drawing.Point(8, 210);
            this._lblEtiqueta_11.Name = "_lblEtiqueta_11";
            this._lblEtiqueta_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_11.Size = new System.Drawing.Size(43, 15);
            this._lblEtiqueta_11.TabIndex = 37;
            this._lblEtiqueta_11.Tag = "";
            this._lblEtiqueta_11.Text = "Estado";
            // 
            // _lblEtiqueta_12
            // 
            this._lblEtiqueta_12.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_12.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_12.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_12.Location = new System.Drawing.Point(236, 210);
            this._lblEtiqueta_12.Name = "_lblEtiqueta_12";
            this._lblEtiqueta_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_12.Size = new System.Drawing.Size(27, 13);
            this._lblEtiqueta_12.TabIndex = 38;
            this._lblEtiqueta_12.Tag = "";
            this._lblEtiqueta_12.Text = "País";
            // 
            // _lblEtiqueta_10
            // 
            this._lblEtiqueta_10.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_10.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_10.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_10.Location = new System.Drawing.Point(8, 183);
            this._lblEtiqueta_10.Name = "_lblEtiqueta_10";
            this._lblEtiqueta_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_10.Size = new System.Drawing.Size(44, 15);
            this._lblEtiqueta_10.TabIndex = 36;
            this._lblEtiqueta_10.Tag = "";
            this._lblEtiqueta_10.Text = "Ciudad";
            // 
            // _lblEtiqueta_8
            // 
            this._lblEtiqueta_8.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_8.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_8.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_8.Location = new System.Drawing.Point(8, 127);
            this._lblEtiqueta_8.Name = "_lblEtiqueta_8";
            this._lblEtiqueta_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_8.Size = new System.Drawing.Size(121, 17);
            this._lblEtiqueta_8.TabIndex = 34;
            this._lblEtiqueta_8.Tag = "";
            this._lblEtiqueta_8.Text = "Co&lonia";
            // 
            // _lblEtiqueta_9
            // 
            this._lblEtiqueta_9.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_9.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_9.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_9.Location = new System.Drawing.Point(8, 154);
            this._lblEtiqueta_9.Name = "_lblEtiqueta_9";
            this._lblEtiqueta_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_9.Size = new System.Drawing.Size(123, 17);
            this._lblEtiqueta_9.TabIndex = 35;
            this._lblEtiqueta_9.Tag = "";
            this._lblEtiqueta_9.Text = "&Pob./Del./Mun.";
            // 
            // _mkbMaskebox_2
            // 
            this._mkbMaskebox_2.Location = new System.Drawing.Point(344, 14);
            this._mkbMaskebox_2.Name = "_mkbMaskebox_2";
            this._mkbMaskebox_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_2.OcxState")));
            this._mkbMaskebox_2.Size = new System.Drawing.Size(41, 21);
            this._mkbMaskebox_2.TabIndex = 2;
            this._mkbMaskebox_2.Tag = "";
            this._mkbMaskebox_2.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _mkbMaskebox_1
            // 
            this._mkbMaskebox_1.Location = new System.Drawing.Point(224, 14);
            this._mkbMaskebox_1.Name = "_mkbMaskebox_1";
            this._mkbMaskebox_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_1.OcxState")));
            this._mkbMaskebox_1.Size = new System.Drawing.Size(41, 21);
            this._mkbMaskebox_1.TabIndex = 1;
            this._mkbMaskebox_1.Tag = "";
            this._mkbMaskebox_1.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _mkbMaskebox_4
            // 
            this._mkbMaskebox_4.Location = new System.Drawing.Point(81, 71);
            this._mkbMaskebox_4.Name = "_mkbMaskebox_4";
            this._mkbMaskebox_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_4.OcxState")));
            this._mkbMaskebox_4.Size = new System.Drawing.Size(305, 21);
            this._mkbMaskebox_4.TabIndex = 4;
            this._mkbMaskebox_4.Tag = "";
            this._mkbMaskebox_4.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _mkbMaskebox_3
            // 
            this._mkbMaskebox_3.Location = new System.Drawing.Point(57, 44);
            this._mkbMaskebox_3.Name = "_mkbMaskebox_3";
            this._mkbMaskebox_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_3.OcxState")));
            this._mkbMaskebox_3.Size = new System.Drawing.Size(343, 21);
            this._mkbMaskebox_3.TabIndex = 3;
            this._mkbMaskebox_3.Tag = "";
            this._mkbMaskebox_3.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _txtTexto_2
            // 
            this._txtTexto_2.AcceptsReturn = true;
            this._txtTexto_2.BackColor = System.Drawing.Color.White;
            this._txtTexto_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtTexto_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTexto_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtTexto_2.Location = new System.Drawing.Point(266, 207);
            this._txtTexto_2.MaxLength = 45;
            this._txtTexto_2.Name = "_txtTexto_2";
            this._txtTexto_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtTexto_2.Size = new System.Drawing.Size(73, 20);
            this._txtTexto_2.TabIndex = 10;
            this._txtTexto_2.Tag = "";
            this._txtTexto_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
            // 
            // _txtTexto_3
            // 
            this._txtTexto_3.AcceptsReturn = true;
            this._txtTexto_3.BackColor = System.Drawing.SystemColors.Window;
            this._txtTexto_3.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtTexto_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTexto_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtTexto_3.Location = new System.Drawing.Point(57, 260);
            this._txtTexto_3.MaxLength = 70;
            this._txtTexto_3.Name = "_txtTexto_3";
            this._txtTexto_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtTexto_3.Size = new System.Drawing.Size(456, 20);
            this._txtTexto_3.TabIndex = 16;
            this._txtTexto_3.Tag = "";
            this._txtTexto_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
            // 
            // _mkbMaskebox_0
            // 
            this._mkbMaskebox_0.Location = new System.Drawing.Point(56, 14);
            this._mkbMaskebox_0.Name = "_mkbMaskebox_0";
            this._mkbMaskebox_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_0.OcxState")));
            this._mkbMaskebox_0.Size = new System.Drawing.Size(41, 21);
            this._mkbMaskebox_0.TabIndex = 0;
            this._mkbMaskebox_0.Tag = "";
            this._mkbMaskebox_0.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _cmbCombo_0
            // 
            this._cmbCombo_0.BackColor = System.Drawing.SystemColors.Window;
            this._cmbCombo_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmbCombo_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbCombo_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this._cmbCombo_0, new int[0]);
            this._cmbCombo_0.Location = new System.Drawing.Point(57, 207);
            this._cmbCombo_0.Name = "_cmbCombo_0";
            this._cmbCombo_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmbCombo_0.Size = new System.Drawing.Size(161, 21);
            this._cmbCombo_0.TabIndex = 9;
            this._cmbCombo_0.Tag = "";
            // 
            // _mkbMaskebox_10
            // 
            this._mkbMaskebox_10.Location = new System.Drawing.Point(57, 234);
            this._mkbMaskebox_10.Name = "_mkbMaskebox_10";
            this._mkbMaskebox_10.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_10.OcxState")));
            this._mkbMaskebox_10.Size = new System.Drawing.Size(57, 21);
            this._mkbMaskebox_10.TabIndex = 12;
            this._mkbMaskebox_10.Tag = "";
            this._mkbMaskebox_10.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _mkbMaskebox_9
            // 
            this._mkbMaskebox_9.Location = new System.Drawing.Point(416, 207);
            this._mkbMaskebox_9.Name = "_mkbMaskebox_9";
            this._mkbMaskebox_9.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_9.OcxState")));
            this._mkbMaskebox_9.Size = new System.Drawing.Size(89, 21);
            this._mkbMaskebox_9.TabIndex = 11;
            this._mkbMaskebox_9.Tag = "";
            this._mkbMaskebox_9.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _mkbMaskebox_12
            // 
            this._mkbMaskebox_12.Location = new System.Drawing.Point(328, 234);
            this._mkbMaskebox_12.Name = "_mkbMaskebox_12";
            this._mkbMaskebox_12.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_12.OcxState")));
            this._mkbMaskebox_12.Size = new System.Drawing.Size(57, 21);
            this._mkbMaskebox_12.TabIndex = 14;
            this._mkbMaskebox_12.Tag = "";
            this._mkbMaskebox_12.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _mkbMaskebox_11
            // 
            this._mkbMaskebox_11.Location = new System.Drawing.Point(216, 234);
            this._mkbMaskebox_11.Name = "_mkbMaskebox_11";
            this._mkbMaskebox_11.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_11.OcxState")));
            this._mkbMaskebox_11.Size = new System.Drawing.Size(57, 21);
            this._mkbMaskebox_11.TabIndex = 13;
            this._mkbMaskebox_11.Tag = "";
            this._mkbMaskebox_11.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _mkbMaskebox_6
            // 
            this._mkbMaskebox_6.Location = new System.Drawing.Point(56, 125);
            this._mkbMaskebox_6.Name = "_mkbMaskebox_6";
            this._mkbMaskebox_6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_6.OcxState")));
            this._mkbMaskebox_6.Size = new System.Drawing.Size(393, 21);
            this._mkbMaskebox_6.TabIndex = 6;
            this._mkbMaskebox_6.Tag = "";
            this._mkbMaskebox_6.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _mkbMaskebox_5
            // 
            this._mkbMaskebox_5.Location = new System.Drawing.Point(144, 98);
            this._mkbMaskebox_5.Name = "_mkbMaskebox_5";
            this._mkbMaskebox_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_5.OcxState")));
            this._mkbMaskebox_5.Size = new System.Drawing.Size(305, 21);
            this._mkbMaskebox_5.TabIndex = 5;
            this._mkbMaskebox_5.Tag = "";
            this._mkbMaskebox_5.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _mkbMaskebox_8
            // 
            this._mkbMaskebox_8.Location = new System.Drawing.Point(56, 180);
            this._mkbMaskebox_8.Name = "_mkbMaskebox_8";
            this._mkbMaskebox_8.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_8.OcxState")));
            this._mkbMaskebox_8.Size = new System.Drawing.Size(305, 21);
            this._mkbMaskebox_8.TabIndex = 8;
            this._mkbMaskebox_8.Tag = "";
            this._mkbMaskebox_8.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _mkbMaskebox_7
            // 
            this._mkbMaskebox_7.Location = new System.Drawing.Point(88, 152);
            this._mkbMaskebox_7.Name = "_mkbMaskebox_7";
            this._mkbMaskebox_7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_7.OcxState")));
            this._mkbMaskebox_7.Size = new System.Drawing.Size(417, 21);
            this._mkbMaskebox_7.TabIndex = 7;
            this._mkbMaskebox_7.Tag = "";
            this._mkbMaskebox_7.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Validating);
            // 
            // _frmFrame_0
            // 
            this._frmFrame_0.Controls.Add(this._txtTexto_0);
            this._frmFrame_0.Controls.Add(this._txtTexto_1);
            this._frmFrame_0.Controls.Add(this._lblEtiqueta_1);
            this._frmFrame_0.Controls.Add(this._lblEtiqueta_0);
            this._frmFrame_0.Location = new System.Drawing.Point(16, 4);
            this._frmFrame_0.Name = "_frmFrame_0";
            this._frmFrame_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_frmFrame_0.OcxState")));
            this._frmFrame_0.Size = new System.Drawing.Size(550, 47);
            this._frmFrame_0.TabIndex = 24;
            this._frmFrame_0.Tag = "";
            // 
            // _txtTexto_0
            // 
            this._txtTexto_0.AcceptsReturn = true;
            this._txtTexto_0.BackColor = System.Drawing.Color.White;
            this._txtTexto_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtTexto_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTexto_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtTexto_0.Location = new System.Drawing.Point(60, 19);
            this._txtTexto_0.MaxLength = 45;
            this._txtTexto_0.Name = "_txtTexto_0";
            this._txtTexto_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtTexto_0.Size = new System.Drawing.Size(317, 20);
            this._txtTexto_0.TabIndex = 22;
            this._txtTexto_0.TabStop = false;
            this._txtTexto_0.Tag = "";
            this._txtTexto_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
            // 
            // _txtTexto_1
            // 
            this._txtTexto_1.AcceptsReturn = true;
            this._txtTexto_1.BackColor = System.Drawing.Color.White;
            this._txtTexto_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtTexto_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTexto_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtTexto_1.Location = new System.Drawing.Point(431, 19);
            this._txtTexto_1.MaxLength = 45;
            this._txtTexto_1.Name = "_txtTexto_1";
            this._txtTexto_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtTexto_1.Size = new System.Drawing.Size(107, 20);
            this._txtTexto_1.TabIndex = 40;
            this._txtTexto_1.TabStop = false;
            this._txtTexto_1.Tag = "";
            this._txtTexto_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
            // 
            // _lblEtiqueta_1
            // 
            this._lblEtiqueta_1.AutoSize = true;
            this._lblEtiqueta_1.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_1.Location = new System.Drawing.Point(386, 21);
            this._lblEtiqueta_1.Name = "_lblEtiqueta_1";
            this._lblEtiqueta_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_1.Size = new System.Drawing.Size(44, 13);
            this._lblEtiqueta_1.TabIndex = 25;
            this._lblEtiqueta_1.Tag = "";
            this._lblEtiqueta_1.Text = "&Número";
            // 
            // _lblEtiqueta_0
            // 
            this._lblEtiqueta_0.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_0.Location = new System.Drawing.Point(11, 21);
            this._lblEtiqueta_0.Name = "_lblEtiqueta_0";
            this._lblEtiqueta_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_0.Size = new System.Drawing.Size(49, 17);
            this._lblEtiqueta_0.TabIndex = 26;
            this._lblEtiqueta_0.Tag = "";
            this._lblEtiqueta_0.Text = "N&ombre";
            // 
            // __tabStab_0_TabPage2
            // 
            this.@__tabStab_0_TabPage2.Controls.Add(this._PAN_REP_5);
            this.@__tabStab_0_TabPage2.Controls.Add(this.FRAM_CAT);
            this.@__tabStab_0_TabPage2.Controls.Add(this._PAN_REP_6);
            this.@__tabStab_0_TabPage2.Controls.Add(this._PAN_REP_9);
            this.@__tabStab_0_TabPage2.Controls.Add(this._PAN_REP_7);
            this.@__tabStab_0_TabPage2.Controls.Add(this.LST_CAT);
            this.@__tabStab_0_TabPage2.Controls.Add(this._frmFrame_4);
            this.@__tabStab_0_TabPage2.Controls.Add(this._frmFrame_5);
            this.@__tabStab_0_TabPage2.Location = new System.Drawing.Point(4, 22);
            this.@__tabStab_0_TabPage2.Name = "__tabStab_0_TabPage2";
            this.@__tabStab_0_TabPage2.Size = new System.Drawing.Size(575, 385);
            this.@__tabStab_0_TabPage2.TabIndex = 1;
            this.@__tabStab_0_TabPage2.Tag = "";
            this.@__tabStab_0_TabPage2.Text = "Categorías";
            // 
            // _PAN_REP_5
            // 
            this._PAN_REP_5.Controls.Add(this._PAN_REP_5Label_Text);
            this._PAN_REP_5.Location = new System.Drawing.Point(40, 184);
            this._PAN_REP_5.Name = "_PAN_REP_5";
            this._PAN_REP_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_5.OcxState")));
            this._PAN_REP_5.Size = new System.Drawing.Size(314, 20);
            this._PAN_REP_5.TabIndex = 96;
            this._PAN_REP_5.Tag = "";
            // 
            // _PAN_REP_5Label_Text
            // 
            this._PAN_REP_5Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._PAN_REP_5Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._PAN_REP_5Label_Text.Location = new System.Drawing.Point(0, 0);
            this._PAN_REP_5Label_Text.Name = "_PAN_REP_5Label_Text";
            this._PAN_REP_5Label_Text.Size = new System.Drawing.Size(314, 20);
            this._PAN_REP_5Label_Text.TabIndex = 0;
            this._PAN_REP_5Label_Text.Tag = "";
            this._PAN_REP_5Label_Text.Text = "Nombre Categoria";
            this._PAN_REP_5Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FRAM_CAT
            // 
            this.FRAM_CAT.Controls.Add(this._mkbMaskebox_Cat_4);
            this.FRAM_CAT.Controls.Add(this._mkbMaskebox_Cat_3);
            this.FRAM_CAT.Controls.Add(this.CMB_CAT);
            this.FRAM_CAT.Controls.Add(this._lblEtiqueta_33);
            this.FRAM_CAT.Controls.Add(this._lblEtiqueta_35);
            this.FRAM_CAT.Controls.Add(this._lblEtiqueta_36);
            this.FRAM_CAT.Controls.Add(this.CMD_ACT_CAT);
            this.FRAM_CAT.Location = new System.Drawing.Point(14, 96);
            this.FRAM_CAT.Name = "FRAM_CAT";
            this.FRAM_CAT.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FRAM_CAT.OcxState")));
            this.FRAM_CAT.Size = new System.Drawing.Size(550, 83);
            this.FRAM_CAT.TabIndex = 88;
            this.FRAM_CAT.Tag = "";
            // 
            // _mkbMaskebox_Cat_4
            // 
            this._mkbMaskebox_Cat_4.Location = new System.Drawing.Point(448, 29);
            this._mkbMaskebox_Cat_4.Name = "_mkbMaskebox_Cat_4";
            this._mkbMaskebox_Cat_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Cat_4.OcxState")));
            this._mkbMaskebox_Cat_4.Size = new System.Drawing.Size(47, 21);
            this._mkbMaskebox_Cat_4.TabIndex = 94;
            this._mkbMaskebox_Cat_4.Tag = "";
            this._mkbMaskebox_Cat_4.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Cat_Validating);
            // 
            // _mkbMaskebox_Cat_3
            // 
            this._mkbMaskebox_Cat_3.Location = new System.Drawing.Point(315, 30);
            this._mkbMaskebox_Cat_3.Name = "_mkbMaskebox_Cat_3";
            this._mkbMaskebox_Cat_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Cat_3.OcxState")));
            this._mkbMaskebox_Cat_3.Size = new System.Drawing.Size(95, 21);
            this._mkbMaskebox_Cat_3.TabIndex = 93;
            this._mkbMaskebox_Cat_3.Tag = "";
            this._mkbMaskebox_Cat_3.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Cat_Validating);
            // 
            // CMB_CAT
            // 
            this.CMB_CAT.BackColor = System.Drawing.SystemColors.Window;
            this.CMB_CAT.Cursor = System.Windows.Forms.Cursors.Default;
            this.CMB_CAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMB_CAT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this.CMB_CAT, new int[0]);
            this.CMB_CAT.Location = new System.Drawing.Point(22, 31);
            this.CMB_CAT.Name = "CMB_CAT";
            this.CMB_CAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CMB_CAT.Size = new System.Drawing.Size(260, 21);
            this.CMB_CAT.TabIndex = 89;
            this.CMB_CAT.Tag = "";
            this.CMB_CAT.SelectionChangeCommitted += new System.EventHandler(this.CMB_CAT_SelectionChangeCommitted);
            // 
            // _lblEtiqueta_33
            // 
            this._lblEtiqueta_33.AutoSize = true;
            this._lblEtiqueta_33.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_33.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_33.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_33.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_33.Location = new System.Drawing.Point(102, 18);
            this._lblEtiqueta_33.Name = "_lblEtiqueta_33";
            this._lblEtiqueta_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_33.Size = new System.Drawing.Size(94, 13);
            this._lblEtiqueta_33.TabIndex = 90;
            this._lblEtiqueta_33.Tag = "";
            this._lblEtiqueta_33.Text = "Nombre Categoría";
            // 
            // _lblEtiqueta_35
            // 
            this._lblEtiqueta_35.AutoSize = true;
            this._lblEtiqueta_35.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_35.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_35.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_35.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_35.Location = new System.Drawing.Point(428, 16);
            this._lblEtiqueta_35.Name = "_lblEtiqueta_35";
            this._lblEtiqueta_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_35.Size = new System.Drawing.Size(95, 13);
            this._lblEtiqueta_35.TabIndex = 91;
            this._lblEtiqueta_35.Tag = "";
            this._lblEtiqueta_35.Text = "Porcentaje de Uso";
            // 
            // _lblEtiqueta_36
            // 
            this._lblEtiqueta_36.AutoSize = true;
            this._lblEtiqueta_36.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_36.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_36.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_36.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_36.Location = new System.Drawing.Point(324, 17);
            this._lblEtiqueta_36.Name = "_lblEtiqueta_36";
            this._lblEtiqueta_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_36.Size = new System.Drawing.Size(80, 13);
            this._lblEtiqueta_36.TabIndex = 92;
            this._lblEtiqueta_36.Tag = "";
            this._lblEtiqueta_36.Text = "Limite de Gasto";
            // 
            // CMD_ACT_CAT
            // 
            this.CMD_ACT_CAT.BackColor = System.Drawing.SystemColors.Control;
            this.CMD_ACT_CAT.Cursor = System.Windows.Forms.Cursors.Default;
            this.CMD_ACT_CAT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CMD_ACT_CAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMD_ACT_CAT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CMD_ACT_CAT.Location = new System.Drawing.Point(473, 56);
            this.CMD_ACT_CAT.Name = "CMD_ACT_CAT";
            this.CMD_ACT_CAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CMD_ACT_CAT.Size = new System.Drawing.Size(64, 20);
            this.CMD_ACT_CAT.TabIndex = 103;
            this.CMD_ACT_CAT.Tag = "";
            this.CMD_ACT_CAT.Text = "&Actualizar";
            this.CMD_ACT_CAT.UseVisualStyleBackColor = false;
            this.CMD_ACT_CAT.Click += new System.EventHandler(this.CMD_ACT_CAT_Click);
            // 
            // _PAN_REP_6
            // 
            this._PAN_REP_6.Controls.Add(this._PAN_REP_6Label_Text);
            this._PAN_REP_6.Location = new System.Drawing.Point(354, 184);
            this._PAN_REP_6.Name = "_PAN_REP_6";
            this._PAN_REP_6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_6.OcxState")));
            this._PAN_REP_6.Size = new System.Drawing.Size(96, 20);
            this._PAN_REP_6.TabIndex = 97;
            this._PAN_REP_6.Tag = "";
            // 
            // _PAN_REP_6Label_Text
            // 
            this._PAN_REP_6Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._PAN_REP_6Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._PAN_REP_6Label_Text.Location = new System.Drawing.Point(0, 0);
            this._PAN_REP_6Label_Text.Name = "_PAN_REP_6Label_Text";
            this._PAN_REP_6Label_Text.Size = new System.Drawing.Size(96, 20);
            this._PAN_REP_6Label_Text.TabIndex = 0;
            this._PAN_REP_6Label_Text.Tag = "";
            this._PAN_REP_6Label_Text.Text = "Limite de Gasto";
            this._PAN_REP_6Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _PAN_REP_9
            // 
            this._PAN_REP_9.Controls.Add(this._PAN_REP_9Label_Text);
            this._PAN_REP_9.Location = new System.Drawing.Point(15, 184);
            this._PAN_REP_9.Name = "_PAN_REP_9";
            this._PAN_REP_9.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_9.OcxState")));
            this._PAN_REP_9.Size = new System.Drawing.Size(25, 20);
            this._PAN_REP_9.TabIndex = 99;
            this._PAN_REP_9.Tag = "";
            // 
            // _PAN_REP_9Label_Text
            // 
            this._PAN_REP_9Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._PAN_REP_9Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._PAN_REP_9Label_Text.Location = new System.Drawing.Point(0, 0);
            this._PAN_REP_9Label_Text.Name = "_PAN_REP_9Label_Text";
            this._PAN_REP_9Label_Text.Size = new System.Drawing.Size(25, 20);
            this._PAN_REP_9Label_Text.TabIndex = 0;
            this._PAN_REP_9Label_Text.Tag = "";
            this._PAN_REP_9Label_Text.Text = "ID";
            this._PAN_REP_9Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _PAN_REP_7
            // 
            this._PAN_REP_7.Controls.Add(this._PAN_REP_7Label_Text);
            this._PAN_REP_7.Location = new System.Drawing.Point(450, 184);
            this._PAN_REP_7.Name = "_PAN_REP_7";
            this._PAN_REP_7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_7.OcxState")));
            this._PAN_REP_7.Size = new System.Drawing.Size(114, 20);
            this._PAN_REP_7.TabIndex = 98;
            this._PAN_REP_7.Tag = "";
            // 
            // _PAN_REP_7Label_Text
            // 
            this._PAN_REP_7Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._PAN_REP_7Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._PAN_REP_7Label_Text.Location = new System.Drawing.Point(0, 0);
            this._PAN_REP_7Label_Text.Name = "_PAN_REP_7Label_Text";
            this._PAN_REP_7Label_Text.Size = new System.Drawing.Size(114, 20);
            this._PAN_REP_7Label_Text.TabIndex = 0;
            this._PAN_REP_7Label_Text.Tag = "";
            this._PAN_REP_7Label_Text.Text = "Porcentaje de Uso";
            this._PAN_REP_7Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LST_CAT
            // 
            this.LST_CAT.BackColor = System.Drawing.SystemColors.Window;
            this.LST_CAT.Cursor = System.Windows.Forms.Cursors.Default;
            this.LST_CAT.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LST_CAT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this.LST_CAT, new int[] {
            0});
            this.LST_CAT.ItemHeight = 14;
            this.LST_CAT.Items.AddRange(new object[] {
            "LST_CAT"});
            this.LST_CAT.Location = new System.Drawing.Point(15, 203);
            this.LST_CAT.Name = "LST_CAT";
            this.LST_CAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LST_CAT.Size = new System.Drawing.Size(548, 172);
            this.LST_CAT.TabIndex = 95;
            this.LST_CAT.Tag = "";
            // 
            // _frmFrame_4
            // 
            this._frmFrame_4.Controls.Add(this._txtTexto_Cat_0);
            this._frmFrame_4.Controls.Add(this._txtTexto_Cat_1);
            this._frmFrame_4.Controls.Add(this._lblEtiqueta_28);
            this._frmFrame_4.Controls.Add(this._lblEtiqueta_29);
            this._frmFrame_4.Location = new System.Drawing.Point(14, 3);
            this._frmFrame_4.Name = "_frmFrame_4";
            this._frmFrame_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_frmFrame_4.OcxState")));
            this._frmFrame_4.Size = new System.Drawing.Size(550, 47);
            this._frmFrame_4.TabIndex = 76;
            this._frmFrame_4.Tag = "";
            // 
            // _txtTexto_Cat_0
            // 
            this._txtTexto_Cat_0.AcceptsReturn = true;
            this._txtTexto_Cat_0.BackColor = System.Drawing.Color.White;
            this._txtTexto_Cat_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtTexto_Cat_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTexto_Cat_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtTexto_Cat_0.Location = new System.Drawing.Point(59, 17);
            this._txtTexto_Cat_0.MaxLength = 45;
            this._txtTexto_Cat_0.Name = "_txtTexto_Cat_0";
            this._txtTexto_Cat_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtTexto_Cat_0.Size = new System.Drawing.Size(317, 20);
            this._txtTexto_Cat_0.TabIndex = 77;
            this._txtTexto_Cat_0.TabStop = false;
            this._txtTexto_Cat_0.Tag = "";
            // 
            // _txtTexto_Cat_1
            // 
            this._txtTexto_Cat_1.AcceptsReturn = true;
            this._txtTexto_Cat_1.BackColor = System.Drawing.Color.White;
            this._txtTexto_Cat_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtTexto_Cat_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTexto_Cat_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtTexto_Cat_1.Location = new System.Drawing.Point(430, 17);
            this._txtTexto_Cat_1.MaxLength = 45;
            this._txtTexto_Cat_1.Name = "_txtTexto_Cat_1";
            this._txtTexto_Cat_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtTexto_Cat_1.Size = new System.Drawing.Size(107, 20);
            this._txtTexto_Cat_1.TabIndex = 78;
            this._txtTexto_Cat_1.TabStop = false;
            this._txtTexto_Cat_1.Tag = "";
            // 
            // _lblEtiqueta_28
            // 
            this._lblEtiqueta_28.AutoSize = true;
            this._lblEtiqueta_28.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_28.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_28.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_28.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_28.Location = new System.Drawing.Point(385, 19);
            this._lblEtiqueta_28.Name = "_lblEtiqueta_28";
            this._lblEtiqueta_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_28.Size = new System.Drawing.Size(44, 13);
            this._lblEtiqueta_28.TabIndex = 79;
            this._lblEtiqueta_28.Tag = "";
            this._lblEtiqueta_28.Text = "&Número";
            // 
            // _lblEtiqueta_29
            // 
            this._lblEtiqueta_29.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_29.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_29.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_29.Location = new System.Drawing.Point(10, 19);
            this._lblEtiqueta_29.Name = "_lblEtiqueta_29";
            this._lblEtiqueta_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_29.Size = new System.Drawing.Size(49, 17);
            this._lblEtiqueta_29.TabIndex = 80;
            this._lblEtiqueta_29.Tag = "";
            this._lblEtiqueta_29.Text = "N&ombre";
            // 
            // _frmFrame_5
            // 
            this._frmFrame_5.Controls.Add(this._mkbMaskebox_Cat_2);
            this._frmFrame_5.Controls.Add(this._mkbMaskebox_Cat_1);
            this._frmFrame_5.Controls.Add(this._mkbMaskebox_Cat_0);
            this._frmFrame_5.Controls.Add(this._lblEtiqueta_32);
            this._frmFrame_5.Controls.Add(this._lblEtiqueta_30);
            this._frmFrame_5.Controls.Add(this._lblEtiqueta_31);
            this._frmFrame_5.Location = new System.Drawing.Point(14, 51);
            this._frmFrame_5.Name = "_frmFrame_5";
            this._frmFrame_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_frmFrame_5.OcxState")));
            this._frmFrame_5.Size = new System.Drawing.Size(550, 46);
            this._frmFrame_5.TabIndex = 81;
            this._frmFrame_5.Tag = "";
            // 
            // _mkbMaskebox_Cat_2
            // 
            this._mkbMaskebox_Cat_2.Location = new System.Drawing.Point(494, 18);
            this._mkbMaskebox_Cat_2.Name = "_mkbMaskebox_Cat_2";
            this._mkbMaskebox_Cat_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Cat_2.OcxState")));
            this._mkbMaskebox_Cat_2.Size = new System.Drawing.Size(41, 21);
            this._mkbMaskebox_Cat_2.TabIndex = 84;
            this._mkbMaskebox_Cat_2.Tag = "";
            this._mkbMaskebox_Cat_2.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Cat_Validating);
            // 
            // _mkbMaskebox_Cat_1
            // 
            this._mkbMaskebox_Cat_1.Location = new System.Drawing.Point(159, 18);
            this._mkbMaskebox_Cat_1.Name = "_mkbMaskebox_Cat_1";
            this._mkbMaskebox_Cat_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Cat_1.OcxState")));
            this._mkbMaskebox_Cat_1.Size = new System.Drawing.Size(294, 21);
            this._mkbMaskebox_Cat_1.TabIndex = 83;
            this._mkbMaskebox_Cat_1.Tag = "";
            this._mkbMaskebox_Cat_1.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Cat_Validating);
            // 
            // _mkbMaskebox_Cat_0
            // 
            this._mkbMaskebox_Cat_0.Location = new System.Drawing.Point(56, 18);
            this._mkbMaskebox_Cat_0.Name = "_mkbMaskebox_Cat_0";
            this._mkbMaskebox_Cat_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Cat_0.OcxState")));
            this._mkbMaskebox_Cat_0.Size = new System.Drawing.Size(41, 21);
            this._mkbMaskebox_Cat_0.TabIndex = 82;
            this._mkbMaskebox_Cat_0.Tag = "";
            this._mkbMaskebox_Cat_0.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Cat_Validating);
            // 
            // _lblEtiqueta_32
            // 
            this._lblEtiqueta_32.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_32.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_32.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_32.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_32.Location = new System.Drawing.Point(111, 20);
            this._lblEtiqueta_32.Name = "_lblEtiqueta_32";
            this._lblEtiqueta_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_32.Size = new System.Drawing.Size(53, 17);
            this._lblEtiqueta_32.TabIndex = 87;
            this._lblEtiqueta_32.Tag = "";
            this._lblEtiqueta_32.Text = "Nombre";
            // 
            // _lblEtiqueta_30
            // 
            this._lblEtiqueta_30.AutoSize = true;
            this._lblEtiqueta_30.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_30.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_30.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_30.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_30.Location = new System.Drawing.Point(462, 22);
            this._lblEtiqueta_30.Name = "_lblEtiqueta_30";
            this._lblEtiqueta_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_30.Size = new System.Drawing.Size(31, 13);
            this._lblEtiqueta_30.TabIndex = 85;
            this._lblEtiqueta_30.Tag = "";
            this._lblEtiqueta_30.Text = "Nivel";
            // 
            // _lblEtiqueta_31
            // 
            this._lblEtiqueta_31.AutoSize = true;
            this._lblEtiqueta_31.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_31.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_31.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_31.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_31.Location = new System.Drawing.Point(11, 22);
            this._lblEtiqueta_31.Name = "_lblEtiqueta_31";
            this._lblEtiqueta_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_31.Size = new System.Drawing.Size(41, 13);
            this._lblEtiqueta_31.TabIndex = 86;
            this._lblEtiqueta_31.Tag = "";
            this._lblEtiqueta_31.Text = "Unidad";
            // 
            // __tabStab_0_TabPage1
            // 
            this.@__tabStab_0_TabPage1.Controls.Add(this._frmFrame_2);
            this.@__tabStab_0_TabPage1.Controls.Add(this._frmFrame_3);
            this.@__tabStab_0_TabPage1.Controls.Add(this._PAN_REP_1);
            this.@__tabStab_0_TabPage1.Controls.Add(this._FRAM_REP_0);
            this.@__tabStab_0_TabPage1.Controls.Add(this._LST_REPO_0);
            this.@__tabStab_0_TabPage1.Controls.Add(this._PAN_REP_0);
            this.@__tabStab_0_TabPage1.Controls.Add(this._PAN_REP_4);
            this.@__tabStab_0_TabPage1.Controls.Add(this._PAN_REP_8);
            this.@__tabStab_0_TabPage1.Controls.Add(this._PAN_REP_2);
            this.@__tabStab_0_TabPage1.Controls.Add(this._PAN_REP_3);
            this.@__tabStab_0_TabPage1.Location = new System.Drawing.Point(4, 43);
            this.@__tabStab_0_TabPage1.Name = "__tabStab_0_TabPage1";
            this.@__tabStab_0_TabPage1.Size = new System.Drawing.Size(575, 364);
            this.@__tabStab_0_TabPage1.TabIndex = 2;
            this.@__tabStab_0_TabPage1.Tag = "";
            this.@__tabStab_0_TabPage1.Text = "Reportes";
            // 
            // _frmFrame_2
            // 
            this._frmFrame_2.Controls.Add(this._txtTexto_Rep_1);
            this._frmFrame_2.Controls.Add(this._txtTexto_Rep_0);
            this._frmFrame_2.Controls.Add(this._lblEtiqueta_21);
            this._frmFrame_2.Controls.Add(this._lblEtiqueta_27);
            this._frmFrame_2.Location = new System.Drawing.Point(13, 5);
            this._frmFrame_2.Name = "_frmFrame_2";
            this._frmFrame_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_frmFrame_2.OcxState")));
            this._frmFrame_2.Size = new System.Drawing.Size(550, 47);
            this._frmFrame_2.TabIndex = 48;
            this._frmFrame_2.Tag = "";
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
            this._txtTexto_Rep_1.TabIndex = 69;
            this._txtTexto_Rep_1.TabStop = false;
            this._txtTexto_Rep_1.Tag = "";
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
            this._txtTexto_Rep_0.TabIndex = 70;
            this._txtTexto_Rep_0.TabStop = false;
            this._txtTexto_Rep_0.Tag = "";
            // 
            // _lblEtiqueta_21
            // 
            this._lblEtiqueta_21.AutoSize = true;
            this._lblEtiqueta_21.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_21.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_21.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_21.Location = new System.Drawing.Point(10, 21);
            this._lblEtiqueta_21.Name = "_lblEtiqueta_21";
            this._lblEtiqueta_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_21.Size = new System.Drawing.Size(44, 13);
            this._lblEtiqueta_21.TabIndex = 71;
            this._lblEtiqueta_21.Tag = "";
            this._lblEtiqueta_21.Text = "Nombre";
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
            this._lblEtiqueta_27.TabIndex = 72;
            this._lblEtiqueta_27.Tag = "";
            this._lblEtiqueta_27.Text = "Número";
            // 
            // _frmFrame_3
            // 
            this._frmFrame_3.Controls.Add(this._mkbMaskebox_Rep_2);
            this._frmFrame_3.Controls.Add(this._mkbMaskebox_Rep_1);
            this._frmFrame_3.Controls.Add(this._mkbMaskebox_Rep_0);
            this._frmFrame_3.Controls.Add(this._lblEtiqueta_22);
            this._frmFrame_3.Controls.Add(this._lblEtiqueta_38);
            this._frmFrame_3.Controls.Add(this._lblEtiqueta_40);
            this._frmFrame_3.Location = new System.Drawing.Point(13, 53);
            this._frmFrame_3.Name = "_frmFrame_3";
            this._frmFrame_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_frmFrame_3.OcxState")));
            this._frmFrame_3.Size = new System.Drawing.Size(550, 46);
            this._frmFrame_3.TabIndex = 49;
            this._frmFrame_3.Tag = "";
            // 
            // _mkbMaskebox_Rep_2
            // 
            this._mkbMaskebox_Rep_2.Location = new System.Drawing.Point(495, 18);
            this._mkbMaskebox_Rep_2.Name = "_mkbMaskebox_Rep_2";
            this._mkbMaskebox_Rep_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Rep_2.OcxState")));
            this._mkbMaskebox_Rep_2.Size = new System.Drawing.Size(41, 21);
            this._mkbMaskebox_Rep_2.TabIndex = 54;
            this._mkbMaskebox_Rep_2.Tag = "";
            this._mkbMaskebox_Rep_2.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Rep_Validating);
            // 
            // _mkbMaskebox_Rep_1
            // 
            this._mkbMaskebox_Rep_1.Location = new System.Drawing.Point(159, 18);
            this._mkbMaskebox_Rep_1.Name = "_mkbMaskebox_Rep_1";
            this._mkbMaskebox_Rep_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Rep_1.OcxState")));
            this._mkbMaskebox_Rep_1.Size = new System.Drawing.Size(294, 21);
            this._mkbMaskebox_Rep_1.TabIndex = 51;
            this._mkbMaskebox_Rep_1.Tag = "";
            this._mkbMaskebox_Rep_1.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Rep_Validating);
            // 
            // _mkbMaskebox_Rep_0
            // 
            this._mkbMaskebox_Rep_0.Location = new System.Drawing.Point(56, 18);
            this._mkbMaskebox_Rep_0.Name = "_mkbMaskebox_Rep_0";
            this._mkbMaskebox_Rep_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Rep_0.OcxState")));
            this._mkbMaskebox_Rep_0.Size = new System.Drawing.Size(41, 21);
            this._mkbMaskebox_Rep_0.TabIndex = 50;
            this._mkbMaskebox_Rep_0.Tag = "";
            this._mkbMaskebox_Rep_0.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Rep_Validating);
            // 
            // _lblEtiqueta_22
            // 
            this._lblEtiqueta_22.AutoSize = true;
            this._lblEtiqueta_22.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_22.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_22.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_22.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_22.Location = new System.Drawing.Point(462, 22);
            this._lblEtiqueta_22.Name = "_lblEtiqueta_22";
            this._lblEtiqueta_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_22.Size = new System.Drawing.Size(31, 13);
            this._lblEtiqueta_22.TabIndex = 55;
            this._lblEtiqueta_22.Tag = "";
            this._lblEtiqueta_22.Text = "Nivel";
            // 
            // _lblEtiqueta_38
            // 
            this._lblEtiqueta_38.AutoSize = true;
            this._lblEtiqueta_38.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_38.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_38.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_38.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_38.Location = new System.Drawing.Point(111, 22);
            this._lblEtiqueta_38.Name = "_lblEtiqueta_38";
            this._lblEtiqueta_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_38.Size = new System.Drawing.Size(44, 13);
            this._lblEtiqueta_38.TabIndex = 52;
            this._lblEtiqueta_38.Tag = "";
            this._lblEtiqueta_38.Text = "Nombre";
            // 
            // _lblEtiqueta_40
            // 
            this._lblEtiqueta_40.AutoSize = true;
            this._lblEtiqueta_40.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_40.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_40.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_40.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_40.Location = new System.Drawing.Point(11, 20);
            this._lblEtiqueta_40.Name = "_lblEtiqueta_40";
            this._lblEtiqueta_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_40.Size = new System.Drawing.Size(41, 13);
            this._lblEtiqueta_40.TabIndex = 53;
            this._lblEtiqueta_40.Tag = "";
            this._lblEtiqueta_40.Text = "Unidad";
            // 
            // _PAN_REP_1
            // 
            this._PAN_REP_1.Controls.Add(this._PAN_REP_1Label_Text);
            this._PAN_REP_1.Location = new System.Drawing.Point(359, 184);
            this._PAN_REP_1.Name = "_PAN_REP_1";
            this._PAN_REP_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_1.OcxState")));
            this._PAN_REP_1.Size = new System.Drawing.Size(74, 20);
            this._PAN_REP_1.TabIndex = 57;
            this._PAN_REP_1.Tag = "";
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
            // _FRAM_REP_0
            // 
            this._FRAM_REP_0.Controls.Add(this._CMB_REPO_1);
            this._FRAM_REP_0.Controls.Add(this._lblEtiqueta_34);
            this._FRAM_REP_0.Controls.Add(this._CMB_REPO_3);
            this._FRAM_REP_0.Controls.Add(this._CMB_REPO_2);
            this._FRAM_REP_0.Controls.Add(this._lblEtiqueta_25);
            this._FRAM_REP_0.Controls.Add(this._lblEtiqueta_24);
            this._FRAM_REP_0.Controls.Add(this._lblEtiqueta_23);
            this._FRAM_REP_0.Controls.Add(this._lblEtiqueta_26);
            this._FRAM_REP_0.Controls.Add(this._CMB_REPO_0);
            this._FRAM_REP_0.Controls.Add(this.CMD_ACT_REP);
            this._FRAM_REP_0.Controls.Add(this.CHK_REP);
            this._FRAM_REP_0.Location = new System.Drawing.Point(13, 98);
            this._FRAM_REP_0.Name = "_FRAM_REP_0";
            this._FRAM_REP_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_FRAM_REP_0.OcxState")));
            this._FRAM_REP_0.Size = new System.Drawing.Size(550, 82);
            this._FRAM_REP_0.TabIndex = 62;
            this._FRAM_REP_0.Tag = "";
            // 
            // _CMB_REPO_1
            // 
            this._CMB_REPO_1.BackColor = System.Drawing.SystemColors.Window;
            this._CMB_REPO_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._CMB_REPO_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CMB_REPO_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this._CMB_REPO_1, new int[] {
            1,
            2,
            3,
            4,
            5,
            6});
            this._CMB_REPO_1.Items.AddRange(new object[] {
            "Quarterly",
            "Monthly",
            "Fiscal Quarterly",
            "Annual",
            "Cyclic",
            "Fiscal Annual"});
            this._CMB_REPO_1.Location = new System.Drawing.Point(248, 30);
            this._CMB_REPO_1.Name = "_CMB_REPO_1";
            this._CMB_REPO_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CMB_REPO_1.Size = new System.Drawing.Size(108, 21);
            this._CMB_REPO_1.TabIndex = 63;
            this._CMB_REPO_1.Tag = "";
            this._CMB_REPO_1.SelectedIndexChanged += new System.EventHandler(this.CMB_REPO_SelectedIndexChanged);
            // 
            // _lblEtiqueta_34
            // 
            this._lblEtiqueta_34.AutoSize = true;
            this._lblEtiqueta_34.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_34.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_34.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_34.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_34.Location = new System.Drawing.Point(214, 14);
            this._lblEtiqueta_34.Name = "_lblEtiqueta_34";
            this._lblEtiqueta_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_34.Size = new System.Drawing.Size(45, 13);
            this._lblEtiqueta_34.TabIndex = 100;
            this._lblEtiqueta_34.Tag = "";
            this._lblEtiqueta_34.Text = "Generar";
            // 
            // _CMB_REPO_3
            // 
            this._CMB_REPO_3.BackColor = System.Drawing.SystemColors.Window;
            this._CMB_REPO_3.Cursor = System.Windows.Forms.Cursors.Default;
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
            this._CMB_REPO_3.Location = new System.Drawing.Point(456, 30);
            this._CMB_REPO_3.Name = "_CMB_REPO_3";
            this._CMB_REPO_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CMB_REPO_3.Size = new System.Drawing.Size(83, 21);
            this._CMB_REPO_3.TabIndex = 65;
            this._CMB_REPO_3.Tag = "";
            this._CMB_REPO_3.SelectedIndexChanged += new System.EventHandler(this.CMB_REPO_SelectedIndexChanged);
            // 
            // _CMB_REPO_2
            // 
            this._CMB_REPO_2.BackColor = System.Drawing.SystemColors.Window;
            this._CMB_REPO_2.Cursor = System.Windows.Forms.Cursors.Default;
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
            this._CMB_REPO_2.Location = new System.Drawing.Point(358, 30);
            this._CMB_REPO_2.Name = "_CMB_REPO_2";
            this._CMB_REPO_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CMB_REPO_2.Size = new System.Drawing.Size(96, 21);
            this._CMB_REPO_2.TabIndex = 64;
            this._CMB_REPO_2.Tag = "";
            this._CMB_REPO_2.SelectedIndexChanged += new System.EventHandler(this.CMB_REPO_SelectedIndexChanged);
            // 
            // _lblEtiqueta_25
            // 
            this._lblEtiqueta_25.AutoSize = true;
            this._lblEtiqueta_25.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_25.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_25.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_25.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_25.Location = new System.Drawing.Point(383, 16);
            this._lblEtiqueta_25.Name = "_lblEtiqueta_25";
            this._lblEtiqueta_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_25.Size = new System.Drawing.Size(40, 13);
            this._lblEtiqueta_25.TabIndex = 67;
            this._lblEtiqueta_25.Tag = "";
            this._lblEtiqueta_25.Text = "Detalle";
            // 
            // _lblEtiqueta_24
            // 
            this._lblEtiqueta_24.AutoSize = true;
            this._lblEtiqueta_24.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_24.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_24.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_24.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_24.Location = new System.Drawing.Point(269, 15);
            this._lblEtiqueta_24.Name = "_lblEtiqueta_24";
            this._lblEtiqueta_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_24.Size = new System.Drawing.Size(60, 13);
            this._lblEtiqueta_24.TabIndex = 66;
            this._lblEtiqueta_24.Tag = "";
            this._lblEtiqueta_24.Text = "Frecuencia";
            // 
            // _lblEtiqueta_23
            // 
            this._lblEtiqueta_23.AutoSize = true;
            this._lblEtiqueta_23.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_23.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_23.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_23.Location = new System.Drawing.Point(11, 16);
            this._lblEtiqueta_23.Name = "_lblEtiqueta_23";
            this._lblEtiqueta_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_23.Size = new System.Drawing.Size(85, 13);
            this._lblEtiqueta_23.TabIndex = 74;
            this._lblEtiqueta_23.Tag = "";
            this._lblEtiqueta_23.Text = "Nombre Reporte";
            // 
            // _lblEtiqueta_26
            // 
            this._lblEtiqueta_26.AutoSize = true;
            this._lblEtiqueta_26.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_26.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_26.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_26.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_26.Location = new System.Drawing.Point(467, 16);
            this._lblEtiqueta_26.Name = "_lblEtiqueta_26";
            this._lblEtiqueta_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_26.Size = new System.Drawing.Size(64, 13);
            this._lblEtiqueta_26.TabIndex = 68;
            this._lblEtiqueta_26.Tag = "";
            this._lblEtiqueta_26.Text = "Profundidad";
            // 
            // _CMB_REPO_0
            // 
            this._CMB_REPO_0.BackColor = System.Drawing.SystemColors.Window;
            this._CMB_REPO_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._CMB_REPO_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CMB_REPO_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this._CMB_REPO_0, new int[0]);
            this._CMB_REPO_0.Location = new System.Drawing.Point(10, 28);
            this._CMB_REPO_0.Name = "_CMB_REPO_0";
            this._CMB_REPO_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CMB_REPO_0.Size = new System.Drawing.Size(209, 21);
            this._CMB_REPO_0.TabIndex = 73;
            this._CMB_REPO_0.Tag = "";
            this._CMB_REPO_0.SelectedIndexChanged += new System.EventHandler(this.CMB_REPO_SelectedIndexChanged);
            // 
            // CMD_ACT_REP
            // 
            this.CMD_ACT_REP.BackColor = System.Drawing.SystemColors.Control;
            this.CMD_ACT_REP.Cursor = System.Windows.Forms.Cursors.Default;
            this.CMD_ACT_REP.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CMD_ACT_REP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CMD_ACT_REP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CMD_ACT_REP.Location = new System.Drawing.Point(471, 56);
            this.CMD_ACT_REP.Name = "CMD_ACT_REP";
            this.CMD_ACT_REP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CMD_ACT_REP.Size = new System.Drawing.Size(64, 20);
            this.CMD_ACT_REP.TabIndex = 101;
            this.CMD_ACT_REP.Tag = "";
            this.CMD_ACT_REP.Text = "&Actualizar";
            this.CMD_ACT_REP.UseVisualStyleBackColor = false;
            this.CMD_ACT_REP.Click += new System.EventHandler(this.CMD_ACT_REP_Click);
            // 
            // CHK_REP
            // 
            this.CHK_REP.BackColor = System.Drawing.SystemColors.Control;
            this.CHK_REP.Cursor = System.Windows.Forms.Cursors.Default;
            this.CHK_REP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CHK_REP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CHK_REP.Location = new System.Drawing.Point(226, 32);
            this.CHK_REP.Name = "CHK_REP";
            this.CHK_REP.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CHK_REP.Size = new System.Drawing.Size(15, 15);
            this.CHK_REP.TabIndex = 75;
            this.CHK_REP.Tag = "";
            this.CHK_REP.UseVisualStyleBackColor = false;
            this.CHK_REP.CheckStateChanged += new System.EventHandler(this.CHK_REP_CheckStateChanged);
            // 
            // _LST_REPO_0
            // 
            this._LST_REPO_0.BackColor = System.Drawing.SystemColors.Window;
            this._LST_REPO_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._LST_REPO_0.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LST_REPO_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this._LST_REPO_0, new int[0]);
            this._LST_REPO_0.ItemHeight = 14;
            this._LST_REPO_0.Location = new System.Drawing.Point(14, 203);
            this._LST_REPO_0.Name = "_LST_REPO_0";
            this._LST_REPO_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LST_REPO_0.Size = new System.Drawing.Size(548, 172);
            this._LST_REPO_0.TabIndex = 60;
            this._LST_REPO_0.Tag = "";
            this._LST_REPO_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LST_REPO_KeyPress);
            // 
            // _PAN_REP_0
            // 
            this._PAN_REP_0.Controls.Add(this._PAN_REP_0Label_Text);
            this._PAN_REP_0.Location = new System.Drawing.Point(39, 184);
            this._PAN_REP_0.Name = "_PAN_REP_0";
            this._PAN_REP_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_0.OcxState")));
            this._PAN_REP_0.Size = new System.Drawing.Size(266, 20);
            this._PAN_REP_0.TabIndex = 56;
            this._PAN_REP_0.Tag = "";
            // 
            // _PAN_REP_0Label_Text
            // 
            this._PAN_REP_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._PAN_REP_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._PAN_REP_0Label_Text.Location = new System.Drawing.Point(0, 0);
            this._PAN_REP_0Label_Text.Name = "_PAN_REP_0Label_Text";
            this._PAN_REP_0Label_Text.Size = new System.Drawing.Size(266, 20);
            this._PAN_REP_0Label_Text.TabIndex = 0;
            this._PAN_REP_0Label_Text.Tag = "";
            this._PAN_REP_0Label_Text.Text = "Nombre Reporte";
            this._PAN_REP_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _PAN_REP_4
            // 
            this._PAN_REP_4.Controls.Add(this._PAN_REP_4Label_Text);
            this._PAN_REP_4.Location = new System.Drawing.Point(14, 184);
            this._PAN_REP_4.Name = "_PAN_REP_4";
            this._PAN_REP_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_4.OcxState")));
            this._PAN_REP_4.Size = new System.Drawing.Size(25, 20);
            this._PAN_REP_4.TabIndex = 61;
            this._PAN_REP_4.Tag = "";
            // 
            // _PAN_REP_4Label_Text
            // 
            this._PAN_REP_4Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._PAN_REP_4Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._PAN_REP_4Label_Text.Location = new System.Drawing.Point(0, 0);
            this._PAN_REP_4Label_Text.Name = "_PAN_REP_4Label_Text";
            this._PAN_REP_4Label_Text.Size = new System.Drawing.Size(25, 20);
            this._PAN_REP_4Label_Text.TabIndex = 0;
            this._PAN_REP_4Label_Text.Tag = "";
            this._PAN_REP_4Label_Text.Text = "ID";
            this._PAN_REP_4Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _PAN_REP_8
            // 
            this._PAN_REP_8.Controls.Add(this._PAN_REP_8Label_Text);
            this._PAN_REP_8.Location = new System.Drawing.Point(305, 184);
            this._PAN_REP_8.Name = "_PAN_REP_8";
            this._PAN_REP_8.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_8.OcxState")));
            this._PAN_REP_8.Size = new System.Drawing.Size(54, 20);
            this._PAN_REP_8.TabIndex = 102;
            this._PAN_REP_8.Tag = "";
            // 
            // _PAN_REP_8Label_Text
            // 
            this._PAN_REP_8Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._PAN_REP_8Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._PAN_REP_8Label_Text.Location = new System.Drawing.Point(0, 0);
            this._PAN_REP_8Label_Text.Name = "_PAN_REP_8Label_Text";
            this._PAN_REP_8Label_Text.Size = new System.Drawing.Size(54, 20);
            this._PAN_REP_8Label_Text.TabIndex = 0;
            this._PAN_REP_8Label_Text.Tag = "";
            this._PAN_REP_8Label_Text.Text = "Generar";
            this._PAN_REP_8Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _PAN_REP_2
            // 
            this._PAN_REP_2.Controls.Add(this._PAN_REP_2Label_Text);
            this._PAN_REP_2.Location = new System.Drawing.Point(433, 184);
            this._PAN_REP_2.Name = "_PAN_REP_2";
            this._PAN_REP_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_2.OcxState")));
            this._PAN_REP_2.Size = new System.Drawing.Size(52, 20);
            this._PAN_REP_2.TabIndex = 58;
            this._PAN_REP_2.Tag = "";
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
            this._PAN_REP_3.Location = new System.Drawing.Point(485, 184);
            this._PAN_REP_3.Name = "_PAN_REP_3";
            this._PAN_REP_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_3.OcxState")));
            this._PAN_REP_3.Size = new System.Drawing.Size(77, 20);
            this._PAN_REP_3.TabIndex = 59;
            this._PAN_REP_3.Tag = "";
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
            // CORMNUNI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(623, 456);
            this.Controls.Add(this.ID_MEE_CER_PB);
            this.Controls.Add(this._tabStab_0);
            this.Controls.Add(this.ID_MEE_IMP_PB);
            this.Controls.Add(this.ID_MEE_ALT_PB);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(224, 177);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORMNUNI";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Mantenimiento de Unidades";
            this.Closed += new System.EventHandler(this.CORMNUNI_Closed);
            this._tabStab_0.ResumeLayout(false);
            this.@__tabStab_0_TabPage0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._frmFrame_1)).EndInit();
            this._frmFrame_1.ResumeLayout(false);
            this._frmFrame_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._frmFrame_0)).EndInit();
            this._frmFrame_0.ResumeLayout(false);
            this._frmFrame_0.PerformLayout();
            this.@__tabStab_0_TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_5)).EndInit();
            this._PAN_REP_5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.FRAM_CAT)).EndInit();
            this.FRAM_CAT.ResumeLayout(false);
            this.FRAM_CAT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_6)).EndInit();
            this._PAN_REP_6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_9)).EndInit();
            this._PAN_REP_9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_7)).EndInit();
            this._PAN_REP_7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._frmFrame_4)).EndInit();
            this._frmFrame_4.ResumeLayout(false);
            this._frmFrame_4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._frmFrame_5)).EndInit();
            this._frmFrame_5.ResumeLayout(false);
            this._frmFrame_5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_0)).EndInit();
            this.@__tabStab_0_TabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._frmFrame_2)).EndInit();
            this._frmFrame_2.ResumeLayout(false);
            this._frmFrame_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._frmFrame_3)).EndInit();
            this._frmFrame_3.ResumeLayout(false);
            this._frmFrame_3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Rep_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Rep_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Rep_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_1)).EndInit();
            this._PAN_REP_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._FRAM_REP_0)).EndInit();
            this._FRAM_REP_0.ResumeLayout(false);
            this._FRAM_REP_0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_0)).EndInit();
            this._PAN_REP_0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_4)).EndInit();
            this._PAN_REP_4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_8)).EndInit();
            this._PAN_REP_8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_2)).EndInit();
            this._PAN_REP_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_3)).EndInit();
            this._PAN_REP_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).EndInit();
            this.ResumeLayout(false);

	}
	void  InitializeCMB_REPO()
	{
			this.CMB_REPO[0] = _CMB_REPO_0;
			this.CMB_REPO[3] = _CMB_REPO_3;
			this.CMB_REPO[2] = _CMB_REPO_2;
			this.CMB_REPO[1] = _CMB_REPO_1;
	}
	void  InitializelblEtiqueta()
	{
			this.lblEtiqueta[34] = _lblEtiqueta_34;
			this.lblEtiqueta[23] = _lblEtiqueta_23;
			this.lblEtiqueta[26] = _lblEtiqueta_26;
			this.lblEtiqueta[25] = _lblEtiqueta_25;
			this.lblEtiqueta[24] = _lblEtiqueta_24;
			this.lblEtiqueta[0] = _lblEtiqueta_0;
			this.lblEtiqueta[1] = _lblEtiqueta_1;
			this.lblEtiqueta[20] = _lblEtiqueta_20;
			this.lblEtiqueta[19] = _lblEtiqueta_19;
			this.lblEtiqueta[18] = _lblEtiqueta_18;
			this.lblEtiqueta[17] = _lblEtiqueta_17;
			this.lblEtiqueta[16] = _lblEtiqueta_16;
			this.lblEtiqueta[15] = _lblEtiqueta_15;
			this.lblEtiqueta[14] = _lblEtiqueta_14;
			this.lblEtiqueta[13] = _lblEtiqueta_13;
			this.lblEtiqueta[12] = _lblEtiqueta_12;
			this.lblEtiqueta[11] = _lblEtiqueta_11;
			this.lblEtiqueta[10] = _lblEtiqueta_10;
			this.lblEtiqueta[9] = _lblEtiqueta_9;
			this.lblEtiqueta[8] = _lblEtiqueta_8;
			this.lblEtiqueta[7] = _lblEtiqueta_7;
			this.lblEtiqueta[6] = _lblEtiqueta_6;
			this.lblEtiqueta[5] = _lblEtiqueta_5;
			this.lblEtiqueta[3] = _lblEtiqueta_3;
			this.lblEtiqueta[2] = _lblEtiqueta_2;
			this.lblEtiqueta[4] = _lblEtiqueta_4;
			this.lblEtiqueta[27] = _lblEtiqueta_27;
			this.lblEtiqueta[21] = _lblEtiqueta_21;
			this.lblEtiqueta[22] = _lblEtiqueta_22;
			this.lblEtiqueta[40] = _lblEtiqueta_40;
			this.lblEtiqueta[38] = _lblEtiqueta_38;
			this.lblEtiqueta[29] = _lblEtiqueta_29;
			this.lblEtiqueta[28] = _lblEtiqueta_28;
			this.lblEtiqueta[32] = _lblEtiqueta_32;
			this.lblEtiqueta[31] = _lblEtiqueta_31;
			this.lblEtiqueta[30] = _lblEtiqueta_30;
			this.lblEtiqueta[36] = _lblEtiqueta_36;
			this.lblEtiqueta[35] = _lblEtiqueta_35;
			this.lblEtiqueta[33] = _lblEtiqueta_33;
	}
	void  InitializetxtTexto_Cat()
	{
			this.txtTexto_Cat[1] = _txtTexto_Cat_1;
			this.txtTexto_Cat[0] = _txtTexto_Cat_0;
	}
	void  InitializefrmFrame()
	{
			this.frmFrame[0] = _frmFrame_0;
			this.frmFrame[1] = _frmFrame_1;
			this.frmFrame[2] = _frmFrame_2;
			this.frmFrame[3] = _frmFrame_3;
			this.frmFrame[4] = _frmFrame_4;
			this.frmFrame[5] = _frmFrame_5;
	}
	void  InitializetxtTexto()
	{
			this.txtTexto[1] = _txtTexto_1;
			this.txtTexto[0] = _txtTexto_0;
			this.txtTexto[3] = _txtTexto_3;
			this.txtTexto[2] = _txtTexto_2;
	}
	void  InitializeLST_REPO()
	{
			this.LST_REPO[0] = _LST_REPO_0;
	}
	void  InitializeFRAM_REP()
	{
			this.FRAM_REP[0] = _FRAM_REP_0;
	}
	void  InitializecmbCombo()
	{
			this.cmbCombo[0] = _cmbCombo_0;
	}
	void  InitializetxtTexto_Rep()
	{
			this.txtTexto_Rep[0] = _txtTexto_Rep_0;
			this.txtTexto_Rep[1] = _txtTexto_Rep_1;
	}
	void  InitializemkbMaskebox_Rep()
	{
			this.mkbMaskebox_Rep[0] = _mkbMaskebox_Rep_0;
			this.mkbMaskebox_Rep[1] = _mkbMaskebox_Rep_1;
			this.mkbMaskebox_Rep[2] = _mkbMaskebox_Rep_2;
	}
	void  InitializemkbMaskebox_Cat()
	{
			this.mkbMaskebox_Cat[0] = _mkbMaskebox_Cat_0;
			this.mkbMaskebox_Cat[1] = _mkbMaskebox_Cat_1;
			this.mkbMaskebox_Cat[2] = _mkbMaskebox_Cat_2;
			this.mkbMaskebox_Cat[3] = _mkbMaskebox_Cat_3;
			this.mkbMaskebox_Cat[4] = _mkbMaskebox_Cat_4;
	}
	void  InitializemkbMaskebox()
	{
			this.mkbMaskebox[0] = _mkbMaskebox_0;
			this.mkbMaskebox[1] = _mkbMaskebox_1;
			this.mkbMaskebox[2] = _mkbMaskebox_2;
			this.mkbMaskebox[3] = _mkbMaskebox_3;
			this.mkbMaskebox[4] = _mkbMaskebox_4;
			this.mkbMaskebox[5] = _mkbMaskebox_5;
			this.mkbMaskebox[6] = _mkbMaskebox_6;
			this.mkbMaskebox[7] = _mkbMaskebox_7;
			this.mkbMaskebox[8] = _mkbMaskebox_8;
			this.mkbMaskebox[9] = _mkbMaskebox_9;
			this.mkbMaskebox[10] = _mkbMaskebox_10;
			this.mkbMaskebox[11] = _mkbMaskebox_11;
			this.mkbMaskebox[12] = _mkbMaskebox_12;
			this.mkbMaskebox[13] = _mkbMaskebox_13;
			this.mkbMaskebox[15] = _mkbMaskebox_15;
			this.mkbMaskebox[16] = _mkbMaskebox_16;
	}
	void  InitializePAN_REP()
	{
			this.PAN_REP[0] = _PAN_REP_0;
			this.PAN_REP[1] = _PAN_REP_1;
			this.PAN_REP[2] = _PAN_REP_2;
			this.PAN_REP[3] = _PAN_REP_3;
			this.PAN_REP[4] = _PAN_REP_4;
			this.PAN_REP[5] = _PAN_REP_5;
			this.PAN_REP[6] = _PAN_REP_6;
			this.PAN_REP[7] = _PAN_REP_7;
			this.PAN_REP[9] = _PAN_REP_9;
			this.PAN_REP[8] = _PAN_REP_8;
	}
	void  InitializetabStab()
	{
			this.tabStab[0] = _tabStab_0;
	}
#endregion 
}
}