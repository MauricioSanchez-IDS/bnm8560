using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORLIMCR
	{
	
#region "Upgrade Support "
		private static CORLIMCR m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORLIMCR DefInstance
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
		public CORLIMCR():base(){
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
	public static CORLIMCR CreateInstance()
	{
			CORLIMCR theInstance = new CORLIMCR();
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
	public  System.Windows.Forms.ListBox ID_LIM_COR_LIB;
	public  System.Windows.Forms.Button ID_MEN_SAL_CB;
	public  System.Windows.Forms.ListBox ID_LIM_EMP_LIB;
	public  System.Windows.Forms.Label ID_LIM_ACU_LBL;
	public  System.Windows.Forms.Label ID_LIM_ASI_LBL;
	public  System.Windows.Forms.Label ID_LIM_EMP_LBL;
	public  System.Windows.Forms.Label ID_LIM_COR_LBL;
	public  AxThreed.AxSSPanel ID_MEN_PRI_PNL;
	private Artinsoft.VB6.Gui.ListControlHelper ListBoxComboBoxHelper1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORLIMCR));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_MEN_PRI_PNL = new AxThreed.AxSSPanel();
            this.ID_LIM_ACU_LBL = new System.Windows.Forms.Label();
            this.ID_LIM_EMP_LIB = new System.Windows.Forms.ListBox();
            this.ID_MEN_SAL_CB = new System.Windows.Forms.Button();
            this.ID_LIM_COR_LBL = new System.Windows.Forms.Label();
            this.ID_LIM_EMP_LBL = new System.Windows.Forms.Label();
            this.ID_LIM_ASI_LBL = new System.Windows.Forms.Label();
            this.ID_LIM_COR_LIB = new System.Windows.Forms.ListBox();
            this.ListBoxComboBoxHelper1 = new Artinsoft.VB6.Gui.ListControlHelper(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEN_PRI_PNL)).BeginInit();
            this.ID_MEN_PRI_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_MEN_PRI_PNL
            // 
            this.ID_MEN_PRI_PNL.Controls.Add(this.ID_LIM_ACU_LBL);
            this.ID_MEN_PRI_PNL.Controls.Add(this.ID_LIM_EMP_LIB);
            this.ID_MEN_PRI_PNL.Controls.Add(this.ID_MEN_SAL_CB);
            this.ID_MEN_PRI_PNL.Controls.Add(this.ID_LIM_COR_LBL);
            this.ID_MEN_PRI_PNL.Controls.Add(this.ID_LIM_EMP_LBL);
            this.ID_MEN_PRI_PNL.Controls.Add(this.ID_LIM_ASI_LBL);
            this.ID_MEN_PRI_PNL.Controls.Add(this.ID_LIM_COR_LIB);
            this.ID_MEN_PRI_PNL.Location = new System.Drawing.Point(-3, -1);
            this.ID_MEN_PRI_PNL.Name = "ID_MEN_PRI_PNL";
            this.ID_MEN_PRI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEN_PRI_PNL.OcxState")));
            this.ID_MEN_PRI_PNL.Size = new System.Drawing.Size(1297, 666);
            this.ID_MEN_PRI_PNL.TabIndex = 0;
            this.ID_MEN_PRI_PNL.Tag = "";
            // 
            // ID_LIM_ACU_LBL
            // 
            this.ID_LIM_ACU_LBL.AutoSize = true;
            this.ID_LIM_ACU_LBL.BackColor = System.Drawing.SystemColors.Control;
            this.ID_LIM_ACU_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_LIM_ACU_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_LIM_ACU_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_LIM_ACU_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_LIM_ACU_LBL.Location = new System.Drawing.Point(666, 12);
            this.ID_LIM_ACU_LBL.Name = "ID_LIM_ACU_LBL";
            this.ID_LIM_ACU_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_LIM_ACU_LBL.Size = new System.Drawing.Size(152, 20);
            this.ID_LIM_ACU_LBL.TabIndex = 7;
            this.ID_LIM_ACU_LBL.Tag = "";
            this.ID_LIM_ACU_LBL.Text = "Créd. Acumulado";
            // 
            // ID_LIM_EMP_LIB
            // 
            this.ID_LIM_EMP_LIB.BackColor = System.Drawing.SystemColors.Window;
            this.ID_LIM_EMP_LIB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_LIM_EMP_LIB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_LIM_EMP_LIB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListBoxComboBoxHelper1.SetItemData(this.ID_LIM_EMP_LIB, new int[] {
            0});
            this.ID_LIM_EMP_LIB.ItemHeight = 20;
            this.ID_LIM_EMP_LIB.Items.AddRange(new object[] {
            "ID_LIM_EMP_LIB"});
            this.ID_LIM_EMP_LIB.Location = new System.Drawing.Point(15, 223);
            this.ID_LIM_EMP_LIB.Name = "ID_LIM_EMP_LIB";
            this.ID_LIM_EMP_LIB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_LIM_EMP_LIB.Size = new System.Drawing.Size(835, 144);
            this.ID_LIM_EMP_LIB.TabIndex = 1;
            this.ID_LIM_EMP_LIB.Tag = "";
            // 
            // ID_MEN_SAL_CB
            // 
            this.ID_MEN_SAL_CB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_MEN_SAL_CB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_MEN_SAL_CB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_MEN_SAL_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_MEN_SAL_CB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_MEN_SAL_CB.Location = new System.Drawing.Point(732, 389);
            this.ID_MEN_SAL_CB.Name = "ID_MEN_SAL_CB";
            this.ID_MEN_SAL_CB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_MEN_SAL_CB.Size = new System.Drawing.Size(118, 38);
            this.ID_MEN_SAL_CB.TabIndex = 2;
            this.ID_MEN_SAL_CB.Tag = "";
            this.ID_MEN_SAL_CB.Text = "Aceptar";
            this.ID_MEN_SAL_CB.UseVisualStyleBackColor = false;
            this.ID_MEN_SAL_CB.Click += new System.EventHandler(this.ID_MEN_SAL_CB_Click);
            // 
            // ID_LIM_COR_LBL
            // 
            this.ID_LIM_COR_LBL.AutoSize = true;
            this.ID_LIM_COR_LBL.BackColor = System.Drawing.SystemColors.Control;
            this.ID_LIM_COR_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_LIM_COR_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_LIM_COR_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_LIM_COR_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_LIM_COR_LBL.Location = new System.Drawing.Point(20, 7);
            this.ID_LIM_COR_LBL.Name = "ID_LIM_COR_LBL";
            this.ID_LIM_COR_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_LIM_COR_LBL.Size = new System.Drawing.Size(135, 25);
            this.ID_LIM_COR_LBL.TabIndex = 3;
            this.ID_LIM_COR_LBL.Tag = "";
            this.ID_LIM_COR_LBL.Text = "Corporativos";
            // 
            // ID_LIM_EMP_LBL
            // 
            this.ID_LIM_EMP_LBL.AutoSize = true;
            this.ID_LIM_EMP_LBL.BackColor = System.Drawing.SystemColors.Control;
            this.ID_LIM_EMP_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_LIM_EMP_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_LIM_EMP_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_LIM_EMP_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_LIM_EMP_LBL.Location = new System.Drawing.Point(20, 196);
            this.ID_LIM_EMP_LBL.Name = "ID_LIM_EMP_LBL";
            this.ID_LIM_EMP_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_LIM_EMP_LBL.Size = new System.Drawing.Size(108, 25);
            this.ID_LIM_EMP_LBL.TabIndex = 5;
            this.ID_LIM_EMP_LBL.Tag = "";
            this.ID_LIM_EMP_LBL.Text = "Empresas";
            // 
            // ID_LIM_ASI_LBL
            // 
            this.ID_LIM_ASI_LBL.AutoSize = true;
            this.ID_LIM_ASI_LBL.BackColor = System.Drawing.SystemColors.Control;
            this.ID_LIM_ASI_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_LIM_ASI_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_LIM_ASI_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_LIM_ASI_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_LIM_ASI_LBL.Location = new System.Drawing.Point(510, 12);
            this.ID_LIM_ASI_LBL.Name = "ID_LIM_ASI_LBL";
            this.ID_LIM_ASI_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_LIM_ASI_LBL.Size = new System.Drawing.Size(137, 20);
            this.ID_LIM_ASI_LBL.TabIndex = 6;
            this.ID_LIM_ASI_LBL.Tag = "";
            this.ID_LIM_ASI_LBL.Text = "Créd. Asignado";
            // 
            // ID_LIM_COR_LIB
            // 
            this.ID_LIM_COR_LIB.BackColor = System.Drawing.SystemColors.Window;
            this.ID_LIM_COR_LIB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_LIM_COR_LIB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_LIM_COR_LIB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.ListBoxComboBoxHelper1.SetItemData(this.ID_LIM_COR_LIB, new int[] {
            0});
            this.ID_LIM_COR_LIB.ItemHeight = 20;
            this.ID_LIM_COR_LIB.Items.AddRange(new object[] {
            "ID_LIM_COR_LIB"});
            this.ID_LIM_COR_LIB.Location = new System.Drawing.Point(16, 32);
            this.ID_LIM_COR_LIB.Name = "ID_LIM_COR_LIB";
            this.ID_LIM_COR_LIB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_LIM_COR_LIB.Size = new System.Drawing.Size(836, 144);
            this.ID_LIM_COR_LIB.TabIndex = 4;
            this.ID_LIM_COR_LIB.Tag = "";
            // 
            // CORLIMCR
            // 
            this.AcceptButton = this.ID_MEN_SAL_CB;
            this.AutoScaleBaseSize = new System.Drawing.Size(15, 28);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(574, 298);
            this.Controls.Add(this.ID_MEN_PRI_PNL);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(120, 197);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORLIMCR";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Límites de Crédito Inconsistentes";
            this.Closed += new System.EventHandler(this.CORLIMCR_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.ID_MEN_PRI_PNL)).EndInit();
            this.ID_MEN_PRI_PNL.ResumeLayout(false);
            this.ID_MEN_PRI_PNL.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).EndInit();
            this.ResumeLayout(false);

	}
#endregion 
}
}