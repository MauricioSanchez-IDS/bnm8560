using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORIRUNI
	{
	
#region "Upgrade Support "
		private static CORIRUNI m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORIRUNI DefInstance
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
		public CORIRUNI():base(){
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
			InitializemkbMaskebox();
			InitializeCMD_IR_A();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static CORIRUNI CreateInstance()
	{
			CORIRUNI theInstance = new CORIRUNI();
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
	public  System.Windows.Forms.Label SSPanel3Label_Text;
	public  AxThreed.AxSSPanel SSPanel3;
	public  System.Windows.Forms.Label SSPanel2Label_Text;
	public  AxThreed.AxSSPanel SSPanel2;
	public  System.Windows.Forms.ListBox LST_IR_A;
	private  System.Windows.Forms.Button _CMD_IR_A_0;
	private  System.Windows.Forms.Button _CMD_IR_A_1;
	private  System.Windows.Forms.Label _SSPanel1_0Label_Text;
	private  AxThreed.AxSSPanel _SSPanel1_0;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_0;
	private  System.Windows.Forms.Label _SSPanel1_1Label_Text;
	private  AxThreed.AxSSPanel _SSPanel1_1;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_1;
	public System.Windows.Forms.Button[] CMD_IR_A = new System.Windows.Forms.Button[2];
	public AxThreed.AxSSPanel[] SSPanel1 = new AxThreed.AxSSPanel[2];
	public AxMSMask.AxMaskEdBox[] mkbMaskebox = new AxMSMask.AxMaskEdBox[2];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORIRUNI));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.SSPanel3 = new AxThreed.AxSSPanel();
        this.SSPanel3Label_Text = new System.Windows.Forms.Label();
        this.SSPanel2 = new AxThreed.AxSSPanel();
        this.SSPanel2Label_Text = new System.Windows.Forms.Label();
        this.LST_IR_A = new System.Windows.Forms.ListBox();
        this._CMD_IR_A_0 = new System.Windows.Forms.Button();
        this._CMD_IR_A_1 = new System.Windows.Forms.Button();
        this._SSPanel1_0 = new AxThreed.AxSSPanel();
        this._SSPanel1_0Label_Text = new System.Windows.Forms.Label();
        this._mkbMaskebox_0 = new AxMSMask.AxMaskEdBox();
        this._SSPanel1_1 = new AxThreed.AxSSPanel();
        this._SSPanel1_1Label_Text = new System.Windows.Forms.Label();
        this._mkbMaskebox_1 = new AxMSMask.AxMaskEdBox();
        ((System.ComponentModel.ISupportInitialize)(this.SSPanel3)).BeginInit();
        this.SSPanel3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.SSPanel2)).BeginInit();
        this.SSPanel2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_0)).BeginInit();
        this._SSPanel1_0.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_1)).BeginInit();
        this._SSPanel1_1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_1)).BeginInit();
        this.SuspendLayout();
        // 
        // SSPanel3
        // 
        this.SSPanel3.Controls.Add(this.SSPanel3Label_Text);
        this.SSPanel3.Location = new System.Drawing.Point(146, 128);
        this.SSPanel3.Name = "SSPanel3";
        this.SSPanel3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SSPanel3.OcxState")));
        this.SSPanel3.Size = new System.Drawing.Size(257, 25);
        this.SSPanel3.TabIndex = 8;
        this.SSPanel3.Tag = "";
        // 
        // SSPanel3Label_Text
        // 
        this.SSPanel3Label_Text.BackColor = System.Drawing.Color.Silver;
        this.SSPanel3Label_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.SSPanel3Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.SSPanel3Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.SSPanel3Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.SSPanel3Label_Text.Location = new System.Drawing.Point(0, 0);
        this.SSPanel3Label_Text.Name = "SSPanel3Label_Text";
        this.SSPanel3Label_Text.Size = new System.Drawing.Size(257, 25);
        this.SSPanel3Label_Text.TabIndex = 0;
        this.SSPanel3Label_Text.Tag = "";
        this.SSPanel3Label_Text.Text = "Nombre Unidad";
        this.SSPanel3Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // SSPanel2
        // 
        this.SSPanel2.Controls.Add(this.SSPanel2Label_Text);
        this.SSPanel2.Location = new System.Drawing.Point(22, 128);
        this.SSPanel2.Name = "SSPanel2";
        this.SSPanel2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SSPanel2.OcxState")));
        this.SSPanel2.Size = new System.Drawing.Size(123, 25);
        this.SSPanel2.TabIndex = 7;
        this.SSPanel2.Tag = "";
        // 
        // SSPanel2Label_Text
        // 
        this.SSPanel2Label_Text.BackColor = System.Drawing.Color.Silver;
        this.SSPanel2Label_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.SSPanel2Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.SSPanel2Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.SSPanel2Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this.SSPanel2Label_Text.Location = new System.Drawing.Point(0, 0);
        this.SSPanel2Label_Text.Name = "SSPanel2Label_Text";
        this.SSPanel2Label_Text.Size = new System.Drawing.Size(123, 25);
        this.SSPanel2Label_Text.TabIndex = 0;
        this.SSPanel2Label_Text.Tag = "";
        this.SSPanel2Label_Text.Text = "No. de Unidad";
        this.SSPanel2Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // LST_IR_A
        // 
        this.LST_IR_A.BackColor = System.Drawing.SystemColors.Window;
        this.LST_IR_A.Cursor = System.Windows.Forms.Cursors.Default;
        this.LST_IR_A.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.LST_IR_A.ForeColor = System.Drawing.SystemColors.WindowText;
        this.LST_IR_A.ItemHeight = 14;
        this.LST_IR_A.Location = new System.Drawing.Point(22, 152);
        this.LST_IR_A.Name = "LST_IR_A";
        this.LST_IR_A.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.LST_IR_A.Size = new System.Drawing.Size(380, 88);
        this.LST_IR_A.TabIndex = 4;
        this.LST_IR_A.Tag = "";
        this.LST_IR_A.DoubleClick += new System.EventHandler(this.LST_IR_A_DoubleClick);
        // 
        // _CMD_IR_A_0
        // 
        this._CMD_IR_A_0.BackColor = System.Drawing.SystemColors.Control;
        this._CMD_IR_A_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._CMD_IR_A_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._CMD_IR_A_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._CMD_IR_A_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._CMD_IR_A_0.Location = new System.Drawing.Point(122, 87);
        this._CMD_IR_A_0.Name = "_CMD_IR_A_0";
        this._CMD_IR_A_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._CMD_IR_A_0.Size = new System.Drawing.Size(73, 23);
        this._CMD_IR_A_0.TabIndex = 2;
        this._CMD_IR_A_0.Tag = "";
        this._CMD_IR_A_0.Text = "&Aceptar";
        this._CMD_IR_A_0.UseVisualStyleBackColor = false;
        this._CMD_IR_A_0.Click += new System.EventHandler(this.CMD_IR_A_Click);
        // 
        // _CMD_IR_A_1
        // 
        this._CMD_IR_A_1.BackColor = System.Drawing.SystemColors.Control;
        this._CMD_IR_A_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._CMD_IR_A_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._CMD_IR_A_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._CMD_IR_A_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._CMD_IR_A_1.Location = new System.Drawing.Point(236, 87);
        this._CMD_IR_A_1.Name = "_CMD_IR_A_1";
        this._CMD_IR_A_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._CMD_IR_A_1.Size = new System.Drawing.Size(73, 23);
        this._CMD_IR_A_1.TabIndex = 3;
        this._CMD_IR_A_1.Tag = "";
        this._CMD_IR_A_1.Text = "&Cancelar";
        this._CMD_IR_A_1.UseVisualStyleBackColor = false;
        this._CMD_IR_A_1.Click += new System.EventHandler(this.CMD_IR_A_Click);
        // 
        // _SSPanel1_0
        // 
        this._SSPanel1_0.Controls.Add(this._SSPanel1_0Label_Text);
        this._SSPanel1_0.Location = new System.Drawing.Point(94, 24);
        this._SSPanel1_0.Name = "_SSPanel1_0";
        this._SSPanel1_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_SSPanel1_0.OcxState")));
        this._SSPanel1_0.Size = new System.Drawing.Size(102, 16);
        this._SSPanel1_0.TabIndex = 5;
        this._SSPanel1_0.Tag = "";
        // 
        // _SSPanel1_0Label_Text
        // 
        this._SSPanel1_0Label_Text.BackColor = System.Drawing.Color.Silver;
        this._SSPanel1_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._SSPanel1_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._SSPanel1_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._SSPanel1_0Label_Text.Location = new System.Drawing.Point(0, 0);
        this._SSPanel1_0Label_Text.Name = "_SSPanel1_0Label_Text";
        this._SSPanel1_0Label_Text.Size = new System.Drawing.Size(102, 16);
        this._SSPanel1_0Label_Text.TabIndex = 0;
        this._SSPanel1_0Label_Text.Tag = "";
        this._SSPanel1_0Label_Text.Text = "Teclee la Unidad:";
        this._SSPanel1_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _mkbMaskebox_0
        // 
        this._mkbMaskebox_0.Location = new System.Drawing.Point(199, 21);
        this._mkbMaskebox_0.Name = "_mkbMaskebox_0";
        this._mkbMaskebox_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_0.OcxState")));
        this._mkbMaskebox_0.Size = new System.Drawing.Size(120, 21);
        this._mkbMaskebox_0.TabIndex = 0;
        this._mkbMaskebox_0.Tag = "";
        // 
        // _SSPanel1_1
        // 
        this._SSPanel1_1.Controls.Add(this._SSPanel1_1Label_Text);
        this._SSPanel1_1.Location = new System.Drawing.Point(15, 51);
        this._SSPanel1_1.Name = "_SSPanel1_1";
        this._SSPanel1_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_SSPanel1_1.OcxState")));
        this._SSPanel1_1.Size = new System.Drawing.Size(181, 16);
        this._SSPanel1_1.TabIndex = 6;
        this._SSPanel1_1.Tag = "";
        // 
        // _SSPanel1_1Label_Text
        // 
        this._SSPanel1_1Label_Text.BackColor = System.Drawing.Color.Silver;
        this._SSPanel1_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._SSPanel1_1Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._SSPanel1_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._SSPanel1_1Label_Text.Location = new System.Drawing.Point(0, 0);
        this._SSPanel1_1Label_Text.Name = "_SSPanel1_1Label_Text";
        this._SSPanel1_1Label_Text.Size = new System.Drawing.Size(181, 16);
        this._SSPanel1_1Label_Text.TabIndex = 0;
        this._SSPanel1_1Label_Text.Tag = "";
        this._SSPanel1_1Label_Text.Text = "Teclee el Nombre de la Unidad:";
        this._SSPanel1_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _mkbMaskebox_1
        // 
        this._mkbMaskebox_1.Location = new System.Drawing.Point(199, 48);
        this._mkbMaskebox_1.Name = "_mkbMaskebox_1";
        this._mkbMaskebox_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_1.OcxState")));
        this._mkbMaskebox_1.Size = new System.Drawing.Size(210, 21);
        this._mkbMaskebox_1.TabIndex = 1;
        this._mkbMaskebox_1.Tag = "";
        // 
        // CORIRUNI
        // 
        this.AcceptButton = this._CMD_IR_A_0;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.ClientSize = new System.Drawing.Size(424, 259);
        this.Controls.Add(this._CMD_IR_A_1);
        this.Controls.Add(this._SSPanel1_0);
        this.Controls.Add(this.LST_IR_A);
        this.Controls.Add(this.SSPanel3);
        this.Controls.Add(this.SSPanel2);
        this.Controls.Add(this._CMD_IR_A_0);
        this.Controls.Add(this._mkbMaskebox_0);
        this.Controls.Add(this._SSPanel1_1);
        this.Controls.Add(this._mkbMaskebox_1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(310, 269);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORIRUNI";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Ir a....";
        this.Closed += new System.EventHandler(this.CORIRUNI_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.SSPanel3)).EndInit();
        this.SSPanel3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.SSPanel2)).EndInit();
        this.SSPanel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_0)).EndInit();
        this._SSPanel1_0.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_1)).EndInit();
        this._SSPanel1_1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_1)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeSSPanel1()
	{
			this.SSPanel1[0] = _SSPanel1_0;
			this.SSPanel1[1] = _SSPanel1_1;
	}
	void  InitializemkbMaskebox()
	{
			this.mkbMaskebox[0] = _mkbMaskebox_0;
			this.mkbMaskebox[1] = _mkbMaskebox_1;
	}
	void  InitializeCMD_IR_A()
	{
			this.CMD_IR_A[0] = _CMD_IR_A_0;
			this.CMD_IR_A[1] = _CMD_IR_A_1;
	}
#endregion 
}
}