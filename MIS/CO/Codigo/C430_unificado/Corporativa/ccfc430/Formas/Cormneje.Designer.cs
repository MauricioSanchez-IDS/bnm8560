using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORMNEJE
	{
	
#region "Upgrade Support "
		private static CORMNEJE m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORMNEJE DefInstance
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
		public CORMNEJE():base(){
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
			InitializefraDatosAdicionales();
			InitializeoptNacionalidad();
			InitializeID_MEM_TEX_PNL();
			InitializeID_MEM_CIU_EB();
			InitializechkPinPlastico();
			InitializeID_MEM_COL_EB();
			InitializeID_MEM_EDO_EB();
			InitializeID_MEM_CP_PIC();
			InitializeID_MEE_DEJ_FRM();
			InitializeID_MEM_ETT_TXT();
			InitializeoptEjecutivos();
			InitializeID_MEM_MES_FIS_LBL();
			InitializeID_MEE_ETT_TXT();
			InitializefraDomicilio();
			InitializeID_MEM_TFA_3OPB();
			InitializeID_MEM_DOM_EB();
			InitializeID_MEM_PDM_EB();
			ID_MEE_TAR_FPTPreviousTab = ID_MEE_TAR_FPT.SelectedIndex;
		}
	public static CORMNEJE CreateInstance()
	{
			CORMNEJE theInstance = new CORMNEJE();
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
	public  System.Windows.Forms.ComboBox ID_MEE_CCO_EB;
    public System.Windows.Forms.RadioButton ID_MEE_MAS_OPB;
	public  System.Windows.Forms.RadioButton ID_MEE_FEM_OPB;
	private  System.Windows.Forms.Panel _ID_MEM_TEX_PNL_0;
	public  System.Windows.Forms.TextBox txtFechaAlta;
	public  System.Windows.Forms.TextBox ID_MEJ_CTA_EB;
	public  System.Windows.Forms.TextBox txtCContable;
	public  System.Windows.Forms.TextBox ID_MEE_NEJ_EB;
	public  System.Windows.Forms.TextBox ID_MEE_NCE_EB;
	public  System.Windows.Forms.TextBox txtMail;
	public  AxMSMask.AxMaskEdBox ID_MEE_NOM_PIC;
	public  AxMSMask.AxMaskEdBox ID_MEE_SDO_EB;
	public  AxMSMask.AxMaskEdBox ID_MEE_RFC_EB;
	public  AxMSMask.AxMaskEdBox ID_MEE_LIM_FTB;
	public  AxMSMask.AxMaskEdBox txtDisEfectivo;
	public  AxMSMask.AxMaskEdBox ID_MEE_COR_PIC;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_2;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_27;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_4;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_8;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_1;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_0;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_2;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_3;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_4;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_5;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_6;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_11;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_31;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_3;
	private  System.Windows.Forms.GroupBox _ID_MEE_DEJ_FRM_0;
	public  System.Windows.Forms.TextBox ID_MEE_NEM_EB;
	public  System.Windows.Forms.Label ID_MEE_CTA_TXT;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_1;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_0;
	public  System.Windows.Forms.GroupBox ID_MEE_CON_FRM;
	private  System.Windows.Forms.TabPage _ID_MEE_TAR_FPT_TabPage0;
	public  AxMSMask.AxMaskEdBox ID_MEE_CP_PIC;
	private  System.Windows.Forms.ComboBox _ID_MEM_EDO_EB_1;
	public  System.Windows.Forms.TextBox ID_MEE_CNU_EB;
	public  System.Windows.Forms.TextBox ID_MEE_COL_EB;
	public  System.Windows.Forms.TextBox ID_MEE_POB_EB;
	public  AxMSMask.AxMaskEdBox ID_MEE_TOF_PIC;
	public  AxMSMask.AxMaskEdBox ID_MEE_FAX_PIC;
	public  AxMSMask.AxMaskEdBox ID_MEE_EXT_PIC;
	public  AxMSMask.AxMaskEdBox ID_MEE_ZPO_PIC;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_6;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_17;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_16;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_20;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_19;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_12;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_13;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_14;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_18;
	private  System.Windows.Forms.GroupBox _fraDomicilio_0;
	private  System.Windows.Forms.ComboBox _ID_MEM_EDO_EB_0;
	private  System.Windows.Forms.TextBox _ID_MEM_DOM_EB_0;
	private  System.Windows.Forms.TextBox _ID_MEM_COL_EB_0;
	private  System.Windows.Forms.TextBox _ID_MEM_PDM_EB_0;
	private  System.Windows.Forms.TextBox _ID_MEM_CIU_EB_0;
	private  AxMSMask.AxMaskEdBox _ID_MEM_CP_PIC_0;
	public  AxMSMask.AxMaskEdBox ID_MEE_TDO_PIC;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_15;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_15;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_12;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_13;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_14;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_10;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_9;
	private  System.Windows.Forms.GroupBox _fraDomicilio_1;
	private  System.Windows.Forms.TabPage _ID_MEE_TAR_FPT_TabPage1;
	public  System.Windows.Forms.TextBox txtAtencionA;
	public  System.Windows.Forms.ComboBox ID_MEM_PERSONA;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_9;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_7;
	private  System.Windows.Forms.GroupBox _fraDatosAdicionales_3;
	public  System.Windows.Forms.CheckBox chkSkipPayment;
	public  System.Windows.Forms.CheckBox chkCuentaControl;
	private  System.Windows.Forms.GroupBox _fraDatosAdicionales_2;
	private  System.Windows.Forms.RadioButton _ID_MEM_TFA_3OPB_0;
        private System.Windows.Forms.RadioButton _ID_MEM_TFA_3OPB_1;
	private  System.Windows.Forms.GroupBox _fraDatosAdicionales_1;
	private  System.Windows.Forms.CheckBox _chkPinPlastico_1;
	private  System.Windows.Forms.CheckBox _chkPinPlastico_0;
	private  System.Windows.Forms.GroupBox _fraDatosAdicionales_0;
	private  System.Windows.Forms.RadioButton _optEjecutivos_0;
        private System.Windows.Forms.RadioButton _optEjecutivos_1;
        private System.Windows.Forms.RadioButton _optEjecutivos_2;
	public  System.Windows.Forms.GroupBox fraEjecutivos;
	public  AxMSMask.AxMaskEdBox mskMCC;
        private System.Windows.Forms.RadioButton _optNacionalidad_1;
	private  System.Windows.Forms.RadioButton _optNacionalidad_0;
	private  System.Windows.Forms.Panel _ID_MEM_TEX_PNL_1;
	private  System.Windows.Forms.Label _ID_MEM_ETT_TXT_5;
	private  System.Windows.Forms.Label _ID_MEM_MES_FIS_LBL_1;
	private  System.Windows.Forms.TabPage _ID_MEE_TAR_FPT_TabPage2;
	public  System.Windows.Forms.TabControl ID_MEE_TAR_FPT;
	public  System.Windows.Forms.Button ID_MEE_IMP_PB;
	public  System.Windows.Forms.Button ID_MEE_ALT_PB;
	public  System.Windows.Forms.Button ID_MEE_CER_PB;
	public System.Windows.Forms.GroupBox[] ID_MEE_DEJ_FRM = new System.Windows.Forms.GroupBox[1];
	public System.Windows.Forms.Label[] ID_MEE_ETT_TXT = new System.Windows.Forms.Label[32];
	public System.Windows.Forms.TextBox[] ID_MEM_CIU_EB = new System.Windows.Forms.TextBox[1];
	public System.Windows.Forms.TextBox[] ID_MEM_COL_EB = new System.Windows.Forms.TextBox[1];
	public AxMSMask.AxMaskEdBox[] ID_MEM_CP_PIC = new AxMSMask.AxMaskEdBox[1];
	public System.Windows.Forms.TextBox[] ID_MEM_DOM_EB = new System.Windows.Forms.TextBox[1];
	public System.Windows.Forms.ComboBox[] ID_MEM_EDO_EB = new System.Windows.Forms.ComboBox[2];
	public System.Windows.Forms.Label[] ID_MEM_ETT_TXT = new System.Windows.Forms.Label[16];
	public System.Windows.Forms.Label[] ID_MEM_MES_FIS_LBL = new System.Windows.Forms.Label[2];
	public System.Windows.Forms.TextBox[] ID_MEM_PDM_EB = new System.Windows.Forms.TextBox[1];
	public System.Windows.Forms.Panel[] ID_MEM_TEX_PNL = new System.Windows.Forms.Panel[2];
        public System.Windows.Forms.RadioButton[] ID_MEM_TFA_3OPB = new System.Windows.Forms.RadioButton[2];
	public System.Windows.Forms.CheckBox[] chkPinPlastico = new System.Windows.Forms.CheckBox[2];
	public System.Windows.Forms.GroupBox[] fraDatosAdicionales = new System.Windows.Forms.GroupBox[4];
	public System.Windows.Forms.GroupBox[] fraDomicilio = new System.Windows.Forms.GroupBox[2];
        public System.Windows.Forms.RadioButton[] optEjecutivos = new System.Windows.Forms.RadioButton[3];
	public System.Windows.Forms.RadioButton[] optNacionalidad = new System.Windows.Forms.RadioButton[2];
	private Artinsoft.VB6.Gui.ListControlHelper ListBoxComboBoxHelper1;
	private int ID_MEE_TAR_FPTPreviousTab;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORMNEJE));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_MEE_TAR_FPT = new System.Windows.Forms.TabControl();
            this._ID_MEE_TAR_FPT_TabPage0 = new System.Windows.Forms.TabPage();
            this._ID_MEE_DEJ_FRM_0 = new System.Windows.Forms.GroupBox();
            this._ID_MEM_ETT_TXT_4 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_27 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_1 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_8 = new System.Windows.Forms.Label();
            this.txtDisEfectivo = new AxMSMask.AxMaskEdBox();
            this.ID_MEE_LIM_FTB = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_ETT_TXT_2 = new System.Windows.Forms.Label();
            this.ID_MEE_COR_PIC = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_ETT_TXT_0 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_11 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_6 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_3 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_31 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_3 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_2 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_5 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_4 = new System.Windows.Forms.Label();
            this.ID_MEE_RFC_EB = new AxMSMask.AxMaskEdBox();
            this.ID_MEJ_CTA_EB = new System.Windows.Forms.TextBox();
            this.txtCContable = new System.Windows.Forms.TextBox();
            this.txtFechaAlta = new System.Windows.Forms.TextBox();
            this.ID_MEE_CCO_EB = new System.Windows.Forms.ComboBox();
            this._ID_MEM_TEX_PNL_0 = new System.Windows.Forms.Panel();
            this.ID_MEE_FEM_OPB = new System.Windows.Forms.RadioButton();
            this.ID_MEE_MAS_OPB = new System.Windows.Forms.RadioButton();
            this.ID_MEE_NOM_PIC = new AxMSMask.AxMaskEdBox();
            this.ID_MEE_SDO_EB = new AxMSMask.AxMaskEdBox();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.ID_MEE_NEJ_EB = new System.Windows.Forms.TextBox();
            this.ID_MEE_NCE_EB = new System.Windows.Forms.TextBox();
            this.ID_MEE_CON_FRM = new System.Windows.Forms.GroupBox();
            this.ID_MEE_CTA_TXT = new System.Windows.Forms.Label();
            this.ID_MEE_NEM_EB = new System.Windows.Forms.TextBox();
            this._ID_MEE_ETT_TXT_0 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_1 = new System.Windows.Forms.Label();
            this._ID_MEE_TAR_FPT_TabPage1 = new System.Windows.Forms.TabPage();
            this._fraDomicilio_0 = new System.Windows.Forms.GroupBox();
            this.ID_MEE_ZPO_PIC = new AxMSMask.AxMaskEdBox();
            this._ID_MEE_ETT_TXT_17 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_6 = new System.Windows.Forms.Label();
            this.ID_MEE_TOF_PIC = new AxMSMask.AxMaskEdBox();
            this.ID_MEE_POB_EB = new System.Windows.Forms.TextBox();
            this.ID_MEE_EXT_PIC = new AxMSMask.AxMaskEdBox();
            this.ID_MEE_FAX_PIC = new AxMSMask.AxMaskEdBox();
            this._ID_MEE_ETT_TXT_13 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_14 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_18 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_12 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_16 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_20 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_19 = new System.Windows.Forms.Label();
            this.ID_MEE_COL_EB = new System.Windows.Forms.TextBox();
            this.ID_MEE_CP_PIC = new AxMSMask.AxMaskEdBox();
            this._ID_MEM_EDO_EB_1 = new System.Windows.Forms.ComboBox();
            this.ID_MEE_CNU_EB = new System.Windows.Forms.TextBox();
            this._fraDomicilio_1 = new System.Windows.Forms.GroupBox();
            this.ID_MEE_TDO_PIC = new AxMSMask.AxMaskEdBox();
            this._ID_MEE_ETT_TXT_15 = new System.Windows.Forms.Label();
            this._ID_MEM_COL_EB_0 = new System.Windows.Forms.TextBox();
            this._ID_MEM_PDM_EB_0 = new System.Windows.Forms.TextBox();
            this._ID_MEM_CIU_EB_0 = new System.Windows.Forms.TextBox();
            this._ID_MEM_ETT_TXT_14 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_10 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_9 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_15 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_12 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_13 = new System.Windows.Forms.Label();
            this._ID_MEM_DOM_EB_0 = new System.Windows.Forms.TextBox();
            this._ID_MEM_EDO_EB_0 = new System.Windows.Forms.ComboBox();
            this._ID_MEM_CP_PIC_0 = new AxMSMask.AxMaskEdBox();
            this._ID_MEE_TAR_FPT_TabPage2 = new System.Windows.Forms.TabPage();
            this.mskMCC = new AxMSMask.AxMaskEdBox();
            this.fraEjecutivos = new System.Windows.Forms.GroupBox();
            this._optEjecutivos_0 = new System.Windows.Forms.RadioButton();
            this._optEjecutivos_1 = new System.Windows.Forms.RadioButton();
            this._optEjecutivos_2 = new System.Windows.Forms.RadioButton();
            this._ID_MEM_TEX_PNL_1 = new System.Windows.Forms.Panel();
            this._optNacionalidad_0 = new System.Windows.Forms.RadioButton();
            this._optNacionalidad_1 = new System.Windows.Forms.RadioButton();
            this._ID_MEM_MES_FIS_LBL_1 = new System.Windows.Forms.Label();
            this._ID_MEM_ETT_TXT_5 = new System.Windows.Forms.Label();
            this._fraDatosAdicionales_0 = new System.Windows.Forms.GroupBox();
            this._chkPinPlastico_1 = new System.Windows.Forms.CheckBox();
            this._chkPinPlastico_0 = new System.Windows.Forms.CheckBox();
            this._fraDatosAdicionales_3 = new System.Windows.Forms.GroupBox();
            this.ID_MEM_PERSONA = new System.Windows.Forms.ComboBox();
            this.txtAtencionA = new System.Windows.Forms.TextBox();
            this._ID_MEE_ETT_TXT_7 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_9 = new System.Windows.Forms.Label();
            this._fraDatosAdicionales_2 = new System.Windows.Forms.GroupBox();
            this.chkSkipPayment = new System.Windows.Forms.CheckBox();
            this.chkCuentaControl = new System.Windows.Forms.CheckBox();
            this._fraDatosAdicionales_1 = new System.Windows.Forms.GroupBox();
            this._ID_MEM_TFA_3OPB_0 = new System.Windows.Forms.RadioButton();
            this._ID_MEM_TFA_3OPB_1 = new System.Windows.Forms.RadioButton();
            this.ID_MEE_IMP_PB = new System.Windows.Forms.Button();
            this.ID_MEE_ALT_PB = new System.Windows.Forms.Button();
            this.ID_MEE_CER_PB = new System.Windows.Forms.Button();
            this.ListBoxComboBoxHelper1 = new Artinsoft.VB6.Gui.ListControlHelper(this.components);
            this.ID_MEE_TAR_FPT.SuspendLayout();
            this._ID_MEE_TAR_FPT_TabPage0.SuspendLayout();
            this._ID_MEE_DEJ_FRM_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisEfectivo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_LIM_FTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_COR_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_RFC_EB)).BeginInit();
            this._ID_MEM_TEX_PNL_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_NOM_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_SDO_EB)).BeginInit();
            this.ID_MEE_CON_FRM.SuspendLayout();
            this._ID_MEE_TAR_FPT_TabPage1.SuspendLayout();
            this._fraDomicilio_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_ZPO_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_TOF_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_EXT_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_FAX_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_CP_PIC)).BeginInit();
            this._fraDomicilio_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_TDO_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_CP_PIC_0)).BeginInit();
            this._ID_MEE_TAR_FPT_TabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mskMCC)).BeginInit();
            this.fraEjecutivos.SuspendLayout();
            this._ID_MEM_TEX_PNL_1.SuspendLayout();
            this._fraDatosAdicionales_0.SuspendLayout();
            this._fraDatosAdicionales_3.SuspendLayout();
            this._fraDatosAdicionales_2.SuspendLayout();
            this._fraDatosAdicionales_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_MEE_TAR_FPT
            // 
            this.ID_MEE_TAR_FPT.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.ID_MEE_TAR_FPT.Controls.Add(this._ID_MEE_TAR_FPT_TabPage0);
            this.ID_MEE_TAR_FPT.Controls.Add(this._ID_MEE_TAR_FPT_TabPage1);
            this.ID_MEE_TAR_FPT.Controls.Add(this._ID_MEE_TAR_FPT_TabPage2);
            this.ID_MEE_TAR_FPT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_TAR_FPT.ItemSize = new System.Drawing.Size(191, 18);
            this.ID_MEE_TAR_FPT.Location = new System.Drawing.Point(8, 8);
            this.ID_MEE_TAR_FPT.Multiline = true;
            this.ID_MEE_TAR_FPT.Name = "ID_MEE_TAR_FPT";
            this.ID_MEE_TAR_FPT.SelectedIndex = 0;
            this.ID_MEE_TAR_FPT.Size = new System.Drawing.Size(581, 424);
            this.ID_MEE_TAR_FPT.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.ID_MEE_TAR_FPT.TabIndex = 0;
            this.ID_MEE_TAR_FPT.Tag = "";
            this.ID_MEE_TAR_FPT.SelectedIndexChanged += new System.EventHandler(this.ID_MEE_TAR_FPT_SelectedIndexChanged);
            // 
            // _ID_MEE_TAR_FPT_TabPage0
            // 
            this._ID_MEE_TAR_FPT_TabPage0.Controls.Add(this._ID_MEE_DEJ_FRM_0);
            this._ID_MEE_TAR_FPT_TabPage0.Controls.Add(this.ID_MEE_CON_FRM);
            this._ID_MEE_TAR_FPT_TabPage0.Location = new System.Drawing.Point(4, 22);
            this._ID_MEE_TAR_FPT_TabPage0.Name = "_ID_MEE_TAR_FPT_TabPage0";
            this._ID_MEE_TAR_FPT_TabPage0.Size = new System.Drawing.Size(573, 398);
            this._ID_MEE_TAR_FPT_TabPage0.TabIndex = 0;
            this._ID_MEE_TAR_FPT_TabPage0.Tag = "";
            this._ID_MEE_TAR_FPT_TabPage0.Text = "Datos &Generales";
            this._ID_MEE_TAR_FPT_TabPage0.UseVisualStyleBackColor = true;
            // 
            // _ID_MEE_DEJ_FRM_0
            // 
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEM_ETT_TXT_4);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEE_ETT_TXT_27);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEM_ETT_TXT_1);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEE_ETT_TXT_8);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this.txtDisEfectivo);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this.ID_MEE_LIM_FTB);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEM_ETT_TXT_2);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this.ID_MEE_COR_PIC);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEM_ETT_TXT_0);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEE_ETT_TXT_11);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEE_ETT_TXT_6);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEM_ETT_TXT_3);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEE_ETT_TXT_31);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEE_ETT_TXT_3);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEE_ETT_TXT_2);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEE_ETT_TXT_5);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEE_ETT_TXT_4);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this.ID_MEE_RFC_EB);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this.ID_MEJ_CTA_EB);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this.txtCContable);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this.txtFechaAlta);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this.ID_MEE_CCO_EB);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this._ID_MEM_TEX_PNL_0);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this.ID_MEE_NOM_PIC);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this.ID_MEE_SDO_EB);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this.txtMail);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this.ID_MEE_NEJ_EB);
            this._ID_MEE_DEJ_FRM_0.Controls.Add(this.ID_MEE_NCE_EB);
            this._ID_MEE_DEJ_FRM_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_DEJ_FRM_0.Location = new System.Drawing.Point(13, 58);
            this._ID_MEE_DEJ_FRM_0.Name = "_ID_MEE_DEJ_FRM_0";
            this._ID_MEE_DEJ_FRM_0.Size = new System.Drawing.Size(550, 311);
            this._ID_MEE_DEJ_FRM_0.TabIndex = 6;
            this._ID_MEE_DEJ_FRM_0.TabStop = false;
            this._ID_MEE_DEJ_FRM_0.Tag = "";
            this._ID_MEE_DEJ_FRM_0.Text = "Datos del &Ejecutivo";
            // 
            // _ID_MEM_ETT_TXT_4
            // 
            this._ID_MEM_ETT_TXT_4.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_4.Location = new System.Drawing.Point(363, 150);
            this._ID_MEM_ETT_TXT_4.Name = "_ID_MEM_ETT_TXT_4";
            this._ID_MEM_ETT_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_4.Size = new System.Drawing.Size(66, 17);
            this._ID_MEM_ETT_TXT_4.TabIndex = 21;
            this._ID_MEM_ETT_TXT_4.Tag = "";
            this._ID_MEM_ETT_TXT_4.Text = "&Apertura";
            this._ID_MEM_ETT_TXT_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this._ID_MEM_ETT_TXT_4.Visible = false;
            // 
            // _ID_MEE_ETT_TXT_27
            // 
            this._ID_MEE_ETT_TXT_27.AutoSize = true;
            this._ID_MEE_ETT_TXT_27.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_27.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_27.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_27.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_27.Location = new System.Drawing.Point(373, 278);
            this._ID_MEE_ETT_TXT_27.Name = "_ID_MEE_ETT_TXT_27";
            this._ID_MEE_ETT_TXT_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_27.Size = new System.Drawing.Size(80, 13);
            this._ID_MEE_ETT_TXT_27.TabIndex = 35;
            this._ID_MEE_ETT_TXT_27.Tag = "";
            this._ID_MEE_ETT_TXT_27.Text = "&Día de Corte";
            this._ID_MEE_ETT_TXT_27.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_MEM_ETT_TXT_1
            // 
            this._ID_MEM_ETT_TXT_1.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_1.Location = new System.Drawing.Point(12, 214);
            this._ID_MEM_ETT_TXT_1.Name = "_ID_MEM_ETT_TXT_1";
            this._ID_MEM_ETT_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_1.Size = new System.Drawing.Size(111, 17);
            this._ID_MEM_ETT_TXT_1.TabIndex = 27;
            this._ID_MEM_ETT_TXT_1.Tag = "";
            this._ID_MEM_ETT_TXT_1.Text = "Cuenta Contable";
            // 
            // _ID_MEE_ETT_TXT_8
            // 
            this._ID_MEE_ETT_TXT_8.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_8.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_8.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_8.Location = new System.Drawing.Point(12, 151);
            this._ID_MEE_ETT_TXT_8.Name = "_ID_MEE_ETT_TXT_8";
            this._ID_MEE_ETT_TXT_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_8.Size = new System.Drawing.Size(43, 15);
            this._ID_MEE_ETT_TXT_8.TabIndex = 19;
            this._ID_MEE_ETT_TXT_8.Tag = "";
            this._ID_MEE_ETT_TXT_8.Text = "Cuenta";
            // 
            // txtDisEfectivo
            // 
            this.txtDisEfectivo.Location = new System.Drawing.Point(438, 179);
            this.txtDisEfectivo.Name = "txtDisEfectivo";
            this.txtDisEfectivo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("txtDisEfectivo.OcxState")));
            this.txtDisEfectivo.Size = new System.Drawing.Size(98, 22);
            this.txtDisEfectivo.TabIndex = 26;
            this.txtDisEfectivo.Tag = "";
            this.txtDisEfectivo.Change += new System.EventHandler(this.txtDisEfectivo_Change);
            this.txtDisEfectivo.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.txtDisEfectivo_KeyPressEvent);
            this.txtDisEfectivo.Enter += new System.EventHandler(this.txtDisEfectivo_Enter);
            this.txtDisEfectivo.Validating += new System.ComponentModel.CancelEventHandler(this.txtDisEfectivo_Validating);
            // 
            // ID_MEE_LIM_FTB
            // 
            this.ID_MEE_LIM_FTB.Location = new System.Drawing.Point(129, 179);
            this.ID_MEE_LIM_FTB.Name = "ID_MEE_LIM_FTB";
            this.ID_MEE_LIM_FTB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_LIM_FTB.OcxState")));
            this.ID_MEE_LIM_FTB.Size = new System.Drawing.Size(141, 22);
            this.ID_MEE_LIM_FTB.TabIndex = 24;
            this.ID_MEE_LIM_FTB.Tag = "";
            this.ID_MEE_LIM_FTB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_LIM_FTB_KeyPressEvent);
            this.ID_MEE_LIM_FTB.Enter += new System.EventHandler(this.ID_MEE_LIM_FTB_Enter);
            this.ID_MEE_LIM_FTB.Validating += new System.ComponentModel.CancelEventHandler(this.ID_MEE_LIM_FTB_Validating);
            // 
            // _ID_MEM_ETT_TXT_2
            // 
            this._ID_MEM_ETT_TXT_2.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_2.Location = new System.Drawing.Point(12, 276);
            this._ID_MEM_ETT_TXT_2.Name = "_ID_MEM_ETT_TXT_2";
            this._ID_MEM_ETT_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_2.Size = new System.Drawing.Size(73, 17);
            this._ID_MEM_ETT_TXT_2.TabIndex = 31;
            this._ID_MEM_ETT_TXT_2.Tag = "";
            this._ID_MEM_ETT_TXT_2.Text = "Sexo";
            // 
            // ID_MEE_COR_PIC
            // 
            this.ID_MEE_COR_PIC.Location = new System.Drawing.Point(480, 273);
            this.ID_MEE_COR_PIC.Name = "ID_MEE_COR_PIC";
            this.ID_MEE_COR_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_COR_PIC.OcxState")));
            this.ID_MEE_COR_PIC.Size = new System.Drawing.Size(56, 22);
            this.ID_MEE_COR_PIC.TabIndex = 36;
            this.ID_MEE_COR_PIC.Tag = "";
            // 
            // _ID_MEM_ETT_TXT_0
            // 
            this._ID_MEM_ETT_TXT_0.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_0.Location = new System.Drawing.Point(12, 244);
            this._ID_MEM_ETT_TXT_0.Name = "_ID_MEM_ETT_TXT_0";
            this._ID_MEM_ETT_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_0.Size = new System.Drawing.Size(111, 17);
            this._ID_MEM_ETT_TXT_0.TabIndex = 29;
            this._ID_MEM_ETT_TXT_0.Tag = "";
            this._ID_MEM_ETT_TXT_0.Text = "Correo Electrónico";
            // 
            // _ID_MEE_ETT_TXT_11
            // 
            this._ID_MEE_ETT_TXT_11.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_11.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_11.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_11.Location = new System.Drawing.Point(12, 57);
            this._ID_MEE_ETT_TXT_11.Name = "_ID_MEE_ETT_TXT_11";
            this._ID_MEE_ETT_TXT_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_11.Size = new System.Drawing.Size(119, 19);
            this._ID_MEE_ETT_TXT_11.TabIndex = 9;
            this._ID_MEE_ETT_TXT_11.Tag = "";
            this._ID_MEE_ETT_TXT_11.Text = "Nombre (Grabación)";
            // 
            // _ID_MEE_ETT_TXT_6
            // 
            this._ID_MEE_ETT_TXT_6.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_6.Location = new System.Drawing.Point(12, 119);
            this._ID_MEE_ETT_TXT_6.Name = "_ID_MEE_ETT_TXT_6";
            this._ID_MEE_ETT_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_6.Size = new System.Drawing.Size(101, 19);
            this._ID_MEE_ETT_TXT_6.TabIndex = 15;
            this._ID_MEE_ETT_TXT_6.Tag = "";
            this._ID_MEE_ETT_TXT_6.Text = "&Centro de Costos";
            // 
            // _ID_MEM_ETT_TXT_3
            // 
            this._ID_MEM_ETT_TXT_3.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_3.Location = new System.Drawing.Point(291, 182);
            this._ID_MEM_ETT_TXT_3.Name = "_ID_MEM_ETT_TXT_3";
            this._ID_MEM_ETT_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_3.Size = new System.Drawing.Size(138, 17);
            this._ID_MEM_ETT_TXT_3.TabIndex = 25;
            this._ID_MEM_ETT_TXT_3.Tag = "";
            this._ID_MEM_ETT_TXT_3.Text = "Límite disposiciones (%)";
            this._ID_MEM_ETT_TXT_3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_MEE_ETT_TXT_31
            // 
            this._ID_MEE_ETT_TXT_31.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_31.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_31.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_31.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_31.Location = new System.Drawing.Point(12, 182);
            this._ID_MEE_ETT_TXT_31.Name = "_ID_MEE_ETT_TXT_31";
            this._ID_MEE_ETT_TXT_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_31.Size = new System.Drawing.Size(106, 17);
            this._ID_MEE_ETT_TXT_31.TabIndex = 23;
            this._ID_MEE_ETT_TXT_31.Tag = "";
            this._ID_MEE_ETT_TXT_31.Text = "&Límite Crédito";
            // 
            // _ID_MEE_ETT_TXT_3
            // 
            this._ID_MEE_ETT_TXT_3.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_3.Location = new System.Drawing.Point(12, 89);
            this._ID_MEE_ETT_TXT_3.Name = "_ID_MEE_ETT_TXT_3";
            this._ID_MEE_ETT_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_3.Size = new System.Drawing.Size(45, 17);
            this._ID_MEE_ETT_TXT_3.TabIndex = 11;
            this._ID_MEE_ETT_TXT_3.Tag = "";
            this._ID_MEE_ETT_TXT_3.Text = "&RFC";
            // 
            // _ID_MEE_ETT_TXT_2
            // 
            this._ID_MEE_ETT_TXT_2.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_2.Location = new System.Drawing.Point(12, 27);
            this._ID_MEE_ETT_TXT_2.Name = "_ID_MEE_ETT_TXT_2";
            this._ID_MEE_ETT_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_2.Size = new System.Drawing.Size(83, 17);
            this._ID_MEE_ETT_TXT_2.TabIndex = 7;
            this._ID_MEE_ETT_TXT_2.Tag = "";
            this._ID_MEE_ETT_TXT_2.Text = "No&mbre";
            // 
            // _ID_MEE_ETT_TXT_5
            // 
            this._ID_MEE_ETT_TXT_5.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_5.Location = new System.Drawing.Point(328, 89);
            this._ID_MEE_ETT_TXT_5.Name = "_ID_MEE_ETT_TXT_5";
            this._ID_MEE_ETT_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_5.Size = new System.Drawing.Size(101, 17);
            this._ID_MEE_ETT_TXT_5.TabIndex = 13;
            this._ID_MEE_ETT_TXT_5.Tag = "";
            this._ID_MEE_ETT_TXT_5.Text = "No.  de Nóm&ina";
            this._ID_MEE_ETT_TXT_5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // _ID_MEE_ETT_TXT_4
            // 
            this._ID_MEE_ETT_TXT_4.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_4.Location = new System.Drawing.Point(346, 121);
            this._ID_MEE_ETT_TXT_4.Name = "_ID_MEE_ETT_TXT_4";
            this._ID_MEE_ETT_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_4.Size = new System.Drawing.Size(83, 15);
            this._ID_MEE_ETT_TXT_4.TabIndex = 17;
            this._ID_MEE_ETT_TXT_4.Tag = "";
            this._ID_MEE_ETT_TXT_4.Text = "&Sueldo";
            this._ID_MEE_ETT_TXT_4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ID_MEE_RFC_EB
            // 
            this.ID_MEE_RFC_EB.Location = new System.Drawing.Point(129, 87);
            this.ID_MEE_RFC_EB.Name = "ID_MEE_RFC_EB";
            this.ID_MEE_RFC_EB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_RFC_EB.OcxState")));
            this.ID_MEE_RFC_EB.Size = new System.Drawing.Size(141, 21);
            this.ID_MEE_RFC_EB.TabIndex = 12;
            this.ID_MEE_RFC_EB.Tag = "";
            this.ID_MEE_RFC_EB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_RFC_EB_KeyPressEvent);
            this.ID_MEE_RFC_EB.Enter += new System.EventHandler(this.ID_MEE_RFC_EB_Enter);
            this.ID_MEE_RFC_EB.Validating += new System.ComponentModel.CancelEventHandler(this.ID_MEE_RFC_EB_Validating);
            // 
            // ID_MEJ_CTA_EB
            // 
            this.ID_MEJ_CTA_EB.AcceptsReturn = true;
            this.ID_MEJ_CTA_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEJ_CTA_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEJ_CTA_EB.Enabled = false;
            this.ID_MEJ_CTA_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEJ_CTA_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEJ_CTA_EB.Location = new System.Drawing.Point(129, 149);
            this.ID_MEJ_CTA_EB.MaxLength = 19;
            this.ID_MEJ_CTA_EB.Name = "ID_MEJ_CTA_EB";
            this.ID_MEJ_CTA_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEJ_CTA_EB.Size = new System.Drawing.Size(141, 20);
            this.ID_MEJ_CTA_EB.TabIndex = 20;
            this.ID_MEJ_CTA_EB.Tag = "";
            this.ID_MEJ_CTA_EB.Enter += new System.EventHandler(this.ID_MEJ_CTA_EB_Enter);
            this.ID_MEJ_CTA_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEJ_CTA_EB_KeyPress);
            // 
            // txtCContable
            // 
            this.txtCContable.AcceptsReturn = true;
            this.txtCContable.BackColor = System.Drawing.Color.White;
            this.txtCContable.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtCContable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCContable.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtCContable.Location = new System.Drawing.Point(129, 212);
            this.txtCContable.MaxLength = 40;
            this.txtCContable.Name = "txtCContable";
            this.txtCContable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtCContable.Size = new System.Drawing.Size(407, 20);
            this.txtCContable.TabIndex = 28;
            this.txtCContable.Tag = "";
            this.txtCContable.TextChanged += new System.EventHandler(this.txtCContable_TextChanged);
            this.txtCContable.Enter += new System.EventHandler(this.txtCContable_Enter);
            this.txtCContable.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCContable_KeyPress);
            // 
            // txtFechaAlta
            // 
            this.txtFechaAlta.AcceptsReturn = true;
            this.txtFechaAlta.BackColor = System.Drawing.Color.White;
            this.txtFechaAlta.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtFechaAlta.Enabled = false;
            this.txtFechaAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaAlta.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtFechaAlta.Location = new System.Drawing.Point(438, 148);
            this.txtFechaAlta.MaxLength = 26;
            this.txtFechaAlta.Name = "txtFechaAlta";
            this.txtFechaAlta.ReadOnly = true;
            this.txtFechaAlta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtFechaAlta.Size = new System.Drawing.Size(98, 20);
            this.txtFechaAlta.TabIndex = 22;
            this.txtFechaAlta.Tag = "";
            this.txtFechaAlta.Visible = false;
            // 
            // ID_MEE_CCO_EB
            // 
            this.ID_MEE_CCO_EB.BackColor = System.Drawing.SystemColors.Window;
            this.ID_MEE_CCO_EB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEE_CCO_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_CCO_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this.ID_MEE_CCO_EB, new int[0]);
            this.ID_MEE_CCO_EB.Location = new System.Drawing.Point(129, 117);
            this.ID_MEE_CCO_EB.Name = "ID_MEE_CCO_EB";
            this.ID_MEE_CCO_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_CCO_EB.Size = new System.Drawing.Size(141, 21);
            this.ID_MEE_CCO_EB.TabIndex = 16;
            this.ID_MEE_CCO_EB.Tag = "";
            this.ID_MEE_CCO_EB.Text = "ID_MEE_CCO_EB";
            this.ID_MEE_CCO_EB.SelectionChangeCommitted += new System.EventHandler(this.ID_MEE_CCO_EB_SelectionChangeCommitted);
            // 
            // _ID_MEM_TEX_PNL_0
            // 
            this._ID_MEM_TEX_PNL_0.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_TEX_PNL_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ID_MEM_TEX_PNL_0.Controls.Add(this.ID_MEE_FEM_OPB);
            this._ID_MEM_TEX_PNL_0.Controls.Add(this.ID_MEE_MAS_OPB);
            this._ID_MEM_TEX_PNL_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_TEX_PNL_0.Location = new System.Drawing.Point(129, 270);
            this._ID_MEM_TEX_PNL_0.Name = "_ID_MEM_TEX_PNL_0";
            this._ID_MEM_TEX_PNL_0.Size = new System.Drawing.Size(223, 35);
            this._ID_MEM_TEX_PNL_0.TabIndex = 32;
            this._ID_MEM_TEX_PNL_0.Tag = "";
            // 
            // ID_MEE_FEM_OPB
            // 
            this.ID_MEE_FEM_OPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_FEM_OPB.Location = new System.Drawing.Point(12, 6);
            this.ID_MEE_FEM_OPB.Name = "ID_MEE_FEM_OPB";
            this.ID_MEE_FEM_OPB.Size = new System.Drawing.Size(96, 20);
            this.ID_MEE_FEM_OPB.TabIndex = 33;
            this.ID_MEE_FEM_OPB.Tag = "";
            this.ID_MEE_FEM_OPB.Text = "Femenino";
            // 
            // ID_MEE_MAS_OPB
            // 
            this.ID_MEE_MAS_OPB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_MAS_OPB.Location = new System.Drawing.Point(114, 6);
            this.ID_MEE_MAS_OPB.Name = "ID_MEE_MAS_OPB";
            this.ID_MEE_MAS_OPB.Size = new System.Drawing.Size(96, 20);
            this.ID_MEE_MAS_OPB.TabIndex = 34;
            this.ID_MEE_MAS_OPB.Tag = "";
            this.ID_MEE_MAS_OPB.Text = "Masculino";
            this.ID_MEE_MAS_OPB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEE_MAS_OPB_KeyPress);
            // 
            // ID_MEE_NOM_PIC
            // 
            this.ID_MEE_NOM_PIC.Location = new System.Drawing.Point(438, 86);
            this.ID_MEE_NOM_PIC.Name = "ID_MEE_NOM_PIC";
            this.ID_MEE_NOM_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_NOM_PIC.OcxState")));
            this.ID_MEE_NOM_PIC.Size = new System.Drawing.Size(98, 22);
            this.ID_MEE_NOM_PIC.TabIndex = 14;
            this.ID_MEE_NOM_PIC.Tag = "";
            this.ID_MEE_NOM_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_NOM_PIC_KeyPressEvent);
            this.ID_MEE_NOM_PIC.Enter += new System.EventHandler(this.ID_MEE_NOM_PIC_Enter);
            // 
            // ID_MEE_SDO_EB
            // 
            this.ID_MEE_SDO_EB.Location = new System.Drawing.Point(438, 117);
            this.ID_MEE_SDO_EB.Name = "ID_MEE_SDO_EB";
            this.ID_MEE_SDO_EB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_SDO_EB.OcxState")));
            this.ID_MEE_SDO_EB.Size = new System.Drawing.Size(98, 22);
            this.ID_MEE_SDO_EB.TabIndex = 18;
            this.ID_MEE_SDO_EB.Tag = "";
            this.ID_MEE_SDO_EB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_SDO_EB_KeyPressEvent);
            this.ID_MEE_SDO_EB.Enter += new System.EventHandler(this.ID_MEE_SDO_EB_Enter);
            this.ID_MEE_SDO_EB.Leave += new System.EventHandler(this.ID_MEE_SDO_EB_Leave);
            // 
            // txtMail
            // 
            this.txtMail.AcceptsReturn = true;
            this.txtMail.BackColor = System.Drawing.Color.White;
            this.txtMail.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtMail.Location = new System.Drawing.Point(129, 243);
            this.txtMail.MaxLength = 70;
            this.txtMail.Name = "txtMail";
            this.txtMail.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtMail.Size = new System.Drawing.Size(407, 20);
            this.txtMail.TabIndex = 30;
            this.txtMail.Tag = "";
            this.txtMail.TextChanged += new System.EventHandler(this.txtMail_TextChanged);
            this.txtMail.Enter += new System.EventHandler(this.txtMail_Enter);
            this.txtMail.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMail_KeyPress);
            this.txtMail.Validating += new System.ComponentModel.CancelEventHandler(this.txtMail_Validating);
            // 
            // ID_MEE_NEJ_EB
            // 
            this.ID_MEE_NEJ_EB.AcceptsReturn = true;
            this.ID_MEE_NEJ_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEE_NEJ_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEE_NEJ_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_NEJ_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEE_NEJ_EB.Location = new System.Drawing.Point(129, 25);
            this.ID_MEE_NEJ_EB.MaxLength = 45;
            this.ID_MEE_NEJ_EB.Name = "ID_MEE_NEJ_EB";
            this.ID_MEE_NEJ_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_NEJ_EB.Size = new System.Drawing.Size(407, 20);
            this.ID_MEE_NEJ_EB.TabIndex = 8;
            this.ID_MEE_NEJ_EB.Tag = "";
            this.ID_MEE_NEJ_EB.Enter += new System.EventHandler(this.ID_MEE_NEJ_EB_Enter);
            this.ID_MEE_NEJ_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEE_NEJ_EB_KeyPress);
            // 
            // ID_MEE_NCE_EB
            // 
            this.ID_MEE_NCE_EB.AcceptsReturn = true;
            this.ID_MEE_NCE_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEE_NCE_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEE_NCE_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_NCE_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEE_NCE_EB.Location = new System.Drawing.Point(129, 56);
            this.ID_MEE_NCE_EB.MaxLength = 26;
            this.ID_MEE_NCE_EB.Name = "ID_MEE_NCE_EB";
            this.ID_MEE_NCE_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_NCE_EB.Size = new System.Drawing.Size(407, 20);
            this.ID_MEE_NCE_EB.TabIndex = 10;
            this.ID_MEE_NCE_EB.Tag = "";
            this.ID_MEE_NCE_EB.Enter += new System.EventHandler(this.ID_MEE_NCE_EB_Enter);
            this.ID_MEE_NCE_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEE_NCE_EB_KeyPress);
            this.ID_MEE_NCE_EB.Leave += new System.EventHandler(this.ID_MEE_NCE_EB_Leave);
            // 
            // ID_MEE_CON_FRM
            // 
            this.ID_MEE_CON_FRM.Controls.Add(this.ID_MEE_CTA_TXT);
            this.ID_MEE_CON_FRM.Controls.Add(this.ID_MEE_NEM_EB);
            this.ID_MEE_CON_FRM.Controls.Add(this._ID_MEE_ETT_TXT_0);
            this.ID_MEE_CON_FRM.Controls.Add(this._ID_MEE_ETT_TXT_1);
            this.ID_MEE_CON_FRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_CON_FRM.Location = new System.Drawing.Point(13, 5);
            this.ID_MEE_CON_FRM.Name = "ID_MEE_CON_FRM";
            this.ID_MEE_CON_FRM.Size = new System.Drawing.Size(550, 47);
            this.ID_MEE_CON_FRM.TabIndex = 1;
            this.ID_MEE_CON_FRM.TabStop = false;
            this.ID_MEE_CON_FRM.Tag = "";
            this.ID_MEE_CON_FRM.Text = "Nombre de la Empresa";
            // 
            // ID_MEE_CTA_TXT
            // 
            this.ID_MEE_CTA_TXT.BackColor = System.Drawing.Color.White;
            this.ID_MEE_CTA_TXT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ID_MEE_CTA_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEE_CTA_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEE_CTA_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_CTA_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEE_CTA_TXT.Location = new System.Drawing.Point(486, 19);
            this.ID_MEE_CTA_TXT.Name = "ID_MEE_CTA_TXT";
            this.ID_MEE_CTA_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_CTA_TXT.Size = new System.Drawing.Size(49, 20);
            this.ID_MEE_CTA_TXT.TabIndex = 5;
            this.ID_MEE_CTA_TXT.Tag = "";
            this.ID_MEE_CTA_TXT.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // ID_MEE_NEM_EB
            // 
            this.ID_MEE_NEM_EB.AcceptsReturn = true;
            this.ID_MEE_NEM_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEE_NEM_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEE_NEM_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_NEM_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEE_NEM_EB.Location = new System.Drawing.Point(69, 19);
            this.ID_MEE_NEM_EB.MaxLength = 45;
            this.ID_MEE_NEM_EB.Name = "ID_MEE_NEM_EB";
            this.ID_MEE_NEM_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_NEM_EB.Size = new System.Drawing.Size(337, 20);
            this.ID_MEE_NEM_EB.TabIndex = 3;
            this.ID_MEE_NEM_EB.Tag = "";
            this.ID_MEE_NEM_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEE_NEM_EB_KeyPress);
            // 
            // _ID_MEE_ETT_TXT_0
            // 
            this._ID_MEE_ETT_TXT_0.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_0.Location = new System.Drawing.Point(432, 21);
            this._ID_MEE_ETT_TXT_0.Name = "_ID_MEE_ETT_TXT_0";
            this._ID_MEE_ETT_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_0.Size = new System.Drawing.Size(46, 17);
            this._ID_MEE_ETT_TXT_0.TabIndex = 4;
            this._ID_MEE_ETT_TXT_0.Tag = "";
            this._ID_MEE_ETT_TXT_0.Text = "&Número";
            // 
            // _ID_MEE_ETT_TXT_1
            // 
            this._ID_MEE_ETT_TXT_1.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_1.Location = new System.Drawing.Point(12, 21);
            this._ID_MEE_ETT_TXT_1.Name = "_ID_MEE_ETT_TXT_1";
            this._ID_MEE_ETT_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_1.Size = new System.Drawing.Size(49, 17);
            this._ID_MEE_ETT_TXT_1.TabIndex = 2;
            this._ID_MEE_ETT_TXT_1.Tag = "";
            this._ID_MEE_ETT_TXT_1.Text = "N&ombre";
            // 
            // _ID_MEE_TAR_FPT_TabPage1
            // 
            this._ID_MEE_TAR_FPT_TabPage1.Controls.Add(this._fraDomicilio_0);
            this._ID_MEE_TAR_FPT_TabPage1.Controls.Add(this._fraDomicilio_1);
            this._ID_MEE_TAR_FPT_TabPage1.Location = new System.Drawing.Point(4, 22);
            this._ID_MEE_TAR_FPT_TabPage1.Name = "_ID_MEE_TAR_FPT_TabPage1";
            this._ID_MEE_TAR_FPT_TabPage1.Size = new System.Drawing.Size(573, 398);
            this._ID_MEE_TAR_FPT_TabPage1.TabIndex = 2;
            this._ID_MEE_TAR_FPT_TabPage1.Tag = "";
            this._ID_MEE_TAR_FPT_TabPage1.Text = "Domicilio";
            this._ID_MEE_TAR_FPT_TabPage1.UseVisualStyleBackColor = true;
            // 
            // _fraDomicilio_0
            // 
            this._fraDomicilio_0.BackColor = System.Drawing.SystemColors.Control;
            this._fraDomicilio_0.Controls.Add(this.ID_MEE_ZPO_PIC);
            this._fraDomicilio_0.Controls.Add(this._ID_MEE_ETT_TXT_17);
            this._fraDomicilio_0.Controls.Add(this._ID_MEM_ETT_TXT_6);
            this._fraDomicilio_0.Controls.Add(this.ID_MEE_TOF_PIC);
            this._fraDomicilio_0.Controls.Add(this.ID_MEE_POB_EB);
            this._fraDomicilio_0.Controls.Add(this.ID_MEE_EXT_PIC);
            this._fraDomicilio_0.Controls.Add(this.ID_MEE_FAX_PIC);
            this._fraDomicilio_0.Controls.Add(this._ID_MEE_ETT_TXT_13);
            this._fraDomicilio_0.Controls.Add(this._ID_MEE_ETT_TXT_14);
            this._fraDomicilio_0.Controls.Add(this._ID_MEE_ETT_TXT_18);
            this._fraDomicilio_0.Controls.Add(this._ID_MEE_ETT_TXT_12);
            this._fraDomicilio_0.Controls.Add(this._ID_MEE_ETT_TXT_16);
            this._fraDomicilio_0.Controls.Add(this._ID_MEE_ETT_TXT_20);
            this._fraDomicilio_0.Controls.Add(this._ID_MEE_ETT_TXT_19);
            this._fraDomicilio_0.Controls.Add(this.ID_MEE_COL_EB);
            this._fraDomicilio_0.Controls.Add(this.ID_MEE_CP_PIC);
            this._fraDomicilio_0.Controls.Add(this._ID_MEM_EDO_EB_1);
            this._fraDomicilio_0.Controls.Add(this.ID_MEE_CNU_EB);
            this._fraDomicilio_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraDomicilio_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._fraDomicilio_0.Location = new System.Drawing.Point(15, 10);
            this._fraDomicilio_0.Name = "_fraDomicilio_0";
            this._fraDomicilio_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._fraDomicilio_0.Size = new System.Drawing.Size(547, 160);
            this._fraDomicilio_0.TabIndex = 37;
            this._fraDomicilio_0.TabStop = false;
            this._fraDomicilio_0.Tag = "";
            this._fraDomicilio_0.Text = "Domicilio de Envio";
            // 
            // ID_MEE_ZPO_PIC
            // 
            this.ID_MEE_ZPO_PIC.Location = new System.Drawing.Point(531, 9);
            this.ID_MEE_ZPO_PIC.Name = "ID_MEE_ZPO_PIC";
            this.ID_MEE_ZPO_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_ZPO_PIC.OcxState")));
            this.ID_MEE_ZPO_PIC.Size = new System.Drawing.Size(60, 21);
            this.ID_MEE_ZPO_PIC.TabIndex = 49;
            this.ID_MEE_ZPO_PIC.Tag = "";
            this.ID_MEE_ZPO_PIC.Visible = false;
            this.ID_MEE_ZPO_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_ZPO_PIC_KeyPressEvent);
            this.ID_MEE_ZPO_PIC.Enter += new System.EventHandler(this.ID_MEE_ZPO_PIC_Enter);
            // 
            // _ID_MEE_ETT_TXT_17
            // 
            this._ID_MEE_ETT_TXT_17.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_17.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_17.Enabled = false;
            this._ID_MEE_ETT_TXT_17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_17.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_17.Location = new System.Drawing.Point(454, 8);
            this._ID_MEE_ETT_TXT_17.Name = "_ID_MEE_ETT_TXT_17";
            this._ID_MEE_ETT_TXT_17.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_17.Size = new System.Drawing.Size(73, 13);
            this._ID_MEE_ETT_TXT_17.TabIndex = 48;
            this._ID_MEE_ETT_TXT_17.Tag = "";
            this._ID_MEE_ETT_TXT_17.Text = "&Zona Postal";
            this._ID_MEE_ETT_TXT_17.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this._ID_MEE_ETT_TXT_17.Visible = false;
            // 
            // _ID_MEM_ETT_TXT_6
            // 
            this._ID_MEM_ETT_TXT_6.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_6.Location = new System.Drawing.Point(12, 104);
            this._ID_MEM_ETT_TXT_6.Name = "_ID_MEM_ETT_TXT_6";
            this._ID_MEM_ETT_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_6.Size = new System.Drawing.Size(55, 17);
            this._ID_MEM_ETT_TXT_6.TabIndex = 44;
            this._ID_MEM_ETT_TXT_6.Tag = "";
            this._ID_MEM_ETT_TXT_6.Text = "&Estado";
            // 
            // ID_MEE_TOF_PIC
            // 
            this.ID_MEE_TOF_PIC.Location = new System.Drawing.Point(131, 129);
            this.ID_MEE_TOF_PIC.Name = "ID_MEE_TOF_PIC";
            this.ID_MEE_TOF_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_TOF_PIC.OcxState")));
            this.ID_MEE_TOF_PIC.Size = new System.Drawing.Size(102, 22);
            this.ID_MEE_TOF_PIC.TabIndex = 51;
            this.ID_MEE_TOF_PIC.Tag = "";
            this.ID_MEE_TOF_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_TOF_PIC_KeyPressEvent);
            this.ID_MEE_TOF_PIC.Enter += new System.EventHandler(this.ID_MEE_TOF_PIC_Enter);
            // 
            // ID_MEE_POB_EB
            // 
            this.ID_MEE_POB_EB.AcceptsReturn = true;
            this.ID_MEE_POB_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEE_POB_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEE_POB_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_POB_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEE_POB_EB.Location = new System.Drawing.Point(131, 75);
            this.ID_MEE_POB_EB.MaxLength = 20;
            this.ID_MEE_POB_EB.Name = "ID_MEE_POB_EB";
            this.ID_MEE_POB_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_POB_EB.Size = new System.Drawing.Size(395, 20);
            this.ID_MEE_POB_EB.TabIndex = 43;
            this.ID_MEE_POB_EB.Tag = "";
            this.ID_MEE_POB_EB.Enter += new System.EventHandler(this.ID_MEE_POB_EB_Enter);
            this.ID_MEE_POB_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEE_POB_EB_KeyPress);
            // 
            // ID_MEE_EXT_PIC
            // 
            this.ID_MEE_EXT_PIC.Location = new System.Drawing.Point(309, 130);
            this.ID_MEE_EXT_PIC.Name = "ID_MEE_EXT_PIC";
            this.ID_MEE_EXT_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_EXT_PIC.OcxState")));
            this.ID_MEE_EXT_PIC.Size = new System.Drawing.Size(57, 21);
            this.ID_MEE_EXT_PIC.TabIndex = 53;
            this.ID_MEE_EXT_PIC.Tag = "";
            this.ID_MEE_EXT_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_EXT_PIC_KeyPressEvent);
            this.ID_MEE_EXT_PIC.Enter += new System.EventHandler(this.ID_MEE_EXT_PIC_Enter);
            // 
            // ID_MEE_FAX_PIC
            // 
            this.ID_MEE_FAX_PIC.Location = new System.Drawing.Point(425, 129);
            this.ID_MEE_FAX_PIC.Name = "ID_MEE_FAX_PIC";
            this.ID_MEE_FAX_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_FAX_PIC.OcxState")));
            this.ID_MEE_FAX_PIC.Size = new System.Drawing.Size(102, 22);
            this.ID_MEE_FAX_PIC.TabIndex = 55;
            this.ID_MEE_FAX_PIC.Tag = "";
            this.ID_MEE_FAX_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_FAX_PIC_KeyPressEvent);
            this.ID_MEE_FAX_PIC.Enter += new System.EventHandler(this.ID_MEE_FAX_PIC_Enter);
            // 
            // _ID_MEE_ETT_TXT_13
            // 
            this._ID_MEE_ETT_TXT_13.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_13.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_13.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_13.Location = new System.Drawing.Point(12, 52);
            this._ID_MEE_ETT_TXT_13.Name = "_ID_MEE_ETT_TXT_13";
            this._ID_MEE_ETT_TXT_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_13.Size = new System.Drawing.Size(99, 17);
            this._ID_MEE_ETT_TXT_13.TabIndex = 40;
            this._ID_MEE_ETT_TXT_13.Tag = "";
            this._ID_MEE_ETT_TXT_13.Text = "Co&lonia";
            // 
            // _ID_MEE_ETT_TXT_14
            // 
            this._ID_MEE_ETT_TXT_14.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_14.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_14.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_14.Location = new System.Drawing.Point(12, 77);
            this._ID_MEE_ETT_TXT_14.Name = "_ID_MEE_ETT_TXT_14";
            this._ID_MEE_ETT_TXT_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_14.Size = new System.Drawing.Size(113, 17);
            this._ID_MEE_ETT_TXT_14.TabIndex = 42;
            this._ID_MEE_ETT_TXT_14.Tag = "";
            this._ID_MEE_ETT_TXT_14.Text = "&Pob./Del./Mun.";
            // 
            // _ID_MEE_ETT_TXT_18
            // 
            this._ID_MEE_ETT_TXT_18.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_18.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_18.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_18.Location = new System.Drawing.Point(12, 133);
            this._ID_MEE_ETT_TXT_18.Name = "_ID_MEE_ETT_TXT_18";
            this._ID_MEE_ETT_TXT_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_18.Size = new System.Drawing.Size(113, 15);
            this._ID_MEE_ETT_TXT_18.TabIndex = 50;
            this._ID_MEE_ETT_TXT_18.Tag = "";
            this._ID_MEE_ETT_TXT_18.Text = "Teléfono &Oficina";
            // 
            // _ID_MEE_ETT_TXT_12
            // 
            this._ID_MEE_ETT_TXT_12.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_12.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_12.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_12.Location = new System.Drawing.Point(12, 25);
            this._ID_MEE_ETT_TXT_12.Name = "_ID_MEE_ETT_TXT_12";
            this._ID_MEE_ETT_TXT_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_12.Size = new System.Drawing.Size(99, 19);
            this._ID_MEE_ETT_TXT_12.TabIndex = 38;
            this._ID_MEE_ETT_TXT_12.Tag = "";
            this._ID_MEE_ETT_TXT_12.Text = "C&alle y Número";
            // 
            // _ID_MEE_ETT_TXT_16
            // 
            this._ID_MEE_ETT_TXT_16.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_16.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_16.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_16.Location = new System.Drawing.Point(363, 105);
            this._ID_MEE_ETT_TXT_16.Name = "_ID_MEE_ETT_TXT_16";
            this._ID_MEE_ETT_TXT_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_16.Size = new System.Drawing.Size(77, 13);
            this._ID_MEE_ETT_TXT_16.TabIndex = 46;
            this._ID_MEE_ETT_TXT_16.Tag = "";
            this._ID_MEE_ETT_TXT_16.Text = "&Código Postal";
            // 
            // _ID_MEE_ETT_TXT_20
            // 
            this._ID_MEE_ETT_TXT_20.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_20.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_20.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_20.Location = new System.Drawing.Point(396, 132);
            this._ID_MEE_ETT_TXT_20.Name = "_ID_MEE_ETT_TXT_20";
            this._ID_MEE_ETT_TXT_20.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_20.Size = new System.Drawing.Size(26, 17);
            this._ID_MEE_ETT_TXT_20.TabIndex = 54;
            this._ID_MEE_ETT_TXT_20.Tag = "";
            this._ID_MEE_ETT_TXT_20.Text = "&Fax";
            // 
            // _ID_MEE_ETT_TXT_19
            // 
            this._ID_MEE_ETT_TXT_19.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_19.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_19.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_19.Location = new System.Drawing.Point(246, 132);
            this._ID_MEE_ETT_TXT_19.Name = "_ID_MEE_ETT_TXT_19";
            this._ID_MEE_ETT_TXT_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_19.Size = new System.Drawing.Size(59, 17);
            this._ID_MEE_ETT_TXT_19.TabIndex = 52;
            this._ID_MEE_ETT_TXT_19.Tag = "";
            this._ID_MEE_ETT_TXT_19.Text = "E&xtensión";
            this._ID_MEE_ETT_TXT_19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // ID_MEE_COL_EB
            // 
            this.ID_MEE_COL_EB.AcceptsReturn = true;
            this.ID_MEE_COL_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEE_COL_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEE_COL_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_COL_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEE_COL_EB.Location = new System.Drawing.Point(131, 50);
            this.ID_MEE_COL_EB.MaxLength = 25;
            this.ID_MEE_COL_EB.Name = "ID_MEE_COL_EB";
            this.ID_MEE_COL_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_COL_EB.Size = new System.Drawing.Size(395, 20);
            this.ID_MEE_COL_EB.TabIndex = 41;
            this.ID_MEE_COL_EB.Tag = "";
            this.ID_MEE_COL_EB.Enter += new System.EventHandler(this.ID_MEE_COL_EB_Enter);
            this.ID_MEE_COL_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEE_COL_EB_KeyPress);
            // 
            // ID_MEE_CP_PIC
            // 
            this.ID_MEE_CP_PIC.Location = new System.Drawing.Point(450, 102);
            this.ID_MEE_CP_PIC.Name = "ID_MEE_CP_PIC";
            this.ID_MEE_CP_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_CP_PIC.OcxState")));
            this.ID_MEE_CP_PIC.Size = new System.Drawing.Size(76, 21);
            this.ID_MEE_CP_PIC.TabIndex = 47;
            this.ID_MEE_CP_PIC.Tag = "";
            this.ID_MEE_CP_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_CP_PIC_KeyPressEvent);
            this.ID_MEE_CP_PIC.Enter += new System.EventHandler(this.ID_MEE_CP_PIC_Enter);
            this.ID_MEE_CP_PIC.Leave += new System.EventHandler(this.ID_MEE_CP_PIC_Leave);
            // 
            // _ID_MEM_EDO_EB_1
            // 
            this._ID_MEM_EDO_EB_1.BackColor = System.Drawing.SystemColors.Window;
            this._ID_MEM_EDO_EB_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_EDO_EB_1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ID_MEM_EDO_EB_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_EDO_EB_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this._ID_MEM_EDO_EB_1, new int[0]);
            this._ID_MEM_EDO_EB_1.Location = new System.Drawing.Point(131, 102);
            this._ID_MEM_EDO_EB_1.Name = "_ID_MEM_EDO_EB_1";
            this._ID_MEM_EDO_EB_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_EDO_EB_1.Size = new System.Drawing.Size(200, 21);
            this._ID_MEM_EDO_EB_1.TabIndex = 45;
            this._ID_MEM_EDO_EB_1.Tag = "";
            this._ID_MEM_EDO_EB_1.SelectedIndexChanged += new System.EventHandler(this.ID_MEM_EDO_EB_SelectedIndexChanged);
            // 
            // ID_MEE_CNU_EB
            // 
            this.ID_MEE_CNU_EB.AcceptsReturn = true;
            this.ID_MEE_CNU_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEE_CNU_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEE_CNU_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_CNU_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEE_CNU_EB.Location = new System.Drawing.Point(131, 24);
            this.ID_MEE_CNU_EB.MaxLength = 35;
            this.ID_MEE_CNU_EB.Name = "ID_MEE_CNU_EB";
            this.ID_MEE_CNU_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_CNU_EB.Size = new System.Drawing.Size(395, 20);
            this.ID_MEE_CNU_EB.TabIndex = 39;
            this.ID_MEE_CNU_EB.Tag = "";
            this.ID_MEE_CNU_EB.Enter += new System.EventHandler(this.ID_MEE_CNU_EB_Enter);
            this.ID_MEE_CNU_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEE_CNU_EB_KeyPress);
            // 
            // _fraDomicilio_1
            // 
            this._fraDomicilio_1.BackColor = System.Drawing.SystemColors.Control;
            this._fraDomicilio_1.Controls.Add(this.ID_MEE_TDO_PIC);
            this._fraDomicilio_1.Controls.Add(this._ID_MEE_ETT_TXT_15);
            this._fraDomicilio_1.Controls.Add(this._ID_MEM_COL_EB_0);
            this._fraDomicilio_1.Controls.Add(this._ID_MEM_PDM_EB_0);
            this._fraDomicilio_1.Controls.Add(this._ID_MEM_CIU_EB_0);
            this._fraDomicilio_1.Controls.Add(this._ID_MEM_ETT_TXT_14);
            this._fraDomicilio_1.Controls.Add(this._ID_MEM_ETT_TXT_10);
            this._fraDomicilio_1.Controls.Add(this._ID_MEM_ETT_TXT_9);
            this._fraDomicilio_1.Controls.Add(this._ID_MEM_ETT_TXT_15);
            this._fraDomicilio_1.Controls.Add(this._ID_MEM_ETT_TXT_12);
            this._fraDomicilio_1.Controls.Add(this._ID_MEM_ETT_TXT_13);
            this._fraDomicilio_1.Controls.Add(this._ID_MEM_DOM_EB_0);
            this._fraDomicilio_1.Controls.Add(this._ID_MEM_EDO_EB_0);
            this._fraDomicilio_1.Controls.Add(this._ID_MEM_CP_PIC_0);
            this._fraDomicilio_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraDomicilio_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._fraDomicilio_1.Location = new System.Drawing.Point(15, 175);
            this._fraDomicilio_1.Name = "_fraDomicilio_1";
            this._fraDomicilio_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._fraDomicilio_1.Size = new System.Drawing.Size(547, 193);
            this._fraDomicilio_1.TabIndex = 56;
            this._fraDomicilio_1.TabStop = false;
            this._fraDomicilio_1.Tag = "";
            this._fraDomicilio_1.Text = "Domicilio Particular";
            // 
            // ID_MEE_TDO_PIC
            // 
            this.ID_MEE_TDO_PIC.Location = new System.Drawing.Point(131, 162);
            this.ID_MEE_TDO_PIC.Name = "ID_MEE_TDO_PIC";
            this.ID_MEE_TDO_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_TDO_PIC.OcxState")));
            this.ID_MEE_TDO_PIC.Size = new System.Drawing.Size(102, 22);
            this.ID_MEE_TDO_PIC.TabIndex = 70;
            this.ID_MEE_TDO_PIC.Tag = "";
            this.ID_MEE_TDO_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_TDO_PIC_KeyPressEvent);
            this.ID_MEE_TDO_PIC.Enter += new System.EventHandler(this.ID_MEE_TDO_PIC_Enter);
            // 
            // _ID_MEE_ETT_TXT_15
            // 
            this._ID_MEE_ETT_TXT_15.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEE_ETT_TXT_15.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_15.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_15.Location = new System.Drawing.Point(12, 166);
            this._ID_MEE_ETT_TXT_15.Name = "_ID_MEE_ETT_TXT_15";
            this._ID_MEE_ETT_TXT_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_15.Size = new System.Drawing.Size(113, 15);
            this._ID_MEE_ETT_TXT_15.TabIndex = 69;
            this._ID_MEE_ETT_TXT_15.Tag = "";
            this._ID_MEE_ETT_TXT_15.Text = "Teléfono &Domicilio";
            // 
            // _ID_MEM_COL_EB_0
            // 
            this._ID_MEM_COL_EB_0.AcceptsReturn = true;
            this._ID_MEM_COL_EB_0.BackColor = System.Drawing.Color.White;
            this._ID_MEM_COL_EB_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_COL_EB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_COL_EB_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_COL_EB_0.Location = new System.Drawing.Point(131, 47);
            this._ID_MEM_COL_EB_0.MaxLength = 25;
            this._ID_MEM_COL_EB_0.Name = "_ID_MEM_COL_EB_0";
            this._ID_MEM_COL_EB_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_COL_EB_0.Size = new System.Drawing.Size(394, 20);
            this._ID_MEM_COL_EB_0.TabIndex = 60;
            this._ID_MEM_COL_EB_0.Tag = "";
            this._ID_MEM_COL_EB_0.TextChanged += new System.EventHandler(this.ID_MEM_COL_EB_TextChanged);
            this._ID_MEM_COL_EB_0.Enter += new System.EventHandler(this.ID_MEM_COL_EB_Enter);
            this._ID_MEM_COL_EB_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_COL_EB_KeyPress);
            // 
            // _ID_MEM_PDM_EB_0
            // 
            this._ID_MEM_PDM_EB_0.AcceptsReturn = true;
            this._ID_MEM_PDM_EB_0.BackColor = System.Drawing.Color.White;
            this._ID_MEM_PDM_EB_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_PDM_EB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_PDM_EB_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_PDM_EB_0.Location = new System.Drawing.Point(131, 76);
            this._ID_MEM_PDM_EB_0.MaxLength = 25;
            this._ID_MEM_PDM_EB_0.Name = "_ID_MEM_PDM_EB_0";
            this._ID_MEM_PDM_EB_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_PDM_EB_0.Size = new System.Drawing.Size(394, 20);
            this._ID_MEM_PDM_EB_0.TabIndex = 62;
            this._ID_MEM_PDM_EB_0.Tag = "";
            this._ID_MEM_PDM_EB_0.TextChanged += new System.EventHandler(this.ID_MEM_PDM_EB_TextChanged);
            this._ID_MEM_PDM_EB_0.Enter += new System.EventHandler(this.ID_MEM_PDM_EB_Enter);
            this._ID_MEM_PDM_EB_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_PDM_EB_KeyPress);
            // 
            // _ID_MEM_CIU_EB_0
            // 
            this._ID_MEM_CIU_EB_0.AcceptsReturn = true;
            this._ID_MEM_CIU_EB_0.BackColor = System.Drawing.Color.White;
            this._ID_MEM_CIU_EB_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_CIU_EB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_CIU_EB_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_CIU_EB_0.Location = new System.Drawing.Point(131, 105);
            this._ID_MEM_CIU_EB_0.MaxLength = 25;
            this._ID_MEM_CIU_EB_0.Name = "_ID_MEM_CIU_EB_0";
            this._ID_MEM_CIU_EB_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_CIU_EB_0.Size = new System.Drawing.Size(394, 20);
            this._ID_MEM_CIU_EB_0.TabIndex = 64;
            this._ID_MEM_CIU_EB_0.Tag = "";
            this._ID_MEM_CIU_EB_0.TextChanged += new System.EventHandler(this.ID_MEM_CIU_EB_TextChanged);
            this._ID_MEM_CIU_EB_0.Enter += new System.EventHandler(this.ID_MEM_CIU_EB_Enter);
            this._ID_MEM_CIU_EB_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_CIU_EB_KeyPress);
            // 
            // _ID_MEM_ETT_TXT_14
            // 
            this._ID_MEM_ETT_TXT_14.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_14.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_14.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_14.Location = new System.Drawing.Point(15, 136);
            this._ID_MEM_ETT_TXT_14.Name = "_ID_MEM_ETT_TXT_14";
            this._ID_MEM_ETT_TXT_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_14.Size = new System.Drawing.Size(85, 17);
            this._ID_MEM_ETT_TXT_14.TabIndex = 65;
            this._ID_MEM_ETT_TXT_14.Tag = "";
            this._ID_MEM_ETT_TXT_14.Text = "&Estado";
            // 
            // _ID_MEM_ETT_TXT_10
            // 
            this._ID_MEM_ETT_TXT_10.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_10.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_10.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_10.Location = new System.Drawing.Point(15, 49);
            this._ID_MEM_ETT_TXT_10.Name = "_ID_MEM_ETT_TXT_10";
            this._ID_MEM_ETT_TXT_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_10.Size = new System.Drawing.Size(87, 17);
            this._ID_MEM_ETT_TXT_10.TabIndex = 59;
            this._ID_MEM_ETT_TXT_10.Tag = "";
            this._ID_MEM_ETT_TXT_10.Text = "&Colonia";
            // 
            // _ID_MEM_ETT_TXT_9
            // 
            this._ID_MEM_ETT_TXT_9.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_9.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_9.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_9.Location = new System.Drawing.Point(15, 20);
            this._ID_MEM_ETT_TXT_9.Name = "_ID_MEM_ETT_TXT_9";
            this._ID_MEM_ETT_TXT_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_9.Size = new System.Drawing.Size(110, 17);
            this._ID_MEM_ETT_TXT_9.TabIndex = 57;
            this._ID_MEM_ETT_TXT_9.Tag = "";
            this._ID_MEM_ETT_TXT_9.Text = "&Calle y Número";
            // 
            // _ID_MEM_ETT_TXT_15
            // 
            this._ID_MEM_ETT_TXT_15.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_15.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_15.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_15.Location = new System.Drawing.Point(361, 137);
            this._ID_MEM_ETT_TXT_15.Name = "_ID_MEM_ETT_TXT_15";
            this._ID_MEM_ETT_TXT_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_15.Size = new System.Drawing.Size(79, 15);
            this._ID_MEM_ETT_TXT_15.TabIndex = 67;
            this._ID_MEM_ETT_TXT_15.Tag = "";
            this._ID_MEM_ETT_TXT_15.Text = "Código Postal";
            // 
            // _ID_MEM_ETT_TXT_12
            // 
            this._ID_MEM_ETT_TXT_12.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_12.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_12.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_12.Location = new System.Drawing.Point(15, 78);
            this._ID_MEM_ETT_TXT_12.Name = "_ID_MEM_ETT_TXT_12";
            this._ID_MEM_ETT_TXT_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_12.Size = new System.Drawing.Size(85, 17);
            this._ID_MEM_ETT_TXT_12.TabIndex = 61;
            this._ID_MEM_ETT_TXT_12.Tag = "";
            this._ID_MEM_ETT_TXT_12.Text = "&Pob./Del./Mun.";
            // 
            // _ID_MEM_ETT_TXT_13
            // 
            this._ID_MEM_ETT_TXT_13.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_13.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_13.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_13.Location = new System.Drawing.Point(15, 107);
            this._ID_MEM_ETT_TXT_13.Name = "_ID_MEM_ETT_TXT_13";
            this._ID_MEM_ETT_TXT_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_13.Size = new System.Drawing.Size(87, 17);
            this._ID_MEM_ETT_TXT_13.TabIndex = 63;
            this._ID_MEM_ETT_TXT_13.Tag = "";
            this._ID_MEM_ETT_TXT_13.Text = "C&iudad";
            // 
            // _ID_MEM_DOM_EB_0
            // 
            this._ID_MEM_DOM_EB_0.AcceptsReturn = true;
            this._ID_MEM_DOM_EB_0.BackColor = System.Drawing.Color.White;
            this._ID_MEM_DOM_EB_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._ID_MEM_DOM_EB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_DOM_EB_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_MEM_DOM_EB_0.Location = new System.Drawing.Point(131, 18);
            this._ID_MEM_DOM_EB_0.MaxLength = 35;
            this._ID_MEM_DOM_EB_0.Name = "_ID_MEM_DOM_EB_0";
            this._ID_MEM_DOM_EB_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_DOM_EB_0.Size = new System.Drawing.Size(394, 20);
            this._ID_MEM_DOM_EB_0.TabIndex = 58;
            this._ID_MEM_DOM_EB_0.Tag = "";
            this._ID_MEM_DOM_EB_0.TextChanged += new System.EventHandler(this.ID_MEM_DOM_EB_TextChanged);
            this._ID_MEM_DOM_EB_0.Enter += new System.EventHandler(this.ID_MEM_DOM_EB_Enter);
            this._ID_MEM_DOM_EB_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_DOM_EB_KeyPress);
            // 
            // _ID_MEM_EDO_EB_0
            // 
            this._ID_MEM_EDO_EB_0.BackColor = System.Drawing.SystemColors.Window;
            this._ID_MEM_EDO_EB_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_EDO_EB_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._ID_MEM_EDO_EB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_EDO_EB_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this._ID_MEM_EDO_EB_0, new int[0]);
            this._ID_MEM_EDO_EB_0.Location = new System.Drawing.Point(131, 132);
            this._ID_MEM_EDO_EB_0.Name = "_ID_MEM_EDO_EB_0";
            this._ID_MEM_EDO_EB_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_EDO_EB_0.Size = new System.Drawing.Size(200, 21);
            this._ID_MEM_EDO_EB_0.TabIndex = 66;
            this._ID_MEM_EDO_EB_0.Tag = "";
            this._ID_MEM_EDO_EB_0.SelectedIndexChanged += new System.EventHandler(this.ID_MEM_EDO_EB_SelectedIndexChanged);
            // 
            // _ID_MEM_CP_PIC_0
            // 
            this._ID_MEM_CP_PIC_0.Location = new System.Drawing.Point(449, 133);
            this._ID_MEM_CP_PIC_0.Name = "_ID_MEM_CP_PIC_0";
            this._ID_MEM_CP_PIC_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_MEM_CP_PIC_0.OcxState")));
            this._ID_MEM_CP_PIC_0.Size = new System.Drawing.Size(76, 22);
            this._ID_MEM_CP_PIC_0.TabIndex = 68;
            this._ID_MEM_CP_PIC_0.Tag = "";
            this._ID_MEM_CP_PIC_0.Change += new System.EventHandler(this.ID_MEM_CP_PIC_Change);
            this._ID_MEM_CP_PIC_0.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEM_CP_PIC_KeyPressEvent);
            this._ID_MEM_CP_PIC_0.Enter += new System.EventHandler(this.ID_MEM_CP_PIC_Enter);
            // 
            // _ID_MEE_TAR_FPT_TabPage2
            // 
            this._ID_MEE_TAR_FPT_TabPage2.Controls.Add(this.mskMCC);
            this._ID_MEE_TAR_FPT_TabPage2.Controls.Add(this.fraEjecutivos);
            this._ID_MEE_TAR_FPT_TabPage2.Controls.Add(this._ID_MEM_TEX_PNL_1);
            this._ID_MEE_TAR_FPT_TabPage2.Controls.Add(this._ID_MEM_MES_FIS_LBL_1);
            this._ID_MEE_TAR_FPT_TabPage2.Controls.Add(this._ID_MEM_ETT_TXT_5);
            this._ID_MEE_TAR_FPT_TabPage2.Controls.Add(this._fraDatosAdicionales_0);
            this._ID_MEE_TAR_FPT_TabPage2.Controls.Add(this._fraDatosAdicionales_3);
            this._ID_MEE_TAR_FPT_TabPage2.Controls.Add(this._fraDatosAdicionales_2);
            this._ID_MEE_TAR_FPT_TabPage2.Controls.Add(this._fraDatosAdicionales_1);
            this._ID_MEE_TAR_FPT_TabPage2.Location = new System.Drawing.Point(4, 22);
            this._ID_MEE_TAR_FPT_TabPage2.Name = "_ID_MEE_TAR_FPT_TabPage2";
            this._ID_MEE_TAR_FPT_TabPage2.Size = new System.Drawing.Size(573, 398);
            this._ID_MEE_TAR_FPT_TabPage2.TabIndex = 1;
            this._ID_MEE_TAR_FPT_TabPage2.Tag = "";
            this._ID_MEE_TAR_FPT_TabPage2.Text = "Datos Adicionales";
            this._ID_MEE_TAR_FPT_TabPage2.UseVisualStyleBackColor = true;
            // 
            // mskMCC
            // 
            this.mskMCC.Location = new System.Drawing.Point(455, 124);
            this.mskMCC.Name = "mskMCC";
            this.mskMCC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mskMCC.OcxState")));
            this.mskMCC.Size = new System.Drawing.Size(98, 22);
            this.mskMCC.TabIndex = 89;
            this.mskMCC.Tag = "";
            this.mskMCC.Change += new System.EventHandler(this.mskMCC_Change);
            this.mskMCC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mskMCC_KeyPressEvent);
            this.mskMCC.Enter += new System.EventHandler(this.mskMCC_Enter);
            // 
            // fraEjecutivos
            // 
            this.fraEjecutivos.Controls.Add(this._optEjecutivos_0);
            this.fraEjecutivos.Controls.Add(this._optEjecutivos_1);
            this.fraEjecutivos.Controls.Add(this._optEjecutivos_2);
            this.fraEjecutivos.Enabled = false;
            this.fraEjecutivos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraEjecutivos.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraEjecutivos.Location = new System.Drawing.Point(304, 160);
            this.fraEjecutivos.Name = "fraEjecutivos";
            this.fraEjecutivos.Size = new System.Drawing.Size(249, 129);
            this.fraEjecutivos.TabIndex = 84;
            this.fraEjecutivos.TabStop = false;
            this.fraEjecutivos.Tag = "";
            this.fraEjecutivos.Text = "Tipo de Bloqueo";
            // 
            // _optEjecutivos_0
            // 
            this._optEjecutivos_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEjecutivos_0.Location = new System.Drawing.Point(40, 32);
            this._optEjecutivos_0.Name = "_optEjecutivos_0";
            this._optEjecutivos_0.Size = new System.Drawing.Size(144, 26);
            this._optEjecutivos_0.TabIndex = 85;
            this._optEjecutivos_0.Tag = "";
            this._optEjecutivos_0.Text = "No maneja bloqueo";
            this._optEjecutivos_0.CheckedChanged += new System.EventHandler(this._optEjecutivos_0_CheckedChanged);
            // 
            // _optEjecutivos_1
            // 
            this._optEjecutivos_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEjecutivos_1.Location = new System.Drawing.Point(40, 64);
            this._optEjecutivos_1.Name = "_optEjecutivos_1";
            this._optEjecutivos_1.Size = new System.Drawing.Size(144, 24);
            this._optEjecutivos_1.TabIndex = 86;
            this._optEjecutivos_1.Tag = "";
            this._optEjecutivos_1.Text = "Bloqueo por MCC";
            this._optEjecutivos_1.CheckedChanged += new System.EventHandler(this._optEjecutivos_1_CheckedChanged);
            // 
            // _optEjecutivos_2
            // 
            this._optEjecutivos_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optEjecutivos_2.Location = new System.Drawing.Point(40, 96);
            this._optEjecutivos_2.Name = "_optEjecutivos_2";
            this._optEjecutivos_2.Size = new System.Drawing.Size(203, 27);
            this._optEjecutivos_2.TabIndex = 87;
            this._optEjecutivos_2.Tag = "";
            this._optEjecutivos_2.Text = "Bloqueo por No. de Negocio";
            this._optEjecutivos_2.CheckedChanged += new System.EventHandler(this._optEjecutivos_2_CheckedChanged);
            // 
            // _ID_MEM_TEX_PNL_1
            // 
            this._ID_MEM_TEX_PNL_1.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_TEX_PNL_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ID_MEM_TEX_PNL_1.Controls.Add(this._optNacionalidad_0);
            this._ID_MEM_TEX_PNL_1.Controls.Add(this._optNacionalidad_1);
            this._ID_MEM_TEX_PNL_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_TEX_PNL_1.Location = new System.Drawing.Point(96, 118);
            this._ID_MEM_TEX_PNL_1.Name = "_ID_MEM_TEX_PNL_1";
            this._ID_MEM_TEX_PNL_1.Size = new System.Drawing.Size(194, 37);
            this._ID_MEM_TEX_PNL_1.TabIndex = 90;
            this._ID_MEM_TEX_PNL_1.Tag = "";
            // 
            // _optNacionalidad_0
            // 
            this._optNacionalidad_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optNacionalidad_0.Location = new System.Drawing.Point(6, 11);
            this._optNacionalidad_0.Name = "_optNacionalidad_0";
            this._optNacionalidad_0.Size = new System.Drawing.Size(86, 19);
            this._optNacionalidad_0.TabIndex = 92;
            this._optNacionalidad_0.Tag = "";
            this._optNacionalidad_0.Text = "Mexicana";
            this._optNacionalidad_0.CheckedChanged += new System.EventHandler(this._optNacionalidad_0_CheckedChanged);
            // 
            // _optNacionalidad_1
            // 
            this._optNacionalidad_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optNacionalidad_1.Location = new System.Drawing.Point(96, 11);
            this._optNacionalidad_1.Name = "_optNacionalidad_1";
            this._optNacionalidad_1.Size = new System.Drawing.Size(87, 19);
            this._optNacionalidad_1.TabIndex = 91;
            this._optNacionalidad_1.Tag = "";
            this._optNacionalidad_1.Text = "Extranjera";
            this._optNacionalidad_1.CheckedChanged += new System.EventHandler(this._optNacionalidad_1_CheckedChanged);
            // 
            // _ID_MEM_MES_FIS_LBL_1
            // 
            this._ID_MEM_MES_FIS_LBL_1.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_MES_FIS_LBL_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_MES_FIS_LBL_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_MES_FIS_LBL_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_MES_FIS_LBL_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_MES_FIS_LBL_1.Location = new System.Drawing.Point(304, 131);
            this._ID_MEM_MES_FIS_LBL_1.Name = "_ID_MEM_MES_FIS_LBL_1";
            this._ID_MEM_MES_FIS_LBL_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_MES_FIS_LBL_1.Size = new System.Drawing.Size(146, 17);
            this._ID_MEM_MES_FIS_LBL_1.TabIndex = 75;
            this._ID_MEM_MES_FIS_LBL_1.Tag = "";
            this._ID_MEM_MES_FIS_LBL_1.Text = "Tabla MCC / Negocio";
            // 
            // _ID_MEM_ETT_TXT_5
            // 
            this._ID_MEM_ETT_TXT_5.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MEM_ETT_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEM_ETT_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEM_ETT_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_ETT_TXT_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEM_ETT_TXT_5.Location = new System.Drawing.Point(16, 131);
            this._ID_MEM_ETT_TXT_5.Name = "_ID_MEM_ETT_TXT_5";
            this._ID_MEM_ETT_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEM_ETT_TXT_5.Size = new System.Drawing.Size(85, 17);
            this._ID_MEM_ETT_TXT_5.TabIndex = 88;
            this._ID_MEM_ETT_TXT_5.Tag = "";
            this._ID_MEM_ETT_TXT_5.Text = "Nacionalidad";
            // 
            // _fraDatosAdicionales_0
            // 
            this._fraDatosAdicionales_0.BackColor = System.Drawing.SystemColors.Control;
            this._fraDatosAdicionales_0.Controls.Add(this._chkPinPlastico_1);
            this._fraDatosAdicionales_0.Controls.Add(this._chkPinPlastico_0);
            this._fraDatosAdicionales_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraDatosAdicionales_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._fraDatosAdicionales_0.Location = new System.Drawing.Point(16, 12);
            this._fraDatosAdicionales_0.Name = "_fraDatosAdicionales_0";
            this._fraDatosAdicionales_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._fraDatosAdicionales_0.Size = new System.Drawing.Size(275, 98);
            this._fraDatosAdicionales_0.TabIndex = 71;
            this._fraDatosAdicionales_0.TabStop = false;
            this._fraDatosAdicionales_0.Tag = "";
            this._fraDatosAdicionales_0.Text = "&Plástico Pin";
            // 
            // _chkPinPlastico_1
            // 
            this._chkPinPlastico_1.BackColor = System.Drawing.SystemColors.Control;
            this._chkPinPlastico_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._chkPinPlastico_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chkPinPlastico_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._chkPinPlastico_1.Location = new System.Drawing.Point(27, 60);
            this._chkPinPlastico_1.Name = "_chkPinPlastico_1";
            this._chkPinPlastico_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._chkPinPlastico_1.Size = new System.Drawing.Size(118, 28);
            this._chkPinPlastico_1.TabIndex = 73;
            this._chkPinPlastico_1.Tag = "";
            this._chkPinPlastico_1.Text = "Generar Pin";
            this._chkPinPlastico_1.UseVisualStyleBackColor = false;
            this._chkPinPlastico_1.CheckStateChanged += new System.EventHandler(this.chkPinPlastico_CheckStateChanged);
            // 
            // _chkPinPlastico_0
            // 
            this._chkPinPlastico_0.BackColor = System.Drawing.SystemColors.Control;
            this._chkPinPlastico_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._chkPinPlastico_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._chkPinPlastico_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._chkPinPlastico_0.Location = new System.Drawing.Point(27, 24);
            this._chkPinPlastico_0.Name = "_chkPinPlastico_0";
            this._chkPinPlastico_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._chkPinPlastico_0.Size = new System.Drawing.Size(118, 28);
            this._chkPinPlastico_0.TabIndex = 72;
            this._chkPinPlastico_0.Tag = "";
            this._chkPinPlastico_0.Text = "Generar Plástico";
            this._chkPinPlastico_0.UseVisualStyleBackColor = false;
            this._chkPinPlastico_0.CheckStateChanged += new System.EventHandler(this.chkPinPlastico_CheckStateChanged);
            // 
            // _fraDatosAdicionales_3
            // 
            this._fraDatosAdicionales_3.BackColor = System.Drawing.SystemColors.Control;
            this._fraDatosAdicionales_3.Controls.Add(this.ID_MEM_PERSONA);
            this._fraDatosAdicionales_3.Controls.Add(this.txtAtencionA);
            this._fraDatosAdicionales_3.Controls.Add(this._ID_MEE_ETT_TXT_7);
            this._fraDatosAdicionales_3.Controls.Add(this._ID_MEE_ETT_TXT_9);
            this._fraDatosAdicionales_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraDatosAdicionales_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._fraDatosAdicionales_3.Location = new System.Drawing.Point(16, 292);
            this._fraDatosAdicionales_3.Name = "_fraDatosAdicionales_3";
            this._fraDatosAdicionales_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._fraDatosAdicionales_3.Size = new System.Drawing.Size(537, 81);
            this._fraDatosAdicionales_3.TabIndex = 93;
            this._fraDatosAdicionales_3.TabStop = false;
            this._fraDatosAdicionales_3.Tag = "";
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
            this.ID_MEM_PERSONA.Size = new System.Drawing.Size(376, 21);
            this.ID_MEM_PERSONA.TabIndex = 94;
            this.ID_MEM_PERSONA.Tag = "";
            this.ID_MEM_PERSONA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEM_PERSONA_KeyPress);
            this.ID_MEM_PERSONA.Leave += new System.EventHandler(this.ID_MEM_PERSONA_Leave);
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
            this.txtAtencionA.TabIndex = 96;
            this.txtAtencionA.Tag = "";
            this.txtAtencionA.Enter += new System.EventHandler(this.txtAtencionA_Enter);
            this.txtAtencionA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAtencionA_KeyPress);
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
            this._ID_MEE_ETT_TXT_7.TabIndex = 95;
            this._ID_MEE_ETT_TXT_7.Tag = "";
            this._ID_MEE_ETT_TXT_7.Text = "&Persona";
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
            this._ID_MEE_ETT_TXT_9.TabIndex = 97;
            this._ID_MEE_ETT_TXT_9.Tag = "";
            this._ID_MEE_ETT_TXT_9.Text = "&Atención A: ";
            // 
            // _fraDatosAdicionales_2
            // 
            this._fraDatosAdicionales_2.BackColor = System.Drawing.SystemColors.Control;
            this._fraDatosAdicionales_2.Controls.Add(this.chkSkipPayment);
            this._fraDatosAdicionales_2.Controls.Add(this.chkCuentaControl);
            this._fraDatosAdicionales_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraDatosAdicionales_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._fraDatosAdicionales_2.Location = new System.Drawing.Point(16, 160);
            this._fraDatosAdicionales_2.Name = "_fraDatosAdicionales_2";
            this._fraDatosAdicionales_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._fraDatosAdicionales_2.Size = new System.Drawing.Size(273, 129);
            this._fraDatosAdicionales_2.TabIndex = 76;
            this._fraDatosAdicionales_2.TabStop = false;
            this._fraDatosAdicionales_2.Tag = "";
            // 
            // chkSkipPayment
            // 
            this.chkSkipPayment.BackColor = System.Drawing.SystemColors.Control;
            this.chkSkipPayment.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkSkipPayment.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSkipPayment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkSkipPayment.Location = new System.Drawing.Point(18, 21);
            this.chkSkipPayment.Name = "chkSkipPayment";
            this.chkSkipPayment.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkSkipPayment.Size = new System.Drawing.Size(121, 25);
            this.chkSkipPayment.TabIndex = 77;
            this.chkSkipPayment.Tag = "";
            this.chkSkipPayment.Text = "Skip Payment";
            this.chkSkipPayment.UseVisualStyleBackColor = false;
            this.chkSkipPayment.CheckStateChanged += new System.EventHandler(this.chkSkipPayment_CheckStateChanged);
            // 
            // chkCuentaControl
            // 
            this.chkCuentaControl.BackColor = System.Drawing.SystemColors.Control;
            this.chkCuentaControl.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkCuentaControl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCuentaControl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCuentaControl.Location = new System.Drawing.Point(18, 63);
            this.chkCuentaControl.Name = "chkCuentaControl";
            this.chkCuentaControl.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkCuentaControl.Size = new System.Drawing.Size(121, 25);
            this.chkCuentaControl.TabIndex = 78;
            this.chkCuentaControl.Tag = "";
            this.chkCuentaControl.Text = "Cuenta Control";
            this.chkCuentaControl.UseVisualStyleBackColor = false;
            this.chkCuentaControl.CheckStateChanged += new System.EventHandler(this.chkCuentaControl_CheckStateChanged);
            // 
            // _fraDatosAdicionales_1
            // 
            this._fraDatosAdicionales_1.BackColor = System.Drawing.SystemColors.Control;
            this._fraDatosAdicionales_1.Controls.Add(this._ID_MEM_TFA_3OPB_0);
            this._fraDatosAdicionales_1.Controls.Add(this._ID_MEM_TFA_3OPB_1);
            this._fraDatosAdicionales_1.Enabled = false;
            this._fraDatosAdicionales_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._fraDatosAdicionales_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._fraDatosAdicionales_1.Location = new System.Drawing.Point(304, 12);
            this._fraDatosAdicionales_1.Name = "_fraDatosAdicionales_1";
            this._fraDatosAdicionales_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._fraDatosAdicionales_1.Size = new System.Drawing.Size(249, 98);
            this._fraDatosAdicionales_1.TabIndex = 74;
            this._fraDatosAdicionales_1.TabStop = false;
            this._fraDatosAdicionales_1.Tag = "";
            this._fraDatosAdicionales_1.Text = "Tipo &Facturación";
            // 
            // _ID_MEM_TFA_3OPB_0
            // 
            this._ID_MEM_TFA_3OPB_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_TFA_3OPB_0.Location = new System.Drawing.Point(48, 27);
            this._ID_MEM_TFA_3OPB_0.Name = "_ID_MEM_TFA_3OPB_0";
            this._ID_MEM_TFA_3OPB_0.Size = new System.Drawing.Size(125, 25);
            this._ID_MEM_TFA_3OPB_0.TabIndex = 82;
            this._ID_MEM_TFA_3OPB_0.Tag = "";
            this._ID_MEM_TFA_3OPB_0.Text = "&Corporativo";
            this._ID_MEM_TFA_3OPB_0.CheckedChanged += new System.EventHandler(this._ID_MEM_TFA_3OPB_0_CheckedChanged);
            // 
            // _ID_MEM_TFA_3OPB_1
            // 
            this._ID_MEM_TFA_3OPB_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEM_TFA_3OPB_1.Location = new System.Drawing.Point(48, 63);
            this._ID_MEM_TFA_3OPB_1.Name = "_ID_MEM_TFA_3OPB_1";
            this._ID_MEM_TFA_3OPB_1.Size = new System.Drawing.Size(125, 25);
            this._ID_MEM_TFA_3OPB_1.TabIndex = 83;
            this._ID_MEM_TFA_3OPB_1.Tag = "";
            this._ID_MEM_TFA_3OPB_1.Text = "&Individual";
            this._ID_MEM_TFA_3OPB_1.CheckedChanged += new System.EventHandler(this._ID_MEM_TFA_3OPB_1_CheckedChanged);
            // 
            // ID_MEE_IMP_PB
            // 
            this.ID_MEE_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEE_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEE_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEE_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEE_IMP_PB.Location = new System.Drawing.Point(393, 438);
            this.ID_MEE_IMP_PB.Name = "ID_MEE_IMP_PB";
            this.ID_MEE_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_IMP_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEE_IMP_PB.TabIndex = 81;
            this.ID_MEE_IMP_PB.Tag = "";
            this.ID_MEE_IMP_PB.Text = "&Imprimir";
            this.ID_MEE_IMP_PB.UseVisualStyleBackColor = false;
            this.ID_MEE_IMP_PB.Click += new System.EventHandler(this.ID_MEE_IMP_PB_Click);
            this.ID_MEE_IMP_PB.Leave += new System.EventHandler(this.ID_MEE_IMP_PB_Leave);
            // 
            // ID_MEE_ALT_PB
            // 
            this.ID_MEE_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEE_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEE_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEE_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEE_ALT_PB.Location = new System.Drawing.Point(128, 438);
            this.ID_MEE_ALT_PB.Name = "ID_MEE_ALT_PB";
            this.ID_MEE_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_ALT_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEE_ALT_PB.TabIndex = 79;
            this.ID_MEE_ALT_PB.Tag = "";
            this.ID_MEE_ALT_PB.Text = "Aceptar";
            this.ID_MEE_ALT_PB.UseVisualStyleBackColor = false;
            this.ID_MEE_ALT_PB.Click += new System.EventHandler(this.ID_MEE_ALT_PB_Click);
            // 
            // ID_MEE_CER_PB
            // 
            this.ID_MEE_CER_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEE_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEE_CER_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_MEE_CER_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEE_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEE_CER_PB.Location = new System.Drawing.Point(261, 438);
            this.ID_MEE_CER_PB.Name = "ID_MEE_CER_PB";
            this.ID_MEE_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_CER_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEE_CER_PB.TabIndex = 80;
            this.ID_MEE_CER_PB.Tag = "Cancela";
            this.ID_MEE_CER_PB.Text = "Cancelar";
            this.ID_MEE_CER_PB.UseVisualStyleBackColor = false;
            this.ID_MEE_CER_PB.Click += new System.EventHandler(this.ID_MEE_CER_PB_Click);
            // 
            // CORMNEJE
            // 
            this.AcceptButton = this.ID_MEE_CER_PB;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.ID_MEE_CER_PB;
            this.ClientSize = new System.Drawing.Size(591, 470);
            this.Controls.Add(this.ID_MEE_IMP_PB);
            this.Controls.Add(this.ID_MEE_TAR_FPT);
            this.Controls.Add(this.ID_MEE_ALT_PB);
            this.Controls.Add(this.ID_MEE_CER_PB);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(253, 209);
            this.Name = "CORMNEJE";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Tarjetahabientes Empresa";
            this.Activated += new System.EventHandler(this.CORMNEJE_Activated);
            this.Closed += new System.EventHandler(this.CORMNEJE_Closed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORMNEJE_KeyPress);
            this.ID_MEE_TAR_FPT.ResumeLayout(false);
            this._ID_MEE_TAR_FPT_TabPage0.ResumeLayout(false);
            this._ID_MEE_DEJ_FRM_0.ResumeLayout(false);
            this._ID_MEE_DEJ_FRM_0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisEfectivo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_LIM_FTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_COR_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_RFC_EB)).EndInit();
            this._ID_MEM_TEX_PNL_0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_NOM_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_SDO_EB)).EndInit();
            this.ID_MEE_CON_FRM.ResumeLayout(false);
            this.ID_MEE_CON_FRM.PerformLayout();
            this._ID_MEE_TAR_FPT_TabPage1.ResumeLayout(false);
            this._fraDomicilio_0.ResumeLayout(false);
            this._fraDomicilio_0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_ZPO_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_TOF_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_EXT_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_FAX_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_CP_PIC)).EndInit();
            this._fraDomicilio_1.ResumeLayout(false);
            this._fraDomicilio_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_TDO_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_MEM_CP_PIC_0)).EndInit();
            this._ID_MEE_TAR_FPT_TabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mskMCC)).EndInit();
            this.fraEjecutivos.ResumeLayout(false);
            this._ID_MEM_TEX_PNL_1.ResumeLayout(false);
            this._fraDatosAdicionales_0.ResumeLayout(false);
            this._fraDatosAdicionales_3.ResumeLayout(false);
            this._fraDatosAdicionales_3.PerformLayout();
            this._fraDatosAdicionales_2.ResumeLayout(false);
            this._fraDatosAdicionales_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).EndInit();
            this.ResumeLayout(false);

	}
	void  InitializefraDatosAdicionales()
	{
			this.fraDatosAdicionales[3] = _fraDatosAdicionales_3;
			this.fraDatosAdicionales[2] = _fraDatosAdicionales_2;
			this.fraDatosAdicionales[1] = _fraDatosAdicionales_1;
			this.fraDatosAdicionales[0] = _fraDatosAdicionales_0;
	}
	void  InitializeoptNacionalidad()
	{
			this.optNacionalidad[1] = _optNacionalidad_1;
			this.optNacionalidad[0] = _optNacionalidad_0;
	}
	void  InitializeID_MEM_TEX_PNL()
	{
			this.ID_MEM_TEX_PNL[0] = _ID_MEM_TEX_PNL_0;
			this.ID_MEM_TEX_PNL[1] = _ID_MEM_TEX_PNL_1;
	}
	void  InitializeID_MEM_CIU_EB()
	{
			this.ID_MEM_CIU_EB[0] = _ID_MEM_CIU_EB_0;
	}
	void  InitializechkPinPlastico()
	{
			this.chkPinPlastico[1] = _chkPinPlastico_1;
			this.chkPinPlastico[0] = _chkPinPlastico_0;
	}
	void  InitializeID_MEM_COL_EB()
	{
			this.ID_MEM_COL_EB[0] = _ID_MEM_COL_EB_0;
	}
	void  InitializeID_MEM_EDO_EB()
	{
			this.ID_MEM_EDO_EB[0] = _ID_MEM_EDO_EB_0;
			this.ID_MEM_EDO_EB[1] = _ID_MEM_EDO_EB_1;
	}
	void  InitializeID_MEM_CP_PIC()
	{
			this.ID_MEM_CP_PIC[0] = _ID_MEM_CP_PIC_0;
	}
	void  InitializeID_MEE_DEJ_FRM()
	{
			this.ID_MEE_DEJ_FRM[0] = _ID_MEE_DEJ_FRM_0;
	}
	void  InitializeID_MEM_ETT_TXT()
	{
			this.ID_MEM_ETT_TXT[15] = _ID_MEM_ETT_TXT_15;
			this.ID_MEM_ETT_TXT[12] = _ID_MEM_ETT_TXT_12;
			this.ID_MEM_ETT_TXT[13] = _ID_MEM_ETT_TXT_13;
			this.ID_MEM_ETT_TXT[14] = _ID_MEM_ETT_TXT_14;
			this.ID_MEM_ETT_TXT[10] = _ID_MEM_ETT_TXT_10;
			this.ID_MEM_ETT_TXT[9] = _ID_MEM_ETT_TXT_9;
			this.ID_MEM_ETT_TXT[6] = _ID_MEM_ETT_TXT_6;
			this.ID_MEM_ETT_TXT[2] = _ID_MEM_ETT_TXT_2;
			this.ID_MEM_ETT_TXT[4] = _ID_MEM_ETT_TXT_4;
			this.ID_MEM_ETT_TXT[1] = _ID_MEM_ETT_TXT_1;
			this.ID_MEM_ETT_TXT[0] = _ID_MEM_ETT_TXT_0;
			this.ID_MEM_ETT_TXT[3] = _ID_MEM_ETT_TXT_3;
			this.ID_MEM_ETT_TXT[5] = _ID_MEM_ETT_TXT_5;
	}
	void  InitializeoptEjecutivos()
	{
			this.optEjecutivos[0] = _optEjecutivos_0;
			this.optEjecutivos[1] = _optEjecutivos_1;
			this.optEjecutivos[2] = _optEjecutivos_2;
	}
	void  InitializeID_MEM_MES_FIS_LBL()
	{
			this.ID_MEM_MES_FIS_LBL[1] = _ID_MEM_MES_FIS_LBL_1;
	}
	void  InitializeID_MEE_ETT_TXT()
	{
			this.ID_MEE_ETT_TXT[9] = _ID_MEE_ETT_TXT_9;
			this.ID_MEE_ETT_TXT[7] = _ID_MEE_ETT_TXT_7;
			this.ID_MEE_ETT_TXT[15] = _ID_MEE_ETT_TXT_15;
			this.ID_MEE_ETT_TXT[17] = _ID_MEE_ETT_TXT_17;
			this.ID_MEE_ETT_TXT[16] = _ID_MEE_ETT_TXT_16;
			this.ID_MEE_ETT_TXT[20] = _ID_MEE_ETT_TXT_20;
			this.ID_MEE_ETT_TXT[19] = _ID_MEE_ETT_TXT_19;
			this.ID_MEE_ETT_TXT[12] = _ID_MEE_ETT_TXT_12;
			this.ID_MEE_ETT_TXT[13] = _ID_MEE_ETT_TXT_13;
			this.ID_MEE_ETT_TXT[14] = _ID_MEE_ETT_TXT_14;
			this.ID_MEE_ETT_TXT[18] = _ID_MEE_ETT_TXT_18;
			this.ID_MEE_ETT_TXT[1] = _ID_MEE_ETT_TXT_1;
			this.ID_MEE_ETT_TXT[0] = _ID_MEE_ETT_TXT_0;
			this.ID_MEE_ETT_TXT[27] = _ID_MEE_ETT_TXT_27;
			this.ID_MEE_ETT_TXT[8] = _ID_MEE_ETT_TXT_8;
			this.ID_MEE_ETT_TXT[2] = _ID_MEE_ETT_TXT_2;
			this.ID_MEE_ETT_TXT[3] = _ID_MEE_ETT_TXT_3;
			this.ID_MEE_ETT_TXT[4] = _ID_MEE_ETT_TXT_4;
			this.ID_MEE_ETT_TXT[5] = _ID_MEE_ETT_TXT_5;
			this.ID_MEE_ETT_TXT[6] = _ID_MEE_ETT_TXT_6;
			this.ID_MEE_ETT_TXT[11] = _ID_MEE_ETT_TXT_11;
			this.ID_MEE_ETT_TXT[31] = _ID_MEE_ETT_TXT_31;
	}
	void  InitializefraDomicilio()
	{
			this.fraDomicilio[1] = _fraDomicilio_1;
			this.fraDomicilio[0] = _fraDomicilio_0;
	}
	void  InitializeID_MEM_TFA_3OPB()
	{
			this.ID_MEM_TFA_3OPB[0] = _ID_MEM_TFA_3OPB_0;
			this.ID_MEM_TFA_3OPB[1] = _ID_MEM_TFA_3OPB_1;
	}
	void  InitializeID_MEM_DOM_EB()
	{
			this.ID_MEM_DOM_EB[0] = _ID_MEM_DOM_EB_0;
	}
	void  InitializeID_MEM_PDM_EB()
	{
			this.ID_MEM_PDM_EB[0] = _ID_MEM_PDM_EB_0;
	}
#endregion 
}
}