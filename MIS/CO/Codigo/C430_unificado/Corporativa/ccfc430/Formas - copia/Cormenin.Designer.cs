using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORMENIN
	{
	
#region "Upgrade Support "
		private static CORMENIN m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORMENIN DefInstance
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
		public CORMENIN():base(){
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
	public static CORMENIN CreateInstance()
	{
			CORMENIN theInstance = new CORMENIN();
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
	public  System.Windows.Forms.Button ID_MEN_SAL_CB;
	public  System.Windows.Forms.ListBox ID_MEN_MEN_LIB;
	public  System.Windows.Forms.Label ID_MEM_SIT_LB;
	public  System.Windows.Forms.Label ID_MEM_TAB_LB;
	public  System.Windows.Forms.Label ID_MEM_MEN_LB;
	public  System.Windows.Forms.Label ID_MEM_ARC_LB;
	public  AxThreed.AxSSPanel ID_MEN_PRI_PNL;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORMENIN));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_MEN_PRI_PNL = new AxThreed.AxSSPanel();
        this.ID_MEM_SIT_LB = new System.Windows.Forms.Label();
        this.ID_MEN_MEN_LIB = new System.Windows.Forms.ListBox();
        this.ID_MEN_SAL_CB = new System.Windows.Forms.Button();
        this.ID_MEM_TAB_LB = new System.Windows.Forms.Label();
        this.ID_MEM_ARC_LB = new System.Windows.Forms.Label();
        this.ID_MEM_MEN_LB = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.ID_MEN_PRI_PNL)).BeginInit();
        this.ID_MEN_PRI_PNL.SuspendLayout();
        this.SuspendLayout();
        // 
        // ID_MEN_PRI_PNL
        // 
        this.ID_MEN_PRI_PNL.Controls.Add(this.ID_MEM_SIT_LB);
        this.ID_MEN_PRI_PNL.Controls.Add(this.ID_MEN_MEN_LIB);
        this.ID_MEN_PRI_PNL.Controls.Add(this.ID_MEM_TAB_LB);
        this.ID_MEN_PRI_PNL.Controls.Add(this.ID_MEM_ARC_LB);
        this.ID_MEN_PRI_PNL.Controls.Add(this.ID_MEM_MEN_LB);
        this.ID_MEN_PRI_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_MEN_PRI_PNL.Name = "ID_MEN_PRI_PNL";
        this.ID_MEN_PRI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_MEN_PRI_PNL.OcxState")));
        this.ID_MEN_PRI_PNL.Size = new System.Drawing.Size(577, 215);
        this.ID_MEN_PRI_PNL.TabIndex = 1;
        this.ID_MEN_PRI_PNL.Tag = "";
        // 
        // ID_MEM_SIT_LB
        // 
        this.ID_MEM_SIT_LB.AutoSize = true;
        this.ID_MEM_SIT_LB.BackColor = System.Drawing.Color.Silver;
        this.ID_MEM_SIT_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_MEM_SIT_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_MEM_SIT_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_MEM_SIT_LB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_MEM_SIT_LB.Location = new System.Drawing.Point(274, 5);
        this.ID_MEM_SIT_LB.Name = "ID_MEM_SIT_LB";
        this.ID_MEM_SIT_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_MEM_SIT_LB.Size = new System.Drawing.Size(72, 16);
        this.ID_MEM_SIT_LB.TabIndex = 6;
        this.ID_MEM_SIT_LB.Tag = "";
        this.ID_MEM_SIT_LB.Text = "Situación";
        // 
        // ID_MEN_MEN_LIB
        // 
        this.ID_MEN_MEN_LIB.BackColor = System.Drawing.SystemColors.Window;
        this.ID_MEN_MEN_LIB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_MEN_MEN_LIB.Font = new System.Drawing.Font("Courier New", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_MEN_MEN_LIB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
        this.ID_MEN_MEN_LIB.ItemHeight = 18;
        this.ID_MEN_MEN_LIB.Location = new System.Drawing.Point(9, 24);
        this.ID_MEN_MEN_LIB.Name = "ID_MEN_MEN_LIB";
        this.ID_MEN_MEN_LIB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_MEN_MEN_LIB.Size = new System.Drawing.Size(557, 94);
        this.ID_MEN_MEN_LIB.TabIndex = 2;
        this.ID_MEN_MEN_LIB.Tag = "";
        // 
        // ID_MEN_SAL_CB
        // 
        this.ID_MEN_SAL_CB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_MEN_SAL_CB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_MEN_SAL_CB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_MEN_SAL_CB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_MEN_SAL_CB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_MEN_SAL_CB.Location = new System.Drawing.Point(488, 177);
        this.ID_MEN_SAL_CB.Name = "ID_MEN_SAL_CB";
        this.ID_MEN_SAL_CB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_MEN_SAL_CB.Size = new System.Drawing.Size(79, 26);
        this.ID_MEN_SAL_CB.TabIndex = 0;
        this.ID_MEN_SAL_CB.Tag = "";
        this.ID_MEN_SAL_CB.Text = "Aceptar";
        this.ID_MEN_SAL_CB.UseVisualStyleBackColor = false;
        this.ID_MEN_SAL_CB.Click += new System.EventHandler(this.ID_MEN_SAL_CB_Click);
        // 
        // ID_MEM_TAB_LB
        // 
        this.ID_MEM_TAB_LB.BackColor = System.Drawing.Color.Silver;
        this.ID_MEM_TAB_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_MEM_TAB_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_MEM_TAB_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_MEM_TAB_LB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_MEM_TAB_LB.Location = new System.Drawing.Point(111, 6);
        this.ID_MEM_TAB_LB.Name = "ID_MEM_TAB_LB";
        this.ID_MEM_TAB_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_MEM_TAB_LB.Size = new System.Drawing.Size(64, 13);
        this.ID_MEM_TAB_LB.TabIndex = 5;
        this.ID_MEM_TAB_LB.Tag = "";
        this.ID_MEM_TAB_LB.Text = "Tabla";
        // 
        // ID_MEM_ARC_LB
        // 
        this.ID_MEM_ARC_LB.AutoSize = true;
        this.ID_MEM_ARC_LB.BackColor = System.Drawing.Color.Silver;
        this.ID_MEM_ARC_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_MEM_ARC_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_MEM_ARC_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_MEM_ARC_LB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_MEM_ARC_LB.Location = new System.Drawing.Point(11, 4);
        this.ID_MEM_ARC_LB.Name = "ID_MEM_ARC_LB";
        this.ID_MEM_ARC_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_MEM_ARC_LB.Size = new System.Drawing.Size(60, 16);
        this.ID_MEM_ARC_LB.TabIndex = 3;
        this.ID_MEM_ARC_LB.Tag = "";
        this.ID_MEM_ARC_LB.Text = "Archivo";
        // 
        // ID_MEM_MEN_LB
        // 
        this.ID_MEM_MEN_LB.AutoSize = true;
        this.ID_MEM_MEN_LB.BackColor = System.Drawing.Color.Silver;
        this.ID_MEM_MEN_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_MEM_MEN_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_MEM_MEN_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_MEM_MEN_LB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_MEM_MEN_LB.Location = new System.Drawing.Point(405, 5);
        this.ID_MEM_MEN_LB.Name = "ID_MEM_MEN_LB";
        this.ID_MEM_MEN_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_MEM_MEN_LB.Size = new System.Drawing.Size(55, 16);
        this.ID_MEM_MEN_LB.TabIndex = 4;
        this.ID_MEM_MEN_LB.Tag = "";
        this.ID_MEM_MEN_LB.Text = "Acción";
        // 
        // CORMENIN
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(10, 19);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(578, 217);
        this.ControlBox = false;
        this.Controls.Add(this.ID_MEN_SAL_CB);
        this.Controls.Add(this.ID_MEN_PRI_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Courier New", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(94, 184);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORMENIN";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Estatus de Integración";
        this.Closed += new System.EventHandler(this.CORMENIN_Closed);
        this.Activated += new System.EventHandler(this.CORMENIN_Activated);
        ((System.ComponentModel.ISupportInitialize)(this.ID_MEN_PRI_PNL)).EndInit();
        this.ID_MEN_PRI_PNL.ResumeLayout(false);
        this.ID_MEN_PRI_PNL.PerformLayout();
        this.ResumeLayout(false);

	}
#endregion 
}
}