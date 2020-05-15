using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORMNDIV
	{
	
#region "Upgrade Support "
		private static CORMNDIV m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORMNDIV DefInstance
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
		public CORMNDIV():base(){
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
	public static CORMNDIV CreateInstance()
	{
			CORMNDIV theInstance = new CORMNDIV();
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
	public  System.Windows.Forms.Button ID_DIV_IMP_PB;
	public  System.Windows.Forms.Button ID_DIV_ACE_PB;
	public  System.Windows.Forms.Button ID_DIV_CAN_PB;
	public  AxMSMask.AxMaskEdBox ID_DIV_CVE_EB;
	public  System.Windows.Forms.TextBox ID_DIV_DIV_EB;
	public  System.Windows.Forms.Label ID_DIV_DIV_LBL;
	public  System.Windows.Forms.Label ID_DIV_CVE_TXT;
	public  System.Windows.Forms.GroupBox ID_DIV_DAT_FRM;
	public  AxMSComDlg.AxCommonDialog CMDialog1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORMNDIV));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_DIV_IMP_PB = new System.Windows.Forms.Button();
            this.ID_DIV_ACE_PB = new System.Windows.Forms.Button();
            this.ID_DIV_CAN_PB = new System.Windows.Forms.Button();
            this.ID_DIV_DAT_FRM = new System.Windows.Forms.GroupBox();
            this.ID_DIV_CVE_EB = new AxMSMask.AxMaskEdBox();
            this.ID_DIV_DIV_EB = new System.Windows.Forms.TextBox();
            this.ID_DIV_CVE_TXT = new System.Windows.Forms.Label();
            this.ID_DIV_DIV_LBL = new System.Windows.Forms.Label();
            this.CMDialog1 = new AxMSComDlg.AxCommonDialog();
            this.ID_DIV_DAT_FRM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_DIV_CVE_EB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMDialog1)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_DIV_IMP_PB
            // 
            this.ID_DIV_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_DIV_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DIV_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_DIV_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DIV_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_DIV_IMP_PB.Location = new System.Drawing.Point(214, 112);
            this.ID_DIV_IMP_PB.Name = "ID_DIV_IMP_PB";
            this.ID_DIV_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DIV_IMP_PB.Size = new System.Drawing.Size(70, 25);
            this.ID_DIV_IMP_PB.TabIndex = 5;
            this.ID_DIV_IMP_PB.Tag = "";
            this.ID_DIV_IMP_PB.Text = "&Imprimir";
            this.ID_DIV_IMP_PB.UseVisualStyleBackColor = false;
            this.ID_DIV_IMP_PB.Click += new System.EventHandler(this.ID_DIV_IMP_PB_Click);
            // 
            // ID_DIV_ACE_PB
            // 
            this.ID_DIV_ACE_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_DIV_ACE_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DIV_ACE_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_DIV_ACE_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DIV_ACE_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_DIV_ACE_PB.Location = new System.Drawing.Point(48, 112);
            this.ID_DIV_ACE_PB.Name = "ID_DIV_ACE_PB";
            this.ID_DIV_ACE_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DIV_ACE_PB.Size = new System.Drawing.Size(70, 25);
            this.ID_DIV_ACE_PB.TabIndex = 3;
            this.ID_DIV_ACE_PB.Tag = "";
            this.ID_DIV_ACE_PB.Text = "Aceptar";
            this.ID_DIV_ACE_PB.UseVisualStyleBackColor = false;
            this.ID_DIV_ACE_PB.Click += new System.EventHandler(this.ID_DIV_ACE_PB_Click);
            // 
            // ID_DIV_CAN_PB
            // 
            this.ID_DIV_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_DIV_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DIV_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_DIV_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_DIV_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DIV_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_DIV_CAN_PB.Location = new System.Drawing.Point(126, 112);
            this.ID_DIV_CAN_PB.Name = "ID_DIV_CAN_PB";
            this.ID_DIV_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DIV_CAN_PB.Size = new System.Drawing.Size(70, 25);
            this.ID_DIV_CAN_PB.TabIndex = 4;
            this.ID_DIV_CAN_PB.Tag = "";
            this.ID_DIV_CAN_PB.Text = "Cancelar";
            this.ID_DIV_CAN_PB.UseVisualStyleBackColor = false;
            this.ID_DIV_CAN_PB.Click += new System.EventHandler(this.ID_DIV_CAN_PB_Click);
            // 
            // ID_DIV_DAT_FRM
            // 
            this.ID_DIV_DAT_FRM.BackColor = System.Drawing.SystemColors.Control;
            this.ID_DIV_DAT_FRM.Controls.Add(this.ID_DIV_CVE_EB);
            this.ID_DIV_DAT_FRM.Controls.Add(this.ID_DIV_DIV_EB);
            this.ID_DIV_DAT_FRM.Controls.Add(this.ID_DIV_CVE_TXT);
            this.ID_DIV_DAT_FRM.Controls.Add(this.ID_DIV_DIV_LBL);
            this.ID_DIV_DAT_FRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DIV_DAT_FRM.ForeColor = System.Drawing.Color.Black;
            this.ID_DIV_DAT_FRM.Location = new System.Drawing.Point(17, 16);
            this.ID_DIV_DAT_FRM.Name = "ID_DIV_DAT_FRM";
            this.ID_DIV_DAT_FRM.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DIV_DAT_FRM.Size = new System.Drawing.Size(295, 85);
            this.ID_DIV_DAT_FRM.TabIndex = 0;
            this.ID_DIV_DAT_FRM.TabStop = false;
            this.ID_DIV_DAT_FRM.Tag = "";
            this.ID_DIV_DAT_FRM.Text = "Datos de División";
            // 
            // ID_DIV_CVE_EB
            // 
            this.ID_DIV_CVE_EB.Location = new System.Drawing.Point(96, 24);
            this.ID_DIV_CVE_EB.Name = "ID_DIV_CVE_EB";
            this.ID_DIV_CVE_EB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_DIV_CVE_EB.OcxState")));
            this.ID_DIV_CVE_EB.Size = new System.Drawing.Size(32, 22);
            this.ID_DIV_CVE_EB.TabIndex = 1;
            this.ID_DIV_CVE_EB.Tag = "";
            this.ID_DIV_CVE_EB.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.ID_DIV_CVE_EB_KeyPressEvent);
            // 
            // ID_DIV_DIV_EB
            // 
            this.ID_DIV_DIV_EB.AcceptsReturn = true;
            this.ID_DIV_DIV_EB.BackColor = System.Drawing.Color.White;
            this.ID_DIV_DIV_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ID_DIV_DIV_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DIV_DIV_EB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_DIV_DIV_EB.Location = new System.Drawing.Point(95, 49);
            this.ID_DIV_DIV_EB.MaxLength = 25;
            this.ID_DIV_DIV_EB.Name = "ID_DIV_DIV_EB";
            this.ID_DIV_DIV_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DIV_DIV_EB.Size = new System.Drawing.Size(189, 20);
            this.ID_DIV_DIV_EB.TabIndex = 2;
            this.ID_DIV_DIV_EB.Tag = "";
            this.ID_DIV_DIV_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_DIV_DIV_EB_KeyPress);
            // 
            // ID_DIV_CVE_TXT
            // 
            this.ID_DIV_CVE_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_DIV_CVE_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DIV_CVE_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_DIV_CVE_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DIV_CVE_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_DIV_CVE_TXT.Location = new System.Drawing.Point(16, 24);
            this.ID_DIV_CVE_TXT.Name = "ID_DIV_CVE_TXT";
            this.ID_DIV_CVE_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DIV_CVE_TXT.Size = new System.Drawing.Size(61, 17);
            this.ID_DIV_CVE_TXT.TabIndex = 6;
            this.ID_DIV_CVE_TXT.Tag = "";
            this.ID_DIV_CVE_TXT.Text = "Clave ";
            // 
            // ID_DIV_DIV_LBL
            // 
            this.ID_DIV_DIV_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_DIV_DIV_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DIV_DIV_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_DIV_DIV_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DIV_DIV_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_DIV_DIV_LBL.Location = new System.Drawing.Point(16, 48);
            this.ID_DIV_DIV_LBL.Name = "ID_DIV_DIV_LBL";
            this.ID_DIV_DIV_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DIV_DIV_LBL.Size = new System.Drawing.Size(73, 15);
            this.ID_DIV_DIV_LBL.TabIndex = 7;
            this.ID_DIV_DIV_LBL.Tag = "";
            this.ID_DIV_DIV_LBL.Text = "Descripción";
            // 
            // CMDialog1
            // 
            this.CMDialog1.Enabled = true;
            this.CMDialog1.Location = new System.Drawing.Point(11, 116);
            this.CMDialog1.Name = "CMDialog1";
            this.CMDialog1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CMDialog1.OcxState")));
            this.CMDialog1.Size = new System.Drawing.Size(32, 32);
            this.CMDialog1.TabIndex = 6;
            this.CMDialog1.Tag = "";
            this.CMDialog1.Enter += new System.EventHandler(this.CMDialog1_Enter);
            // 
            // CORMNDIV
            // 
            this.AcceptButton = this.ID_DIV_ACE_PB;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.ID_DIV_CAN_PB;
            this.ClientSize = new System.Drawing.Size(334, 153);
            this.Controls.Add(this.ID_DIV_IMP_PB);
            this.Controls.Add(this.ID_DIV_DAT_FRM);
            this.Controls.Add(this.CMDialog1);
            this.Controls.Add(this.ID_DIV_CAN_PB);
            this.Controls.Add(this.ID_DIV_ACE_PB);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(337, 121);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORMNDIV";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Divisiones Regionales";
            this.Activated += new System.EventHandler(this.CORMNDIV_Activated);
            this.Closed += new System.EventHandler(this.CORMNDIV_Closed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORMNDIV_KeyPress);
            this.ID_DIV_DAT_FRM.ResumeLayout(false);
            this.ID_DIV_DAT_FRM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_DIV_CVE_EB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CMDialog1)).EndInit();
            this.ResumeLayout(false);

	}
#endregion 
}
}