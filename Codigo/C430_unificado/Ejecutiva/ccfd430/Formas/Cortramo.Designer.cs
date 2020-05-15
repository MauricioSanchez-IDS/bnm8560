using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORTRAMO
	{
	
#region "Upgrade Support "
		private static CORTRAMO m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORTRAMO DefInstance
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
		public CORTRAMO():base(){
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
			InitializeID_MCO_EMAIL_LBL();
			InitializeFramFlowControl();
		}
	public static CORTRAMO CreateInstance()
	{
			CORTRAMO theInstance = new CORTRAMO();
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
	public  System.Windows.Forms.Button ID_MCO_INT_PB;
	public  System.Windows.Forms.TextBox ID_MCO_EMAIL_TXT;
	public  Microsoft.VisualBasic.Compatibility.VB6.FileListBox ID_MCO_FIL_FLB;
	public  System.Windows.Forms.ComboBox ID_MCO_GRU_COB;
	public  System.Windows.Forms.ListBox ID_MCO_EMP_LB;
	public  System.Windows.Forms.Button cmdSalir;
        public System.Windows.Forms.Button cmdResetea;
	public  System.Windows.Forms.Button cmdEnvia;
	public  System.Windows.Forms.TextBox TxtFilename;
	public  System.Windows.Forms.ComboBox CmbProtocol;
	public  System.Windows.Forms.TextBox txtNumero;
	public  System.Windows.Forms.Button cmdMarcar;
	public  System.Windows.Forms.ComboBox CmbBaudRate;
	public  System.Windows.Forms.ComboBox CmbStopBits;
	public  System.Windows.Forms.ComboBox CmbParity;
	public  System.Windows.Forms.ComboBox CmbDataBits;
	public  System.Windows.Forms.ComboBox CmbComPort;
	public  System.Windows.Forms.Label LblStopBits;
	public  System.Windows.Forms.Label LblParity;
	public  System.Windows.Forms.Label LblDataBits;
	public  System.Windows.Forms.Label LblBaudRate;
	public  System.Windows.Forms.Label LblComPort;
	public  System.Windows.Forms.GroupBox FramSettings;
	public  System.Windows.Forms.CheckBox ChkHandshakingHardware;
	public  System.Windows.Forms.CheckBox ChkHandshakingSoftware;
	private  System.Windows.Forms.GroupBox _FramFlowControl_4;
	public  System.Windows.Forms.CheckBox ChkDTREnable;
	public  System.Windows.Forms.CheckBox ChkRTSEnable;
	public  AxMSComDlg.AxCommonDialog CommonDialog1;
	public  AxMSMAPI.AxMAPISession ID_MCOM_SESS;
	public  AxMSMAPI.AxMAPIMessages ID_MCOM_MAIL;
	private  System.Windows.Forms.Label _ID_MCO_EMAIL_LBL_44;
	public  System.Windows.Forms.Label ID_MCOM_ARCH_LB;
	public  System.Windows.Forms.Label ID_MCOM_GPO_LB;
	public  System.Windows.Forms.Label ID_MCOM_EMP_LB;
	public  System.Windows.Forms.Label LblFolder;
	public  System.Windows.Forms.Label LblFilename;
	public  System.Windows.Forms.Label LblPath;
	public  System.Windows.Forms.Label LblProtocol;
	public  System.Windows.Forms.Label Label1;
	public System.Windows.Forms.GroupBox[] FramFlowControl = new System.Windows.Forms.GroupBox[5];
	public System.Windows.Forms.Label[] ID_MCO_EMAIL_LBL = new System.Windows.Forms.Label[45];

    public System.Windows.Forms.StatusBar Status;    
        
        
    //NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORTRAMO));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_MCO_INT_PB = new System.Windows.Forms.Button();
            this.ID_MCO_EMAIL_TXT = new System.Windows.Forms.TextBox();
            this.ID_MCO_FIL_FLB = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
            this.ID_MCO_GRU_COB = new System.Windows.Forms.ComboBox();
            this.ID_MCO_EMP_LB = new System.Windows.Forms.ListBox();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdResetea = new System.Windows.Forms.Button();
            this.cmdEnvia = new System.Windows.Forms.Button();
            this.TxtFilename = new System.Windows.Forms.TextBox();
            this.CmbProtocol = new System.Windows.Forms.ComboBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.cmdMarcar = new System.Windows.Forms.Button();
            this.FramSettings = new System.Windows.Forms.GroupBox();
            this.CmbStopBits = new System.Windows.Forms.ComboBox();
            this.LblDataBits = new System.Windows.Forms.Label();
            this.CmbBaudRate = new System.Windows.Forms.ComboBox();
            this.CmbParity = new System.Windows.Forms.ComboBox();
            this.LblStopBits = new System.Windows.Forms.Label();
            this.LblParity = new System.Windows.Forms.Label();
            this.CmbDataBits = new System.Windows.Forms.ComboBox();
            this.CmbComPort = new System.Windows.Forms.ComboBox();
            this.LblBaudRate = new System.Windows.Forms.Label();
            this.LblComPort = new System.Windows.Forms.Label();
            this._FramFlowControl_4 = new System.Windows.Forms.GroupBox();
            this.ChkHandshakingHardware = new System.Windows.Forms.CheckBox();
            this.ChkHandshakingSoftware = new System.Windows.Forms.CheckBox();
            this.ChkDTREnable = new System.Windows.Forms.CheckBox();
            this.ChkRTSEnable = new System.Windows.Forms.CheckBox();
            this.CommonDialog1 = new AxMSComDlg.AxCommonDialog();
            this.ID_MCOM_SESS = new AxMSMAPI.AxMAPISession();
            this.ID_MCOM_MAIL = new AxMSMAPI.AxMAPIMessages();
            this._ID_MCO_EMAIL_LBL_44 = new System.Windows.Forms.Label();
            this.ID_MCOM_ARCH_LB = new System.Windows.Forms.Label();
            this.ID_MCOM_GPO_LB = new System.Windows.Forms.Label();
            this.ID_MCOM_EMP_LB = new System.Windows.Forms.Label();
            this.LblFolder = new System.Windows.Forms.Label();
            this.LblFilename = new System.Windows.Forms.Label();
            this.LblPath = new System.Windows.Forms.Label();
            this.LblProtocol = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Status = new System.Windows.Forms.StatusBar();
            this.FramSettings.SuspendLayout();
            this._FramFlowControl_4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CommonDialog1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MCOM_SESS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MCOM_MAIL)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_MCO_INT_PB
            // 
            this.ID_MCO_INT_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MCO_INT_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MCO_INT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MCO_INT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MCO_INT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MCO_INT_PB.Location = new System.Drawing.Point(382, 261);
            this.ID_MCO_INT_PB.Name = "ID_MCO_INT_PB";
            this.ID_MCO_INT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MCO_INT_PB.Size = new System.Drawing.Size(88, 24);
            this.ID_MCO_INT_PB.TabIndex = 14;
            this.ID_MCO_INT_PB.Tag = "";
            this.ID_MCO_INT_PB.Text = "&Enviar";
            this.ID_MCO_INT_PB.UseVisualStyleBackColor = false;
            this.ID_MCO_INT_PB.Click += new System.EventHandler(this.ID_MCO_INT_PB_Click);
            // 
            // ID_MCO_EMAIL_TXT
            // 
            this.ID_MCO_EMAIL_TXT.AcceptsReturn = true;
            this.ID_MCO_EMAIL_TXT.BackColor = System.Drawing.Color.White;
            this.ID_MCO_EMAIL_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MCO_EMAIL_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MCO_EMAIL_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MCO_EMAIL_TXT.Location = new System.Drawing.Point(68, 263);
            this.ID_MCO_EMAIL_TXT.MaxLength = 50;
            this.ID_MCO_EMAIL_TXT.Name = "ID_MCO_EMAIL_TXT";
            this.ID_MCO_EMAIL_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MCO_EMAIL_TXT.Size = new System.Drawing.Size(291, 20);
            this.ID_MCO_EMAIL_TXT.TabIndex = 9;
            this.ID_MCO_EMAIL_TXT.Tag = "";
            this.ID_MCO_EMAIL_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MCO_EMAIL_TXT_KeyPress);
            // 
            // ID_MCO_FIL_FLB
            // 
            this.ID_MCO_FIL_FLB.BackColor = System.Drawing.Color.White;
            this.ID_MCO_FIL_FLB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MCO_FIL_FLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MCO_FIL_FLB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MCO_FIL_FLB.FormattingEnabled = true;
            this.ID_MCO_FIL_FLB.Location = new System.Drawing.Point(286, 40);
            this.ID_MCO_FIL_FLB.Name = "ID_MCO_FIL_FLB";
            this.ID_MCO_FIL_FLB.Pattern = "*.*";
            this.ID_MCO_FIL_FLB.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.ID_MCO_FIL_FLB.Size = new System.Drawing.Size(184, 212);
            this.ID_MCO_FIL_FLB.TabIndex = 2;
            this.ID_MCO_FIL_FLB.Tag = "";
            // 
            // ID_MCO_GRU_COB
            // 
            this.ID_MCO_GRU_COB.BackColor = System.Drawing.Color.White;
            this.ID_MCO_GRU_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MCO_GRU_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_MCO_GRU_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MCO_GRU_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MCO_GRU_COB.Location = new System.Drawing.Point(68, 10);
            this.ID_MCO_GRU_COB.Name = "ID_MCO_GRU_COB";
            this.ID_MCO_GRU_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MCO_GRU_COB.Size = new System.Drawing.Size(208, 21);
            this.ID_MCO_GRU_COB.Sorted = true;
            this.ID_MCO_GRU_COB.TabIndex = 0;
            this.ID_MCO_GRU_COB.Tag = "";
            this.ID_MCO_GRU_COB.SelectedIndexChanged += new System.EventHandler(this.ID_MCO_GRU_COB_SelectedIndexChanged);
            // 
            // ID_MCO_EMP_LB
            // 
            this.ID_MCO_EMP_LB.BackColor = System.Drawing.Color.White;
            this.ID_MCO_EMP_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MCO_EMP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MCO_EMP_LB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MCO_EMP_LB.Location = new System.Drawing.Point(68, 41);
            this.ID_MCO_EMP_LB.Name = "ID_MCO_EMP_LB";
            this.ID_MCO_EMP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MCO_EMP_LB.Size = new System.Drawing.Size(208, 212);
            this.ID_MCO_EMP_LB.TabIndex = 1;
            this.ID_MCO_EMP_LB.Tag = "";
            this.ID_MCO_EMP_LB.SelectedIndexChanged += new System.EventHandler(this.ID_MCO_EMP_LB_SelectedIndexChanged);
            // 
            // cmdSalir
            // 
            this.cmdSalir.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSalir.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSalir.Location = new System.Drawing.Point(382, 291);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSalir.Size = new System.Drawing.Size(88, 24);
            this.cmdSalir.TabIndex = 15;
            this.cmdSalir.Tag = "";
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = false;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdResetea
            // 
            this.cmdResetea.BackColor = System.Drawing.SystemColors.Control;
            this.cmdResetea.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdResetea.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdResetea.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdResetea.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdResetea.Location = new System.Drawing.Point(356, 513);
            this.cmdResetea.Name = "cmdResetea";
            this.cmdResetea.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdResetea.Size = new System.Drawing.Size(88, 24);
            this.cmdResetea.TabIndex = 13;
            this.cmdResetea.TabStop = false;
            this.cmdResetea.Tag = "";
            this.cmdResetea.Text = "Colgar";
            this.cmdResetea.UseVisualStyleBackColor = false;
            // 
            // cmdEnvia
            // 
            this.cmdEnvia.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEnvia.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdEnvia.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdEnvia.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEnvia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdEnvia.Location = new System.Drawing.Point(356, 457);
            this.cmdEnvia.Name = "cmdEnvia";
            this.cmdEnvia.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdEnvia.Size = new System.Drawing.Size(88, 24);
            this.cmdEnvia.TabIndex = 11;
            this.cmdEnvia.TabStop = false;
            this.cmdEnvia.Tag = "";
            this.cmdEnvia.Text = "Enviar";
            this.cmdEnvia.UseVisualStyleBackColor = false;
            // 
            // TxtFilename
            // 
            this.TxtFilename.AcceptsReturn = true;
            this.TxtFilename.BackColor = System.Drawing.SystemColors.Window;
            this.TxtFilename.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.TxtFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtFilename.ForeColor = System.Drawing.SystemColors.WindowText;
            this.TxtFilename.Location = new System.Drawing.Point(515, 364);
            this.TxtFilename.MaxLength = 0;
            this.TxtFilename.Name = "TxtFilename";
            this.TxtFilename.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.TxtFilename.Size = new System.Drawing.Size(66, 20);
            this.TxtFilename.TabIndex = 29;
            this.TxtFilename.TabStop = false;
            this.TxtFilename.Tag = "";
            this.TxtFilename.Visible = false;
            // 
            // CmbProtocol
            // 
            this.CmbProtocol.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.CmbProtocol.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbProtocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbProtocol.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbProtocol.Location = new System.Drawing.Point(405, 410);
            this.CmbProtocol.Name = "CmbProtocol";
            this.CmbProtocol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbProtocol.Size = new System.Drawing.Size(130, 21);
            this.CmbProtocol.TabIndex = 10;
            this.CmbProtocol.TabStop = false;
            this.CmbProtocol.Tag = "";
            // 
            // txtNumero
            // 
            this.txtNumero.AcceptsReturn = true;
            this.txtNumero.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txtNumero.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtNumero.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNumero.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtNumero.Location = new System.Drawing.Point(156, 374);
            this.txtNumero.MaxLength = 0;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtNumero.Size = new System.Drawing.Size(103, 20);
            this.txtNumero.TabIndex = 3;
            this.txtNumero.TabStop = false;
            this.txtNumero.Tag = "";
            this.txtNumero.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNumero_KeyPress);
            // 
            // cmdMarcar
            // 
            this.cmdMarcar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdMarcar.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdMarcar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdMarcar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdMarcar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdMarcar.Location = new System.Drawing.Point(357, 485);
            this.cmdMarcar.Name = "cmdMarcar";
            this.cmdMarcar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdMarcar.Size = new System.Drawing.Size(88, 24);
            this.cmdMarcar.TabIndex = 12;
            this.cmdMarcar.TabStop = false;
            this.cmdMarcar.Tag = "";
            this.cmdMarcar.Text = "Marcar";
            this.cmdMarcar.UseVisualStyleBackColor = false;
            // 
            // FramSettings
            // 
            this.FramSettings.BackColor = System.Drawing.SystemColors.Control;
            this.FramSettings.Controls.Add(this.CmbStopBits);
            this.FramSettings.Controls.Add(this.LblDataBits);
            this.FramSettings.Controls.Add(this.CmbBaudRate);
            this.FramSettings.Controls.Add(this.CmbParity);
            this.FramSettings.Controls.Add(this.LblStopBits);
            this.FramSettings.Controls.Add(this.LblParity);
            this.FramSettings.Controls.Add(this.CmbDataBits);
            this.FramSettings.Controls.Add(this.CmbComPort);
            this.FramSettings.Controls.Add(this.LblBaudRate);
            this.FramSettings.Controls.Add(this.LblComPort);
            this.FramSettings.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FramSettings.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FramSettings.Location = new System.Drawing.Point(54, 408);
            this.FramSettings.Name = "FramSettings";
            this.FramSettings.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.FramSettings.Size = new System.Drawing.Size(266, 160);
            this.FramSettings.TabIndex = 21;
            this.FramSettings.TabStop = false;
            this.FramSettings.Tag = "";
            this.FramSettings.Text = "Parámetros de Puerto";
            // 
            // CmbStopBits
            // 
            this.CmbStopBits.BackColor = System.Drawing.SystemColors.Window;
            this.CmbStopBits.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbStopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbStopBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbStopBits.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbStopBits.Location = new System.Drawing.Point(128, 128);
            this.CmbStopBits.Name = "CmbStopBits";
            this.CmbStopBits.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbStopBits.Size = new System.Drawing.Size(120, 21);
            this.CmbStopBits.TabIndex = 8;
            this.CmbStopBits.TabStop = false;
            this.CmbStopBits.Tag = "";
            // 
            // LblDataBits
            // 
            this.LblDataBits.BackColor = System.Drawing.SystemColors.Control;
            this.LblDataBits.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblDataBits.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LblDataBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblDataBits.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblDataBits.Location = new System.Drawing.Point(17, 83);
            this.LblDataBits.Name = "LblDataBits";
            this.LblDataBits.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblDataBits.Size = new System.Drawing.Size(80, 23);
            this.LblDataBits.TabIndex = 24;
            this.LblDataBits.Tag = "";
            this.LblDataBits.Text = "Bits &Datos :";
            // 
            // CmbBaudRate
            // 
            this.CmbBaudRate.BackColor = System.Drawing.SystemColors.Window;
            this.CmbBaudRate.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbBaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbBaudRate.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbBaudRate.Location = new System.Drawing.Point(128, 50);
            this.CmbBaudRate.Name = "CmbBaudRate";
            this.CmbBaudRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbBaudRate.Size = new System.Drawing.Size(120, 21);
            this.CmbBaudRate.TabIndex = 5;
            this.CmbBaudRate.TabStop = false;
            this.CmbBaudRate.Tag = "";
            // 
            // CmbParity
            // 
            this.CmbParity.BackColor = System.Drawing.SystemColors.Window;
            this.CmbParity.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbParity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbParity.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbParity.Location = new System.Drawing.Point(128, 102);
            this.CmbParity.Name = "CmbParity";
            this.CmbParity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbParity.Size = new System.Drawing.Size(120, 21);
            this.CmbParity.TabIndex = 7;
            this.CmbParity.TabStop = false;
            this.CmbParity.Tag = "";
            // 
            // LblStopBits
            // 
            this.LblStopBits.BackColor = System.Drawing.SystemColors.Control;
            this.LblStopBits.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblStopBits.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LblStopBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblStopBits.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblStopBits.Location = new System.Drawing.Point(17, 135);
            this.LblStopBits.Name = "LblStopBits";
            this.LblStopBits.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblStopBits.Size = new System.Drawing.Size(80, 23);
            this.LblStopBits.TabIndex = 26;
            this.LblStopBits.Tag = "";
            this.LblStopBits.Text = "&Stop bits:";
            // 
            // LblParity
            // 
            this.LblParity.BackColor = System.Drawing.SystemColors.Control;
            this.LblParity.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblParity.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LblParity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblParity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblParity.Location = new System.Drawing.Point(17, 109);
            this.LblParity.Name = "LblParity";
            this.LblParity.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblParity.Size = new System.Drawing.Size(80, 23);
            this.LblParity.TabIndex = 25;
            this.LblParity.Tag = "";
            this.LblParity.Text = "&Paridad:";
            // 
            // CmbDataBits
            // 
            this.CmbDataBits.BackColor = System.Drawing.SystemColors.Window;
            this.CmbDataBits.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbDataBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbDataBits.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbDataBits.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbDataBits.Location = new System.Drawing.Point(129, 76);
            this.CmbDataBits.Name = "CmbDataBits";
            this.CmbDataBits.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbDataBits.Size = new System.Drawing.Size(120, 21);
            this.CmbDataBits.TabIndex = 6;
            this.CmbDataBits.TabStop = false;
            this.CmbDataBits.Tag = "";
            // 
            // CmbComPort
            // 
            this.CmbComPort.BackColor = System.Drawing.SystemColors.Window;
            this.CmbComPort.Cursor = System.Windows.Forms.Cursors.Default;
            this.CmbComPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CmbComPort.ForeColor = System.Drawing.SystemColors.WindowText;
            this.CmbComPort.Location = new System.Drawing.Point(126, 21);
            this.CmbComPort.Name = "CmbComPort";
            this.CmbComPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.CmbComPort.Size = new System.Drawing.Size(120, 21);
            this.CmbComPort.TabIndex = 4;
            this.CmbComPort.TabStop = false;
            this.CmbComPort.Tag = "";
            // 
            // LblBaudRate
            // 
            this.LblBaudRate.BackColor = System.Drawing.SystemColors.Control;
            this.LblBaudRate.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblBaudRate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LblBaudRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblBaudRate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblBaudRate.Location = new System.Drawing.Point(17, 57);
            this.LblBaudRate.Name = "LblBaudRate";
            this.LblBaudRate.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblBaudRate.Size = new System.Drawing.Size(110, 23);
            this.LblBaudRate.TabIndex = 23;
            this.LblBaudRate.Tag = "";
            this.LblBaudRate.Text = "&Velocidad Transmisión:";
            // 
            // LblComPort
            // 
            this.LblComPort.BackColor = System.Drawing.SystemColors.Control;
            this.LblComPort.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblComPort.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LblComPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblComPort.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblComPort.Location = new System.Drawing.Point(17, 31);
            this.LblComPort.Name = "LblComPort";
            this.LblComPort.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblComPort.Size = new System.Drawing.Size(78, 22);
            this.LblComPort.TabIndex = 22;
            this.LblComPort.Tag = "";
            this.LblComPort.Text = "&Número Puerto:";
            // 
            // _FramFlowControl_4
            // 
            this._FramFlowControl_4.BackColor = System.Drawing.SystemColors.Control;
            this._FramFlowControl_4.Controls.Add(this.ChkHandshakingHardware);
            this._FramFlowControl_4.Controls.Add(this.ChkHandshakingSoftware);
            this._FramFlowControl_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._FramFlowControl_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._FramFlowControl_4.Location = new System.Drawing.Point(516, 258);
            this._FramFlowControl_4.Name = "_FramFlowControl_4";
            this._FramFlowControl_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._FramFlowControl_4.Size = new System.Drawing.Size(153, 78);
            this._FramFlowControl_4.TabIndex = 18;
            this._FramFlowControl_4.TabStop = false;
            this._FramFlowControl_4.Tag = "";
            this._FramFlowControl_4.Text = "Flujo de Control";
            this._FramFlowControl_4.Visible = false;
            // 
            // ChkHandshakingHardware
            // 
            this.ChkHandshakingHardware.BackColor = System.Drawing.SystemColors.Control;
            this.ChkHandshakingHardware.Checked = true;
            this.ChkHandshakingHardware.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkHandshakingHardware.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChkHandshakingHardware.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkHandshakingHardware.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChkHandshakingHardware.Location = new System.Drawing.Point(16, 15);
            this.ChkHandshakingHardware.Name = "ChkHandshakingHardware";
            this.ChkHandshakingHardware.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ChkHandshakingHardware.Size = new System.Drawing.Size(123, 28);
            this.ChkHandshakingHardware.TabIndex = 20;
            this.ChkHandshakingHardware.TabStop = false;
            this.ChkHandshakingHardware.Tag = "";
            this.ChkHandshakingHardware.Text = "&Hardware (RTS/CTS)";
            this.ChkHandshakingHardware.UseVisualStyleBackColor = false;
            // 
            // ChkHandshakingSoftware
            // 
            this.ChkHandshakingSoftware.BackColor = System.Drawing.SystemColors.Control;
            this.ChkHandshakingSoftware.Checked = true;
            this.ChkHandshakingSoftware.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkHandshakingSoftware.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChkHandshakingSoftware.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkHandshakingSoftware.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChkHandshakingSoftware.Location = new System.Drawing.Point(7, 45);
            this.ChkHandshakingSoftware.Name = "ChkHandshakingSoftware";
            this.ChkHandshakingSoftware.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ChkHandshakingSoftware.Size = new System.Drawing.Size(129, 28);
            this.ChkHandshakingSoftware.TabIndex = 19;
            this.ChkHandshakingSoftware.TabStop = false;
            this.ChkHandshakingSoftware.Tag = "";
            this.ChkHandshakingSoftware.Text = "Software (&XON/XOFF)";
            this.ChkHandshakingSoftware.UseVisualStyleBackColor = false;
            // 
            // ChkDTREnable
            // 
            this.ChkDTREnable.BackColor = System.Drawing.SystemColors.Control;
            this.ChkDTREnable.Checked = true;
            this.ChkDTREnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkDTREnable.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChkDTREnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkDTREnable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChkDTREnable.Location = new System.Drawing.Point(518, 195);
            this.ChkDTREnable.Name = "ChkDTREnable";
            this.ChkDTREnable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ChkDTREnable.Size = new System.Drawing.Size(153, 34);
            this.ChkDTREnable.TabIndex = 17;
            this.ChkDTREnable.TabStop = false;
            this.ChkDTREnable.Tag = "";
            this.ChkDTREnable.Text = "Set D&TR line high";
            this.ChkDTREnable.UseVisualStyleBackColor = false;
            this.ChkDTREnable.Visible = false;
            // 
            // ChkRTSEnable
            // 
            this.ChkRTSEnable.BackColor = System.Drawing.SystemColors.Control;
            this.ChkRTSEnable.Checked = true;
            this.ChkRTSEnable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkRTSEnable.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChkRTSEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChkRTSEnable.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ChkRTSEnable.Location = new System.Drawing.Point(519, 221);
            this.ChkRTSEnable.Name = "ChkRTSEnable";
            this.ChkRTSEnable.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ChkRTSEnable.Size = new System.Drawing.Size(153, 34);
            this.ChkRTSEnable.TabIndex = 16;
            this.ChkRTSEnable.TabStop = false;
            this.ChkRTSEnable.Tag = "";
            this.ChkRTSEnable.Text = "Set &RTS line high";
            this.ChkRTSEnable.UseVisualStyleBackColor = false;
            this.ChkRTSEnable.Visible = false;
            // 
            // CommonDialog1
            // 
            this.CommonDialog1.Enabled = true;
            this.CommonDialog1.Location = new System.Drawing.Point(447, 3);
            this.CommonDialog1.Name = "CommonDialog1";
            this.CommonDialog1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CommonDialog1.OcxState")));
            this.CommonDialog1.Size = new System.Drawing.Size(32, 32);
            this.CommonDialog1.TabIndex = 34;
            this.CommonDialog1.Tag = "";
            // 
            // ID_MCOM_SESS
            // 
            this.ID_MCOM_SESS.Enabled = true;
            this.ID_MCOM_SESS.Location = new System.Drawing.Point(342, 0);
            this.ID_MCOM_SESS.Name = "ID_MCOM_SESS";
            this.ID_MCOM_SESS.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MCOM_SESS.OcxState")));
            this.ID_MCOM_SESS.Size = new System.Drawing.Size(38, 38);
            this.ID_MCOM_SESS.TabIndex = 36;
            this.ID_MCOM_SESS.Tag = "";
            // 
            // ID_MCOM_MAIL
            // 
            this.ID_MCOM_MAIL.Enabled = true;
            this.ID_MCOM_MAIL.Location = new System.Drawing.Point(398, 0);
            this.ID_MCOM_MAIL.Name = "ID_MCOM_MAIL";
            this.ID_MCOM_MAIL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MCOM_MAIL.OcxState")));
            this.ID_MCOM_MAIL.Size = new System.Drawing.Size(38, 38);
            this.ID_MCOM_MAIL.TabIndex = 35;
            this.ID_MCOM_MAIL.Tag = "";
            this.ID_MCOM_MAIL.Enter += new System.EventHandler(this.ID_MCOM_MAIL_Enter);
            // 
            // _ID_MCO_EMAIL_LBL_44
            // 
            this._ID_MCO_EMAIL_LBL_44.AutoSize = true;
            this._ID_MCO_EMAIL_LBL_44.BackColor = System.Drawing.SystemColors.Control;
            this._ID_MCO_EMAIL_LBL_44.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MCO_EMAIL_LBL_44.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MCO_EMAIL_LBL_44.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MCO_EMAIL_LBL_44.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MCO_EMAIL_LBL_44.Location = new System.Drawing.Point(14, 268);
            this._ID_MCO_EMAIL_LBL_44.Name = "_ID_MCO_EMAIL_LBL_44";
            this._ID_MCO_EMAIL_LBL_44.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MCO_EMAIL_LBL_44.Size = new System.Drawing.Size(32, 13);
            this._ID_MCO_EMAIL_LBL_44.TabIndex = 37;
            this._ID_MCO_EMAIL_LBL_44.Tag = "";
            this._ID_MCO_EMAIL_LBL_44.Text = "Email";
            // 
            // ID_MCOM_ARCH_LB
            // 
            this.ID_MCOM_ARCH_LB.AutoSize = true;
            this.ID_MCOM_ARCH_LB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MCOM_ARCH_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MCOM_ARCH_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MCOM_ARCH_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MCOM_ARCH_LB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MCOM_ARCH_LB.Location = new System.Drawing.Point(286, 18);
            this.ID_MCOM_ARCH_LB.Name = "ID_MCOM_ARCH_LB";
            this.ID_MCOM_ARCH_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MCOM_ARCH_LB.Size = new System.Drawing.Size(51, 13);
            this.ID_MCOM_ARCH_LB.TabIndex = 36;
            this.ID_MCOM_ARCH_LB.Tag = "";
            this.ID_MCOM_ARCH_LB.Text = "Archivos:";
            // 
            // ID_MCOM_GPO_LB
            // 
            this.ID_MCOM_GPO_LB.AutoSize = true;
            this.ID_MCOM_GPO_LB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MCOM_GPO_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MCOM_GPO_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MCOM_GPO_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MCOM_GPO_LB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MCOM_GPO_LB.Location = new System.Drawing.Point(14, 14);
            this.ID_MCOM_GPO_LB.Name = "ID_MCOM_GPO_LB";
            this.ID_MCOM_GPO_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MCOM_GPO_LB.Size = new System.Drawing.Size(39, 13);
            this.ID_MCOM_GPO_LB.TabIndex = 35;
            this.ID_MCOM_GPO_LB.Tag = "";
            this.ID_MCOM_GPO_LB.Text = "Grupo:";
            // 
            // ID_MCOM_EMP_LB
            // 
            this.ID_MCOM_EMP_LB.AutoSize = true;
            this.ID_MCOM_EMP_LB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MCOM_EMP_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MCOM_EMP_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MCOM_EMP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MCOM_EMP_LB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MCOM_EMP_LB.Location = new System.Drawing.Point(14, 39);
            this.ID_MCOM_EMP_LB.Name = "ID_MCOM_EMP_LB";
            this.ID_MCOM_EMP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MCOM_EMP_LB.Size = new System.Drawing.Size(56, 13);
            this.ID_MCOM_EMP_LB.TabIndex = 34;
            this.ID_MCOM_EMP_LB.Tag = "";
            this.ID_MCOM_EMP_LB.Text = "Empresas:";
            // 
            // LblFolder
            // 
            this.LblFolder.BackColor = System.Drawing.SystemColors.Control;
            this.LblFolder.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblFolder.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LblFolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFolder.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblFolder.Location = new System.Drawing.Point(12, 372);
            this.LblFolder.Name = "LblFolder";
            this.LblFolder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblFolder.Size = new System.Drawing.Size(41, 17);
            this.LblFolder.TabIndex = 32;
            this.LblFolder.Tag = "";
            this.LblFolder.Text = "Folder:";
            // 
            // LblFilename
            // 
            this.LblFilename.AutoSize = true;
            this.LblFilename.BackColor = System.Drawing.SystemColors.Control;
            this.LblFilename.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblFilename.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LblFilename.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblFilename.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblFilename.Location = new System.Drawing.Point(515, 346);
            this.LblFilename.Name = "LblFilename";
            this.LblFilename.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblFilename.Size = new System.Drawing.Size(52, 13);
            this.LblFilename.TabIndex = 31;
            this.LblFilename.Tag = "";
            this.LblFilename.Text = "&Filename:";
            // 
            // LblPath
            // 
            this.LblPath.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.LblPath.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblPath.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LblPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPath.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblPath.Location = new System.Drawing.Point(53, 405);
            this.LblPath.Name = "LblPath";
            this.LblPath.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblPath.Size = new System.Drawing.Size(283, 16);
            this.LblPath.TabIndex = 30;
            this.LblPath.Tag = "";
            // 
            // LblProtocol
            // 
            this.LblProtocol.AutoSize = true;
            this.LblProtocol.BackColor = System.Drawing.SystemColors.Control;
            this.LblProtocol.Cursor = System.Windows.Forms.Cursors.Default;
            this.LblProtocol.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.LblProtocol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblProtocol.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LblProtocol.Location = new System.Drawing.Point(351, 417);
            this.LblProtocol.Name = "LblProtocol";
            this.LblProtocol.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LblProtocol.Size = new System.Drawing.Size(55, 13);
            this.LblProtocol.TabIndex = 28;
            this.LblProtocol.Tag = "";
            this.LblProtocol.Text = "Protocolo:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(106, 379);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(52, 13);
            this.Label1.TabIndex = 27;
            this.Label1.Tag = "";
            this.Label1.Text = "Teléfono:";
            // 
            // Status
            // 
            this.Status.Location = new System.Drawing.Point(0, 335);
            this.Status.Name = "Status";
            this.Status.ShowPanels = true;
            this.Status.Size = new System.Drawing.Size(504, 24);
            this.Status.SizingGrip = false;
            this.Status.TabIndex = 1;
            // 
            // CORTRAMO
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 14);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(504, 359);
            this.ControlBox = false;
            this.Controls.Add(this.ChkDTREnable);
            this.Controls.Add(this.ChkRTSEnable);
            this.Controls.Add(this.FramSettings);
            this.Controls.Add(this._FramFlowControl_4);
            this.Controls.Add(this.TxtFilename);
            this.Controls.Add(this.cmdEnvia);
            this.Controls.Add(this.cmdMarcar);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.CmbProtocol);
            this.Controls.Add(this.CommonDialog1);
            this.Controls.Add(this.LblFilename);
            this.Controls.Add(this.LblFolder);
            this.Controls.Add(this.LblPath);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.LblProtocol);
            this.Controls.Add(this.ID_MCOM_EMP_LB);
            this.Controls.Add(this.ID_MCOM_MAIL);
            this.Controls.Add(this.ID_MCOM_SESS);
            this.Controls.Add(this._ID_MCO_EMAIL_LBL_44);
            this.Controls.Add(this.ID_MCOM_GPO_LB);
            this.Controls.Add(this.ID_MCOM_ARCH_LB);
            this.Controls.Add(this.cmdResetea);
            this.Controls.Add(this.ID_MCO_FIL_FLB);
            this.Controls.Add(this.ID_MCO_EMAIL_TXT);
            this.Controls.Add(this.ID_MCO_INT_PB);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.ID_MCO_EMP_LB);
            this.Controls.Add(this.ID_MCO_GRU_COB);
            this.Controls.Add(this.Status);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(202, 95);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORTRAMO";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "StatusBar Example";
            this.Closed += new System.EventHandler(this.CORTRAMO_Closed);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.CORTRAMO_Paint);
            this.FramSettings.ResumeLayout(false);
            this._FramFlowControl_4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CommonDialog1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MCOM_SESS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MCOM_MAIL)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
	void  InitializeID_MCO_EMAIL_LBL()
	{
			this.ID_MCO_EMAIL_LBL[44] = _ID_MCO_EMAIL_LBL_44;
	}
	void  InitializeFramFlowControl()
	{
			this.FramFlowControl[4] = _FramFlowControl_4;
	}
#endregion 
}
}