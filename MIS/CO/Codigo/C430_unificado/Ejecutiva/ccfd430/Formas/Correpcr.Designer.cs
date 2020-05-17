using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORREPCR
	{
	
#region "Upgrade Support "
		private static CORREPCR m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORREPCR DefInstance
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
		public CORREPCR():base(){
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
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORREPCR CreateInstance()
	{
			CORREPCR theInstance = new CORREPCR();
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
	public  AxCrystal.AxCrystalReport ID_REP_CRYSTAL;
	public  Microsoft.VisualBasic.Compatibility.VB6.FileListBox ID_REP_ARCH_FLB;
	public  System.Windows.Forms.Button ID_REP_OK_PB;
	public  System.Windows.Forms.Button ID_REP_SAL_PB;
	public  AxThreed.AxSSPanel SSPanel1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORREPCR));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_REP_CRYSTAL = new AxCrystal.AxCrystalReport();
            this.SSPanel1 = new AxThreed.AxSSPanel();
            this.ID_REP_ARCH_FLB = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
            this.ID_REP_OK_PB = new System.Windows.Forms.Button();
            this.ID_REP_SAL_PB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ID_REP_CRYSTAL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSPanel1)).BeginInit();
            this.SSPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ID_REP_CRYSTAL
            // 
            this.ID_REP_CRYSTAL.Enabled = true;
            this.ID_REP_CRYSTAL.Location = new System.Drawing.Point(108, 27);
            this.ID_REP_CRYSTAL.Name = "ID_REP_CRYSTAL";
            this.ID_REP_CRYSTAL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_REP_CRYSTAL.OcxState")));
            this.ID_REP_CRYSTAL.Size = new System.Drawing.Size(28, 28);
            this.ID_REP_CRYSTAL.TabIndex = 1;
            this.ID_REP_CRYSTAL.Tag = "";
            // 
            // SSPanel1
            // 
            this.SSPanel1.Controls.Add(this.ID_REP_ARCH_FLB);
            this.SSPanel1.Controls.Add(this.ID_REP_OK_PB);
            this.SSPanel1.Controls.Add(this.ID_REP_SAL_PB);
            this.SSPanel1.Location = new System.Drawing.Point(0, 0);
            this.SSPanel1.Name = "SSPanel1";
            this.SSPanel1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SSPanel1.OcxState")));
            this.SSPanel1.Size = new System.Drawing.Size(316, 100);
            this.SSPanel1.TabIndex = 0;
            this.SSPanel1.Tag = "";
            // 
            // ID_REP_ARCH_FLB
            // 
            this.ID_REP_ARCH_FLB.BackColor = System.Drawing.Color.White;
            this.ID_REP_ARCH_FLB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_REP_ARCH_FLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_REP_ARCH_FLB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_REP_ARCH_FLB.FormattingEnabled = true;
            this.ID_REP_ARCH_FLB.Location = new System.Drawing.Point(11, 15);
            this.ID_REP_ARCH_FLB.Name = "ID_REP_ARCH_FLB";
            this.ID_REP_ARCH_FLB.Pattern = "*.*";
            this.ID_REP_ARCH_FLB.Size = new System.Drawing.Size(171, 56);
            this.ID_REP_ARCH_FLB.TabIndex = 1;
            this.ID_REP_ARCH_FLB.Tag = "";
            this.ID_REP_ARCH_FLB.SelectedIndexChanged += new System.EventHandler(this.ID_REP_ARCH_FLB_SelectedIndexChanged);
            // 
            // ID_REP_OK_PB
            // 
            this.ID_REP_OK_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_REP_OK_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_REP_OK_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_REP_OK_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_REP_OK_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_REP_OK_PB.Location = new System.Drawing.Point(198, 16);
            this.ID_REP_OK_PB.Name = "ID_REP_OK_PB";
            this.ID_REP_OK_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_REP_OK_PB.Size = new System.Drawing.Size(79, 28);
            this.ID_REP_OK_PB.TabIndex = 2;
            this.ID_REP_OK_PB.Tag = "";
            this.ID_REP_OK_PB.Text = "&Aceptar";
            this.ID_REP_OK_PB.UseVisualStyleBackColor = false;
            this.ID_REP_OK_PB.Click += new System.EventHandler(this.ID_REP_OK_PB_Click);
            // 
            // ID_REP_SAL_PB
            // 
            this.ID_REP_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_REP_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_REP_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_REP_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_REP_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_REP_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_REP_SAL_PB.Location = new System.Drawing.Point(198, 50);
            this.ID_REP_SAL_PB.Name = "ID_REP_SAL_PB";
            this.ID_REP_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_REP_SAL_PB.Size = new System.Drawing.Size(79, 28);
            this.ID_REP_SAL_PB.TabIndex = 3;
            this.ID_REP_SAL_PB.Tag = "";
            this.ID_REP_SAL_PB.Text = "&Salir";
            this.ID_REP_SAL_PB.UseVisualStyleBackColor = false;
            this.ID_REP_SAL_PB.Click += new System.EventHandler(this.ID_REP_SAL_PB_Click);
            // 
            // CORREPCR
            // 
            this.AcceptButton = this.ID_REP_OK_PB;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.ID_REP_SAL_PB;
            this.ClientSize = new System.Drawing.Size(318, 102);
            this.Controls.Add(this.SSPanel1);
            this.Controls.Add(this.ID_REP_CRYSTAL);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(193, 253);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORREPCR";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Reportes Crystal Report";
            this.Closed += new System.EventHandler(this.CORREPCR_Closed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORREPCR_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.ID_REP_CRYSTAL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSPanel1)).EndInit();
            this.SSPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

	}
#endregion 
}
}