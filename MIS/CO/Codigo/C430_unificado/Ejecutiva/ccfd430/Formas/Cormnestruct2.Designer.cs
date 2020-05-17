using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORMNESTRUCT2
	{
	
#region "Upgrade Support "
		private static CORMNESTRUCT2 m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORMNESTRUCT2 DefInstance
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
		public CORMNESTRUCT2():base(){
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
	public static CORMNESTRUCT2 CreateInstance()
	{
			CORMNESTRUCT2 theInstance = new CORMNESTRUCT2();
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
	public  System.Windows.Forms.Button ID_EST_CAN_PB;
	public  System.Windows.Forms.Button ID_EST_ACE_PB;
	public  System.Windows.Forms.TextBox ID_ESTRUCT_DESC;
	public  AxMSMask.AxMaskEdBox ID_EST_CVE_EB;
	public  System.Windows.Forms.Label ID_REG_CVE_TXT;
	public  System.Windows.Forms.Label ID_REG_REG_TXT;
	public  System.Windows.Forms.GroupBox ID_REG_PRI_FRM;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORMNESTRUCT2));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_REG_PRI_FRM = new System.Windows.Forms.GroupBox();
        this.ID_ESTRUCT_DESC = new System.Windows.Forms.TextBox();
        this.ID_EST_ACE_PB = new System.Windows.Forms.Button();
        this.ID_EST_CAN_PB = new System.Windows.Forms.Button();
        this.ID_EST_CVE_EB = new AxMSMask.AxMaskEdBox();
        this.ID_REG_REG_TXT = new System.Windows.Forms.Label();
        this.ID_REG_CVE_TXT = new System.Windows.Forms.Label();
        this.ID_REG_PRI_FRM.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_EST_CVE_EB)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_REG_PRI_FRM
        // 
        this.ID_REG_PRI_FRM.BackColor = System.Drawing.SystemColors.Control;
        this.ID_REG_PRI_FRM.Controls.Add(this.ID_ESTRUCT_DESC);
        this.ID_REG_PRI_FRM.Controls.Add(this.ID_EST_ACE_PB);
        this.ID_REG_PRI_FRM.Controls.Add(this.ID_EST_CAN_PB);
        this.ID_REG_PRI_FRM.Controls.Add(this.ID_EST_CVE_EB);
        this.ID_REG_PRI_FRM.Controls.Add(this.ID_REG_REG_TXT);
        this.ID_REG_PRI_FRM.Controls.Add(this.ID_REG_CVE_TXT);
        this.ID_REG_PRI_FRM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REG_PRI_FRM.Location = new System.Drawing.Point(0, 0);
        this.ID_REG_PRI_FRM.Name = "ID_REG_PRI_FRM";
        this.ID_REG_PRI_FRM.Size = new System.Drawing.Size(293, 133);
        this.ID_REG_PRI_FRM.TabIndex = 1;
        this.ID_REG_PRI_FRM.TabStop = false;
        this.ID_REG_PRI_FRM.Tag = "";
        this.ID_REG_PRI_FRM.Text = "Datos de la Estructura";
        // 
        // ID_ESTRUCT_DESC
        // 
        this.ID_ESTRUCT_DESC.AcceptsReturn = true;
        this.ID_ESTRUCT_DESC.BackColor = System.Drawing.Color.White;
        this.ID_ESTRUCT_DESC.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ESTRUCT_DESC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ESTRUCT_DESC.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ESTRUCT_DESC.Location = new System.Drawing.Point(90, 52);
        this.ID_ESTRUCT_DESC.MaxLength = 20;
        this.ID_ESTRUCT_DESC.Name = "ID_ESTRUCT_DESC";
        this.ID_ESTRUCT_DESC.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ESTRUCT_DESC.Size = new System.Drawing.Size(189, 20);
        this.ID_ESTRUCT_DESC.TabIndex = 0;
        this.ID_ESTRUCT_DESC.Tag = "";
        this.ID_ESTRUCT_DESC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_ESTRUCT_DESC_KeyPress);
        // 
        // ID_EST_ACE_PB
        // 
        this.ID_EST_ACE_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_EST_ACE_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_EST_ACE_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_EST_ACE_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_EST_ACE_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_EST_ACE_PB.Location = new System.Drawing.Point(61, 91);
        this.ID_EST_ACE_PB.Name = "ID_EST_ACE_PB";
        this.ID_EST_ACE_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_EST_ACE_PB.Size = new System.Drawing.Size(70, 25);
        this.ID_EST_ACE_PB.TabIndex = 5;
        this.ID_EST_ACE_PB.Tag = "";
        this.ID_EST_ACE_PB.Text = "Aceptar";
        this.ID_EST_ACE_PB.UseVisualStyleBackColor = false;
        this.ID_EST_ACE_PB.Click += new System.EventHandler(this.ID_EST_ACE_PB_Click);
        // 
        // ID_EST_CAN_PB
        // 
        this.ID_EST_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_EST_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_EST_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_EST_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_EST_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_EST_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_EST_CAN_PB.Location = new System.Drawing.Point(161, 91);
        this.ID_EST_CAN_PB.Name = "ID_EST_CAN_PB";
        this.ID_EST_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_EST_CAN_PB.Size = new System.Drawing.Size(70, 25);
        this.ID_EST_CAN_PB.TabIndex = 6;
        this.ID_EST_CAN_PB.Tag = "";
        this.ID_EST_CAN_PB.Text = "Cancelar";
        this.ID_EST_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_EST_CAN_PB.Click += new System.EventHandler(this.ID_EST_CAN_PB_Click);
        // 
        // ID_EST_CVE_EB
        // 
        this.ID_EST_CVE_EB.Location = new System.Drawing.Point(90, 24);
        this.ID_EST_CVE_EB.Name = "ID_EST_CVE_EB";
        this.ID_EST_CVE_EB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_EST_CVE_EB.OcxState")));
        this.ID_EST_CVE_EB.Size = new System.Drawing.Size(31, 21);
        this.ID_EST_CVE_EB.TabIndex = 2;
        this.ID_EST_CVE_EB.Tag = "";
        // 
        // ID_REG_REG_TXT
        // 
        this.ID_REG_REG_TXT.AutoSize = true;
        this.ID_REG_REG_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_REG_REG_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REG_REG_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_REG_REG_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REG_REG_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_REG_REG_TXT.Location = new System.Drawing.Point(6, 55);
        this.ID_REG_REG_TXT.Name = "ID_REG_REG_TXT";
        this.ID_REG_REG_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REG_REG_TXT.Size = new System.Drawing.Size(78, 13);
        this.ID_REG_REG_TXT.TabIndex = 3;
        this.ID_REG_REG_TXT.Tag = "";
        this.ID_REG_REG_TXT.Text = "Descripción:";
        // 
        // ID_REG_CVE_TXT
        // 
        this.ID_REG_CVE_TXT.AutoSize = true;
        this.ID_REG_CVE_TXT.BackColor = System.Drawing.SystemColors.Control;
        this.ID_REG_CVE_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_REG_CVE_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_REG_CVE_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_REG_CVE_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_REG_CVE_TXT.Location = new System.Drawing.Point(41, 27);
        this.ID_REG_CVE_TXT.Name = "ID_REG_CVE_TXT";
        this.ID_REG_CVE_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_REG_CVE_TXT.Size = new System.Drawing.Size(43, 13);
        this.ID_REG_CVE_TXT.TabIndex = 4;
        this.ID_REG_CVE_TXT.Tag = "";
        this.ID_REG_CVE_TXT.Text = "Clave:";
        // 
        // CORMNESTRUCT2
        // 
        this.AcceptButton = this.ID_EST_ACE_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Menu;
        this.CancelButton = this.ID_EST_CAN_PB;
        this.ClientSize = new System.Drawing.Size(292, 133);
        this.Controls.Add(this.ID_REG_PRI_FRM);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(355, 246);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORMNESTRUCT2";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Estructuras";
        this.Closed += new System.EventHandler(this.CORMNESTRUCT2_Closed);
        this.ID_REG_PRI_FRM.ResumeLayout(false);
        this.ID_REG_PRI_FRM.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_EST_CVE_EB)).EndInit();
        this.ResumeLayout(false);

	}
#endregion 
}
}