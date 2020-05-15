using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORSGGRU
	{
	
#region "Upgrade Support "
		private static CORSGGRU m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORSGGRU DefInstance
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
		public CORSGGRU():base(){
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
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static CORSGGRU CreateInstance()
	{
			CORSGGRU theInstance = new CORSGGRU();
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
	public  System.Windows.Forms.Button ID_GRU_CON_PB;
	public  System.Windows.Forms.Button ID_GRU_SAL_PB;
	public  System.Windows.Forms.Button ID_GRU_CAM_PB;
	public  System.Windows.Forms.Button ID_GRU_BAJ_PB;
	public  System.Windows.Forms.Button ID_GRU_ALT_PB;
	public  System.Windows.Forms.ListBox ID_GRU_GRU_LB;
	public  System.Windows.Forms.Label ID_GRU_CVE_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_GRU_CVE_PNL;
	public  System.Windows.Forms.Label ID_GRU_NOM_PNLLabel_Text;
	public  AxThreed.AxSSPanel ID_GRU_NOM_PNL;
	public  System.Windows.Forms.GroupBox Frame1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORSGGRU));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.Frame1 = new System.Windows.Forms.GroupBox();
        this.ID_GRU_CAM_PB = new System.Windows.Forms.Button();
        this.ID_GRU_CON_PB = new System.Windows.Forms.Button();
        this.ID_GRU_SAL_PB = new System.Windows.Forms.Button();
        this.ID_GRU_BAJ_PB = new System.Windows.Forms.Button();
        this.ID_GRU_CVE_PNL = new AxThreed.AxSSPanel();
        this.ID_GRU_CVE_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_GRU_NOM_PNL = new AxThreed.AxSSPanel();
        this.ID_GRU_NOM_PNLLabel_Text = new System.Windows.Forms.Label();
        this.ID_GRU_ALT_PB = new System.Windows.Forms.Button();
        this.ID_GRU_GRU_LB = new System.Windows.Forms.ListBox();
        this.Frame1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRU_CVE_PNL)).BeginInit();
        this.ID_GRU_CVE_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRU_NOM_PNL)).BeginInit();
        this.ID_GRU_NOM_PNL.SuspendLayout();
        this.SuspendLayout();
        // 
        // Frame1
        // 
        this.Frame1.BackColor = System.Drawing.SystemColors.Control;
        this.Frame1.Controls.Add(this.ID_GRU_CAM_PB);
        this.Frame1.Controls.Add(this.ID_GRU_CON_PB);
        this.Frame1.Controls.Add(this.ID_GRU_SAL_PB);
        this.Frame1.Controls.Add(this.ID_GRU_BAJ_PB);
        this.Frame1.Controls.Add(this.ID_GRU_CVE_PNL);
        this.Frame1.Controls.Add(this.ID_GRU_NOM_PNL);
        this.Frame1.Controls.Add(this.ID_GRU_ALT_PB);
        this.Frame1.Controls.Add(this.ID_GRU_GRU_LB);
        this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Frame1.Location = new System.Drawing.Point(0, 0);
        this.Frame1.Name = "Frame1";
        this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Frame1.Size = new System.Drawing.Size(371, 221);
        this.Frame1.TabIndex = 0;
        this.Frame1.TabStop = false;
        this.Frame1.Tag = "";
        this.Frame1.Text = "Datos Grupos";
        // 
        // ID_GRU_CAM_PB
        // 
        this.ID_GRU_CAM_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRU_CAM_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRU_CAM_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRU_CAM_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRU_CAM_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRU_CAM_PB.Location = new System.Drawing.Point(271, 103);
        this.ID_GRU_CAM_PB.Name = "ID_GRU_CAM_PB";
        this.ID_GRU_CAM_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRU_CAM_PB.Size = new System.Drawing.Size(83, 25);
        this.ID_GRU_CAM_PB.TabIndex = 4;
        this.ID_GRU_CAM_PB.Tag = "";
        this.ID_GRU_CAM_PB.Text = "&Cambio...";
        this.ID_GRU_CAM_PB.UseVisualStyleBackColor = false;
        this.ID_GRU_CAM_PB.Click += new System.EventHandler(this.ID_GRU_CAM_PB_Click);
        // 
        // ID_GRU_CON_PB
        // 
        this.ID_GRU_CON_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRU_CON_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRU_CON_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRU_CON_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRU_CON_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRU_CON_PB.Location = new System.Drawing.Point(271, 134);
        this.ID_GRU_CON_PB.Name = "ID_GRU_CON_PB";
        this.ID_GRU_CON_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRU_CON_PB.Size = new System.Drawing.Size(83, 25);
        this.ID_GRU_CON_PB.TabIndex = 6;
        this.ID_GRU_CON_PB.Tag = "";
        this.ID_GRU_CON_PB.Text = "Co&nsulta...";
        this.ID_GRU_CON_PB.UseVisualStyleBackColor = false;
        this.ID_GRU_CON_PB.Click += new System.EventHandler(this.ID_GRU_CON_PB_Click);
        // 
        // ID_GRU_SAL_PB
        // 
        this.ID_GRU_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRU_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRU_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_GRU_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRU_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRU_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRU_SAL_PB.Location = new System.Drawing.Point(271, 165);
        this.ID_GRU_SAL_PB.Name = "ID_GRU_SAL_PB";
        this.ID_GRU_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRU_SAL_PB.Size = new System.Drawing.Size(83, 25);
        this.ID_GRU_SAL_PB.TabIndex = 5;
        this.ID_GRU_SAL_PB.Tag = "";
        this.ID_GRU_SAL_PB.Text = "&Salir";
        this.ID_GRU_SAL_PB.UseVisualStyleBackColor = false;
        this.ID_GRU_SAL_PB.Click += new System.EventHandler(this.ID_GRU_SAL_PB_Click);
        // 
        // ID_GRU_BAJ_PB
        // 
        this.ID_GRU_BAJ_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRU_BAJ_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRU_BAJ_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRU_BAJ_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRU_BAJ_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRU_BAJ_PB.Location = new System.Drawing.Point(271, 72);
        this.ID_GRU_BAJ_PB.Name = "ID_GRU_BAJ_PB";
        this.ID_GRU_BAJ_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRU_BAJ_PB.Size = new System.Drawing.Size(83, 25);
        this.ID_GRU_BAJ_PB.TabIndex = 3;
        this.ID_GRU_BAJ_PB.Tag = "";
        this.ID_GRU_BAJ_PB.Text = "&Baja";
        this.ID_GRU_BAJ_PB.UseVisualStyleBackColor = false;
        this.ID_GRU_BAJ_PB.Click += new System.EventHandler(this.ID_GRU_BAJ_PB_Click);
        // 
        // ID_GRU_CVE_PNL
        // 
        this.ID_GRU_CVE_PNL.Controls.Add(this.ID_GRU_CVE_PNLLabel_Text);
        this.ID_GRU_CVE_PNL.Location = new System.Drawing.Point(13, 21);
        this.ID_GRU_CVE_PNL.Name = "ID_GRU_CVE_PNL";
        this.ID_GRU_CVE_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRU_CVE_PNL.OcxState")));
        this.ID_GRU_CVE_PNL.Size = new System.Drawing.Size(78, 27);
        this.ID_GRU_CVE_PNL.TabIndex = 7;
        this.ID_GRU_CVE_PNL.Tag = "";
        // 
        // ID_GRU_CVE_PNLLabel_Text
        // 
        this.ID_GRU_CVE_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRU_CVE_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_GRU_CVE_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_GRU_CVE_PNLLabel_Text.Name = "ID_GRU_CVE_PNLLabel_Text";
        this.ID_GRU_CVE_PNLLabel_Text.Size = new System.Drawing.Size(72, 21);
        this.ID_GRU_CVE_PNLLabel_Text.TabIndex = 0;
        this.ID_GRU_CVE_PNLLabel_Text.Tag = "";
        this.ID_GRU_CVE_PNLLabel_Text.Text = "Clave";
        this.ID_GRU_CVE_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_GRU_NOM_PNL
        // 
        this.ID_GRU_NOM_PNL.Controls.Add(this.ID_GRU_NOM_PNLLabel_Text);
        this.ID_GRU_NOM_PNL.Location = new System.Drawing.Point(83, 21);
        this.ID_GRU_NOM_PNL.Name = "ID_GRU_NOM_PNL";
        this.ID_GRU_NOM_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_GRU_NOM_PNL.OcxState")));
        this.ID_GRU_NOM_PNL.Size = new System.Drawing.Size(173, 22);
        this.ID_GRU_NOM_PNL.TabIndex = 8;
        this.ID_GRU_NOM_PNL.Tag = "";
        // 
        // ID_GRU_NOM_PNLLabel_Text
        // 
        this.ID_GRU_NOM_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRU_NOM_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.ID_GRU_NOM_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.ID_GRU_NOM_PNLLabel_Text.Name = "ID_GRU_NOM_PNLLabel_Text";
        this.ID_GRU_NOM_PNLLabel_Text.Size = new System.Drawing.Size(173, 22);
        this.ID_GRU_NOM_PNLLabel_Text.TabIndex = 0;
        this.ID_GRU_NOM_PNLLabel_Text.Tag = "";
        this.ID_GRU_NOM_PNLLabel_Text.Text = "Descripción";
        this.ID_GRU_NOM_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_GRU_ALT_PB
        // 
        this.ID_GRU_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_GRU_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRU_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_GRU_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRU_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_GRU_ALT_PB.Location = new System.Drawing.Point(271, 40);
        this.ID_GRU_ALT_PB.Name = "ID_GRU_ALT_PB";
        this.ID_GRU_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRU_ALT_PB.Size = new System.Drawing.Size(83, 25);
        this.ID_GRU_ALT_PB.TabIndex = 2;
        this.ID_GRU_ALT_PB.Tag = "";
        this.ID_GRU_ALT_PB.Text = "&Alta...";
        this.ID_GRU_ALT_PB.UseVisualStyleBackColor = false;
        this.ID_GRU_ALT_PB.Click += new System.EventHandler(this.ID_GRU_ALT_PB_Click);
        // 
        // ID_GRU_GRU_LB
        // 
        this.ID_GRU_GRU_LB.BackColor = System.Drawing.Color.White;
        this.ID_GRU_GRU_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_GRU_GRU_LB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_GRU_GRU_LB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_GRU_GRU_LB.ItemHeight = 14;
        this.ID_GRU_GRU_LB.Location = new System.Drawing.Point(15, 39);
        this.ID_GRU_GRU_LB.Name = "ID_GRU_GRU_LB";
        this.ID_GRU_GRU_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_GRU_GRU_LB.Size = new System.Drawing.Size(238, 158);
        this.ID_GRU_GRU_LB.TabIndex = 1;
        this.ID_GRU_GRU_LB.Tag = "";
        // 
        // CORSGGRU
        // 
        this.AcceptButton = this.ID_GRU_ALT_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Menu;
        this.CancelButton = this.ID_GRU_SAL_PB;
        this.ClientSize = new System.Drawing.Size(371, 221);
        this.Controls.Add(this.Frame1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.KeyPreview = true;
        this.Location = new System.Drawing.Point(297, 226);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORSGGRU";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Grupos";
        this.Closed += new System.EventHandler(this.CORSGGRU_Closed);
        this.Activated += new System.EventHandler(this.CORSGGRU_Activated);
        this.Frame1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRU_CVE_PNL)).EndInit();
        this.ID_GRU_CVE_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ID_GRU_NOM_PNL)).EndInit();
        this.ID_GRU_NOM_PNL.ResumeLayout(false);
        this.ResumeLayout(false);

	}
#endregion 
}
}