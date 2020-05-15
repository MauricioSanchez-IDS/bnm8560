using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class frmBancanet
	{
	
#region "Upgrade Support "
		private static frmBancanet m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmBancanet DefInstance
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
		public frmBancanet():base(){
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
			InitializeID_CEM_ETI_PNL();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static frmBancanet CreateInstance()
	{
			frmBancanet theInstance = new frmBancanet();
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
	public  System.Windows.Forms.Button ID_CEM_CON_PB;
	public  System.Windows.Forms.Button ID_CEM_CER_PB;
	public  System.Windows.Forms.Button ID_CEM_ACT_PB;
	public  System.Windows.Forms.ListBox ID_CEM_EMP_LB;
        public System.Windows.Forms.ComboBox ID_CEM_GRP_COB;
	public AxThreed.AxSSPanel[] ID_CEM_ETI_PNL = new AxThreed.AxSSPanel[8];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            this.ID_CEM_PPL_PNL = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._ID_CEM_ETI_PNL_0Label_Text = new System.Windows.Forms.Label();
            this.ID_CEM_EMP_LB = new System.Windows.Forms.ListBox();
            this.ID_CEM_ACT_PB = new System.Windows.Forms.Button();
            this.ID_CEM_CER_PB = new System.Windows.Forms.Button();
            this.ID_CEM_GRP_COB = new System.Windows.Forms.ComboBox();
            this.ID_CEM_CON_PB = new System.Windows.Forms.Button();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_CEM_PPL_PNL.SuspendLayout();
            this.SuspendLayout();
            // 
            // ID_CEM_PPL_PNL
            // 
            this.ID_CEM_PPL_PNL.BackColor = System.Drawing.Color.Silver;
            this.ID_CEM_PPL_PNL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ID_CEM_PPL_PNL.Controls.Add(this.label2);
            this.ID_CEM_PPL_PNL.Controls.Add(this.label1);
            this.ID_CEM_PPL_PNL.Controls.Add(this._ID_CEM_ETI_PNL_0Label_Text);
            this.ID_CEM_PPL_PNL.Controls.Add(this.ID_CEM_EMP_LB);
            this.ID_CEM_PPL_PNL.Controls.Add(this.ID_CEM_ACT_PB);
            this.ID_CEM_PPL_PNL.Controls.Add(this.ID_CEM_CER_PB);
            this.ID_CEM_PPL_PNL.Controls.Add(this.ID_CEM_GRP_COB);
            this.ID_CEM_PPL_PNL.Controls.Add(this.ID_CEM_CON_PB);
            this.ID_CEM_PPL_PNL.Location = new System.Drawing.Point(3, 2);
            this.ID_CEM_PPL_PNL.Name = "ID_CEM_PPL_PNL";
            this.ID_CEM_PPL_PNL.Size = new System.Drawing.Size(452, 287);
            this.ID_CEM_PPL_PNL.TabIndex = 0;
            this.ID_CEM_PPL_PNL.Tag = "";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label2.Location = new System.Drawing.Point(97, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(203, 21);
            this.label2.TabIndex = 7;
            this.label2.Tag = "";
            this.label2.Text = "&Empresa";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label1.Location = new System.Drawing.Point(18, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 21);
            this.label1.TabIndex = 6;
            this.label1.Tag = "";
            this.label1.Text = "No.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _ID_CEM_ETI_PNL_0Label_Text
            // 
            this._ID_CEM_ETI_PNL_0Label_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ID_CEM_ETI_PNL_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEM_ETI_PNL_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEM_ETI_PNL_0Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEM_ETI_PNL_0Label_Text.Location = new System.Drawing.Point(18, 24);
            this._ID_CEM_ETI_PNL_0Label_Text.Name = "_ID_CEM_ETI_PNL_0Label_Text";
            this._ID_CEM_ETI_PNL_0Label_Text.Size = new System.Drawing.Size(73, 21);
            this._ID_CEM_ETI_PNL_0Label_Text.TabIndex = 0;
            this._ID_CEM_ETI_PNL_0Label_Text.Tag = "";
            this._ID_CEM_ETI_PNL_0Label_Text.Text = " &Grupo";
            this._ID_CEM_ETI_PNL_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ID_CEM_EMP_LB
            // 
            this.ID_CEM_EMP_LB.BackColor = System.Drawing.Color.White;
            this.ID_CEM_EMP_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEM_EMP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_EMP_LB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEM_EMP_LB.Location = new System.Drawing.Point(18, 75);
            this.ID_CEM_EMP_LB.Name = "ID_CEM_EMP_LB";
            this.ID_CEM_EMP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEM_EMP_LB.Size = new System.Drawing.Size(282, 147);
            this.ID_CEM_EMP_LB.Sorted = true;
            this.ID_CEM_EMP_LB.TabIndex = 2;
            this.ID_CEM_EMP_LB.Tag = "";
            // 
            // ID_CEM_ACT_PB
            // 
            this.ID_CEM_ACT_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEM_ACT_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEM_ACT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEM_ACT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_ACT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEM_ACT_PB.Location = new System.Drawing.Point(312, 53);
            this.ID_CEM_ACT_PB.Name = "ID_CEM_ACT_PB";
            this.ID_CEM_ACT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEM_ACT_PB.Size = new System.Drawing.Size(124, 22);
            this.ID_CEM_ACT_PB.TabIndex = 3;
            this.ID_CEM_ACT_PB.Tag = "A";
            this.ID_CEM_ACT_PB.Text = "&Actualizar...";
            this.ID_CEM_ACT_PB.UseVisualStyleBackColor = false;
            this.ID_CEM_ACT_PB.Click += new System.EventHandler(this.ID_CEM_ACT_PB_Click);
            // 
            // ID_CEM_CER_PB
            // 
            this.ID_CEM_CER_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEM_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEM_CER_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_CEM_CER_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEM_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEM_CER_PB.Location = new System.Drawing.Point(312, 200);
            this.ID_CEM_CER_PB.Name = "ID_CEM_CER_PB";
            this.ID_CEM_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEM_CER_PB.Size = new System.Drawing.Size(124, 22);
            this.ID_CEM_CER_PB.TabIndex = 5;
            this.ID_CEM_CER_PB.Tag = "";
            this.ID_CEM_CER_PB.Text = "&Exit";
            this.ID_CEM_CER_PB.UseVisualStyleBackColor = false;
            this.ID_CEM_CER_PB.Click += new System.EventHandler(this.ID_CEM_CER_PB_Click);
            // 
            // ID_CEM_GRP_COB
            // 
            this.ID_CEM_GRP_COB.BackColor = System.Drawing.Color.White;
            this.ID_CEM_GRP_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEM_GRP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_CEM_GRP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_GRP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEM_GRP_COB.Location = new System.Drawing.Point(97, 25);
            this.ID_CEM_GRP_COB.Name = "ID_CEM_GRP_COB";
            this.ID_CEM_GRP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEM_GRP_COB.Size = new System.Drawing.Size(288, 21);
            this.ID_CEM_GRP_COB.Sorted = true;
            this.ID_CEM_GRP_COB.TabIndex = 1;
            this.ID_CEM_GRP_COB.Tag = "";
            this.ID_CEM_GRP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CEM_GRP_COB_SelectedIndexChanged);
            // 
            // ID_CEM_CON_PB
            // 
            this.ID_CEM_CON_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEM_CON_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEM_CON_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEM_CON_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEM_CON_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEM_CON_PB.Location = new System.Drawing.Point(312, 80);
            this.ID_CEM_CON_PB.Name = "ID_CEM_CON_PB";
            this.ID_CEM_CON_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEM_CON_PB.Size = new System.Drawing.Size(124, 22);
            this.ID_CEM_CON_PB.TabIndex = 4;
            this.ID_CEM_CON_PB.Tag = "B";
            this.ID_CEM_CON_PB.Text = "C&onsulta...";
            this.ID_CEM_CON_PB.UseVisualStyleBackColor = false;
            this.ID_CEM_CON_PB.Click += new System.EventHandler(this.ID_CEM_CON_PB_Click);
            // 
            // frmBancanet
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(456, 238);
            this.Controls.Add(this.ID_CEM_PPL_PNL);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(16, 129);
            this.Name = "frmBancanet";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "BancaNet";
            this.Closed += new System.EventHandler(this.frmBancanet_Closed);
            this.ID_CEM_PPL_PNL.ResumeLayout(false);
            this.ResumeLayout(false);

	}
	void  InitializeID_CEM_ETI_PNL()
	{
            //this.ID_CEM_ETI_PNL[0] = _ID_CEM_ETI_PNL_0;
            //this.ID_CEM_ETI_PNL[7] = _ID_CEM_ETI_PNL_7;
            //this.ID_CEM_ETI_PNL[1] = _ID_CEM_ETI_PNL_1;
	}
#endregion 

        private System.Windows.Forms.Panel ID_CEM_PPL_PNL;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label _ID_CEM_ETI_PNL_0Label_Text;
}
}