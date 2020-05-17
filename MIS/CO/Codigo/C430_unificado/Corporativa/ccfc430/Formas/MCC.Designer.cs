using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class MCC
	{
	
#region "Upgrade Support "
		private static MCC m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static MCC DefInstance
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
		public MCC():base(){
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
			InitializeSSPanel1();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static MCC CreateInstance()
	{
			MCC theInstance = new MCC();
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
	private  System.Windows.Forms.Label _SSPanel1_0Label_Text;
	private  AxThreed.AxSSPanel _SSPanel1_0;
	public  System.Windows.Forms.ListBox ID_MCC_GRP_LB;
	public  System.Windows.Forms.Button CM_CAN_MCC;
	public  System.Windows.Forms.Button CM_SEL_MCC;
	private  System.Windows.Forms.Label _SSPanel1_1Label_Text;
	private  AxThreed.AxSSPanel _SSPanel1_1;
	public  System.Windows.Forms.GroupBox Frame1;
	public AxThreed.AxSSPanel[] SSPanel1 = new AxThreed.AxSSPanel[2];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MCC));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.Frame1 = new System.Windows.Forms.GroupBox();
        this.ID_MCC_GRP_LB = new System.Windows.Forms.ListBox();
        this._SSPanel1_0 = new AxThreed.AxSSPanel();
        this._SSPanel1_0Label_Text = new System.Windows.Forms.Label();
        this.CM_CAN_MCC = new System.Windows.Forms.Button();
        this.CM_SEL_MCC = new System.Windows.Forms.Button();
        this._SSPanel1_1 = new AxThreed.AxSSPanel();
        this._SSPanel1_1Label_Text = new System.Windows.Forms.Label();
        this.Frame1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_0)).BeginInit();
        this._SSPanel1_0.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_1)).BeginInit();
        this._SSPanel1_1.SuspendLayout();
        this.SuspendLayout();
        // 
        // Frame1
        // 
        this.Frame1.BackColor = System.Drawing.SystemColors.Control;
        this.Frame1.Controls.Add(this.ID_MCC_GRP_LB);
        this.Frame1.Controls.Add(this._SSPanel1_0);
        this.Frame1.Controls.Add(this.CM_CAN_MCC);
        this.Frame1.Controls.Add(this.CM_SEL_MCC);
        this.Frame1.Controls.Add(this._SSPanel1_1);
        this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Frame1.Location = new System.Drawing.Point(0, 0);
        this.Frame1.Name = "Frame1";
        this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Frame1.Size = new System.Drawing.Size(429, 193);
        this.Frame1.TabIndex = 0;
        this.Frame1.TabStop = false;
        this.Frame1.Tag = "";
        this.Frame1.Text = "Información MCC";
        // 
        // ID_MCC_GRP_LB
        // 
        this.ID_MCC_GRP_LB.BackColor = System.Drawing.Color.White;
        this.ID_MCC_GRP_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_MCC_GRP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_MCC_GRP_LB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_MCC_GRP_LB.Location = new System.Drawing.Point(12, 44);
        this.ID_MCC_GRP_LB.Name = "ID_MCC_GRP_LB";
        this.ID_MCC_GRP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_MCC_GRP_LB.Size = new System.Drawing.Size(309, 134);
        this.ID_MCC_GRP_LB.Sorted = true;
        this.ID_MCC_GRP_LB.TabIndex = 3;
        this.ID_MCC_GRP_LB.Tag = "";
        // 
        // _SSPanel1_0
        // 
        this._SSPanel1_0.Controls.Add(this._SSPanel1_0Label_Text);
        this._SSPanel1_0.Location = new System.Drawing.Point(12, 25);
        this._SSPanel1_0.Name = "_SSPanel1_0";
        this._SSPanel1_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_SSPanel1_0.OcxState")));
        this._SSPanel1_0.Size = new System.Drawing.Size(75, 20);
        this._SSPanel1_0.TabIndex = 4;
        this._SSPanel1_0.Tag = "";
        // 
        // _SSPanel1_0Label_Text
        // 
        this._SSPanel1_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._SSPanel1_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._SSPanel1_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._SSPanel1_0Label_Text.Location = new System.Drawing.Point(0, 0);
        this._SSPanel1_0Label_Text.Name = "_SSPanel1_0Label_Text";
        this._SSPanel1_0Label_Text.Size = new System.Drawing.Size(75, 20);
        this._SSPanel1_0Label_Text.TabIndex = 0;
        this._SSPanel1_0Label_Text.Tag = "";
        this._SSPanel1_0Label_Text.Text = "Categoría";
        this._SSPanel1_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // CM_CAN_MCC
        // 
        this.CM_CAN_MCC.BackColor = System.Drawing.SystemColors.Control;
        this.CM_CAN_MCC.Cursor = System.Windows.Forms.Cursors.Default;
        this.CM_CAN_MCC.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.CM_CAN_MCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CM_CAN_MCC.ForeColor = System.Drawing.SystemColors.ControlText;
        this.CM_CAN_MCC.Location = new System.Drawing.Point(333, 115);
        this.CM_CAN_MCC.Name = "CM_CAN_MCC";
        this.CM_CAN_MCC.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CM_CAN_MCC.Size = new System.Drawing.Size(81, 25);
        this.CM_CAN_MCC.TabIndex = 2;
        this.CM_CAN_MCC.Tag = "";
        this.CM_CAN_MCC.Text = "Cancelar";
        this.CM_CAN_MCC.UseVisualStyleBackColor = false;
        this.CM_CAN_MCC.Click += new System.EventHandler(this.CM_CAN_MCC_Click);
        // 
        // CM_SEL_MCC
        // 
        this.CM_SEL_MCC.BackColor = System.Drawing.SystemColors.Control;
        this.CM_SEL_MCC.Cursor = System.Windows.Forms.Cursors.Default;
        this.CM_SEL_MCC.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.CM_SEL_MCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CM_SEL_MCC.ForeColor = System.Drawing.SystemColors.ControlText;
        this.CM_SEL_MCC.Location = new System.Drawing.Point(333, 62);
        this.CM_SEL_MCC.Name = "CM_SEL_MCC";
        this.CM_SEL_MCC.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CM_SEL_MCC.Size = new System.Drawing.Size(81, 25);
        this.CM_SEL_MCC.TabIndex = 1;
        this.CM_SEL_MCC.Tag = "";
        this.CM_SEL_MCC.Text = "Seleccionar";
        this.CM_SEL_MCC.UseVisualStyleBackColor = false;
        this.CM_SEL_MCC.Click += new System.EventHandler(this.CM_SEL_MCC_Click);
        // 
        // _SSPanel1_1
        // 
        this._SSPanel1_1.Controls.Add(this._SSPanel1_1Label_Text);
        this._SSPanel1_1.Location = new System.Drawing.Point(87, 25);
        this._SSPanel1_1.Name = "_SSPanel1_1";
        this._SSPanel1_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_SSPanel1_1.OcxState")));
        this._SSPanel1_1.Size = new System.Drawing.Size(235, 20);
        this._SSPanel1_1.TabIndex = 5;
        this._SSPanel1_1.Tag = "";
        // 
        // _SSPanel1_1Label_Text
        // 
        this._SSPanel1_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._SSPanel1_1Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._SSPanel1_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._SSPanel1_1Label_Text.Location = new System.Drawing.Point(0, 0);
        this._SSPanel1_1Label_Text.Name = "_SSPanel1_1Label_Text";
        this._SSPanel1_1Label_Text.Size = new System.Drawing.Size(235, 20);
        this._SSPanel1_1Label_Text.TabIndex = 0;
        this._SSPanel1_1Label_Text.Tag = "";
        this._SSPanel1_1Label_Text.Text = "Descripción";
        this._SSPanel1_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // MCC
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(429, 193);
        this.Controls.Add(this.Frame1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(353, 276);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "MCC";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Listado de MCC";
        this.Closed += new System.EventHandler(this.MCC_Closed);
        this.Frame1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_0)).EndInit();
        this._SSPanel1_0.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_1)).EndInit();
        this._SSPanel1_1.ResumeLayout(false);
        this.ResumeLayout(false);

	}
	void  InitializeSSPanel1()
	{
			this.SSPanel1[0] = _SSPanel1_0;
			this.SSPanel1[1] = _SSPanel1_1;
	}
#endregion 
}
}