using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class Cormn111
	{
	
#region "Upgrade Support "
		private static Cormn111 m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static Cormn111 DefInstance
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
		public Cormn111():base(){
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
			InitializeID_MEE_ETT_TXT();
			InitializeID_MEE_ETTS111_TXT();
		}
	public static Cormn111 CreateInstance()
	{
			Cormn111 theInstance = new Cormn111();
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
	public  System.Windows.Forms.Button ID_MEE_OK_PB;
	public  System.Windows.Forms.Button ID_MEE_CER_PB;
        public AxMSMask.AxMaskEdBox ID_MEE_EXTS111_PIC;
	public  AxMSMask.AxMaskEdBox ID_MEE_CPS111_PIC;
	public  AxMSMask.AxMaskEdBox ID_MEE_TOFS111_PIC;
	public  AxMSMask.AxMaskEdBox ID_MEE_TDOS111_PIC;
	public  AxMSMask.AxMaskEdBox ID_MEE_SUC_ITB;
	public  AxMSMask.AxMaskEdBox ID_MEE_COR_PIC;
	public  System.Windows.Forms.TextBox ID_MEE_FECS111_EB;
	public  System.Windows.Forms.TextBox ID_MEE_SEXS111_EB;
	public  System.Windows.Forms.TextBox ID_MEE_POBS111_EB;
	public  System.Windows.Forms.TextBox ID_MEE_COLS111_EB;
	public  System.Windows.Forms.TextBox ID_MEE_CNUS111_EB;
	public  System.Windows.Forms.TextBox ID_MEE_NEJS111_EB;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_1;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_0;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_27;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_28;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_16;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_19;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_18;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_15;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_14;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_31;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_13;
	private  System.Windows.Forms.Label _ID_MEE_ETTS111_TXT_12;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_2;
	public  System.Windows.Forms.Panel ID_CEE_PPLS111_PNL;
	public  System.Windows.Forms.TextBox ID_MEE_NUCS111_EB;
	private  System.Windows.Forms.Label _ID_MEE_ETT_TXT_3;
	public  System.Windows.Forms.Panel ID_CEE_SECS111_PNL;
	public System.Windows.Forms.Label[] ID_MEE_ETTS111_TXT = new System.Windows.Forms.Label[13];
	public System.Windows.Forms.Label[] ID_MEE_ETT_TXT = new System.Windows.Forms.Label[32];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cormn111));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_MEE_OK_PB = new System.Windows.Forms.Button();
            this.ID_MEE_CER_PB = new System.Windows.Forms.Button();
            this.ID_CEE_PPLS111_PNL = new System.Windows.Forms.Panel();
            this._ID_MEE_ETT_TXT_0 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_27 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_16 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_28 = new System.Windows.Forms.Label();
            this.ID_MEE_CNUS111_EB = new System.Windows.Forms.TextBox();
            this.ID_MEE_COLS111_EB = new System.Windows.Forms.TextBox();
            this._ID_MEE_ETT_TXT_1 = new System.Windows.Forms.Label();
            this.ID_MEE_NEJS111_EB = new System.Windows.Forms.TextBox();
            this._ID_MEE_ETT_TXT_13 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_31 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_2 = new System.Windows.Forms.Label();
            this._ID_MEE_ETTS111_TXT_12 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_18 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_19 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_14 = new System.Windows.Forms.Label();
            this._ID_MEE_ETT_TXT_15 = new System.Windows.Forms.Label();
            this.ID_MEE_TOFS111_PIC = new AxMSMask.AxMaskEdBox();
            this.ID_MEE_TDOS111_PIC = new AxMSMask.AxMaskEdBox();
            this.ID_MEE_CPS111_PIC = new AxMSMask.AxMaskEdBox();
            this.ID_MEE_EXTS111_PIC = new AxMSMask.AxMaskEdBox();
            this.ID_MEE_SEXS111_EB = new System.Windows.Forms.TextBox();
            this.ID_MEE_POBS111_EB = new System.Windows.Forms.TextBox();
            this.ID_MEE_FECS111_EB = new System.Windows.Forms.TextBox();
            this.ID_MEE_SUC_ITB = new AxMSMask.AxMaskEdBox();
            this.ID_MEE_COR_PIC = new AxMSMask.AxMaskEdBox();
            this.ID_CEE_SECS111_PNL = new System.Windows.Forms.Panel();
            this.ID_MEE_NUCS111_EB = new System.Windows.Forms.TextBox();
            this._ID_MEE_ETT_TXT_3 = new System.Windows.Forms.Label();
            this.ID_CEE_PPLS111_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_TOFS111_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_TDOS111_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_CPS111_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_EXTS111_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_SUC_ITB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_COR_PIC)).BeginInit();
            this.ID_CEE_SECS111_PNL.SuspendLayout();
            this.SuspendLayout();
            // 
            // ID_MEE_OK_PB
            // 
            this.ID_MEE_OK_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEE_OK_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEE_OK_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEE_OK_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_OK_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEE_OK_PB.Location = new System.Drawing.Point(170, 299);
            this.ID_MEE_OK_PB.Name = "ID_MEE_OK_PB";
            this.ID_MEE_OK_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_OK_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEE_OK_PB.TabIndex = 2;
            this.ID_MEE_OK_PB.Tag = "";
            this.ID_MEE_OK_PB.Text = "Consultar";
            this.ID_MEE_OK_PB.UseVisualStyleBackColor = false;
            this.ID_MEE_OK_PB.Click += new System.EventHandler(this.ID_MEE_OK_PB_Click);
            // 
            // ID_MEE_CER_PB
            // 
            this.ID_MEE_CER_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEE_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEE_CER_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_MEE_CER_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEE_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEE_CER_PB.Location = new System.Drawing.Point(269, 299);
            this.ID_MEE_CER_PB.Name = "ID_MEE_CER_PB";
            this.ID_MEE_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_CER_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MEE_CER_PB.TabIndex = 3;
            this.ID_MEE_CER_PB.Tag = "";
            this.ID_MEE_CER_PB.Text = "Salir";
            this.ID_MEE_CER_PB.UseVisualStyleBackColor = false;
            this.ID_MEE_CER_PB.Click += new System.EventHandler(this.ID_MEE_CER_PB_Click);
            // 
            // ID_CEE_PPLS111_PNL
            // 
            this.ID_CEE_PPLS111_PNL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ID_CEE_PPLS111_PNL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_CEE_PPLS111_PNL.Controls.Add(this._ID_MEE_ETT_TXT_0);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this._ID_MEE_ETT_TXT_27);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this._ID_MEE_ETT_TXT_16);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this._ID_MEE_ETT_TXT_28);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this.ID_MEE_CNUS111_EB);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this.ID_MEE_COLS111_EB);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this._ID_MEE_ETT_TXT_1);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this.ID_MEE_NEJS111_EB);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this._ID_MEE_ETT_TXT_13);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this._ID_MEE_ETT_TXT_31);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this._ID_MEE_ETT_TXT_2);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this._ID_MEE_ETTS111_TXT_12);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this._ID_MEE_ETT_TXT_18);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this._ID_MEE_ETT_TXT_19);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this._ID_MEE_ETT_TXT_14);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this._ID_MEE_ETT_TXT_15);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this.ID_MEE_TOFS111_PIC);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this.ID_MEE_TDOS111_PIC);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this.ID_MEE_CPS111_PIC);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this.ID_MEE_EXTS111_PIC);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this.ID_MEE_SEXS111_EB);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this.ID_MEE_POBS111_EB);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this.ID_MEE_FECS111_EB);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this.ID_MEE_SUC_ITB);
            this.ID_CEE_PPLS111_PNL.Controls.Add(this.ID_MEE_COR_PIC);
            this.ID_CEE_PPLS111_PNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_PPLS111_PNL.Location = new System.Drawing.Point(9, 50);
            this.ID_CEE_PPLS111_PNL.Name = "ID_CEE_PPLS111_PNL";
            this.ID_CEE_PPLS111_PNL.Size = new System.Drawing.Size(513, 243);
            this.ID_CEE_PPLS111_PNL.TabIndex = 0;
            this.ID_CEE_PPLS111_PNL.Tag = "";
            this.ID_CEE_PPLS111_PNL.Paint += new System.Windows.Forms.PaintEventHandler(this.ID_CEE_PPLS111_PNL_Paint);
            // 
            // _ID_MEE_ETT_TXT_0
            // 
            this._ID_MEE_ETT_TXT_0.AutoSize = true;
            this._ID_MEE_ETT_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_MEE_ETT_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_0.Location = new System.Drawing.Point(15, 50);
            this._ID_MEE_ETT_TXT_0.Name = "_ID_MEE_ETT_TXT_0";
            this._ID_MEE_ETT_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_0.Size = new System.Drawing.Size(31, 13);
            this._ID_MEE_ETT_TXT_0.TabIndex = 26;
            this._ID_MEE_ETT_TXT_0.Tag = "";
            this._ID_MEE_ETT_TXT_0.Text = "Sexo";
            // 
            // _ID_MEE_ETT_TXT_27
            // 
            this._ID_MEE_ETT_TXT_27.AutoSize = true;
            this._ID_MEE_ETT_TXT_27.BackColor = System.Drawing.Color.Silver;
            this._ID_MEE_ETT_TXT_27.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_27.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_27.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_27.Location = new System.Drawing.Point(400, 195);
            this._ID_MEE_ETT_TXT_27.Name = "_ID_MEE_ETT_TXT_27";
            this._ID_MEE_ETT_TXT_27.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_27.Size = new System.Drawing.Size(68, 13);
            this._ID_MEE_ETT_TXT_27.TabIndex = 25;
            this._ID_MEE_ETT_TXT_27.Tag = "";
            this._ID_MEE_ETT_TXT_27.Text = "&Día de Corte";
            // 
            // _ID_MEE_ETT_TXT_16
            // 
            this._ID_MEE_ETT_TXT_16.BackColor = System.Drawing.Color.Silver;
            this._ID_MEE_ETT_TXT_16.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_16.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_16.Location = new System.Drawing.Point(250, 146);
            this._ID_MEE_ETT_TXT_16.Name = "_ID_MEE_ETT_TXT_16";
            this._ID_MEE_ETT_TXT_16.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_16.Size = new System.Drawing.Size(27, 13);
            this._ID_MEE_ETT_TXT_16.TabIndex = 20;
            this._ID_MEE_ETT_TXT_16.Tag = "";
            this._ID_MEE_ETT_TXT_16.Text = "&C.P.";
            // 
            // _ID_MEE_ETT_TXT_28
            // 
            this._ID_MEE_ETT_TXT_28.BackColor = System.Drawing.Color.Silver;
            this._ID_MEE_ETT_TXT_28.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_28.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_28.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_28.Location = new System.Drawing.Point(249, 195);
            this._ID_MEE_ETT_TXT_28.Name = "_ID_MEE_ETT_TXT_28";
            this._ID_MEE_ETT_TXT_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_28.Size = new System.Drawing.Size(105, 17);
            this._ID_MEE_ETT_TXT_28.TabIndex = 23;
            this._ID_MEE_ETT_TXT_28.Tag = "";
            this._ID_MEE_ETT_TXT_28.Text = "&Sucursal Transmisora";
            // 
            // ID_MEE_CNUS111_EB
            // 
            this.ID_MEE_CNUS111_EB.AcceptsReturn = true;
            this.ID_MEE_CNUS111_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEE_CNUS111_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEE_CNUS111_EB.Enabled = false;
            this.ID_MEE_CNUS111_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_CNUS111_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEE_CNUS111_EB.Location = new System.Drawing.Point(133, 72);
            this.ID_MEE_CNUS111_EB.MaxLength = 35;
            this.ID_MEE_CNUS111_EB.Name = "ID_MEE_CNUS111_EB";
            this.ID_MEE_CNUS111_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_CNUS111_EB.Size = new System.Drawing.Size(301, 20);
            this.ID_MEE_CNUS111_EB.TabIndex = 5;
            this.ID_MEE_CNUS111_EB.Tag = "";
            // 
            // ID_MEE_COLS111_EB
            // 
            this.ID_MEE_COLS111_EB.AcceptsReturn = true;
            this.ID_MEE_COLS111_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEE_COLS111_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEE_COLS111_EB.Enabled = false;
            this.ID_MEE_COLS111_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_COLS111_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEE_COLS111_EB.Location = new System.Drawing.Point(133, 95);
            this.ID_MEE_COLS111_EB.MaxLength = 25;
            this.ID_MEE_COLS111_EB.Name = "ID_MEE_COLS111_EB";
            this.ID_MEE_COLS111_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_COLS111_EB.Size = new System.Drawing.Size(194, 20);
            this.ID_MEE_COLS111_EB.TabIndex = 6;
            this.ID_MEE_COLS111_EB.Tag = "";
            // 
            // _ID_MEE_ETT_TXT_1
            // 
            this._ID_MEE_ETT_TXT_1.AutoSize = true;
            this._ID_MEE_ETT_TXT_1.BackColor = System.Drawing.Color.Silver;
            this._ID_MEE_ETT_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_1.Location = new System.Drawing.Point(15, 199);
            this._ID_MEE_ETT_TXT_1.Name = "_ID_MEE_ETT_TXT_1";
            this._ID_MEE_ETT_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_1.Size = new System.Drawing.Size(73, 13);
            this._ID_MEE_ETT_TXT_1.TabIndex = 30;
            this._ID_MEE_ETT_TXT_1.Tag = "";
            this._ID_MEE_ETT_TXT_1.Text = "Fecha de Alta";
            // 
            // ID_MEE_NEJS111_EB
            // 
            this.ID_MEE_NEJS111_EB.AcceptsReturn = true;
            this.ID_MEE_NEJS111_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEE_NEJS111_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEE_NEJS111_EB.Enabled = false;
            this.ID_MEE_NEJS111_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_NEJS111_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEE_NEJS111_EB.Location = new System.Drawing.Point(133, 24);
            this.ID_MEE_NEJS111_EB.MaxLength = 45;
            this.ID_MEE_NEJS111_EB.Name = "ID_MEE_NEJS111_EB";
            this.ID_MEE_NEJS111_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_NEJS111_EB.Size = new System.Drawing.Size(367, 20);
            this.ID_MEE_NEJS111_EB.TabIndex = 4;
            this.ID_MEE_NEJS111_EB.Tag = "";
            // 
            // _ID_MEE_ETT_TXT_13
            // 
            this._ID_MEE_ETT_TXT_13.AutoSize = true;
            this._ID_MEE_ETT_TXT_13.BackColor = System.Drawing.Color.Silver;
            this._ID_MEE_ETT_TXT_13.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_13.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_13.Location = new System.Drawing.Point(15, 97);
            this._ID_MEE_ETT_TXT_13.Name = "_ID_MEE_ETT_TXT_13";
            this._ID_MEE_ETT_TXT_13.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_13.Size = new System.Drawing.Size(42, 13);
            this._ID_MEE_ETT_TXT_13.TabIndex = 14;
            this._ID_MEE_ETT_TXT_13.Tag = "";
            this._ID_MEE_ETT_TXT_13.Text = "Co&lonia";
            // 
            // _ID_MEE_ETT_TXT_31
            // 
            this._ID_MEE_ETT_TXT_31.AutoSize = true;
            this._ID_MEE_ETT_TXT_31.BackColor = System.Drawing.Color.Silver;
            this._ID_MEE_ETT_TXT_31.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_31.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_31.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_31.Location = new System.Drawing.Point(15, 220);
            this._ID_MEE_ETT_TXT_31.Name = "_ID_MEE_ETT_TXT_31";
            this._ID_MEE_ETT_TXT_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_31.Size = new System.Drawing.Size(36, 13);
            this._ID_MEE_ETT_TXT_31.TabIndex = 15;
            this._ID_MEE_ETT_TXT_31.Tag = "";
            this._ID_MEE_ETT_TXT_31.Text = "&Límite";
            this._ID_MEE_ETT_TXT_31.Visible = false;
            // 
            // _ID_MEE_ETT_TXT_2
            // 
            this._ID_MEE_ETT_TXT_2.AutoSize = true;
            this._ID_MEE_ETT_TXT_2.BackColor = System.Drawing.Color.Silver;
            this._ID_MEE_ETT_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_2.Location = new System.Drawing.Point(15, 27);
            this._ID_MEE_ETT_TXT_2.Name = "_ID_MEE_ETT_TXT_2";
            this._ID_MEE_ETT_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_2.Size = new System.Drawing.Size(44, 13);
            this._ID_MEE_ETT_TXT_2.TabIndex = 12;
            this._ID_MEE_ETT_TXT_2.Tag = "";
            this._ID_MEE_ETT_TXT_2.Text = "No&mbre";
            // 
            // _ID_MEE_ETTS111_TXT_12
            // 
            this._ID_MEE_ETTS111_TXT_12.AutoSize = true;
            this._ID_MEE_ETTS111_TXT_12.BackColor = System.Drawing.Color.Silver;
            this._ID_MEE_ETTS111_TXT_12.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETTS111_TXT_12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETTS111_TXT_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETTS111_TXT_12.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETTS111_TXT_12.Location = new System.Drawing.Point(15, 74);
            this._ID_MEE_ETTS111_TXT_12.Name = "_ID_MEE_ETTS111_TXT_12";
            this._ID_MEE_ETTS111_TXT_12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETTS111_TXT_12.Size = new System.Drawing.Size(78, 13);
            this._ID_MEE_ETTS111_TXT_12.TabIndex = 13;
            this._ID_MEE_ETTS111_TXT_12.Tag = "";
            this._ID_MEE_ETTS111_TXT_12.Text = "C&alle y Número";
            // 
            // _ID_MEE_ETT_TXT_18
            // 
            this._ID_MEE_ETT_TXT_18.AutoSize = true;
            this._ID_MEE_ETT_TXT_18.BackColor = System.Drawing.Color.Silver;
            this._ID_MEE_ETT_TXT_18.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_18.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_18.Location = new System.Drawing.Point(15, 173);
            this._ID_MEE_ETT_TXT_18.Name = "_ID_MEE_ETT_TXT_18";
            this._ID_MEE_ETT_TXT_18.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_18.Size = new System.Drawing.Size(85, 13);
            this._ID_MEE_ETT_TXT_18.TabIndex = 18;
            this._ID_MEE_ETT_TXT_18.Tag = "";
            this._ID_MEE_ETT_TXT_18.Text = "Teléfono &Oficina";
            // 
            // _ID_MEE_ETT_TXT_19
            // 
            this._ID_MEE_ETT_TXT_19.BackColor = System.Drawing.Color.Silver;
            this._ID_MEE_ETT_TXT_19.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_19.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_19.Location = new System.Drawing.Point(250, 171);
            this._ID_MEE_ETT_TXT_19.Name = "_ID_MEE_ETT_TXT_19";
            this._ID_MEE_ETT_TXT_19.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_19.Size = new System.Drawing.Size(59, 17);
            this._ID_MEE_ETT_TXT_19.TabIndex = 19;
            this._ID_MEE_ETT_TXT_19.Tag = "";
            this._ID_MEE_ETT_TXT_19.Text = "E&xtensión";
            // 
            // _ID_MEE_ETT_TXT_14
            // 
            this._ID_MEE_ETT_TXT_14.AutoSize = true;
            this._ID_MEE_ETT_TXT_14.BackColor = System.Drawing.Color.Silver;
            this._ID_MEE_ETT_TXT_14.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_14.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_14.Location = new System.Drawing.Point(15, 121);
            this._ID_MEE_ETT_TXT_14.Name = "_ID_MEE_ETT_TXT_14";
            this._ID_MEE_ETT_TXT_14.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_14.Size = new System.Drawing.Size(54, 13);
            this._ID_MEE_ETT_TXT_14.TabIndex = 16;
            this._ID_MEE_ETT_TXT_14.Tag = "";
            this._ID_MEE_ETT_TXT_14.Text = "&Población";
            // 
            // _ID_MEE_ETT_TXT_15
            // 
            this._ID_MEE_ETT_TXT_15.AutoSize = true;
            this._ID_MEE_ETT_TXT_15.BackColor = System.Drawing.Color.Silver;
            this._ID_MEE_ETT_TXT_15.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_15.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_15.Location = new System.Drawing.Point(15, 147);
            this._ID_MEE_ETT_TXT_15.Name = "_ID_MEE_ETT_TXT_15";
            this._ID_MEE_ETT_TXT_15.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_15.Size = new System.Drawing.Size(94, 13);
            this._ID_MEE_ETT_TXT_15.TabIndex = 17;
            this._ID_MEE_ETT_TXT_15.Tag = "";
            this._ID_MEE_ETT_TXT_15.Text = "Teléfono &Domicilio";
            // 
            // ID_MEE_TOFS111_PIC
            // 
            this.ID_MEE_TOFS111_PIC.Location = new System.Drawing.Point(133, 168);
            this.ID_MEE_TOFS111_PIC.Name = "ID_MEE_TOFS111_PIC";
            this.ID_MEE_TOFS111_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_TOFS111_PIC.OcxState")));
            this.ID_MEE_TOFS111_PIC.Size = new System.Drawing.Size(102, 21);
            this.ID_MEE_TOFS111_PIC.TabIndex = 11;
            this.ID_MEE_TOFS111_PIC.Tag = "";
            this.ID_MEE_TOFS111_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_TOFS111_PIC_KeyPressEvent);
            // 
            // ID_MEE_TDOS111_PIC
            // 
            this.ID_MEE_TDOS111_PIC.Location = new System.Drawing.Point(133, 143);
            this.ID_MEE_TDOS111_PIC.Name = "ID_MEE_TDOS111_PIC";
            this.ID_MEE_TDOS111_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_TDOS111_PIC.OcxState")));
            this.ID_MEE_TDOS111_PIC.Size = new System.Drawing.Size(102, 21);
            this.ID_MEE_TDOS111_PIC.TabIndex = 21;
            this.ID_MEE_TDOS111_PIC.Tag = "";
            this.ID_MEE_TDOS111_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_TDOS111_PIC_KeyPressEvent);
            // 
            // ID_MEE_CPS111_PIC
            // 
            this.ID_MEE_CPS111_PIC.Location = new System.Drawing.Point(361, 142);
            this.ID_MEE_CPS111_PIC.Name = "ID_MEE_CPS111_PIC";
            this.ID_MEE_CPS111_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_CPS111_PIC.OcxState")));
            this.ID_MEE_CPS111_PIC.Size = new System.Drawing.Size(57, 21);
            this.ID_MEE_CPS111_PIC.TabIndex = 10;
            this.ID_MEE_CPS111_PIC.Tag = "";
            this.ID_MEE_CPS111_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_CPS111_PIC_KeyPressEvent);
            // 
            // ID_MEE_EXTS111_PIC
            // 
            this.ID_MEE_EXTS111_PIC.Location = new System.Drawing.Point(361, 169);
            this.ID_MEE_EXTS111_PIC.Name = "ID_MEE_EXTS111_PIC";
            this.ID_MEE_EXTS111_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_EXTS111_PIC.OcxState")));
            this.ID_MEE_EXTS111_PIC.Size = new System.Drawing.Size(57, 21);
            this.ID_MEE_EXTS111_PIC.TabIndex = 8;
            this.ID_MEE_EXTS111_PIC.Tag = "";
            this.ID_MEE_EXTS111_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_EXTS111_PIC_KeyPressEvent);
            // 
            // ID_MEE_SEXS111_EB
            // 
            this.ID_MEE_SEXS111_EB.AcceptsReturn = true;
            this.ID_MEE_SEXS111_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEE_SEXS111_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEE_SEXS111_EB.Enabled = false;
            this.ID_MEE_SEXS111_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_SEXS111_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEE_SEXS111_EB.Location = new System.Drawing.Point(133, 48);
            this.ID_MEE_SEXS111_EB.MaxLength = 0;
            this.ID_MEE_SEXS111_EB.Name = "ID_MEE_SEXS111_EB";
            this.ID_MEE_SEXS111_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_SEXS111_EB.Size = new System.Drawing.Size(95, 20);
            this.ID_MEE_SEXS111_EB.TabIndex = 27;
            this.ID_MEE_SEXS111_EB.Tag = "";
            // 
            // ID_MEE_POBS111_EB
            // 
            this.ID_MEE_POBS111_EB.AcceptsReturn = true;
            this.ID_MEE_POBS111_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEE_POBS111_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEE_POBS111_EB.Enabled = false;
            this.ID_MEE_POBS111_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_POBS111_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEE_POBS111_EB.Location = new System.Drawing.Point(133, 118);
            this.ID_MEE_POBS111_EB.MaxLength = 25;
            this.ID_MEE_POBS111_EB.Name = "ID_MEE_POBS111_EB";
            this.ID_MEE_POBS111_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_POBS111_EB.Size = new System.Drawing.Size(194, 20);
            this.ID_MEE_POBS111_EB.TabIndex = 7;
            this.ID_MEE_POBS111_EB.Tag = "";
            // 
            // ID_MEE_FECS111_EB
            // 
            this.ID_MEE_FECS111_EB.AcceptsReturn = true;
            this.ID_MEE_FECS111_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEE_FECS111_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEE_FECS111_EB.Enabled = false;
            this.ID_MEE_FECS111_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_FECS111_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEE_FECS111_EB.Location = new System.Drawing.Point(133, 194);
            this.ID_MEE_FECS111_EB.MaxLength = 0;
            this.ID_MEE_FECS111_EB.Name = "ID_MEE_FECS111_EB";
            this.ID_MEE_FECS111_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_FECS111_EB.Size = new System.Drawing.Size(73, 20);
            this.ID_MEE_FECS111_EB.TabIndex = 31;
            this.ID_MEE_FECS111_EB.Tag = "";
            // 
            // ID_MEE_SUC_ITB
            // 
            this.ID_MEE_SUC_ITB.Location = new System.Drawing.Point(361, 192);
            this.ID_MEE_SUC_ITB.Name = "ID_MEE_SUC_ITB";
            this.ID_MEE_SUC_ITB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_SUC_ITB.OcxState")));
            this.ID_MEE_SUC_ITB.Size = new System.Drawing.Size(32, 21);
            this.ID_MEE_SUC_ITB.TabIndex = 22;
            this.ID_MEE_SUC_ITB.Tag = "";
            this.ID_MEE_SUC_ITB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_SUC_ITB_KeyPressEvent);
            // 
            // ID_MEE_COR_PIC
            // 
            this.ID_MEE_COR_PIC.Location = new System.Drawing.Point(467, 191);
            this.ID_MEE_COR_PIC.Name = "ID_MEE_COR_PIC";
            this.ID_MEE_COR_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEE_COR_PIC.OcxState")));
            this.ID_MEE_COR_PIC.Size = new System.Drawing.Size(34, 21);
            this.ID_MEE_COR_PIC.TabIndex = 24;
            this.ID_MEE_COR_PIC.Tag = "";
            this.ID_MEE_COR_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MEE_COR_PIC_KeyPressEvent);
            // 
            // ID_CEE_SECS111_PNL
            // 
            this.ID_CEE_SECS111_PNL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ID_CEE_SECS111_PNL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ID_CEE_SECS111_PNL.Controls.Add(this.ID_MEE_NUCS111_EB);
            this.ID_CEE_SECS111_PNL.Controls.Add(this._ID_MEE_ETT_TXT_3);
            this.ID_CEE_SECS111_PNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_SECS111_PNL.Location = new System.Drawing.Point(9, 7);
            this.ID_CEE_SECS111_PNL.Name = "ID_CEE_SECS111_PNL";
            this.ID_CEE_SECS111_PNL.Size = new System.Drawing.Size(514, 41);
            this.ID_CEE_SECS111_PNL.TabIndex = 28;
            this.ID_CEE_SECS111_PNL.Tag = "";
            // 
            // ID_MEE_NUCS111_EB
            // 
            this.ID_MEE_NUCS111_EB.AcceptsReturn = true;
            this.ID_MEE_NUCS111_EB.BackColor = System.Drawing.Color.White;
            this.ID_MEE_NUCS111_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MEE_NUCS111_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEE_NUCS111_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MEE_NUCS111_EB.Location = new System.Drawing.Point(137, 10);
            this.ID_MEE_NUCS111_EB.MaxLength = 16;
            this.ID_MEE_NUCS111_EB.Name = "ID_MEE_NUCS111_EB";
            this.ID_MEE_NUCS111_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEE_NUCS111_EB.Size = new System.Drawing.Size(105, 20);
            this.ID_MEE_NUCS111_EB.TabIndex = 1;
            this.ID_MEE_NUCS111_EB.Tag = "";
            this.ID_MEE_NUCS111_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MEE_NUCS111_EB_KeyPress);
            // 
            // _ID_MEE_ETT_TXT_3
            // 
            this._ID_MEE_ETT_TXT_3.AutoSize = true;
            this._ID_MEE_ETT_TXT_3.BackColor = System.Drawing.Color.Silver;
            this._ID_MEE_ETT_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MEE_ETT_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MEE_ETT_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MEE_ETT_TXT_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MEE_ETT_TXT_3.Location = new System.Drawing.Point(20, 13);
            this._ID_MEE_ETT_TXT_3.Name = "_ID_MEE_ETT_TXT_3";
            this._ID_MEE_ETT_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MEE_ETT_TXT_3.Size = new System.Drawing.Size(96, 13);
            this._ID_MEE_ETT_TXT_3.TabIndex = 29;
            this._ID_MEE_ETT_TXT_3.Tag = "";
            this._ID_MEE_ETT_TXT_3.Text = "Numero de Cuenta";
            // 
            // Cormn111
            // 
            this.AcceptButton = this.ID_MEE_OK_PB;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.ID_MEE_CER_PB;
            this.ClientSize = new System.Drawing.Size(534, 333);
            this.Controls.Add(this.ID_CEE_PPLS111_PNL);
            this.Controls.Add(this.ID_CEE_SECS111_PNL);
            this.Controls.Add(this.ID_MEE_OK_PB);
            this.Controls.Add(this.ID_MEE_CER_PB);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(198, 152);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Cormn111";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Consulta del S111";
            this.Activated += new System.EventHandler(this.Cormn111_Activated);
            this.Closed += new System.EventHandler(this.Cormn111_Closed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cormn111_KeyPress);
            this.ID_CEE_PPLS111_PNL.ResumeLayout(false);
            this.ID_CEE_PPLS111_PNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_TOFS111_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_TDOS111_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_CPS111_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_EXTS111_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_SUC_ITB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEE_COR_PIC)).EndInit();
            this.ID_CEE_SECS111_PNL.ResumeLayout(false);
            this.ID_CEE_SECS111_PNL.PerformLayout();
            this.ResumeLayout(false);

	}
	void  InitializeID_MEE_ETT_TXT()
	{
			this.ID_MEE_ETT_TXT[1] = _ID_MEE_ETT_TXT_1;
			this.ID_MEE_ETT_TXT[0] = _ID_MEE_ETT_TXT_0;
			this.ID_MEE_ETT_TXT[27] = _ID_MEE_ETT_TXT_27;
			this.ID_MEE_ETT_TXT[28] = _ID_MEE_ETT_TXT_28;
			this.ID_MEE_ETT_TXT[16] = _ID_MEE_ETT_TXT_16;
			this.ID_MEE_ETT_TXT[19] = _ID_MEE_ETT_TXT_19;
			this.ID_MEE_ETT_TXT[18] = _ID_MEE_ETT_TXT_18;
			this.ID_MEE_ETT_TXT[15] = _ID_MEE_ETT_TXT_15;
			this.ID_MEE_ETT_TXT[14] = _ID_MEE_ETT_TXT_14;
			this.ID_MEE_ETT_TXT[31] = _ID_MEE_ETT_TXT_31;
			this.ID_MEE_ETT_TXT[13] = _ID_MEE_ETT_TXT_13;
			this.ID_MEE_ETT_TXT[2] = _ID_MEE_ETT_TXT_2;
			this.ID_MEE_ETT_TXT[3] = _ID_MEE_ETT_TXT_3;
	}
	void  InitializeID_MEE_ETTS111_TXT()
	{
			this.ID_MEE_ETTS111_TXT[12] = _ID_MEE_ETTS111_TXT_12;
	}
#endregion 
}
}