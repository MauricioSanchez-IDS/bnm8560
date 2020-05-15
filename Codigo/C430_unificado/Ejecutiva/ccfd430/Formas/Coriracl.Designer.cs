using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORIRACL
	{
	
#region "Upgrade Support "
		private static CORIRACL m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORIRACL DefInstance
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
		public CORIRACL():base(){
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
			InitializeID_IRA_ETI_PNL();
		}
	public static CORIRACL CreateInstance()
	{
			CORIRACL theInstance = new CORIRACL();
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
	public  AxMSMask.AxMaskEdBox ID_IRA_EMP_PIC;
	public  AxMSMask.AxMaskEdBox ID_IRA_FOL_PIC;
	public  AxMSMask.AxMaskEdBox ID_IRA_EJE_PIC;
	public  System.Windows.Forms.Button ID_IRA_OK_PB;
	public  System.Windows.Forms.Button ID_IRA_CAN_PB;
	private  System.Windows.Forms.Label _ID_IRA_ETI_PNL_1Label_Text;
	private  AxThreed.AxSSPanel _ID_IRA_ETI_PNL_1;
	private  System.Windows.Forms.Label _ID_IRA_ETI_PNL_2Label_Text;
	private  AxThreed.AxSSPanel _ID_IRA_ETI_PNL_2;
	private  System.Windows.Forms.Label _ID_IRA_ETI_PNL_0Label_Text;
	private  AxThreed.AxSSPanel _ID_IRA_ETI_PNL_0;
	public AxThreed.AxSSPanel[] ID_IRA_ETI_PNL = new AxThreed.AxSSPanel[3];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORIRACL));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_IRA_EMP_PIC = new AxMSMask.AxMaskEdBox();
        this.ID_IRA_FOL_PIC = new AxMSMask.AxMaskEdBox();
        this.ID_IRA_EJE_PIC = new AxMSMask.AxMaskEdBox();
        this.ID_IRA_OK_PB = new System.Windows.Forms.Button();
        this.ID_IRA_CAN_PB = new System.Windows.Forms.Button();
        this._ID_IRA_ETI_PNL_1 = new AxThreed.AxSSPanel();
        this._ID_IRA_ETI_PNL_1Label_Text = new System.Windows.Forms.Label();
        this._ID_IRA_ETI_PNL_2 = new AxThreed.AxSSPanel();
        this._ID_IRA_ETI_PNL_2Label_Text = new System.Windows.Forms.Label();
        this._ID_IRA_ETI_PNL_0 = new AxThreed.AxSSPanel();
        this._ID_IRA_ETI_PNL_0Label_Text = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.ID_IRA_EMP_PIC)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_IRA_FOL_PIC)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_IRA_EJE_PIC)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_IRA_ETI_PNL_1)).BeginInit();
        this._ID_IRA_ETI_PNL_1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_IRA_ETI_PNL_2)).BeginInit();
        this._ID_IRA_ETI_PNL_2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_IRA_ETI_PNL_0)).BeginInit();
        this._ID_IRA_ETI_PNL_0.SuspendLayout();
        this.SuspendLayout();
        // 
        // ID_IRA_EMP_PIC
        // 
        this.ID_IRA_EMP_PIC.Location = new System.Drawing.Point(205, 8);
        this.ID_IRA_EMP_PIC.Name = "ID_IRA_EMP_PIC";
        this.ID_IRA_EMP_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_IRA_EMP_PIC.OcxState")));
        this.ID_IRA_EMP_PIC.Size = new System.Drawing.Size(55, 22);
        this.ID_IRA_EMP_PIC.TabIndex = 1;
        this.ID_IRA_EMP_PIC.Tag = "";
        this.ID_IRA_EMP_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_IRA_EMP_PIC_KeyPressEvent);
        this.ID_IRA_EMP_PIC.Change += new System.EventHandler(this.ID_IRA_EMP_PIC_Change);
        this.ID_IRA_EMP_PIC.Leave += new System.EventHandler(this.ID_IRA_EMP_PIC_Leave);
        // 
        // ID_IRA_FOL_PIC
        // 
        this.ID_IRA_FOL_PIC.Location = new System.Drawing.Point(204, 60);
        this.ID_IRA_FOL_PIC.Name = "ID_IRA_FOL_PIC";
        this.ID_IRA_FOL_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_IRA_FOL_PIC.OcxState")));
        this.ID_IRA_FOL_PIC.Size = new System.Drawing.Size(56, 22);
        this.ID_IRA_FOL_PIC.TabIndex = 4;
        this.ID_IRA_FOL_PIC.Tag = "";
        this.ID_IRA_FOL_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_IRA_FOL_PIC_KeyPressEvent);
        this.ID_IRA_FOL_PIC.Leave += new System.EventHandler(this.ID_IRA_FOL_PIC_Leave);
        // 
        // ID_IRA_EJE_PIC
        // 
        this.ID_IRA_EJE_PIC.Location = new System.Drawing.Point(204, 34);
        this.ID_IRA_EJE_PIC.Name = "ID_IRA_EJE_PIC";
        this.ID_IRA_EJE_PIC.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_IRA_EJE_PIC.OcxState")));
        this.ID_IRA_EJE_PIC.Size = new System.Drawing.Size(56, 22);
        this.ID_IRA_EJE_PIC.TabIndex = 3;
        this.ID_IRA_EJE_PIC.Tag = "";
        this.ID_IRA_EJE_PIC.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_IRA_EJE_PIC_KeyPressEvent);
        this.ID_IRA_EJE_PIC.Leave += new System.EventHandler(this.ID_IRA_EJE_PIC_Leave);
        // 
        // ID_IRA_OK_PB
        // 
        this.ID_IRA_OK_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_IRA_OK_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_IRA_OK_PB.Enabled = false;
        this.ID_IRA_OK_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_IRA_OK_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_IRA_OK_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_IRA_OK_PB.Location = new System.Drawing.Point(61, 92);
        this.ID_IRA_OK_PB.Name = "ID_IRA_OK_PB";
        this.ID_IRA_OK_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_IRA_OK_PB.Size = new System.Drawing.Size(73, 26);
        this.ID_IRA_OK_PB.TabIndex = 2;
        this.ID_IRA_OK_PB.Tag = "";
        this.ID_IRA_OK_PB.Text = "Aceptar";
        this.ID_IRA_OK_PB.UseVisualStyleBackColor = false;
        this.ID_IRA_OK_PB.Click += new System.EventHandler(this.ID_IRA_OK_PB_Click);
        // 
        // ID_IRA_CAN_PB
        // 
        this.ID_IRA_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_IRA_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_IRA_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_IRA_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_IRA_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_IRA_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_IRA_CAN_PB.Location = new System.Drawing.Point(143, 92);
        this.ID_IRA_CAN_PB.Name = "ID_IRA_CAN_PB";
        this.ID_IRA_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_IRA_CAN_PB.Size = new System.Drawing.Size(73, 27);
        this.ID_IRA_CAN_PB.TabIndex = 5;
        this.ID_IRA_CAN_PB.Tag = "";
        this.ID_IRA_CAN_PB.Text = "Cancelar";
        this.ID_IRA_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_IRA_CAN_PB.Click += new System.EventHandler(this.ID_IRA_CAN_PB_Click);
        // 
        // _ID_IRA_ETI_PNL_1
        // 
        this._ID_IRA_ETI_PNL_1.Controls.Add(this._ID_IRA_ETI_PNL_1Label_Text);
        this._ID_IRA_ETI_PNL_1.Location = new System.Drawing.Point(10, 9);
        this._ID_IRA_ETI_PNL_1.Name = "_ID_IRA_ETI_PNL_1";
        this._ID_IRA_ETI_PNL_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_IRA_ETI_PNL_1.OcxState")));
        this._ID_IRA_ETI_PNL_1.Size = new System.Drawing.Size(188, 20);
        this._ID_IRA_ETI_PNL_1.TabIndex = 0;
        this._ID_IRA_ETI_PNL_1.Tag = "";
        // 
        // _ID_IRA_ETI_PNL_1Label_Text
        // 
        this._ID_IRA_ETI_PNL_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_IRA_ETI_PNL_1Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_IRA_ETI_PNL_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_IRA_ETI_PNL_1Label_Text.Location = new System.Drawing.Point(0, 0);
        this._ID_IRA_ETI_PNL_1Label_Text.Name = "_ID_IRA_ETI_PNL_1Label_Text";
        this._ID_IRA_ETI_PNL_1Label_Text.Size = new System.Drawing.Size(188, 20);
        this._ID_IRA_ETI_PNL_1Label_Text.TabIndex = 0;
        this._ID_IRA_ETI_PNL_1Label_Text.Tag = "";
        this._ID_IRA_ETI_PNL_1Label_Text.Text = "Teclee el Número de la E&mpresa";
        this._ID_IRA_ETI_PNL_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // _ID_IRA_ETI_PNL_2
        // 
        this._ID_IRA_ETI_PNL_2.Controls.Add(this._ID_IRA_ETI_PNL_2Label_Text);
        this._ID_IRA_ETI_PNL_2.Location = new System.Drawing.Point(10, 36);
        this._ID_IRA_ETI_PNL_2.Name = "_ID_IRA_ETI_PNL_2";
        this._ID_IRA_ETI_PNL_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_IRA_ETI_PNL_2.OcxState")));
        this._ID_IRA_ETI_PNL_2.Size = new System.Drawing.Size(181, 19);
        this._ID_IRA_ETI_PNL_2.TabIndex = 6;
        this._ID_IRA_ETI_PNL_2.Tag = "";
        // 
        // _ID_IRA_ETI_PNL_2Label_Text
        // 
        this._ID_IRA_ETI_PNL_2Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_IRA_ETI_PNL_2Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_IRA_ETI_PNL_2Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_IRA_ETI_PNL_2Label_Text.Location = new System.Drawing.Point(0, 0);
        this._ID_IRA_ETI_PNL_2Label_Text.Name = "_ID_IRA_ETI_PNL_2Label_Text";
        this._ID_IRA_ETI_PNL_2Label_Text.Size = new System.Drawing.Size(181, 19);
        this._ID_IRA_ETI_PNL_2Label_Text.TabIndex = 0;
        this._ID_IRA_ETI_PNL_2Label_Text.Tag = "";
        this._ID_IRA_ETI_PNL_2Label_Text.Text = "Teclee el Número de E&jecutivo      ";
        this._ID_IRA_ETI_PNL_2Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // _ID_IRA_ETI_PNL_0
        // 
        this._ID_IRA_ETI_PNL_0.Controls.Add(this._ID_IRA_ETI_PNL_0Label_Text);
        this._ID_IRA_ETI_PNL_0.Location = new System.Drawing.Point(10, 63);
        this._ID_IRA_ETI_PNL_0.Name = "_ID_IRA_ETI_PNL_0";
        this._ID_IRA_ETI_PNL_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_IRA_ETI_PNL_0.OcxState")));
        this._ID_IRA_ETI_PNL_0.Size = new System.Drawing.Size(154, 18);
        this._ID_IRA_ETI_PNL_0.TabIndex = 7;
        this._ID_IRA_ETI_PNL_0.Tag = "";
        // 
        // _ID_IRA_ETI_PNL_0Label_Text
        // 
        this._ID_IRA_ETI_PNL_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_IRA_ETI_PNL_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_IRA_ETI_PNL_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_IRA_ETI_PNL_0Label_Text.Location = new System.Drawing.Point(0, 0);
        this._ID_IRA_ETI_PNL_0Label_Text.Name = "_ID_IRA_ETI_PNL_0Label_Text";
        this._ID_IRA_ETI_PNL_0Label_Text.Size = new System.Drawing.Size(154, 18);
        this._ID_IRA_ETI_PNL_0Label_Text.TabIndex = 0;
        this._ID_IRA_ETI_PNL_0Label_Text.Tag = "";
        this._ID_IRA_ETI_PNL_0Label_Text.Text = "Teclee el Número de &Folio";
        this._ID_IRA_ETI_PNL_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // CORIRACL
        // 
        this.AcceptButton = this.ID_IRA_OK_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.CancelButton = this.ID_IRA_CAN_PB;
        this.ClientSize = new System.Drawing.Size(265, 129);
        this.Controls.Add(this._ID_IRA_ETI_PNL_1);
        this.Controls.Add(this.ID_IRA_EMP_PIC);
        this.Controls.Add(this.ID_IRA_FOL_PIC);
        this.Controls.Add(this.ID_IRA_EJE_PIC);
        this.Controls.Add(this.ID_IRA_OK_PB);
        this.Controls.Add(this.ID_IRA_CAN_PB);
        this.Controls.Add(this._ID_IRA_ETI_PNL_2);
        this.Controls.Add(this._ID_IRA_ETI_PNL_0);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Location = new System.Drawing.Point(256, 251);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORIRACL";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Ir a...";
        this.Closed += new System.EventHandler(this.CORIRACL_Closed);
        this.Activated += new System.EventHandler(this.CORIRACL_Activated);
        ((System.ComponentModel.ISupportInitialize)(this.ID_IRA_EMP_PIC)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_IRA_FOL_PIC)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_IRA_EJE_PIC)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_IRA_ETI_PNL_1)).EndInit();
        this._ID_IRA_ETI_PNL_1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_IRA_ETI_PNL_2)).EndInit();
        this._ID_IRA_ETI_PNL_2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_IRA_ETI_PNL_0)).EndInit();
        this._ID_IRA_ETI_PNL_0.ResumeLayout(false);
        this.ResumeLayout(false);

	}
	void  InitializeID_IRA_ETI_PNL()
	{
			this.ID_IRA_ETI_PNL[1] = _ID_IRA_ETI_PNL_1;
			this.ID_IRA_ETI_PNL[2] = _ID_IRA_ETI_PNL_2;
			this.ID_IRA_ETI_PNL[0] = _ID_IRA_ETI_PNL_0;
	}
#endregion 
}
}