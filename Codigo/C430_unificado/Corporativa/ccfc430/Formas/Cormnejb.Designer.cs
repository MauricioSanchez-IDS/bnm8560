using System;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
    partial class CORMNEJB
    {

        #region "Upgrade Support "
        private static CORMNEJB m_vb6FormDefInstance;
        private static bool m_InitializingDefInstance;
        public static CORMNEJB DefInstance
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
        public CORMNEJB()
            : base()
        {
            if (m_vb6FormDefInstance == null)
            {
                if (m_InitializingDefInstance)
                {
                    m_vb6FormDefInstance = this;
                }
                else
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
            InitializeID_MEB_ETT_TXT();
        }
        public static CORMNEJB CreateInstance()
        {
            CORMNEJB theInstance = new CORMNEJB();
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
        public System.Windows.Forms.Button ID_MEB_IMP_PB;
        public System.Windows.Forms.Button ID_MEB_OK_PB;
        public System.Windows.Forms.Button ID_MEB_CAN_PB;
        public System.Windows.Forms.ComboBox ID_MEB_DVR_ITB;
        private System.Windows.Forms.Label _ID_MEB_ETT_TXT_1;
        private System.Windows.Forms.Label _ID_MEB_ETT_TXT_0;
        public System.Windows.Forms.Panel ID_MEB_PPL1;
        public System.Windows.Forms.ComboBox ID_MEB_EDO_EB;
        public System.Windows.Forms.MaskedTextBox ID_MEB_TEL_PIC;
        public System.Windows.Forms.MaskedTextBox ID_MEB_EXT_ITB;
        public System.Windows.Forms.MaskedTextBox ID_MEB_FAX_PIC;
        public System.Windows.Forms.MaskedTextBox ID_MEB_CP_PIC;
        public System.Windows.Forms.TextBox ID_MEB_CIU_EB;
        public System.Windows.Forms.TextBox ID_MEB_POB_EB;
        public System.Windows.Forms.TextBox ID_MEB_COL_EB;
        public System.Windows.Forms.TextBox ID_MEB_DOM_EB;
        public System.Windows.Forms.TextBox ID_MEB_PTO_EB;
        public System.Windows.Forms.TextBox ID_MEB_NOM_EB;
        public System.Windows.Forms.Button ID_MEB_FIR_PB;
        public AxGEARLib.AxGear ID_MEB_FIR_IMM;
        private System.Windows.Forms.Label _ID_MEB_ETT_TXT_10;
        private System.Windows.Forms.Label _ID_MEB_ETT_TXT_9;
        private System.Windows.Forms.Label _ID_MEB_ETT_TXT_11;
        private System.Windows.Forms.Label _ID_MEB_ETT_TXT_7;
        private System.Windows.Forms.Label _ID_MEB_ETT_TXT_2;
        private System.Windows.Forms.Label _ID_MEB_ETT_TXT_3;
        private System.Windows.Forms.Label _ID_MEB_ETT_TXT_5;
        private System.Windows.Forms.Label _ID_MEB_ETT_TXT_4;
        private System.Windows.Forms.Label _ID_MEB_ETT_TXT_8;
        private System.Windows.Forms.Label _ID_MEB_ETT_TXT_6;
        public System.Windows.Forms.Label ID_MEB_PTO_TXT;
        public System.Windows.Forms.Label ID_MEB_FIR_TXT;
        public System.Windows.Forms.Panel ID_MEB_PPL2_PNL;
        public System.Windows.Forms.Label[] ID_MEB_ETT_TXT = new System.Windows.Forms.Label[12];
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORMNEJB));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_MEB_IMP_PB = new System.Windows.Forms.Button();
            this.ID_MEB_OK_PB = new System.Windows.Forms.Button();
            this.ID_MEB_CAN_PB = new System.Windows.Forms.Button();
            this.ID_MEB_PPL1 = new System.Windows.Forms.Panel();
            this.ID_MEB_NOM_PIC = new System.Windows.Forms.MaskedTextBox();
            this.ID_MEB_DVR_ITB = new System.Windows.Forms.ComboBox();
            this._ID_MEB_ETT_TXT_0 = new System.Windows.Forms.Label();
            this._ID_MEB_ETT_TXT_1 = new System.Windows.Forms.Label();
            this.ID_MEB_PPL2_PNL = new System.Windows.Forms.Panel();
            this._ID_MEB_ETT_TXT_9 = new System.Windows.Forms.Label();
            this._ID_MEB_ETT_TXT_7 = new System.Windows.Forms.Label();
            this._ID_MEB_ETT_TXT_11 = new System.Windows.Forms.Label();
            this.ID_MEB_FIR_PB = new System.Windows.Forms.Button();
            this.ID_MEB_NOM_EB = new System.Windows.Forms.TextBox();
            this._ID_MEB_ETT_TXT_10 = new System.Windows.Forms.Label();
            this.ID_MEB_FIR_IMM = new AxGEARLib.AxGear();
            this._ID_MEB_ETT_TXT_2 = new System.Windows.Forms.Label();
            this._ID_MEB_ETT_TXT_6 = new System.Windows.Forms.Label();
            this.ID_MEB_PTO_TXT = new System.Windows.Forms.Label();
            this.ID_MEB_FIR_TXT = new System.Windows.Forms.Label();
            this._ID_MEB_ETT_TXT_8 = new System.Windows.Forms.Label();
            this._ID_MEB_ETT_TXT_3 = new System.Windows.Forms.Label();
            this._ID_MEB_ETT_TXT_5 = new System.Windows.Forms.Label();
            this._ID_MEB_ETT_TXT_4 = new System.Windows.Forms.Label();
            this.ID_MEB_PTO_EB = new System.Windows.Forms.TextBox();
            this.ID_MEB_EXT_ITB = new System.Windows.Forms.MaskedTextBox();
            this.ID_MEB_FAX_PIC = new System.Windows.Forms.MaskedTextBox();
            this.ID_MEB_EDO_EB = new System.Windows.Forms.ComboBox();
            this.ID_MEB_TEL_PIC = new System.Windows.Forms.MaskedTextBox();
            this.ID_MEB_CP_PIC = new System.Windows.Forms.MaskedTextBox();
            this.ID_MEB_COL_EB = new System.Windows.Forms.TextBox();
            this.ID_MEB_DOM_EB = new System.Windows.Forms.TextBox();
            this.ID_MEB_CIU_EB = new System.Windows.Forms.TextBox();
            this.ID_MEB_POB_EB = new System.Windows.Forms.TextBox();
            this.ID_MEB_PPL1.SuspendLayout();
            this.ID_MEB_PPL2_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEB_FIR_IMM)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_MEB_IMP_PB
            // 
            this.ID_MEB_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEB_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEB_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEB_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEB_IMP_PB.Location = new System.Drawing.Point(315, 319);
            this.ID_MEB_IMP_PB.Name = "ID_MEB_IMP_PB";
            this.ID_MEB_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEB_IMP_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEB_IMP_PB.TabIndex = 20;
            this.ID_MEB_IMP_PB.Tag = "";
            this.ID_MEB_IMP_PB.Text = "&Imprimir";
            this.ID_MEB_IMP_PB.UseVisualStyleBackColor = false;
            this.ID_MEB_IMP_PB.Click += new System.EventHandler(this.ID_MEB_IMP_PB_Click);
            // 
            // ID_MEB_OK_PB
            // 
            this.ID_MEB_OK_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEB_OK_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEB_OK_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEB_OK_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_OK_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEB_OK_PB.Location = new System.Drawing.Point(146, 319);
            this.ID_MEB_OK_PB.Name = "ID_MEB_OK_PB";
            this.ID_MEB_OK_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEB_OK_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEB_OK_PB.TabIndex = 18;
            this.ID_MEB_OK_PB.Tag = "";
            this.ID_MEB_OK_PB.Text = "Aceptar";
            this.ID_MEB_OK_PB.UseVisualStyleBackColor = false;
            this.ID_MEB_OK_PB.Click += new System.EventHandler(this.ID_MEB_OK_PB_Click);
            // 
            // ID_MEB_CAN_PB
            // 
            this.ID_MEB_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEB_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEB_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_MEB_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEB_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEB_CAN_PB.Location = new System.Drawing.Point(227, 319);
            this.ID_MEB_CAN_PB.Name = "ID_MEB_CAN_PB";
            this.ID_MEB_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEB_CAN_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEB_CAN_PB.TabIndex = 19;
            this.ID_MEB_CAN_PB.Tag = "";
            this.ID_MEB_CAN_PB.Text = "Cancelar";
            this.ID_MEB_CAN_PB.UseVisualStyleBackColor = false;
            this.ID_MEB_CAN_PB.Click += new System.EventHandler(this.ID_MEB_CP_PIC_Leave);
            // 
            // ID_MEB_PPL1
            // 
            this.ID_MEB_PPL1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ID_MEB_PPL1.Controls.Add(this.ID_MEB_NOM_PIC);
            this.ID_MEB_PPL1.Controls.Add(this.ID_MEB_DVR_ITB);
            this.ID_MEB_PPL1.Controls.Add(this._ID_MEB_ETT_TXT_0);
            this.ID_MEB_PPL1.Controls.Add(this._ID_MEB_ETT_TXT_1);
            this.ID_MEB_PPL1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_PPL1.Location = new System.Drawing.Point(10, 5);
            this.ID_MEB_PPL1.Name = "ID_MEB_PPL1";
            this.ID_MEB_PPL1.Size = new System.Drawing.Size(524, 35);
            this.ID_MEB_PPL1.TabIndex = 0;
            this.ID_MEB_PPL1.Tag = "";
            // 
            // ID_MEB_NOM_PIC
            // 
            this.ID_MEB_NOM_PIC.AllowPromptAsInput = false;
            this.ID_MEB_NOM_PIC.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ID_MEB_NOM_PIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_NOM_PIC.Location = new System.Drawing.Point(104, 8);
            this.ID_MEB_NOM_PIC.Name = "ID_MEB_NOM_PIC";
            this.ID_MEB_NOM_PIC.Size = new System.Drawing.Size(88, 20);
            this.ID_MEB_NOM_PIC.TabIndex = 1;
            this.ID_MEB_NOM_PIC.Tag = "";
            this.ID_MEB_NOM_PIC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEB_NOM_PIC_KeyPress);
            // 
            // ID_MEB_DVR_ITB
            // 
            this.ID_MEB_DVR_ITB.BackColor = System.Drawing.Color.White;
            this.ID_MEB_DVR_ITB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEB_DVR_ITB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_MEB_DVR_ITB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_DVR_ITB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEB_DVR_ITB.Location = new System.Drawing.Point(346, 8);
            this.ID_MEB_DVR_ITB.Name = "ID_MEB_DVR_ITB";
            this.ID_MEB_DVR_ITB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEB_DVR_ITB.Size = new System.Drawing.Size(164, 21);
            this.ID_MEB_DVR_ITB.TabIndex = 2;
            this.ID_MEB_DVR_ITB.Tag = "";
            // 
            // _ID_MEB_ETT_TXT_0
            // 
            this._ID_MEB_ETT_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_MEB_ETT_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEB_ETT_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEB_ETT_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEB_ETT_TXT_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEB_ETT_TXT_0.Location = new System.Drawing.Point(20, 12);
            this._ID_MEB_ETT_TXT_0.Name = "_ID_MEB_ETT_TXT_0";
            this._ID_MEB_ETT_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEB_ETT_TXT_0.Size = new System.Drawing.Size(51, 13);
            this._ID_MEB_ETT_TXT_0.TabIndex = 1;
            this._ID_MEB_ETT_TXT_0.Tag = "";
            this._ID_MEB_ETT_TXT_0.Text = "&Nómina";
            // 
            // _ID_MEB_ETT_TXT_1
            // 
            this._ID_MEB_ETT_TXT_1.BackColor = System.Drawing.Color.Silver;
            this._ID_MEB_ETT_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEB_ETT_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEB_ETT_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEB_ETT_TXT_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEB_ETT_TXT_1.Location = new System.Drawing.Point(237, 12);
            this._ID_MEB_ETT_TXT_1.Name = "_ID_MEB_ETT_TXT_1";
            this._ID_MEB_ETT_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEB_ETT_TXT_1.Size = new System.Drawing.Size(104, 13);
            this._ID_MEB_ETT_TXT_1.TabIndex = 3;
            this._ID_MEB_ETT_TXT_1.Tag = "";
            this._ID_MEB_ETT_TXT_1.Text = "D&ivisión Regional";
            // 
            // ID_MEB_PPL2_PNL
            // 
            this.ID_MEB_PPL2_PNL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ID_MEB_PPL2_PNL.Controls.Add(this._ID_MEB_ETT_TXT_9);
            this.ID_MEB_PPL2_PNL.Controls.Add(this._ID_MEB_ETT_TXT_7);
            this.ID_MEB_PPL2_PNL.Controls.Add(this._ID_MEB_ETT_TXT_11);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_FIR_PB);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_NOM_EB);
            this.ID_MEB_PPL2_PNL.Controls.Add(this._ID_MEB_ETT_TXT_10);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_FIR_IMM);
            this.ID_MEB_PPL2_PNL.Controls.Add(this._ID_MEB_ETT_TXT_2);
            this.ID_MEB_PPL2_PNL.Controls.Add(this._ID_MEB_ETT_TXT_6);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_PTO_TXT);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_FIR_TXT);
            this.ID_MEB_PPL2_PNL.Controls.Add(this._ID_MEB_ETT_TXT_8);
            this.ID_MEB_PPL2_PNL.Controls.Add(this._ID_MEB_ETT_TXT_3);
            this.ID_MEB_PPL2_PNL.Controls.Add(this._ID_MEB_ETT_TXT_5);
            this.ID_MEB_PPL2_PNL.Controls.Add(this._ID_MEB_ETT_TXT_4);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_PTO_EB);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_EXT_ITB);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_FAX_PIC);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_EDO_EB);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_TEL_PIC);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_CP_PIC);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_COL_EB);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_DOM_EB);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_CIU_EB);
            this.ID_MEB_PPL2_PNL.Controls.Add(this.ID_MEB_POB_EB);
            this.ID_MEB_PPL2_PNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_PPL2_PNL.Location = new System.Drawing.Point(10, 49);
            this.ID_MEB_PPL2_PNL.Name = "ID_MEB_PPL2_PNL";
            this.ID_MEB_PPL2_PNL.Size = new System.Drawing.Size(525, 263);
            this.ID_MEB_PPL2_PNL.TabIndex = 3;
            this.ID_MEB_PPL2_PNL.Tag = "";
            // 
            // _ID_MEB_ETT_TXT_9
            // 
            this._ID_MEB_ETT_TXT_9.BackColor = System.Drawing.Color.Silver;
            this._ID_MEB_ETT_TXT_9.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEB_ETT_TXT_9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEB_ETT_TXT_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEB_ETT_TXT_9.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEB_ETT_TXT_9.Location = new System.Drawing.Point(17, 234);
            this._ID_MEB_ETT_TXT_9.Name = "_ID_MEB_ETT_TXT_9";
            this._ID_MEB_ETT_TXT_9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEB_ETT_TXT_9.Size = new System.Drawing.Size(80, 17);
            this._ID_MEB_ETT_TXT_9.TabIndex = 23;
            this._ID_MEB_ETT_TXT_9.Tag = "";
            this._ID_MEB_ETT_TXT_9.Text = "&Teléfono";
            // 
            // _ID_MEB_ETT_TXT_7
            // 
            this._ID_MEB_ETT_TXT_7.BackColor = System.Drawing.Color.Silver;
            this._ID_MEB_ETT_TXT_7.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEB_ETT_TXT_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEB_ETT_TXT_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEB_ETT_TXT_7.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEB_ETT_TXT_7.Location = new System.Drawing.Point(17, 204);
            this._ID_MEB_ETT_TXT_7.Name = "_ID_MEB_ETT_TXT_7";
            this._ID_MEB_ETT_TXT_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEB_ETT_TXT_7.Size = new System.Drawing.Size(80, 19);
            this._ID_MEB_ETT_TXT_7.TabIndex = 19;
            this._ID_MEB_ETT_TXT_7.Tag = "";
            this._ID_MEB_ETT_TXT_7.Text = "&C.P.";
            // 
            // _ID_MEB_ETT_TXT_11
            // 
            this._ID_MEB_ETT_TXT_11.BackColor = System.Drawing.Color.Silver;
            this._ID_MEB_ETT_TXT_11.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEB_ETT_TXT_11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEB_ETT_TXT_11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEB_ETT_TXT_11.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEB_ETT_TXT_11.Location = new System.Drawing.Point(234, 235);
            this._ID_MEB_ETT_TXT_11.Name = "_ID_MEB_ETT_TXT_11";
            this._ID_MEB_ETT_TXT_11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEB_ETT_TXT_11.Size = new System.Drawing.Size(24, 14);
            this._ID_MEB_ETT_TXT_11.TabIndex = 25;
            this._ID_MEB_ETT_TXT_11.Tag = "";
            this._ID_MEB_ETT_TXT_11.Text = "&Fax";
            // 
            // ID_MEB_FIR_PB
            // 
            this.ID_MEB_FIR_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEB_FIR_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEB_FIR_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEB_FIR_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_FIR_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEB_FIR_PB.Location = new System.Drawing.Point(396, 231);
            this.ID_MEB_FIR_PB.Name = "ID_MEB_FIR_PB";
            this.ID_MEB_FIR_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEB_FIR_PB.Size = new System.Drawing.Size(85, 22);
            this.ID_MEB_FIR_PB.TabIndex = 17;
            this.ID_MEB_FIR_PB.Tag = "";
            this.ID_MEB_FIR_PB.Text = "&Firma";
            this.ID_MEB_FIR_PB.UseVisualStyleBackColor = false;
            this.ID_MEB_FIR_PB.Click += new System.EventHandler(this.ID_MEB_FIR_PB_Click);
            // 
            // ID_MEB_NOM_EB
            // 
            this.ID_MEB_NOM_EB.AcceptsReturn = true;
            this.ID_MEB_NOM_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEB_NOM_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEB_NOM_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_NOM_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEB_NOM_EB.Location = new System.Drawing.Point(103, 9);
            this.ID_MEB_NOM_EB.MaxLength = 45;
            this.ID_MEB_NOM_EB.Name = "ID_MEB_NOM_EB";
            this.ID_MEB_NOM_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEB_NOM_EB.Size = new System.Drawing.Size(407, 20);
            this.ID_MEB_NOM_EB.TabIndex = 4;
            this.ID_MEB_NOM_EB.Tag = "";
            this.ID_MEB_NOM_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEB_NOM_EB_KeyPress);
            // 
            // _ID_MEB_ETT_TXT_10
            // 
            this._ID_MEB_ETT_TXT_10.BackColor = System.Drawing.Color.Silver;
            this._ID_MEB_ETT_TXT_10.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEB_ETT_TXT_10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEB_ETT_TXT_10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEB_ETT_TXT_10.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEB_ETT_TXT_10.Location = new System.Drawing.Point(235, 205);
            this._ID_MEB_ETT_TXT_10.Name = "_ID_MEB_ETT_TXT_10";
            this._ID_MEB_ETT_TXT_10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEB_ETT_TXT_10.Size = new System.Drawing.Size(24, 17);
            this._ID_MEB_ETT_TXT_10.TabIndex = 21;
            this._ID_MEB_ETT_TXT_10.Tag = "";
            this._ID_MEB_ETT_TXT_10.Text = "&Ext.";
            // 
            // ID_MEB_FIR_IMM
            // 
            this.ID_MEB_FIR_IMM.Enabled = true;
            this.ID_MEB_FIR_IMM.Location = new System.Drawing.Point(363, 119);
            this.ID_MEB_FIR_IMM.Name = "ID_MEB_FIR_IMM";
            this.ID_MEB_FIR_IMM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEB_FIR_IMM.OcxState")));
            this.ID_MEB_FIR_IMM.Size = new System.Drawing.Size(147, 104);
            this.ID_MEB_FIR_IMM.TabIndex = 16;
            this.ID_MEB_FIR_IMM.Tag = "";
            // 
            // _ID_MEB_ETT_TXT_2
            // 
            this._ID_MEB_ETT_TXT_2.BackColor = System.Drawing.Color.Silver;
            this._ID_MEB_ETT_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEB_ETT_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEB_ETT_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEB_ETT_TXT_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEB_ETT_TXT_2.Location = new System.Drawing.Point(17, 11);
            this._ID_MEB_ETT_TXT_2.Name = "_ID_MEB_ETT_TXT_2";
            this._ID_MEB_ETT_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEB_ETT_TXT_2.Size = new System.Drawing.Size(80, 17);
            this._ID_MEB_ETT_TXT_2.TabIndex = 5;
            this._ID_MEB_ETT_TXT_2.Tag = "";
            this._ID_MEB_ETT_TXT_2.Text = "&Nombre";
            // 
            // _ID_MEB_ETT_TXT_6
            // 
            this._ID_MEB_ETT_TXT_6.BackColor = System.Drawing.Color.Silver;
            this._ID_MEB_ETT_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEB_ETT_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEB_ETT_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEB_ETT_TXT_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEB_ETT_TXT_6.Location = new System.Drawing.Point(17, 148);
            this._ID_MEB_ETT_TXT_6.Name = "_ID_MEB_ETT_TXT_6";
            this._ID_MEB_ETT_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEB_ETT_TXT_6.Size = new System.Drawing.Size(80, 17);
            this._ID_MEB_ETT_TXT_6.TabIndex = 15;
            this._ID_MEB_ETT_TXT_6.Tag = "";
            this._ID_MEB_ETT_TXT_6.Text = "C&iudad";
            // 
            // ID_MEB_PTO_TXT
            // 
            this.ID_MEB_PTO_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_MEB_PTO_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEB_PTO_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEB_PTO_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_PTO_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEB_PTO_TXT.Location = new System.Drawing.Point(17, 38);
            this.ID_MEB_PTO_TXT.Name = "ID_MEB_PTO_TXT";
            this.ID_MEB_PTO_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEB_PTO_TXT.Size = new System.Drawing.Size(80, 17);
            this.ID_MEB_PTO_TXT.TabIndex = 7;
            this.ID_MEB_PTO_TXT.Tag = "";
            this.ID_MEB_PTO_TXT.Text = "P&uesto";
            // 
            // ID_MEB_FIR_TXT
            // 
            this.ID_MEB_FIR_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_MEB_FIR_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEB_FIR_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEB_FIR_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_FIR_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEB_FIR_TXT.Location = new System.Drawing.Point(379, 101);
            this.ID_MEB_FIR_TXT.Name = "ID_MEB_FIR_TXT";
            this.ID_MEB_FIR_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEB_FIR_TXT.Size = new System.Drawing.Size(115, 15);
            this.ID_MEB_FIR_TXT.TabIndex = 27;
            this.ID_MEB_FIR_TXT.Tag = "";
            this.ID_MEB_FIR_TXT.Text = "Firma";
            this.ID_MEB_FIR_TXT.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // _ID_MEB_ETT_TXT_8
            // 
            this._ID_MEB_ETT_TXT_8.BackColor = System.Drawing.Color.Silver;
            this._ID_MEB_ETT_TXT_8.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEB_ETT_TXT_8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEB_ETT_TXT_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEB_ETT_TXT_8.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEB_ETT_TXT_8.Location = new System.Drawing.Point(17, 176);
            this._ID_MEB_ETT_TXT_8.Name = "_ID_MEB_ETT_TXT_8";
            this._ID_MEB_ETT_TXT_8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEB_ETT_TXT_8.Size = new System.Drawing.Size(61, 17);
            this._ID_MEB_ETT_TXT_8.TabIndex = 17;
            this._ID_MEB_ETT_TXT_8.Tag = "";
            this._ID_MEB_ETT_TXT_8.Text = "&Estado";
            // 
            // _ID_MEB_ETT_TXT_3
            // 
            this._ID_MEB_ETT_TXT_3.BackColor = System.Drawing.Color.Silver;
            this._ID_MEB_ETT_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEB_ETT_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEB_ETT_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEB_ETT_TXT_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEB_ETT_TXT_3.Location = new System.Drawing.Point(17, 67);
            this._ID_MEB_ETT_TXT_3.Name = "_ID_MEB_ETT_TXT_3";
            this._ID_MEB_ETT_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEB_ETT_TXT_3.Size = new System.Drawing.Size(161, 15);
            this._ID_MEB_ETT_TXT_3.TabIndex = 9;
            this._ID_MEB_ETT_TXT_3.Tag = "";
            this._ID_MEB_ETT_TXT_3.Text = "Domicilio ( &Calle y Número )";
            // 
            // _ID_MEB_ETT_TXT_5
            // 
            this._ID_MEB_ETT_TXT_5.BackColor = System.Drawing.Color.Silver;
            this._ID_MEB_ETT_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEB_ETT_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEB_ETT_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEB_ETT_TXT_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEB_ETT_TXT_5.Location = new System.Drawing.Point(17, 122);
            this._ID_MEB_ETT_TXT_5.Name = "_ID_MEB_ETT_TXT_5";
            this._ID_MEB_ETT_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEB_ETT_TXT_5.Size = new System.Drawing.Size(80, 15);
            this._ID_MEB_ETT_TXT_5.TabIndex = 13;
            this._ID_MEB_ETT_TXT_5.Tag = "";
            this._ID_MEB_ETT_TXT_5.Text = "&Pob/Del/Mun";
            // 
            // _ID_MEB_ETT_TXT_4
            // 
            this._ID_MEB_ETT_TXT_4.BackColor = System.Drawing.Color.Silver;
            this._ID_MEB_ETT_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEB_ETT_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEB_ETT_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEB_ETT_TXT_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEB_ETT_TXT_4.Location = new System.Drawing.Point(17, 94);
            this._ID_MEB_ETT_TXT_4.Name = "_ID_MEB_ETT_TXT_4";
            this._ID_MEB_ETT_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEB_ETT_TXT_4.Size = new System.Drawing.Size(80, 15);
            this._ID_MEB_ETT_TXT_4.TabIndex = 11;
            this._ID_MEB_ETT_TXT_4.Tag = "";
            this._ID_MEB_ETT_TXT_4.Text = "&Colonia";
            // 
            // ID_MEB_PTO_EB
            // 
            this.ID_MEB_PTO_EB.AcceptsReturn = true;
            this.ID_MEB_PTO_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEB_PTO_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEB_PTO_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_PTO_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEB_PTO_EB.Location = new System.Drawing.Point(103, 37);
            this.ID_MEB_PTO_EB.MaxLength = 15;
            this.ID_MEB_PTO_EB.Name = "ID_MEB_PTO_EB";
            this.ID_MEB_PTO_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEB_PTO_EB.Size = new System.Drawing.Size(237, 20);
            this.ID_MEB_PTO_EB.TabIndex = 5;
            this.ID_MEB_PTO_EB.Tag = "";
            this.ID_MEB_PTO_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEB_PTO_EB_KeyPress);
            // 
            // ID_MEB_EXT_ITB
            // 
            this.ID_MEB_EXT_ITB.AllowPromptAsInput = false;
            this.ID_MEB_EXT_ITB.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ID_MEB_EXT_ITB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_EXT_ITB.Location = new System.Drawing.Point(264, 203);
            this.ID_MEB_EXT_ITB.Name = "ID_MEB_EXT_ITB";
            this.ID_MEB_EXT_ITB.Size = new System.Drawing.Size(76, 20);
            this.ID_MEB_EXT_ITB.TabIndex = 13;
            this.ID_MEB_EXT_ITB.Tag = "";
            this.ID_MEB_EXT_ITB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEB_EXT_ITB_KeyPress);
            // 
            // ID_MEB_FAX_PIC
            // 
            this.ID_MEB_FAX_PIC.AllowPromptAsInput = false;
            this.ID_MEB_FAX_PIC.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ID_MEB_FAX_PIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_FAX_PIC.Location = new System.Drawing.Point(264, 232);
            this.ID_MEB_FAX_PIC.Name = "ID_MEB_FAX_PIC";
            this.ID_MEB_FAX_PIC.Size = new System.Drawing.Size(76, 20);
            this.ID_MEB_FAX_PIC.TabIndex = 15;
            this.ID_MEB_FAX_PIC.Tag = "";
            this.ID_MEB_FAX_PIC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEB_FAX_PIC_KeyPress);
            // 
            // ID_MEB_EDO_EB
            // 
            this.ID_MEB_EDO_EB.BackColor = System.Drawing.SystemColors.Window;
            this.ID_MEB_EDO_EB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEB_EDO_EB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_MEB_EDO_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_EDO_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEB_EDO_EB.Location = new System.Drawing.Point(103, 174);
            this.ID_MEB_EDO_EB.Name = "ID_MEB_EDO_EB";
            this.ID_MEB_EDO_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEB_EDO_EB.Size = new System.Drawing.Size(237, 21);
            this.ID_MEB_EDO_EB.TabIndex = 11;
            this.ID_MEB_EDO_EB.Tag = "";
            // 
            // ID_MEB_TEL_PIC
            // 
            this.ID_MEB_TEL_PIC.AllowPromptAsInput = false;
            this.ID_MEB_TEL_PIC.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ID_MEB_TEL_PIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_TEL_PIC.Location = new System.Drawing.Point(103, 231);
            this.ID_MEB_TEL_PIC.Name = "ID_MEB_TEL_PIC";
            this.ID_MEB_TEL_PIC.Size = new System.Drawing.Size(78, 20);
            this.ID_MEB_TEL_PIC.TabIndex = 14;
            this.ID_MEB_TEL_PIC.Tag = "";
            this.ID_MEB_TEL_PIC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEB_TEL_PIC_KeyPress);
            // 
            // ID_MEB_CP_PIC
            // 
            this.ID_MEB_CP_PIC.AllowPromptAsInput = false;
            this.ID_MEB_CP_PIC.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ID_MEB_CP_PIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_CP_PIC.Location = new System.Drawing.Point(103, 203);
            this.ID_MEB_CP_PIC.Name = "ID_MEB_CP_PIC";
            this.ID_MEB_CP_PIC.Size = new System.Drawing.Size(78, 20);
            this.ID_MEB_CP_PIC.TabIndex = 12;
            this.ID_MEB_CP_PIC.Tag = "";
            this.ID_MEB_CP_PIC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEB_CP_PIC_KeyPress);
            // 
            // ID_MEB_COL_EB
            // 
            this.ID_MEB_COL_EB.AcceptsReturn = true;
            this.ID_MEB_COL_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEB_COL_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEB_COL_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_COL_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEB_COL_EB.Location = new System.Drawing.Point(103, 92);
            this.ID_MEB_COL_EB.MaxLength = 25;
            this.ID_MEB_COL_EB.Name = "ID_MEB_COL_EB";
            this.ID_MEB_COL_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEB_COL_EB.Size = new System.Drawing.Size(237, 20);
            this.ID_MEB_COL_EB.TabIndex = 8;
            this.ID_MEB_COL_EB.Tag = "";
            this.ID_MEB_COL_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEB_COL_EB_KeyPress);
            // 
            // ID_MEB_DOM_EB
            // 
            this.ID_MEB_DOM_EB.AcceptsReturn = true;
            this.ID_MEB_DOM_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEB_DOM_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEB_DOM_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_DOM_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEB_DOM_EB.Location = new System.Drawing.Point(182, 64);
            this.ID_MEB_DOM_EB.MaxLength = 35;
            this.ID_MEB_DOM_EB.Name = "ID_MEB_DOM_EB";
            this.ID_MEB_DOM_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEB_DOM_EB.Size = new System.Drawing.Size(328, 20);
            this.ID_MEB_DOM_EB.TabIndex = 7;
            this.ID_MEB_DOM_EB.Tag = "";
            this.ID_MEB_DOM_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEB_DOM_EB_KeyPress);
            // 
            // ID_MEB_CIU_EB
            // 
            this.ID_MEB_CIU_EB.AcceptsReturn = true;
            this.ID_MEB_CIU_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEB_CIU_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEB_CIU_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_CIU_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEB_CIU_EB.Location = new System.Drawing.Point(103, 147);
            this.ID_MEB_CIU_EB.MaxLength = 25;
            this.ID_MEB_CIU_EB.Name = "ID_MEB_CIU_EB";
            this.ID_MEB_CIU_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEB_CIU_EB.Size = new System.Drawing.Size(237, 20);
            this.ID_MEB_CIU_EB.TabIndex = 10;
            this.ID_MEB_CIU_EB.Tag = "";
            this.ID_MEB_CIU_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEB_CIU_EB_KeyPress);
            // 
            // ID_MEB_POB_EB
            // 
            this.ID_MEB_POB_EB.AcceptsReturn = true;
            this.ID_MEB_POB_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEB_POB_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEB_POB_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEB_POB_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEB_POB_EB.Location = new System.Drawing.Point(103, 119);
            this.ID_MEB_POB_EB.MaxLength = 25;
            this.ID_MEB_POB_EB.Name = "ID_MEB_POB_EB";
            this.ID_MEB_POB_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEB_POB_EB.Size = new System.Drawing.Size(237, 20);
            this.ID_MEB_POB_EB.TabIndex = 9;
            this.ID_MEB_POB_EB.Tag = "";
            this.ID_MEB_POB_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEB_POB_EB_KeyPress);
            // 
            // CORMNEJB
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.ID_MEB_CAN_PB;
            this.ClientSize = new System.Drawing.Size(544, 345);
            this.Controls.Add(this.ID_MEB_IMP_PB);
            this.Controls.Add(this.ID_MEB_PPL1);
            this.Controls.Add(this.ID_MEB_PPL2_PNL);
            this.Controls.Add(this.ID_MEB_CAN_PB);
            this.Controls.Add(this.ID_MEB_OK_PB);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(130, 126);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORMNEJB";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Ejecutivos Banamex";
            this.Activated += new System.EventHandler(this.CORMNEJB_Activated);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORMNEJB_KeyPress);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CORMNEJB_FormClosing);
            this.ID_MEB_PPL1.ResumeLayout(false);
            this.ID_MEB_PPL1.PerformLayout();
            this.ID_MEB_PPL2_PNL.ResumeLayout(false);
            this.ID_MEB_PPL2_PNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEB_FIR_IMM)).EndInit();
            this.ResumeLayout(false);

        }
        void InitializeID_MEB_ETT_TXT()
        {
            this.ID_MEB_ETT_TXT[1] = _ID_MEB_ETT_TXT_1;
            this.ID_MEB_ETT_TXT[0] = _ID_MEB_ETT_TXT_0;
            this.ID_MEB_ETT_TXT[10] = _ID_MEB_ETT_TXT_10;
            this.ID_MEB_ETT_TXT[9] = _ID_MEB_ETT_TXT_9;
            this.ID_MEB_ETT_TXT[11] = _ID_MEB_ETT_TXT_11;
            this.ID_MEB_ETT_TXT[7] = _ID_MEB_ETT_TXT_7;
            this.ID_MEB_ETT_TXT[2] = _ID_MEB_ETT_TXT_2;
            this.ID_MEB_ETT_TXT[3] = _ID_MEB_ETT_TXT_3;
            this.ID_MEB_ETT_TXT[5] = _ID_MEB_ETT_TXT_5;
            this.ID_MEB_ETT_TXT[4] = _ID_MEB_ETT_TXT_4;
            this.ID_MEB_ETT_TXT[8] = _ID_MEB_ETT_TXT_8;
            this.ID_MEB_ETT_TXT[6] = _ID_MEB_ETT_TXT_6;
        }
        #endregion

        public System.Windows.Forms.MaskedTextBox ID_MEB_NOM_PIC;
    }
}