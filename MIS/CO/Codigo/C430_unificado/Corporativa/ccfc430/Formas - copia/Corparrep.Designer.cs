using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORPARREP
	{
	
#region "Upgrade Support "
		private static CORPARREP m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORPARREP DefInstance
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
		public CORPARREP():base(){
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
	public static CORPARREP CreateInstance()
	{
			CORPARREP theInstance = new CORPARREP();
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
	public  System.Windows.Forms.Button ID_PAR_CAN_CB;
	public  System.Windows.Forms.Button ID_PAR_OK_CB;
	public  System.Windows.Forms.TextBox ID_PAR_PAR_TXT;
	public  System.Windows.Forms.Label ID_PAR_ETI2_LBL;
	public  System.Windows.Forms.Label ID_PAR_ETI1_LBL;
	public  AxThreed.AxSSPanel SSPanel1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORPARREP));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.SSPanel1 = new AxThreed.AxSSPanel();
			this.ID_PAR_CAN_CB = new System.Windows.Forms.Button();
			this.ID_PAR_OK_CB = new System.Windows.Forms.Button();
			this.ID_PAR_PAR_TXT = new System.Windows.Forms.TextBox();
			this.ID_PAR_ETI2_LBL = new System.Windows.Forms.Label();
			this.ID_PAR_ETI1_LBL = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) this.SSPanel1).BeginInit();
			this.SSPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// SSPanel1
			// 
			this.SSPanel1.Controls.Add(this.ID_PAR_PAR_TXT);
			this.SSPanel1.Controls.Add(this.ID_PAR_OK_CB);
			this.SSPanel1.Controls.Add(this.ID_PAR_CAN_CB);
			this.SSPanel1.Controls.Add(this.ID_PAR_ETI1_LBL);
			this.SSPanel1.Controls.Add(this.ID_PAR_ETI2_LBL);
			this.SSPanel1.Location = new System.Drawing.Point(1, 1);
			this.SSPanel1.Name = "SSPanel1";
			this.SSPanel1.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("SSPanel1.OcxState");
			this.SSPanel1.Size = new System.Drawing.Size(251, 83);
			this.SSPanel1.TabIndex = 0;
			this.SSPanel1.Tag = "";
			// 
			// ID_PAR_CAN_CB
			// 
			this.ID_PAR_CAN_CB.BackColor = System.Drawing.SystemColors.Control;
			this.ID_PAR_CAN_CB.CausesValidation = true;
			this.ID_PAR_CAN_CB.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_PAR_CAN_CB.Enabled = true;
			this.ID_PAR_CAN_CB.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_PAR_CAN_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_PAR_CAN_CB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_PAR_CAN_CB.Location = new System.Drawing.Point(179, 42);
			this.ID_PAR_CAN_CB.Name = "ID_PAR_CAN_CB";
			this.ID_PAR_CAN_CB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_PAR_CAN_CB.Size = new System.Drawing.Size(66, 18);
			this.ID_PAR_CAN_CB.TabIndex = 5;
			this.ID_PAR_CAN_CB.TabStop = true;
			this.ID_PAR_CAN_CB.Tag = "";
			this.ID_PAR_CAN_CB.Text = "Cancelar";
			this.ID_PAR_CAN_CB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ID_PAR_CAN_CB.Click += new System.EventHandler(this.ID_PAR_CAN_CB_Click);
			// 
			// ID_PAR_OK_CB
			// 
			this.ID_PAR_OK_CB.BackColor = System.Drawing.SystemColors.Control;
			this.ID_PAR_OK_CB.CausesValidation = true;
			this.ID_PAR_OK_CB.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_PAR_OK_CB.Enabled = true;
			this.ID_PAR_OK_CB.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_PAR_OK_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_PAR_OK_CB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_PAR_OK_CB.Location = new System.Drawing.Point(179, 14);
			this.ID_PAR_OK_CB.Name = "ID_PAR_OK_CB";
			this.ID_PAR_OK_CB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_PAR_OK_CB.Size = new System.Drawing.Size(65, 19);
			this.ID_PAR_OK_CB.TabIndex = 4;
			this.ID_PAR_OK_CB.TabStop = true;
			this.ID_PAR_OK_CB.Tag = "";
			this.ID_PAR_OK_CB.Text = "Aceptar";
			this.ID_PAR_OK_CB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ID_PAR_OK_CB.Click += new System.EventHandler(this.ID_PAR_OK_CB_Click);
			// 
			// ID_PAR_PAR_TXT
			// 
			this.ID_PAR_PAR_TXT.AcceptsReturn = true;
			this.ID_PAR_PAR_TXT.AutoSize = false;
			this.ID_PAR_PAR_TXT.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.ID_PAR_PAR_TXT.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ID_PAR_PAR_TXT.CausesValidation = true;
			this.ID_PAR_PAR_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.ID_PAR_PAR_TXT.Enabled = true;
			this.ID_PAR_PAR_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_PAR_PAR_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
			this.ID_PAR_PAR_TXT.HideSelection = true;
			this.ID_PAR_PAR_TXT.Location = new System.Drawing.Point(13, 55);
			this.ID_PAR_PAR_TXT.MaxLength = 0;
			this.ID_PAR_PAR_TXT.Multiline = false;
			this.ID_PAR_PAR_TXT.Name = "ID_PAR_PAR_TXT";
			this.ID_PAR_PAR_TXT.ReadOnly = false;
			this.ID_PAR_PAR_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_PAR_PAR_TXT.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.ID_PAR_PAR_TXT.Size = new System.Drawing.Size(121, 19);
			this.ID_PAR_PAR_TXT.TabIndex = 1;
			this.ID_PAR_PAR_TXT.TabStop = true;
			this.ID_PAR_PAR_TXT.Tag = "";
			this.ID_PAR_PAR_TXT.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.ID_PAR_PAR_TXT.Visible = true;
			this.ID_PAR_PAR_TXT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_PAR_PAR_TXT_KeyPress);
			// 
			// ID_PAR_ETI2_LBL
			// 
			this.ID_PAR_ETI2_LBL.AutoSize = false;
			this.ID_PAR_ETI2_LBL.BackColor = System.Drawing.SystemColors.Control;
			this.ID_PAR_ETI2_LBL.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ID_PAR_ETI2_LBL.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_PAR_ETI2_LBL.Enabled = true;
			this.ID_PAR_ETI2_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_PAR_ETI2_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_PAR_ETI2_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_PAR_ETI2_LBL.Location = new System.Drawing.Point(37, 33);
			this.ID_PAR_ETI2_LBL.Name = "ID_PAR_ETI2_LBL";
			this.ID_PAR_ETI2_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_PAR_ETI2_LBL.Size = new System.Drawing.Size(115, 11);
			this.ID_PAR_ETI2_LBL.TabIndex = 3;
			this.ID_PAR_ETI2_LBL.Tag = "";
			this.ID_PAR_ETI2_LBL.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ID_PAR_ETI2_LBL.UseMnemonic = true;
			this.ID_PAR_ETI2_LBL.Visible = true;
			// 
			// ID_PAR_ETI1_LBL
			// 
			this.ID_PAR_ETI1_LBL.AutoSize = false;
			this.ID_PAR_ETI1_LBL.BackColor = System.Drawing.SystemColors.Control;
			this.ID_PAR_ETI1_LBL.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ID_PAR_ETI1_LBL.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_PAR_ETI1_LBL.Enabled = true;
			this.ID_PAR_ETI1_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_PAR_ETI1_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_PAR_ETI1_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_PAR_ETI1_LBL.Location = new System.Drawing.Point(10, 11);
			this.ID_PAR_ETI1_LBL.Name = "ID_PAR_ETI1_LBL";
			this.ID_PAR_ETI1_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_PAR_ETI1_LBL.Size = new System.Drawing.Size(99, 13);
			this.ID_PAR_ETI1_LBL.TabIndex = 2;
			this.ID_PAR_ETI1_LBL.Tag = "";
			this.ID_PAR_ETI1_LBL.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ID_PAR_ETI1_LBL.UseMnemonic = true;
			this.ID_PAR_ETI1_LBL.Visible = true;
			// 
			// CORPARREP
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(253, 86);
			this.ControlBox = true;
			this.Controls.Add(this.SSPanel1);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Enabled = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.HelpButton = false;
			this.KeyPreview = false;
			this.Location = new System.Drawing.Point(132, 237);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CORPARREP";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "";
			this.Text = "Parámetros";
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			base.Activated += new System.EventHandler(this.CORPARREP_Activated);
			base.Closed += new System.EventHandler(this.CORPARREP_Closed);
			((System.ComponentModel.ISupportInitialize) this.SSPanel1).EndInit();
			this.SSPanel1.ResumeLayout(false);
			this.ResumeLayout(false);
	}
#endregion 
}
}