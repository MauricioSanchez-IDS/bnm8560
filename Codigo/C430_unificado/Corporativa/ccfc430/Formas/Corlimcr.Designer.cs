using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
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
			this.ID_LIM_COR_LIB = new System.Windows.Forms.ListBox();
			this.ID_MEN_SAL_CB = new System.Windows.Forms.Button();
			this.ID_LIM_EMP_LIB = new System.Windows.Forms.ListBox();
			this.ID_LIM_ACU_LBL = new System.Windows.Forms.Label();
			this.ID_LIM_ASI_LBL = new System.Windows.Forms.Label();
			this.ID_LIM_EMP_LBL = new System.Windows.Forms.Label();
			this.ID_LIM_COR_LBL = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) this.ID_MEN_PRI_PNL).BeginInit();
			this.ID_MEN_PRI_PNL.SuspendLayout();
			this.SuspendLayout();
			this.ListBoxComboBoxHelper1 = new Artinsoft.VB6.Gui.ListControlHelper(this.components);
			((System.ComponentModel.ISupportInitialize) this.ListBoxComboBoxHelper1).BeginInit();
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
			this.ID_MEN_PRI_PNL.Location = new System.Drawing.Point(-2, -1);
			this.ID_MEN_PRI_PNL.Name = "ID_MEN_PRI_PNL";
			this.ID_MEN_PRI_PNL.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("ID_MEN_PRI_PNL.OcxState");
			this.ID_MEN_PRI_PNL.Size = new System.Drawing.Size(577, 301);
			this.ID_MEN_PRI_PNL.TabIndex = 0;
			this.ID_MEN_PRI_PNL.Tag = "";
			// 
			// ID_LIM_COR_LIB
			// 
			this.ID_LIM_COR_LIB.BackColor = System.Drawing.SystemColors.Window;
			this.ID_LIM_COR_LIB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ID_LIM_COR_LIB.CausesValidation = true;
			this.ID_LIM_COR_LIB.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_LIM_COR_LIB.Enabled = true;
			this.ID_LIM_COR_LIB.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_LIM_COR_LIB.ForeColor = System.Drawing.Color.FromArgb(0, 0, 64);
			this.ID_LIM_COR_LIB.IntegralHeight = true;
			this.ID_LIM_COR_LIB.Items.AddRange(new object[]{"ID_LIM_COR_LIB"});
			this.ID_LIM_COR_LIB.Location = new System.Drawing.Point(11, 22);
			this.ID_LIM_COR_LIB.MultiColumn = false;
			this.ID_LIM_COR_LIB.Name = "ID_LIM_COR_LIB";
			this.ID_LIM_COR_LIB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_LIM_COR_LIB.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.ID_LIM_COR_LIB.Size = new System.Drawing.Size(557, 105);
			this.ID_LIM_COR_LIB.Sorted = false;
			this.ID_LIM_COR_LIB.TabIndex = 4;
			this.ID_LIM_COR_LIB.TabStop = true;
			this.ID_LIM_COR_LIB.Tag = "";
			this.ID_LIM_COR_LIB.Visible = true;
			// 
			// ID_MEN_SAL_CB
			// 
			this.ID_MEN_SAL_CB.BackColor = System.Drawing.SystemColors.Control;
			this.ID_MEN_SAL_CB.CausesValidation = true;
			this.ID_MEN_SAL_CB.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_MEN_SAL_CB.Enabled = true;
			this.ID_MEN_SAL_CB.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_MEN_SAL_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_MEN_SAL_CB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_MEN_SAL_CB.Location = new System.Drawing.Point(488, 264);
			this.ID_MEN_SAL_CB.Name = "ID_MEN_SAL_CB";
			this.ID_MEN_SAL_CB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_MEN_SAL_CB.Size = new System.Drawing.Size(79, 26);
			this.ID_MEN_SAL_CB.TabIndex = 2;
			this.ID_MEN_SAL_CB.TabStop = true;
			this.ID_MEN_SAL_CB.Tag = "";
			this.ID_MEN_SAL_CB.Text = "Aceptar";
			this.ID_MEN_SAL_CB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.ID_MEN_SAL_CB.Click += new System.EventHandler(this.ID_MEN_SAL_CB_Click);
			// 
			// ID_LIM_EMP_LIB
			// 
			this.ID_LIM_EMP_LIB.BackColor = System.Drawing.SystemColors.Window;
			this.ID_LIM_EMP_LIB.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.ID_LIM_EMP_LIB.CausesValidation = true;
			this.ID_LIM_EMP_LIB.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_LIM_EMP_LIB.Enabled = true;
			this.ID_LIM_EMP_LIB.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_LIM_EMP_LIB.ForeColor = System.Drawing.Color.FromArgb(0, 0, 64);
			this.ID_LIM_EMP_LIB.IntegralHeight = true;
			this.ID_LIM_EMP_LIB.Items.AddRange(new object[]{"ID_LIM_EMP_LIB"});
			this.ID_LIM_EMP_LIB.Location = new System.Drawing.Point(10, 151);
			this.ID_LIM_EMP_LIB.MultiColumn = false;
			this.ID_LIM_EMP_LIB.Name = "ID_LIM_EMP_LIB";
			this.ID_LIM_EMP_LIB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_LIM_EMP_LIB.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.ID_LIM_EMP_LIB.Size = new System.Drawing.Size(557, 105);
			this.ID_LIM_EMP_LIB.Sorted = false;
			this.ID_LIM_EMP_LIB.TabIndex = 1;
			this.ID_LIM_EMP_LIB.TabStop = true;
			this.ID_LIM_EMP_LIB.Tag = "";
			this.ID_LIM_EMP_LIB.Visible = true;
			// 
			// ID_LIM_ACU_LBL
			// 
			this.ID_LIM_ACU_LBL.AutoSize = true;
			this.ID_LIM_ACU_LBL.BackColor = System.Drawing.SystemColors.Control;
			this.ID_LIM_ACU_LBL.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ID_LIM_ACU_LBL.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_LIM_ACU_LBL.Enabled = true;
			this.ID_LIM_ACU_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_LIM_ACU_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_LIM_ACU_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_LIM_ACU_LBL.Location = new System.Drawing.Point(444, 8);
			this.ID_LIM_ACU_LBL.Name = "ID_LIM_ACU_LBL";
			this.ID_LIM_ACU_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_LIM_ACU_LBL.Size = new System.Drawing.Size(97, 13);
			this.ID_LIM_ACU_LBL.TabIndex = 7;
			this.ID_LIM_ACU_LBL.Tag = "";
			this.ID_LIM_ACU_LBL.Text = "Créd. Acumulado";
			this.ID_LIM_ACU_LBL.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ID_LIM_ACU_LBL.UseMnemonic = true;
			this.ID_LIM_ACU_LBL.Visible = true;
			// 
			// ID_LIM_ASI_LBL
			// 
			this.ID_LIM_ASI_LBL.AutoSize = true;
			this.ID_LIM_ASI_LBL.BackColor = System.Drawing.SystemColors.Control;
			this.ID_LIM_ASI_LBL.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ID_LIM_ASI_LBL.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_LIM_ASI_LBL.Enabled = true;
			this.ID_LIM_ASI_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_LIM_ASI_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_LIM_ASI_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_LIM_ASI_LBL.Location = new System.Drawing.Point(340, 8);
			this.ID_LIM_ASI_LBL.Name = "ID_LIM_ASI_LBL";
			this.ID_LIM_ASI_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_LIM_ASI_LBL.Size = new System.Drawing.Size(87, 13);
			this.ID_LIM_ASI_LBL.TabIndex = 6;
			this.ID_LIM_ASI_LBL.Tag = "";
			this.ID_LIM_ASI_LBL.Text = "Créd. Asignado";
			this.ID_LIM_ASI_LBL.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ID_LIM_ASI_LBL.UseMnemonic = true;
			this.ID_LIM_ASI_LBL.Visible = true;
			// 
			// ID_LIM_EMP_LBL
			// 
			this.ID_LIM_EMP_LBL.AutoSize = true;
			this.ID_LIM_EMP_LBL.BackColor = System.Drawing.SystemColors.Control;
			this.ID_LIM_EMP_LBL.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ID_LIM_EMP_LBL.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_LIM_EMP_LBL.Enabled = true;
			this.ID_LIM_EMP_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_LIM_EMP_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_LIM_EMP_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_LIM_EMP_LBL.Location = new System.Drawing.Point(13, 133);
			this.ID_LIM_EMP_LBL.Name = "ID_LIM_EMP_LBL";
			this.ID_LIM_EMP_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_LIM_EMP_LBL.Size = new System.Drawing.Size(71, 16);
			this.ID_LIM_EMP_LBL.TabIndex = 5;
			this.ID_LIM_EMP_LBL.Tag = "";
			this.ID_LIM_EMP_LBL.Text = "Empresas";
			this.ID_LIM_EMP_LBL.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ID_LIM_EMP_LBL.UseMnemonic = true;
			this.ID_LIM_EMP_LBL.Visible = true;
			// 
			// ID_LIM_COR_LBL
			// 
			this.ID_LIM_COR_LBL.AutoSize = true;
			this.ID_LIM_COR_LBL.BackColor = System.Drawing.SystemColors.Control;
			this.ID_LIM_COR_LBL.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ID_LIM_COR_LBL.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_LIM_COR_LBL.Enabled = true;
			this.ID_LIM_COR_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_LIM_COR_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_LIM_COR_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_LIM_COR_LBL.Location = new System.Drawing.Point(13, 5);
			this.ID_LIM_COR_LBL.Name = "ID_LIM_COR_LBL";
			this.ID_LIM_COR_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_LIM_COR_LBL.Size = new System.Drawing.Size(90, 16);
			this.ID_LIM_COR_LBL.TabIndex = 3;
			this.ID_LIM_COR_LBL.Tag = "";
			this.ID_LIM_COR_LBL.Text = "Corporativos";
			this.ID_LIM_COR_LBL.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ID_LIM_COR_LBL.UseMnemonic = true;
			this.ID_LIM_COR_LBL.Visible = true;
			// 
			// CORLIMCR
			// 
			this.AcceptButton = this.ID_MEN_SAL_CB;
			this.AutoScaleBaseSize = new System.Drawing.Size(10, 19);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(574, 298);
			this.ControlBox = true;
			this.Controls.Add(this.ID_MEN_PRI_PNL);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Enabled = true;
			this.Font = new System.Drawing.Font("Courier New", 12f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = false;
			this.KeyPreview = false;
			this.ListBoxComboBoxHelper1.SetItemData(this.ID_LIM_COR_LIB, new int[]{0});
			this.ListBoxComboBoxHelper1.SetItemData(this.ID_LIM_EMP_LIB, new int[]{0});
			this.Location = new System.Drawing.Point(120, 197);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CORLIMCR";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "";
			this.Text = "Límites de Crédito Inconsistentes";
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			base.Closed += new System.EventHandler(this.CORLIMCR_Closed);
			((System.ComponentModel.ISupportInitialize) this.ListBoxComboBoxHelper1).EndInit();
			((System.ComponentModel.ISupportInitialize) this.ID_MEN_PRI_PNL).EndInit();
			this.ID_MEN_PRI_PNL.ResumeLayout(false);
			this.ResumeLayout(false);
	}
#endregion 
}
}