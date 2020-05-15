using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORCTEJB
	{
	
#region "Upgrade Support "
		private static CORCTEJB m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORCTEJB DefInstance
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
		public CORCTEJB():base(){
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
			InitializeID_CEB_ETI_PNL();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORCTEJB CreateInstance()
	{
			CORCTEJB theInstance = new CORCTEJB();
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
	public  System.Windows.Forms.ListBox ID_CEB_EJE_LB;
	public  System.Windows.Forms.Button ID_CEB_MAS_3PB;
	public  System.Windows.Forms.Button ID_CEB_CON_PB;
	public  System.Windows.Forms.Button Command4;
	public  System.Windows.Forms.Button ID_CEB_ALT_PB;
	public  System.Windows.Forms.Button ID_CEB_BAJ_PB;
	public  System.Windows.Forms.Button ID_CEB_CAM_PB;
	private  System.Windows.Forms.Label _ID_CEB_ETI_PNL_0;
	private  System.Windows.Forms.Label _ID_CEB_ETI_PNL_1;
	public  AxThreed.AxSSCheck ID_CEB_IRE_CKB;
	public  System.Windows.Forms.Panel ID_CEB_PPL_PNL;
	public System.Windows.Forms.Label[] ID_CEB_ETI_PNL = new System.Windows.Forms.Label[2];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORCTEJB));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_CEB_PPL_PNL = new System.Windows.Forms.Panel();
            this.ID_CEB_BAJ_PB = new System.Windows.Forms.Button();
            this.ID_CEB_CON_PB = new System.Windows.Forms.Button();
            this.Command4 = new System.Windows.Forms.Button();
            this.ID_CEB_ALT_PB = new System.Windows.Forms.Button();
            this._ID_CEB_ETI_PNL_1 = new System.Windows.Forms.Label();
            this.ID_CEB_IRE_CKB = new AxThreed.AxSSCheck();
            this.ID_CEB_CAM_PB = new System.Windows.Forms.Button();
            this._ID_CEB_ETI_PNL_0 = new System.Windows.Forms.Label();
            this.ID_CEB_EJE_LB = new System.Windows.Forms.ListBox();
            this.ID_CEB_MAS_3PB = new System.Windows.Forms.Button();
            this.ID_CEB_PPL_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEB_IRE_CKB)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_CEB_PPL_PNL
            // 
            this.ID_CEB_PPL_PNL.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ID_CEB_PPL_PNL.Controls.Add(this.ID_CEB_BAJ_PB);
            this.ID_CEB_PPL_PNL.Controls.Add(this.ID_CEB_CON_PB);
            this.ID_CEB_PPL_PNL.Controls.Add(this.Command4);
            this.ID_CEB_PPL_PNL.Controls.Add(this.ID_CEB_ALT_PB);
            this.ID_CEB_PPL_PNL.Controls.Add(this._ID_CEB_ETI_PNL_1);
            this.ID_CEB_PPL_PNL.Controls.Add(this.ID_CEB_IRE_CKB);
            this.ID_CEB_PPL_PNL.Controls.Add(this.ID_CEB_CAM_PB);
            this.ID_CEB_PPL_PNL.Controls.Add(this._ID_CEB_ETI_PNL_0);
            this.ID_CEB_PPL_PNL.Controls.Add(this.ID_CEB_EJE_LB);
            this.ID_CEB_PPL_PNL.Controls.Add(this.ID_CEB_MAS_3PB);
            this.ID_CEB_PPL_PNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEB_PPL_PNL.Location = new System.Drawing.Point(0, 1);
            this.ID_CEB_PPL_PNL.Name = "ID_CEB_PPL_PNL";
            this.ID_CEB_PPL_PNL.Size = new System.Drawing.Size(359, 256);
            this.ID_CEB_PPL_PNL.TabIndex = 0;
            this.ID_CEB_PPL_PNL.Tag = "";
            // 
            // ID_CEB_BAJ_PB
            // 
            this.ID_CEB_BAJ_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEB_BAJ_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEB_BAJ_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEB_BAJ_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEB_BAJ_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEB_BAJ_PB.Location = new System.Drawing.Point(260, 82);
            this.ID_CEB_BAJ_PB.Name = "ID_CEB_BAJ_PB";
            this.ID_CEB_BAJ_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEB_BAJ_PB.Size = new System.Drawing.Size(88, 22);
            this.ID_CEB_BAJ_PB.TabIndex = 4;
            this.ID_CEB_BAJ_PB.Tag = "";
            this.ID_CEB_BAJ_PB.Text = "&Bajas";
            this.ID_CEB_BAJ_PB.UseVisualStyleBackColor = false;
            this.ID_CEB_BAJ_PB.Click += new System.EventHandler(this.ID_CEB_BAJ_PB_Click);
            // 
            // ID_CEB_CON_PB
            // 
            this.ID_CEB_CON_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEB_CON_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEB_CON_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEB_CON_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEB_CON_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEB_CON_PB.Location = new System.Drawing.Point(260, 133);
            this.ID_CEB_CON_PB.Name = "ID_CEB_CON_PB";
            this.ID_CEB_CON_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEB_CON_PB.Size = new System.Drawing.Size(88, 22);
            this.ID_CEB_CON_PB.TabIndex = 7;
            this.ID_CEB_CON_PB.Tag = "";
            this.ID_CEB_CON_PB.Text = "C&onsultas...";
            this.ID_CEB_CON_PB.UseVisualStyleBackColor = false;
            this.ID_CEB_CON_PB.Click += new System.EventHandler(this.ID_CEB_CON_PB_Click);
            // 
            // Command4
            // 
            this.Command4.BackColor = System.Drawing.SystemColors.Control;
            this.Command4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Command4.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Command4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Command4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Command4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Command4.Location = new System.Drawing.Point(260, 167);
            this.Command4.Name = "Command4";
            this.Command4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Command4.Size = new System.Drawing.Size(88, 22);
            this.Command4.TabIndex = 6;
            this.Command4.Tag = "";
            this.Command4.Text = "&Salir";
            this.Command4.UseVisualStyleBackColor = false;
            this.Command4.Click += new System.EventHandler(this.Command4_Click);
            // 
            // ID_CEB_ALT_PB
            // 
            this.ID_CEB_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEB_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEB_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEB_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEB_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEB_ALT_PB.Location = new System.Drawing.Point(260, 55);
            this.ID_CEB_ALT_PB.Name = "ID_CEB_ALT_PB";
            this.ID_CEB_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEB_ALT_PB.Size = new System.Drawing.Size(88, 22);
            this.ID_CEB_ALT_PB.TabIndex = 5;
            this.ID_CEB_ALT_PB.Tag = "";
            this.ID_CEB_ALT_PB.Text = "&Altas...";
            this.ID_CEB_ALT_PB.UseVisualStyleBackColor = false;
            this.ID_CEB_ALT_PB.Click += new System.EventHandler(this.ID_CEB_ALT_PB_Click);
            // 
            // _ID_CEB_ETI_PNL_1
            // 
            this._ID_CEB_ETI_PNL_1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._ID_CEB_ETI_PNL_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ID_CEB_ETI_PNL_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEB_ETI_PNL_1.Location = new System.Drawing.Point(79, 28);
            this._ID_CEB_ETI_PNL_1.Name = "_ID_CEB_ETI_PNL_1";
            this._ID_CEB_ETI_PNL_1.Size = new System.Drawing.Size(174, 22);
            this._ID_CEB_ETI_PNL_1.TabIndex = 10;
            this._ID_CEB_ETI_PNL_1.Tag = "";
            this._ID_CEB_ETI_PNL_1.Text = " E&jecutivo";
            this._ID_CEB_ETI_PNL_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ID_CEB_IRE_CKB
            // 
            this.ID_CEB_IRE_CKB.Location = new System.Drawing.Point(20, 222);
            this.ID_CEB_IRE_CKB.Name = "ID_CEB_IRE_CKB";
            this.ID_CEB_IRE_CKB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CEB_IRE_CKB.OcxState")));
            this.ID_CEB_IRE_CKB.Size = new System.Drawing.Size(210, 21);
            this.ID_CEB_IRE_CKB.TabIndex = 9;
            this.ID_CEB_IRE_CKB.Tag = "";
            // 
            // ID_CEB_CAM_PB
            // 
            this.ID_CEB_CAM_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEB_CAM_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEB_CAM_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEB_CAM_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEB_CAM_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEB_CAM_PB.Location = new System.Drawing.Point(261, 107);
            this.ID_CEB_CAM_PB.Name = "ID_CEB_CAM_PB";
            this.ID_CEB_CAM_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEB_CAM_PB.Size = new System.Drawing.Size(88, 22);
            this.ID_CEB_CAM_PB.TabIndex = 2;
            this.ID_CEB_CAM_PB.Tag = "";
            this.ID_CEB_CAM_PB.Text = "&Cambios...";
            this.ID_CEB_CAM_PB.UseVisualStyleBackColor = false;
            this.ID_CEB_CAM_PB.Click += new System.EventHandler(this.ID_CEB_CAM_PB_Click);
            // 
            // _ID_CEB_ETI_PNL_0
            // 
            this._ID_CEB_ETI_PNL_0.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this._ID_CEB_ETI_PNL_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._ID_CEB_ETI_PNL_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._ID_CEB_ETI_PNL_0.Location = new System.Drawing.Point(16, 28);
            this._ID_CEB_ETI_PNL_0.Name = "_ID_CEB_ETI_PNL_0";
            this._ID_CEB_ETI_PNL_0.Size = new System.Drawing.Size(65, 22);
            this._ID_CEB_ETI_PNL_0.TabIndex = 1;
            this._ID_CEB_ETI_PNL_0.Tag = "";
            this._ID_CEB_ETI_PNL_0.Text = "  Nómina.";
            this._ID_CEB_ETI_PNL_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ID_CEB_EJE_LB
            // 
            this.ID_CEB_EJE_LB.BackColor = System.Drawing.Color.White;
            this.ID_CEB_EJE_LB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEB_EJE_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEB_EJE_LB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEB_EJE_LB.Location = new System.Drawing.Point(14, 52);
            this.ID_CEB_EJE_LB.Name = "ID_CEB_EJE_LB";
            this.ID_CEB_EJE_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEB_EJE_LB.Size = new System.Drawing.Size(239, 147);
            this.ID_CEB_EJE_LB.Sorted = true;
            this.ID_CEB_EJE_LB.TabIndex = 3;
            this.ID_CEB_EJE_LB.Tag = "";
            this.ID_CEB_EJE_LB.DoubleClick += new System.EventHandler(this.ID_CEB_EJE_LB_DoubleClick);
            this.ID_CEB_EJE_LB.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ID_CEB_EJE_LB_KeyDown);
            // 
            // ID_CEB_MAS_3PB
            // 
            this.ID_CEB_MAS_3PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEB_MAS_3PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEB_MAS_3PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEB_MAS_3PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEB_MAS_3PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEB_MAS_3PB.Location = new System.Drawing.Point(260, 216);
            this.ID_CEB_MAS_3PB.Name = "ID_CEB_MAS_3PB";
            this.ID_CEB_MAS_3PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEB_MAS_3PB.Size = new System.Drawing.Size(88, 22);
            this.ID_CEB_MAS_3PB.TabIndex = 8;
            this.ID_CEB_MAS_3PB.Tag = "A";
            this.ID_CEB_MAS_3PB.Text = "&Más";
            this.ID_CEB_MAS_3PB.UseVisualStyleBackColor = false;
            this.ID_CEB_MAS_3PB.Click += new System.EventHandler(this.ID_CEB_MAS_3PB_Click);
            // 
            // CORCTEJB
            // 
            this.AcceptButton = this.ID_CEB_ALT_PB;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.Command4;
            this.ClientSize = new System.Drawing.Size(359, 256);
            this.Controls.Add(this.ID_CEB_PPL_PNL);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(240, 118);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORCTEJB";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Ejecutivos Banamex";
            this.Activated += new System.EventHandler(this.CORCTEJB_Activated);
            this.Closed += new System.EventHandler(this.CORCTEJB_Closed);
            this.Load += new System.EventHandler(this.CORCTEJB_Load);
            this.ID_CEB_PPL_PNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEB_IRE_CKB)).EndInit();
            this.ResumeLayout(false);

	}
	void  InitializeID_CEB_ETI_PNL()
	{
			this.ID_CEB_ETI_PNL[0] = _ID_CEB_ETI_PNL_0;
			this.ID_CEB_ETI_PNL[1] = _ID_CEB_ETI_PNL_1;
	}
#endregion 
}
}