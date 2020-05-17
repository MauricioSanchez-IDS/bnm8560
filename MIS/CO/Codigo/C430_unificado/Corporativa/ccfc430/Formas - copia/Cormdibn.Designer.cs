using System;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    partial class CORMDIBN
    {

        #region "Upgrade Support "
        private static CORMDIBN m_vb6FormDefInstance;
        private static bool m_InitializingDefInstance;
        public static CORMDIBN DefInstance
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
        public CORMDIBN()
            : base()
        {
            if (m_vb6FormDefInstance == null)
            {
                m_vb6FormDefInstance = this;
            }
            //This call is required by the Windows Form Designer.
            //stdl_ses_id = String.Empty;
            InitializeComponent();
            InitializeHelp();
            InitializeIDT_GPB();
            InitializesspPanel();
        }
        public static CORMDIBN CreateInstance()
        {
            CORMDIBN theInstance = new CORMDIBN();
            theInstance.Form_Load();
            return theInstance;
        }
        protected void InitializeHelp()
        {
            Artinsoft.VB6.Help.HelpSupportClass.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Index);
        }
        private void ReleaseResources(object eventSender, System.EventArgs eventArgs)
        {
            Dispose(true);
            m_vb6FormDefInstance = null;
        }
        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode]
        protected override void Dispose(bool Disposing)
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
        public System.Windows.Forms.ToolStripMenuItem IDM_PAR;
        public System.Windows.Forms.ToolStripMenuItem IDM_INTD;
        public System.Windows.Forms.ToolStripMenuItem IDM_CDF;
        public System.Windows.Forms.ToolStripMenuItem IDM_ENV;
        public System.Windows.Forms.ToolStripMenuItem IDM_CAMM;
        public System.Windows.Forms.ToolStripMenuItem IDM_LIM;
        public System.Windows.Forms.ToolStripMenuItem IDM_USU;
        public System.Windows.Forms.ToolStripMenuItem IDM_GRU;
        public System.Windows.Forms.ToolStripMenuItem IDM_SEG;
        public System.Windows.Forms.ToolStripSeparator IDM_GUION1;
        public System.Windows.Forms.ToolStripMenuItem IDM_BCO;
        public System.Windows.Forms.ToolStripSeparator IDM_GUION2;
        public System.Windows.Forms.ToolStripMenuItem IDM_SAL;
        public System.Windows.Forms.ToolStripMenuItem IDM_ESP;
        public System.Windows.Forms.ToolStripMenuItem IDM_TRR;
        public System.Windows.Forms.ToolStripMenuItem IDM_DEP;
        public System.Windows.Forms.ToolStripMenuItem IDM_OPE;
        public System.Windows.Forms.ToolStripMenuItem IDM_COR;
        public System.Windows.Forms.ToolStripMenuItem IDM_EMP;
        public System.Windows.Forms.ToolStripMenuItem IDM_NET;
        public System.Windows.Forms.ToolStripMenuItem mnu_unidades;
        public System.Windows.Forms.ToolStripMenuItem mnu_reportes;
        public System.Windows.Forms.ToolStripMenuItem mnu_categorias;
        public System.Windows.Forms.ToolStripMenuItem IDM_EJE;
        public System.Windows.Forms.ToolStripMenuItem IDM_BAN;
        public System.Windows.Forms.ToolStripMenuItem IDM_CCI;
        public System.Windows.Forms.ToolStripMenuItem IDM_DIV;
        public System.Windows.Forms.ToolStripMenuItem IDM_REG;
        public System.Windows.Forms.ToolStripMenuItem mnuEmpresaNueva;
        public System.Windows.Forms.ToolStripMenuItem IDM_ALTAS_MASIVAS;
        public System.Windows.Forms.ToolStripMenuItem mnuEnvioLimCred;
        public System.Windows.Forms.ToolStripMenuItem Estructuras_Gastos;
        public System.Windows.Forms.ToolStripMenuItem mnuCamMasivos;
        public System.Windows.Forms.ToolStripMenuItem IDM_CAT;
        public System.Windows.Forms.ToolStripMenuItem IDM_CEJ;
        public System.Windows.Forms.ToolStripMenuItem IDM_CEM;
        public System.Windows.Forms.ToolStripMenuItem IDM_CON;
        public System.Windows.Forms.ToolStripMenuItem IDM_ANA;
        public System.Windows.Forms.ToolStripMenuItem IDM_ATR;
        public System.Windows.Forms.ToolStripMenuItem IDM_REPORTE;
        public System.Windows.Forms.ToolStripMenuItem mnuCnsDtlEmpresas;
        public System.Windows.Forms.ToolStripMenuItem mnuProcEsp;
        public System.Windows.Forms.ToolStripMenuItem IDM_DEJ;
        public System.Windows.Forms.ToolStripMenuItem IDM_AFI;
        public System.Windows.Forms.ToolStripMenuItem IDM_DET;
        public System.Windows.Forms.ToolStripMenuItem IDM_GER;
        public System.Windows.Forms.ToolStripMenuItem IDM_EER;
        public System.Windows.Forms.ToolStripMenuItem mnu_diario_sbf;
        public System.Windows.Forms.ToolStripMenuItem mnu_corte_sbf;
        public System.Windows.Forms.ToolStripMenuItem mnu_envio_sbf;
        public System.Windows.Forms.ToolStripMenuItem IDM_REN;
        public System.Windows.Forms.ToolStripMenuItem IDM_BNX;
        public System.Windows.Forms.ToolStripMenuItem mnu_account_tran;
        public System.Windows.Forms.ToolStripMenuItem mnu_account_cycle;
        public System.Windows.Forms.ToolStripMenuItem IDM_GBIT;
        public System.Windows.Forms.ToolStripMenuItem IDM_GCOR;
        public System.Windows.Forms.ToolStripMenuItem IDM_GEMP;
        public System.Windows.Forms.ToolStripMenuItem IDM_GACL;
        public System.Windows.Forms.ToolStripMenuItem IDM_GSIT;
        public System.Windows.Forms.ToolStripMenuItem IDM_GCRE;
        public System.Windows.Forms.ToolStripMenuItem IDM_GANT;
        public System.Windows.Forms.ToolStripMenuItem IDM_GVEN;
        public System.Windows.Forms.ToolStripMenuItem IDM_GCOM;
        public System.Windows.Forms.ToolStripMenuItem IDM_GRA;
        public System.Windows.Forms.ToolStripMenuItem IDM_IMP;
        public System.Windows.Forms.ToolStripMenuItem IDM_CFG;
        public System.Windows.Forms.ToolStripMenuItem IDM_EXC;
        public System.Windows.Forms.ToolStripMenuItem IDM_FMT;
        public System.Windows.Forms.ToolStripMenuItem IDM_TXT;
        public System.Windows.Forms.ToolStripMenuItem IDM_WDOM;
        public System.Windows.Forms.ToolStripMenuItem IDM_WCRED;
        public System.Windows.Forms.ToolStripMenuItem IDM_WORD;
        public System.Windows.Forms.ToolStripMenuItem IDM_OPC;
        public System.Windows.Forms.ToolStripMenuItem IDM_ACL;
        public System.Windows.Forms.ToolStripMenuItem IDM_CAP;
        public System.Windows.Forms.ToolStripMenuItem IDM_HIS;
        public System.Windows.Forms.ToolStripMenuItem IDM_AVE;
        public System.Windows.Forms.ToolStripMenuItem IDM_FTP;
        public System.Windows.Forms.ToolStripMenuItem IDM_RPT_TUXEDO;
        public System.Windows.Forms.ToolStripMenuItem mnuRptEmpresarial;
        public System.Windows.Forms.ToolStripMenuItem IDM_CTA;
        public System.Windows.Forms.ToolStripMenuItem IDM_IND;
        public System.Windows.Forms.ToolStripMenuItem IDM_BAS;
        public System.Windows.Forms.ToolStripMenuItem IDM_UAY;
        public System.Windows.Forms.ToolStripSeparator IDM_GUION4;
        public System.Windows.Forms.ToolStripMenuItem IDM_VEN;
        public System.Windows.Forms.ToolStripSeparator IDM_GUION3;
        public System.Windows.Forms.ToolStripMenuItem IDM_ACE;
        public System.Windows.Forms.ToolStripMenuItem IDM_AYU;
        public System.Windows.Forms.MenuStrip MainMenu1;
        public System.Windows.Forms.Timer tmrTimer;
        public System.Windows.Forms.TextBox ID_COR_DDE_EB;
        public AxMSComDlg.AxCommonDialog ID_COR_CMD;
        private AxThreed.AxSSRibbon _IDT_GPB_7;
        private AxThreed.AxSSRibbon _IDT_GPB_6;
        private AxThreed.AxSSRibbon _IDT_GPB_5;
        private AxThreed.AxSSRibbon _IDT_GPB_3;
        private AxThreed.AxSSRibbon _IDT_GPB_4;
        private AxThreed.AxSSRibbon _IDT_GPB_2;
        private AxThreed.AxSSRibbon _IDT_GPB_1;
        private AxThreed.AxSSRibbon _IDT_GPB_0;
        public AxThreed.AxSSPanel ID_COR_BHER;
        public System.Windows.Forms.Label SSPanel1Label_Text;
        public AxThreed.AxSSPanel SSPanel1;
        public AxThreed.AxSSPanel ID_COR_MEDO_PNL;
        private AxThreed.AxSSPanel _sspPanel_0;
        private AxThreed.AxSSPanel _sspPanel_1;
        private AxThreed.AxSSPanel _sspPanel_2;
        public System.Windows.Forms.Label lblNumero;
        public System.Windows.Forms.Label txtEstado;
        public System.Windows.Forms.Label ID_COR_MSG_TXT;
        public AxThreed.AxSSPanel ID_COR_BEDO;
        public AxThreed.AxSSRibbon[] IDT_GPB = new AxThreed.AxSSRibbon[8];
        public AxThreed.AxSSPanel[] sspPanel = new AxThreed.AxSSPanel[3];
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORMDIBN));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MainMenu1 = new System.Windows.Forms.MenuStrip();
            this.IDM_ESP = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_PAR = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_INTD = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_CDF = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_ENV = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_CAMM = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_LIM = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_SEG = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_USU = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GRU = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GUION1 = new System.Windows.Forms.ToolStripSeparator();
            this.IDM_BCO = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GUION2 = new System.Windows.Forms.ToolStripSeparator();
            this.IDM_SAL = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_CAT = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_COR = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_EMP = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_NET = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_unidades = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_reportes = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_categorias = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_EJE = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_BAN = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_CCI = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_DIV = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_REG = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEmpresaNueva = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_ALTAS_MASIVAS = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuEnvioLimCred = new System.Windows.Forms.ToolStripMenuItem();
            this.Estructuras_Gastos = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCamMasivos = new System.Windows.Forms.ToolStripMenuItem();
            this.catalogosDeMonedasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_CTA = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_CON = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_CEJ = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_CEM = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_ANA = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_DET = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_ATR = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_REPORTE = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCnsDtlEmpresas = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuProcEsp = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_DEJ = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_AFI = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GER = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_EER = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_envio_sbf = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_diario_sbf = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_corte_sbf = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_REN = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_BNX = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_account_tran = new System.Windows.Forms.ToolStripMenuItem();
            this.mnu_account_cycle = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GRA = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GBIT = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GCOR = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GEMP = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GACL = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GSIT = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GCRE = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GANT = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GVEN = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GCOM = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_OPC = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_IMP = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_CFG = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_EXC = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_FMT = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_TXT = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_WORD = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_WDOM = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_WCRED = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_ACL = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_CAP = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_HIS = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_AVE = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRptEmpresarial = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_FTP = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_RPT_TUXEDO = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_OPE = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_TRR = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_DEP = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_AYU = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_IND = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_BAS = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_UAY = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GUION4 = new System.Windows.Forms.ToolStripSeparator();
            this.IDM_VEN = new System.Windows.Forms.ToolStripMenuItem();
            this.IDM_GUION3 = new System.Windows.Forms.ToolStripSeparator();
            this.IDM_ACE = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuWindowList = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrTimer = new System.Windows.Forms.Timer(this.components);
            this.ID_COR_BHER = new AxThreed.AxSSPanel();
            this._IDT_GPB_5 = new AxThreed.AxSSRibbon();
            this._IDT_GPB_3 = new AxThreed.AxSSRibbon();
            this._IDT_GPB_7 = new AxThreed.AxSSRibbon();
            this._IDT_GPB_6 = new AxThreed.AxSSRibbon();
            this._IDT_GPB_1 = new AxThreed.AxSSRibbon();
            this._IDT_GPB_0 = new AxThreed.AxSSRibbon();
            this._IDT_GPB_4 = new AxThreed.AxSSRibbon();
            this._IDT_GPB_2 = new AxThreed.AxSSRibbon();
            this.ID_COR_CMD = new AxMSComDlg.AxCommonDialog();
            this.ID_COR_DDE_EB = new System.Windows.Forms.TextBox();
            this.ID_COR_BEDO = new AxThreed.AxSSPanel();
            this._sspPanel_1 = new AxThreed.AxSSPanel();
            this._sspPanel_0 = new AxThreed.AxSSPanel();
            this.ID_COR_MEDO_PNL = new AxThreed.AxSSPanel();
            this._sspPanel_2 = new AxThreed.AxSSPanel();
            this.ID_COR_MSG_TXT = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.SSPanel1 = new AxThreed.AxSSPanel();
            this.SSPanel1Label_Text = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.MainMenu1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_COR_BHER)).BeginInit();
            this.ID_COR_BHER.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_COR_CMD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_COR_BEDO)).BeginInit();
            this.ID_COR_BEDO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._sspPanel_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._sspPanel_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_COR_MEDO_PNL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._sspPanel_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSPanel1)).BeginInit();
            this.SSPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu1
            // 
            this.MainMenu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_ESP,
            this.IDM_CAT,
            this.IDM_CTA,
            this.IDM_OPE,
            this.IDM_AYU,
            this.mnuWindowList});
            this.MainMenu1.Location = new System.Drawing.Point(0, 0);
            this.MainMenu1.MdiWindowListItem = this.mnuWindowList;
            this.MainMenu1.Name = "MainMenu1";
            this.MainMenu1.Size = new System.Drawing.Size(696, 24);
            this.MainMenu1.TabIndex = 0;
            this.MainMenu1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.MainMenu1_ItemClicked);
            // 
            // IDM_ESP
            // 
            this.IDM_ESP.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_PAR,
            this.IDM_INTD,
            this.IDM_CDF,
            this.IDM_ENV,
            this.IDM_CAMM,
            this.IDM_LIM,
            this.IDM_SEG,
            this.IDM_GUION1,
            this.IDM_BCO,
            this.IDM_GUION2,
            this.IDM_SAL});
            this.IDM_ESP.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.IDM_ESP.Name = "IDM_ESP";
            this.IDM_ESP.Size = new System.Drawing.Size(76, 20);
            this.IDM_ESP.Tag = "IDM_C430";
            this.IDM_ESP.Text = "&Configurar";
            this.IDM_ESP.Click += new System.EventHandler(this.IDM_ESP_Click);
            // 
            // IDM_PAR
            // 
            this.IDM_PAR.Name = "IDM_PAR";
            this.IDM_PAR.Size = new System.Drawing.Size(190, 22);
            this.IDM_PAR.Tag = "IDM_ESP";
            this.IDM_PAR.Text = "&Parámetros ";
            this.IDM_PAR.Click += new System.EventHandler(this.IDM_PAR_Click);
            // 
            // IDM_INTD
            // 
            this.IDM_INTD.Name = "IDM_INTD";
            this.IDM_INTD.Size = new System.Drawing.Size(190, 22);
            this.IDM_INTD.Tag = "IDM_ESP";
            this.IDM_INTD.Text = "&Estatus de Integración";
            this.IDM_INTD.Click += new System.EventHandler(this.IDM_INTD_Click);
            // 
            // IDM_CDF
            // 
            this.IDM_CDF.Name = "IDM_CDF";
            this.IDM_CDF.Size = new System.Drawing.Size(190, 22);
            this.IDM_CDF.Tag = "";
            this.IDM_CDF.Text = "Es&tatus CDF";
            this.IDM_CDF.Click += new System.EventHandler(this.IDM_CDF_Click);
            // 
            // IDM_ENV
            // 
            this.IDM_ENV.Name = "IDM_ENV";
            this.IDM_ENV.Size = new System.Drawing.Size(190, 22);
            this.IDM_ENV.Tag = "";
            this.IDM_ENV.Text = "E&status Envio";
            this.IDM_ENV.Click += new System.EventHandler(this.IDM_ENV_Click);
            // 
            // IDM_CAMM
            // 
            this.IDM_CAMM.Enabled = false;
            this.IDM_CAMM.Name = "IDM_CAMM";
            this.IDM_CAMM.Size = new System.Drawing.Size(190, 22);
            this.IDM_CAMM.Tag = "IDM_ESP";
            this.IDM_CAMM.Text = "&Cambios Masivos";
            this.IDM_CAMM.Visible = false;
            this.IDM_CAMM.Click += new System.EventHandler(this.IDM_CAMM_Click);
            // 
            // IDM_LIM
            // 
            this.IDM_LIM.Name = "IDM_LIM";
            this.IDM_LIM.Size = new System.Drawing.Size(190, 22);
            this.IDM_LIM.Tag = "IDM_ESP";
            this.IDM_LIM.Text = "&Límites de Crédito";
            this.IDM_LIM.Click += new System.EventHandler(this.IDM_LIM_Click);
            // 
            // IDM_SEG
            // 
            this.IDM_SEG.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_USU,
            this.IDM_GRU});
            this.IDM_SEG.Enabled = false;
            this.IDM_SEG.Name = "IDM_SEG";
            this.IDM_SEG.Size = new System.Drawing.Size(190, 22);
            this.IDM_SEG.Tag = "IDM_ESP";
            this.IDM_SEG.Text = "Segu&ridad";
            this.IDM_SEG.Visible = false;
            this.IDM_SEG.Click += new System.EventHandler(this.IDM_SEG_Click);
            // 
            // IDM_USU
            // 
            this.IDM_USU.Name = "IDM_USU";
            this.IDM_USU.Size = new System.Drawing.Size(119, 22);
            this.IDM_USU.Tag = "IDM_SEG";
            this.IDM_USU.Text = "&Usuarios";
            this.IDM_USU.Click += new System.EventHandler(this.IDM_USU_Click);
            // 
            // IDM_GRU
            // 
            this.IDM_GRU.Name = "IDM_GRU";
            this.IDM_GRU.Size = new System.Drawing.Size(119, 22);
            this.IDM_GRU.Tag = "IDM_SEG";
            this.IDM_GRU.Text = "&Grupos";
            this.IDM_GRU.Click += new System.EventHandler(this.IDM_GRU_Click);
            // 
            // IDM_GUION1
            // 
            this.IDM_GUION1.Name = "IDM_GUION1";
            this.IDM_GUION1.Size = new System.Drawing.Size(187, 6);
            this.IDM_GUION1.Tag = "IDM_ESP";
            // 
            // IDM_BCO
            // 
            this.IDM_BCO.Name = "IDM_BCO";
            this.IDM_BCO.Size = new System.Drawing.Size(190, 22);
            this.IDM_BCO.Tag = "IDM_ESP";
            this.IDM_BCO.Text = "&Banco de Operación";
            this.IDM_BCO.Click += new System.EventHandler(this.IDM_BCO_Click);
            // 
            // IDM_GUION2
            // 
            this.IDM_GUION2.Name = "IDM_GUION2";
            this.IDM_GUION2.Size = new System.Drawing.Size(187, 6);
            this.IDM_GUION2.Tag = "IDM_ESP";
            // 
            // IDM_SAL
            // 
            this.IDM_SAL.Name = "IDM_SAL";
            this.IDM_SAL.Size = new System.Drawing.Size(190, 22);
            this.IDM_SAL.Tag = "IDM_ESP";
            this.IDM_SAL.Text = "&Salir";
            this.IDM_SAL.Click += new System.EventHandler(this.IDM_SAL_Click);
            // 
            // IDM_CAT
            // 
            this.IDM_CAT.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_COR,
            this.IDM_EMP,
            this.IDM_NET,
            this.mnu_unidades,
            this.mnu_reportes,
            this.mnu_categorias,
            this.IDM_EJE,
            this.IDM_BAN,
            this.IDM_CCI,
            this.IDM_DIV,
            this.IDM_REG,
            this.mnuEmpresaNueva,
            this.IDM_ALTAS_MASIVAS,
            this.mnuEnvioLimCred,
            this.Estructuras_Gastos,
            this.mnuCamMasivos,
            this.catalogosDeMonedasToolStripMenuItem});
            this.IDM_CAT.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.IDM_CAT.Name = "IDM_CAT";
            this.IDM_CAT.Size = new System.Drawing.Size(60, 20);
            this.IDM_CAT.Tag = "IDM_C430";
            this.IDM_CAT.Text = "&Archivo";
            this.IDM_CAT.Click += new System.EventHandler(this.IDM_CAT_Click);
            // 
            // IDM_COR
            // 
            this.IDM_COR.Name = "IDM_COR";
            this.IDM_COR.Size = new System.Drawing.Size(305, 22);
            this.IDM_COR.Tag = "IDM_CAT";
            this.IDM_COR.Text = "&Corporativos";
            this.IDM_COR.Click += new System.EventHandler(this.IDM_COR_Click);
            // 
            // IDM_EMP
            // 
            this.IDM_EMP.Name = "IDM_EMP";
            this.IDM_EMP.Size = new System.Drawing.Size(305, 22);
            this.IDM_EMP.Tag = "IDM_CAT";
            this.IDM_EMP.Text = "&Empresas";
            this.IDM_EMP.Click += new System.EventHandler(this.IDM_EMP_Click);
            // 
            // IDM_NET
            // 
            this.IDM_NET.Name = "IDM_NET";
            this.IDM_NET.Size = new System.Drawing.Size(305, 22);
            this.IDM_NET.Tag = "";
            this.IDM_NET.Text = "Banca&Net";
            this.IDM_NET.Click += new System.EventHandler(this.IDM_NET_Click);
            // 
            // mnu_unidades
            // 
            this.mnu_unidades.Name = "mnu_unidades";
            this.mnu_unidades.Size = new System.Drawing.Size(305, 22);
            this.mnu_unidades.Tag = "";
            this.mnu_unidades.Text = "&Unidades";
            this.mnu_unidades.Click += new System.EventHandler(this.mnu_unidades_Click);
            // 
            // mnu_reportes
            // 
            this.mnu_reportes.Name = "mnu_reportes";
            this.mnu_reportes.Size = new System.Drawing.Size(305, 22);
            this.mnu_reportes.Tag = "";
            this.mnu_reportes.Text = "Re&portes Banamex Empresarial";
            this.mnu_reportes.Click += new System.EventHandler(this.mnu_reportes_Click);
            // 
            // mnu_categorias
            // 
            this.mnu_categorias.Enabled = false;
            this.mnu_categorias.Name = "mnu_categorias";
            this.mnu_categorias.Size = new System.Drawing.Size(305, 22);
            this.mnu_categorias.Tag = "";
            this.mnu_categorias.Text = "&Categorias";
            this.mnu_categorias.Visible = false;
            this.mnu_categorias.Click += new System.EventHandler(this.mnu_categorias_Click);
            // 
            // IDM_EJE
            // 
            this.IDM_EJE.Name = "IDM_EJE";
            this.IDM_EJE.Size = new System.Drawing.Size(305, 22);
            this.IDM_EJE.Tag = "IDM_CAT";
            this.IDM_EJE.Text = "Tarjetahabientes E&mpresa";
            this.IDM_EJE.Click += new System.EventHandler(this.IDM_EJE_Click);
            // 
            // IDM_BAN
            // 
            this.IDM_BAN.Name = "IDM_BAN";
            this.IDM_BAN.Size = new System.Drawing.Size(305, 22);
            this.IDM_BAN.Tag = "IDM_CAT";
            this.IDM_BAN.Text = "Ejecutivos &Banamex";
            this.IDM_BAN.Click += new System.EventHandler(this.IDM_BAN_Click);
            // 
            // IDM_CCI
            // 
            this.IDM_CCI.Name = "IDM_CCI";
            this.IDM_CCI.Size = new System.Drawing.Size(305, 22);
            this.IDM_CCI.Tag = "IDM_CAT";
            this.IDM_CCI.Text = "&Activar reportes en CCI";
            this.IDM_CCI.Click += new System.EventHandler(this.IDM_CCI_Click);
            // 
            // IDM_DIV
            // 
            this.IDM_DIV.Enabled = false;
            this.IDM_DIV.Name = "IDM_DIV";
            this.IDM_DIV.Size = new System.Drawing.Size(305, 22);
            this.IDM_DIV.Tag = "IDM_CAT";
            this.IDM_DIV.Text = "&Divisiones Regionales";
            this.IDM_DIV.Visible = false;
            this.IDM_DIV.Click += new System.EventHandler(this.IDM_DIV_Click);
            // 
            // IDM_REG
            // 
            this.IDM_REG.Enabled = false;
            this.IDM_REG.Name = "IDM_REG";
            this.IDM_REG.Size = new System.Drawing.Size(305, 22);
            this.IDM_REG.Tag = "IDM_CAT";
            this.IDM_REG.Text = "&Regiones";
            this.IDM_REG.Visible = false;
            this.IDM_REG.Click += new System.EventHandler(this.IDM_REG_Click);
            // 
            // mnuEmpresaNueva
            // 
            this.mnuEmpresaNueva.Enabled = false;
            this.mnuEmpresaNueva.Name = "mnuEmpresaNueva";
            this.mnuEmpresaNueva.Size = new System.Drawing.Size(305, 22);
            this.mnuEmpresaNueva.Tag = "";
            this.mnuEmpresaNueva.Text = "Empresa Nueva";
            this.mnuEmpresaNueva.Visible = false;
            this.mnuEmpresaNueva.Click += new System.EventHandler(this.mnuEmpresaNueva_Click);
            // 
            // IDM_ALTAS_MASIVAS
            // 
            this.IDM_ALTAS_MASIVAS.Enabled = false;
            this.IDM_ALTAS_MASIVAS.Name = "IDM_ALTAS_MASIVAS";
            this.IDM_ALTAS_MASIVAS.Size = new System.Drawing.Size(305, 22);
            this.IDM_ALTAS_MASIVAS.Tag = "";
            this.IDM_ALTAS_MASIVAS.Text = "&Altas Masivas";
            this.IDM_ALTAS_MASIVAS.Visible = false;
            this.IDM_ALTAS_MASIVAS.Click += new System.EventHandler(this.IDM_ALTAS_MASIVAS_Click);
            // 
            // mnuEnvioLimCred
            // 
            this.mnuEnvioLimCred.Name = "mnuEnvioLimCred";
            this.mnuEnvioLimCred.Size = new System.Drawing.Size(305, 22);
            this.mnuEnvioLimCred.Tag = "";
            this.mnuEnvioLimCred.Text = "Autorización de &cambio en límite de crédito";
            this.mnuEnvioLimCred.Click += new System.EventHandler(this.mnuEnvioLimCred_Click);
            // 
            // Estructuras_Gastos
            // 
            this.Estructuras_Gastos.Name = "Estructuras_Gastos";
            this.Estructuras_Gastos.Size = new System.Drawing.Size(305, 22);
            this.Estructuras_Gastos.Tag = "IDM_CAT";
            this.Estructuras_Gastos.Text = "&Estructuras de Gastos";
            this.Estructuras_Gastos.Click += new System.EventHandler(this.Estructuras_Gastos_Click);
            // 
            // mnuCamMasivos
            // 
            this.mnuCamMasivos.Name = "mnuCamMasivos";
            this.mnuCamMasivos.Size = new System.Drawing.Size(305, 22);
            this.mnuCamMasivos.Tag = "";
            this.mnuCamMasivos.Text = "Cambios Masivos Ejecutivo";
            this.mnuCamMasivos.Click += new System.EventHandler(this.mnuCamMasivos_Click);
            // 
            // catalogosDeMonedasToolStripMenuItem
            // 
            this.catalogosDeMonedasToolStripMenuItem.Name = "catalogosDeMonedasToolStripMenuItem";
            this.catalogosDeMonedasToolStripMenuItem.Size = new System.Drawing.Size(305, 22);
            this.catalogosDeMonedasToolStripMenuItem.Text = "Catalogos de Monedas";
            this.catalogosDeMonedasToolStripMenuItem.Click += new System.EventHandler(this.catalogosDeMonedasToolStripMenuItem_Click);
            // 
            // IDM_CTA
            // 
            this.IDM_CTA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_CON,
            this.IDM_ANA,
            this.IDM_DET,
            this.IDM_GER,
            this.IDM_EER,
            this.mnu_envio_sbf,
            this.IDM_REN,
            this.IDM_BNX,
            this.mnu_account_tran,
            this.mnu_account_cycle,
            this.IDM_GRA,
            this.IDM_OPC,
            this.IDM_ACL,
            this.IDM_CAP,
            this.IDM_HIS,
            this.IDM_AVE,
            this.mnuRptEmpresarial});
            this.IDM_CTA.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.IDM_CTA.Name = "IDM_CTA";
            this.IDM_CTA.Size = new System.Drawing.Size(71, 20);
            this.IDM_CTA.Tag = "IDM_C430";
            this.IDM_CTA.Text = "Co&nsultas";
            this.IDM_CTA.Click += new System.EventHandler(this.IDM_CTA_Click);
            // 
            // IDM_CON
            // 
            this.IDM_CON.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_CEJ,
            this.IDM_CEM});
            this.IDM_CON.Name = "IDM_CON";
            this.IDM_CON.Size = new System.Drawing.Size(259, 22);
            this.IDM_CON.Tag = "IDM_CTA";
            this.IDM_CON.Text = "&Concentrado";
            this.IDM_CON.Click += new System.EventHandler(this.IDM_CON_Click);
            // 
            // IDM_CEJ
            // 
            this.IDM_CEJ.Name = "IDM_CEJ";
            this.IDM_CEJ.Size = new System.Drawing.Size(172, 22);
            this.IDM_CEJ.Tag = "IDM_CON";
            this.IDM_CEJ.Text = "&Empresa/Ejecutivo";
            this.IDM_CEJ.Click += new System.EventHandler(this.IDM_CEJ_Click);
            // 
            // IDM_CEM
            // 
            this.IDM_CEM.Name = "IDM_CEM";
            this.IDM_CEM.Size = new System.Drawing.Size(172, 22);
            this.IDM_CEM.Tag = "IDM_CON";
            this.IDM_CEM.Text = "&Grupo/Empresa";
            this.IDM_CEM.Click += new System.EventHandler(this.IDM_CEM_Click);
            // 
            // IDM_ANA
            // 
            this.IDM_ANA.Name = "IDM_ANA";
            this.IDM_ANA.Size = new System.Drawing.Size(259, 22);
            this.IDM_ANA.Tag = "IDM_CTA";
            this.IDM_ANA.Text = "Consumos por &Giro";
            this.IDM_ANA.Click += new System.EventHandler(this.IDM_ANA_Click);
            // 
            // IDM_DET
            // 
            this.IDM_DET.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_ATR,
            this.IDM_REPORTE,
            this.mnuCnsDtlEmpresas,
            this.mnuProcEsp,
            this.IDM_DEJ,
            this.IDM_AFI});
            this.IDM_DET.Name = "IDM_DET";
            this.IDM_DET.Size = new System.Drawing.Size(259, 22);
            this.IDM_DET.Tag = "IDM_CTA";
            this.IDM_DET.Text = "&Detalle";
            this.IDM_DET.Click += new System.EventHandler(this.IDM_DET_Click);
            // 
            // IDM_ATR
            // 
            this.IDM_ATR.Name = "IDM_ATR";
            this.IDM_ATR.Size = new System.Drawing.Size(185, 22);
            this.IDM_ATR.Tag = "IDM_DET";
            this.IDM_ATR.Text = "Atrasos por &Ejecutivo";
            this.IDM_ATR.Click += new System.EventHandler(this.IDM_ATR_Click);
            // 
            // IDM_REPORTE
            // 
            this.IDM_REPORTE.Name = "IDM_REPORTE";
            this.IDM_REPORTE.Size = new System.Drawing.Size(185, 22);
            this.IDM_REPORTE.Tag = "";
            this.IDM_REPORTE.Text = "Cuentas &Nuevas";
            this.IDM_REPORTE.Click += new System.EventHandler(this.IDM_REPORTE_Click);
            // 
            // mnuCnsDtlEmpresas
            // 
            this.mnuCnsDtlEmpresas.Name = "mnuCnsDtlEmpresas";
            this.mnuCnsDtlEmpresas.Size = new System.Drawing.Size(185, 22);
            this.mnuCnsDtlEmpresas.Tag = "";
            this.mnuCnsDtlEmpresas.Text = "E&mpresas";
            this.mnuCnsDtlEmpresas.Click += new System.EventHandler(this.mnuCnsDtlEmpresas_Click);
            // 
            // mnuProcEsp
            // 
            this.mnuProcEsp.Name = "mnuProcEsp";
            this.mnuProcEsp.Size = new System.Drawing.Size(185, 22);
            this.mnuProcEsp.Tag = "";
            this.mnuProcEsp.Text = "&ProcesoEspecial";
            this.mnuProcEsp.Click += new System.EventHandler(this.mnuProcEsp_Click);
            // 
            // IDM_DEJ
            // 
            this.IDM_DEJ.Name = "IDM_DEJ";
            this.IDM_DEJ.Size = new System.Drawing.Size(185, 22);
            this.IDM_DEJ.Tag = "IDM_DET";
            this.IDM_DEJ.Text = "Ejecutivos &Banamex";
            this.IDM_DEJ.Click += new System.EventHandler(this.IDM_DEJ_Click);
            // 
            // IDM_AFI
            // 
            this.IDM_AFI.Name = "IDM_AFI";
            this.IDM_AFI.Size = new System.Drawing.Size(185, 22);
            this.IDM_AFI.Tag = "IDM_DET";
            this.IDM_AFI.Text = "Empresas &Afiliadas";
            this.IDM_AFI.Click += new System.EventHandler(this.IDM_AFI_Click);
            // 
            // IDM_GER
            // 
            this.IDM_GER.Enabled = false;
            this.IDM_GER.Name = "IDM_GER";
            this.IDM_GER.Size = new System.Drawing.Size(259, 22);
            this.IDM_GER.Tag = "IDM_CTA";
            this.IDM_GER.Text = "&Reportes Crystal Report";
            this.IDM_GER.Visible = false;
            this.IDM_GER.Click += new System.EventHandler(this.IDM_GER_Click);
            // 
            // IDM_EER
            // 
            this.IDM_EER.Name = "IDM_EER";
            this.IDM_EER.Size = new System.Drawing.Size(259, 22);
            this.IDM_EER.Tag = "";
            this.IDM_EER.Text = "&Estatus Envio Reportes";
            this.IDM_EER.Click += new System.EventHandler(this.IDM_EER_Click);
            // 
            // mnu_envio_sbf
            // 
            this.mnu_envio_sbf.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnu_diario_sbf,
            this.mnu_corte_sbf});
            this.mnu_envio_sbf.Name = "mnu_envio_sbf";
            this.mnu_envio_sbf.Size = new System.Drawing.Size(259, 22);
            this.mnu_envio_sbf.Tag = "";
            this.mnu_envio_sbf.Text = "Envios...";
            // 
            // mnu_diario_sbf
            // 
            this.mnu_diario_sbf.Name = "mnu_diario_sbf";
            this.mnu_diario_sbf.Size = new System.Drawing.Size(184, 22);
            this.mnu_diario_sbf.Tag = "";
            this.mnu_diario_sbf.Text = "Diario";
            this.mnu_diario_sbf.Visible = false;
            // 
            // mnu_corte_sbf
            // 
            this.mnu_corte_sbf.Name = "mnu_corte_sbf";
            this.mnu_corte_sbf.Size = new System.Drawing.Size(184, 22);
            this.mnu_corte_sbf.Tag = "";
            this.mnu_corte_sbf.Text = "Liberación CCF / SBF";
            this.mnu_corte_sbf.Click += new System.EventHandler(this.mnu_corte_sbf_Click);
            // 
            // IDM_REN
            // 
            this.IDM_REN.Name = "IDM_REN";
            this.IDM_REN.Size = new System.Drawing.Size(259, 22);
            this.IDM_REN.Tag = "IDM_CTA";
            this.IDM_REN.Text = "&Rentabilidad";
            this.IDM_REN.Click += new System.EventHandler(this.IDM_REN_Click);
            // 
            // IDM_BNX
            // 
            this.IDM_BNX.Enabled = false;
            this.IDM_BNX.Name = "IDM_BNX";
            this.IDM_BNX.Size = new System.Drawing.Size(259, 22);
            this.IDM_BNX.Tag = "IDM_CTA";
            this.IDM_BNX.Text = "Ejecutivos &Banamex";
            this.IDM_BNX.Visible = false;
            this.IDM_BNX.Click += new System.EventHandler(this.IDM_BNX_Click);
            // 
            // mnu_account_tran
            // 
            this.mnu_account_tran.Enabled = false;
            this.mnu_account_tran.Name = "mnu_account_tran";
            this.mnu_account_tran.Size = new System.Drawing.Size(259, 22);
            this.mnu_account_tran.Tag = "";
            this.mnu_account_tran.Text = "Account Transaction Totals Inquiry";
            this.mnu_account_tran.Visible = false;
            this.mnu_account_tran.Click += new System.EventHandler(this.mnu_account_tran_Click);
            // 
            // mnu_account_cycle
            // 
            this.mnu_account_cycle.Name = "mnu_account_cycle";
            this.mnu_account_cycle.Size = new System.Drawing.Size(259, 22);
            this.mnu_account_cycle.Tag = "";
            this.mnu_account_cycle.Text = "Account Cycle Report";
            this.mnu_account_cycle.Click += new System.EventHandler(this.mnu_account_cycle_Click);
            // 
            // IDM_GRA
            // 
            this.IDM_GRA.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_GBIT,
            this.IDM_GCOR,
            this.IDM_GEMP,
            this.IDM_GACL,
            this.IDM_GSIT,
            this.IDM_GCRE,
            this.IDM_GANT,
            this.IDM_GVEN,
            this.IDM_GCOM});
            this.IDM_GRA.Enabled = false;
            this.IDM_GRA.Name = "IDM_GRA";
            this.IDM_GRA.Size = new System.Drawing.Size(259, 22);
            this.IDM_GRA.Tag = "IDM_CTA";
            this.IDM_GRA.Text = "Grá&ficas";
            this.IDM_GRA.Visible = false;
            this.IDM_GRA.Click += new System.EventHandler(this.IDM_GRA_Click);
            // 
            // IDM_GBIT
            // 
            this.IDM_GBIT.Name = "IDM_GBIT";
            this.IDM_GBIT.Size = new System.Drawing.Size(205, 22);
            this.IDM_GBIT.Tag = "IDM_GRA";
            this.IDM_GBIT.Text = "&Bitácora";
            this.IDM_GBIT.Click += new System.EventHandler(this.IDM_GBIT_Click);
            // 
            // IDM_GCOR
            // 
            this.IDM_GCOR.Name = "IDM_GCOR";
            this.IDM_GCOR.Size = new System.Drawing.Size(205, 22);
            this.IDM_GCOR.Tag = "IDM_GRA";
            this.IDM_GCOR.Text = "C&orporativos";
            this.IDM_GCOR.Click += new System.EventHandler(this.IDM_GCOR_Click);
            // 
            // IDM_GEMP
            // 
            this.IDM_GEMP.Name = "IDM_GEMP";
            this.IDM_GEMP.Size = new System.Drawing.Size(205, 22);
            this.IDM_GEMP.Tag = "IDM_GRA";
            this.IDM_GEMP.Text = "&Empresas";
            this.IDM_GEMP.Click += new System.EventHandler(this.IDM_GEMP_Click);
            // 
            // IDM_GACL
            // 
            this.IDM_GACL.Name = "IDM_GACL";
            this.IDM_GACL.Size = new System.Drawing.Size(205, 22);
            this.IDM_GACL.Tag = "IDM_GRA";
            this.IDM_GACL.Text = "&Aclaraciones";
            this.IDM_GACL.Click += new System.EventHandler(this.IDM_GACL_Click);
            // 
            // IDM_GSIT
            // 
            this.IDM_GSIT.Name = "IDM_GSIT";
            this.IDM_GSIT.Size = new System.Drawing.Size(205, 22);
            this.IDM_GSIT.Tag = "IDM_GRA";
            this.IDM_GSIT.Text = "&Situación de la Cuenta";
            this.IDM_GSIT.Click += new System.EventHandler(this.IDM_GSIT_Click);
            // 
            // IDM_GCRE
            // 
            this.IDM_GCRE.Name = "IDM_GCRE";
            this.IDM_GCRE.Size = new System.Drawing.Size(205, 22);
            this.IDM_GCRE.Tag = "IDM_GRA";
            this.IDM_GCRE.Text = "&Créditos";
            this.IDM_GCRE.Click += new System.EventHandler(this.IDM_GCRE_Click);
            // 
            // IDM_GANT
            // 
            this.IDM_GANT.Name = "IDM_GANT";
            this.IDM_GANT.Size = new System.Drawing.Size(205, 22);
            this.IDM_GANT.Tag = "IDM_GRA";
            this.IDM_GANT.Text = "A&ntigüedad de la Cuenta";
            this.IDM_GANT.Click += new System.EventHandler(this.IDM_GANT_Click);
            // 
            // IDM_GVEN
            // 
            this.IDM_GVEN.Name = "IDM_GVEN";
            this.IDM_GVEN.Size = new System.Drawing.Size(205, 22);
            this.IDM_GVEN.Tag = "IDM_GRA";
            this.IDM_GVEN.Text = "&Vencidos";
            this.IDM_GVEN.Click += new System.EventHandler(this.IDM_GVEN_Click);
            // 
            // IDM_GCOM
            // 
            this.IDM_GCOM.Name = "IDM_GCOM";
            this.IDM_GCOM.Size = new System.Drawing.Size(205, 22);
            this.IDM_GCOM.Tag = "IDM_GRA";
            this.IDM_GCOM.Text = "Co&mparativos";
            this.IDM_GCOM.Click += new System.EventHandler(this.IDM_GCOM_Click);
            // 
            // IDM_OPC
            // 
            this.IDM_OPC.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_IMP,
            this.IDM_CFG,
            this.IDM_EXC,
            this.IDM_FMT,
            this.IDM_TXT,
            this.IDM_WORD});
            this.IDM_OPC.Name = "IDM_OPC";
            this.IDM_OPC.Size = new System.Drawing.Size(259, 22);
            this.IDM_OPC.Tag = "IDM_CTA";
            this.IDM_OPC.Text = "&Opciones";
            this.IDM_OPC.Click += new System.EventHandler(this.IDM_OPC_Click);
            // 
            // IDM_IMP
            // 
            this.IDM_IMP.Enabled = false;
            this.IDM_IMP.Name = "IDM_IMP";
            this.IDM_IMP.Size = new System.Drawing.Size(196, 22);
            this.IDM_IMP.Tag = "IDM_OPC";
            this.IDM_IMP.Text = "&Imprimir Reporte";
            this.IDM_IMP.Visible = false;
            this.IDM_IMP.Click += new System.EventHandler(this.IDM_IMP_Click);
            // 
            // IDM_CFG
            // 
            this.IDM_CFG.Name = "IDM_CFG";
            this.IDM_CFG.Size = new System.Drawing.Size(196, 22);
            this.IDM_CFG.Tag = "IDM_OPC";
            this.IDM_CFG.Text = "Configurar &Impresora";
            this.IDM_CFG.Click += new System.EventHandler(this.IDM_CFG_Click);
            // 
            // IDM_EXC
            // 
            this.IDM_EXC.Name = "IDM_EXC";
            this.IDM_EXC.Size = new System.Drawing.Size(196, 22);
            this.IDM_EXC.Tag = "IDM_OPC";
            this.IDM_EXC.Text = "Exportar a E&xcel";
            this.IDM_EXC.Click += new System.EventHandler(this.IDM_EXC_Click);
            // 
            // IDM_FMT
            // 
            this.IDM_FMT.Name = "IDM_FMT";
            this.IDM_FMT.Size = new System.Drawing.Size(196, 22);
            this.IDM_FMT.Tag = "IDM_OPC";
            this.IDM_FMT.Text = "Exportar a &Formato Fijo";
            this.IDM_FMT.Click += new System.EventHandler(this.IDM_FMT_Click);
            // 
            // IDM_TXT
            // 
            this.IDM_TXT.Name = "IDM_TXT";
            this.IDM_TXT.Size = new System.Drawing.Size(196, 22);
            this.IDM_TXT.Tag = "IDM_OPC";
            this.IDM_TXT.Text = "Exportar a &Texto";
            this.IDM_TXT.Click += new System.EventHandler(this.IDM_TXT_Click);
            // 
            // IDM_WORD
            // 
            this.IDM_WORD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_WDOM,
            this.IDM_WCRED});
            this.IDM_WORD.Enabled = false;
            this.IDM_WORD.Name = "IDM_WORD";
            this.IDM_WORD.Size = new System.Drawing.Size(196, 22);
            this.IDM_WORD.Tag = "IDM_OPC";
            this.IDM_WORD.Text = "Formato de &Word";
            this.IDM_WORD.Visible = false;
            // 
            // IDM_WDOM
            // 
            this.IDM_WDOM.Name = "IDM_WDOM";
            this.IDM_WDOM.Size = new System.Drawing.Size(125, 22);
            this.IDM_WDOM.Tag = "IDM_WORD";
            this.IDM_WDOM.Text = "Domicilio";
            this.IDM_WDOM.Click += new System.EventHandler(this.IDM_WDOM_Click);
            // 
            // IDM_WCRED
            // 
            this.IDM_WCRED.Name = "IDM_WCRED";
            this.IDM_WCRED.Size = new System.Drawing.Size(125, 22);
            this.IDM_WCRED.Tag = "IDM_WORD";
            this.IDM_WCRED.Text = "Crédito";
            this.IDM_WCRED.Click += new System.EventHandler(this.IDM_WCRED_Click);
            // 
            // IDM_ACL
            // 
            this.IDM_ACL.Enabled = false;
            this.IDM_ACL.Name = "IDM_ACL";
            this.IDM_ACL.Size = new System.Drawing.Size(259, 22);
            this.IDM_ACL.Tag = "IDM_C430";
            this.IDM_ACL.Text = "Emu&lador";
            this.IDM_ACL.Visible = false;
            this.IDM_ACL.Click += new System.EventHandler(this.IDM_ACL_Click);
            // 
            // IDM_CAP
            // 
            this.IDM_CAP.Enabled = false;
            this.IDM_CAP.Name = "IDM_CAP";
            this.IDM_CAP.Size = new System.Drawing.Size(259, 22);
            this.IDM_CAP.Tag = "IDM_ACL";
            this.IDM_CAP.Text = "&Emulador";
            this.IDM_CAP.Visible = false;
            this.IDM_CAP.Click += new System.EventHandler(this.IDM_CAP_Click);
            // 
            // IDM_HIS
            // 
            this.IDM_HIS.Enabled = false;
            this.IDM_HIS.Name = "IDM_HIS";
            this.IDM_HIS.Size = new System.Drawing.Size(259, 22);
            this.IDM_HIS.Tag = "IDM_ACL";
            this.IDM_HIS.Text = "Consulta &Histórica";
            this.IDM_HIS.Visible = false;
            this.IDM_HIS.Click += new System.EventHandler(this.IDM_HIS_Click);
            // 
            // IDM_AVE
            // 
            this.IDM_AVE.Enabled = false;
            this.IDM_AVE.Name = "IDM_AVE";
            this.IDM_AVE.Size = new System.Drawing.Size(259, 22);
            this.IDM_AVE.Tag = "IDM_ACL";
            this.IDM_AVE.Text = "Aclaraciones &Vencidas";
            this.IDM_AVE.Visible = false;
            this.IDM_AVE.Click += new System.EventHandler(this.IDM_AVE_Click);
            // 
            // mnuRptEmpresarial
            // 
            this.mnuRptEmpresarial.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_FTP,
            this.IDM_RPT_TUXEDO});
            this.mnuRptEmpresarial.Name = "mnuRptEmpresarial";
            this.mnuRptEmpresarial.Size = new System.Drawing.Size(259, 22);
            this.mnuRptEmpresarial.Tag = "";
            this.mnuRptEmpresarial.Text = "Reporte Empresarial";
            // 
            // IDM_FTP
            // 
            this.IDM_FTP.Name = "IDM_FTP";
            this.IDM_FTP.Size = new System.Drawing.Size(167, 22);
            this.IDM_FTP.Tag = "";
            this.IDM_FTP.Text = "Descargar via &FTP";
            this.IDM_FTP.Click += new System.EventHandler(this.IDM_FTP_Click);
            // 
            // IDM_RPT_TUXEDO
            // 
            this.IDM_RPT_TUXEDO.Name = "IDM_RPT_TUXEDO";
            this.IDM_RPT_TUXEDO.Size = new System.Drawing.Size(167, 22);
            this.IDM_RPT_TUXEDO.Tag = "";
            this.IDM_RPT_TUXEDO.Text = "Generar en Linea";
            this.IDM_RPT_TUXEDO.Click += new System.EventHandler(this.IDM_RPT_TUXEDO_Click);
            // 
            // IDM_OPE
            // 
            this.IDM_OPE.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_TRR,
            this.IDM_DEP});
            this.IDM_OPE.Enabled = false;
            this.IDM_OPE.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.IDM_OPE.Name = "IDM_OPE";
            this.IDM_OPE.Size = new System.Drawing.Size(69, 20);
            this.IDM_OPE.Tag = "IDM_C430";
            this.IDM_OPE.Text = "&Interfases";
            this.IDM_OPE.Visible = false;
            this.IDM_OPE.Click += new System.EventHandler(this.IDM_OPE_Click);
            // 
            // IDM_TRR
            // 
            this.IDM_TRR.Name = "IDM_TRR";
            this.IDM_TRR.Size = new System.Drawing.Size(207, 22);
            this.IDM_TRR.Tag = "IDM_OPE";
            this.IDM_TRR.Text = "&Transmisión de  Reportes";
            this.IDM_TRR.Click += new System.EventHandler(this.IDM_TRR_Click);
            // 
            // IDM_DEP
            // 
            this.IDM_DEP.Name = "IDM_DEP";
            this.IDM_DEP.Size = new System.Drawing.Size(207, 22);
            this.IDM_DEP.Tag = "IDM_OPE";
            this.IDM_DEP.Text = "&Depuración";
            this.IDM_DEP.Click += new System.EventHandler(this.IDM_DEP_Click);
            // 
            // IDM_AYU
            // 
            this.IDM_AYU.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.IDM_IND,
            this.IDM_BAS,
            this.IDM_UAY,
            this.IDM_GUION4,
            this.IDM_VEN,
            this.IDM_GUION3,
            this.IDM_ACE});
            this.IDM_AYU.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.IDM_AYU.Name = "IDM_AYU";
            this.IDM_AYU.Size = new System.Drawing.Size(53, 20);
            this.IDM_AYU.Tag = "IDM_C430";
            this.IDM_AYU.Text = "Ay&uda";
            this.IDM_AYU.DropDownClosed += new System.EventHandler(this.IDM_AYU_DropDownClosed);
            this.IDM_AYU.DropDownOpening += new System.EventHandler(this.IDM_AYU_DropDownOpening);
            // 
            // IDM_IND
            // 
            this.IDM_IND.Name = "IDM_IND";
            this.IDM_IND.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.IDM_IND.Size = new System.Drawing.Size(191, 22);
            this.IDM_IND.Tag = "IDM_AYU";
            this.IDM_IND.Text = "&Indice";
            this.IDM_IND.Click += new System.EventHandler(this.IDM_IND_Click);
            // 
            // IDM_BAS
            // 
            this.IDM_BAS.Name = "IDM_BAS";
            this.IDM_BAS.Size = new System.Drawing.Size(191, 22);
            this.IDM_BAS.Tag = "IDM_AYU";
            this.IDM_BAS.Text = "&Buscar ayuda sobre...";
            this.IDM_BAS.Click += new System.EventHandler(this.IDM_BAS_Click);
            // 
            // IDM_UAY
            // 
            this.IDM_UAY.Name = "IDM_UAY";
            this.IDM_UAY.Size = new System.Drawing.Size(191, 22);
            this.IDM_UAY.Tag = "IDM_AYU";
            this.IDM_UAY.Text = "&Uso de la Ayuda";
            this.IDM_UAY.Click += new System.EventHandler(this.IDM_UAY_Click);
            // 
            // IDM_GUION4
            // 
            this.IDM_GUION4.Name = "IDM_GUION4";
            this.IDM_GUION4.Size = new System.Drawing.Size(188, 6);
            this.IDM_GUION4.Tag = "IDM_AYU";
            this.IDM_GUION4.Visible = false;
            // 
            // IDM_VEN
            // 
            this.IDM_VEN.AutoToolTip = true;
            this.IDM_VEN.MergeAction = System.Windows.Forms.MergeAction.Remove;
            this.IDM_VEN.Name = "IDM_VEN";
            this.IDM_VEN.Size = new System.Drawing.Size(191, 22);
            this.IDM_VEN.Tag = "IDM_AYU";
            this.IDM_VEN.Text = "&Ventanas Activas";
            // 
            // IDM_GUION3
            // 
            this.IDM_GUION3.Name = "IDM_GUION3";
            this.IDM_GUION3.Size = new System.Drawing.Size(188, 6);
            this.IDM_GUION3.Tag = "IDM_AYU";
            // 
            // IDM_ACE
            // 
            this.IDM_ACE.Name = "IDM_ACE";
            this.IDM_ACE.Size = new System.Drawing.Size(191, 22);
            this.IDM_ACE.Tag = "IDM_AYU";
            this.IDM_ACE.Text = "&Acerca de Corporativa";
            this.IDM_ACE.Click += new System.EventHandler(this.IDM_ACE_Click);
            // 
            // mnuWindowList
            // 
            this.mnuWindowList.Name = "mnuWindowList";
            this.mnuWindowList.Size = new System.Drawing.Size(84, 20);
            this.mnuWindowList.Text = "Window List";
            this.mnuWindowList.Visible = false;
            // 
            // tmrTimer
            // 
            this.tmrTimer.Interval = 1000;
            // 
            // ID_COR_BHER
            // 
            this.ID_COR_BHER.Controls.Add(this._IDT_GPB_5);
            this.ID_COR_BHER.Controls.Add(this._IDT_GPB_3);
            this.ID_COR_BHER.Controls.Add(this._IDT_GPB_7);
            this.ID_COR_BHER.Controls.Add(this._IDT_GPB_6);
            this.ID_COR_BHER.Controls.Add(this._IDT_GPB_1);
            this.ID_COR_BHER.Controls.Add(this._IDT_GPB_0);
            this.ID_COR_BHER.Controls.Add(this._IDT_GPB_4);
            this.ID_COR_BHER.Controls.Add(this._IDT_GPB_2);
            this.ID_COR_BHER.Controls.Add(this.ID_COR_CMD);
            this.ID_COR_BHER.Controls.Add(this.ID_COR_DDE_EB);
            this.ID_COR_BHER.Dock = System.Windows.Forms.DockStyle.Top;
            this.ID_COR_BHER.Location = new System.Drawing.Point(0, 24);
            this.ID_COR_BHER.Name = "ID_COR_BHER";
            this.ID_COR_BHER.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_COR_BHER.OcxState")));
            this.ID_COR_BHER.Size = new System.Drawing.Size(696, 45);
            this.ID_COR_BHER.TabIndex = 2;
            this.ID_COR_BHER.Tag = "";
            this.ID_COR_BHER.Enter += new System.EventHandler(this.ID_COR_BHER_Enter);
            // 
            // _IDT_GPB_5
            // 
            this._IDT_GPB_5.Location = new System.Drawing.Point(328, 3);
            this._IDT_GPB_5.Name = "_IDT_GPB_5";
            this._IDT_GPB_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_IDT_GPB_5.OcxState")));
            this._IDT_GPB_5.Size = new System.Drawing.Size(50, 40);
            this._IDT_GPB_5.TabIndex = 6;
            this._IDT_GPB_5.Tag = "";
            this._IDT_GPB_5.Visible = false;
            this._IDT_GPB_5.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.IDT_GPB_ClickEvent);
            // 
            // _IDT_GPB_3
            // 
            this._IDT_GPB_3.Location = new System.Drawing.Point(278, 3);
            this._IDT_GPB_3.Name = "_IDT_GPB_3";
            this._IDT_GPB_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_IDT_GPB_3.OcxState")));
            this._IDT_GPB_3.Size = new System.Drawing.Size(50, 40);
            this._IDT_GPB_3.TabIndex = 5;
            this._IDT_GPB_3.Tag = "";
            this._IDT_GPB_3.Visible = false;
            this._IDT_GPB_3.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.IDT_GPB_ClickEvent);
            // 
            // _IDT_GPB_7
            // 
            this._IDT_GPB_7.Location = new System.Drawing.Point(579, 2);
            this._IDT_GPB_7.Name = "_IDT_GPB_7";
            this._IDT_GPB_7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_IDT_GPB_7.OcxState")));
            this._IDT_GPB_7.Size = new System.Drawing.Size(50, 40);
            this._IDT_GPB_7.TabIndex = 8;
            this._IDT_GPB_7.Tag = "";
            this._IDT_GPB_7.Visible = false;
            this._IDT_GPB_7.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.IDT_GPB_ClickEvent);
            // 
            // _IDT_GPB_6
            // 
            this._IDT_GPB_6.Location = new System.Drawing.Point(390, 3);
            this._IDT_GPB_6.Name = "_IDT_GPB_6";
            this._IDT_GPB_6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_IDT_GPB_6.OcxState")));
            this._IDT_GPB_6.Size = new System.Drawing.Size(50, 40);
            this._IDT_GPB_6.TabIndex = 7;
            this._IDT_GPB_6.Tag = "";
            this._IDT_GPB_6.Visible = false;
            this._IDT_GPB_6.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.IDT_GPB_ClickEvent);
            // 
            // _IDT_GPB_1
            // 
            this._IDT_GPB_1.Location = new System.Drawing.Point(114, 2);
            this._IDT_GPB_1.Name = "_IDT_GPB_1";
            this._IDT_GPB_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_IDT_GPB_1.OcxState")));
            this._IDT_GPB_1.Size = new System.Drawing.Size(50, 40);
            this._IDT_GPB_1.TabIndex = 1;
            this._IDT_GPB_1.Tag = "";
            this._IDT_GPB_1.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.IDT_GPB_ClickEvent);
            // 
            // _IDT_GPB_0
            // 
            this._IDT_GPB_0.Location = new System.Drawing.Point(64, 2);
            this._IDT_GPB_0.Name = "_IDT_GPB_0";
            this._IDT_GPB_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_IDT_GPB_0.OcxState")));
            this._IDT_GPB_0.Size = new System.Drawing.Size(50, 40);
            this._IDT_GPB_0.TabIndex = 0;
            this._IDT_GPB_0.Tag = "";
            this._IDT_GPB_0.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.IDT_GPB_ClickEvent);
            // 
            // _IDT_GPB_4
            // 
            this._IDT_GPB_4.Location = new System.Drawing.Point(217, 3);
            this._IDT_GPB_4.Name = "_IDT_GPB_4";
            this._IDT_GPB_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_IDT_GPB_4.OcxState")));
            this._IDT_GPB_4.Size = new System.Drawing.Size(50, 40);
            this._IDT_GPB_4.TabIndex = 4;
            this._IDT_GPB_4.Tag = "";
            this._IDT_GPB_4.Visible = false;
            this._IDT_GPB_4.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.IDT_GPB_ClickEvent);
            // 
            // _IDT_GPB_2
            // 
            this._IDT_GPB_2.Location = new System.Drawing.Point(14, 2);
            this._IDT_GPB_2.Name = "_IDT_GPB_2";
            this._IDT_GPB_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_IDT_GPB_2.OcxState")));
            this._IDT_GPB_2.Size = new System.Drawing.Size(50, 40);
            this._IDT_GPB_2.TabIndex = 3;
            this._IDT_GPB_2.Tag = "";
            this._IDT_GPB_2.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.IDT_GPB_ClickEvent);
            // 
            // ID_COR_CMD
            // 
            this.ID_COR_CMD.Enabled = true;
            this.ID_COR_CMD.Location = new System.Drawing.Point(515, 11);
            this.ID_COR_CMD.Name = "ID_COR_CMD";
            this.ID_COR_CMD.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_COR_CMD.OcxState")));
            this.ID_COR_CMD.Size = new System.Drawing.Size(32, 32);
            this.ID_COR_CMD.TabIndex = 9;
            this.ID_COR_CMD.Tag = "";
            // 
            // ID_COR_DDE_EB
            // 
            this.ID_COR_DDE_EB.AcceptsReturn = true;
            this.ID_COR_DDE_EB.BackColor = System.Drawing.Color.White;
            this.ID_COR_DDE_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_COR_DDE_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_COR_DDE_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_COR_DDE_EB.Location = new System.Drawing.Point(441, 3);
            this.ID_COR_DDE_EB.MaxLength = 0;
            this.ID_COR_DDE_EB.Name = "ID_COR_DDE_EB";
            this.ID_COR_DDE_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_COR_DDE_EB.Size = new System.Drawing.Size(49, 20);
            this.ID_COR_DDE_EB.TabIndex = 9;
            this.ID_COR_DDE_EB.Tag = "";
            this.ID_COR_DDE_EB.Visible = false;
            // 
            // ID_COR_BEDO
            // 
            this.ID_COR_BEDO.Controls.Add(this._sspPanel_1);
            this.ID_COR_BEDO.Controls.Add(this._sspPanel_0);
            this.ID_COR_BEDO.Controls.Add(this.ID_COR_MEDO_PNL);
            this.ID_COR_BEDO.Controls.Add(this._sspPanel_2);
            this.ID_COR_BEDO.Controls.Add(this.ID_COR_MSG_TXT);
            this.ID_COR_BEDO.Controls.Add(this.txtEstado);
            this.ID_COR_BEDO.Controls.Add(this.lblNumero);
            this.ID_COR_BEDO.Controls.Add(this.SSPanel1);
            this.ID_COR_BEDO.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ID_COR_BEDO.Location = new System.Drawing.Point(0, 349);
            this.ID_COR_BEDO.Name = "ID_COR_BEDO";
            this.ID_COR_BEDO.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_COR_BEDO.OcxState")));
            this.ID_COR_BEDO.Size = new System.Drawing.Size(696, 22);
            this.ID_COR_BEDO.TabIndex = 10;
            this.ID_COR_BEDO.Tag = "";
            // 
            // _sspPanel_1
            // 
            this._sspPanel_1.Location = new System.Drawing.Point(91, 3);
            this._sspPanel_1.Name = "_sspPanel_1";
            this._sspPanel_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_sspPanel_1.OcxState")));
            this._sspPanel_1.Size = new System.Drawing.Size(72, 18);
            this._sspPanel_1.TabIndex = 17;
            this._sspPanel_1.Tag = "";
            // 
            // _sspPanel_0
            // 
            this._sspPanel_0.Location = new System.Drawing.Point(3, 3);
            this._sspPanel_0.Name = "_sspPanel_0";
            this._sspPanel_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_sspPanel_0.OcxState")));
            this._sspPanel_0.Size = new System.Drawing.Size(84, 18);
            this._sspPanel_0.TabIndex = 16;
            this._sspPanel_0.Tag = "";
            // 
            // ID_COR_MEDO_PNL
            // 
            this.ID_COR_MEDO_PNL.Location = new System.Drawing.Point(226, 3);
            this.ID_COR_MEDO_PNL.Name = "ID_COR_MEDO_PNL";
            this.ID_COR_MEDO_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_COR_MEDO_PNL.OcxState")));
            this.ID_COR_MEDO_PNL.Size = new System.Drawing.Size(186, 18);
            this.ID_COR_MEDO_PNL.TabIndex = 12;
            this.ID_COR_MEDO_PNL.Tag = "";
            // 
            // _sspPanel_2
            // 
            this._sspPanel_2.Location = new System.Drawing.Point(168, 3);
            this._sspPanel_2.Name = "_sspPanel_2";
            this._sspPanel_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_sspPanel_2.OcxState")));
            this._sspPanel_2.Size = new System.Drawing.Size(54, 18);
            this._sspPanel_2.TabIndex = 18;
            this._sspPanel_2.Tag = "";
            // 
            // ID_COR_MSG_TXT
            // 
            this.ID_COR_MSG_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_COR_MSG_TXT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ID_COR_MSG_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_COR_MSG_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_COR_MSG_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_COR_MSG_TXT.ForeColor = System.Drawing.Color.Navy;
            this.ID_COR_MSG_TXT.Location = new System.Drawing.Point(484, 3);
            this.ID_COR_MSG_TXT.Name = "ID_COR_MSG_TXT";
            this.ID_COR_MSG_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_COR_MSG_TXT.Size = new System.Drawing.Size(233, 18);
            this.ID_COR_MSG_TXT.TabIndex = 13;
            this.ID_COR_MSG_TXT.Tag = "";
            // 
            // txtEstado
            // 
            this.txtEstado.BackColor = System.Drawing.SystemColors.Control;
            this.txtEstado.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtEstado.Cursor = System.Windows.Forms.Cursors.Default;
            this.txtEstado.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtEstado.Location = new System.Drawing.Point(721, 3);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtEstado.Size = new System.Drawing.Size(31, 18);
            this.txtEstado.TabIndex = 14;
            this.txtEstado.Tag = "";
            // 
            // lblNumero
            // 
            this.lblNumero.BackColor = System.Drawing.SystemColors.Control;
            this.lblNumero.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblNumero.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblNumero.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNumero.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblNumero.Location = new System.Drawing.Point(756, 4);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblNumero.Size = new System.Drawing.Size(35, 18);
            this.lblNumero.TabIndex = 15;
            this.lblNumero.Tag = "";
            // 
            // SSPanel1
            // 
            this.SSPanel1.Controls.Add(this.SSPanel1Label_Text);
            this.SSPanel1.Location = new System.Drawing.Point(416, 3);
            this.SSPanel1.Name = "SSPanel1";
            this.SSPanel1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SSPanel1.OcxState")));
            this.SSPanel1.Size = new System.Drawing.Size(63, 18);
            this.SSPanel1.TabIndex = 11;
            this.SSPanel1.Tag = "";
            // 
            // SSPanel1Label_Text
            // 
            this.SSPanel1Label_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SSPanel1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SSPanel1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.SSPanel1Label_Text.Location = new System.Drawing.Point(0, 0);
            this.SSPanel1Label_Text.Name = "SSPanel1Label_Text";
            this.SSPanel1Label_Text.Size = new System.Drawing.Size(63, 18);
            this.SSPanel1Label_Text.TabIndex = 0;
            this.SSPanel1Label_Text.Tag = "";
            this.SSPanel1Label_Text.Text = "BANAMEX";
            this.SSPanel1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CORMDIBN
            // 
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(696, 371);
            this.Controls.Add(this.ID_COR_BHER);
            this.Controls.Add(this.MainMenu1);
            this.Controls.Add(this.ID_COR_BEDO);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Location = new System.Drawing.Point(142, 341);
            this.MainMenuStrip = this.MainMenu1;
            this.Name = "CORMDIBN";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Tarjeta Corporativa Banamex";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.CORMDIBN_Closing);
            this.Closed += new System.EventHandler(this.CORMDIBN_Closed);
            this.MainMenu1.ResumeLayout(false);
            this.MainMenu1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_COR_BHER)).EndInit();
            this.ID_COR_BHER.ResumeLayout(false);
            this.ID_COR_BHER.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._IDT_GPB_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_COR_CMD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_COR_BEDO)).EndInit();
            this.ID_COR_BEDO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._sspPanel_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._sspPanel_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_COR_MEDO_PNL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._sspPanel_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSPanel1)).EndInit();
            this.SSPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        void InitializeIDT_GPB()
        {
            this.IDT_GPB[7] = _IDT_GPB_7;
            this.IDT_GPB[6] = _IDT_GPB_6;
            this.IDT_GPB[5] = _IDT_GPB_5;
            this.IDT_GPB[3] = _IDT_GPB_3;
            this.IDT_GPB[4] = _IDT_GPB_4;
            this.IDT_GPB[2] = _IDT_GPB_2;
            this.IDT_GPB[1] = _IDT_GPB_1;
            this.IDT_GPB[0] = _IDT_GPB_0;
        }
        void InitializesspPanel()
        {
            this.sspPanel[0] = _sspPanel_0;
            this.sspPanel[1] = _sspPanel_1;
            this.sspPanel[2] = _sspPanel_2;
        }
        #endregion

        private System.Windows.Forms.ToolStripMenuItem catalogosDeMonedasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuWindowList;
        public System.Windows.Forms.Timer timer1;

    }
}
