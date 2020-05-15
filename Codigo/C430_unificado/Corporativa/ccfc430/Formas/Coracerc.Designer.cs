using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORACERC
	{
	
#region "Upgrade Support "
		private static CORACERC m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORACERC DefInstance
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
		public CORACERC():base(){
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
		}
	public static CORACERC CreateInstance()
	{
			CORACERC theInstance = new CORACERC();
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
	public  System.Windows.Forms.Button ID_ACE_OK_PB;
	public  System.Windows.Forms.Label ID_ACE_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_ACE_PNL;
	public  System.Windows.Forms.PictureBox ID_ACE_LOG1_IMG;
	public  System.Windows.Forms.Label ID_ACE_ETI2_TXT;
	public  System.Windows.Forms.Label ID_ACE_ETI1_TXT;
	public  System.Windows.Forms.Label ID_ACE_BAN_TXT;
	public  System.Windows.Forms.Label ID_ACE_DER_TXT;
	public  System.Windows.Forms.Label ID_ACE_LIN;
	public  System.Windows.Forms.Label ID_ACE_ETI3_TXT;
	public  System.Windows.Forms.PictureBox ID_ACE_LOG2_IMG;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORACERC));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_ACE_OK_PB = new System.Windows.Forms.Button();
        this.ID_ACE_PNL = new AxThreed.AxSSPanel();
        this.ID_ACE_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_ACE_LOG1_IMG = new System.Windows.Forms.PictureBox();
        this.ID_ACE_ETI2_TXT = new System.Windows.Forms.Label();
        this.ID_ACE_ETI1_TXT = new System.Windows.Forms.Label();
        this.ID_ACE_BAN_TXT = new System.Windows.Forms.Label();
        this.ID_ACE_DER_TXT = new System.Windows.Forms.Label();
        this.ID_ACE_LIN = new System.Windows.Forms.Label();
        this.ID_ACE_ETI3_TXT = new System.Windows.Forms.Label();
        this.ID_ACE_LOG2_IMG = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACE_PNL)).BeginInit();
        this.ID_ACE_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACE_LOG1_IMG)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACE_LOG2_IMG)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_ACE_OK_PB
        // 
        this.ID_ACE_OK_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACE_OK_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACE_OK_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_ACE_OK_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACE_OK_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACE_OK_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACE_OK_PB.Location = new System.Drawing.Point(311, 139);
        this.ID_ACE_OK_PB.Name = "ID_ACE_OK_PB";
        this.ID_ACE_OK_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACE_OK_PB.Size = new System.Drawing.Size(71, 23);
        this.ID_ACE_OK_PB.TabIndex = 0;
        this.ID_ACE_OK_PB.Tag = "";
        this.ID_ACE_OK_PB.Text = "&Salir";
        this.ID_ACE_OK_PB.UseVisualStyleBackColor = false;
        this.ID_ACE_OK_PB.Click += new System.EventHandler(this.ID_ACE_OK_PB_Click);
        // 
        // ID_ACE_PNL
        // 
        this.ID_ACE_PNL.Controls.Add(this.ID_ACE_PNLLabel_Text);
        this.ID_ACE_PNL.Location = new System.Drawing.Point(69, 18);
        this.ID_ACE_PNL.Name = "ID_ACE_PNL";
        this.ID_ACE_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACE_PNL.OcxState")));
        this.ID_ACE_PNL.Size = new System.Drawing.Size(79, 23);
        this.ID_ACE_PNL.TabIndex = 2;
        this.ID_ACE_PNL.Tag = "";
        // 
        // ID_ACE_PNLLabel_Text
        // 
        this.ID_ACE_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACE_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_ACE_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_ACE_PNLLabel_Text.Name = "ID_ACE_PNLLabel_Text";
        this.ID_ACE_PNLLabel_Text.Size = new System.Drawing.Size(79, 23);
        this.ID_ACE_PNLLabel_Text.TabIndex = 0;
        this.ID_ACE_PNLLabel_Text.Tag = "";
        this.ID_ACE_PNLLabel_Text.Text = "BANAMEX";
        this.ID_ACE_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_ACE_LOG1_IMG
        // 
        this.ID_ACE_LOG1_IMG.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACE_LOG1_IMG.Image = ((System.Drawing.Image)(resources.GetObject("ID_ACE_LOG1_IMG.Image")));
        this.ID_ACE_LOG1_IMG.Location = new System.Drawing.Point(16, 7);
        this.ID_ACE_LOG1_IMG.Name = "ID_ACE_LOG1_IMG";
        this.ID_ACE_LOG1_IMG.Size = new System.Drawing.Size(51, 43);
        this.ID_ACE_LOG1_IMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.ID_ACE_LOG1_IMG.TabIndex = 3;
        this.ID_ACE_LOG1_IMG.TabStop = false;
        this.ID_ACE_LOG1_IMG.Tag = "";
        // 
        // ID_ACE_ETI2_TXT
        // 
        this.ID_ACE_ETI2_TXT.BackColor = System.Drawing.Color.Silver;
        this.ID_ACE_ETI2_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACE_ETI2_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACE_ETI2_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACE_ETI2_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACE_ETI2_TXT.Location = new System.Drawing.Point(229, 121);
        this.ID_ACE_ETI2_TXT.Name = "ID_ACE_ETI2_TXT";
        this.ID_ACE_ETI2_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACE_ETI2_TXT.Size = new System.Drawing.Size(79, 40);
        this.ID_ACE_ETI2_TXT.TabIndex = 1;
        this.ID_ACE_ETI2_TXT.Tag = "";
        // 
        // ID_ACE_ETI1_TXT
        // 
        this.ID_ACE_ETI1_TXT.BackColor = System.Drawing.Color.Silver;
        this.ID_ACE_ETI1_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACE_ETI1_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACE_ETI1_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACE_ETI1_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACE_ETI1_TXT.Location = new System.Drawing.Point(89, 122);
        this.ID_ACE_ETI1_TXT.Name = "ID_ACE_ETI1_TXT";
        this.ID_ACE_ETI1_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACE_ETI1_TXT.Size = new System.Drawing.Size(156, 39);
        this.ID_ACE_ETI1_TXT.TabIndex = 6;
        this.ID_ACE_ETI1_TXT.Tag = "";
        // 
        // ID_ACE_BAN_TXT
        // 
        this.ID_ACE_BAN_TXT.BackColor = System.Drawing.Color.Silver;
        this.ID_ACE_BAN_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACE_BAN_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACE_BAN_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACE_BAN_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACE_BAN_TXT.Location = new System.Drawing.Point(36, 94);
        this.ID_ACE_BAN_TXT.Name = "ID_ACE_BAN_TXT";
        this.ID_ACE_BAN_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACE_BAN_TXT.Size = new System.Drawing.Size(185, 16);
        this.ID_ACE_BAN_TXT.TabIndex = 3;
        this.ID_ACE_BAN_TXT.Tag = "";
        this.ID_ACE_BAN_TXT.Text = "Banamex S.A. ";
        // 
        // ID_ACE_DER_TXT
        // 
        this.ID_ACE_DER_TXT.BackColor = System.Drawing.Color.Silver;
        this.ID_ACE_DER_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACE_DER_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACE_DER_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACE_DER_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACE_DER_TXT.Location = new System.Drawing.Point(36, 78);
        this.ID_ACE_DER_TXT.Name = "ID_ACE_DER_TXT";
        this.ID_ACE_DER_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACE_DER_TXT.Size = new System.Drawing.Size(185, 16);
        this.ID_ACE_DER_TXT.TabIndex = 4;
        this.ID_ACE_DER_TXT.Tag = "";
        this.ID_ACE_DER_TXT.Text = "Derechos Reservados  1994";
        // 
        // ID_ACE_LIN
        // 
        this.ID_ACE_LIN.BackColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACE_LIN.Location = new System.Drawing.Point(24, 140);
        this.ID_ACE_LIN.Name = "ID_ACE_LIN";
        this.ID_ACE_LIN.Size = new System.Drawing.Size(221, 1);
        this.ID_ACE_LIN.TabIndex = 7;
        this.ID_ACE_LIN.Tag = "";
        // 
        // ID_ACE_ETI3_TXT
        // 
        this.ID_ACE_ETI3_TXT.BackColor = System.Drawing.Color.Silver;
        this.ID_ACE_ETI3_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACE_ETI3_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_ACE_ETI3_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACE_ETI3_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACE_ETI3_TXT.Location = new System.Drawing.Point(36, 62);
        this.ID_ACE_ETI3_TXT.Name = "ID_ACE_ETI3_TXT";
        this.ID_ACE_ETI3_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACE_ETI3_TXT.Size = new System.Drawing.Size(185, 16);
        this.ID_ACE_ETI3_TXT.TabIndex = 5;
        this.ID_ACE_ETI3_TXT.Tag = "";
        this.ID_ACE_ETI3_TXT.Text = "Sistema Tarjeta Corporativa Versión";
        // 
        // ID_ACE_LOG2_IMG
        // 
        this.ID_ACE_LOG2_IMG.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACE_LOG2_IMG.Image = ((System.Drawing.Image)(resources.GetObject("ID_ACE_LOG2_IMG.Image")));
        this.ID_ACE_LOG2_IMG.Location = new System.Drawing.Point(239, 11);
        this.ID_ACE_LOG2_IMG.Name = "ID_ACE_LOG2_IMG";
        this.ID_ACE_LOG2_IMG.Size = new System.Drawing.Size(131, 31);
        this.ID_ACE_LOG2_IMG.TabIndex = 8;
        this.ID_ACE_LOG2_IMG.TabStop = false;
        this.ID_ACE_LOG2_IMG.Tag = "";
        // 
        // CORACERC
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.CancelButton = this.ID_ACE_OK_PB;
        this.ClientSize = new System.Drawing.Size(390, 172);
        this.Controls.Add(this.ID_ACE_PNL);
        this.Controls.Add(this.ID_ACE_LOG1_IMG);
        this.Controls.Add(this.ID_ACE_ETI2_TXT);
        this.Controls.Add(this.ID_ACE_DER_TXT);
        this.Controls.Add(this.ID_ACE_OK_PB);
        this.Controls.Add(this.ID_ACE_ETI1_TXT);
        this.Controls.Add(this.ID_ACE_BAN_TXT);
        this.Controls.Add(this.ID_ACE_LIN);
        this.Controls.Add(this.ID_ACE_ETI3_TXT);
        this.Controls.Add(this.ID_ACE_LOG2_IMG);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Location = new System.Drawing.Point(234, 105);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORACERC";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Acerca de Corporativa";
        this.Closed += new System.EventHandler(this.CORACERC_Closed);
        this.Load += new System.EventHandler(this.CORACERC_Load);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACE_PNL)).EndInit();
        this.ID_ACE_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACE_LOG1_IMG)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_ACE_LOG2_IMG)).EndInit();
        this.ResumeLayout(false);

	}
#endregion 
}
}