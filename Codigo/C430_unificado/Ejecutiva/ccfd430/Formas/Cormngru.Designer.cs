using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORMNGRU
	{
	
#region "Upgrade Support "
		private static CORMNGRU m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORMNGRU DefInstance
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
		public CORMNGRU():base(){
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
			InitializeID_MGR_ETI_TXT();
		}
	public static CORMNGRU CreateInstance()
	{
			CORMNGRU theInstance = new CORMNGRU();
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
	public  System.Windows.Forms.Button ID_MGR_IMP_PB;
	public  System.Windows.Forms.Button ID_MGR_OK_PB;
	public  System.Windows.Forms.Button ID_MGR_CAN_PB;
	public  System.Windows.Forms.ComboBox ID_MGR_EDO_EB;
        public AxMSMask.AxMaskEdBox ID_MGR_CP_PIC;
	public  System.Windows.Forms.TextBox ID_MGR_CIU_EB;
	public  System.Windows.Forms.TextBox ID_MGR_POB_EB;
	public  System.Windows.Forms.TextBox ID_MGR_COL_EB;
	public  System.Windows.Forms.TextBox ID_MGR_DOM_EB;
	public  System.Windows.Forms.TextBox ID_MGR_GRP_EB;
        public System.Windows.Forms.Label ID_MGR_TEX_PNL;
	public  System.Windows.Forms.Label ID_MGR_CTA_PNL;
	public  AxMSMask.AxMaskEdBox ID_MGR_VEN_CRD_DTB;
        public System.Windows.Forms.Label Label3;
	private  System.Windows.Forms.Label _ID_MGR_ETI_TXT_6;
	private  System.Windows.Forms.Label _ID_MGR_ETI_TXT_5;
	private  System.Windows.Forms.Label _ID_MGR_ETI_TXT_4;
	private  System.Windows.Forms.Label _ID_MGR_ETI_TXT_3;
	private  System.Windows.Forms.Label _ID_MGR_ETI_TXT_2;
	private  System.Windows.Forms.Label _ID_MGR_ETI_TXT_1;
	private  System.Windows.Forms.Label _ID_MGR_ETI_TXT_0;
	public  AxThreed.AxSSPanel ID_MGR_SEC_PNL;
	public System.Windows.Forms.Label[] ID_MGR_ETI_TXT = new System.Windows.Forms.Label[7];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORMNGRU));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_MGR_IMP_PB = new System.Windows.Forms.Button();
            this.ID_MGR_OK_PB = new System.Windows.Forms.Button();
            this.ID_MGR_CAN_PB = new System.Windows.Forms.Button();
            this.ID_MGR_SEC_PNL = new AxThreed.AxSSPanel();
            this.ID_MGR_VEN_CRD_DTB = new AxMSMask.AxMaskEdBox();
            this.ID_MGR_GRP_EB = new System.Windows.Forms.TextBox();
            this.ID_MGR_CTA_PNL = new System.Windows.Forms.Label();
            this.ID_MGR_TEX_PNL = new System.Windows.Forms.Label();
            this._ID_MGR_ETI_TXT_2 = new System.Windows.Forms.Label();
            this._ID_MGR_ETI_TXT_1 = new System.Windows.Forms.Label();
            this._ID_MGR_ETI_TXT_0 = new System.Windows.Forms.Label();
            this._ID_MGR_ETI_TXT_3 = new System.Windows.Forms.Label();
            this._ID_MGR_ETI_TXT_6 = new System.Windows.Forms.Label();
            this._ID_MGR_ETI_TXT_5 = new System.Windows.Forms.Label();
            this._ID_MGR_ETI_TXT_4 = new System.Windows.Forms.Label();
            this.ID_MGR_EDO_EB = new System.Windows.Forms.ComboBox();
            this.ID_MGR_CP_PIC = new AxMSMask.AxMaskEdBox();
            this.ID_MGR_COL_EB = new System.Windows.Forms.TextBox();
            this.ID_MGR_DOM_EB = new System.Windows.Forms.TextBox();
            this.ID_MGR_CIU_EB = new System.Windows.Forms.TextBox();
            this.ID_MGR_POB_EB = new System.Windows.Forms.TextBox();
            this.Label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MGR_SEC_PNL)).BeginInit();
            this.ID_MGR_SEC_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MGR_VEN_CRD_DTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MGR_CP_PIC)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_MGR_IMP_PB
            // 
            this.ID_MGR_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MGR_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MGR_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MGR_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MGR_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MGR_IMP_PB.Location = new System.Drawing.Point(317, 218);
            this.ID_MGR_IMP_PB.Name = "ID_MGR_IMP_PB";
            this.ID_MGR_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MGR_IMP_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MGR_IMP_PB.TabIndex = 25;
            this.ID_MGR_IMP_PB.Tag = "";
            this.ID_MGR_IMP_PB.Text = "&Imprimir";
            this.ID_MGR_IMP_PB.UseVisualStyleBackColor = false;
            this.ID_MGR_IMP_PB.Click += new System.EventHandler(this.ID_MGR_IMP_PB_Click);
            // 
            // ID_MGR_OK_PB
            // 
            this.ID_MGR_OK_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MGR_OK_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MGR_OK_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MGR_OK_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MGR_OK_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MGR_OK_PB.Location = new System.Drawing.Point(162, 218);
            this.ID_MGR_OK_PB.Name = "ID_MGR_OK_PB";
            this.ID_MGR_OK_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MGR_OK_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MGR_OK_PB.TabIndex = 23;
            this.ID_MGR_OK_PB.Tag = "";
            this.ID_MGR_OK_PB.Text = "Aceptar";
            this.ID_MGR_OK_PB.UseVisualStyleBackColor = false;
            this.ID_MGR_OK_PB.Click += new System.EventHandler(this.ID_MGR_OK_PB_Click);
            // 
            // ID_MGR_CAN_PB
            // 
            this.ID_MGR_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MGR_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MGR_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_MGR_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MGR_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MGR_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MGR_CAN_PB.Location = new System.Drawing.Point(239, 219);
            this.ID_MGR_CAN_PB.Name = "ID_MGR_CAN_PB";
            this.ID_MGR_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MGR_CAN_PB.Size = new System.Drawing.Size(74, 22);
            this.ID_MGR_CAN_PB.TabIndex = 24;
            this.ID_MGR_CAN_PB.Tag = "";
            this.ID_MGR_CAN_PB.Text = "Cancelar";
            this.ID_MGR_CAN_PB.UseVisualStyleBackColor = false;
            this.ID_MGR_CAN_PB.Click += new System.EventHandler(this.ID_MGR_CAN_PB_Click);
            // 
            // ID_MGR_SEC_PNL
            // 
            this.ID_MGR_SEC_PNL.Controls.Add(this.ID_MGR_VEN_CRD_DTB);
            this.ID_MGR_SEC_PNL.Controls.Add(this.ID_MGR_GRP_EB);
            this.ID_MGR_SEC_PNL.Controls.Add(this.ID_MGR_CTA_PNL);
            this.ID_MGR_SEC_PNL.Controls.Add(this.ID_MGR_TEX_PNL);
            this.ID_MGR_SEC_PNL.Controls.Add(this._ID_MGR_ETI_TXT_2);
            this.ID_MGR_SEC_PNL.Controls.Add(this._ID_MGR_ETI_TXT_1);
            this.ID_MGR_SEC_PNL.Controls.Add(this._ID_MGR_ETI_TXT_0);
            this.ID_MGR_SEC_PNL.Controls.Add(this._ID_MGR_ETI_TXT_3);
            this.ID_MGR_SEC_PNL.Controls.Add(this._ID_MGR_ETI_TXT_6);
            this.ID_MGR_SEC_PNL.Controls.Add(this._ID_MGR_ETI_TXT_5);
            this.ID_MGR_SEC_PNL.Controls.Add(this._ID_MGR_ETI_TXT_4);
            this.ID_MGR_SEC_PNL.Controls.Add(this.ID_MGR_EDO_EB);
            this.ID_MGR_SEC_PNL.Controls.Add(this.ID_MGR_CP_PIC);
            this.ID_MGR_SEC_PNL.Controls.Add(this.ID_MGR_COL_EB);
            this.ID_MGR_SEC_PNL.Controls.Add(this.ID_MGR_DOM_EB);
            this.ID_MGR_SEC_PNL.Controls.Add(this.ID_MGR_CIU_EB);
            this.ID_MGR_SEC_PNL.Controls.Add(this.ID_MGR_POB_EB);
            this.ID_MGR_SEC_PNL.Location = new System.Drawing.Point(9, 7);
            this.ID_MGR_SEC_PNL.Name = "ID_MGR_SEC_PNL";
            this.ID_MGR_SEC_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MGR_SEC_PNL.OcxState")));
            this.ID_MGR_SEC_PNL.Size = new System.Drawing.Size(522, 204);
            this.ID_MGR_SEC_PNL.TabIndex = 0;
            this.ID_MGR_SEC_PNL.Tag = "";
            // 
            // ID_MGR_VEN_CRD_DTB
            // 
            this.ID_MGR_VEN_CRD_DTB.Location = new System.Drawing.Point(423, 168);
            this.ID_MGR_VEN_CRD_DTB.Name = "ID_MGR_VEN_CRD_DTB";
            this.ID_MGR_VEN_CRD_DTB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MGR_VEN_CRD_DTB.OcxState")));
            this.ID_MGR_VEN_CRD_DTB.Size = new System.Drawing.Size(78, 23);
            this.ID_MGR_VEN_CRD_DTB.TabIndex = 22;
            this.ID_MGR_VEN_CRD_DTB.Tag = "";
            this.ID_MGR_VEN_CRD_DTB.Enter += new System.EventHandler(this.ID_MGR_VEN_CRD_DTB_Enter);
            this.ID_MGR_VEN_CRD_DTB.Validating += new System.ComponentModel.CancelEventHandler(this.ID_MGR_VEN_CRD_DTB_Validating);
            // 
            // ID_MGR_GRP_EB
            // 
            this.ID_MGR_GRP_EB.AcceptsReturn = true;
            this.ID_MGR_GRP_EB.BackColor = System.Drawing.Color.White;
            this.ID_MGR_GRP_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MGR_GRP_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MGR_GRP_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MGR_GRP_EB.Location = new System.Drawing.Point(114, 35);
            this.ID_MGR_GRP_EB.MaxLength = 35;
            this.ID_MGR_GRP_EB.Name = "ID_MGR_GRP_EB";
            this.ID_MGR_GRP_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MGR_GRP_EB.Size = new System.Drawing.Size(397, 20);
            this.ID_MGR_GRP_EB.TabIndex = 4;
            this.ID_MGR_GRP_EB.Tag = "";
            this.ID_MGR_GRP_EB.Click += new System.EventHandler(this.HandleSelection_Click);
            this.ID_MGR_GRP_EB.Enter += new System.EventHandler(this.ID_MGR_GRP_EB_Enter);
            this.ID_MGR_GRP_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MGR_GRP_EB_KeyPress);
            this.ID_MGR_GRP_EB.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // ID_MGR_CTA_PNL
            // 
            this.ID_MGR_CTA_PNL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ID_MGR_CTA_PNL.Location = new System.Drawing.Point(440, 5);
            this.ID_MGR_CTA_PNL.Name = "ID_MGR_CTA_PNL";
            this.ID_MGR_CTA_PNL.Size = new System.Drawing.Size(71, 24);
            this.ID_MGR_CTA_PNL.TabIndex = 2;
            this.ID_MGR_CTA_PNL.Tag = "";
            this.ID_MGR_CTA_PNL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ID_MGR_TEX_PNL
            // 
            this.ID_MGR_TEX_PNL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ID_MGR_TEX_PNL.Location = new System.Drawing.Point(345, 5);
            this.ID_MGR_TEX_PNL.Name = "ID_MGR_TEX_PNL";
            this.ID_MGR_TEX_PNL.Size = new System.Drawing.Size(90, 24);
            this.ID_MGR_TEX_PNL.TabIndex = 0;
            this.ID_MGR_TEX_PNL.Tag = "";
            this.ID_MGR_TEX_PNL.Text = "No. Asignado";
            this.ID_MGR_TEX_PNL.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _ID_MGR_ETI_TXT_2
            // 
            this._ID_MGR_ETI_TXT_2.BackColor = System.Drawing.Color.Silver;
            this._ID_MGR_ETI_TXT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MGR_ETI_TXT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MGR_ETI_TXT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MGR_ETI_TXT_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MGR_ETI_TXT_2.Location = new System.Drawing.Point(11, 91);
            this._ID_MGR_ETI_TXT_2.Name = "_ID_MGR_ETI_TXT_2";
            this._ID_MGR_ETI_TXT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MGR_ETI_TXT_2.Size = new System.Drawing.Size(103, 15);
            this._ID_MGR_ETI_TXT_2.TabIndex = 7;
            this._ID_MGR_ETI_TXT_2.Tag = "";
            this._ID_MGR_ETI_TXT_2.Text = "Co&lonia";
            // 
            // _ID_MGR_ETI_TXT_1
            // 
            this._ID_MGR_ETI_TXT_1.BackColor = System.Drawing.Color.Silver;
            this._ID_MGR_ETI_TXT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MGR_ETI_TXT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MGR_ETI_TXT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MGR_ETI_TXT_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MGR_ETI_TXT_1.Location = new System.Drawing.Point(11, 65);
            this._ID_MGR_ETI_TXT_1.Name = "_ID_MGR_ETI_TXT_1";
            this._ID_MGR_ETI_TXT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MGR_ETI_TXT_1.Size = new System.Drawing.Size(151, 15);
            this._ID_MGR_ETI_TXT_1.TabIndex = 5;
            this._ID_MGR_ETI_TXT_1.Tag = "";
            this._ID_MGR_ETI_TXT_1.Text = "&Domicilio (Calle y Número)";
            // 
            // _ID_MGR_ETI_TXT_0
            // 
            this._ID_MGR_ETI_TXT_0.BackColor = System.Drawing.Color.Silver;
            this._ID_MGR_ETI_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MGR_ETI_TXT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MGR_ETI_TXT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MGR_ETI_TXT_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MGR_ETI_TXT_0.Location = new System.Drawing.Point(11, 37);
            this._ID_MGR_ETI_TXT_0.Name = "_ID_MGR_ETI_TXT_0";
            this._ID_MGR_ETI_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MGR_ETI_TXT_0.Size = new System.Drawing.Size(101, 17);
            this._ID_MGR_ETI_TXT_0.TabIndex = 3;
            this._ID_MGR_ETI_TXT_0.Tag = "";
            this._ID_MGR_ETI_TXT_0.Text = "&Nombre";
            // 
            // _ID_MGR_ETI_TXT_3
            // 
            this._ID_MGR_ETI_TXT_3.BackColor = System.Drawing.Color.Silver;
            this._ID_MGR_ETI_TXT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MGR_ETI_TXT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MGR_ETI_TXT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MGR_ETI_TXT_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MGR_ETI_TXT_3.Location = new System.Drawing.Point(11, 118);
            this._ID_MGR_ETI_TXT_3.Name = "_ID_MGR_ETI_TXT_3";
            this._ID_MGR_ETI_TXT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MGR_ETI_TXT_3.Size = new System.Drawing.Size(103, 15);
            this._ID_MGR_ETI_TXT_3.TabIndex = 9;
            this._ID_MGR_ETI_TXT_3.Tag = "";
            this._ID_MGR_ETI_TXT_3.Text = "&Pob./Del./Mun.";
            // 
            // _ID_MGR_ETI_TXT_6
            // 
            this._ID_MGR_ETI_TXT_6.BackColor = System.Drawing.Color.Silver;
            this._ID_MGR_ETI_TXT_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MGR_ETI_TXT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MGR_ETI_TXT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MGR_ETI_TXT_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MGR_ETI_TXT_6.Location = new System.Drawing.Point(319, 145);
            this._ID_MGR_ETI_TXT_6.Name = "_ID_MGR_ETI_TXT_6";
            this._ID_MGR_ETI_TXT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MGR_ETI_TXT_6.Size = new System.Drawing.Size(42, 15);
            this._ID_MGR_ETI_TXT_6.TabIndex = 13;
            this._ID_MGR_ETI_TXT_6.Tag = "";
            this._ID_MGR_ETI_TXT_6.Text = "&Estado";
            // 
            // _ID_MGR_ETI_TXT_5
            // 
            this._ID_MGR_ETI_TXT_5.BackColor = System.Drawing.Color.Silver;
            this._ID_MGR_ETI_TXT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MGR_ETI_TXT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MGR_ETI_TXT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MGR_ETI_TXT_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MGR_ETI_TXT_5.Location = new System.Drawing.Point(11, 171);
            this._ID_MGR_ETI_TXT_5.Name = "_ID_MGR_ETI_TXT_5";
            this._ID_MGR_ETI_TXT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MGR_ETI_TXT_5.Size = new System.Drawing.Size(101, 17);
            this._ID_MGR_ETI_TXT_5.TabIndex = 15;
            this._ID_MGR_ETI_TXT_5.Tag = "";
            this._ID_MGR_ETI_TXT_5.Text = "&C.P";
            // 
            // _ID_MGR_ETI_TXT_4
            // 
            this._ID_MGR_ETI_TXT_4.BackColor = System.Drawing.Color.Silver;
            this._ID_MGR_ETI_TXT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._ID_MGR_ETI_TXT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_MGR_ETI_TXT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_MGR_ETI_TXT_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._ID_MGR_ETI_TXT_4.Location = new System.Drawing.Point(11, 145);
            this._ID_MGR_ETI_TXT_4.Name = "_ID_MGR_ETI_TXT_4";
            this._ID_MGR_ETI_TXT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._ID_MGR_ETI_TXT_4.Size = new System.Drawing.Size(103, 15);
            this._ID_MGR_ETI_TXT_4.TabIndex = 11;
            this._ID_MGR_ETI_TXT_4.Tag = "";
            this._ID_MGR_ETI_TXT_4.Text = "C&iudad";
            // 
            // ID_MGR_EDO_EB
            // 
            this.ID_MGR_EDO_EB.BackColor = System.Drawing.SystemColors.Window;
            this.ID_MGR_EDO_EB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MGR_EDO_EB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_MGR_EDO_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MGR_EDO_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MGR_EDO_EB.Location = new System.Drawing.Point(368, 142);
            this.ID_MGR_EDO_EB.Name = "ID_MGR_EDO_EB";
            this.ID_MGR_EDO_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MGR_EDO_EB.Size = new System.Drawing.Size(134, 21);
            this.ID_MGR_EDO_EB.TabIndex = 14;
            this.ID_MGR_EDO_EB.Tag = "";
            this.ID_MGR_EDO_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MGR_EDO_EB_KeyPress);
            this.ID_MGR_EDO_EB.Validating += new System.ComponentModel.CancelEventHandler(this.ID_MGR_EDO_EB_Validating);
            // 
            // ID_MGR_CP_PIC
            // 
            this.ID_MGR_CP_PIC.Location = new System.Drawing.Point(114, 169);
            this.ID_MGR_CP_PIC.Name = "ID_MGR_CP_PIC";
            this.ID_MGR_CP_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MGR_CP_PIC.OcxState")));
            this.ID_MGR_CP_PIC.Size = new System.Drawing.Size(48, 22);
            this.ID_MGR_CP_PIC.TabIndex = 16;
            this.ID_MGR_CP_PIC.Tag = "";
            this.ID_MGR_CP_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_MGR_CP_PIC_KeyPressEvent);
            this.ID_MGR_CP_PIC.Enter += new System.EventHandler(this.ID_MGR_CP_PIC_Enter);
            this.ID_MGR_CP_PIC.Leave += new System.EventHandler(this.ID_MGR_CP_PIC_Leave);
            // 
            // ID_MGR_COL_EB
            // 
            this.ID_MGR_COL_EB.AcceptsReturn = true;
            this.ID_MGR_COL_EB.BackColor = System.Drawing.Color.White;
            this.ID_MGR_COL_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MGR_COL_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MGR_COL_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MGR_COL_EB.Location = new System.Drawing.Point(114, 89);
            this.ID_MGR_COL_EB.MaxLength = 25;
            this.ID_MGR_COL_EB.Name = "ID_MGR_COL_EB";
            this.ID_MGR_COL_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MGR_COL_EB.Size = new System.Drawing.Size(285, 20);
            this.ID_MGR_COL_EB.TabIndex = 8;
            this.ID_MGR_COL_EB.Tag = "";
            this.ID_MGR_COL_EB.Click += new System.EventHandler(this.HandleSelection_Click);
            this.ID_MGR_COL_EB.Enter += new System.EventHandler(this.ID_MGR_COL_EB_Enter);
            this.ID_MGR_COL_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MGR_COL_EB_KeyPress);
            this.ID_MGR_COL_EB.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // ID_MGR_DOM_EB
            // 
            this.ID_MGR_DOM_EB.AcceptsReturn = true;
            this.ID_MGR_DOM_EB.BackColor = System.Drawing.Color.White;
            this.ID_MGR_DOM_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MGR_DOM_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MGR_DOM_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MGR_DOM_EB.Location = new System.Drawing.Point(168, 62);
            this.ID_MGR_DOM_EB.MaxLength = 35;
            this.ID_MGR_DOM_EB.Name = "ID_MGR_DOM_EB";
            this.ID_MGR_DOM_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MGR_DOM_EB.Size = new System.Drawing.Size(331, 20);
            this.ID_MGR_DOM_EB.TabIndex = 6;
            this.ID_MGR_DOM_EB.Tag = "";
            this.ID_MGR_DOM_EB.Click += new System.EventHandler(this.HandleSelection_Click);
            this.ID_MGR_DOM_EB.Enter += new System.EventHandler(this.ID_MGR_DOM_EB_Enter);
            this.ID_MGR_DOM_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MGR_DOM_EB_KeyPress);
            this.ID_MGR_DOM_EB.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // ID_MGR_CIU_EB
            // 
            this.ID_MGR_CIU_EB.AcceptsReturn = true;
            this.ID_MGR_CIU_EB.BackColor = System.Drawing.Color.White;
            this.ID_MGR_CIU_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MGR_CIU_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MGR_CIU_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MGR_CIU_EB.Location = new System.Drawing.Point(114, 142);
            this.ID_MGR_CIU_EB.MaxLength = 25;
            this.ID_MGR_CIU_EB.Name = "ID_MGR_CIU_EB";
            this.ID_MGR_CIU_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MGR_CIU_EB.Size = new System.Drawing.Size(196, 20);
            this.ID_MGR_CIU_EB.TabIndex = 12;
            this.ID_MGR_CIU_EB.Tag = "";
            this.ID_MGR_CIU_EB.Click += new System.EventHandler(this.HandleSelection_Click);
            this.ID_MGR_CIU_EB.Enter += new System.EventHandler(this.ID_MGR_CIU_EB_Enter);
            this.ID_MGR_CIU_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MGR_CIU_EB_KeyPress);
            this.ID_MGR_CIU_EB.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // ID_MGR_POB_EB
            // 
            this.ID_MGR_POB_EB.AcceptsReturn = true;
            this.ID_MGR_POB_EB.BackColor = System.Drawing.Color.White;
            this.ID_MGR_POB_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_MGR_POB_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MGR_POB_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_MGR_POB_EB.Location = new System.Drawing.Point(114, 116);
            this.ID_MGR_POB_EB.MaxLength = 25;
            this.ID_MGR_POB_EB.Name = "ID_MGR_POB_EB";
            this.ID_MGR_POB_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MGR_POB_EB.Size = new System.Drawing.Size(285, 20);
            this.ID_MGR_POB_EB.TabIndex = 10;
            this.ID_MGR_POB_EB.Tag = "";
            this.ID_MGR_POB_EB.Click += new System.EventHandler(this.HandleSelection_Click);
            this.ID_MGR_POB_EB.Enter += new System.EventHandler(this.ID_MGR_POB_EB_Enter);
            this.ID_MGR_POB_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_MGR_POB_EB_KeyPress);
            this.ID_MGR_POB_EB.MouseEnter += new System.EventHandler(this.HandleSelection_MouseEnter);
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.BackColor = System.Drawing.Color.Silver;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(205, 182);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(221, 13);
            this.Label3.TabIndex = 21;
            this.Label3.Tag = "";
            this.Label3.Text = "Vencimiento del Credito (dd/mm/yyyy)";
            // 
            // CORMNGRU
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(543, 262);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.ID_MGR_CAN_PB);
            this.Controls.Add(this.ID_MGR_OK_PB);
            this.Controls.Add(this.ID_MGR_IMP_PB);
            this.Controls.Add(this.ID_MGR_SEC_PNL);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(88, 117);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORMNGRU";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Corporativos";
            this.Activated += new System.EventHandler(this.CORMNGRU_Activated);
            this.Closed += new System.EventHandler(this.CORMNGRU_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.ID_MGR_SEC_PNL)).EndInit();
            this.ID_MGR_SEC_PNL.ResumeLayout(false);
            this.ID_MGR_SEC_PNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MGR_VEN_CRD_DTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_MGR_CP_PIC)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
	void  InitializeID_MGR_ETI_TXT()
	{
			this.ID_MGR_ETI_TXT[6] = _ID_MGR_ETI_TXT_6;
			this.ID_MGR_ETI_TXT[5] = _ID_MGR_ETI_TXT_5;
			this.ID_MGR_ETI_TXT[4] = _ID_MGR_ETI_TXT_4;
			this.ID_MGR_ETI_TXT[3] = _ID_MGR_ETI_TXT_3;
			this.ID_MGR_ETI_TXT[2] = _ID_MGR_ETI_TXT_2;
			this.ID_MGR_ETI_TXT[1] = _ID_MGR_ETI_TXT_1;
			this.ID_MGR_ETI_TXT[0] = _ID_MGR_ETI_TXT_0;
	}
#endregion 
}
}