using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORRPDE1
	{
	
#region "Upgrade Support "
		private static CORRPDE1 m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORRPDE1 DefInstance
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
		public CORRPDE1():base(){
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
			InitializeID_DA1_ETI_PNL();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORRPDE1 CreateInstance()
	{
			CORRPDE1 theInstance = new CORRPDE1();
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
	public AxThreed.AxSSPanel[] ID_DA1_ETI_PNL = new AxThreed.AxSSPanel[4];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORRPDE1));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_DA1_PPL_PNL = new AxThreed.AxSSPanel();
        this._ID_DA1_ETI_PNL_3Label_Text = new System.Windows.Forms.Label();
        this._ID_DA1_ETI_PNL_3 = new AxThreed.AxSSPanel();
        this.ID_DA1_MES_COB = new System.Windows.Forms.ComboBox();
        this._ID_DA1_ETI_PNL_2Label_Text = new System.Windows.Forms.Label();
        this._ID_DA1_ETI_PNL_2 = new AxThreed.AxSSPanel();
        this._ID_DA1_ETI_PNL_0Label_Text = new System.Windows.Forms.Label();
        this._ID_DA1_ETI_PNL_0 = new AxThreed.AxSSPanel();
        this.ID_DA1_EMP_LB = new System.Windows.Forms.ListBox();
        this.ID_DA1_ALT_PB = new System.Windows.Forms.Button();
        this.ID_DA1_CER_PB = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)(this.ID_DA1_PPL_PNL)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_DA1_ETI_PNL_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_DA1_ETI_PNL_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_DA1_ETI_PNL_0)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_DA1_PPL_PNL
        // 
        this.ID_DA1_PPL_PNL.Location = new System.Drawing.Point(1, 1);
        this.ID_DA1_PPL_PNL.Name = "ID_DA1_PPL_PNL";
        this.ID_DA1_PPL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_DA1_PPL_PNL.OcxState")));
        this.ID_DA1_PPL_PNL.Size = new System.Drawing.Size(297, 293);
        this.ID_DA1_PPL_PNL.TabIndex = 1;
        this.ID_DA1_PPL_PNL.Tag = "";
        // 
        // _ID_DA1_ETI_PNL_3Label_Text
        // 
        this._ID_DA1_ETI_PNL_3Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_DA1_ETI_PNL_3Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_DA1_ETI_PNL_3Label_Text.Location = new System.Drawing.Point(23, 16);
        this._ID_DA1_ETI_PNL_3Label_Text.Name = "_ID_DA1_ETI_PNL_3Label_Text";
        this._ID_DA1_ETI_PNL_3Label_Text.Size = new System.Drawing.Size(92, 19);
        this._ID_DA1_ETI_PNL_3Label_Text.TabIndex = 2;
        this._ID_DA1_ETI_PNL_3Label_Text.Tag = "";
        this._ID_DA1_ETI_PNL_3Label_Text.Text = " &Mes de corte";
        this._ID_DA1_ETI_PNL_3Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // _ID_DA1_ETI_PNL_3
        // 
        this._ID_DA1_ETI_PNL_3.Location = new System.Drawing.Point(20, 13);
        this._ID_DA1_ETI_PNL_3.Name = "_ID_DA1_ETI_PNL_3";
        this._ID_DA1_ETI_PNL_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_DA1_ETI_PNL_3.OcxState")));
        this._ID_DA1_ETI_PNL_3.Size = new System.Drawing.Size(95, 26);
        this._ID_DA1_ETI_PNL_3.TabIndex = 3;
        this._ID_DA1_ETI_PNL_3.Tag = "";
        // 
        // ID_DA1_MES_COB
        // 
        this.ID_DA1_MES_COB.BackColor = System.Drawing.Color.White;
        this.ID_DA1_MES_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DA1_MES_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_DA1_MES_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DA1_MES_COB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_DA1_MES_COB.Location = new System.Drawing.Point(114, 15);
        this.ID_DA1_MES_COB.Name = "ID_DA1_MES_COB";
        this.ID_DA1_MES_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DA1_MES_COB.Size = new System.Drawing.Size(163, 21);
        this.ID_DA1_MES_COB.TabIndex = 7;
        this.ID_DA1_MES_COB.Tag = "";
        // 
        // _ID_DA1_ETI_PNL_2Label_Text
        // 
        this._ID_DA1_ETI_PNL_2Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_DA1_ETI_PNL_2Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_DA1_ETI_PNL_2Label_Text.Location = new System.Drawing.Point(23, 42);
        this._ID_DA1_ETI_PNL_2Label_Text.Name = "_ID_DA1_ETI_PNL_2Label_Text";
        this._ID_DA1_ETI_PNL_2Label_Text.Size = new System.Drawing.Size(71, 20);
        this._ID_DA1_ETI_PNL_2Label_Text.TabIndex = 8;
        this._ID_DA1_ETI_PNL_2Label_Text.Tag = "";
        this._ID_DA1_ETI_PNL_2Label_Text.Text = "&Nómina";
        this._ID_DA1_ETI_PNL_2Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _ID_DA1_ETI_PNL_2
        // 
        this._ID_DA1_ETI_PNL_2.Location = new System.Drawing.Point(20, 41);
        this._ID_DA1_ETI_PNL_2.Name = "_ID_DA1_ETI_PNL_2";
        this._ID_DA1_ETI_PNL_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_DA1_ETI_PNL_2.OcxState")));
        this._ID_DA1_ETI_PNL_2.Size = new System.Drawing.Size(77, 25);
        this._ID_DA1_ETI_PNL_2.TabIndex = 9;
        this._ID_DA1_ETI_PNL_2.Tag = "";
        // 
        // _ID_DA1_ETI_PNL_0Label_Text
        // 
        this._ID_DA1_ETI_PNL_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_DA1_ETI_PNL_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._ID_DA1_ETI_PNL_0Label_Text.Location = new System.Drawing.Point(99, 42);
        this._ID_DA1_ETI_PNL_0Label_Text.Name = "_ID_DA1_ETI_PNL_0Label_Text";
        this._ID_DA1_ETI_PNL_0Label_Text.Size = new System.Drawing.Size(183, 21);
        this._ID_DA1_ETI_PNL_0Label_Text.TabIndex = 10;
        this._ID_DA1_ETI_PNL_0Label_Text.Tag = "";
        this._ID_DA1_ETI_PNL_0Label_Text.Text = "&Ejecutivo      ";
        this._ID_DA1_ETI_PNL_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _ID_DA1_ETI_PNL_0
        // 
        this._ID_DA1_ETI_PNL_0.Location = new System.Drawing.Point(95, 41);
        this._ID_DA1_ETI_PNL_0.Name = "_ID_DA1_ETI_PNL_0";
        this._ID_DA1_ETI_PNL_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_DA1_ETI_PNL_0.OcxState")));
        this._ID_DA1_ETI_PNL_0.Size = new System.Drawing.Size(187, 25);
        this._ID_DA1_ETI_PNL_0.TabIndex = 11;
        this._ID_DA1_ETI_PNL_0.Tag = "";
        // 
        // ID_DA1_EMP_LB
        // 
        this.ID_DA1_EMP_LB.BackColor = System.Drawing.Color.White;
        this.ID_DA1_EMP_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DA1_EMP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DA1_EMP_LB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_DA1_EMP_LB.Location = new System.Drawing.Point(23, 77);
        this.ID_DA1_EMP_LB.Name = "ID_DA1_EMP_LB";
        this.ID_DA1_EMP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DA1_EMP_LB.Size = new System.Drawing.Size(257, 160);
        this.ID_DA1_EMP_LB.TabIndex = 12;
        this.ID_DA1_EMP_LB.Tag = "";
        // 
        // ID_DA1_ALT_PB
        // 
        this.ID_DA1_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_DA1_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DA1_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DA1_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_DA1_ALT_PB.Location = new System.Drawing.Point(74, 257);
        this.ID_DA1_ALT_PB.Name = "ID_DA1_ALT_PB";
        this.ID_DA1_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DA1_ALT_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_DA1_ALT_PB.TabIndex = 13;
        this.ID_DA1_ALT_PB.Tag = "";
        this.ID_DA1_ALT_PB.Text = "&Reporte";
        this.ID_DA1_ALT_PB.UseVisualStyleBackColor = false;
        this.ID_DA1_ALT_PB.Click += new System.EventHandler(this.ID_DA1_ALT_PB_Click);
        // 
        // ID_DA1_CER_PB
        // 
        this.ID_DA1_CER_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_DA1_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_DA1_CER_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_DA1_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_DA1_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_DA1_CER_PB.Location = new System.Drawing.Point(154, 257);
        this.ID_DA1_CER_PB.Name = "ID_DA1_CER_PB";
        this.ID_DA1_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_DA1_CER_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_DA1_CER_PB.TabIndex = 14;
        this.ID_DA1_CER_PB.Tag = "Cancela";
        this.ID_DA1_CER_PB.Text = "&Salir";
        this.ID_DA1_CER_PB.UseVisualStyleBackColor = false;
        this.ID_DA1_CER_PB.Click += new System.EventHandler(this.ID_DA1_CER_PB_Click);
        // 
        // CORRPDE1
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.ClientSize = new System.Drawing.Size(298, 294);
        this.Controls.Add(this.ID_DA1_CER_PB);
        this.Controls.Add(this.ID_DA1_ALT_PB);
        this.Controls.Add(this.ID_DA1_EMP_LB);
        this.Controls.Add(this._ID_DA1_ETI_PNL_0);
        this.Controls.Add(this._ID_DA1_ETI_PNL_0Label_Text);
        this.Controls.Add(this._ID_DA1_ETI_PNL_2);
        this.Controls.Add(this._ID_DA1_ETI_PNL_2Label_Text);
        this.Controls.Add(this.ID_DA1_MES_COB);
        this.Controls.Add(this._ID_DA1_ETI_PNL_3);
        this.Controls.Add(this._ID_DA1_ETI_PNL_3Label_Text);
        this.Controls.Add(this.ID_DA1_PPL_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(234, 106);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORRPDE1";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Tag = "";
        this.Text = "Ejecutivos Banamex";
        this.Closed += new System.EventHandler(this.CORRPDE1_Closed);
        this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORRPDE1_KeyPress);
        ((System.ComponentModel.ISupportInitialize)(this.ID_DA1_PPL_PNL)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_DA1_ETI_PNL_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_DA1_ETI_PNL_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._ID_DA1_ETI_PNL_0)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeID_DA1_ETI_PNL()
	{
			this.ID_DA1_ETI_PNL[3] = _ID_DA1_ETI_PNL_3;
			this.ID_DA1_ETI_PNL[2] = _ID_DA1_ETI_PNL_2;
			this.ID_DA1_ETI_PNL[0] = _ID_DA1_ETI_PNL_0;
	}
#endregion 

        public AxThreed.AxSSPanel ID_DA1_PPL_PNL;
        private System.Windows.Forms.Label _ID_DA1_ETI_PNL_3Label_Text;
        private AxThreed.AxSSPanel _ID_DA1_ETI_PNL_3;
        public System.Windows.Forms.ComboBox ID_DA1_MES_COB;
        private System.Windows.Forms.Label _ID_DA1_ETI_PNL_2Label_Text;
        private AxThreed.AxSSPanel _ID_DA1_ETI_PNL_2;
        private System.Windows.Forms.Label _ID_DA1_ETI_PNL_0Label_Text;
        private AxThreed.AxSSPanel _ID_DA1_ETI_PNL_0;
        public System.Windows.Forms.ListBox ID_DA1_EMP_LB;
        public System.Windows.Forms.Button ID_DA1_ALT_PB;
        public System.Windows.Forms.Button ID_DA1_CER_PB;
}
}