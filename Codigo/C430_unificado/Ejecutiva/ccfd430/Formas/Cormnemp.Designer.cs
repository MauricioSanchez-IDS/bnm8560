using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORMNEMP
	{
	
#region "Upgrade Support "
		private static CORMNEMP m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORMNEMP DefInstance
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
		public CORMNEMP():base(){
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
			InitializeID_MEM_DOM_PNL();
			InitializeID_MEM_TPA_3OPB();
			InitializeID_MEM_TEX_PNL();
			InitializeID_MEM_ETT_PNL();
			InitializeID_MEM_CIU_EB();
			InitializeID_MEM_REP_PNL();
			InitializefraDatosAdicionales();
			InitializeID_MEM_COL_EB();
			InitializeID_MEM_EEC_3OPB();
			InitializeID_MEM_EDO_EB();
			InitializeID_MEM_CP_PIC();
			InitializeID_MEM_NO_BORRAR();
			InitializeID_MEM_EXT_PIC();
			InitializeID_MEM_ETT_TXT();
			InitializeoptTipoProducto();
			InitializeID_MEM_MES_FIS_LBL();
			InitializeID_MEM_PDM_EB();
            //InitializeoptEmpresa();
			InitializechkCheckBox();
			InitializeID_MEM_EMAIL_LBL();
			InitializeID_MEM_TFA_3OPB();
			InitializeID_MEM_FEC_VEN_LBL();
			InitializeID_MEM_ETT_LBL();
			InitializeID_MEM_FAX_MKE();
			InitializeID_MEM_TEL_MKE();
			InitializeID_MEE_ETT_TXT();
			InitializeID_MEM_LADA_LBL();
			InitializeID_MEM_NOM_EB();
			InitializeID_MEM_REP_3OD();
			InitializeID_MEM_DOM_EB();
			InitializeID_MEM_FAX_LBL();
			InitializeID_MEM_INTER_LBL();
			InitializeID_MEM_PUE_EB();
			ID_MEM_DG_SSPPreviousTab = ID_MEM_DG_SSP.SelectedIndex;
		}
	public static CORMNEMP CreateInstance()
	{
			CORMNEMP theInstance = new CORMNEMP();
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
	public  System.Windows.Forms.Button ID_MEM_OK_PB;
	public  System.Windows.Forms.Button ID_MEM_CAN_PB;
	public  System.Windows.Forms.Button ID_MEM_IMP_PB;
        public AxMSMask.AxMaskEdBox ID_MEM_CLI_MKE;
        public System.Windows.Forms.ComboBox ID_MEM_SEC_COB;
        public AxMSMask.AxMaskEdBox ID_MEM_RFC_MKE;
	public  System.Windows.Forms.TextBox ID_MEM_NLG_EB;
	public  System.Windows.Forms.TextBox ID_MEM_PAC_EB;
        public System.Windows.Forms.TextBox ID_MEM_NCT_EB;
        public AxMSMask.AxMaskEdBox mskDiaCorte;
        private System.Windows.Forms.Label _ID_MEM_ETT_TXT_36;
        private System.Windows.Forms.Label _ID_MEM_ETT_TXT_38;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_6;
        private System.Windows.Forms.Label _ID_MEM_ETT_TXT_7;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_4;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_3;
        private System.Windows.Forms.Label _ID_MEM_ETT_TXT_2;
	public  System.Windows.Forms.GroupBox ID_MEM_DGR_FRM;
	private  System.Windows.Forms.Label _ID_MEM_ETT_PNL_2;
	private  System.Windows.Forms.Label _ID_MEM_ETT_PNL_1;
	private  System.Windows.Forms.Label _ID_MEM_ETT_PNL_0;
	private  System.Windows.Forms.Label _ID_MEM_TEX_PNL_2;
	private  System.Windows.Forms.Label _ID_MEM_TEX_PNL_1;
	private  System.Windows.Forms.Label _ID_MEM_TEX_PNL_0;
	private  System.Windows.Forms.Label _ID_MEM_TEX_PNL_3;
	public  System.Windows.Forms.GroupBox ID_MEM_CTA_FRM;
	private  System.Windows.Forms.TabPage _ID_MEM_DG_SSP_TabPage0;
	private  System.Windows.Forms.ComboBox _ID_MEM_EDO_EB_1;
	private  System.Windows.Forms.TextBox _ID_MEM_CIU_EB_1;
	private  System.Windows.Forms.TextBox _ID_MEM_PDM_EB_1;
	private  System.Windows.Forms.TextBox _ID_MEM_COL_EB_1;
	private  System.Windows.Forms.TextBox _ID_MEM_DOM_EB_1;
	private  System.Windows.Forms.Button _ID_MEM_NO_BORRAR_0;
	private  AxMSMask.AxMaskEdBox _ID_MEM_CP_PIC_1;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_24;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_25;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_26;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_27;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_28;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_29;
	private  System.Windows.Forms.GroupBox _ID_MEM_DOM_PNL_1;
	private  System.Windows.Forms.ComboBox _ID_MEM_EDO_EB_0;
	private  System.Windows.Forms.TextBox _ID_MEM_CIU_EB_0;
	private  System.Windows.Forms.TextBox _ID_MEM_PDM_EB_0;
	private  System.Windows.Forms.TextBox _ID_MEM_COL_EB_0;
	private  System.Windows.Forms.TextBox _ID_MEM_DOM_EB_0;
	private  AxMSMask.AxMaskEdBox _ID_MEM_CP_PIC_0;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_9;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_10;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_14;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_13;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_12;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_15;
	private  System.Windows.Forms.GroupBox _ID_MEM_DOM_PNL_0;
	private  System.Windows.Forms.TabPage _ID_MEM_DG_SSP_TabPage1;
	public  System.Windows.Forms.Button ID_MEM_BOR_PB;
	public  System.Windows.Forms.Button ID_MEM_FIR_PB;
	private  System.Windows.Forms.RadioButton _ID_MEM_REP_3OD_1;
	private  System.Windows.Forms.RadioButton _ID_MEM_REP_3OD_2;
	private  System.Windows.Forms.RadioButton _ID_MEM_REP_3OD_0;
	private  System.Windows.Forms.TextBox _ID_MEM_NOM_EB_0;
	private  System.Windows.Forms.TextBox _ID_MEM_PUE_EB_0;
	private  AxMSMask.AxMaskEdBox _ID_MEM_FAX_MKE_0;
	private  AxMSMask.AxMaskEdBox _ID_MEM_TEL_MKE_0;
	private  AxMSMask.AxMaskEdBox _ID_MEM_EXT_PIC_0;
	public  System.Windows.Forms.Label ID_MEM_REP1_LB;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_18;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_19;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_17;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_16;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_20;
	private  System.Windows.Forms.GroupBox _ID_MEM_REP_PNL_0;
	private  System.Windows.Forms.TextBox _ID_MEM_NOM_EB_2;
	private  System.Windows.Forms.TextBox _ID_MEM_PUE_EB_2;
	private  AxMSMask.AxMaskEdBox _ID_MEM_TEL_MKE_2;
	private  AxMSMask.AxMaskEdBox _ID_MEM_EXT_PIC_2;
	private  AxMSMask.AxMaskEdBox _ID_MEM_FAX_MKE_2;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_34;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_33;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_32;
        private System.Windows.Forms.Label _ID_MEM_ETT_TXT_31;
	public  System.Windows.Forms.Label ID_MEM_REP_LB;
	private  System.Windows.Forms.GroupBox _ID_MEM_REP_PNL_2;
	private  System.Windows.Forms.TextBox _ID_MEM_NOM_EB_1;
	private  System.Windows.Forms.TextBox _ID_MEM_PUE_EB_1;
	private  AxMSMask.AxMaskEdBox _ID_MEM_EXT_PIC_1;
	private  AxMSMask.AxMaskEdBox _ID_MEM_TEL_MKE_1;
	private  AxMSMask.AxMaskEdBox _ID_MEM_FAX_MKE_1;
	public  System.Windows.Forms.Label ID_MEM_REP2_LB;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_22;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_11;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_1;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_0;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_21;
	private  System.Windows.Forms.GroupBox _ID_MEM_REP_PNL_1;
        public System.Windows.Forms.GroupBox ID_MEM_REP_FRM;
        private System.Windows.Forms.TabPage _ID_MEM_DG_SSP_TabPage2;
	private  System.Windows.Forms.Button _ID_MEM_NO_BORRAR_2;
	public  System.Windows.Forms.TextBox ID_MEM_NNA_EB;
	public  System.Windows.Forms.Button ID_MEM_BUS_PB;
    public System.Windows.Forms.ComboBox ID_MEM_NOM_COB;
    //public System.Windows.Forms.ComboBox CboSucPromotora;
    private System.Windows.Forms.Label _ID_MEM_ETT_PNL_7;
	private  System.Windows.Forms.Label _ID_MEM_ETT_PNL_8;
    private System.Windows.Forms.Label _ID_MEM_ETT_TXT_35;
	public  System.Windows.Forms.GroupBox ID_MEM_EJE_FRM;
	public  System.Windows.Forms.TextBox ID_MEM_FAX_LADA_TXT;
	public  System.Windows.Forms.TextBox ID_MEM_TEL_EXT_TXT;
	public  System.Windows.Forms.TextBox ID_MEM_CON_TXT;
	public  System.Windows.Forms.TextBox ID_MEM_INTER_TXT;
	public  System.Windows.Forms.TextBox ID_MEM_EMAIL_TXT;
	public  System.Windows.Forms.TextBox ID_MEM_FAX_TXT;
	public  System.Windows.Forms.TextBox ID_MEM_LADA_TXT;
	public  System.Windows.Forms.Label ID_MEM_FAXL_LB;
	public  System.Windows.Forms.Label ID_MEM_EXT_LB;
	private  System.Windows.Forms.Label _ID_MEM_ETT_LBL_23;
	private  System.Windows.Forms.Label _ID_MEM_FAX_LBL_38;
	private  System.Windows.Forms.Label _ID_MEM_EMAIL_LBL_44;
	private  System.Windows.Forms.Label _ID_MEM_INTER_LBL_45;
	private  System.Windows.Forms.Label _ID_MEM_LADA_LBL_36;
	public  System.Windows.Forms.GroupBox ID_MEM_TEL_FRM;
	private  System.Windows.Forms.TabPage _ID_MEM_DG_SSP_TabPage3;
	private  System.Windows.Forms.Label _ID_MEM_MES_FIS_LBL_0;
        private System.Windows.Forms.Label _ID_MEM_ETT_TXT_39;
        private System.Windows.Forms.RadioButton _ID_MEM_TFA_3OPB_0;
        private System.Windows.Forms.GroupBox _fraDatosAdicionales_3;
    private System.Windows.Forms.RadioButton _ID_MEM_EEC_3OPB_0;
    private System.Windows.Forms.RadioButton _ID_MEM_EEC_3OPB_1;
        private System.Windows.Forms.GroupBox _fraDatosAdicionales_0;
	public  System.Windows.Forms.ComboBox ID_MEM_MES_FIS_CBO;
	public  System.Windows.Forms.ComboBox cboEstructuraGastos;
	public  AxMSMask.AxMaskEdBox ID_MEM_SUC_ITB;
	public  AxMSMask.AxMaskEdBox ID_MEM_NMC_FTB;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_40;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_41;
        public System.Windows.Forms.GroupBox ID_MEM_CEJ_FRM;
	private  System.Windows.Forms.TabPage _ID_MEM_DG_SSP_TabPage4;
	public  System.Windows.Forms.TabControl ID_MEM_DG_SSP;
	public System.Windows.Forms.Label[] ID_MEE_ETT_TXT = new System.Windows.Forms.Label[10];
	public System.Windows.Forms.TextBox[] ID_MEM_CIU_EB = new System.Windows.Forms.TextBox[2];
	public System.Windows.Forms.TextBox[] ID_MEM_COL_EB = new System.Windows.Forms.TextBox[2];
	public AxMSMask.AxMaskEdBox[] ID_MEM_CP_PIC = new AxMSMask.AxMaskEdBox[2];
	public System.Windows.Forms.TextBox[] ID_MEM_DOM_EB = new System.Windows.Forms.TextBox[2];
	public System.Windows.Forms.GroupBox[] ID_MEM_DOM_PNL = new System.Windows.Forms.GroupBox[2];
	public System.Windows.Forms.ComboBox[] ID_MEM_EDO_EB = new System.Windows.Forms.ComboBox[2];
        public System.Windows.Forms.RadioButton[] ID_MEM_EEC_3OPB = new System.Windows.Forms.RadioButton[2];
	public System.Windows.Forms.Label[] ID_MEM_EMAIL_LBL = new System.Windows.Forms.Label[45];
	public System.Windows.Forms.Label[] ID_MEM_ETT_LBL = new System.Windows.Forms.Label[24];
        public System.Windows.Forms.Label[] ID_MEM_ETT_PNL = new System.Windows.Forms.Label[9];
	public System.Windows.Forms.Label[] ID_MEM_ETT_TXT = new System.Windows.Forms.Label[42];
	public AxMSMask.AxMaskEdBox[] ID_MEM_EXT_PIC = new AxMSMask.AxMaskEdBox[3];
	public System.Windows.Forms.Label[] ID_MEM_FAX_LBL = new System.Windows.Forms.Label[39];
	public AxMSMask.AxMaskEdBox[] ID_MEM_FAX_MKE = new AxMSMask.AxMaskEdBox[3];
	public System.Windows.Forms.Label[] ID_MEM_FEC_VEN_LBL = new System.Windows.Forms.Label[37];
	public System.Windows.Forms.Label[] ID_MEM_INTER_LBL = new System.Windows.Forms.Label[46];
	public System.Windows.Forms.Label[] ID_MEM_LADA_LBL = new System.Windows.Forms.Label[37];
	public System.Windows.Forms.Label[] ID_MEM_MES_FIS_LBL = new System.Windows.Forms.Label[5];
	public System.Windows.Forms.TextBox[] ID_MEM_NOM_EB = new System.Windows.Forms.TextBox[3];
	public System.Windows.Forms.Button[] ID_MEM_NO_BORRAR = new System.Windows.Forms.Button[3];
	public System.Windows.Forms.TextBox[] ID_MEM_PDM_EB = new System.Windows.Forms.TextBox[2];
	public System.Windows.Forms.TextBox[] ID_MEM_PUE_EB = new System.Windows.Forms.TextBox[3];
	public System.Windows.Forms.RadioButton[] ID_MEM_REP_3OD = new System.Windows.Forms.RadioButton[3];
	public System.Windows.Forms.GroupBox[] ID_MEM_REP_PNL = new System.Windows.Forms.GroupBox[3];
	public AxMSMask.AxMaskEdBox[] ID_MEM_TEL_MKE = new AxMSMask.AxMaskEdBox[3];
	public System.Windows.Forms.Label[] ID_MEM_TEX_PNL = new System.Windows.Forms.Label[4];
    public System.Windows.Forms.RadioButton[] ID_MEM_TFA_3OPB = new System.Windows.Forms.RadioButton[2];
	public System.Windows.Forms.RadioButton[] ID_MEM_TPA_3OPB = new System.Windows.Forms.RadioButton[3];
	public System.Windows.Forms.CheckBox[] chkCheckBox = new System.Windows.Forms.CheckBox[3];
	public System.Windows.Forms.GroupBox[] fraDatosAdicionales = new System.Windows.Forms.GroupBox[5];
	public System.Windows.Forms.RadioButton[] optEmpresa = new System.Windows.Forms.RadioButton[3];
	public System.Windows.Forms.RadioButton[] optTipoProducto = new System.Windows.Forms.RadioButton[3];
	private Artinsoft.VB6.Gui.ListControlHelper ListBoxComboBoxHelper1;
	private int ID_MEM_DG_SSPPreviousTab;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORMNEMP));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_MEM_OK_PB = new System.Windows.Forms.Button();
            this.ID_MEM_CAN_PB = new System.Windows.Forms.Button();
            this.ID_MEM_IMP_PB = new System.Windows.Forms.Button();
            this.ID_MEM_DG_SSP = new System.Windows.Forms.TabControl();
            this._ID_MEM_DG_SSP_TabPage0 = new System.Windows.Forms.TabPage();
            this.axgear2 = new AxGEARLib.AxGear();
            this.ID_MEM_DGR_FRM = new System.Windows.Forms.GroupBox();
            this.mskNumEmp = new AxMSMask.AxMaskEdBox();
            this.label2 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_38 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_36 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_2 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_3 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_4 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_6 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_7 = new System.Windows.Forms.Label();
            this.ID_MEM_RFC_MKE = new AxMSMask.AxMaskEdBox();
            this.ID_MEM_CLI_MKE = new AxMSMask.AxMaskEdBox();
            this.ID_MEM_SEC_COB = new System.Windows.Forms.ComboBox();
            this.mskDiaCorte = new AxMSMask.AxMaskEdBox();
            this.ID_MEM_NLG_EB = new System.Windows.Forms.TextBox();
            this.ID_MEM_PAC_EB = new System.Windows.Forms.TextBox();
            this.ID_MEM_NCT_EB = new System.Windows.Forms.TextBox();
            this.ID_MEM_CTA_FRM = new System.Windows.Forms.GroupBox();
            this._ID_MEM_TEX_PNL_2 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_PNL_2 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_PNL_0 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_PNL_1 = new System.Windows.Forms.Label();
            this._ID_MEM_TEX_PNL_1 = new System.Windows.Forms.Label();
            this._ID_MEM_TEX_PNL_3 = new System.Windows.Forms.Label();
            this._ID_MEM_TEX_PNL_0 = new System.Windows.Forms.Label();
            this._ID_MEM_DG_SSP_TabPage1 = new System.Windows.Forms.TabPage();
            this._ID_MEM_DOM_PNL_1 = new System.Windows.Forms.GroupBox();
            this._ID_MEM_CP_PIC_1 = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_ETT_TXT_24 = new System.Windows.Forms.Label();
            this._ID_MEM_NO_BORRAR_0 = new System.Windows.Forms.Button();
            this._ID_MEM_COL_EB_1 = new System.Windows.Forms.TextBox();
            this._ID_MEM_DOM_EB_1 = new System.Windows.Forms.TextBox();
            this._ID_MEM_ETT_TXT_28 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_29 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_27 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_25 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_26 = new System.Windows.Forms.Label();
            this._ID_MEM_EDO_EB_1 = new System.Windows.Forms.ComboBox();
            this._ID_MEM_CIU_EB_1 = new System.Windows.Forms.TextBox();
            this._ID_MEM_PDM_EB_1 = new System.Windows.Forms.TextBox();
            this._ID_MEM_DOM_PNL_0 = new System.Windows.Forms.GroupBox();
            this._ID_MEM_CP_PIC_0 = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_ETT_TXT_9 = new System.Windows.Forms.Label();
            this._ID_MEM_COL_EB_0 = new System.Windows.Forms.TextBox();
            this._ID_MEM_DOM_EB_0 = new System.Windows.Forms.TextBox();
            this._ID_MEM_ETT_TXT_10 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_12 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_15 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_14 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_13 = new System.Windows.Forms.Label();
            this._ID_MEM_PDM_EB_0 = new System.Windows.Forms.TextBox();
            this._ID_MEM_EDO_EB_0 = new System.Windows.Forms.ComboBox();
            this._ID_MEM_CIU_EB_0 = new System.Windows.Forms.TextBox();
            this._ID_MEM_DG_SSP_TabPage2 = new System.Windows.Forms.TabPage();
            this._ID_MEM_REP_3OD_2 = new System.Windows.Forms.RadioButton();
            this.ID_MEM_REP_FRM = new System.Windows.Forms.GroupBox();
            this.ID_MEM_FIR_PB = new System.Windows.Forms.Button();
            this._ID_MEM_REP_PNL_0 = new System.Windows.Forms.GroupBox();
            this._ID_MEM_NOM_EB_0 = new System.Windows.Forms.TextBox();
            this._ID_MEM_ETT_TXT_18 = new System.Windows.Forms.Label();
            this.ID_MEM_REP1_LB = new System.Windows.Forms.Label();
            this._ID_MEM_TEL_MKE_0 = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_EXT_PIC_0 = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_PUE_EB_0 = new System.Windows.Forms.TextBox();
            this._ID_MEM_FAX_MKE_0 = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_ETT_TXT_19 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_16 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_20 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_17 = new System.Windows.Forms.Label();
            this._ID_MEM_REP_PNL_1 = new System.Windows.Forms.GroupBox();
            this._ID_MEM_NOM_EB_1 = new System.Windows.Forms.TextBox();
            this._ID_MEM_ETT_TXT_22 = new System.Windows.Forms.Label();
            this.ID_MEM_REP2_LB = new System.Windows.Forms.Label();
            this._ID_MEM_TEL_MKE_1 = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_FAX_MKE_1 = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_PUE_EB_1 = new System.Windows.Forms.TextBox();
            this._ID_MEM_EXT_PIC_1 = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_ETT_TXT_11 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_0 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_21 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_1 = new System.Windows.Forms.Label();
            this._ID_MEM_REP_PNL_2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this._ID_MEM_NOM_EB_2 = new System.Windows.Forms.TextBox();
            this._ID_MEM_ETT_TXT_33 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_34 = new System.Windows.Forms.Label();
            this._ID_MEM_EXT_PIC_2 = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_FAX_MKE_2 = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_PUE_EB_2 = new System.Windows.Forms.TextBox();
            this._ID_MEM_TEL_MKE_2 = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_ETT_TXT_32 = new System.Windows.Forms.Label();
            this.ID_MEM_REP_LB = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_31 = new System.Windows.Forms.Label();
            this.ID_MEM_BOR_PB = new System.Windows.Forms.Button();
            this._ID_MEM_REP_3OD_1 = new System.Windows.Forms.RadioButton();
            this._ID_MEM_REP_3OD_0 = new System.Windows.Forms.RadioButton();
            this._ID_MEM_DG_SSP_TabPage3 = new System.Windows.Forms.TabPage();
            this.ID_MEM_EJE_FRM = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CmdAgregarSucursal = new System.Windows.Forms.Button();
            this.TbSucursalStatus = new System.Windows.Forms.TextBox();
            this.CboSucPromotora = new System.Windows.Forms.ComboBox();
            this.ID_MEM_NOM_COB = new System.Windows.Forms.ComboBox();
            this.ID_MEM_BUS_PB = new System.Windows.Forms.Button();
            this.ID_MEM_NNA_EB = new System.Windows.Forms.TextBox();
            this._ID_MEM_ETT_TXT_35 = new System.Windows.Forms.Label();
            this._ID_MEM_NO_BORRAR_2 = new System.Windows.Forms.Button();
            this._ID_MEM_ETT_PNL_7 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_PNL_8 = new System.Windows.Forms.Label();
            this.ID_MEM_NOM_TXT = new System.Windows.Forms.Label();
            this.ID_MEM_TEL_FRM = new System.Windows.Forms.GroupBox();
            this.ID_MEM_FAXL_LB = new System.Windows.Forms.Label();
            this.ID_MEM_EXT_LB = new System.Windows.Forms.Label();
            this.ID_MEM_LADA_TXT = new System.Windows.Forms.TextBox();
            this.ID_MEM_EMAIL_TXT = new System.Windows.Forms.TextBox();
            this.ID_MEM_FAX_TXT = new System.Windows.Forms.TextBox();
            this._ID_MEM_INTER_LBL_45 = new System.Windows.Forms.Label();
            this._ID_MEM_LADA_LBL_36 = new System.Windows.Forms.Label();
            this._ID_MEM_EMAIL_LBL_44 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_LBL_23 = new System.Windows.Forms.Label();
            this._ID_MEM_FAX_LBL_38 = new System.Windows.Forms.Label();
            this.ID_MEM_INTER_TXT = new System.Windows.Forms.TextBox();
            this.ID_MEM_FAX_LADA_TXT = new System.Windows.Forms.TextBox();
            this.ID_MEM_TEL_EXT_TXT = new System.Windows.Forms.TextBox();
            this.ID_MEM_CON_TXT = new System.Windows.Forms.TextBox();
            this._ID_MEM_DG_SSP_TabPage4 = new System.Windows.Forms.TabPage();
            this.mskMCC = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_MES_FIS_LBL_1 = new System.Windows.Forms.Label();
            this._fraDatosAdicionales_0 = new System.Windows.Forms.GroupBox();
            this._ID_MEM_EEC_3OPB_0 = new System.Windows.Forms.RadioButton();
            this._ID_MEM_EEC_3OPB_1 = new System.Windows.Forms.RadioButton();
            this.ID_MEM_MES_FIS_CBO = new System.Windows.Forms.ComboBox();
            this.ID_MEM_CEJ_FRM = new System.Windows.Forms.GroupBox();
            this.ID_MEM_NMC_FTB = new AxMSMask.AxMaskEdBox();
            this.ID_MEM_SUC_ITB = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_ETT_TXT_41 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_40 = new System.Windows.Forms.Label();
            this.cboEstructuraGastos = new System.Windows.Forms.ComboBox();
            this._ID_MEM_ETT_TXT_39 = new System.Windows.Forms.Label();
            this._ID_MEM_MES_FIS_LBL_0 = new System.Windows.Forms.Label();
            this._fraDatosAdicionales_3 = new System.Windows.Forms.GroupBox();
            this._ID_MEM_TFA_3OPB_0 = new System.Windows.Forms.RadioButton();
            this.ListBoxComboBoxHelper1 = new Artinsoft.VB6.Gui.ListControlHelper(this.components);
            this.axgear3 = new AxGEARLib.AxGear();
            this.axgear1 = new AxGEARLib.AxGear();
            this.ID_MEM_DG_SSP.SuspendLayout();
            this._ID_MEM_DG_SSP_TabPage0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axgear2)).BeginInit();
            this.ID_MEM_DGR_FRM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mskNumEmp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEM_RFC_MKE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEM_CLI_MKE)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mskDiaCorte)).BeginInit();
            this.ID_MEM_CTA_FRM.SuspendLayout();
            this._ID_MEM_DG_SSP_TabPage1.SuspendLayout();
            this._ID_MEM_DOM_PNL_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_CP_PIC_1)).BeginInit();
            this._ID_MEM_DOM_PNL_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_CP_PIC_0)).BeginInit();
            this._ID_MEM_DG_SSP_TabPage2.SuspendLayout();
            this.ID_MEM_REP_FRM.SuspendLayout();
            this._ID_MEM_REP_PNL_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_TEL_MKE_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_EXT_PIC_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_FAX_MKE_0)).BeginInit();
            this._ID_MEM_REP_PNL_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_TEL_MKE_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_FAX_MKE_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_EXT_PIC_1)).BeginInit();
            this._ID_MEM_REP_PNL_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_EXT_PIC_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_FAX_MKE_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_TEL_MKE_2)).BeginInit();
            this._ID_MEM_DG_SSP_TabPage3.SuspendLayout();
            this.ID_MEM_EJE_FRM.SuspendLayout();
            this.ID_MEM_TEL_FRM.SuspendLayout();
            this._ID_MEM_DG_SSP_TabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mskMCC)).BeginInit();
            this._fraDatosAdicionales_0.SuspendLayout();
            this.ID_MEM_CEJ_FRM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEM_NMC_FTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEM_SUC_ITB)).BeginInit();
            this._fraDatosAdicionales_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axgear3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.axgear1)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_MEM_OK_PB
            // 
            this.ID_MEM_OK_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEM_OK_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_OK_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEM_OK_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_OK_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEM_OK_PB.Location = new System.Drawing.Point(112, 393);
            this.ID_MEM_OK_PB.Name = "ID_MEM_OK_PB";
            this.ID_MEM_OK_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_OK_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEM_OK_PB.TabIndex = 139;
            this.ID_MEM_OK_PB.Tag = "";
            this.ID_MEM_OK_PB.Text = "Aceptar";
            this.ID_MEM_OK_PB.UseVisualStyleBackColor = false;
            this.ID_MEM_OK_PB.Click += new System.EventHandler(this.ID_MEM_OK_PB_Click);
            this.ID_MEM_OK_PB.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ID_MEM_OK_PB_MouseDown);
            // 
            // ID_MEM_CAN_PB
            // 
            this.ID_MEM_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEM_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_MEM_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEM_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEM_CAN_PB.Location = new System.Drawing.Point(289, 393);
            this.ID_MEM_CAN_PB.Name = "ID_MEM_CAN_PB";
            this.ID_MEM_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_CAN_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEM_CAN_PB.TabIndex = 140;
            this.ID_MEM_CAN_PB.Tag = "";
            this.ID_MEM_CAN_PB.Text = "Cancelar";
            this.ID_MEM_CAN_PB.UseVisualStyleBackColor = false;
            this.ID_MEM_CAN_PB.Click += new System.EventHandler(this.ID_MEM_CAN_PB_Click);
            // 
            // ID_MEM_IMP_PB
            // 
            this.ID_MEM_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEM_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEM_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEM_IMP_PB.Location = new System.Drawing.Point(457, 393);
            this.ID_MEM_IMP_PB.Name = "ID_MEM_IMP_PB";
            this.ID_MEM_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_IMP_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEM_IMP_PB.TabIndex = 141;
            this.ID_MEM_IMP_PB.Tag = "";
            this.ID_MEM_IMP_PB.Text = "&Imprimir";
            this.ID_MEM_IMP_PB.UseVisualStyleBackColor = false;
            this.ID_MEM_IMP_PB.Click += new System.EventHandler(this.ID_MEM_IMP_PB_Click);
            // 
            // ID_MEM_DG_SSP
            // 
            this.ID_MEM_DG_SSP.Controls.Add(this._ID_MEM_DG_SSP_TabPage0);
            this.ID_MEM_DG_SSP.Controls.Add(this._ID_MEM_DG_SSP_TabPage1);
            this.ID_MEM_DG_SSP.Controls.Add(this._ID_MEM_DG_SSP_TabPage2);
            this.ID_MEM_DG_SSP.Controls.Add(this._ID_MEM_DG_SSP_TabPage3);
            this.ID_MEM_DG_SSP.Controls.Add(this._ID_MEM_DG_SSP_TabPage4);
            this.ID_MEM_DG_SSP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_DG_SSP.ItemSize = new System.Drawing.Size(123, 18);
            this.ID_MEM_DG_SSP.Location = new System.Drawing.Point(12, 12);
            this.ID_MEM_DG_SSP.Multiline = true;
            this.ID_MEM_DG_SSP.Name = "ID_MEM_DG_SSP";
            this.ID_MEM_DG_SSP.SelectedIndex = 0;
            this.ID_MEM_DG_SSP.Size = new System.Drawing.Size(626, 374);
            this.ID_MEM_DG_SSP.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.ID_MEM_DG_SSP.TabIndex = 3;
            this.ID_MEM_DG_SSP.Tag = "";
            this.ID_MEM_DG_SSP.SelectedIndexChanged += new System.EventHandler(this.ID_MEM_DG_SSP_SelectedIndexChanged);
            // 
            // _ID_MEM_DG_SSP_TabPage0
            // 
            this._ID_MEM_DG_SSP_TabPage0.BackColor = System.Drawing.Color.Transparent;
            this._ID_MEM_DG_SSP_TabPage0.Controls.Add(this.axgear2);
            this._ID_MEM_DG_SSP_TabPage0.Controls.Add(this.ID_MEM_DGR_FRM);
            this._ID_MEM_DG_SSP_TabPage0.Controls.Add(this.ID_MEM_CTA_FRM);
            this._ID_MEM_DG_SSP_TabPage0.Location = new System.Drawing.Point(4, 22);
            this._ID_MEM_DG_SSP_TabPage0.Name = "_ID_MEM_DG_SSP_TabPage0";
            this._ID_MEM_DG_SSP_TabPage0.Size = new System.Drawing.Size(618, 348);
            this._ID_MEM_DG_SSP_TabPage0.TabIndex = 1;
            this._ID_MEM_DG_SSP_TabPage0.Tag = "";
            this._ID_MEM_DG_SSP_TabPage0.Text = "Datos Generales";
            this._ID_MEM_DG_SSP_TabPage0.UseVisualStyleBackColor = true;
            // 
            // axgear2
            // 
            this.axgear2.Enabled = true;
            this.axgear2.Location = new System.Drawing.Point(259, 149);
            this.axgear2.Name = "axgear2";
            this.axgear2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axgear2.OcxState")));
            this.axgear2.Size = new System.Drawing.Size(100, 50);
            this.axgear2.TabIndex = 2;
            this.axgear2.Visible = false;
            // 
            // ID_MEM_DGR_FRM
            // 
            this.ID_MEM_DGR_FRM.Controls.Add(this.mskNumEmp);
            this.ID_MEM_DGR_FRM.Controls.Add(this.label2);
            this.ID_MEM_DGR_FRM.Controls.Add(this._ID_MEM_ETT_TXT_38);
            this.ID_MEM_DGR_FRM.Controls.Add(this._ID_MEM_ETT_TXT_36);
            this.ID_MEM_DGR_FRM.Controls.Add(this._ID_MEM_ETT_TXT_2);
            this.ID_MEM_DGR_FRM.Controls.Add(this._ID_MEM_ETT_TXT_3);
            this.ID_MEM_DGR_FRM.Controls.Add(this._ID_MEM_ETT_TXT_4);
            this.ID_MEM_DGR_FRM.Controls.Add(this._ID_MEM_ETT_TXT_6);
            this.ID_MEM_DGR_FRM.Controls.Add(this._ID_MEM_ETT_TXT_7);
            this.ID_MEM_DGR_FRM.Controls.Add(this.ID_MEM_RFC_MKE);
            this.ID_MEM_DGR_FRM.Controls.Add(this.ID_MEM_CLI_MKE);
            this.ID_MEM_DGR_FRM.Controls.Add(this.ID_MEM_SEC_COB);
            this.ID_MEM_DGR_FRM.Controls.Add(this.mskDiaCorte);
            this.ID_MEM_DGR_FRM.Controls.Add(this.ID_MEM_NLG_EB);
            this.ID_MEM_DGR_FRM.Controls.Add(this.ID_MEM_PAC_EB);
            this.ID_MEM_DGR_FRM.Controls.Add(this.ID_MEM_NCT_EB);
            this.ID_MEM_DGR_FRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_DGR_FRM.Location = new System.Drawing.Point(13, 109);
            this.ID_MEM_DGR_FRM.Name = "ID_MEM_DGR_FRM";
            this.ID_MEM_DGR_FRM.Size = new System.Drawing.Size(596, 200);
            this.ID_MEM_DGR_FRM.TabIndex = 1;
            this.ID_MEM_DGR_FRM.TabStop = false;
            this.ID_MEM_DGR_FRM.Tag = "";
            // 
            // mskNumEmp
            // 
            this.mskNumEmp.Location = new System.Drawing.Point(163, 38);
            this.mskNumEmp.Name = "mskNumEmp";
            this.mskNumEmp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mskNumEmp.OcxState")));
            this.mskNumEmp.Size = new System.Drawing.Size(82, 22);
            this.mskNumEmp.TabIndex = 1;
            this.mskNumEmp.Tag = "";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(18, 42);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label2.Size = new System.Drawing.Size(128, 15);
            this.label2.TabIndex = 0;
            this.label2.Tag = "";
            this.label2.Text = "Numero Empresa";
            // 
            // _ID_MEM_ETT_TXT_38
            // 
            this._ID_MEM_ETT_TXT_38.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_38.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_38.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_38.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_38.Location = new System.Drawing.Point(416, 131);
            this._ID_MEM_ETT_TXT_38.Name = "_ID_MEM_ETT_TXT_38";
            this._ID_MEM_ETT_TXT_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_38.Size = new System.Drawing.Size(88, 15);
            this._ID_MEM_ETT_TXT_38.TabIndex = 14;
            this._ID_MEM_ETT_TXT_38.Tag = "";
            this._ID_MEM_ETT_TXT_38.Text = "&D�a de Corte";
            this._ID_MEM_ETT_TXT_38.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_MEM_ETT_TXT_36
            // 
            this._ID_MEM_ETT_TXT_36.AutoSize = true;
            this._ID_MEM_ETT_TXT_36.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_36.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_36.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_36.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_36.Location = new System.Drawing.Point(419, 41);
            this._ID_MEM_ETT_TXT_36.Name = "_ID_MEM_ETT_TXT_36";
            this._ID_MEM_ETT_TXT_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_36.Size = new System.Drawing.Size(46, 13);
            this._ID_MEM_ETT_TXT_36.TabIndex = 2;
            this._ID_MEM_ETT_TXT_36.Tag = "";
            this._ID_MEM_ETT_TXT_36.Text = "Cliente";
            this._ID_MEM_ETT_TXT_36.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_MEM_ETT_TXT_2
            // 
            this._ID_MEM_ETT_TXT_2.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_2.Location = new System.Drawing.Point(18, 69);
            this._ID_MEM_ETT_TXT_2.Name = "_ID_MEM_ETT_TXT_2";
            this._ID_MEM_ETT_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_2.Size = new System.Drawing.Size(128, 15);
            this._ID_MEM_ETT_TXT_2.TabIndex = 4;
            this._ID_MEM_ETT_TXT_2.Tag = "";
            this._ID_MEM_ETT_TXT_2.Text = "Nombre &Largo";
            // 
            // _ID_MEM_ETT_TXT_3
            // 
            this._ID_MEM_ETT_TXT_3.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_3.Location = new System.Drawing.Point(18, 98);
            this._ID_MEM_ETT_TXT_3.Name = "_ID_MEM_ETT_TXT_3";
            this._ID_MEM_ETT_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_3.Size = new System.Drawing.Size(128, 17);
            this._ID_MEM_ETT_TXT_3.TabIndex = 8;
            this._ID_MEM_ETT_TXT_3.Tag = "";
            this._ID_MEM_ETT_TXT_3.Text = "Nombre &Corto";
            // 
            // _ID_MEM_ETT_TXT_4
            // 
            this._ID_MEM_ETT_TXT_4.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_4.Location = new System.Drawing.Point(406, 69);
            this._ID_MEM_ETT_TXT_4.Name = "_ID_MEM_ETT_TXT_4";
            this._ID_MEM_ETT_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_4.Size = new System.Drawing.Size(59, 17);
            this._ID_MEM_ETT_TXT_4.TabIndex = 6;
            this._ID_MEM_ETT_TXT_4.Tag = "";
            this._ID_MEM_ETT_TXT_4.Text = "&R.F.C.";
            this._ID_MEM_ETT_TXT_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_MEM_ETT_TXT_6
            // 
            this._ID_MEM_ETT_TXT_6.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_6.Location = new System.Drawing.Point(18, 130);
            this._ID_MEM_ETT_TXT_6.Name = "_ID_MEM_ETT_TXT_6";
            this._ID_MEM_ETT_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_6.Size = new System.Drawing.Size(128, 15);
            this._ID_MEM_ETT_TXT_6.TabIndex = 12;
            this._ID_MEM_ETT_TXT_6.Tag = "";
            this._ID_MEM_ETT_TXT_6.Text = "&Principal Accionista";
            // 
            // _ID_MEM_ETT_TXT_7
            // 
            this._ID_MEM_ETT_TXT_7.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_7.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_7.Location = new System.Drawing.Point(410, 100);
            this._ID_MEM_ETT_TXT_7.Name = "_ID_MEM_ETT_TXT_7";
            this._ID_MEM_ETT_TXT_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_7.Size = new System.Drawing.Size(49, 15);
            this._ID_MEM_ETT_TXT_7.TabIndex = 10;
            this._ID_MEM_ETT_TXT_7.Tag = "";
            this._ID_MEM_ETT_TXT_7.Text = "&Sector";
            this._ID_MEM_ETT_TXT_7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ID_MEM_RFC_MKE
            // 
            this.ID_MEM_RFC_MKE.Location = new System.Drawing.Point(468, 66);
            this.ID_MEM_RFC_MKE.Name = "ID_MEM_RFC_MKE";
            this.ID_MEM_RFC_MKE.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEM_RFC_MKE.OcxState")));
            this.ID_MEM_RFC_MKE.Size = new System.Drawing.Size(116, 22);
            this.ID_MEM_RFC_MKE.TabIndex = 7;
            this.ID_MEM_RFC_MKE.Tag = "";
            this.ID_MEM_RFC_MKE.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_RFC_MKE_KeyPressEvent);
            this.ID_MEM_RFC_MKE.Enter += new System.EventHandler(this.ID_MEM_RFC_MKE_Enter);
            // 
            // ID_MEM_CLI_MKE
            // 
            this.ID_MEM_CLI_MKE.Location = new System.Drawing.Point(468, 37);
            this.ID_MEM_CLI_MKE.Name = "ID_MEM_CLI_MKE";
            this.ID_MEM_CLI_MKE.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEM_CLI_MKE.OcxState")));
            this.ID_MEM_CLI_MKE.Size = new System.Drawing.Size(116, 20);
            this.ID_MEM_CLI_MKE.TabIndex = 3;
            this.ID_MEM_CLI_MKE.Tag = "";
            // 
            // ID_MEM_SEC_COB
            // 
            this.ID_MEM_SEC_COB.BackColor = System.Drawing.Color.White;
            this.ID_MEM_SEC_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_SEC_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_MEM_SEC_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_SEC_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this.ID_MEM_SEC_COB, new int[0]);
            this.ID_MEM_SEC_COB.Location = new System.Drawing.Point(468, 98);
            this.ID_MEM_SEC_COB.Name = "ID_MEM_SEC_COB";
            this.ID_MEM_SEC_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_SEC_COB.Size = new System.Drawing.Size(116, 21);
            this.ID_MEM_SEC_COB.TabIndex = 11;
            this.ID_MEM_SEC_COB.Tag = "";
            // 
            // mskDiaCorte
            // 
            this.mskDiaCorte.Location = new System.Drawing.Point(522, 125);
            this.mskDiaCorte.Name = "mskDiaCorte";
            this.mskDiaCorte.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mskDiaCorte.OcxState")));
            this.mskDiaCorte.Size = new System.Drawing.Size(62, 22);
            this.mskDiaCorte.TabIndex = 15;
            this.mskDiaCorte.Tag = "";
            this.mskDiaCorte.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskDiaCorte_KeyPressEvent);
            this.mskDiaCorte.Enter += new System.EventHandler(this.mskDiaCorte_Enter);
            this.mskDiaCorte.Leave += new System.EventHandler(this.mskDiaCorte_Leave);
            this.mskDiaCorte.Validating += new System.ComponentModel.CancelEventHandler(this.mskDiaCorte_Validating);
            // 
            // ID_MEM_NLG_EB
            // 
            this.ID_MEM_NLG_EB.AcceptsReturn = true;
            this.ID_MEM_NLG_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEM_NLG_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEM_NLG_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_NLG_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEM_NLG_EB.Location = new System.Drawing.Point(163, 66);
            this.ID_MEM_NLG_EB.MaxLength = 45;
            this.ID_MEM_NLG_EB.Name = "ID_MEM_NLG_EB";
            this.ID_MEM_NLG_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_NLG_EB.Size = new System.Drawing.Size(246, 20);
            this.ID_MEM_NLG_EB.TabIndex = 5;
            this.ID_MEM_NLG_EB.Tag = "";
            this.ID_MEM_NLG_EB.Click += new System.EventHandler(this.HandleSelection_Click);
            this.ID_MEM_NLG_EB.TextChanged += new System.EventHandler(this.ID_MEM_NLG_EB_TextChanged);
            this.ID_MEM_NLG_EB.Enter += new System.EventHandler(this.ID_MEM_NLG_EB_Enter);
            this.ID_MEM_NLG_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_NLG_EB_KeyPress);
            this.ID_MEM_NLG_EB.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // ID_MEM_PAC_EB
            // 
            this.ID_MEM_PAC_EB.AcceptsReturn = true;
            this.ID_MEM_PAC_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEM_PAC_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEM_PAC_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_PAC_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEM_PAC_EB.Location = new System.Drawing.Point(163, 127);
            this.ID_MEM_PAC_EB.MaxLength = 35;
            this.ID_MEM_PAC_EB.Name = "ID_MEM_PAC_EB";
            this.ID_MEM_PAC_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_PAC_EB.Size = new System.Drawing.Size(244, 20);
            this.ID_MEM_PAC_EB.TabIndex = 13;
            this.ID_MEM_PAC_EB.Tag = "";
            this.ID_MEM_PAC_EB.Click += new System.EventHandler(this.HandleSelection_Click);
            this.ID_MEM_PAC_EB.Enter += new System.EventHandler(this.ID_MEM_PAC_EB_Enter);
            this.ID_MEM_PAC_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_PAC_EB_KeyPress);
            this.ID_MEM_PAC_EB.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // ID_MEM_NCT_EB
            // 
            this.ID_MEM_NCT_EB.AcceptsReturn = true;
            this.ID_MEM_NCT_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEM_NCT_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEM_NCT_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_NCT_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEM_NCT_EB.Location = new System.Drawing.Point(163, 98);
            this.ID_MEM_NCT_EB.MaxLength = 24;
            this.ID_MEM_NCT_EB.Name = "ID_MEM_NCT_EB";
            this.ID_MEM_NCT_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_NCT_EB.Size = new System.Drawing.Size(246, 20);
            this.ID_MEM_NCT_EB.TabIndex = 9;
            this.ID_MEM_NCT_EB.Tag = "";
            this.ID_MEM_NCT_EB.TextChanged += new System.EventHandler(this.ID_MEM_NCT_EB_TextChanged);
            this.ID_MEM_NCT_EB.Enter += new System.EventHandler(this.ID_MEM_NCT_EB_Enter);
            this.ID_MEM_NCT_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_NCT_EB_KeyPress);
            this.ID_MEM_NCT_EB.Leave += new System.EventHandler(this.ID_MEM_NCT_EB_Leave);
            // 
            // ID_MEM_CTA_FRM
            // 
            this.ID_MEM_CTA_FRM.Controls.Add(this._ID_MEM_TEX_PNL_2);
            this.ID_MEM_CTA_FRM.Controls.Add(this._ID_MEM_ETT_PNL_2);
            this.ID_MEM_CTA_FRM.Controls.Add(this._ID_MEM_ETT_PNL_0);
            this.ID_MEM_CTA_FRM.Controls.Add(this._ID_MEM_ETT_PNL_1);
            this.ID_MEM_CTA_FRM.Controls.Add(this._ID_MEM_TEX_PNL_1);
            this.ID_MEM_CTA_FRM.Controls.Add(this._ID_MEM_TEX_PNL_3);
            this.ID_MEM_CTA_FRM.Controls.Add(this._ID_MEM_TEX_PNL_0);
            this.ID_MEM_CTA_FRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_CTA_FRM.Location = new System.Drawing.Point(13, 7);
            this.ID_MEM_CTA_FRM.Name = "ID_MEM_CTA_FRM";
            this.ID_MEM_CTA_FRM.Size = new System.Drawing.Size(596, 69);
            this.ID_MEM_CTA_FRM.TabIndex = 0;
            this.ID_MEM_CTA_FRM.TabStop = false;
            this.ID_MEM_CTA_FRM.Tag = "";
            // 
            // _ID_MEM_TEX_PNL_2
            // 
            this._ID_MEM_TEX_PNL_2.BackColor = System.Drawing.Color.Silver;
            this._ID_MEM_TEX_PNL_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ID_MEM_TEX_PNL_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_TEX_PNL_2.Location = new System.Drawing.Point(481, 39);
            this._ID_MEM_TEX_PNL_2.Name = "_ID_MEM_TEX_PNL_2";
            this._ID_MEM_TEX_PNL_2.Size = new System.Drawing.Size(105, 23);
            this._ID_MEM_TEX_PNL_2.TabIndex = 6;
            this._ID_MEM_TEX_PNL_2.Tag = "";
            this._ID_MEM_TEX_PNL_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _ID_MEM_ETT_PNL_2
            // 
            this._ID_MEM_ETT_PNL_2.BackColor = System.Drawing.Color.Silver;
            this._ID_MEM_ETT_PNL_2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._ID_MEM_ETT_PNL_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_PNL_2.Location = new System.Drawing.Point(415, 39);
            this._ID_MEM_ETT_PNL_2.Name = "_ID_MEM_ETT_PNL_2";
            this._ID_MEM_ETT_PNL_2.Size = new System.Drawing.Size(61, 23);
            this._ID_MEM_ETT_PNL_2.TabIndex = 5;
            this._ID_MEM_ETT_PNL_2.Tag = "";
            this._ID_MEM_ETT_PNL_2.Text = "Numero";
            this._ID_MEM_ETT_PNL_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _ID_MEM_ETT_PNL_0
            // 
            this._ID_MEM_ETT_PNL_0.BackColor = System.Drawing.Color.Silver;
            this._ID_MEM_ETT_PNL_0.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._ID_MEM_ETT_PNL_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_PNL_0.Location = new System.Drawing.Point(9, 12);
            this._ID_MEM_ETT_PNL_0.Name = "_ID_MEM_ETT_PNL_0";
            this._ID_MEM_ETT_PNL_0.Size = new System.Drawing.Size(64, 23);
            this._ID_MEM_ETT_PNL_0.TabIndex = 0;
            this._ID_MEM_ETT_PNL_0.Tag = "";
            this._ID_MEM_ETT_PNL_0.Text = " Grupo";
            this._ID_MEM_ETT_PNL_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _ID_MEM_ETT_PNL_1
            // 
            this._ID_MEM_ETT_PNL_1.BackColor = System.Drawing.Color.Silver;
            this._ID_MEM_ETT_PNL_1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._ID_MEM_ETT_PNL_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_PNL_1.Location = new System.Drawing.Point(9, 39);
            this._ID_MEM_ETT_PNL_1.Name = "_ID_MEM_ETT_PNL_1";
            this._ID_MEM_ETT_PNL_1.Size = new System.Drawing.Size(64, 23);
            this._ID_MEM_ETT_PNL_1.TabIndex = 3;
            this._ID_MEM_ETT_PNL_1.Tag = "";
            this._ID_MEM_ETT_PNL_1.Text = " Empresa";
            this._ID_MEM_ETT_PNL_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _ID_MEM_TEX_PNL_1
            // 
            this._ID_MEM_TEX_PNL_1.BackColor = System.Drawing.Color.Silver;
            this._ID_MEM_TEX_PNL_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ID_MEM_TEX_PNL_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_TEX_PNL_1.Location = new System.Drawing.Point(76, 39);
            this._ID_MEM_TEX_PNL_1.Name = "_ID_MEM_TEX_PNL_1";
            this._ID_MEM_TEX_PNL_1.Size = new System.Drawing.Size(334, 23);
            this._ID_MEM_TEX_PNL_1.TabIndex = 4;
            this._ID_MEM_TEX_PNL_1.Tag = "";
            this._ID_MEM_TEX_PNL_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _ID_MEM_TEX_PNL_3
            // 
            this._ID_MEM_TEX_PNL_3.BackColor = System.Drawing.Color.Silver;
            this._ID_MEM_TEX_PNL_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ID_MEM_TEX_PNL_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_TEX_PNL_3.Location = new System.Drawing.Point(415, 12);
            this._ID_MEM_TEX_PNL_3.Name = "_ID_MEM_TEX_PNL_3";
            this._ID_MEM_TEX_PNL_3.Size = new System.Drawing.Size(171, 23);
            this._ID_MEM_TEX_PNL_3.TabIndex = 2;
            this._ID_MEM_TEX_PNL_3.Tag = "";
            this._ID_MEM_TEX_PNL_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _ID_MEM_TEX_PNL_0
            // 
            this._ID_MEM_TEX_PNL_0.BackColor = System.Drawing.Color.Silver;
            this._ID_MEM_TEX_PNL_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ID_MEM_TEX_PNL_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_TEX_PNL_0.Location = new System.Drawing.Point(76, 12);
            this._ID_MEM_TEX_PNL_0.Name = "_ID_MEM_TEX_PNL_0";
            this._ID_MEM_TEX_PNL_0.Size = new System.Drawing.Size(334, 23);
            this._ID_MEM_TEX_PNL_0.TabIndex = 1;
            this._ID_MEM_TEX_PNL_0.Tag = "";
            this._ID_MEM_TEX_PNL_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _ID_MEM_DG_SSP_TabPage1
            // 
            this._ID_MEM_DG_SSP_TabPage1.BackColor = System.Drawing.Color.Transparent;
            this._ID_MEM_DG_SSP_TabPage1.Controls.Add(this._ID_MEM_DOM_PNL_1);
            this._ID_MEM_DG_SSP_TabPage1.Controls.Add(this._ID_MEM_DOM_PNL_0);
            this._ID_MEM_DG_SSP_TabPage1.Location = new System.Drawing.Point(4, 22);
            this._ID_MEM_DG_SSP_TabPage1.Name = "_ID_MEM_DG_SSP_TabPage1";
            this._ID_MEM_DG_SSP_TabPage1.Size = new System.Drawing.Size(618, 348);
            this._ID_MEM_DG_SSP_TabPage1.TabIndex = 0;
            this._ID_MEM_DG_SSP_TabPage1.Tag = "";
            this._ID_MEM_DG_SSP_TabPage1.Text = "Domicilio";
            this._ID_MEM_DG_SSP_TabPage1.UseVisualStyleBackColor = true;
            // 
            // _ID_MEM_DOM_PNL_1
            // 
            this._ID_MEM_DOM_PNL_1.Controls.Add(this._ID_MEM_CP_PIC_1);
            this._ID_MEM_DOM_PNL_1.Controls.Add(this._ID_MEM_ETT_TXT_24);
            this._ID_MEM_DOM_PNL_1.Controls.Add(this._ID_MEM_NO_BORRAR_0);
            this._ID_MEM_DOM_PNL_1.Controls.Add(this._ID_MEM_COL_EB_1);
            this._ID_MEM_DOM_PNL_1.Controls.Add(this._ID_MEM_DOM_EB_1);
            this._ID_MEM_DOM_PNL_1.Controls.Add(this._ID_MEM_ETT_TXT_28);
            this._ID_MEM_DOM_PNL_1.Controls.Add(this._ID_MEM_ETT_TXT_29);
            this._ID_MEM_DOM_PNL_1.Controls.Add(this._ID_MEM_ETT_TXT_27);
            this._ID_MEM_DOM_PNL_1.Controls.Add(this._ID_MEM_ETT_TXT_25);
            this._ID_MEM_DOM_PNL_1.Controls.Add(this._ID_MEM_ETT_TXT_26);
            this._ID_MEM_DOM_PNL_1.Controls.Add(this._ID_MEM_EDO_EB_1);
            this._ID_MEM_DOM_PNL_1.Controls.Add(this._ID_MEM_CIU_EB_1);
            this._ID_MEM_DOM_PNL_1.Controls.Add(this._ID_MEM_PDM_EB_1);
            this._ID_MEM_DOM_PNL_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_DOM_PNL_1.ForeColor = System.Drawing.Color.Black;
            this._ID_MEM_DOM_PNL_1.Location = new System.Drawing.Point(13, 174);
            this._ID_MEM_DOM_PNL_1.Name = "_ID_MEM_DOM_PNL_1";
            this._ID_MEM_DOM_PNL_1.Size = new System.Drawing.Size(596, 161);
            this._ID_MEM_DOM_PNL_1.TabIndex = 72;
            this._ID_MEM_DOM_PNL_1.TabStop = false;
            this._ID_MEM_DOM_PNL_1.Tag = "";
            this._ID_MEM_DOM_PNL_1.Text = " Domicilio &Env�o";
            // 
            // _ID_MEM_CP_PIC_1
            // 
            this._ID_MEM_CP_PIC_1.Location = new System.Drawing.Point(465, 131);
            this._ID_MEM_CP_PIC_1.Name = "_ID_MEM_CP_PIC_1";
            this._ID_MEM_CP_PIC_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_MEM_CP_PIC_1.OcxState")));
            this._ID_MEM_CP_PIC_1.Size = new System.Drawing.Size(73, 22);
            this._ID_MEM_CP_PIC_1.TabIndex = 84;
            this._ID_MEM_CP_PIC_1.Tag = "";
            this._ID_MEM_CP_PIC_1.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_CP_PIC_KeyPressEvent);
            this._ID_MEM_CP_PIC_1.Enter += new System.EventHandler(this.ID_MEM_CP_PIC_Enter);
            // 
            // _ID_MEM_ETT_TXT_24
            // 
            this._ID_MEM_ETT_TXT_24.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_24.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_24.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_24.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_24.Location = new System.Drawing.Point(426, 135);
            this._ID_MEM_ETT_TXT_24.Name = "_ID_MEM_ETT_TXT_24";
            this._ID_MEM_ETT_TXT_24.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_24.Size = new System.Drawing.Size(24, 15);
            this._ID_MEM_ETT_TXT_24.TabIndex = 83;
            this._ID_MEM_ETT_TXT_24.Tag = "";
            this._ID_MEM_ETT_TXT_24.Text = "&C.P.";
            // 
            // _ID_MEM_NO_BORRAR_0
            // 
            this._ID_MEM_NO_BORRAR_0.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_NO_BORRAR_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_NO_BORRAR_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_NO_BORRAR_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_NO_BORRAR_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_NO_BORRAR_0.Location = new System.Drawing.Point(468, 186);
            this._ID_MEM_NO_BORRAR_0.Name = "_ID_MEM_NO_BORRAR_0";
            this._ID_MEM_NO_BORRAR_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_NO_BORRAR_0.Size = new System.Drawing.Size(28, 20);
            this._ID_MEM_NO_BORRAR_0.TabIndex = 144;
            this._ID_MEM_NO_BORRAR_0.Tag = "";
            this._ID_MEM_NO_BORRAR_0.UseVisualStyleBackColor = false;
            this._ID_MEM_NO_BORRAR_0.Enter += new System.EventHandler(this.ID_MEM_NO_BORRAR_Enter);
            // 
            // _ID_MEM_COL_EB_1
            // 
            this._ID_MEM_COL_EB_1.AcceptsReturn = true;
            this._ID_MEM_COL_EB_1.BackColor = System.Drawing.Color.White;
            this._ID_MEM_COL_EB_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_COL_EB_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_COL_EB_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_COL_EB_1.Location = new System.Drawing.Point(137, 51);
            this._ID_MEM_COL_EB_1.MaxLength = 25;
            this._ID_MEM_COL_EB_1.Name = "_ID_MEM_COL_EB_1";
            this._ID_MEM_COL_EB_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_COL_EB_1.Size = new System.Drawing.Size(401, 20);
            this._ID_MEM_COL_EB_1.TabIndex = 76;
            this._ID_MEM_COL_EB_1.Tag = "";
            this._ID_MEM_COL_EB_1.Click += new System.EventHandler(this.HandleSelection_Click);
            this._ID_MEM_COL_EB_1.Enter += new System.EventHandler(this.ID_MEM_COL_EB_Enter);
            this._ID_MEM_COL_EB_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_COL_EB_KeyPress);
            this._ID_MEM_COL_EB_1.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // _ID_MEM_DOM_EB_1
            // 
            this._ID_MEM_DOM_EB_1.AcceptsReturn = true;
            this._ID_MEM_DOM_EB_1.BackColor = System.Drawing.Color.White;
            this._ID_MEM_DOM_EB_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_DOM_EB_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_DOM_EB_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_DOM_EB_1.Location = new System.Drawing.Point(201, 24);
            this._ID_MEM_DOM_EB_1.MaxLength = 35;
            this._ID_MEM_DOM_EB_1.Name = "_ID_MEM_DOM_EB_1";
            this._ID_MEM_DOM_EB_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_DOM_EB_1.Size = new System.Drawing.Size(337, 20);
            this._ID_MEM_DOM_EB_1.TabIndex = 74;
            this._ID_MEM_DOM_EB_1.Tag = "";
            this._ID_MEM_DOM_EB_1.Click += new System.EventHandler(this.HandleSelection_Click);
            this._ID_MEM_DOM_EB_1.Enter += new System.EventHandler(this.ID_MEM_DOM_EB_Enter);
            this._ID_MEM_DOM_EB_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_DOM_EB_KeyPress);
            this._ID_MEM_DOM_EB_1.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // _ID_MEM_ETT_TXT_28
            // 
            this._ID_MEM_ETT_TXT_28.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_28.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_28.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_28.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_28.Location = new System.Drawing.Point(44, 53);
            this._ID_MEM_ETT_TXT_28.Name = "_ID_MEM_ETT_TXT_28";
            this._ID_MEM_ETT_TXT_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_28.Size = new System.Drawing.Size(87, 17);
            this._ID_MEM_ETT_TXT_28.TabIndex = 75;
            this._ID_MEM_ETT_TXT_28.Tag = "";
            this._ID_MEM_ETT_TXT_28.Text = "&Colonia";
            // 
            // _ID_MEM_ETT_TXT_29
            // 
            this._ID_MEM_ETT_TXT_29.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_29.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_29.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_29.Location = new System.Drawing.Point(44, 26);
            this._ID_MEM_ETT_TXT_29.Name = "_ID_MEM_ETT_TXT_29";
            this._ID_MEM_ETT_TXT_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_29.Size = new System.Drawing.Size(163, 17);
            this._ID_MEM_ETT_TXT_29.TabIndex = 73;
            this._ID_MEM_ETT_TXT_29.Tag = "";
            this._ID_MEM_ETT_TXT_29.Text = "Domicilio (&Calle y N�mero)";
            // 
            // _ID_MEM_ETT_TXT_27
            // 
            this._ID_MEM_ETT_TXT_27.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_27.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_27.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_27.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_27.Location = new System.Drawing.Point(44, 134);
            this._ID_MEM_ETT_TXT_27.Name = "_ID_MEM_ETT_TXT_27";
            this._ID_MEM_ETT_TXT_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_27.Size = new System.Drawing.Size(85, 17);
            this._ID_MEM_ETT_TXT_27.TabIndex = 81;
            this._ID_MEM_ETT_TXT_27.Tag = "";
            this._ID_MEM_ETT_TXT_27.Text = "&Estado";
            // 
            // _ID_MEM_ETT_TXT_25
            // 
            this._ID_MEM_ETT_TXT_25.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_25.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_25.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_25.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_25.Location = new System.Drawing.Point(44, 80);
            this._ID_MEM_ETT_TXT_25.Name = "_ID_MEM_ETT_TXT_25";
            this._ID_MEM_ETT_TXT_25.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_25.Size = new System.Drawing.Size(85, 17);
            this._ID_MEM_ETT_TXT_25.TabIndex = 77;
            this._ID_MEM_ETT_TXT_25.Tag = "";
            this._ID_MEM_ETT_TXT_25.Text = "&Pob./Del./Mun.";
            // 
            // _ID_MEM_ETT_TXT_26
            // 
            this._ID_MEM_ETT_TXT_26.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_26.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_26.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_26.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_26.Location = new System.Drawing.Point(44, 107);
            this._ID_MEM_ETT_TXT_26.Name = "_ID_MEM_ETT_TXT_26";
            this._ID_MEM_ETT_TXT_26.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_26.Size = new System.Drawing.Size(87, 17);
            this._ID_MEM_ETT_TXT_26.TabIndex = 79;
            this._ID_MEM_ETT_TXT_26.Tag = "";
            this._ID_MEM_ETT_TXT_26.Text = "C&iudad";
            // 
            // _ID_MEM_EDO_EB_1
            // 
            this._ID_MEM_EDO_EB_1.BackColor = System.Drawing.SystemColors.Window;
            this._ID_MEM_EDO_EB_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_EDO_EB_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ID_MEM_EDO_EB_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_EDO_EB_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this._ID_MEM_EDO_EB_1, new int[0]);
            this._ID_MEM_EDO_EB_1.Location = new System.Drawing.Point(137, 132);
            this._ID_MEM_EDO_EB_1.Name = "_ID_MEM_EDO_EB_1";
            this._ID_MEM_EDO_EB_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_EDO_EB_1.Size = new System.Drawing.Size(212, 21);
            this._ID_MEM_EDO_EB_1.TabIndex = 82;
            this._ID_MEM_EDO_EB_1.Tag = "";
            this._ID_MEM_EDO_EB_1.Validating += new System.ComponentModel.CancelEventHandler(this.ID_MEM_EDO_EB_Validating);
            // 
            // _ID_MEM_CIU_EB_1
            // 
            this._ID_MEM_CIU_EB_1.AcceptsReturn = true;
            this._ID_MEM_CIU_EB_1.BackColor = System.Drawing.Color.White;
            this._ID_MEM_CIU_EB_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_CIU_EB_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_CIU_EB_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_CIU_EB_1.Location = new System.Drawing.Point(137, 105);
            this._ID_MEM_CIU_EB_1.MaxLength = 25;
            this._ID_MEM_CIU_EB_1.Name = "_ID_MEM_CIU_EB_1";
            this._ID_MEM_CIU_EB_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_CIU_EB_1.Size = new System.Drawing.Size(401, 20);
            this._ID_MEM_CIU_EB_1.TabIndex = 80;
            this._ID_MEM_CIU_EB_1.Tag = "";
            this._ID_MEM_CIU_EB_1.Click += new System.EventHandler(this.HandleSelection_Click);
            this._ID_MEM_CIU_EB_1.Enter += new System.EventHandler(this.ID_MEM_CIU_EB_Enter);
            this._ID_MEM_CIU_EB_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_CIU_EB_KeyPress);
            this._ID_MEM_CIU_EB_1.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // _ID_MEM_PDM_EB_1
            // 
            this._ID_MEM_PDM_EB_1.AcceptsReturn = true;
            this._ID_MEM_PDM_EB_1.BackColor = System.Drawing.Color.White;
            this._ID_MEM_PDM_EB_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_PDM_EB_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_PDM_EB_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_PDM_EB_1.Location = new System.Drawing.Point(137, 78);
            this._ID_MEM_PDM_EB_1.MaxLength = 25;
            this._ID_MEM_PDM_EB_1.Name = "_ID_MEM_PDM_EB_1";
            this._ID_MEM_PDM_EB_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_PDM_EB_1.Size = new System.Drawing.Size(401, 20);
            this._ID_MEM_PDM_EB_1.TabIndex = 78;
            this._ID_MEM_PDM_EB_1.Tag = "";
            this._ID_MEM_PDM_EB_1.Click += new System.EventHandler(this.HandleSelection_Click);
            this._ID_MEM_PDM_EB_1.Enter += new System.EventHandler(this.ID_MEM_PDM_EB_Enter);
            this._ID_MEM_PDM_EB_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_PDM_EB_KeyPress);
            this._ID_MEM_PDM_EB_1.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // _ID_MEM_DOM_PNL_0
            // 
            this._ID_MEM_DOM_PNL_0.Controls.Add(this._ID_MEM_CP_PIC_0);
            this._ID_MEM_DOM_PNL_0.Controls.Add(this._ID_MEM_ETT_TXT_9);
            this._ID_MEM_DOM_PNL_0.Controls.Add(this._ID_MEM_COL_EB_0);
            this._ID_MEM_DOM_PNL_0.Controls.Add(this._ID_MEM_DOM_EB_0);
            this._ID_MEM_DOM_PNL_0.Controls.Add(this._ID_MEM_ETT_TXT_10);
            this._ID_MEM_DOM_PNL_0.Controls.Add(this._ID_MEM_ETT_TXT_12);
            this._ID_MEM_DOM_PNL_0.Controls.Add(this._ID_MEM_ETT_TXT_15);
            this._ID_MEM_DOM_PNL_0.Controls.Add(this._ID_MEM_ETT_TXT_14);
            this._ID_MEM_DOM_PNL_0.Controls.Add(this._ID_MEM_ETT_TXT_13);
            this._ID_MEM_DOM_PNL_0.Controls.Add(this._ID_MEM_PDM_EB_0);
            this._ID_MEM_DOM_PNL_0.Controls.Add(this._ID_MEM_EDO_EB_0);
            this._ID_MEM_DOM_PNL_0.Controls.Add(this._ID_MEM_CIU_EB_0);
            this._ID_MEM_DOM_PNL_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_DOM_PNL_0.ForeColor = System.Drawing.Color.Black;
            this._ID_MEM_DOM_PNL_0.Location = new System.Drawing.Point(13, 7);
            this._ID_MEM_DOM_PNL_0.Name = "_ID_MEM_DOM_PNL_0";
            this._ID_MEM_DOM_PNL_0.Size = new System.Drawing.Size(596, 161);
            this._ID_MEM_DOM_PNL_0.TabIndex = 59;
            this._ID_MEM_DOM_PNL_0.TabStop = false;
            this._ID_MEM_DOM_PNL_0.Tag = "";
            this._ID_MEM_DOM_PNL_0.Text = " Domicilio &Fiscal";
            // 
            // _ID_MEM_CP_PIC_0
            // 
            this._ID_MEM_CP_PIC_0.Location = new System.Drawing.Point(462, 131);
            this._ID_MEM_CP_PIC_0.Name = "_ID_MEM_CP_PIC_0";
            this._ID_MEM_CP_PIC_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_MEM_CP_PIC_0.OcxState")));
            this._ID_MEM_CP_PIC_0.Size = new System.Drawing.Size(76, 22);
            this._ID_MEM_CP_PIC_0.TabIndex = 71;
            this._ID_MEM_CP_PIC_0.Tag = "";
            this._ID_MEM_CP_PIC_0.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_CP_PIC_KeyPressEvent);
            this._ID_MEM_CP_PIC_0.Enter += new System.EventHandler(this.ID_MEM_CP_PIC_Enter);
            // 
            // _ID_MEM_ETT_TXT_9
            // 
            this._ID_MEM_ETT_TXT_9.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_9.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_9.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_9.Location = new System.Drawing.Point(44, 26);
            this._ID_MEM_ETT_TXT_9.Name = "_ID_MEM_ETT_TXT_9";
            this._ID_MEM_ETT_TXT_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_9.Size = new System.Drawing.Size(149, 17);
            this._ID_MEM_ETT_TXT_9.TabIndex = 60;
            this._ID_MEM_ETT_TXT_9.Tag = "";
            this._ID_MEM_ETT_TXT_9.Text = "Domicilio (&Calle y N�mero)";
            // 
            // _ID_MEM_COL_EB_0
            // 
            this._ID_MEM_COL_EB_0.AcceptsReturn = true;
            this._ID_MEM_COL_EB_0.BackColor = System.Drawing.Color.White;
            this._ID_MEM_COL_EB_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_COL_EB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_COL_EB_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_COL_EB_0.Location = new System.Drawing.Point(137, 51);
            this._ID_MEM_COL_EB_0.MaxLength = 25;
            this._ID_MEM_COL_EB_0.Name = "_ID_MEM_COL_EB_0";
            this._ID_MEM_COL_EB_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_COL_EB_0.Size = new System.Drawing.Size(401, 20);
            this._ID_MEM_COL_EB_0.TabIndex = 63;
            this._ID_MEM_COL_EB_0.Tag = "";
            this._ID_MEM_COL_EB_0.Click += new System.EventHandler(this.HandleSelection_Click);
            this._ID_MEM_COL_EB_0.Enter += new System.EventHandler(this.ID_MEM_COL_EB_Enter);
            this._ID_MEM_COL_EB_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_COL_EB_KeyPress);
            this._ID_MEM_COL_EB_0.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // _ID_MEM_DOM_EB_0
            // 
            this._ID_MEM_DOM_EB_0.AcceptsReturn = true;
            this._ID_MEM_DOM_EB_0.BackColor = System.Drawing.Color.White;
            this._ID_MEM_DOM_EB_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_DOM_EB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_DOM_EB_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_DOM_EB_0.Location = new System.Drawing.Point(199, 24);
            this._ID_MEM_DOM_EB_0.MaxLength = 35;
            this._ID_MEM_DOM_EB_0.Name = "_ID_MEM_DOM_EB_0";
            this._ID_MEM_DOM_EB_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_DOM_EB_0.Size = new System.Drawing.Size(339, 20);
            this._ID_MEM_DOM_EB_0.TabIndex = 61;
            this._ID_MEM_DOM_EB_0.Tag = "";
            this._ID_MEM_DOM_EB_0.Click += new System.EventHandler(this.HandleSelection_Click);
            this._ID_MEM_DOM_EB_0.Enter += new System.EventHandler(this.ID_MEM_DOM_EB_Enter);
            this._ID_MEM_DOM_EB_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_DOM_EB_KeyPress);
            this._ID_MEM_DOM_EB_0.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // _ID_MEM_ETT_TXT_10
            // 
            this._ID_MEM_ETT_TXT_10.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_10.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_10.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_10.Location = new System.Drawing.Point(44, 52);
            this._ID_MEM_ETT_TXT_10.Name = "_ID_MEM_ETT_TXT_10";
            this._ID_MEM_ETT_TXT_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_10.Size = new System.Drawing.Size(87, 17);
            this._ID_MEM_ETT_TXT_10.TabIndex = 62;
            this._ID_MEM_ETT_TXT_10.Tag = "";
            this._ID_MEM_ETT_TXT_10.Text = "&Colonia";
            // 
            // _ID_MEM_ETT_TXT_12
            // 
            this._ID_MEM_ETT_TXT_12.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_12.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_12.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_12.Location = new System.Drawing.Point(44, 79);
            this._ID_MEM_ETT_TXT_12.Name = "_ID_MEM_ETT_TXT_12";
            this._ID_MEM_ETT_TXT_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_12.Size = new System.Drawing.Size(85, 17);
            this._ID_MEM_ETT_TXT_12.TabIndex = 64;
            this._ID_MEM_ETT_TXT_12.Tag = "";
            this._ID_MEM_ETT_TXT_12.Text = "&Pob./Del./Mun.";
            // 
            // _ID_MEM_ETT_TXT_15
            // 
            this._ID_MEM_ETT_TXT_15.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_15.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_15.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_15.Location = new System.Drawing.Point(432, 135);
            this._ID_MEM_ETT_TXT_15.Name = "_ID_MEM_ETT_TXT_15";
            this._ID_MEM_ETT_TXT_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_15.Size = new System.Drawing.Size(29, 15);
            this._ID_MEM_ETT_TXT_15.TabIndex = 70;
            this._ID_MEM_ETT_TXT_15.Tag = "";
            this._ID_MEM_ETT_TXT_15.Text = "&C.P.";
            // 
            // _ID_MEM_ETT_TXT_14
            // 
            this._ID_MEM_ETT_TXT_14.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_14.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_14.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_14.Location = new System.Drawing.Point(44, 134);
            this._ID_MEM_ETT_TXT_14.Name = "_ID_MEM_ETT_TXT_14";
            this._ID_MEM_ETT_TXT_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_14.Size = new System.Drawing.Size(85, 17);
            this._ID_MEM_ETT_TXT_14.TabIndex = 68;
            this._ID_MEM_ETT_TXT_14.Tag = "";
            this._ID_MEM_ETT_TXT_14.Text = "&Estado";
            // 
            // _ID_MEM_ETT_TXT_13
            // 
            this._ID_MEM_ETT_TXT_13.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_13.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_13.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_13.Location = new System.Drawing.Point(44, 106);
            this._ID_MEM_ETT_TXT_13.Name = "_ID_MEM_ETT_TXT_13";
            this._ID_MEM_ETT_TXT_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_13.Size = new System.Drawing.Size(87, 17);
            this._ID_MEM_ETT_TXT_13.TabIndex = 66;
            this._ID_MEM_ETT_TXT_13.Tag = "";
            this._ID_MEM_ETT_TXT_13.Text = "C&iudad";
            // 
            // _ID_MEM_PDM_EB_0
            // 
            this._ID_MEM_PDM_EB_0.AcceptsReturn = true;
            this._ID_MEM_PDM_EB_0.BackColor = System.Drawing.Color.White;
            this._ID_MEM_PDM_EB_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_PDM_EB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_PDM_EB_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_PDM_EB_0.Location = new System.Drawing.Point(137, 78);
            this._ID_MEM_PDM_EB_0.MaxLength = 21;
            this._ID_MEM_PDM_EB_0.Name = "_ID_MEM_PDM_EB_0";
            this._ID_MEM_PDM_EB_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_PDM_EB_0.Size = new System.Drawing.Size(401, 20);
            this._ID_MEM_PDM_EB_0.TabIndex = 65;
            this._ID_MEM_PDM_EB_0.Tag = "";
            this._ID_MEM_PDM_EB_0.Click += new System.EventHandler(this.HandleSelection_Click);
            this._ID_MEM_PDM_EB_0.Enter += new System.EventHandler(this.ID_MEM_PDM_EB_Enter);
            this._ID_MEM_PDM_EB_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_PDM_EB_KeyPress);
            this._ID_MEM_PDM_EB_0.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // _ID_MEM_EDO_EB_0
            // 
            this._ID_MEM_EDO_EB_0.BackColor = System.Drawing.SystemColors.Window;
            this._ID_MEM_EDO_EB_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_EDO_EB_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ID_MEM_EDO_EB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_EDO_EB_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this._ID_MEM_EDO_EB_0, new int[0]);
            this._ID_MEM_EDO_EB_0.Location = new System.Drawing.Point(137, 132);
            this._ID_MEM_EDO_EB_0.Name = "_ID_MEM_EDO_EB_0";
            this._ID_MEM_EDO_EB_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_EDO_EB_0.Size = new System.Drawing.Size(212, 21);
            this._ID_MEM_EDO_EB_0.TabIndex = 69;
            this._ID_MEM_EDO_EB_0.Tag = "";
            this._ID_MEM_EDO_EB_0.Validating += new System.ComponentModel.CancelEventHandler(this.ID_MEM_EDO_EB_Validating);
            // 
            // _ID_MEM_CIU_EB_0
            // 
            this._ID_MEM_CIU_EB_0.AcceptsReturn = true;
            this._ID_MEM_CIU_EB_0.BackColor = System.Drawing.Color.White;
            this._ID_MEM_CIU_EB_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_CIU_EB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_CIU_EB_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_CIU_EB_0.Location = new System.Drawing.Point(137, 105);
            this._ID_MEM_CIU_EB_0.MaxLength = 25;
            this._ID_MEM_CIU_EB_0.Name = "_ID_MEM_CIU_EB_0";
            this._ID_MEM_CIU_EB_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_CIU_EB_0.Size = new System.Drawing.Size(401, 20);
            this._ID_MEM_CIU_EB_0.TabIndex = 67;
            this._ID_MEM_CIU_EB_0.Tag = "";
            this._ID_MEM_CIU_EB_0.Click += new System.EventHandler(this.HandleSelection_Click);
            this._ID_MEM_CIU_EB_0.Enter += new System.EventHandler(this.ID_MEM_CIU_EB_Enter);
            this._ID_MEM_CIU_EB_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_CIU_EB_KeyPress);
            this._ID_MEM_CIU_EB_0.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // _ID_MEM_DG_SSP_TabPage2
            // 
            this._ID_MEM_DG_SSP_TabPage2.BackColor = System.Drawing.Color.Transparent;
            this._ID_MEM_DG_SSP_TabPage2.Controls.Add(this._ID_MEM_REP_3OD_2);
            this._ID_MEM_DG_SSP_TabPage2.Controls.Add(this.ID_MEM_REP_FRM);
            this._ID_MEM_DG_SSP_TabPage2.Controls.Add(this._ID_MEM_REP_3OD_1);
            this._ID_MEM_DG_SSP_TabPage2.Controls.Add(this._ID_MEM_REP_3OD_0);
            this._ID_MEM_DG_SSP_TabPage2.Location = new System.Drawing.Point(4, 22);
            this._ID_MEM_DG_SSP_TabPage2.Name = "_ID_MEM_DG_SSP_TabPage2";
            this._ID_MEM_DG_SSP_TabPage2.Size = new System.Drawing.Size(618, 348);
            this._ID_MEM_DG_SSP_TabPage2.TabIndex = 2;
            this._ID_MEM_DG_SSP_TabPage2.Tag = "";
            this._ID_MEM_DG_SSP_TabPage2.Text = "Representantes / Otros";
            this._ID_MEM_DG_SSP_TabPage2.UseVisualStyleBackColor = true;
            // 
            // _ID_MEM_REP_3OD_2
            // 
            this._ID_MEM_REP_3OD_2.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_REP_3OD_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_REP_3OD_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_REP_3OD_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_REP_3OD_2.Location = new System.Drawing.Point(181, 42);
            this._ID_MEM_REP_3OD_2.Name = "_ID_MEM_REP_3OD_2";
            this._ID_MEM_REP_3OD_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_REP_3OD_2.Size = new System.Drawing.Size(37, 19);
            this._ID_MEM_REP_3OD_2.TabIndex = 18;
            this._ID_MEM_REP_3OD_2.Tag = "";
            this._ID_MEM_REP_3OD_2.Text = "&3";
            this._ID_MEM_REP_3OD_2.UseVisualStyleBackColor = false;
            this._ID_MEM_REP_3OD_2.CheckedChanged += new System.EventHandler(this.ID_MEM_REP_3OD_CheckedChanged);
            this._ID_MEM_REP_3OD_2.Enter += new System.EventHandler(this.ID_MEM_REP_3OD_Enter);
            this._ID_MEM_REP_3OD_2.Leave += new System.EventHandler(this.ID_MEM_REP_3OD_Leave);
            // 
            // ID_MEM_REP_FRM
            // 
            this.ID_MEM_REP_FRM.Controls.Add(this.ID_MEM_FIR_PB);
            this.ID_MEM_REP_FRM.Controls.Add(this._ID_MEM_REP_PNL_0);
            this.ID_MEM_REP_FRM.Controls.Add(this._ID_MEM_REP_PNL_1);
            this.ID_MEM_REP_FRM.Controls.Add(this._ID_MEM_REP_PNL_2);
            this.ID_MEM_REP_FRM.Controls.Add(this.ID_MEM_BOR_PB);
            this.ID_MEM_REP_FRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_REP_FRM.Location = new System.Drawing.Point(18, 67);
            this.ID_MEM_REP_FRM.Name = "ID_MEM_REP_FRM";
            this.ID_MEM_REP_FRM.Size = new System.Drawing.Size(577, 258);
            this.ID_MEM_REP_FRM.TabIndex = 153;
            this.ID_MEM_REP_FRM.TabStop = false;
            this.ID_MEM_REP_FRM.Tag = "";
            // 
            // ID_MEM_FIR_PB
            // 
            this.ID_MEM_FIR_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEM_FIR_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_FIR_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEM_FIR_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_FIR_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEM_FIR_PB.Location = new System.Drawing.Point(275, 208);
            this.ID_MEM_FIR_PB.Name = "ID_MEM_FIR_PB";
            this.ID_MEM_FIR_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_FIR_PB.Size = new System.Drawing.Size(189, 22);
            this.ID_MEM_FIR_PB.TabIndex = 35;
            this.ID_MEM_FIR_PB.Tag = "";
            this.ID_MEM_FIR_PB.Text = "Capturar &Firmas";
            this.ID_MEM_FIR_PB.UseVisualStyleBackColor = false;
            this.ID_MEM_FIR_PB.Click += new System.EventHandler(this.ID_MEM_FIR_PB_Click);
            this.ID_MEM_FIR_PB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_FIR_PB_KeyPress);
            this.ID_MEM_FIR_PB.Leave += new System.EventHandler(this.ID_MEM_FIR_PB_Leave);
            // 
            // _ID_MEM_REP_PNL_0
            // 
            this._ID_MEM_REP_PNL_0.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_REP_PNL_0.Controls.Add(this._ID_MEM_NOM_EB_0);
            this._ID_MEM_REP_PNL_0.Controls.Add(this._ID_MEM_ETT_TXT_18);
            this._ID_MEM_REP_PNL_0.Controls.Add(this.ID_MEM_REP1_LB);
            this._ID_MEM_REP_PNL_0.Controls.Add(this._ID_MEM_TEL_MKE_0);
            this._ID_MEM_REP_PNL_0.Controls.Add(this._ID_MEM_EXT_PIC_0);
            this._ID_MEM_REP_PNL_0.Controls.Add(this._ID_MEM_PUE_EB_0);
            this._ID_MEM_REP_PNL_0.Controls.Add(this._ID_MEM_FAX_MKE_0);
            this._ID_MEM_REP_PNL_0.Controls.Add(this._ID_MEM_ETT_TXT_19);
            this._ID_MEM_REP_PNL_0.Controls.Add(this._ID_MEM_ETT_TXT_16);
            this._ID_MEM_REP_PNL_0.Controls.Add(this._ID_MEM_ETT_TXT_20);
            this._ID_MEM_REP_PNL_0.Controls.Add(this._ID_MEM_ETT_TXT_17);
            this._ID_MEM_REP_PNL_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_REP_PNL_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_REP_PNL_0.Location = new System.Drawing.Point(24, 40);
            this._ID_MEM_REP_PNL_0.Name = "_ID_MEM_REP_PNL_0";
            this._ID_MEM_REP_PNL_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_REP_PNL_0.Size = new System.Drawing.Size(544, 152);
            this._ID_MEM_REP_PNL_0.TabIndex = 168;
            this._ID_MEM_REP_PNL_0.TabStop = false;
            this._ID_MEM_REP_PNL_0.Tag = "";
            // 
            // _ID_MEM_NOM_EB_0
            // 
            this._ID_MEM_NOM_EB_0.AcceptsReturn = true;
            this._ID_MEM_NOM_EB_0.BackColor = System.Drawing.Color.White;
            this._ID_MEM_NOM_EB_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_NOM_EB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_NOM_EB_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_NOM_EB_0.Location = new System.Drawing.Point(80, 54);
            this._ID_MEM_NOM_EB_0.MaxLength = 35;
            this._ID_MEM_NOM_EB_0.Name = "_ID_MEM_NOM_EB_0";
            this._ID_MEM_NOM_EB_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_NOM_EB_0.Size = new System.Drawing.Size(398, 20);
            this._ID_MEM_NOM_EB_0.TabIndex = 29;
            this._ID_MEM_NOM_EB_0.Tag = "";
            this._ID_MEM_NOM_EB_0.Click += new System.EventHandler(this.HandleSelection_Click);
            this._ID_MEM_NOM_EB_0.Enter += new System.EventHandler(this.ID_MEM_NOM_EB_Enter);
            this._ID_MEM_NOM_EB_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_NOM_EB_KeyPress);
            this._ID_MEM_NOM_EB_0.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // _ID_MEM_ETT_TXT_18
            // 
            this._ID_MEM_ETT_TXT_18.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_18.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_18.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_18.Location = new System.Drawing.Point(15, 117);
            this._ID_MEM_ETT_TXT_18.Name = "_ID_MEM_ETT_TXT_18";
            this._ID_MEM_ETT_TXT_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_18.Size = new System.Drawing.Size(59, 15);
            this._ID_MEM_ETT_TXT_18.TabIndex = 159;
            this._ID_MEM_ETT_TXT_18.Tag = "";
            this._ID_MEM_ETT_TXT_18.Text = "&Tel�fono";
            // 
            // ID_MEM_REP1_LB
            // 
            this.ID_MEM_REP1_LB.AutoSize = true;
            this.ID_MEM_REP1_LB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEM_REP1_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_REP1_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEM_REP1_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_REP1_LB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEM_REP1_LB.Location = new System.Drawing.Point(15, 20);
            this.ID_MEM_REP1_LB.Name = "ID_MEM_REP1_LB";
            this.ID_MEM_REP1_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_REP1_LB.Size = new System.Drawing.Size(154, 13);
            this.ID_MEM_REP1_LB.TabIndex = 160;
            this.ID_MEM_REP1_LB.Tag = "";
            this.ID_MEM_REP1_LB.Text = "Datos del representante 1";
            // 
            // _ID_MEM_TEL_MKE_0
            // 
            this._ID_MEM_TEL_MKE_0.Location = new System.Drawing.Point(80, 113);
            this._ID_MEM_TEL_MKE_0.Name = "_ID_MEM_TEL_MKE_0";
            this._ID_MEM_TEL_MKE_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_MEM_TEL_MKE_0.OcxState")));
            this._ID_MEM_TEL_MKE_0.Size = new System.Drawing.Size(105, 22);
            this._ID_MEM_TEL_MKE_0.TabIndex = 31;
            this._ID_MEM_TEL_MKE_0.Tag = "";
            this._ID_MEM_TEL_MKE_0.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_TEL_MKE_KeyPressEvent);
            this._ID_MEM_TEL_MKE_0.Enter += new System.EventHandler(this.ID_MEM_TEL_MKE_Enter);
            // 
            // _ID_MEM_EXT_PIC_0
            // 
            this._ID_MEM_EXT_PIC_0.Location = new System.Drawing.Point(255, 112);
            this._ID_MEM_EXT_PIC_0.Name = "_ID_MEM_EXT_PIC_0";
            this._ID_MEM_EXT_PIC_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_MEM_EXT_PIC_0.OcxState")));
            this._ID_MEM_EXT_PIC_0.Size = new System.Drawing.Size(57, 22);
            this._ID_MEM_EXT_PIC_0.TabIndex = 32;
            this._ID_MEM_EXT_PIC_0.Tag = "";
            this._ID_MEM_EXT_PIC_0.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_EXT_PIC_KeyPressEvent);
            this._ID_MEM_EXT_PIC_0.Enter += new System.EventHandler(this.ID_MEM_EXT_PIC_Enter);
            this._ID_MEM_EXT_PIC_0.Leave += new System.EventHandler(this.ID_MEM_EXT_PIC_Leave);
            // 
            // _ID_MEM_PUE_EB_0
            // 
            this._ID_MEM_PUE_EB_0.AcceptsReturn = true;
            this._ID_MEM_PUE_EB_0.BackColor = System.Drawing.Color.White;
            this._ID_MEM_PUE_EB_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_PUE_EB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_PUE_EB_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_PUE_EB_0.Location = new System.Drawing.Point(80, 84);
            this._ID_MEM_PUE_EB_0.MaxLength = 15;
            this._ID_MEM_PUE_EB_0.Name = "_ID_MEM_PUE_EB_0";
            this._ID_MEM_PUE_EB_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_PUE_EB_0.Size = new System.Drawing.Size(198, 20);
            this._ID_MEM_PUE_EB_0.TabIndex = 30;
            this._ID_MEM_PUE_EB_0.Tag = "";
            this._ID_MEM_PUE_EB_0.Click += new System.EventHandler(this.HandleSelection_Click);
            this._ID_MEM_PUE_EB_0.Enter += new System.EventHandler(this.ID_MEM_PUE_EB_Enter);
            this._ID_MEM_PUE_EB_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_PUE_EB_KeyPress);
            this._ID_MEM_PUE_EB_0.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // _ID_MEM_FAX_MKE_0
            // 
            this._ID_MEM_FAX_MKE_0.Location = new System.Drawing.Point(376, 112);
            this._ID_MEM_FAX_MKE_0.Name = "_ID_MEM_FAX_MKE_0";
            this._ID_MEM_FAX_MKE_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_MEM_FAX_MKE_0.OcxState")));
            this._ID_MEM_FAX_MKE_0.Size = new System.Drawing.Size(103, 22);
            this._ID_MEM_FAX_MKE_0.TabIndex = 33;
            this._ID_MEM_FAX_MKE_0.Tag = "";
            this._ID_MEM_FAX_MKE_0.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_FAX_MKE_KeyPressEvent);
            this._ID_MEM_FAX_MKE_0.Enter += new System.EventHandler(this.ID_MEM_FAX_MKE_Enter);
            // 
            // _ID_MEM_ETT_TXT_19
            // 
            this._ID_MEM_ETT_TXT_19.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_19.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_19.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_19.Location = new System.Drawing.Point(224, 117);
            this._ID_MEM_ETT_TXT_19.Name = "_ID_MEM_ETT_TXT_19";
            this._ID_MEM_ETT_TXT_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_19.Size = new System.Drawing.Size(27, 15);
            this._ID_MEM_ETT_TXT_19.TabIndex = 158;
            this._ID_MEM_ETT_TXT_19.Tag = "";
            this._ID_MEM_ETT_TXT_19.Text = "&Ext.";
            // 
            // _ID_MEM_ETT_TXT_16
            // 
            this._ID_MEM_ETT_TXT_16.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_16.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_16.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_16.Location = new System.Drawing.Point(15, 56);
            this._ID_MEM_ETT_TXT_16.Name = "_ID_MEM_ETT_TXT_16";
            this._ID_MEM_ETT_TXT_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_16.Size = new System.Drawing.Size(59, 15);
            this._ID_MEM_ETT_TXT_16.TabIndex = 156;
            this._ID_MEM_ETT_TXT_16.Tag = "";
            this._ID_MEM_ETT_TXT_16.Text = "&Nombre";
            // 
            // _ID_MEM_ETT_TXT_20
            // 
            this._ID_MEM_ETT_TXT_20.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_20.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_20.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_20.Location = new System.Drawing.Point(340, 117);
            this._ID_MEM_ETT_TXT_20.Name = "_ID_MEM_ETT_TXT_20";
            this._ID_MEM_ETT_TXT_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_20.Size = new System.Drawing.Size(33, 15);
            this._ID_MEM_ETT_TXT_20.TabIndex = 155;
            this._ID_MEM_ETT_TXT_20.Tag = "";
            this._ID_MEM_ETT_TXT_20.Text = "&Fax";
            // 
            // _ID_MEM_ETT_TXT_17
            // 
            this._ID_MEM_ETT_TXT_17.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_17.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_17.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_17.Location = new System.Drawing.Point(15, 86);
            this._ID_MEM_ETT_TXT_17.Name = "_ID_MEM_ETT_TXT_17";
            this._ID_MEM_ETT_TXT_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_17.Size = new System.Drawing.Size(59, 15);
            this._ID_MEM_ETT_TXT_17.TabIndex = 157;
            this._ID_MEM_ETT_TXT_17.Tag = "";
            this._ID_MEM_ETT_TXT_17.Text = "&Puesto";
            // 
            // _ID_MEM_REP_PNL_1
            // 
            this._ID_MEM_REP_PNL_1.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_REP_PNL_1.Controls.Add(this._ID_MEM_NOM_EB_1);
            this._ID_MEM_REP_PNL_1.Controls.Add(this._ID_MEM_ETT_TXT_22);
            this._ID_MEM_REP_PNL_1.Controls.Add(this.ID_MEM_REP2_LB);
            this._ID_MEM_REP_PNL_1.Controls.Add(this._ID_MEM_TEL_MKE_1);
            this._ID_MEM_REP_PNL_1.Controls.Add(this._ID_MEM_FAX_MKE_1);
            this._ID_MEM_REP_PNL_1.Controls.Add(this._ID_MEM_PUE_EB_1);
            this._ID_MEM_REP_PNL_1.Controls.Add(this._ID_MEM_EXT_PIC_1);
            this._ID_MEM_REP_PNL_1.Controls.Add(this._ID_MEM_ETT_TXT_11);
            this._ID_MEM_REP_PNL_1.Controls.Add(this._ID_MEM_ETT_TXT_0);
            this._ID_MEM_REP_PNL_1.Controls.Add(this._ID_MEM_ETT_TXT_21);
            this._ID_MEM_REP_PNL_1.Controls.Add(this._ID_MEM_ETT_TXT_1);
            this._ID_MEM_REP_PNL_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_REP_PNL_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_REP_PNL_1.Location = new System.Drawing.Point(24, 40);
            this._ID_MEM_REP_PNL_1.Name = "_ID_MEM_REP_PNL_1";
            this._ID_MEM_REP_PNL_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_REP_PNL_1.Size = new System.Drawing.Size(544, 152);
            this._ID_MEM_REP_PNL_1.TabIndex = 161;
            this._ID_MEM_REP_PNL_1.TabStop = false;
            this._ID_MEM_REP_PNL_1.Tag = "";
            // 
            // _ID_MEM_NOM_EB_1
            // 
            this._ID_MEM_NOM_EB_1.AcceptsReturn = true;
            this._ID_MEM_NOM_EB_1.BackColor = System.Drawing.Color.White;
            this._ID_MEM_NOM_EB_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_NOM_EB_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_NOM_EB_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_NOM_EB_1.Location = new System.Drawing.Point(80, 54);
            this._ID_MEM_NOM_EB_1.MaxLength = 35;
            this._ID_MEM_NOM_EB_1.Name = "_ID_MEM_NOM_EB_1";
            this._ID_MEM_NOM_EB_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_NOM_EB_1.Size = new System.Drawing.Size(398, 20);
            this._ID_MEM_NOM_EB_1.TabIndex = 19;
            this._ID_MEM_NOM_EB_1.Tag = "";
            this._ID_MEM_NOM_EB_1.Enter += new System.EventHandler(this.ID_MEM_NOM_EB_Enter);
            this._ID_MEM_NOM_EB_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_NOM_EB_KeyPress);
            // 
            // _ID_MEM_ETT_TXT_22
            // 
            this._ID_MEM_ETT_TXT_22.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_22.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_22.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_22.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_22.Location = new System.Drawing.Point(340, 117);
            this._ID_MEM_ETT_TXT_22.Name = "_ID_MEM_ETT_TXT_22";
            this._ID_MEM_ETT_TXT_22.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_22.Size = new System.Drawing.Size(32, 15);
            this._ID_MEM_ETT_TXT_22.TabIndex = 166;
            this._ID_MEM_ETT_TXT_22.Tag = "";
            this._ID_MEM_ETT_TXT_22.Text = "&Fax";
            // 
            // ID_MEM_REP2_LB
            // 
            this.ID_MEM_REP2_LB.AutoSize = true;
            this.ID_MEM_REP2_LB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEM_REP2_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_REP2_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEM_REP2_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_REP2_LB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEM_REP2_LB.Location = new System.Drawing.Point(15, 20);
            this.ID_MEM_REP2_LB.Name = "ID_MEM_REP2_LB";
            this.ID_MEM_REP2_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_REP2_LB.Size = new System.Drawing.Size(154, 13);
            this.ID_MEM_REP2_LB.TabIndex = 167;
            this.ID_MEM_REP2_LB.Tag = "";
            this.ID_MEM_REP2_LB.Text = "Datos del representante 2";
            // 
            // _ID_MEM_TEL_MKE_1
            // 
            this._ID_MEM_TEL_MKE_1.Location = new System.Drawing.Point(80, 114);
            this._ID_MEM_TEL_MKE_1.Name = "_ID_MEM_TEL_MKE_1";
            this._ID_MEM_TEL_MKE_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_MEM_TEL_MKE_1.OcxState")));
            this._ID_MEM_TEL_MKE_1.Size = new System.Drawing.Size(117, 22);
            this._ID_MEM_TEL_MKE_1.TabIndex = 21;
            this._ID_MEM_TEL_MKE_1.Tag = "";
            this._ID_MEM_TEL_MKE_1.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_TEL_MKE_KeyPressEvent);
            this._ID_MEM_TEL_MKE_1.Enter += new System.EventHandler(this.ID_MEM_TEL_MKE_Enter);
            // 
            // _ID_MEM_FAX_MKE_1
            // 
            this._ID_MEM_FAX_MKE_1.Location = new System.Drawing.Point(374, 114);
            this._ID_MEM_FAX_MKE_1.Name = "_ID_MEM_FAX_MKE_1";
            this._ID_MEM_FAX_MKE_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_MEM_FAX_MKE_1.OcxState")));
            this._ID_MEM_FAX_MKE_1.Size = new System.Drawing.Size(119, 22);
            this._ID_MEM_FAX_MKE_1.TabIndex = 23;
            this._ID_MEM_FAX_MKE_1.Tag = "";
            this._ID_MEM_FAX_MKE_1.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_FAX_MKE_KeyPressEvent);
            this._ID_MEM_FAX_MKE_1.Enter += new System.EventHandler(this.ID_MEM_FAX_MKE_Enter);
            // 
            // _ID_MEM_PUE_EB_1
            // 
            this._ID_MEM_PUE_EB_1.AcceptsReturn = true;
            this._ID_MEM_PUE_EB_1.BackColor = System.Drawing.Color.White;
            this._ID_MEM_PUE_EB_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_PUE_EB_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_PUE_EB_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_PUE_EB_1.Location = new System.Drawing.Point(80, 84);
            this._ID_MEM_PUE_EB_1.MaxLength = 15;
            this._ID_MEM_PUE_EB_1.Name = "_ID_MEM_PUE_EB_1";
            this._ID_MEM_PUE_EB_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_PUE_EB_1.Size = new System.Drawing.Size(198, 20);
            this._ID_MEM_PUE_EB_1.TabIndex = 20;
            this._ID_MEM_PUE_EB_1.Tag = "";
            this._ID_MEM_PUE_EB_1.Enter += new System.EventHandler(this.ID_MEM_PUE_EB_Enter);
            this._ID_MEM_PUE_EB_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_PUE_EB_KeyPress);
            // 
            // _ID_MEM_EXT_PIC_1
            // 
            this._ID_MEM_EXT_PIC_1.Location = new System.Drawing.Point(256, 114);
            this._ID_MEM_EXT_PIC_1.Name = "_ID_MEM_EXT_PIC_1";
            this._ID_MEM_EXT_PIC_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_MEM_EXT_PIC_1.OcxState")));
            this._ID_MEM_EXT_PIC_1.Size = new System.Drawing.Size(57, 22);
            this._ID_MEM_EXT_PIC_1.TabIndex = 22;
            this._ID_MEM_EXT_PIC_1.Tag = "";
            this._ID_MEM_EXT_PIC_1.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_EXT_PIC_KeyPressEvent);
            this._ID_MEM_EXT_PIC_1.Enter += new System.EventHandler(this.ID_MEM_EXT_PIC_Enter);
            this._ID_MEM_EXT_PIC_1.Leave += new System.EventHandler(this.ID_MEM_EXT_PIC_Leave);
            // 
            // _ID_MEM_ETT_TXT_11
            // 
            this._ID_MEM_ETT_TXT_11.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_11.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_11.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_11.Location = new System.Drawing.Point(15, 86);
            this._ID_MEM_ETT_TXT_11.Name = "_ID_MEM_ETT_TXT_11";
            this._ID_MEM_ETT_TXT_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_11.Size = new System.Drawing.Size(47, 15);
            this._ID_MEM_ETT_TXT_11.TabIndex = 165;
            this._ID_MEM_ETT_TXT_11.Tag = "";
            this._ID_MEM_ETT_TXT_11.Text = "&Puesto";
            // 
            // _ID_MEM_ETT_TXT_0
            // 
            this._ID_MEM_ETT_TXT_0.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_0.Location = new System.Drawing.Point(15, 117);
            this._ID_MEM_ETT_TXT_0.Name = "_ID_MEM_ETT_TXT_0";
            this._ID_MEM_ETT_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_0.Size = new System.Drawing.Size(56, 15);
            this._ID_MEM_ETT_TXT_0.TabIndex = 163;
            this._ID_MEM_ETT_TXT_0.Tag = "";
            this._ID_MEM_ETT_TXT_0.Text = "&Tel�fono";
            // 
            // _ID_MEM_ETT_TXT_21
            // 
            this._ID_MEM_ETT_TXT_21.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_21.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_21.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_21.Location = new System.Drawing.Point(15, 56);
            this._ID_MEM_ETT_TXT_21.Name = "_ID_MEM_ETT_TXT_21";
            this._ID_MEM_ETT_TXT_21.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_21.Size = new System.Drawing.Size(47, 15);
            this._ID_MEM_ETT_TXT_21.TabIndex = 162;
            this._ID_MEM_ETT_TXT_21.Tag = "";
            this._ID_MEM_ETT_TXT_21.Text = "&Nombre";
            // 
            // _ID_MEM_ETT_TXT_1
            // 
            this._ID_MEM_ETT_TXT_1.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_1.Location = new System.Drawing.Point(224, 117);
            this._ID_MEM_ETT_TXT_1.Name = "_ID_MEM_ETT_TXT_1";
            this._ID_MEM_ETT_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_1.Size = new System.Drawing.Size(27, 15);
            this._ID_MEM_ETT_TXT_1.TabIndex = 164;
            this._ID_MEM_ETT_TXT_1.Tag = "";
            this._ID_MEM_ETT_TXT_1.Text = "&Ext.";
            // 
            // _ID_MEM_REP_PNL_2
            // 
            this._ID_MEM_REP_PNL_2.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_REP_PNL_2.Controls.Add(this.label1);
            this._ID_MEM_REP_PNL_2.Controls.Add(this._ID_MEM_NOM_EB_2);
            this._ID_MEM_REP_PNL_2.Controls.Add(this._ID_MEM_ETT_TXT_33);
            this._ID_MEM_REP_PNL_2.Controls.Add(this._ID_MEM_ETT_TXT_34);
            this._ID_MEM_REP_PNL_2.Controls.Add(this._ID_MEM_EXT_PIC_2);
            this._ID_MEM_REP_PNL_2.Controls.Add(this._ID_MEM_FAX_MKE_2);
            this._ID_MEM_REP_PNL_2.Controls.Add(this._ID_MEM_PUE_EB_2);
            this._ID_MEM_REP_PNL_2.Controls.Add(this._ID_MEM_TEL_MKE_2);
            this._ID_MEM_REP_PNL_2.Controls.Add(this._ID_MEM_ETT_TXT_32);
            this._ID_MEM_REP_PNL_2.Controls.Add(this.ID_MEM_REP_LB);
            this._ID_MEM_REP_PNL_2.Controls.Add(this._ID_MEM_ETT_TXT_31);
            this._ID_MEM_REP_PNL_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_REP_PNL_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_REP_PNL_2.Location = new System.Drawing.Point(24, 40);
            this._ID_MEM_REP_PNL_2.Name = "_ID_MEM_REP_PNL_2";
            this._ID_MEM_REP_PNL_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_REP_PNL_2.Size = new System.Drawing.Size(544, 152);
            this._ID_MEM_REP_PNL_2.TabIndex = 168;
            this._ID_MEM_REP_PNL_2.TabStop = false;
            this._ID_MEM_REP_PNL_2.Tag = "";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 117);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(59, 15);
            this.label1.TabIndex = 175;
            this.label1.Tag = "";
            this.label1.Text = "&Tel�fono";
            // 
            // _ID_MEM_NOM_EB_2
            // 
            this._ID_MEM_NOM_EB_2.AcceptsReturn = true;
            this._ID_MEM_NOM_EB_2.BackColor = System.Drawing.Color.White;
            this._ID_MEM_NOM_EB_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_NOM_EB_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_NOM_EB_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_NOM_EB_2.Location = new System.Drawing.Point(80, 54);
            this._ID_MEM_NOM_EB_2.MaxLength = 35;
            this._ID_MEM_NOM_EB_2.Name = "_ID_MEM_NOM_EB_2";
            this._ID_MEM_NOM_EB_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_NOM_EB_2.Size = new System.Drawing.Size(398, 20);
            this._ID_MEM_NOM_EB_2.TabIndex = 24;
            this._ID_MEM_NOM_EB_2.Tag = "";
            this._ID_MEM_NOM_EB_2.Enter += new System.EventHandler(this.ID_MEM_NOM_EB_Enter);
            this._ID_MEM_NOM_EB_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_NOM_EB_KeyPress);
            // 
            // _ID_MEM_ETT_TXT_33
            // 
            this._ID_MEM_ETT_TXT_33.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_33.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_33.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_33.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_33.Location = new System.Drawing.Point(15, 54);
            this._ID_MEM_ETT_TXT_33.Name = "_ID_MEM_ETT_TXT_33";
            this._ID_MEM_ETT_TXT_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_33.Size = new System.Drawing.Size(73, 15);
            this._ID_MEM_ETT_TXT_33.TabIndex = 173;
            this._ID_MEM_ETT_TXT_33.Tag = "";
            this._ID_MEM_ETT_TXT_33.Text = "&Nombre";
            // 
            // _ID_MEM_ETT_TXT_34
            // 
            this._ID_MEM_ETT_TXT_34.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_34.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_34.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_34.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_34.Location = new System.Drawing.Point(346, 117);
            this._ID_MEM_ETT_TXT_34.Name = "_ID_MEM_ETT_TXT_34";
            this._ID_MEM_ETT_TXT_34.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_34.Size = new System.Drawing.Size(32, 15);
            this._ID_MEM_ETT_TXT_34.TabIndex = 174;
            this._ID_MEM_ETT_TXT_34.Tag = "";
            this._ID_MEM_ETT_TXT_34.Text = "&Fax";
            // 
            // _ID_MEM_EXT_PIC_2
            // 
            this._ID_MEM_EXT_PIC_2.Location = new System.Drawing.Point(262, 114);
            this._ID_MEM_EXT_PIC_2.Name = "_ID_MEM_EXT_PIC_2";
            this._ID_MEM_EXT_PIC_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_MEM_EXT_PIC_2.OcxState")));
            this._ID_MEM_EXT_PIC_2.Size = new System.Drawing.Size(57, 22);
            this._ID_MEM_EXT_PIC_2.TabIndex = 27;
            this._ID_MEM_EXT_PIC_2.Tag = "";
            this._ID_MEM_EXT_PIC_2.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_EXT_PIC_KeyPressEvent);
            this._ID_MEM_EXT_PIC_2.Enter += new System.EventHandler(this.ID_MEM_EXT_PIC_Enter);
            this._ID_MEM_EXT_PIC_2.Leave += new System.EventHandler(this.ID_MEM_EXT_PIC_Leave);
            // 
            // _ID_MEM_FAX_MKE_2
            // 
            this._ID_MEM_FAX_MKE_2.Location = new System.Drawing.Point(379, 114);
            this._ID_MEM_FAX_MKE_2.Name = "_ID_MEM_FAX_MKE_2";
            this._ID_MEM_FAX_MKE_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_MEM_FAX_MKE_2.OcxState")));
            this._ID_MEM_FAX_MKE_2.Size = new System.Drawing.Size(119, 22);
            this._ID_MEM_FAX_MKE_2.TabIndex = 28;
            this._ID_MEM_FAX_MKE_2.Tag = "";
            this._ID_MEM_FAX_MKE_2.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_FAX_MKE_KeyPressEvent);
            this._ID_MEM_FAX_MKE_2.Enter += new System.EventHandler(this.ID_MEM_FAX_MKE_Enter);
            // 
            // _ID_MEM_PUE_EB_2
            // 
            this._ID_MEM_PUE_EB_2.AcceptsReturn = true;
            this._ID_MEM_PUE_EB_2.BackColor = System.Drawing.Color.White;
            this._ID_MEM_PUE_EB_2.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_PUE_EB_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_PUE_EB_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_PUE_EB_2.Location = new System.Drawing.Point(80, 84);
            this._ID_MEM_PUE_EB_2.MaxLength = 15;
            this._ID_MEM_PUE_EB_2.Name = "_ID_MEM_PUE_EB_2";
            this._ID_MEM_PUE_EB_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_PUE_EB_2.Size = new System.Drawing.Size(198, 20);
            this._ID_MEM_PUE_EB_2.TabIndex = 25;
            this._ID_MEM_PUE_EB_2.Tag = "";
            this._ID_MEM_PUE_EB_2.Enter += new System.EventHandler(this.ID_MEM_PUE_EB_Enter);
            this._ID_MEM_PUE_EB_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_PUE_EB_KeyPress);
            // 
            // _ID_MEM_TEL_MKE_2
            // 
            this._ID_MEM_TEL_MKE_2.Location = new System.Drawing.Point(80, 114);
            this._ID_MEM_TEL_MKE_2.Name = "_ID_MEM_TEL_MKE_2";
            this._ID_MEM_TEL_MKE_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_MEM_TEL_MKE_2.OcxState")));
            this._ID_MEM_TEL_MKE_2.Size = new System.Drawing.Size(117, 22);
            this._ID_MEM_TEL_MKE_2.TabIndex = 26;
            this._ID_MEM_TEL_MKE_2.Tag = "";
            this._ID_MEM_TEL_MKE_2.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_TEL_MKE_KeyPressEvent);
            this._ID_MEM_TEL_MKE_2.Enter += new System.EventHandler(this.ID_MEM_TEL_MKE_Enter);
            // 
            // _ID_MEM_ETT_TXT_32
            // 
            this._ID_MEM_ETT_TXT_32.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_32.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_32.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_32.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_32.Location = new System.Drawing.Point(15, 84);
            this._ID_MEM_ETT_TXT_32.Name = "_ID_MEM_ETT_TXT_32";
            this._ID_MEM_ETT_TXT_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_32.Size = new System.Drawing.Size(73, 15);
            this._ID_MEM_ETT_TXT_32.TabIndex = 172;
            this._ID_MEM_ETT_TXT_32.Tag = "";
            this._ID_MEM_ETT_TXT_32.Text = "&Puesto";
            // 
            // ID_MEM_REP_LB
            // 
            this.ID_MEM_REP_LB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEM_REP_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_REP_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEM_REP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_REP_LB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEM_REP_LB.Location = new System.Drawing.Point(15, 21);
            this.ID_MEM_REP_LB.Name = "ID_MEM_REP_LB";
            this.ID_MEM_REP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_REP_LB.Size = new System.Drawing.Size(188, 17);
            this.ID_MEM_REP_LB.TabIndex = 169;
            this.ID_MEM_REP_LB.Tag = "";
            this.ID_MEM_REP_LB.Text = "Datos del representante 3";
            // 
            // _ID_MEM_ETT_TXT_31
            // 
            this._ID_MEM_ETT_TXT_31.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_31.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_31.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_31.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_31.Location = new System.Drawing.Point(230, 117);
            this._ID_MEM_ETT_TXT_31.Name = "_ID_MEM_ETT_TXT_31";
            this._ID_MEM_ETT_TXT_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_31.Size = new System.Drawing.Size(27, 15);
            this._ID_MEM_ETT_TXT_31.TabIndex = 171;
            this._ID_MEM_ETT_TXT_31.Tag = "";
            this._ID_MEM_ETT_TXT_31.Text = "&Ext.";
            // 
            // ID_MEM_BOR_PB
            // 
            this.ID_MEM_BOR_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEM_BOR_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_BOR_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEM_BOR_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_BOR_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEM_BOR_PB.Location = new System.Drawing.Point(96, 208);
            this.ID_MEM_BOR_PB.Name = "ID_MEM_BOR_PB";
            this.ID_MEM_BOR_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_BOR_PB.Size = new System.Drawing.Size(89, 22);
            this.ID_MEM_BOR_PB.TabIndex = 34;
            this.ID_MEM_BOR_PB.TabStop = false;
            this.ID_MEM_BOR_PB.Tag = "";
            this.ID_MEM_BOR_PB.Text = "&Borrar Repr.";
            this.ID_MEM_BOR_PB.UseVisualStyleBackColor = false;
            this.ID_MEM_BOR_PB.Click += new System.EventHandler(this.ID_MEM_BOR_PB_Click);
            // 
            // _ID_MEM_REP_3OD_1
            // 
            this._ID_MEM_REP_3OD_1.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_REP_3OD_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_REP_3OD_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_REP_3OD_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_REP_3OD_1.Location = new System.Drawing.Point(115, 42);
            this._ID_MEM_REP_3OD_1.Name = "_ID_MEM_REP_3OD_1";
            this._ID_MEM_REP_3OD_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_REP_3OD_1.Size = new System.Drawing.Size(37, 19);
            this._ID_MEM_REP_3OD_1.TabIndex = 17;
            this._ID_MEM_REP_3OD_1.Tag = "";
            this._ID_MEM_REP_3OD_1.Text = "&2";
            this._ID_MEM_REP_3OD_1.UseVisualStyleBackColor = false;
            this._ID_MEM_REP_3OD_1.CheckedChanged += new System.EventHandler(this.ID_MEM_REP_3OD_CheckedChanged);
            this._ID_MEM_REP_3OD_1.Enter += new System.EventHandler(this.ID_MEM_REP_3OD_Enter);
            this._ID_MEM_REP_3OD_1.Leave += new System.EventHandler(this.ID_MEM_REP_3OD_Leave);
            // 
            // _ID_MEM_REP_3OD_0
            // 
            this._ID_MEM_REP_3OD_0.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_REP_3OD_0.Checked = true;
            this._ID_MEM_REP_3OD_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_REP_3OD_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_REP_3OD_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_REP_3OD_0.Location = new System.Drawing.Point(42, 42);
            this._ID_MEM_REP_3OD_0.Name = "_ID_MEM_REP_3OD_0";
            this._ID_MEM_REP_3OD_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_REP_3OD_0.Size = new System.Drawing.Size(37, 19);
            this._ID_MEM_REP_3OD_0.TabIndex = 16;
            this._ID_MEM_REP_3OD_0.TabStop = true;
            this._ID_MEM_REP_3OD_0.Tag = "";
            this._ID_MEM_REP_3OD_0.Text = "&1";
            this._ID_MEM_REP_3OD_0.UseVisualStyleBackColor = false;
            this._ID_MEM_REP_3OD_0.CheckedChanged += new System.EventHandler(this.ID_MEM_REP_3OD_CheckedChanged);
            this._ID_MEM_REP_3OD_0.Enter += new System.EventHandler(this.ID_MEM_REP_3OD_Enter);
            this._ID_MEM_REP_3OD_0.Leave += new System.EventHandler(this.ID_MEM_REP_3OD_Leave);
            // 
            // _ID_MEM_DG_SSP_TabPage3
            // 
            this._ID_MEM_DG_SSP_TabPage3.BackColor = System.Drawing.Color.Transparent;
            this._ID_MEM_DG_SSP_TabPage3.Controls.Add(this.ID_MEM_EJE_FRM);
            this._ID_MEM_DG_SSP_TabPage3.Controls.Add(this.ID_MEM_TEL_FRM);
            this._ID_MEM_DG_SSP_TabPage3.Location = new System.Drawing.Point(4, 22);
            this._ID_MEM_DG_SSP_TabPage3.Name = "_ID_MEM_DG_SSP_TabPage3";
            this._ID_MEM_DG_SSP_TabPage3.Size = new System.Drawing.Size(618, 348);
            this._ID_MEM_DG_SSP_TabPage3.TabIndex = 4;
            this._ID_MEM_DG_SSP_TabPage3.Tag = "";
            this._ID_MEM_DG_SSP_TabPage3.Text = "Tel�fonos / Otros";
            this._ID_MEM_DG_SSP_TabPage3.UseVisualStyleBackColor = true;
            // 
            // ID_MEM_EJE_FRM
            // 
            this.ID_MEM_EJE_FRM.Controls.Add(this.label5);
            this.ID_MEM_EJE_FRM.Controls.Add(this.label4);
            this.ID_MEM_EJE_FRM.Controls.Add(this.CmdAgregarSucursal);
            this.ID_MEM_EJE_FRM.Controls.Add(this.TbSucursalStatus);
            this.ID_MEM_EJE_FRM.Controls.Add(this.CboSucPromotora);
            this.ID_MEM_EJE_FRM.Controls.Add(this.ID_MEM_NOM_COB);
            this.ID_MEM_EJE_FRM.Controls.Add(this.ID_MEM_BUS_PB);
            this.ID_MEM_EJE_FRM.Controls.Add(this.ID_MEM_NNA_EB);
            this.ID_MEM_EJE_FRM.Controls.Add(this._ID_MEM_ETT_TXT_35);
            this.ID_MEM_EJE_FRM.Controls.Add(this._ID_MEM_NO_BORRAR_2);
            this.ID_MEM_EJE_FRM.Controls.Add(this._ID_MEM_ETT_PNL_7);
            this.ID_MEM_EJE_FRM.Controls.Add(this._ID_MEM_ETT_PNL_8);
            this.ID_MEM_EJE_FRM.Controls.Add(this.ID_MEM_NOM_TXT);
            this.ID_MEM_EJE_FRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_EJE_FRM.ForeColor = System.Drawing.Color.Black;
            this.ID_MEM_EJE_FRM.Location = new System.Drawing.Point(14, 150);
            this.ID_MEM_EJE_FRM.Name = "ID_MEM_EJE_FRM";
            this.ID_MEM_EJE_FRM.Size = new System.Drawing.Size(596, 186);
            this.ID_MEM_EJE_FRM.TabIndex = 100;
            this.ID_MEM_EJE_FRM.TabStop = false;
            this.ID_MEM_EJE_FRM.Tag = "";
            this.ID_MEM_EJE_FRM.Text = "Ejecutivo Banamex que atiende a esta Empresa";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(346, 108);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 147;
            this.label5.Tag = "";
            this.label5.Text = "Activa";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(18, 108);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label4.Size = new System.Drawing.Size(119, 17);
            this.label4.TabIndex = 146;
            this.label4.Tag = "";
            this.label4.Text = "Sucursal Promotora";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // CmdAgregarSucursal
            // 
            this.CmdAgregarSucursal.BackColor = System.Drawing.SystemColors.Control;
            this.CmdAgregarSucursal.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmdAgregarSucursal.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.CmdAgregarSucursal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmdAgregarSucursal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CmdAgregarSucursal.Location = new System.Drawing.Point(405, 123);
            this.CmdAgregarSucursal.Name = "CmdAgregarSucursal";
            this.CmdAgregarSucursal.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmdAgregarSucursal.Size = new System.Drawing.Size(74, 22);
            this.CmdAgregarSucursal.TabIndex = 145;
            this.CmdAgregarSucursal.Tag = "BUSCAR";
            this.CmdAgregarSucursal.Text = "Agregar";
            this.CmdAgregarSucursal.UseVisualStyleBackColor = false;
            this.CmdAgregarSucursal.Click += new System.EventHandler(this.CmdAgregarSucursal_Click);
            // 
            // TbSucursalStatus
            // 
            this.TbSucursalStatus.AcceptsReturn = true;
            this.TbSucursalStatus.BackColor = System.Drawing.Color.White;
            this.TbSucursalStatus.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TbSucursalStatus.Enabled = false;
            this.TbSucursalStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbSucursalStatus.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TbSucursalStatus.Location = new System.Drawing.Point(346, 124);
            this.TbSucursalStatus.MaxLength = 15;
            this.TbSucursalStatus.Multiline = true;
            this.TbSucursalStatus.Name = "TbSucursalStatus";
            this.TbSucursalStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TbSucursalStatus.Size = new System.Drawing.Size(50, 19);
            this.TbSucursalStatus.TabIndex = 144;
            this.TbSucursalStatus.Tag = "";
            this.TbSucursalStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CboSucPromotora
            // 
            this.CboSucPromotora.BackColor = System.Drawing.Color.White;
            this.CboSucPromotora.Cursor = System.Windows.Forms.Cursors.Default;
            this.CboSucPromotora.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboSucPromotora.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CboSucPromotora.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this.CboSucPromotora, new int[0]);
            this.CboSucPromotora.Location = new System.Drawing.Point(25, 124);
            this.CboSucPromotora.Name = "CboSucPromotora";
            this.CboSucPromotora.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CboSucPromotora.Size = new System.Drawing.Size(315, 21);
            this.CboSucPromotora.Sorted = true;
            this.CboSucPromotora.TabIndex = 143;
            this.CboSucPromotora.Tag = "";
            this.CboSucPromotora.SelectedIndexChanged += new System.EventHandler(this.CboSucPromotora_SelectedIndexChanged);
            // 
            // ID_MEM_NOM_COB
            // 
            this.ID_MEM_NOM_COB.BackColor = System.Drawing.Color.White;
            this.ID_MEM_NOM_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_NOM_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_MEM_NOM_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_NOM_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this.ID_MEM_NOM_COB, new int[0]);
            this.ID_MEM_NOM_COB.Location = new System.Drawing.Point(13, 50);
            this.ID_MEM_NOM_COB.Name = "ID_MEM_NOM_COB";
            this.ID_MEM_NOM_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_NOM_COB.Size = new System.Drawing.Size(448, 21);
            this.ID_MEM_NOM_COB.Sorted = true;
            this.ID_MEM_NOM_COB.TabIndex = 103;
            this.ID_MEM_NOM_COB.Tag = "";
            this.ID_MEM_NOM_COB.SelectedIndexChanged += new System.EventHandler(this.ID_MEM_NOM_COB_SelectedIndexChanged);
            // 
            // ID_MEM_BUS_PB
            // 
            this.ID_MEM_BUS_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEM_BUS_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_BUS_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEM_BUS_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_BUS_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEM_BUS_PB.Location = new System.Drawing.Point(383, 75);
            this.ID_MEM_BUS_PB.Name = "ID_MEM_BUS_PB";
            this.ID_MEM_BUS_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_BUS_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEM_BUS_PB.TabIndex = 106;
            this.ID_MEM_BUS_PB.Tag = "BUSCAR";
            this.ID_MEM_BUS_PB.Text = "&Buscar";
            this.ID_MEM_BUS_PB.UseVisualStyleBackColor = false;
            this.ID_MEM_BUS_PB.Click += new System.EventHandler(this.ID_MEM_BUS_PB_Click);
            this.ID_MEM_BUS_PB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_BUS_PB_KeyPress);
            // 
            // ID_MEM_NNA_EB
            // 
            this.ID_MEM_NNA_EB.AcceptsReturn = true;
            this.ID_MEM_NNA_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEM_NNA_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEM_NNA_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_NNA_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEM_NNA_EB.Location = new System.Drawing.Point(154, 77);
            this.ID_MEM_NNA_EB.MaxLength = 15;
            this.ID_MEM_NNA_EB.Multiline = true;
            this.ID_MEM_NNA_EB.Name = "ID_MEM_NNA_EB";
            this.ID_MEM_NNA_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_NNA_EB.Size = new System.Drawing.Size(72, 19);
            this.ID_MEM_NNA_EB.TabIndex = 105;
            this.ID_MEM_NNA_EB.Tag = "";
            this.ID_MEM_NNA_EB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ID_MEM_NNA_EB.Click += new System.EventHandler(this.HandleSelection_Click);
            this.ID_MEM_NNA_EB.Enter += new System.EventHandler(this.ID_MEM_NNA_EB_Enter);
            this.ID_MEM_NNA_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_NNA_EB_KeyPress);
            this.ID_MEM_NNA_EB.Leave += new System.EventHandler(this.ID_MEM_NNA_EB_Leave);
            this.ID_MEM_NNA_EB.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // _ID_MEM_ETT_TXT_35
            // 
            this._ID_MEM_ETT_TXT_35.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_35.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_35.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_35.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_35.Location = new System.Drawing.Point(13, 78);
            this._ID_MEM_ETT_TXT_35.Name = "_ID_MEM_ETT_TXT_35";
            this._ID_MEM_ETT_TXT_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_35.Size = new System.Drawing.Size(119, 17);
            this._ID_MEM_ETT_TXT_35.TabIndex = 104;
            this._ID_MEM_ETT_TXT_35.Tag = "";
            this._ID_MEM_ETT_TXT_35.Text = "N�mero de N�mina";
            this._ID_MEM_ETT_TXT_35.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_MEM_NO_BORRAR_2
            // 
            this._ID_MEM_NO_BORRAR_2.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_NO_BORRAR_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_NO_BORRAR_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_NO_BORRAR_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_NO_BORRAR_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_NO_BORRAR_2.Location = new System.Drawing.Point(346, 77);
            this._ID_MEM_NO_BORRAR_2.Name = "_ID_MEM_NO_BORRAR_2";
            this._ID_MEM_NO_BORRAR_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_NO_BORRAR_2.Size = new System.Drawing.Size(28, 20);
            this._ID_MEM_NO_BORRAR_2.TabIndex = 142;
            this._ID_MEM_NO_BORRAR_2.Tag = "";
            this._ID_MEM_NO_BORRAR_2.UseVisualStyleBackColor = false;
            this._ID_MEM_NO_BORRAR_2.Visible = false;
            this._ID_MEM_NO_BORRAR_2.Enter += new System.EventHandler(this.ID_MEM_NO_BORRAR_Enter);
            // 
            // _ID_MEM_ETT_PNL_7
            // 
            this._ID_MEM_ETT_PNL_7.BackColor = System.Drawing.Color.Silver;
            this._ID_MEM_ETT_PNL_7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._ID_MEM_ETT_PNL_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_PNL_7.Location = new System.Drawing.Point(13, 24);
            this._ID_MEM_ETT_PNL_7.Name = "_ID_MEM_ETT_PNL_7";
            this._ID_MEM_ETT_PNL_7.Size = new System.Drawing.Size(52, 19);
            this._ID_MEM_ETT_PNL_7.TabIndex = 101;
            this._ID_MEM_ETT_PNL_7.Tag = "";
            this._ID_MEM_ETT_PNL_7.Text = "&N�mina";
            // 
            // _ID_MEM_ETT_PNL_8
            // 
            this._ID_MEM_ETT_PNL_8.BackColor = System.Drawing.Color.Silver;
            this._ID_MEM_ETT_PNL_8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this._ID_MEM_ETT_PNL_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_PNL_8.Location = new System.Drawing.Point(64, 24);
            this._ID_MEM_ETT_PNL_8.Name = "_ID_MEM_ETT_PNL_8";
            this._ID_MEM_ETT_PNL_8.Size = new System.Drawing.Size(397, 19);
            this._ID_MEM_ETT_PNL_8.TabIndex = 102;
            this._ID_MEM_ETT_PNL_8.Tag = "";
            this._ID_MEM_ETT_PNL_8.Text = "Nom&bre";
            this._ID_MEM_ETT_PNL_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ID_MEM_NOM_TXT
            // 
            this.ID_MEM_NOM_TXT.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEM_NOM_TXT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ID_MEM_NOM_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_NOM_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEM_NOM_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_NOM_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEM_NOM_TXT.Location = new System.Drawing.Point(15, 49);
            this.ID_MEM_NOM_TXT.Name = "ID_MEM_NOM_TXT";
            this.ID_MEM_NOM_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_NOM_TXT.Size = new System.Drawing.Size(446, 20);
            this.ID_MEM_NOM_TXT.TabIndex = 148;
            this.ID_MEM_NOM_TXT.Tag = "";
            this.ID_MEM_NOM_TXT.Visible = false;
            // 
            // ID_MEM_TEL_FRM
            // 
            this.ID_MEM_TEL_FRM.Controls.Add(this.ID_MEM_FAXL_LB);
            this.ID_MEM_TEL_FRM.Controls.Add(this.ID_MEM_EXT_LB);
            this.ID_MEM_TEL_FRM.Controls.Add(this.ID_MEM_LADA_TXT);
            this.ID_MEM_TEL_FRM.Controls.Add(this.ID_MEM_EMAIL_TXT);
            this.ID_MEM_TEL_FRM.Controls.Add(this.ID_MEM_FAX_TXT);
            this.ID_MEM_TEL_FRM.Controls.Add(this._ID_MEM_INTER_LBL_45);
            this.ID_MEM_TEL_FRM.Controls.Add(this._ID_MEM_LADA_LBL_36);
            this.ID_MEM_TEL_FRM.Controls.Add(this._ID_MEM_EMAIL_LBL_44);
            this.ID_MEM_TEL_FRM.Controls.Add(this._ID_MEM_ETT_LBL_23);
            this.ID_MEM_TEL_FRM.Controls.Add(this._ID_MEM_FAX_LBL_38);
            this.ID_MEM_TEL_FRM.Controls.Add(this.ID_MEM_INTER_TXT);
            this.ID_MEM_TEL_FRM.Controls.Add(this.ID_MEM_FAX_LADA_TXT);
            this.ID_MEM_TEL_FRM.Controls.Add(this.ID_MEM_TEL_EXT_TXT);
            this.ID_MEM_TEL_FRM.Controls.Add(this.ID_MEM_CON_TXT);
            this.ID_MEM_TEL_FRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_TEL_FRM.ForeColor = System.Drawing.Color.Black;
            this.ID_MEM_TEL_FRM.Location = new System.Drawing.Point(14, 7);
            this.ID_MEM_TEL_FRM.Name = "ID_MEM_TEL_FRM";
            this.ID_MEM_TEL_FRM.Size = new System.Drawing.Size(596, 137);
            this.ID_MEM_TEL_FRM.TabIndex = 85;
            this.ID_MEM_TEL_FRM.TabStop = false;
            this.ID_MEM_TEL_FRM.Tag = "";
            this.ID_MEM_TEL_FRM.Text = "Tel�fono";
            // 
            // ID_MEM_FAXL_LB
            // 
            this.ID_MEM_FAXL_LB.AutoSize = true;
            this.ID_MEM_FAXL_LB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEM_FAXL_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_FAXL_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEM_FAXL_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_FAXL_LB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEM_FAXL_LB.Location = new System.Drawing.Point(231, 56);
            this.ID_MEM_FAXL_LB.Name = "ID_MEM_FAXL_LB";
            this.ID_MEM_FAXL_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_FAXL_LB.Size = new System.Drawing.Size(59, 13);
            this.ID_MEM_FAXL_LB.TabIndex = 94;
            this.ID_MEM_FAXL_LB.Tag = "";
            this.ID_MEM_FAXL_LB.Text = "Fax Lada";
            // 
            // ID_MEM_EXT_LB
            // 
            this.ID_MEM_EXT_LB.AutoSize = true;
            this.ID_MEM_EXT_LB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEM_EXT_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_EXT_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEM_EXT_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_EXT_LB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEM_EXT_LB.Location = new System.Drawing.Point(231, 29);
            this.ID_MEM_EXT_LB.Name = "ID_MEM_EXT_LB";
            this.ID_MEM_EXT_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_EXT_LB.Size = new System.Drawing.Size(62, 13);
            this.ID_MEM_EXT_LB.TabIndex = 88;
            this.ID_MEM_EXT_LB.Tag = "";
            this.ID_MEM_EXT_LB.Text = "Extensi�n";
            // 
            // ID_MEM_LADA_TXT
            // 
            this.ID_MEM_LADA_TXT.AcceptsReturn = true;
            this.ID_MEM_LADA_TXT.BackColor = System.Drawing.Color.White;
            this.ID_MEM_LADA_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEM_LADA_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_LADA_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEM_LADA_TXT.Location = new System.Drawing.Point(476, 24);
            this.ID_MEM_LADA_TXT.MaxLength = 9;
            this.ID_MEM_LADA_TXT.Multiline = true;
            this.ID_MEM_LADA_TXT.Name = "ID_MEM_LADA_TXT";
            this.ID_MEM_LADA_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_LADA_TXT.Size = new System.Drawing.Size(66, 22);
            this.ID_MEM_LADA_TXT.TabIndex = 91;
            this.ID_MEM_LADA_TXT.Tag = "";
            this.ID_MEM_LADA_TXT.Enter += new System.EventHandler(this.ID_MEM_LADA_TXT_Enter);
            this.ID_MEM_LADA_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_LADA_TXT_KeyPress);
            // 
            // ID_MEM_EMAIL_TXT
            // 
            this.ID_MEM_EMAIL_TXT.AcceptsReturn = true;
            this.ID_MEM_EMAIL_TXT.BackColor = System.Drawing.Color.White;
            this.ID_MEM_EMAIL_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEM_EMAIL_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_EMAIL_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEM_EMAIL_TXT.Location = new System.Drawing.Point(77, 79);
            this.ID_MEM_EMAIL_TXT.MaxLength = 70;
            this.ID_MEM_EMAIL_TXT.Name = "ID_MEM_EMAIL_TXT";
            this.ID_MEM_EMAIL_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_EMAIL_TXT.Size = new System.Drawing.Size(465, 20);
            this.ID_MEM_EMAIL_TXT.TabIndex = 97;
            this.ID_MEM_EMAIL_TXT.Tag = "";
            this.ID_MEM_EMAIL_TXT.Click += new System.EventHandler(this.HandleSelection_Click);
            this.ID_MEM_EMAIL_TXT.Enter += new System.EventHandler(this.ID_MEM_EMAIL_TXT_Enter);
            this.ID_MEM_EMAIL_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_EMAIL_TXT_KeyPress);
            this.ID_MEM_EMAIL_TXT.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            this.ID_MEM_EMAIL_TXT.Validating += new System.ComponentModel.CancelEventHandler(this.ID_MEM_EMAIL_TXT_Validating);
            // 
            // ID_MEM_FAX_TXT
            // 
            this.ID_MEM_FAX_TXT.AcceptsReturn = true;
            this.ID_MEM_FAX_TXT.BackColor = System.Drawing.Color.White;
            this.ID_MEM_FAX_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEM_FAX_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_FAX_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEM_FAX_TXT.Location = new System.Drawing.Point(77, 52);
            this.ID_MEM_FAX_TXT.MaxLength = 10;
            this.ID_MEM_FAX_TXT.Multiline = true;
            this.ID_MEM_FAX_TXT.Name = "ID_MEM_FAX_TXT";
            this.ID_MEM_FAX_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_FAX_TXT.Size = new System.Drawing.Size(115, 22);
            this.ID_MEM_FAX_TXT.TabIndex = 93;
            this.ID_MEM_FAX_TXT.Tag = "";
            this.ID_MEM_FAX_TXT.Click += new System.EventHandler(this.HandleSelection_Click);
            this.ID_MEM_FAX_TXT.Enter += new System.EventHandler(this.ID_MEM_FAX_TXT_Enter);
            this.ID_MEM_FAX_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_FAX_TXT_KeyPress);
            this.ID_MEM_FAX_TXT.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // _ID_MEM_INTER_LBL_45
            // 
            this._ID_MEM_INTER_LBL_45.AutoSize = true;
            this._ID_MEM_INTER_LBL_45.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_INTER_LBL_45.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_INTER_LBL_45.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_INTER_LBL_45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_INTER_LBL_45.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_INTER_LBL_45.Location = new System.Drawing.Point(14, 111);
            this._ID_MEM_INTER_LBL_45.Name = "_ID_MEM_INTER_LBL_45";
            this._ID_MEM_INTER_LBL_45.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_INTER_LBL_45.Size = new System.Drawing.Size(51, 13);
            this._ID_MEM_INTER_LBL_45.TabIndex = 98;
            this._ID_MEM_INTER_LBL_45.Tag = "";
            this._ID_MEM_INTER_LBL_45.Text = "Internet";
            this._ID_MEM_INTER_LBL_45.Visible = false;
            // 
            // _ID_MEM_LADA_LBL_36
            // 
            this._ID_MEM_LADA_LBL_36.AutoSize = true;
            this._ID_MEM_LADA_LBL_36.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_LADA_LBL_36.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_LADA_LBL_36.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_LADA_LBL_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_LADA_LBL_36.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_LADA_LBL_36.Location = new System.Drawing.Point(434, 29);
            this._ID_MEM_LADA_LBL_36.Name = "_ID_MEM_LADA_LBL_36";
            this._ID_MEM_LADA_LBL_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_LADA_LBL_36.Size = new System.Drawing.Size(35, 13);
            this._ID_MEM_LADA_LBL_36.TabIndex = 90;
            this._ID_MEM_LADA_LBL_36.Tag = "";
            this._ID_MEM_LADA_LBL_36.Text = "Lada";
            // 
            // _ID_MEM_EMAIL_LBL_44
            // 
            this._ID_MEM_EMAIL_LBL_44.AutoSize = true;
            this._ID_MEM_EMAIL_LBL_44.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_EMAIL_LBL_44.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_EMAIL_LBL_44.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_EMAIL_LBL_44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_EMAIL_LBL_44.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_EMAIL_LBL_44.Location = new System.Drawing.Point(14, 85);
            this._ID_MEM_EMAIL_LBL_44.Name = "_ID_MEM_EMAIL_LBL_44";
            this._ID_MEM_EMAIL_LBL_44.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_EMAIL_LBL_44.Size = new System.Drawing.Size(37, 13);
            this._ID_MEM_EMAIL_LBL_44.TabIndex = 96;
            this._ID_MEM_EMAIL_LBL_44.Tag = "";
            this._ID_MEM_EMAIL_LBL_44.Text = "Email";
            // 
            // _ID_MEM_ETT_LBL_23
            // 
            this._ID_MEM_ETT_LBL_23.AutoSize = true;
            this._ID_MEM_ETT_LBL_23.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_LBL_23.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_LBL_23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_LBL_23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_LBL_23.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_LBL_23.Location = new System.Drawing.Point(14, 29);
            this._ID_MEM_ETT_LBL_23.Name = "_ID_MEM_ETT_LBL_23";
            this._ID_MEM_ETT_LBL_23.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_LBL_23.Size = new System.Drawing.Size(57, 13);
            this._ID_MEM_ETT_LBL_23.TabIndex = 86;
            this._ID_MEM_ETT_LBL_23.Tag = "";
            this._ID_MEM_ETT_LBL_23.Text = "Tel�fono";
            // 
            // _ID_MEM_FAX_LBL_38
            // 
            this._ID_MEM_FAX_LBL_38.AutoSize = true;
            this._ID_MEM_FAX_LBL_38.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_FAX_LBL_38.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_FAX_LBL_38.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_FAX_LBL_38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_FAX_LBL_38.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_FAX_LBL_38.Location = new System.Drawing.Point(14, 56);
            this._ID_MEM_FAX_LBL_38.Name = "_ID_MEM_FAX_LBL_38";
            this._ID_MEM_FAX_LBL_38.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_FAX_LBL_38.Size = new System.Drawing.Size(27, 13);
            this._ID_MEM_FAX_LBL_38.TabIndex = 92;
            this._ID_MEM_FAX_LBL_38.Tag = "";
            this._ID_MEM_FAX_LBL_38.Text = "Fax";
            // 
            // ID_MEM_INTER_TXT
            // 
            this.ID_MEM_INTER_TXT.AcceptsReturn = true;
            this.ID_MEM_INTER_TXT.BackColor = System.Drawing.Color.White;
            this.ID_MEM_INTER_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEM_INTER_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_INTER_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEM_INTER_TXT.Location = new System.Drawing.Point(77, 106);
            this.ID_MEM_INTER_TXT.MaxLength = 70;
            this.ID_MEM_INTER_TXT.Name = "ID_MEM_INTER_TXT";
            this.ID_MEM_INTER_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_INTER_TXT.Size = new System.Drawing.Size(465, 20);
            this.ID_MEM_INTER_TXT.TabIndex = 99;
            this.ID_MEM_INTER_TXT.Tag = "";
            this.ID_MEM_INTER_TXT.Visible = false;
            this.ID_MEM_INTER_TXT.Click += new System.EventHandler(this.HandleSelection_Click);
            this.ID_MEM_INTER_TXT.Enter += new System.EventHandler(this.ID_MEM_INTER_TXT_Enter);
            this.ID_MEM_INTER_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_INTER_TXT_KeyPress);
            this.ID_MEM_INTER_TXT.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // ID_MEM_FAX_LADA_TXT
            // 
            this.ID_MEM_FAX_LADA_TXT.AcceptsReturn = true;
            this.ID_MEM_FAX_LADA_TXT.BackColor = System.Drawing.Color.White;
            this.ID_MEM_FAX_LADA_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEM_FAX_LADA_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_FAX_LADA_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEM_FAX_LADA_TXT.Location = new System.Drawing.Point(301, 52);
            this.ID_MEM_FAX_LADA_TXT.MaxLength = 9;
            this.ID_MEM_FAX_LADA_TXT.Multiline = true;
            this.ID_MEM_FAX_LADA_TXT.Name = "ID_MEM_FAX_LADA_TXT";
            this.ID_MEM_FAX_LADA_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_FAX_LADA_TXT.Size = new System.Drawing.Size(95, 22);
            this.ID_MEM_FAX_LADA_TXT.TabIndex = 95;
            this.ID_MEM_FAX_LADA_TXT.Tag = "";
            this.ID_MEM_FAX_LADA_TXT.Click += new System.EventHandler(this.HandleSelection_Click);
            this.ID_MEM_FAX_LADA_TXT.Enter += new System.EventHandler(this.ID_MEM_FAX_LADA_TXT_Enter);
            this.ID_MEM_FAX_LADA_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_FAX_LADA_TXT_KeyPress);
            this.ID_MEM_FAX_LADA_TXT.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // ID_MEM_TEL_EXT_TXT
            // 
            this.ID_MEM_TEL_EXT_TXT.AcceptsReturn = true;
            this.ID_MEM_TEL_EXT_TXT.BackColor = System.Drawing.Color.White;
            this.ID_MEM_TEL_EXT_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEM_TEL_EXT_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_TEL_EXT_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEM_TEL_EXT_TXT.Location = new System.Drawing.Point(301, 24);
            this.ID_MEM_TEL_EXT_TXT.MaxLength = 5;
            this.ID_MEM_TEL_EXT_TXT.Multiline = true;
            this.ID_MEM_TEL_EXT_TXT.Name = "ID_MEM_TEL_EXT_TXT";
            this.ID_MEM_TEL_EXT_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_TEL_EXT_TXT.Size = new System.Drawing.Size(94, 22);
            this.ID_MEM_TEL_EXT_TXT.TabIndex = 89;
            this.ID_MEM_TEL_EXT_TXT.Tag = "";
            this.ID_MEM_TEL_EXT_TXT.Click += new System.EventHandler(this.HandleSelection_Click);
            this.ID_MEM_TEL_EXT_TXT.Enter += new System.EventHandler(this.ID_MEM_TEL_EXT_TXT_Enter);
            this.ID_MEM_TEL_EXT_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_TEL_EXT_TXT_KeyPress);
            this.ID_MEM_TEL_EXT_TXT.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // ID_MEM_CON_TXT
            // 
            this.ID_MEM_CON_TXT.AcceptsReturn = true;
            this.ID_MEM_CON_TXT.BackColor = System.Drawing.Color.White;
            this.ID_MEM_CON_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEM_CON_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_CON_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEM_CON_TXT.Location = new System.Drawing.Point(77, 24);
            this.ID_MEM_CON_TXT.MaxLength = 10;
            this.ID_MEM_CON_TXT.Multiline = true;
            this.ID_MEM_CON_TXT.Name = "ID_MEM_CON_TXT";
            this.ID_MEM_CON_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_CON_TXT.Size = new System.Drawing.Size(116, 22);
            this.ID_MEM_CON_TXT.TabIndex = 87;
            this.ID_MEM_CON_TXT.Tag = "";
            this.ID_MEM_CON_TXT.Click += new System.EventHandler(this.HandleSelection_Click);
            this.ID_MEM_CON_TXT.Enter += new System.EventHandler(this.ID_MEM_CON_TXT_Enter);
            this.ID_MEM_CON_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_CON_TXT_KeyPress);
            this.ID_MEM_CON_TXT.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // _ID_MEM_DG_SSP_TabPage4
            // 
            this._ID_MEM_DG_SSP_TabPage4.BackColor = System.Drawing.Color.Transparent;
            this._ID_MEM_DG_SSP_TabPage4.Controls.Add(this.mskMCC);
            this._ID_MEM_DG_SSP_TabPage4.Controls.Add(this._ID_MEM_MES_FIS_LBL_1);
            this._ID_MEM_DG_SSP_TabPage4.Controls.Add(this._fraDatosAdicionales_0);
            this._ID_MEM_DG_SSP_TabPage4.Controls.Add(this.ID_MEM_MES_FIS_CBO);
            this._ID_MEM_DG_SSP_TabPage4.Controls.Add(this.ID_MEM_CEJ_FRM);
            this._ID_MEM_DG_SSP_TabPage4.Controls.Add(this.cboEstructuraGastos);
            this._ID_MEM_DG_SSP_TabPage4.Controls.Add(this._ID_MEM_ETT_TXT_39);
            this._ID_MEM_DG_SSP_TabPage4.Controls.Add(this._ID_MEM_MES_FIS_LBL_0);
            this._ID_MEM_DG_SSP_TabPage4.Controls.Add(this._fraDatosAdicionales_3);
            this._ID_MEM_DG_SSP_TabPage4.Location = new System.Drawing.Point(4, 22);
            this._ID_MEM_DG_SSP_TabPage4.Name = "_ID_MEM_DG_SSP_TabPage4";
            this._ID_MEM_DG_SSP_TabPage4.Size = new System.Drawing.Size(618, 348);
            this._ID_MEM_DG_SSP_TabPage4.TabIndex = 3;
            this._ID_MEM_DG_SSP_TabPage4.Tag = "";
            this._ID_MEM_DG_SSP_TabPage4.Text = "Datos Adicionales";
            this._ID_MEM_DG_SSP_TabPage4.UseVisualStyleBackColor = true;
            // 
            // mskMCC
            // 
            this.mskMCC.Location = new System.Drawing.Point(462, 59);
            this.mskMCC.Name = "mskMCC";
            this.mskMCC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mskMCC.OcxState")));
            this.mskMCC.Size = new System.Drawing.Size(136, 22);
            this.mskMCC.TabIndex = 153;
            this.mskMCC.Tag = "";
            // 
            // _ID_MEM_MES_FIS_LBL_1
            // 
            this._ID_MEM_MES_FIS_LBL_1.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_MES_FIS_LBL_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_MES_FIS_LBL_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_MES_FIS_LBL_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_MES_FIS_LBL_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_MES_FIS_LBL_1.Location = new System.Drawing.Point(326, 62);
            this._ID_MEM_MES_FIS_LBL_1.Name = "_ID_MEM_MES_FIS_LBL_1";
            this._ID_MEM_MES_FIS_LBL_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_MES_FIS_LBL_1.Size = new System.Drawing.Size(146, 17);
            this._ID_MEM_MES_FIS_LBL_1.TabIndex = 154;
            this._ID_MEM_MES_FIS_LBL_1.Tag = "";
            this._ID_MEM_MES_FIS_LBL_1.Text = "Tabla MCC / Negocio";
            // 
            // _fraDatosAdicionales_0
            // 
            this._fraDatosAdicionales_0.Controls.Add(this._ID_MEM_EEC_3OPB_0);
            this._fraDatosAdicionales_0.Controls.Add(this._ID_MEM_EEC_3OPB_1);
            this._fraDatosAdicionales_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraDatosAdicionales_0.ForeColor = System.Drawing.Color.Black;
            this._fraDatosAdicionales_0.Location = new System.Drawing.Point(13, 131);
            this._fraDatosAdicionales_0.Name = "_fraDatosAdicionales_0";
            this._fraDatosAdicionales_0.Size = new System.Drawing.Size(296, 50);
            this._fraDatosAdicionales_0.TabIndex = 114;
            this._fraDatosAdicionales_0.TabStop = false;
            this._fraDatosAdicionales_0.Tag = "";
            this._fraDatosAdicionales_0.Text = "Env�o Estado de Cuenta";
            // 
            // _ID_MEM_EEC_3OPB_0
            // 
            this._ID_MEM_EEC_3OPB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_EEC_3OPB_0.Location = new System.Drawing.Point(35, 20);
            this._ID_MEM_EEC_3OPB_0.Name = "_ID_MEM_EEC_3OPB_0";
            this._ID_MEM_EEC_3OPB_0.Size = new System.Drawing.Size(95, 23);
            this._ID_MEM_EEC_3OPB_0.TabIndex = 115;
            this._ID_MEM_EEC_3OPB_0.Tag = "";
            this._ID_MEM_EEC_3OPB_0.Text = "&Empresa";
            // 
            // _ID_MEM_EEC_3OPB_1
            // 
            this._ID_MEM_EEC_3OPB_1.Checked = true;
            this._ID_MEM_EEC_3OPB_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_EEC_3OPB_1.Location = new System.Drawing.Point(160, 20);
            this._ID_MEM_EEC_3OPB_1.Name = "_ID_MEM_EEC_3OPB_1";
            this._ID_MEM_EEC_3OPB_1.Size = new System.Drawing.Size(97, 23);
            this._ID_MEM_EEC_3OPB_1.TabIndex = 116;
            this._ID_MEM_EEC_3OPB_1.TabStop = true;
            this._ID_MEM_EEC_3OPB_1.Tag = "";
            this._ID_MEM_EEC_3OPB_1.Text = "&Individual";
            // 
            // ID_MEM_MES_FIS_CBO
            // 
            this.ID_MEM_MES_FIS_CBO.BackColor = System.Drawing.Color.White;
            this.ID_MEM_MES_FIS_CBO.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEM_MES_FIS_CBO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_MEM_MES_FIS_CBO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_MES_FIS_CBO.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this.ID_MEM_MES_FIS_CBO, new int[0]);
            this.ID_MEM_MES_FIS_CBO.Location = new System.Drawing.Point(113, 60);
            this.ID_MEM_MES_FIS_CBO.Name = "ID_MEM_MES_FIS_CBO";
            this.ID_MEM_MES_FIS_CBO.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEM_MES_FIS_CBO.Size = new System.Drawing.Size(178, 21);
            this.ID_MEM_MES_FIS_CBO.TabIndex = 112;
            this.ID_MEM_MES_FIS_CBO.Tag = "";
            this.ID_MEM_MES_FIS_CBO.SelectedIndexChanged += new System.EventHandler(this.ID_MEM_MES_FIS_CBO_SelectedIndexChanged);
            // 
            // ID_MEM_CEJ_FRM
            // 
            this.ID_MEM_CEJ_FRM.Controls.Add(this.ID_MEM_NMC_FTB);
            this.ID_MEM_CEJ_FRM.Controls.Add(this.ID_MEM_SUC_ITB);
            this.ID_MEM_CEJ_FRM.Controls.Add(this._ID_MEM_ETT_TXT_41);
            this.ID_MEM_CEJ_FRM.Controls.Add(this._ID_MEM_ETT_TXT_40);
            this.ID_MEM_CEJ_FRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEM_CEJ_FRM.ForeColor = System.Drawing.Color.Black;
            this.ID_MEM_CEJ_FRM.Location = new System.Drawing.Point(13, 204);
            this.ID_MEM_CEJ_FRM.Name = "ID_MEM_CEJ_FRM";
            this.ID_MEM_CEJ_FRM.Size = new System.Drawing.Size(296, 83);
            this.ID_MEM_CEJ_FRM.TabIndex = 130;
            this.ID_MEM_CEJ_FRM.TabStop = false;
            this.ID_MEM_CEJ_FRM.Tag = "";
            this.ID_MEM_CEJ_FRM.Text = "&Cuenta Eje";
            // 
            // ID_MEM_NMC_FTB
            // 
            this.ID_MEM_NMC_FTB.Location = new System.Drawing.Point(137, 49);
            this.ID_MEM_NMC_FTB.Name = "ID_MEM_NMC_FTB";
            this.ID_MEM_NMC_FTB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEM_NMC_FTB.OcxState")));
            this.ID_MEM_NMC_FTB.Size = new System.Drawing.Size(79, 23);
            this.ID_MEM_NMC_FTB.TabIndex = 133;
            this.ID_MEM_NMC_FTB.Tag = "";
            this.ID_MEM_NMC_FTB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_NMC_FTB_KeyPressEvent);
            this.ID_MEM_NMC_FTB.Enter += new System.EventHandler(this.ID_MEM_NMC_FTB_Enter);
            // 
            // ID_MEM_SUC_ITB
            // 
            this.ID_MEM_SUC_ITB.Location = new System.Drawing.Point(103, 14);
            this.ID_MEM_SUC_ITB.Name = "ID_MEM_SUC_ITB";
            this.ID_MEM_SUC_ITB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEM_SUC_ITB.OcxState")));
            this.ID_MEM_SUC_ITB.Size = new System.Drawing.Size(54, 22);
            this.ID_MEM_SUC_ITB.TabIndex = 132;
            this.ID_MEM_SUC_ITB.Tag = "";
            this.ID_MEM_SUC_ITB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_SUC_ITB_KeyPressEvent);
            this.ID_MEM_SUC_ITB.Enter += new System.EventHandler(this.ID_MEM_SUC_ITB_Enter);
            // 
            // _ID_MEM_ETT_TXT_41
            // 
            this._ID_MEM_ETT_TXT_41.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_41.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_41.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_41.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_41.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_41.Location = new System.Drawing.Point(74, 54);
            this._ID_MEM_ETT_TXT_41.Name = "_ID_MEM_ETT_TXT_41";
            this._ID_MEM_ETT_TXT_41.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_41.Size = new System.Drawing.Size(52, 13);
            this._ID_MEM_ETT_TXT_41.TabIndex = 134;
            this._ID_MEM_ETT_TXT_41.Tag = "";
            this._ID_MEM_ETT_TXT_41.Text = "Cuen&ta";
            // 
            // _ID_MEM_ETT_TXT_40
            // 
            this._ID_MEM_ETT_TXT_40.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_40.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_40.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_40.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_40.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_40.Location = new System.Drawing.Point(74, 24);
            this._ID_MEM_ETT_TXT_40.Name = "_ID_MEM_ETT_TXT_40";
            this._ID_MEM_ETT_TXT_40.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_40.Size = new System.Drawing.Size(54, 15);
            this._ID_MEM_ETT_TXT_40.TabIndex = 131;
            this._ID_MEM_ETT_TXT_40.Tag = "";
            this._ID_MEM_ETT_TXT_40.Text = "&Sucursal";
            // 
            // cboEstructuraGastos
            // 
            this.cboEstructuraGastos.BackColor = System.Drawing.Color.White;
            this.cboEstructuraGastos.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboEstructuraGastos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstructuraGastos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboEstructuraGastos.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this.cboEstructuraGastos, new int[0]);
            this.cboEstructuraGastos.Location = new System.Drawing.Point(155, 91);
            this.cboEstructuraGastos.Name = "cboEstructuraGastos";
            this.cboEstructuraGastos.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboEstructuraGastos.Size = new System.Drawing.Size(136, 21);
            this.cboEstructuraGastos.Sorted = true;
            this.cboEstructuraGastos.TabIndex = 126;
            this.cboEstructuraGastos.Tag = "";
            this.cboEstructuraGastos.SelectedIndexChanged += new System.EventHandler(this.cboEstructuraGastos_SelectedIndexChanged);
            // 
            // _ID_MEM_ETT_TXT_39
            // 
            this._ID_MEM_ETT_TXT_39.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_39.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_39.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_39.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_39.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_39.Location = new System.Drawing.Point(19, 93);
            this._ID_MEM_ETT_TXT_39.Name = "_ID_MEM_ETT_TXT_39";
            this._ID_MEM_ETT_TXT_39.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_39.Size = new System.Drawing.Size(137, 17);
            this._ID_MEM_ETT_TXT_39.TabIndex = 125;
            this._ID_MEM_ETT_TXT_39.Tag = "";
            this._ID_MEM_ETT_TXT_39.Text = "Estructura de Gastos";
            // 
            // _ID_MEM_MES_FIS_LBL_0
            // 
            this._ID_MEM_MES_FIS_LBL_0.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_MES_FIS_LBL_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_MES_FIS_LBL_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_MES_FIS_LBL_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_MES_FIS_LBL_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_MES_FIS_LBL_0.Location = new System.Drawing.Point(19, 62);
            this._ID_MEM_MES_FIS_LBL_0.Name = "_ID_MEM_MES_FIS_LBL_0";
            this._ID_MEM_MES_FIS_LBL_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_MES_FIS_LBL_0.Size = new System.Drawing.Size(86, 17);
            this._ID_MEM_MES_FIS_LBL_0.TabIndex = 111;
            this._ID_MEM_MES_FIS_LBL_0.Tag = "";
            this._ID_MEM_MES_FIS_LBL_0.Text = "Mes Fiscal";
            // 
            // _fraDatosAdicionales_3
            // 
            this._fraDatosAdicionales_3.Controls.Add(this._ID_MEM_TFA_3OPB_0);
            this._fraDatosAdicionales_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraDatosAdicionales_3.ForeColor = System.Drawing.Color.Black;
            this._fraDatosAdicionales_3.Location = new System.Drawing.Point(326, 131);
            this._fraDatosAdicionales_3.Name = "_fraDatosAdicionales_3";
            this._fraDatosAdicionales_3.Size = new System.Drawing.Size(280, 50);
            this._fraDatosAdicionales_3.TabIndex = 127;
            this._fraDatosAdicionales_3.TabStop = false;
            this._fraDatosAdicionales_3.Tag = "";
            this._fraDatosAdicionales_3.Text = "Tipo de &Facturaci�n";
            // 
            // _ID_MEM_TFA_3OPB_0
            // 
            this._ID_MEM_TFA_3OPB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_TFA_3OPB_0.Location = new System.Drawing.Point(99, 19);
            this._ID_MEM_TFA_3OPB_0.Name = "_ID_MEM_TFA_3OPB_0";
            this._ID_MEM_TFA_3OPB_0.Size = new System.Drawing.Size(100, 22);
            this._ID_MEM_TFA_3OPB_0.TabIndex = 128;
            this._ID_MEM_TFA_3OPB_0.Tag = "";
            this._ID_MEM_TFA_3OPB_0.Text = "&Corporativo";
            this._ID_MEM_TFA_3OPB_0.CheckedChanged += new System.EventHandler(this._ID_MEM_TFA_3OPB_0_CheckedChanged);
            // 
            // axgear3
            // 
            this.axgear3.Enabled = true;
            this.axgear3.Location = new System.Drawing.Point(282, 193);
            this.axgear3.Name = "axgear3";
            this.axgear3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axgear3.OcxState")));
            this.axgear3.Size = new System.Drawing.Size(100, 50);
            this.axgear3.TabIndex = 143;
            this.axgear3.Visible = false;
            // 
            // axgear1
            // 
            this.axgear1.Enabled = true;
            this.axgear1.Location = new System.Drawing.Point(274, 185);
            this.axgear1.Name = "axgear1";
            this.axgear1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axgear1.OcxState")));
            this.axgear1.Size = new System.Drawing.Size(100, 50);
            this.axgear1.TabIndex = 142;
            this.axgear1.Visible = false;
            // 
            // CORMNEMP
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(650, 424);
            this.Controls.Add(this.axgear3);
            this.Controls.Add(this.axgear1);
            this.Controls.Add(this.ID_MEM_DG_SSP);
            this.Controls.Add(this.ID_MEM_IMP_PB);
            this.Controls.Add(this.ID_MEM_OK_PB);
            this.Controls.Add(this.ID_MEM_CAN_PB);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(152, 185);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORMNEMP";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Empresas";
            this.Activated += new System.EventHandler(this.CORMNEMP_Activated);
            this.Closed += new System.EventHandler(this.CORMNEMP_Closed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORMNEMP_KeyPress);
            this.ID_MEM_DG_SSP.ResumeLayout(false);
            this._ID_MEM_DG_SSP_TabPage0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axgear2)).EndInit();
            this.ID_MEM_DGR_FRM.ResumeLayout(false);
            this.ID_MEM_DGR_FRM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mskNumEmp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEM_RFC_MKE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEM_CLI_MKE)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mskDiaCorte)).EndInit();
            this.ID_MEM_CTA_FRM.ResumeLayout(false);
            this._ID_MEM_DG_SSP_TabPage1.ResumeLayout(false);
            this._ID_MEM_DOM_PNL_1.ResumeLayout(false);
            this._ID_MEM_DOM_PNL_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_CP_PIC_1)).EndInit();
            this._ID_MEM_DOM_PNL_0.ResumeLayout(false);
            this._ID_MEM_DOM_PNL_0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_CP_PIC_0)).EndInit();
            this._ID_MEM_DG_SSP_TabPage2.ResumeLayout(false);
            this.ID_MEM_REP_FRM.ResumeLayout(false);
            this._ID_MEM_REP_PNL_0.ResumeLayout(false);
            this._ID_MEM_REP_PNL_0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_TEL_MKE_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_EXT_PIC_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_FAX_MKE_0)).EndInit();
            this._ID_MEM_REP_PNL_1.ResumeLayout(false);
            this._ID_MEM_REP_PNL_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_TEL_MKE_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_FAX_MKE_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_EXT_PIC_1)).EndInit();
            this._ID_MEM_REP_PNL_2.ResumeLayout(false);
            this._ID_MEM_REP_PNL_2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_EXT_PIC_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_FAX_MKE_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_TEL_MKE_2)).EndInit();
            this._ID_MEM_DG_SSP_TabPage3.ResumeLayout(false);
            this.ID_MEM_EJE_FRM.ResumeLayout(false);
            this.ID_MEM_EJE_FRM.PerformLayout();
            this.ID_MEM_TEL_FRM.ResumeLayout(false);
            this.ID_MEM_TEL_FRM.PerformLayout();
            this._ID_MEM_DG_SSP_TabPage4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mskMCC)).EndInit();
            this._fraDatosAdicionales_0.ResumeLayout(false);
            this.ID_MEM_CEJ_FRM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEM_NMC_FTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEM_SUC_ITB)).EndInit();
            this._fraDatosAdicionales_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axgear3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.axgear1)).EndInit();
            this.ResumeLayout(false);

	}
	void  InitializeID_MEM_DOM_PNL()
	{
			this.ID_MEM_DOM_PNL[0] = _ID_MEM_DOM_PNL_0;
			this.ID_MEM_DOM_PNL[1] = _ID_MEM_DOM_PNL_1;
	}
	void  InitializeID_MEM_TPA_3OPB()
	{
            //this.ID_MEM_TPA_3OPB[0] = _ID_MEM_TPA_3OPB_0;
            //this.ID_MEM_TPA_3OPB[1] = _ID_MEM_TPA_3OPB_1;
            //this.ID_MEM_TPA_3OPB[2] = _ID_MEM_TPA_3OPB_2;
	}
	void  InitializeID_MEM_TEX_PNL()
	{
			this.ID_MEM_TEX_PNL[2] = _ID_MEM_TEX_PNL_2;
			this.ID_MEM_TEX_PNL[1] = _ID_MEM_TEX_PNL_1;
			this.ID_MEM_TEX_PNL[0] = _ID_MEM_TEX_PNL_0;
			this.ID_MEM_TEX_PNL[3] = _ID_MEM_TEX_PNL_3;
	}
	void  InitializeID_MEM_ETT_PNL()
	{
			this.ID_MEM_ETT_PNL[2] = _ID_MEM_ETT_PNL_2;
			this.ID_MEM_ETT_PNL[1] = _ID_MEM_ETT_PNL_1;
			this.ID_MEM_ETT_PNL[0] = _ID_MEM_ETT_PNL_0;
			//this.ID_MEM_ETT_PNL[7] = _ID_MEM_ETT_PNL_7;
			//this.ID_MEM_ETT_PNL[8] = _ID_MEM_ETT_PNL_8;
	}
	void  InitializeID_MEM_CIU_EB()
	{
			this.ID_MEM_CIU_EB[0] = _ID_MEM_CIU_EB_0;
			this.ID_MEM_CIU_EB[1] = _ID_MEM_CIU_EB_1;
	}
	void  InitializeID_MEM_REP_PNL()
	{
			this.ID_MEM_REP_PNL[0] = _ID_MEM_REP_PNL_0;
			this.ID_MEM_REP_PNL[2] = _ID_MEM_REP_PNL_2;
			this.ID_MEM_REP_PNL[1] = _ID_MEM_REP_PNL_1;
	}
	void  InitializefraDatosAdicionales()
	{
        //this.fraDatosAdicionales[0] = _fraDatosAdicionales_0;
        //this.fraDatosAdicionales[2] = _fraDatosAdicionales_0;
        //this.fraDatosAdicionales[1] = _fraDatosAdicionales_0;
        //this.fraDatosAdicionales[3] = _fraDatosAdicionales_3;
        //this.fraDatosAdicionales[4] = _fraDatosAdicionales_3;
	}
	void  InitializeID_MEM_COL_EB()
	{
			this.ID_MEM_COL_EB[0] = _ID_MEM_COL_EB_0;
			this.ID_MEM_COL_EB[1] = _ID_MEM_COL_EB_1;
	}
	void  InitializeID_MEM_EEC_3OPB()
	{
			this.ID_MEM_EEC_3OPB[0] = _ID_MEM_EEC_3OPB_0;
			this.ID_MEM_EEC_3OPB[1] = _ID_MEM_EEC_3OPB_1;
	}
	void  InitializeID_MEM_EDO_EB()
	{
			this.ID_MEM_EDO_EB[0] = _ID_MEM_EDO_EB_0;
			this.ID_MEM_EDO_EB[1] = _ID_MEM_EDO_EB_1;
	}
	void  InitializeID_MEM_CP_PIC()
	{
			this.ID_MEM_CP_PIC[0] = _ID_MEM_CP_PIC_0;
			this.ID_MEM_CP_PIC[1] = _ID_MEM_CP_PIC_1;
	}
	void  InitializeID_MEM_NO_BORRAR()
	{
			this.ID_MEM_NO_BORRAR[2] = _ID_MEM_NO_BORRAR_2;
			this.ID_MEM_NO_BORRAR[0] = _ID_MEM_NO_BORRAR_0;
	}
	void  InitializeID_MEM_EXT_PIC()
	{
			this.ID_MEM_EXT_PIC[0] = _ID_MEM_EXT_PIC_0;
			this.ID_MEM_EXT_PIC[2] = _ID_MEM_EXT_PIC_2;
			this.ID_MEM_EXT_PIC[1] = _ID_MEM_EXT_PIC_1;
	}
	void  InitializeID_MEM_ETT_TXT()
	{
			this.ID_MEM_ETT_TXT[18] = _ID_MEM_ETT_TXT_18;
			this.ID_MEM_ETT_TXT[19] = _ID_MEM_ETT_TXT_19;
			this.ID_MEM_ETT_TXT[17] = _ID_MEM_ETT_TXT_17;
			this.ID_MEM_ETT_TXT[16] = _ID_MEM_ETT_TXT_16;
			this.ID_MEM_ETT_TXT[20] = _ID_MEM_ETT_TXT_20;
			this.ID_MEM_ETT_TXT[34] = _ID_MEM_ETT_TXT_34;
			this.ID_MEM_ETT_TXT[33] = _ID_MEM_ETT_TXT_33;
			this.ID_MEM_ETT_TXT[32] = _ID_MEM_ETT_TXT_32;
			this.ID_MEM_ETT_TXT[31] = _ID_MEM_ETT_TXT_31;
			//this.ID_MEM_ETT_TXT[30] = _ID_MEM_ETT_TXT_30;
			this.ID_MEM_ETT_TXT[22] = _ID_MEM_ETT_TXT_22;
			this.ID_MEM_ETT_TXT[11] = _ID_MEM_ETT_TXT_11;
			this.ID_MEM_ETT_TXT[1] = _ID_MEM_ETT_TXT_1;
			this.ID_MEM_ETT_TXT[0] = _ID_MEM_ETT_TXT_0;
			this.ID_MEM_ETT_TXT[21] = _ID_MEM_ETT_TXT_21;
			this.ID_MEM_ETT_TXT[40] = _ID_MEM_ETT_TXT_40;
			this.ID_MEM_ETT_TXT[41] = _ID_MEM_ETT_TXT_41;
			this.ID_MEM_ETT_TXT[35] = _ID_MEM_ETT_TXT_35;
			this.ID_MEM_ETT_TXT[36] = _ID_MEM_ETT_TXT_36;
            //this.ID_MEM_ETT_TXT[23] = _ID_MEM_ETT_TXT_23;
            //this.ID_MEM_ETT_TXT[37] = _ID_MEM_ETT_TXT_37;
			this.ID_MEM_ETT_TXT[38] = _ID_MEM_ETT_TXT_38;
            //this.ID_MEM_ETT_TXT[8] = _ID_MEM_ETT_TXT_8;
			this.ID_MEM_ETT_TXT[6] = _ID_MEM_ETT_TXT_6;
			this.ID_MEM_ETT_TXT[7] = _ID_MEM_ETT_TXT_7;
            //this.ID_MEM_ETT_TXT[5] = _ID_MEM_ETT_TXT_5;
			this.ID_MEM_ETT_TXT[4] = _ID_MEM_ETT_TXT_4;
			this.ID_MEM_ETT_TXT[3] = _ID_MEM_ETT_TXT_3;
			this.ID_MEM_ETT_TXT[2] = _ID_MEM_ETT_TXT_2;
			this.ID_MEM_ETT_TXT[9] = _ID_MEM_ETT_TXT_9;
			this.ID_MEM_ETT_TXT[10] = _ID_MEM_ETT_TXT_10;
			this.ID_MEM_ETT_TXT[14] = _ID_MEM_ETT_TXT_14;
			this.ID_MEM_ETT_TXT[13] = _ID_MEM_ETT_TXT_13;
			this.ID_MEM_ETT_TXT[12] = _ID_MEM_ETT_TXT_12;
			this.ID_MEM_ETT_TXT[15] = _ID_MEM_ETT_TXT_15;
			this.ID_MEM_ETT_TXT[24] = _ID_MEM_ETT_TXT_24;
			this.ID_MEM_ETT_TXT[25] = _ID_MEM_ETT_TXT_25;
			this.ID_MEM_ETT_TXT[26] = _ID_MEM_ETT_TXT_26;
			this.ID_MEM_ETT_TXT[27] = _ID_MEM_ETT_TXT_27;
			this.ID_MEM_ETT_TXT[28] = _ID_MEM_ETT_TXT_28;
			this.ID_MEM_ETT_TXT[29] = _ID_MEM_ETT_TXT_29;
			this.ID_MEM_ETT_TXT[39] = _ID_MEM_ETT_TXT_39;
	}
	void  InitializeoptTipoProducto()
	{
            //this.optTipoProducto[0] = _optTipoProducto_0;
            //this.optTipoProducto[1] = _optTipoProducto_1;
            //this.optTipoProducto[2] = _optTipoProducto_2;
	}
	void  InitializeID_MEM_MES_FIS_LBL()
	{
            //this.ID_MEM_MES_FIS_LBL[4] = _ID_MEM_MES_FIS_LBL_4;
            //this.ID_MEM_MES_FIS_LBL[3] = _ID_MEM_MES_FIS_LBL_3;
            //this.ID_MEM_MES_FIS_LBL[2] = _ID_MEM_MES_FIS_LBL_2;
            //this.ID_MEM_MES_FIS_LBL[1] = _ID_MEM_MES_FIS_LBL_1;
            //this.ID_MEM_MES_FIS_LBL[0] = _ID_MEM_MES_FIS_LBL_0;
	}
	void  InitializeID_MEM_PDM_EB()
	{
			this.ID_MEM_PDM_EB[0] = _ID_MEM_PDM_EB_0;
			this.ID_MEM_PDM_EB[1] = _ID_MEM_PDM_EB_1;
	}

    //void  InitializeoptEmpresa()
    //{
    //        this.optEmpresa[0] = _optEmpresa_0;
    //        this.optEmpresa[1] = _optEmpresa_1;
    //        this.optEmpresa[2] = _optEmpresa_2;
    //}

	void  InitializechkCheckBox()
	{
            //this.chkCheckBox[2] = _chkCheckBox_2;
            //this.chkCheckBox[0] = _chkCheckBox_0;
            //this.chkCheckBox[1] = _chkCheckBox_1;
	}
	void  InitializeID_MEM_EMAIL_LBL()
	{
			this.ID_MEM_EMAIL_LBL[44] = _ID_MEM_EMAIL_LBL_44;
	}
	void  InitializeID_MEM_TFA_3OPB()
	{
			this.ID_MEM_TFA_3OPB[0] = _ID_MEM_TFA_3OPB_0;
            //this.ID_MEM_TFA_3OPB[1] = _ID_MEM_TFA_3OPB_1;
	}
	void  InitializeID_MEM_FEC_VEN_LBL()
	{
            //this.ID_MEM_FEC_VEN_LBL[36] = _ID_MEM_FEC_VEN_LBL_36;
	}
	void  InitializeID_MEM_ETT_LBL()
	{
			this.ID_MEM_ETT_LBL[23] = _ID_MEM_ETT_LBL_23;
	}
	void  InitializeID_MEM_FAX_MKE()
	{
			this.ID_MEM_FAX_MKE[0] = _ID_MEM_FAX_MKE_0;
			this.ID_MEM_FAX_MKE[2] = _ID_MEM_FAX_MKE_2;
			this.ID_MEM_FAX_MKE[1] = _ID_MEM_FAX_MKE_1;
	}
	void  InitializeID_MEM_TEL_MKE()
	{
			this.ID_MEM_TEL_MKE[0] = _ID_MEM_TEL_MKE_0;
			this.ID_MEM_TEL_MKE[2] = _ID_MEM_TEL_MKE_2;
			this.ID_MEM_TEL_MKE[1] = _ID_MEM_TEL_MKE_1;
	}
	void  InitializeID_MEE_ETT_TXT()
	{
            //this.ID_MEE_ETT_TXT[7] = _ID_MEE_ETT_TXT_7;
            //this.ID_MEE_ETT_TXT[9] = _ID_MEE_ETT_TXT_9;
	}
	void  InitializeID_MEM_LADA_LBL()
	{
			this.ID_MEM_LADA_LBL[36] = _ID_MEM_LADA_LBL_36;
	}
	void  InitializeID_MEM_NOM_EB()
	{
			this.ID_MEM_NOM_EB[0] = _ID_MEM_NOM_EB_0;
			this.ID_MEM_NOM_EB[2] = _ID_MEM_NOM_EB_2;
			this.ID_MEM_NOM_EB[1] = _ID_MEM_NOM_EB_1;
	}
	void  InitializeID_MEM_REP_3OD()
	{
			this.ID_MEM_REP_3OD[1] = _ID_MEM_REP_3OD_1;
			this.ID_MEM_REP_3OD[2] = _ID_MEM_REP_3OD_2;
			this.ID_MEM_REP_3OD[0] = _ID_MEM_REP_3OD_0;
	}
	void  InitializeID_MEM_DOM_EB()
	{
			this.ID_MEM_DOM_EB[0] = _ID_MEM_DOM_EB_0;
			this.ID_MEM_DOM_EB[1] = _ID_MEM_DOM_EB_1;
	}
	void  InitializeID_MEM_FAX_LBL()
	{
			this.ID_MEM_FAX_LBL[38] = _ID_MEM_FAX_LBL_38;
	}
	void  InitializeID_MEM_INTER_LBL()
	{
			this.ID_MEM_INTER_LBL[45] = _ID_MEM_INTER_LBL_45;
	}
	void  InitializeID_MEM_PUE_EB()
	{
			this.ID_MEM_PUE_EB[0] = _ID_MEM_PUE_EB_0;
			this.ID_MEM_PUE_EB[2] = _ID_MEM_PUE_EB_2;
			this.ID_MEM_PUE_EB[1] = _ID_MEM_PUE_EB_1;
	}
#endregion 

        private System.Windows.Forms.Label label1;
        public AxMSMask.AxMaskEdBox mskNumEmp;
        private System.Windows.Forms.Label label2;
        public AxMSMask.AxMaskEdBox mskMCC;
        private System.Windows.Forms.Label _ID_MEM_MES_FIS_LBL_1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Button CmdAgregarSucursal;
        public System.Windows.Forms.TextBox TbSucursalStatus;
        public System.Windows.Forms.ComboBox CboSucPromotora;
        public System.Windows.Forms.Label ID_MEM_NOM_TXT;
        //private AxGEARLib.AxGear axgear1;
        //private AxGEARLib.AxGear axgear2;
        //private AxGEARLib.AxGear axgear3;


}
}