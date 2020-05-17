using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORMNPAR
	{
	
#region "Upgrade Support "
		private static CORMNPAR m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORMNPAR DefInstance
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
		public CORMNPAR():base(){
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
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORMNPAR CreateInstance()
	{
			CORMNPAR theInstance = new CORMNPAR();
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
        protected override void Dispose(bool Disposing)
        {
            if (Disposing)
            {
                if (components != null)
                {
                    try
                    {
                        components.Dispose();
                    }
                    catch (Exception e) { }
                }
            }
            base.Dispose(Disposing);
        }
	//Required by the Windows Form Designer
	private System.ComponentModel.IContainer components;
	public System.Windows.Forms.ToolTip ToolTip1;
	public  AxMSMask.AxMaskEdBox ID_PAR_LEM_EB;
	public  AxMSMask.AxMaskEdBox ID_PAR_LEJ_EB;
	public  System.Windows.Forms.Label Label10;
        public System.Windows.Forms.Label Label9;
        public System.Windows.Forms.Panel SSPanel2;
	//public  AxThreed.AxSSPanel SSPanel2;
	public  AxMSMask.AxMaskEdBox ID_PAR_VER_EB;
	public  System.Windows.Forms.TextBox ID_PAR_EMP_EB;
	public  System.Windows.Forms.Button ID_PAR_CAN_PB;
	public  System.Windows.Forms.Button ID_PAR_ACE_PB;
	public  AxMSMask.AxMaskEdBox ID_PAR_DIA_EB;
	public  System.Windows.Forms.ComboBox ID_PAR_MES_COB;
	public  System.Windows.Forms.ComboBox ID_PAR_INC_COB;
	public  System.Windows.Forms.Label ID_PAR_MES_TXT;
	public  System.Windows.Forms.Label ID_PAR_DIA_TXT;
        public System.Windows.Forms.Label ID_PAR_INC_TXT;
	//public  AxThreed.AxSSPanel ID_PAR_PAR_PNL;
        public System.Windows.Forms.Panel ID_PAR_PAR_PNL;
	public  System.Windows.Forms.Button Fsw_Bco_Baja;
	public  System.Windows.Forms.Button FSW_Bco_Alta;
	public  AxMSMask.AxMaskEdBox ID_PAR_NUM_EB;
	public  AxMSMask.AxMaskEdBox ID_PAR_PRE_EB;
	public  AxMSMask.AxMaskEdBox ID_PAR_GRU_EB;
	public  AxMSMask.AxMaskEdBox ID_PAR_CON_EB;
	public  System.Windows.Forms.ComboBox ID_PAR_NOM_COB;
	public  System.Windows.Forms.Label ID_PAR_NOM_TXT;
	public  System.Windows.Forms.Label ID_PAR_NUM_TXT;
	public  System.Windows.Forms.Label ID_PAR_GRU_TXT;
	public  System.Windows.Forms.Label ID_PAR_PRE_TXT;
        public System.Windows.Forms.Label ID_PAR_CON_TXT;
        public System.Windows.Forms.Panel ID_PAR_BAN_PNL;
	//public  AxThreed.AxSSPanel ID_PAR_BAN_PNL;
	public  System.Windows.Forms.ComboBox ID_PAR_COM_TRA_COB;
	public  System.Windows.Forms.TextBox ID_PAR_INTER_TXT;
	public  System.Windows.Forms.TextBox ID_PAR_EMAIL_TXT;
	public  System.Windows.Forms.TextBox ID_PAR_TEL_EXT_TXT;
	public  System.Windows.Forms.TextBox ID_PAR_FAX_LADA_TXT;
	public  System.Windows.Forms.TextBox ID_PAR_FAX_TXT;
	public  System.Windows.Forms.TextBox ID_PAR_LADA_TXT;
	public  System.Windows.Forms.TextBox ID_PAR_TEL_TXT;
	public  AxThreed.AxSSOption ID_PAR_COM4_OB;
	public  AxThreed.AxSSOption ID_PAR_COM3_OB;
	public  AxThreed.AxSSOption ID_PAR_COM2_OB;
	public  AxThreed.AxSSOption ID_PAR_COM1_OB;
	public  AxThreed.AxSSFrame ID_PAR_COM_TRA_FR;
	public  System.Windows.Forms.Label Label8;
	public  System.Windows.Forms.Label Label7;
	public  System.Windows.Forms.Label Label6;
	public  System.Windows.Forms.Label Label5;
	public  System.Windows.Forms.Label Label4;
	public  System.Windows.Forms.Label Label3;
	public  System.Windows.Forms.Label Label2;
	public  System.Windows.Forms.Label Label1;
        public System.Windows.Forms.Panel SSPanel1;
	//public  AxThreed.AxSSPanel SSPanel1;
	public  System.Windows.Forms.Label ID_PAR_VER_TXT;
	public  System.Windows.Forms.Label ID_PAR_EMP_TXT;
        public System.Windows.Forms.Panel ID_PAR_PRI_PNL;
        // AxThreed.AxSSPanel ID_PAR_PRI_PNL;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORMNPAR));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_PAR_PRI_PNL = new System.Windows.Forms.Panel();
            this.ID_PAR_PAR_PNL = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.ID_PAR_MES_COB = new System.Windows.Forms.ComboBox();
            this.ID_PAR_MES_TXT = new System.Windows.Forms.Label();
            this.ID_PAR_DIA_EB = new AxMSMask.AxMaskEdBox();
            this.ID_PAR_INC_COB = new System.Windows.Forms.ComboBox();
            this.ID_PAR_INC_TXT = new System.Windows.Forms.Label();
            this.ID_PAR_DIA_TXT = new System.Windows.Forms.Label();
            this.ID_PAR_EMP_EB = new System.Windows.Forms.TextBox();
            this.ID_PAR_VER_TXT = new System.Windows.Forms.Label();
            this.ID_PAR_EMP_TXT = new System.Windows.Forms.Label();
            this.ID_PAR_BAN_PNL = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.ID_PAR_NOM_COB = new System.Windows.Forms.ComboBox();
            this.ID_PAR_NOM_TXT = new System.Windows.Forms.Label();
            this.ID_PAR_GRU_EB = new AxMSMask.AxMaskEdBox();
            this.ID_PAR_CON_EB = new AxMSMask.AxMaskEdBox();
            this.ID_PAR_NUM_TXT = new System.Windows.Forms.Label();
            this.ID_PAR_CON_TXT = new System.Windows.Forms.Label();
            this.ID_PAR_GRU_TXT = new System.Windows.Forms.Label();
            this.ID_PAR_PRE_TXT = new System.Windows.Forms.Label();
            this.ID_PAR_PRE_EB = new AxMSMask.AxMaskEdBox();
            this.ID_PAR_NUM_EB = new AxMSMask.AxMaskEdBox();
            this.SSPanel1 = new System.Windows.Forms.Panel();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.ID_PAR_COM_TRA_FR = new AxThreed.AxSSFrame();
            this.ID_PAR_COM3_OB = new AxThreed.AxSSOption();
            this.ID_PAR_COM4_OB = new AxThreed.AxSSOption();
            this.ID_PAR_COM1_OB = new AxThreed.AxSSOption();
            this.ID_PAR_COM2_OB = new AxThreed.AxSSOption();
            this.ID_PAR_LADA_TXT = new System.Windows.Forms.TextBox();
            this.ID_PAR_TEL_TXT = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.ID_PAR_FAX_TXT = new System.Windows.Forms.TextBox();
            this.ID_PAR_INTER_TXT = new System.Windows.Forms.TextBox();
            this.ID_PAR_COM_TRA_COB = new System.Windows.Forms.ComboBox();
            this.ID_PAR_EMAIL_TXT = new System.Windows.Forms.TextBox();
            this.ID_PAR_FAX_LADA_TXT = new System.Windows.Forms.TextBox();
            this.ID_PAR_TEL_EXT_TXT = new System.Windows.Forms.TextBox();
            this.SSPanel2 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.ID_PAR_LEJ_EB = new AxMSMask.AxMaskEdBox();
            this.ID_PAR_LEM_EB = new AxMSMask.AxMaskEdBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.ID_PAR_VER_EB = new AxMSMask.AxMaskEdBox();
            this.ID_PAR_ACE_PB = new System.Windows.Forms.Button();
            this.ID_PAR_CAN_PB = new System.Windows.Forms.Button();
            this.Fsw_Bco_Baja = new System.Windows.Forms.Button();
            this.FSW_Bco_Alta = new System.Windows.Forms.Button();
            this.ID_PAR_PRI_PNL.SuspendLayout();
            this.ID_PAR_PAR_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_DIA_EB)).BeginInit();
            this.ID_PAR_BAN_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_GRU_EB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_CON_EB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_PRE_EB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_NUM_EB)).BeginInit();
            this.SSPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_COM_TRA_FR)).BeginInit();
            this.ID_PAR_COM_TRA_FR.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_COM3_OB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_COM4_OB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_COM1_OB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_COM2_OB)).BeginInit();
            this.SSPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_LEJ_EB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_LEM_EB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_VER_EB)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_PAR_PRI_PNL
            // 
            this.ID_PAR_PRI_PNL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_PAR_PRI_PNL.Controls.Add(this.ID_PAR_PAR_PNL);
            this.ID_PAR_PRI_PNL.Controls.Add(this.ID_PAR_EMP_EB);
            this.ID_PAR_PRI_PNL.Controls.Add(this.ID_PAR_VER_TXT);
            this.ID_PAR_PRI_PNL.Controls.Add(this.ID_PAR_EMP_TXT);
            this.ID_PAR_PRI_PNL.Controls.Add(this.ID_PAR_BAN_PNL);
            this.ID_PAR_PRI_PNL.Controls.Add(this.SSPanel1);
            this.ID_PAR_PRI_PNL.Controls.Add(this.SSPanel2);
            this.ID_PAR_PRI_PNL.Controls.Add(this.ID_PAR_VER_EB);
            this.ID_PAR_PRI_PNL.Location = new System.Drawing.Point(0, 0);
            this.ID_PAR_PRI_PNL.Name = "ID_PAR_PRI_PNL";
            this.ID_PAR_PRI_PNL.Size = new System.Drawing.Size(614, 395);
            this.ID_PAR_PRI_PNL.TabIndex = 0;
            this.ID_PAR_PRI_PNL.Tag = "";
            // 
            // ID_PAR_PAR_PNL
            // 
            this.ID_PAR_PAR_PNL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_PAR_PAR_PNL.Controls.Add(this.label11);
            this.ID_PAR_PAR_PNL.Controls.Add(this.ID_PAR_MES_COB);
            this.ID_PAR_PAR_PNL.Controls.Add(this.ID_PAR_MES_TXT);
            this.ID_PAR_PAR_PNL.Controls.Add(this.ID_PAR_DIA_EB);
            this.ID_PAR_PAR_PNL.Controls.Add(this.ID_PAR_INC_COB);
            this.ID_PAR_PAR_PNL.Controls.Add(this.ID_PAR_INC_TXT);
            this.ID_PAR_PAR_PNL.Controls.Add(this.ID_PAR_DIA_TXT);
            this.ID_PAR_PAR_PNL.Location = new System.Drawing.Point(16, 49);
            this.ID_PAR_PAR_PNL.Name = "ID_PAR_PAR_PNL";
            this.ID_PAR_PAR_PNL.Size = new System.Drawing.Size(239, 122);
            this.ID_PAR_PAR_PNL.TabIndex = 2;
            this.ID_PAR_PAR_PNL.Tag = "";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(78, 3);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(70, 13);
            this.label11.TabIndex = 34;
            this.label11.Text = "Parámetros";
            // 
            // ID_PAR_MES_COB
            // 
            this.ID_PAR_MES_COB.BackColor = System.Drawing.Color.White;
            this.ID_PAR_MES_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_MES_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_PAR_MES_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_MES_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_PAR_MES_COB.Location = new System.Drawing.Point(121, 25);
            this.ID_PAR_MES_COB.Name = "ID_PAR_MES_COB";
            this.ID_PAR_MES_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_MES_COB.Size = new System.Drawing.Size(95, 21);
            this.ID_PAR_MES_COB.TabIndex = 1;
            this.ID_PAR_MES_COB.Tag = "";
            // 
            // ID_PAR_MES_TXT
            // 
            this.ID_PAR_MES_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_PAR_MES_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_MES_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_PAR_MES_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_MES_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_PAR_MES_TXT.Location = new System.Drawing.Point(11, 29);
            this.ID_PAR_MES_TXT.Name = "ID_PAR_MES_TXT";
            this.ID_PAR_MES_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_MES_TXT.Size = new System.Drawing.Size(109, 17);
            this.ID_PAR_MES_TXT.TabIndex = 33;
            this.ID_PAR_MES_TXT.Tag = "";
            this.ID_PAR_MES_TXT.Text = "&Mes de Operación";
            // 
            // ID_PAR_DIA_EB
            // 
            this.ID_PAR_DIA_EB.Location = new System.Drawing.Point(121, 60);
            this.ID_PAR_DIA_EB.Name = "ID_PAR_DIA_EB";
            this.ID_PAR_DIA_EB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PAR_DIA_EB.OcxState")));
            this.ID_PAR_DIA_EB.Size = new System.Drawing.Size(63, 22);
            this.ID_PAR_DIA_EB.TabIndex = 2;
            this.ID_PAR_DIA_EB.Tag = "";
            this.ID_PAR_DIA_EB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_PAR_DIA_EB_KeyPressEvent);
            // 
            // ID_PAR_INC_COB
            // 
            this.ID_PAR_INC_COB.BackColor = System.Drawing.Color.White;
            this.ID_PAR_INC_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_INC_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_PAR_INC_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_INC_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_PAR_INC_COB.Location = new System.Drawing.Point(121, 90);
            this.ID_PAR_INC_COB.Name = "ID_PAR_INC_COB";
            this.ID_PAR_INC_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_INC_COB.Size = new System.Drawing.Size(65, 21);
            this.ID_PAR_INC_COB.TabIndex = 3;
            this.ID_PAR_INC_COB.Tag = "";
            this.ID_PAR_INC_COB.SelectedIndexChanged += new System.EventHandler(this.ID_PAR_INC_COB_SelectedIndexChanged);
            this.ID_PAR_INC_COB.TextChanged += new System.EventHandler(this.ID_PAR_INC_COB_TextChanged);
            // 
            // ID_PAR_INC_TXT
            // 
            this.ID_PAR_INC_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_PAR_INC_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_INC_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_PAR_INC_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_INC_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_PAR_INC_TXT.Location = new System.Drawing.Point(12, 100);
            this.ID_PAR_INC_TXT.Name = "ID_PAR_INC_TXT";
            this.ID_PAR_INC_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_INC_TXT.Size = new System.Drawing.Size(70, 17);
            this.ID_PAR_INC_TXT.TabIndex = 31;
            this.ID_PAR_INC_TXT.Tag = "";
            this.ID_PAR_INC_TXT.Text = "&Incremento";
            // 
            // ID_PAR_DIA_TXT
            // 
            this.ID_PAR_DIA_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_PAR_DIA_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_DIA_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_PAR_DIA_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_DIA_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_PAR_DIA_TXT.Location = new System.Drawing.Point(11, 65);
            this.ID_PAR_DIA_TXT.Name = "ID_PAR_DIA_TXT";
            this.ID_PAR_DIA_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_DIA_TXT.Size = new System.Drawing.Size(75, 17);
            this.ID_PAR_DIA_TXT.TabIndex = 32;
            this.ID_PAR_DIA_TXT.Tag = "";
            this.ID_PAR_DIA_TXT.Text = "&Día de Corte";
            // 
            // ID_PAR_EMP_EB
            // 
            this.ID_PAR_EMP_EB.AcceptsReturn = true;
            this.ID_PAR_EMP_EB.BackColor = System.Drawing.Color.White;
            this.ID_PAR_EMP_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_PAR_EMP_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_EMP_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_PAR_EMP_EB.Location = new System.Drawing.Point(134, 18);
            this.ID_PAR_EMP_EB.MaxLength = 50;
            this.ID_PAR_EMP_EB.Name = "ID_PAR_EMP_EB";
            this.ID_PAR_EMP_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_EMP_EB.Size = new System.Drawing.Size(291, 20);
            this.ID_PAR_EMP_EB.TabIndex = 0;
            this.ID_PAR_EMP_EB.Tag = "";
            this.ID_PAR_EMP_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_PAR_EMP_EB_KeyPress);
            // 
            // ID_PAR_VER_TXT
            // 
            this.ID_PAR_VER_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_PAR_VER_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_VER_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_PAR_VER_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_VER_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_PAR_VER_TXT.Location = new System.Drawing.Point(477, 261);
            this.ID_PAR_VER_TXT.Name = "ID_PAR_VER_TXT";
            this.ID_PAR_VER_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_VER_TXT.Size = new System.Drawing.Size(47, 17);
            this.ID_PAR_VER_TXT.TabIndex = 40;
            this.ID_PAR_VER_TXT.Tag = "";
            this.ID_PAR_VER_TXT.Text = "&Versión";
            // 
            // ID_PAR_EMP_TXT
            // 
            this.ID_PAR_EMP_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_PAR_EMP_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_EMP_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_PAR_EMP_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_EMP_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_PAR_EMP_TXT.Location = new System.Drawing.Point(75, 20);
            this.ID_PAR_EMP_TXT.Name = "ID_PAR_EMP_TXT";
            this.ID_PAR_EMP_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_EMP_TXT.Size = new System.Drawing.Size(51, 17);
            this.ID_PAR_EMP_TXT.TabIndex = 29;
            this.ID_PAR_EMP_TXT.Tag = "";
            this.ID_PAR_EMP_TXT.Text = "&Empresa";
            // 
            // ID_PAR_BAN_PNL
            // 
            this.ID_PAR_BAN_PNL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_PAR_BAN_PNL.Controls.Add(this.label12);
            this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_NOM_COB);
            this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_NOM_TXT);
            this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_GRU_EB);
            this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_CON_EB);
            this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_NUM_TXT);
            this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_CON_TXT);
            this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_GRU_TXT);
            this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_PRE_TXT);
            this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_PRE_EB);
            this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_NUM_EB);
            this.ID_PAR_BAN_PNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_BAN_PNL.Location = new System.Drawing.Point(267, 49);
            this.ID_PAR_BAN_PNL.Name = "ID_PAR_BAN_PNL";
            this.ID_PAR_BAN_PNL.Size = new System.Drawing.Size(335, 122);
            this.ID_PAR_BAN_PNL.TabIndex = 6;
            this.ID_PAR_BAN_PNL.Tag = "";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(125, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Bancos";
            // 
            // ID_PAR_NOM_COB
            // 
            this.ID_PAR_NOM_COB.BackColor = System.Drawing.Color.White;
            this.ID_PAR_NOM_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_NOM_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_NOM_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_PAR_NOM_COB.Location = new System.Drawing.Point(61, 19);
            this.ID_PAR_NOM_COB.Name = "ID_PAR_NOM_COB";
            this.ID_PAR_NOM_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_NOM_COB.Size = new System.Drawing.Size(170, 21);
            this.ID_PAR_NOM_COB.TabIndex = 4;
            this.ID_PAR_NOM_COB.Tag = "";
            this.ID_PAR_NOM_COB.Text = "ID_PAR_NOM_COB";
            this.ID_PAR_NOM_COB.DropDown += new System.EventHandler(this.ID_PAR_NOM_COB_DropDown);
            this.ID_PAR_NOM_COB.SelectedIndexChanged += new System.EventHandler(this.ID_PAR_NOM_COB_SelectionChangeCommitted);
            this.ID_PAR_NOM_COB.TextChanged += new System.EventHandler(this.ID_PAR_NOM_COB_TextChanged);
            this.ID_PAR_NOM_COB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_PAR_NOM_COB_KeyPress);
            // 
            // ID_PAR_NOM_TXT
            // 
            this.ID_PAR_NOM_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_PAR_NOM_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_NOM_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_PAR_NOM_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_NOM_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_PAR_NOM_TXT.Location = new System.Drawing.Point(12, 25);
            this.ID_PAR_NOM_TXT.Name = "ID_PAR_NOM_TXT";
            this.ID_PAR_NOM_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_NOM_TXT.Size = new System.Drawing.Size(48, 14);
            this.ID_PAR_NOM_TXT.TabIndex = 39;
            this.ID_PAR_NOM_TXT.Tag = "";
            this.ID_PAR_NOM_TXT.Text = "&Nombre";
            // 
            // ID_PAR_GRU_EB
            // 
            this.ID_PAR_GRU_EB.Location = new System.Drawing.Point(175, 69);
            this.ID_PAR_GRU_EB.Name = "ID_PAR_GRU_EB";
            this.ID_PAR_GRU_EB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PAR_GRU_EB.OcxState")));
            this.ID_PAR_GRU_EB.Size = new System.Drawing.Size(56, 22);
            this.ID_PAR_GRU_EB.TabIndex = 7;
            this.ID_PAR_GRU_EB.Tag = "";
            this.ID_PAR_GRU_EB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_PAR_GRU_EB_KeyPressEvent);
            // 
            // ID_PAR_CON_EB
            // 
            this.ID_PAR_CON_EB.Location = new System.Drawing.Point(175, 96);
            this.ID_PAR_CON_EB.Name = "ID_PAR_CON_EB";
            this.ID_PAR_CON_EB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PAR_CON_EB.OcxState")));
            this.ID_PAR_CON_EB.Size = new System.Drawing.Size(56, 22);
            this.ID_PAR_CON_EB.TabIndex = 8;
            this.ID_PAR_CON_EB.Tag = "";
            this.ID_PAR_CON_EB.Change += new System.EventHandler(this.ID_PAR_CON_EB_Change);
            this.ID_PAR_CON_EB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_PAR_CON_EB_KeyPressEvent);
            // 
            // ID_PAR_NUM_TXT
            // 
            this.ID_PAR_NUM_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_PAR_NUM_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_NUM_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_PAR_NUM_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_NUM_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_PAR_NUM_TXT.Location = new System.Drawing.Point(12, 52);
            this.ID_PAR_NUM_TXT.Name = "ID_PAR_NUM_TXT";
            this.ID_PAR_NUM_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_NUM_TXT.Size = new System.Drawing.Size(81, 14);
            this.ID_PAR_NUM_TXT.TabIndex = 38;
            this.ID_PAR_NUM_TXT.Tag = "";
            this.ID_PAR_NUM_TXT.Text = "N&o. de Banco";
            // 
            // ID_PAR_CON_TXT
            // 
            this.ID_PAR_CON_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_PAR_CON_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_CON_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_PAR_CON_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_CON_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_PAR_CON_TXT.Location = new System.Drawing.Point(12, 100);
            this.ID_PAR_CON_TXT.Name = "ID_PAR_CON_TXT";
            this.ID_PAR_CON_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_CON_TXT.Size = new System.Drawing.Size(146, 15);
            this.ID_PAR_CON_TXT.TabIndex = 35;
            this.ID_PAR_CON_TXT.Tag = "";
            this.ID_PAR_CON_TXT.Text = "Consecutivo de &Empresa";
            // 
            // ID_PAR_GRU_TXT
            // 
            this.ID_PAR_GRU_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_PAR_GRU_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_GRU_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_PAR_GRU_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_GRU_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_PAR_GRU_TXT.Location = new System.Drawing.Point(12, 76);
            this.ID_PAR_GRU_TXT.Name = "ID_PAR_GRU_TXT";
            this.ID_PAR_GRU_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_GRU_TXT.Size = new System.Drawing.Size(129, 14);
            this.ID_PAR_GRU_TXT.TabIndex = 37;
            this.ID_PAR_GRU_TXT.Tag = "";
            this.ID_PAR_GRU_TXT.Text = "Consecutivo de &Grupo";
            // 
            // ID_PAR_PRE_TXT
            // 
            this.ID_PAR_PRE_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_PAR_PRE_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_PRE_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_PAR_PRE_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_PRE_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_PAR_PRE_TXT.Location = new System.Drawing.Point(147, 47);
            this.ID_PAR_PRE_TXT.Name = "ID_PAR_PRE_TXT";
            this.ID_PAR_PRE_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_PRE_TXT.Size = new System.Drawing.Size(39, 13);
            this.ID_PAR_PRE_TXT.TabIndex = 36;
            this.ID_PAR_PRE_TXT.Tag = "";
            this.ID_PAR_PRE_TXT.Text = "&Prefijo";
            // 
            // ID_PAR_PRE_EB
            // 
            this.ID_PAR_PRE_EB.Location = new System.Drawing.Point(188, 43);
            this.ID_PAR_PRE_EB.Name = "ID_PAR_PRE_EB";
            this.ID_PAR_PRE_EB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PAR_PRE_EB.OcxState")));
            this.ID_PAR_PRE_EB.Size = new System.Drawing.Size(43, 22);
            this.ID_PAR_PRE_EB.TabIndex = 6;
            this.ID_PAR_PRE_EB.Tag = "";
            this.ID_PAR_PRE_EB.Change += new System.EventHandler(this.ID_PAR_PRE_EB_Change);
            this.ID_PAR_PRE_EB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_PAR_PRE_EB_KeyPressEvent);
            this.ID_PAR_PRE_EB.Leave += new System.EventHandler(this.ID_PAR_PRE_EB_Leave);
            // 
            // ID_PAR_NUM_EB
            // 
            this.ID_PAR_NUM_EB.Location = new System.Drawing.Point(102, 47);
            this.ID_PAR_NUM_EB.Name = "ID_PAR_NUM_EB";
            this.ID_PAR_NUM_EB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PAR_NUM_EB.OcxState")));
            this.ID_PAR_NUM_EB.Size = new System.Drawing.Size(32, 22);
            this.ID_PAR_NUM_EB.TabIndex = 5;
            this.ID_PAR_NUM_EB.Tag = "";
            this.ID_PAR_NUM_EB.Change += new System.EventHandler(this.ID_PAR_NUM_EB_Change);
            this.ID_PAR_NUM_EB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_PAR_NUM_EB_KeyPressEvent);
            this.ID_PAR_NUM_EB.Leave += new System.EventHandler(this.ID_PAR_NUM_EB_Leave);
            // 
            // SSPanel1
            // 
            this.SSPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SSPanel1.Controls.Add(this.Label8);
            this.SSPanel1.Controls.Add(this.Label7);
            this.SSPanel1.Controls.Add(this.ID_PAR_COM_TRA_FR);
            this.SSPanel1.Controls.Add(this.ID_PAR_LADA_TXT);
            this.SSPanel1.Controls.Add(this.ID_PAR_TEL_TXT);
            this.SSPanel1.Controls.Add(this.Label6);
            this.SSPanel1.Controls.Add(this.Label2);
            this.SSPanel1.Controls.Add(this.Label1);
            this.SSPanel1.Controls.Add(this.Label3);
            this.SSPanel1.Controls.Add(this.Label5);
            this.SSPanel1.Controls.Add(this.Label4);
            this.SSPanel1.Controls.Add(this.ID_PAR_FAX_TXT);
            this.SSPanel1.Controls.Add(this.ID_PAR_INTER_TXT);
            this.SSPanel1.Controls.Add(this.ID_PAR_COM_TRA_COB);
            this.SSPanel1.Controls.Add(this.ID_PAR_EMAIL_TXT);
            this.SSPanel1.Controls.Add(this.ID_PAR_FAX_LADA_TXT);
            this.SSPanel1.Controls.Add(this.ID_PAR_TEL_EXT_TXT);
            this.SSPanel1.Location = new System.Drawing.Point(16, 261);
            this.SSPanel1.Name = "SSPanel1";
            this.SSPanel1.Size = new System.Drawing.Size(448, 119);
            this.SSPanel1.TabIndex = 11;
            this.SSPanel1.Tag = "";
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.BackColor = System.Drawing.SystemColors.Control;
            this.Label8.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label8.Location = new System.Drawing.Point(13, 281);
            this.Label8.Name = "Label8";
            this.Label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label8.Size = new System.Drawing.Size(128, 13);
            this.Label8.TabIndex = 50;
            this.Label8.Tag = "";
            this.Label8.Text = "Velocidad de Transmisión";
            this.Label8.Visible = false;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.Color.Silver;
            this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label7.Location = new System.Drawing.Point(13, 92);
            this.Label7.Name = "Label7";
            this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label7.Size = new System.Drawing.Size(51, 13);
            this.Label7.TabIndex = 48;
            this.Label7.Tag = "";
            this.Label7.Text = "Internet";
            // 
            // ID_PAR_COM_TRA_FR
            // 
            this.ID_PAR_COM_TRA_FR.Controls.Add(this.ID_PAR_COM3_OB);
            this.ID_PAR_COM_TRA_FR.Controls.Add(this.ID_PAR_COM4_OB);
            this.ID_PAR_COM_TRA_FR.Controls.Add(this.ID_PAR_COM1_OB);
            this.ID_PAR_COM_TRA_FR.Controls.Add(this.ID_PAR_COM2_OB);
            this.ID_PAR_COM_TRA_FR.Location = new System.Drawing.Point(312, 195);
            this.ID_PAR_COM_TRA_FR.Name = "ID_PAR_COM_TRA_FR";
            this.ID_PAR_COM_TRA_FR.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PAR_COM_TRA_FR.OcxState")));
            this.ID_PAR_COM_TRA_FR.Size = new System.Drawing.Size(123, 104);
            this.ID_PAR_COM_TRA_FR.TabIndex = 49;
            this.ID_PAR_COM_TRA_FR.Tag = "";
            this.ID_PAR_COM_TRA_FR.Visible = false;
            // 
            // ID_PAR_COM3_OB
            // 
            this.ID_PAR_COM3_OB.Location = new System.Drawing.Point(23, 62);
            this.ID_PAR_COM3_OB.Name = "ID_PAR_COM3_OB";
            this.ID_PAR_COM3_OB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PAR_COM3_OB.OcxState")));
            this.ID_PAR_COM3_OB.Size = new System.Drawing.Size(71, 18);
            this.ID_PAR_COM3_OB.TabIndex = 21;
            this.ID_PAR_COM3_OB.Tag = "";
            // 
            // ID_PAR_COM4_OB
            // 
            this.ID_PAR_COM4_OB.Location = new System.Drawing.Point(23, 83);
            this.ID_PAR_COM4_OB.Name = "ID_PAR_COM4_OB";
            this.ID_PAR_COM4_OB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PAR_COM4_OB.OcxState")));
            this.ID_PAR_COM4_OB.Size = new System.Drawing.Size(63, 17);
            this.ID_PAR_COM4_OB.TabIndex = 22;
            this.ID_PAR_COM4_OB.Tag = "";
            // 
            // ID_PAR_COM1_OB
            // 
            this.ID_PAR_COM1_OB.Location = new System.Drawing.Point(23, 20);
            this.ID_PAR_COM1_OB.Name = "ID_PAR_COM1_OB";
            this.ID_PAR_COM1_OB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PAR_COM1_OB.OcxState")));
            this.ID_PAR_COM1_OB.Size = new System.Drawing.Size(64, 12);
            this.ID_PAR_COM1_OB.TabIndex = 19;
            this.ID_PAR_COM1_OB.Tag = "";
            // 
            // ID_PAR_COM2_OB
            // 
            this.ID_PAR_COM2_OB.Location = new System.Drawing.Point(23, 39);
            this.ID_PAR_COM2_OB.Name = "ID_PAR_COM2_OB";
            this.ID_PAR_COM2_OB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PAR_COM2_OB.OcxState")));
            this.ID_PAR_COM2_OB.Size = new System.Drawing.Size(78, 17);
            this.ID_PAR_COM2_OB.TabIndex = 20;
            this.ID_PAR_COM2_OB.Tag = "";
            // 
            // ID_PAR_LADA_TXT
            // 
            this.ID_PAR_LADA_TXT.AcceptsReturn = true;
            this.ID_PAR_LADA_TXT.BackColor = System.Drawing.Color.White;
            this.ID_PAR_LADA_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_PAR_LADA_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_LADA_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_PAR_LADA_TXT.Location = new System.Drawing.Point(222, 9);
            this.ID_PAR_LADA_TXT.MaxLength = 9;
            this.ID_PAR_LADA_TXT.Multiline = true;
            this.ID_PAR_LADA_TXT.Name = "ID_PAR_LADA_TXT";
            this.ID_PAR_LADA_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_LADA_TXT.Size = new System.Drawing.Size(78, 20);
            this.ID_PAR_LADA_TXT.TabIndex = 12;
            this.ID_PAR_LADA_TXT.Tag = "";
            this.ID_PAR_LADA_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ID_PAR_LADA_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_PAR_LADA_TXT_KeyPress);
            // 
            // ID_PAR_TEL_TXT
            // 
            this.ID_PAR_TEL_TXT.AcceptsReturn = true;
            this.ID_PAR_TEL_TXT.BackColor = System.Drawing.Color.White;
            this.ID_PAR_TEL_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_PAR_TEL_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_TEL_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_PAR_TEL_TXT.Location = new System.Drawing.Point(75, 9);
            this.ID_PAR_TEL_TXT.MaxLength = 9;
            this.ID_PAR_TEL_TXT.Multiline = true;
            this.ID_PAR_TEL_TXT.Name = "ID_PAR_TEL_TXT";
            this.ID_PAR_TEL_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_TEL_TXT.Size = new System.Drawing.Size(74, 20);
            this.ID_PAR_TEL_TXT.TabIndex = 11;
            this.ID_PAR_TEL_TXT.Tag = "";
            this.ID_PAR_TEL_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ID_PAR_TEL_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_PAR_TEL_TXT_KeyPress);
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.Color.Silver;
            this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label6.Location = new System.Drawing.Point(13, 66);
            this.Label6.Name = "Label6";
            this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label6.Size = new System.Drawing.Size(37, 13);
            this.Label6.TabIndex = 47;
            this.Label6.Tag = "";
            this.Label6.Text = "Email";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.Color.Silver;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(161, 12);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(35, 13);
            this.Label2.TabIndex = 43;
            this.Label2.Tag = "";
            this.Label2.Text = "Lada";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.Color.Silver;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(13, 12);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(57, 13);
            this.Label1.TabIndex = 42;
            this.Label1.Tag = "";
            this.Label1.Text = "Teléfono";
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Silver;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(13, 38);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(27, 13);
            this.Label3.TabIndex = 44;
            this.Label3.Tag = "";
            this.Label3.Text = "Fax";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.Color.Silver;
            this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label5.Location = new System.Drawing.Point(317, 12);
            this.Label5.Name = "Label5";
            this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label5.Size = new System.Drawing.Size(62, 13);
            this.Label5.TabIndex = 46;
            this.Label5.Tag = "";
            this.Label5.Text = "Extensión";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.Color.Silver;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label4.Location = new System.Drawing.Point(160, 38);
            this.Label4.Name = "Label4";
            this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label4.Size = new System.Drawing.Size(59, 13);
            this.Label4.TabIndex = 45;
            this.Label4.Tag = "";
            this.Label4.Text = "Fax Lada";
            // 
            // ID_PAR_FAX_TXT
            // 
            this.ID_PAR_FAX_TXT.AcceptsReturn = true;
            this.ID_PAR_FAX_TXT.BackColor = System.Drawing.Color.White;
            this.ID_PAR_FAX_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_PAR_FAX_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_FAX_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_PAR_FAX_TXT.Location = new System.Drawing.Point(75, 34);
            this.ID_PAR_FAX_TXT.MaxLength = 9;
            this.ID_PAR_FAX_TXT.Multiline = true;
            this.ID_PAR_FAX_TXT.Name = "ID_PAR_FAX_TXT";
            this.ID_PAR_FAX_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_FAX_TXT.Size = new System.Drawing.Size(74, 22);
            this.ID_PAR_FAX_TXT.TabIndex = 13;
            this.ID_PAR_FAX_TXT.Tag = "";
            this.ID_PAR_FAX_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ID_PAR_FAX_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_PAR_FAX_TXT_KeyPress);
            // 
            // ID_PAR_INTER_TXT
            // 
            this.ID_PAR_INTER_TXT.AcceptsReturn = true;
            this.ID_PAR_INTER_TXT.BackColor = System.Drawing.Color.White;
            this.ID_PAR_INTER_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_PAR_INTER_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_INTER_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_PAR_INTER_TXT.Location = new System.Drawing.Point(75, 88);
            this.ID_PAR_INTER_TXT.MaxLength = 0;
            this.ID_PAR_INTER_TXT.Name = "ID_PAR_INTER_TXT";
            this.ID_PAR_INTER_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_INTER_TXT.Size = new System.Drawing.Size(360, 20);
            this.ID_PAR_INTER_TXT.TabIndex = 18;
            this.ID_PAR_INTER_TXT.Tag = "";
            this.ID_PAR_INTER_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_PAR_INTER_TXT_KeyPress);
            // 
            // ID_PAR_COM_TRA_COB
            // 
            this.ID_PAR_COM_TRA_COB.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ID_PAR_COM_TRA_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_COM_TRA_COB.Enabled = false;
            this.ID_PAR_COM_TRA_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_COM_TRA_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_PAR_COM_TRA_COB.Location = new System.Drawing.Point(169, 277);
            this.ID_PAR_COM_TRA_COB.Name = "ID_PAR_COM_TRA_COB";
            this.ID_PAR_COM_TRA_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_COM_TRA_COB.Size = new System.Drawing.Size(100, 21);
            this.ID_PAR_COM_TRA_COB.TabIndex = 16;
            this.ID_PAR_COM_TRA_COB.Tag = "";
            this.ID_PAR_COM_TRA_COB.Text = "0";
            this.ID_PAR_COM_TRA_COB.Visible = false;
            // 
            // ID_PAR_EMAIL_TXT
            // 
            this.ID_PAR_EMAIL_TXT.AcceptsReturn = true;
            this.ID_PAR_EMAIL_TXT.BackColor = System.Drawing.Color.White;
            this.ID_PAR_EMAIL_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_PAR_EMAIL_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_EMAIL_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_PAR_EMAIL_TXT.Location = new System.Drawing.Point(75, 63);
            this.ID_PAR_EMAIL_TXT.MaxLength = 0;
            this.ID_PAR_EMAIL_TXT.Name = "ID_PAR_EMAIL_TXT";
            this.ID_PAR_EMAIL_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_EMAIL_TXT.Size = new System.Drawing.Size(360, 20);
            this.ID_PAR_EMAIL_TXT.TabIndex = 17;
            this.ID_PAR_EMAIL_TXT.Tag = "";
            this.ID_PAR_EMAIL_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_PAR_EMAIL_TXT_KeyPress);
            // 
            // ID_PAR_FAX_LADA_TXT
            // 
            this.ID_PAR_FAX_LADA_TXT.AcceptsReturn = true;
            this.ID_PAR_FAX_LADA_TXT.BackColor = System.Drawing.Color.White;
            this.ID_PAR_FAX_LADA_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_PAR_FAX_LADA_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_FAX_LADA_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_PAR_FAX_LADA_TXT.Location = new System.Drawing.Point(222, 35);
            this.ID_PAR_FAX_LADA_TXT.MaxLength = 9;
            this.ID_PAR_FAX_LADA_TXT.Multiline = true;
            this.ID_PAR_FAX_LADA_TXT.Name = "ID_PAR_FAX_LADA_TXT";
            this.ID_PAR_FAX_LADA_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_FAX_LADA_TXT.Size = new System.Drawing.Size(78, 20);
            this.ID_PAR_FAX_LADA_TXT.TabIndex = 14;
            this.ID_PAR_FAX_LADA_TXT.Tag = "";
            this.ID_PAR_FAX_LADA_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ID_PAR_FAX_LADA_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_PAR_FAX_LADA_TXT_KeyPress);
            // 
            // ID_PAR_TEL_EXT_TXT
            // 
            this.ID_PAR_TEL_EXT_TXT.AcceptsReturn = true;
            this.ID_PAR_TEL_EXT_TXT.BackColor = System.Drawing.Color.White;
            this.ID_PAR_TEL_EXT_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_PAR_TEL_EXT_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_TEL_EXT_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_PAR_TEL_EXT_TXT.Location = new System.Drawing.Point(379, 9);
            this.ID_PAR_TEL_EXT_TXT.MaxLength = 5;
            this.ID_PAR_TEL_EXT_TXT.Multiline = true;
            this.ID_PAR_TEL_EXT_TXT.Name = "ID_PAR_TEL_EXT_TXT";
            this.ID_PAR_TEL_EXT_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_TEL_EXT_TXT.Size = new System.Drawing.Size(49, 20);
            this.ID_PAR_TEL_EXT_TXT.TabIndex = 15;
            this.ID_PAR_TEL_EXT_TXT.Tag = "";
            this.ID_PAR_TEL_EXT_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ID_PAR_TEL_EXT_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_PAR_TEL_EXT_TXT_KeyPress);
            // 
            // SSPanel2
            // 
            this.SSPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SSPanel2.Controls.Add(this.label13);
            this.SSPanel2.Controls.Add(this.ID_PAR_LEJ_EB);
            this.SSPanel2.Controls.Add(this.ID_PAR_LEM_EB);
            this.SSPanel2.Controls.Add(this.Label10);
            this.SSPanel2.Controls.Add(this.Label9);
            this.SSPanel2.Location = new System.Drawing.Point(16, 186);
            this.SSPanel2.Name = "SSPanel2";
            this.SSPanel2.Size = new System.Drawing.Size(583, 61);
            this.SSPanel2.TabIndex = 8;
            this.SSPanel2.Tag = "";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(210, 3);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(169, 13);
            this.label13.TabIndex = 54;
            this.label13.Text = "Configuración de Longitudes";
            // 
            // ID_PAR_LEJ_EB
            // 
            this.ID_PAR_LEJ_EB.Location = new System.Drawing.Point(468, 21);
            this.ID_PAR_LEJ_EB.Name = "ID_PAR_LEJ_EB";
            this.ID_PAR_LEJ_EB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PAR_LEJ_EB.OcxState")));
            this.ID_PAR_LEJ_EB.Size = new System.Drawing.Size(56, 22);
            this.ID_PAR_LEJ_EB.TabIndex = 10;
            this.ID_PAR_LEJ_EB.Tag = "";
            this.ID_PAR_LEJ_EB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_PAR_LEJ_EB_KeyPressEvent);
            this.ID_PAR_LEJ_EB.Enter += new System.EventHandler(this.ID_PAR_LEJ_EB_Enter);
            this.ID_PAR_LEJ_EB.Validating += new System.ComponentModel.CancelEventHandler(this.ID_PAR_LEJ_EB_Validating);
            // 
            // ID_PAR_LEM_EB
            // 
            this.ID_PAR_LEM_EB.Location = new System.Drawing.Point(145, 24);
            this.ID_PAR_LEM_EB.Name = "ID_PAR_LEM_EB";
            this.ID_PAR_LEM_EB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PAR_LEM_EB.OcxState")));
            this.ID_PAR_LEM_EB.Size = new System.Drawing.Size(56, 22);
            this.ID_PAR_LEM_EB.TabIndex = 9;
            this.ID_PAR_LEM_EB.Tag = "";
            this.ID_PAR_LEM_EB.Change += new System.EventHandler(this.ID_PAR_LEM_EB_Change);
            this.ID_PAR_LEM_EB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_PAR_LEM_EB_KeyPressEvent);
            this.ID_PAR_LEM_EB.Enter += new System.EventHandler(this.ID_PAR_LEM_EB_Enter);
            this.ID_PAR_LEM_EB.Validating += new System.ComponentModel.CancelEventHandler(this.ID_PAR_LEM_EB_Validating);
            // 
            // Label10
            // 
            this.Label10.BackColor = System.Drawing.Color.Silver;
            this.Label10.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label10.Location = new System.Drawing.Point(327, 27);
            this.Label10.Name = "Label10";
            this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label10.Size = new System.Drawing.Size(139, 17);
            this.Label10.TabIndex = 53;
            this.Label10.Tag = "";
            this.Label10.Text = "&Longitud de Ejecutivos:";
            // 
            // Label9
            // 
            this.Label9.BackColor = System.Drawing.Color.Silver;
            this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label9.Location = new System.Drawing.Point(16, 27);
            this.Label9.Name = "Label9";
            this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label9.Size = new System.Drawing.Size(125, 17);
            this.Label9.TabIndex = 52;
            this.Label9.Tag = "";
            this.Label9.Text = "&Longitud de Empresa:";
            // 
            // ID_PAR_VER_EB
            // 
            this.ID_PAR_VER_EB.Location = new System.Drawing.Point(537, 258);
            this.ID_PAR_VER_EB.Name = "ID_PAR_VER_EB";
            this.ID_PAR_VER_EB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PAR_VER_EB.OcxState")));
            this.ID_PAR_VER_EB.Size = new System.Drawing.Size(55, 22);
            this.ID_PAR_VER_EB.TabIndex = 23;
            this.ID_PAR_VER_EB.Tag = "";
            this.ID_PAR_VER_EB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_PAR_VER_EB_KeyPressEvent);
            // 
            // ID_PAR_ACE_PB
            // 
            this.ID_PAR_ACE_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_PAR_ACE_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_ACE_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_PAR_ACE_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_ACE_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_PAR_ACE_PB.Location = new System.Drawing.Point(506, 307);
            this.ID_PAR_ACE_PB.Name = "ID_PAR_ACE_PB";
            this.ID_PAR_ACE_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_ACE_PB.Size = new System.Drawing.Size(70, 25);
            this.ID_PAR_ACE_PB.TabIndex = 24;
            this.ID_PAR_ACE_PB.Tag = "";
            this.ID_PAR_ACE_PB.Text = "Aceptar";
            this.ID_PAR_ACE_PB.UseVisualStyleBackColor = false;
            this.ID_PAR_ACE_PB.Click += new System.EventHandler(this.ID_PAR_ACE_PB_Click);
            // 
            // ID_PAR_CAN_PB
            // 
            this.ID_PAR_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_PAR_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_PAR_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_PAR_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_PAR_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_PAR_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_PAR_CAN_PB.Location = new System.Drawing.Point(506, 345);
            this.ID_PAR_CAN_PB.Name = "ID_PAR_CAN_PB";
            this.ID_PAR_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_PAR_CAN_PB.Size = new System.Drawing.Size(70, 25);
            this.ID_PAR_CAN_PB.TabIndex = 25;
            this.ID_PAR_CAN_PB.Tag = "";
            this.ID_PAR_CAN_PB.Text = "Cancelar";
            this.ID_PAR_CAN_PB.UseVisualStyleBackColor = false;
            this.ID_PAR_CAN_PB.Click += new System.EventHandler(this.ID_PAR_CAN_PB_Click);
            // 
            // Fsw_Bco_Baja
            // 
            this.Fsw_Bco_Baja.BackColor = System.Drawing.SystemColors.Control;
            this.Fsw_Bco_Baja.Cursor = System.Windows.Forms.Cursors.Default;
            this.Fsw_Bco_Baja.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Fsw_Bco_Baja.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Fsw_Bco_Baja.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Fsw_Bco_Baja.Location = new System.Drawing.Point(512, 97);
            this.Fsw_Bco_Baja.Name = "Fsw_Bco_Baja";
            this.Fsw_Bco_Baja.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Fsw_Bco_Baja.Size = new System.Drawing.Size(73, 25);
            this.Fsw_Bco_Baja.TabIndex = 27;
            this.Fsw_Bco_Baja.Tag = "";
            this.Fsw_Bco_Baja.Text = "&Baja";
            this.Fsw_Bco_Baja.UseVisualStyleBackColor = false;
            this.Fsw_Bco_Baja.Click += new System.EventHandler(this.Fsw_Bco_Baja_Click);
            // 
            // FSW_Bco_Alta
            // 
            this.FSW_Bco_Alta.BackColor = System.Drawing.SystemColors.Control;
            this.FSW_Bco_Alta.Cursor = System.Windows.Forms.Cursors.Default;
            this.FSW_Bco_Alta.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.FSW_Bco_Alta.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FSW_Bco_Alta.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FSW_Bco_Alta.Location = new System.Drawing.Point(512, 59);
            this.FSW_Bco_Alta.Name = "FSW_Bco_Alta";
            this.FSW_Bco_Alta.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FSW_Bco_Alta.Size = new System.Drawing.Size(73, 25);
            this.FSW_Bco_Alta.TabIndex = 26;
            this.FSW_Bco_Alta.Tag = "";
            this.FSW_Bco_Alta.Text = "&Alta";
            this.FSW_Bco_Alta.UseVisualStyleBackColor = false;
            this.FSW_Bco_Alta.Click += new System.EventHandler(this.FSW_Bco_Alta_Click);
            // 
            // CORMNPAR
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(615, 395);
            this.Controls.Add(this.ID_PAR_CAN_PB);
            this.Controls.Add(this.ID_PAR_ACE_PB);
            this.Controls.Add(this.Fsw_Bco_Baja);
            this.Controls.Add(this.FSW_Bco_Alta);
            this.Controls.Add(this.ID_PAR_PRI_PNL);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(98, 46);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORMNPAR";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Parámetros";
            this.Activated += new System.EventHandler(this.CORMNPAR_Activated);
            this.Closed += new System.EventHandler(this.CORMNPAR_Closed);
            this.ID_PAR_PRI_PNL.ResumeLayout(false);
            this.ID_PAR_PRI_PNL.PerformLayout();
            this.ID_PAR_PAR_PNL.ResumeLayout(false);
            this.ID_PAR_PAR_PNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_DIA_EB)).EndInit();
            this.ID_PAR_BAN_PNL.ResumeLayout(false);
            this.ID_PAR_BAN_PNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_GRU_EB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_CON_EB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_PRE_EB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_NUM_EB)).EndInit();
            this.SSPanel1.ResumeLayout(false);
            this.SSPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_COM_TRA_FR)).EndInit();
            this.ID_PAR_COM_TRA_FR.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_COM3_OB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_COM4_OB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_COM1_OB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_COM2_OB)).EndInit();
            this.SSPanel2.ResumeLayout(false);
            this.SSPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_LEJ_EB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_LEM_EB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_PAR_VER_EB)).EndInit();
            this.ResumeLayout(false);

	}
#endregion 

        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
}
}