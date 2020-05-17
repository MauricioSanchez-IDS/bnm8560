using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORSGPRE
	{
	
#region "Upgrade Support "
		private static CORSGPRE m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORSGPRE DefInstance
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
		public CORSGPRE():base(){
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
	public static CORSGPRE CreateInstance()
	{
			CORSGPRE theInstance = new CORSGPRE();
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
	public  System.Windows.Forms.Timer ID_MDI_TIM_TMR;
	public  System.Windows.Forms.PictureBox ID_PRE_BAN_PIC;
	public  System.Windows.Forms.PictureBox ID_PRE_COR_PIC;
	public  System.Windows.Forms.Label ID_PRE_TIT_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_PRE_TIT_PNL;
	public  System.Windows.Forms.Label ID_PRE_DER_TXT;
	public  System.Windows.Forms.Label ID_PRE_DEP_TXT;
	public  System.Windows.Forms.Label ID_PRE_VER_TXT;
	public  System.Windows.Forms.Label ID_PRE_LIN1_LN;
	public  System.Windows.Forms.Label ID_PRE_LIN2_LN;
	public  AxThreed.AxSSPanel ID_PRE_PRI_FRM;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORSGPRE));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_PRE_PRI_FRM = new AxThreed.AxSSPanel();
        this.ID_PRE_DER_TXT = new System.Windows.Forms.Label();
        this.ID_PRE_TIT_PNL = new AxThreed.AxSSPanel();
        this.ID_PRE_TIT_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_PRE_COR_PIC = new System.Windows.Forms.PictureBox();
        this.ID_PRE_DEP_TXT = new System.Windows.Forms.Label();
        this.ID_PRE_LIN2_LN = new System.Windows.Forms.Label();
        this.ID_PRE_LIN1_LN = new System.Windows.Forms.Label();
        this.ID_PRE_VER_TXT = new System.Windows.Forms.Label();
        this.ID_PRE_BAN_PIC = new System.Windows.Forms.PictureBox();
        this.ID_MDI_TIM_TMR = new System.Windows.Forms.Timer(this.components);
        ((System.ComponentModel.ISupportInitialize)(this.ID_PRE_PRI_FRM)).BeginInit();
        this.ID_PRE_PRI_FRM.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_PRE_TIT_PNL)).BeginInit();
        this.ID_PRE_TIT_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_PRE_COR_PIC)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_PRE_BAN_PIC)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_PRE_PRI_FRM
        // 
        this.ID_PRE_PRI_FRM.Controls.Add(this.ID_PRE_DER_TXT);
        this.ID_PRE_PRI_FRM.Controls.Add(this.ID_PRE_TIT_PNL);
        this.ID_PRE_PRI_FRM.Controls.Add(this.ID_PRE_COR_PIC);
        this.ID_PRE_PRI_FRM.Controls.Add(this.ID_PRE_DEP_TXT);
        this.ID_PRE_PRI_FRM.Controls.Add(this.ID_PRE_LIN2_LN);
        this.ID_PRE_PRI_FRM.Controls.Add(this.ID_PRE_LIN1_LN);
        this.ID_PRE_PRI_FRM.Controls.Add(this.ID_PRE_VER_TXT);
        this.ID_PRE_PRI_FRM.Controls.Add(this.ID_PRE_BAN_PIC);
        this.ID_PRE_PRI_FRM.Location = new System.Drawing.Point(0, 0);
        this.ID_PRE_PRI_FRM.Name = "ID_PRE_PRI_FRM";
        this.ID_PRE_PRI_FRM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PRE_PRI_FRM.OcxState")));
        this.ID_PRE_PRI_FRM.Size = new System.Drawing.Size(317, 205);
        this.ID_PRE_PRI_FRM.TabIndex = 0;
        this.ID_PRE_PRI_FRM.Tag = "";
        // 
        // ID_PRE_DER_TXT
        // 
        this.ID_PRE_DER_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_PRE_DER_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_PRE_DER_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_PRE_DER_TXT.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_PRE_DER_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_PRE_DER_TXT.Location = new System.Drawing.Point(197, 182);
        this.ID_PRE_DER_TXT.Name = "ID_PRE_DER_TXT";
        this.ID_PRE_DER_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_PRE_DER_TXT.Size = new System.Drawing.Size(94, 13);
        this.ID_PRE_DER_TXT.TabIndex = 6;
        this.ID_PRE_DER_TXT.Tag = "";
        this.ID_PRE_DER_TXT.Text = "Derechos Reservados";
        // 
        // ID_PRE_TIT_PNL
        // 
        this.ID_PRE_TIT_PNL.Controls.Add(this.ID_PRE_TIT_PNLLabel_Text);
        this.ID_PRE_TIT_PNL.Location = new System.Drawing.Point(104, 12);
        this.ID_PRE_TIT_PNL.Name = "ID_PRE_TIT_PNL";
        this.ID_PRE_TIT_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_PRE_TIT_PNL.OcxState")));
        this.ID_PRE_TIT_PNL.Size = new System.Drawing.Size(167, 27);
        this.ID_PRE_TIT_PNL.TabIndex = 2;
        this.ID_PRE_TIT_PNL.Tag = "";
        // 
        // ID_PRE_TIT_PNLLabel_Text
        // 
        this.ID_PRE_TIT_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_PRE_TIT_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_PRE_TIT_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_PRE_TIT_PNLLabel_Text.Name = "ID_PRE_TIT_PNLLabel_Text";
        this.ID_PRE_TIT_PNLLabel_Text.Size = new System.Drawing.Size(167, 27);
        this.ID_PRE_TIT_PNLLabel_Text.TabIndex = 0;
        this.ID_PRE_TIT_PNLLabel_Text.Tag = "";
        this.ID_PRE_TIT_PNLLabel_Text.Text = "Grupo Financiero Banamex Accival";
        this.ID_PRE_TIT_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_PRE_COR_PIC
        // 
        this.ID_PRE_COR_PIC.BackColor = System.Drawing.Color.Silver;
        this.ID_PRE_COR_PIC.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_PRE_COR_PIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_PRE_COR_PIC.Image = ((System.Drawing.Image)(resources.GetObject("ID_PRE_COR_PIC.Image")));
        this.ID_PRE_COR_PIC.Location = new System.Drawing.Point(44, 70);
        this.ID_PRE_COR_PIC.Name = "ID_PRE_COR_PIC";
        this.ID_PRE_COR_PIC.Size = new System.Drawing.Size(253, 61);
        this.ID_PRE_COR_PIC.TabIndex = 1;
        this.ID_PRE_COR_PIC.Tag = "";
        // 
        // ID_PRE_DEP_TXT
        // 
        this.ID_PRE_DEP_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_PRE_DEP_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_PRE_DEP_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_PRE_DEP_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_PRE_DEP_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_PRE_DEP_TXT.Location = new System.Drawing.Point(78, 164);
        this.ID_PRE_DEP_TXT.Name = "ID_PRE_DEP_TXT";
        this.ID_PRE_DEP_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_PRE_DEP_TXT.Size = new System.Drawing.Size(181, 19);
        this.ID_PRE_DEP_TXT.TabIndex = 5;
        this.ID_PRE_DEP_TXT.Tag = "";
        this.ID_PRE_DEP_TXT.Text = "Departamento Tarjeta Clásica";
        // 
        // ID_PRE_LIN2_LN
        // 
        this.ID_PRE_LIN2_LN.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_PRE_LIN2_LN.Location = new System.Drawing.Point(38, 65);
        this.ID_PRE_LIN2_LN.Name = "ID_PRE_LIN2_LN";
        this.ID_PRE_LIN2_LN.Size = new System.Drawing.Size(246, 1);
        this.ID_PRE_LIN2_LN.TabIndex = 7;
        this.ID_PRE_LIN2_LN.Tag = "";
        // 
        // ID_PRE_LIN1_LN
        // 
        this.ID_PRE_LIN1_LN.BackColor = System.Drawing.Color.Red;
        this.ID_PRE_LIN1_LN.Location = new System.Drawing.Point(26, 61);
        this.ID_PRE_LIN1_LN.Name = "ID_PRE_LIN1_LN";
        this.ID_PRE_LIN1_LN.Size = new System.Drawing.Size(270, 1);
        this.ID_PRE_LIN1_LN.TabIndex = 8;
        this.ID_PRE_LIN1_LN.Tag = "";
        // 
        // ID_PRE_VER_TXT
        // 
        this.ID_PRE_VER_TXT.AutoSize = true;
        this.ID_PRE_VER_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_PRE_VER_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_PRE_VER_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_PRE_VER_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_PRE_VER_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_PRE_VER_TXT.Location = new System.Drawing.Point(126, 150);
        this.ID_PRE_VER_TXT.Name = "ID_PRE_VER_TXT";
        this.ID_PRE_VER_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_PRE_VER_TXT.Size = new System.Drawing.Size(81, 16);
        this.ID_PRE_VER_TXT.TabIndex = 4;
        this.ID_PRE_VER_TXT.Tag = "";
        this.ID_PRE_VER_TXT.Text = "Versión 6.00";
        this.ID_PRE_VER_TXT.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // ID_PRE_BAN_PIC
        // 
        this.ID_PRE_BAN_PIC.BackColor = System.Drawing.SystemColors.Control;
        this.ID_PRE_BAN_PIC.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_PRE_BAN_PIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_PRE_BAN_PIC.Image = ((System.Drawing.Image)(resources.GetObject("ID_PRE_BAN_PIC.Image")));
        this.ID_PRE_BAN_PIC.Location = new System.Drawing.Point(63, 15);
        this.ID_PRE_BAN_PIC.Name = "ID_PRE_BAN_PIC";
        this.ID_PRE_BAN_PIC.Size = new System.Drawing.Size(45, 45);
        this.ID_PRE_BAN_PIC.TabIndex = 3;
        this.ID_PRE_BAN_PIC.Tag = "";
        // 
        // ID_MDI_TIM_TMR
        // 
        this.ID_MDI_TIM_TMR.Enabled = true;
        this.ID_MDI_TIM_TMR.Interval = 1;
        this.ID_MDI_TIM_TMR.Tick += new System.EventHandler(this.ID_MDI_TIM_TMR_Tick);
        // 
        // CORSGPRE
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.ClientSize = new System.Drawing.Size(317, 205);
        this.ControlBox = false;
        this.Controls.Add(this.ID_PRE_PRI_FRM);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Location = new System.Drawing.Point(202, 144);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORSGPRE";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Presentación Banamex";
        this.Closed += new System.EventHandler(this.CORSGPRE_Closed);
        this.Closing += new System.ComponentModel.CancelEventHandler(this.CORSGPRE_Closing);
        this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORSGPRE_KeyPress);
        ((System.ComponentModel.ISupportInitialize)(this.ID_PRE_PRI_FRM)).EndInit();
        this.ID_PRE_PRI_FRM.ResumeLayout(false);
        this.ID_PRE_PRI_FRM.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_PRE_TIT_PNL)).EndInit();
        this.ID_PRE_TIT_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_PRE_COR_PIC)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ID_PRE_BAN_PIC)).EndInit();
        this.ResumeLayout(false);

	}
#endregion 
}
}