using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class EmpAsig
	{
	
#region "Upgrade Support "
		private static EmpAsig m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static EmpAsig DefInstance
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
		public EmpAsig():base(){
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
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static EmpAsig CreateInstance()
	{
			EmpAsig theInstance = new EmpAsig();
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
	public  System.Windows.Forms.ListBox EMPRESA_ESTRUCT_LB;
	public  System.Windows.Forms.Button Command2;
	private  System.Windows.Forms.Label _SSPanel1_1Label_Text;
	private  AxThreed.AxSSPanel _SSPanel1_1;
	public  System.Windows.Forms.GroupBox Frame1;
	public AxThreed.AxSSPanel[] SSPanel1 = new AxThreed.AxSSPanel[2];
	private Artinsoft.VB6.Gui.ListControlHelper ListBoxComboBoxHelper1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EmpAsig));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.Frame1 = new System.Windows.Forms.GroupBox();
        this._SSPanel1_0 = new AxThreed.AxSSPanel();
        this._SSPanel1_0Label_Text = new System.Windows.Forms.Label();
        this.EMPRESA_ESTRUCT_LB = new System.Windows.Forms.ListBox();
        this._SSPanel1_1 = new AxThreed.AxSSPanel();
        this._SSPanel1_1Label_Text = new System.Windows.Forms.Label();
        this.Command2 = new System.Windows.Forms.Button();
        this.ListBoxComboBoxHelper1 = new Artinsoft.VB6.Gui.ListControlHelper(this.components);
        this.Frame1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_0)).BeginInit();
        this._SSPanel1_0.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_1)).BeginInit();
        this._SSPanel1_1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).BeginInit();
        this.SuspendLayout();
        // 
        // Frame1
        // 
        this.Frame1.BackColor = System.Drawing.SystemColors.Control;
        this.Frame1.Controls.Add(this._SSPanel1_0);
        this.Frame1.Controls.Add(this.EMPRESA_ESTRUCT_LB);
        this.Frame1.Controls.Add(this._SSPanel1_1);
        this.Frame1.Controls.Add(this.Command2);
        this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Frame1.Location = new System.Drawing.Point(0, 0);
        this.Frame1.Name = "Frame1";
        this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Frame1.Size = new System.Drawing.Size(338, 181);
        this.Frame1.TabIndex = 0;
        this.Frame1.TabStop = false;
        this.Frame1.Tag = "";
        this.Frame1.Text = "Información Empresas";
        // 
        // _SSPanel1_0
        // 
        this._SSPanel1_0.Controls.Add(this._SSPanel1_0Label_Text);
        this._SSPanel1_0.Location = new System.Drawing.Point(19, 23);
        this._SSPanel1_0.Name = "_SSPanel1_0";
        this._SSPanel1_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_SSPanel1_0.OcxState")));
        this._SSPanel1_0.Size = new System.Drawing.Size(56, 16);
        this._SSPanel1_0.TabIndex = 3;
        this._SSPanel1_0.Tag = "";
        // 
        // _SSPanel1_0Label_Text
        // 
        this._SSPanel1_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._SSPanel1_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._SSPanel1_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._SSPanel1_0Label_Text.Location = new System.Drawing.Point(0, 0);
        this._SSPanel1_0Label_Text.Name = "_SSPanel1_0Label_Text";
        this._SSPanel1_0Label_Text.Size = new System.Drawing.Size(56, 16);
        this._SSPanel1_0Label_Text.TabIndex = 0;
        this._SSPanel1_0Label_Text.Tag = "";
        this._SSPanel1_0Label_Text.Text = "Numero";
        this._SSPanel1_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // EMPRESA_ESTRUCT_LB
        // 
        this.EMPRESA_ESTRUCT_LB.BackColor = System.Drawing.Color.White;
        this.EMPRESA_ESTRUCT_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.EMPRESA_ESTRUCT_LB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.EMPRESA_ESTRUCT_LB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ListBoxComboBoxHelper1.SetItemData(this.EMPRESA_ESTRUCT_LB, new int[] {
            0});
        this.EMPRESA_ESTRUCT_LB.ItemHeight = 14;
        this.EMPRESA_ESTRUCT_LB.Items.AddRange(new object[] {
            "EMPRESA_ESTRUCT_LB"});
        this.EMPRESA_ESTRUCT_LB.Location = new System.Drawing.Point(18, 38);
        this.EMPRESA_ESTRUCT_LB.Name = "EMPRESA_ESTRUCT_LB";
        this.EMPRESA_ESTRUCT_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.EMPRESA_ESTRUCT_LB.Size = new System.Drawing.Size(222, 116);
        this.EMPRESA_ESTRUCT_LB.Sorted = true;
        this.EMPRESA_ESTRUCT_LB.TabIndex = 2;
        this.EMPRESA_ESTRUCT_LB.Tag = "";
        // 
        // _SSPanel1_1
        // 
        this._SSPanel1_1.Controls.Add(this._SSPanel1_1Label_Text);
        this._SSPanel1_1.Location = new System.Drawing.Point(75, 23);
        this._SSPanel1_1.Name = "_SSPanel1_1";
        this._SSPanel1_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_SSPanel1_1.OcxState")));
        this._SSPanel1_1.Size = new System.Drawing.Size(166, 16);
        this._SSPanel1_1.TabIndex = 4;
        this._SSPanel1_1.Tag = "";
        // 
        // _SSPanel1_1Label_Text
        // 
        this._SSPanel1_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._SSPanel1_1Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._SSPanel1_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._SSPanel1_1Label_Text.Location = new System.Drawing.Point(0, 0);
        this._SSPanel1_1Label_Text.Name = "_SSPanel1_1Label_Text";
        this._SSPanel1_1Label_Text.Size = new System.Drawing.Size(166, 16);
        this._SSPanel1_1Label_Text.TabIndex = 0;
        this._SSPanel1_1Label_Text.Tag = "";
        this._SSPanel1_1Label_Text.Text = "Descripción";
        this._SSPanel1_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Command2
        // 
        this.Command2.BackColor = System.Drawing.SystemColors.Control;
        this.Command2.Cursor = System.Windows.Forms.Cursors.Default;
        this.Command2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.Command2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Command2.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Command2.Location = new System.Drawing.Point(248, 85);
        this.Command2.Name = "Command2";
        this.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Command2.Size = new System.Drawing.Size(81, 25);
        this.Command2.TabIndex = 1;
        this.Command2.Tag = "";
        this.Command2.Text = "Cerrar";
        this.Command2.UseVisualStyleBackColor = false;
        this.Command2.Click += new System.EventHandler(this.Command2_Click);
        // 
        // EmpAsig
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(338, 181);
        this.Controls.Add(this.Frame1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(311, 275);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "EmpAsig";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Empresas Asignadas";
        this.Closed += new System.EventHandler(this.EmpAsig_Closed);
        this.Frame1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_0)).EndInit();
        this._SSPanel1_0.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_1)).EndInit();
        this._SSPanel1_1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).EndInit();
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