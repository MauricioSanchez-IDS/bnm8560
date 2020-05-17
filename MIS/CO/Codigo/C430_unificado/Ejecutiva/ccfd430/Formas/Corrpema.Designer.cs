using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORRPEMA
	{
	
#region "Upgrade Support "
		private static CORRPEMA m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORRPEMA DefInstance
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
		public CORRPEMA():base(){
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
            InitializeComponent(); //AIS-1213 echasiquiza
			InitializeHelp();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORRPEMA CreateInstance()
	{
			CORRPEMA theInstance = new CORRPEMA();
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
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORRPEMA));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_DEA_PPL_PNL = new AxThreed.AxSSPanel();
        this.ID_DEA_CAN_PB = new System.Windows.Forms.Button();
        this.ID_DEA_OK_PB = new System.Windows.Forms.Button();
        this.ID_DEA_ETI_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_DEA_ETI_PNL = new AxThreed.AxSSPanel();
        this.ID_DEA_TEX_TXT = new System.Windows.Forms.Label();
        this.ID_DEA_MES_COB = new System.Windows.Forms.ComboBox();
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEA_PPL_PNL)).BeginInit();
        this.ID_DEA_PPL_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEA_ETI_PNL)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_DEA_PPL_PNL
        // 
        this.ID_DEA_PPL_PNL.Controls.Add(this.ID_DEA_CAN_PB);
        this.ID_DEA_PPL_PNL.Controls.Add(this.ID_DEA_OK_PB);
        this.ID_DEA_PPL_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_DEA_PPL_PNL.Name = "ID_DEA_PPL_PNL";
        this.ID_DEA_PPL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_DEA_PPL_PNL.OcxState")));
        this.ID_DEA_PPL_PNL.Size = new System.Drawing.Size(315, 125);
        this.ID_DEA_PPL_PNL.TabIndex = 1;
        this.ID_DEA_PPL_PNL.Tag = "";
        // 
        // ID_DEA_CAN_PB
        // 
        this.ID_DEA_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_DEA_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEA_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_DEA_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DEA_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_DEA_CAN_PB.Location = new System.Drawing.Point(150, 79);
        this.ID_DEA_CAN_PB.Name = "ID_DEA_CAN_PB";
        this.ID_DEA_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DEA_CAN_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_DEA_CAN_PB.TabIndex = 2;
        this.ID_DEA_CAN_PB.Tag = "";
        this.ID_DEA_CAN_PB.Text = "&Salir";
        this.ID_DEA_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_DEA_CAN_PB.Click += new System.EventHandler(this.ID_DEA_CAN_PB_Click);
        // 
        // ID_DEA_OK_PB
        // 
        this.ID_DEA_OK_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_DEA_OK_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEA_OK_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DEA_OK_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_DEA_OK_PB.Location = new System.Drawing.Point(71, 79);
        this.ID_DEA_OK_PB.Name = "ID_DEA_OK_PB";
        this.ID_DEA_OK_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DEA_OK_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_DEA_OK_PB.TabIndex = 3;
        this.ID_DEA_OK_PB.Tag = "";
        this.ID_DEA_OK_PB.Text = "&Reporte";
        this.ID_DEA_OK_PB.UseVisualStyleBackColor = false;
        this.ID_DEA_OK_PB.Click += new System.EventHandler(this.ID_DEA_OK_PB_Click);
        // 
        // ID_DEA_ETI_PNLLabel_Text
        // 
        this.ID_DEA_ETI_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_DEA_ETI_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_DEA_ETI_PNLLabel_Text.Location = new System.Drawing.Point(40, 37);
        this.ID_DEA_ETI_PNLLabel_Text.Name = "ID_DEA_ETI_PNLLabel_Text";
        this.ID_DEA_ETI_PNLLabel_Text.Size = new System.Drawing.Size(89, 21);
        this.ID_DEA_ETI_PNLLabel_Text.TabIndex = 9;
        this.ID_DEA_ETI_PNLLabel_Text.Tag = "";
        this.ID_DEA_ETI_PNLLabel_Text.Text = " &Mes de corte";
        this.ID_DEA_ETI_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // ID_DEA_ETI_PNL
        // 
        this.ID_DEA_ETI_PNL.Location = new System.Drawing.Point(39, 36);
        this.ID_DEA_ETI_PNL.Name = "ID_DEA_ETI_PNL";
        this.ID_DEA_ETI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_DEA_ETI_PNL.OcxState")));
        this.ID_DEA_ETI_PNL.Size = new System.Drawing.Size(91, 23);
        this.ID_DEA_ETI_PNL.TabIndex = 10;
        this.ID_DEA_ETI_PNL.Tag = "";
        // 
        // ID_DEA_TEX_TXT
        // 
        this.ID_DEA_TEX_TXT.BackColor = System.Drawing.SystemColors.Window;
        this.ID_DEA_TEX_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEA_TEX_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_DEA_TEX_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DEA_TEX_TXT.ForeColor = System.Drawing.Color.Blue;
        this.ID_DEA_TEX_TXT.Location = new System.Drawing.Point(131, 37);
        this.ID_DEA_TEX_TXT.Name = "ID_DEA_TEX_TXT";
        this.ID_DEA_TEX_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DEA_TEX_TXT.Size = new System.Drawing.Size(137, 15);
        this.ID_DEA_TEX_TXT.TabIndex = 12;
        this.ID_DEA_TEX_TXT.Tag = "";
        this.ID_DEA_TEX_TXT.Text = "Guardando en Texto...";
        // 
        // ID_DEA_MES_COB
        // 
        this.ID_DEA_MES_COB.BackColor = System.Drawing.Color.White;
        this.ID_DEA_MES_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DEA_MES_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_DEA_MES_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DEA_MES_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_DEA_MES_COB.Location = new System.Drawing.Point(130, 37);
        this.ID_DEA_MES_COB.Name = "ID_DEA_MES_COB";
        this.ID_DEA_MES_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DEA_MES_COB.Size = new System.Drawing.Size(151, 21);
        this.ID_DEA_MES_COB.TabIndex = 13;
        this.ID_DEA_MES_COB.Tag = "";
        // 
        // CORRPEMA
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.ClientSize = new System.Drawing.Size(314, 125);
        this.Controls.Add(this.ID_DEA_MES_COB);
        this.Controls.Add(this.ID_DEA_TEX_TXT);
        this.Controls.Add(this.ID_DEA_ETI_PNL);
        this.Controls.Add(this.ID_DEA_ETI_PNLLabel_Text);
        this.Controls.Add(this.ID_DEA_PPL_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        this.KeyPreview = true;
        this.Location = new System.Drawing.Point(230, 120);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORRPEMA";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Tag = "";
        this.Text = "Empresas Afiliadas";
        this.Closed += new System.EventHandler(this.CORRPEMA_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEA_PPL_PNL)).EndInit();
        this.ID_DEA_PPL_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_DEA_ETI_PNL)).EndInit();
        this.ResumeLayout(false);

	}
#endregion 

        public AxThreed.AxSSPanel ID_DEA_PPL_PNL;
        public System.Windows.Forms.Button ID_DEA_CAN_PB;
        public System.Windows.Forms.Button ID_DEA_OK_PB;
        public System.Windows.Forms.Label ID_DEA_ETI_PNLLabel_Text;
        public AxThreed.AxSSPanel ID_DEA_ETI_PNL;
        public System.Windows.Forms.Label ID_DEA_TEX_TXT;
        public System.Windows.Forms.ComboBox ID_DEA_MES_COB;
}
}