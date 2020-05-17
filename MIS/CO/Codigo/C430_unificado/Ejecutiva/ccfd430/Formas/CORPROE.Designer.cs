using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORPROE
	{
	
#region "Upgrade Support "
		private static CORPROE m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORPROE DefInstance
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
		public CORPROE():base(){
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
		}
	public static CORPROE CreateInstance()
	{
			CORPROE theInstance = new CORPROE();
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
	public  System.Windows.Forms.Button Command3;
	public  System.Windows.Forms.CheckBox Check1;
        public System.Windows.Forms.TextBox Text2;
	public  System.Windows.Forms.Button Command1;
	public  System.Windows.Forms.TextBox Text1;
	public  System.Windows.Forms.Label Label2;
	public  System.Windows.Forms.Label Label1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.Command3 = new System.Windows.Forms.Button();
        this.Check1 = new System.Windows.Forms.CheckBox();
        this.Text2 = new System.Windows.Forms.TextBox();
        this.Command1 = new System.Windows.Forms.Button();
        this.Text1 = new System.Windows.Forms.TextBox();
        this.Label2 = new System.Windows.Forms.Label();
        this.Label1 = new System.Windows.Forms.Label();
        this.Command2 = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // Command3
        // 
        this.Command3.BackColor = System.Drawing.SystemColors.Control;
        this.Command3.Cursor = System.Windows.Forms.Cursors.Default;
        this.Command3.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.Command3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Command3.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Command3.Location = new System.Drawing.Point(120, 176);
        this.Command3.Name = "Command3";
        this.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Command3.Size = new System.Drawing.Size(81, 33);
        this.Command3.TabIndex = 5;
        this.Command3.Tag = "";
        this.Command3.Text = "Actualiza";
        this.Command3.UseVisualStyleBackColor = false;
        this.Command3.Click += new System.EventHandler(this.Command3_Click);
        // 
        // Check1
        // 
        this.Check1.BackColor = System.Drawing.SystemColors.Control;
        this.Check1.Cursor = System.Windows.Forms.Cursors.Default;
        this.Check1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Check1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Check1.Location = new System.Drawing.Point(120, 104);
        this.Check1.Name = "Check1";
        this.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Check1.Size = new System.Drawing.Size(161, 33);
        this.Check1.TabIndex = 4;
        this.Check1.Tag = "";
        this.Check1.Text = "Marca Cuenta Espejo";
        this.Check1.UseVisualStyleBackColor = false;
        // 
        // Text2
        // 
        this.Text2.AcceptsReturn = true;
        this.Text2.BackColor = System.Drawing.SystemColors.Window;
        this.Text2.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Text2.Enabled = false;
        this.Text2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Text2.ForeColor = System.Drawing.SystemColors.WindowText;
        this.Text2.Location = new System.Drawing.Point(112, 64);
        this.Text2.MaxLength = 0;
        this.Text2.Name = "Text2";
        this.Text2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Text2.Size = new System.Drawing.Size(169, 20);
        this.Text2.TabIndex = 4;
        this.Text2.Tag = "";
        // 
        // Command1
        // 
        this.Command1.BackColor = System.Drawing.SystemColors.Control;
        this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
        this.Command1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.Command1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Command1.Location = new System.Drawing.Point(32, 176);
        this.Command1.Name = "Command1";
        this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Command1.Size = new System.Drawing.Size(73, 33);
        this.Command1.TabIndex = 2;
        this.Command1.Tag = "";
        this.Command1.Text = "Consulta";
        this.Command1.UseVisualStyleBackColor = false;
        this.Command1.Click += new System.EventHandler(this.Command1_Click);
        // 
        // Text1
        // 
        this.Text1.AcceptsReturn = true;
        this.Text1.BackColor = System.Drawing.SystemColors.Window;
        this.Text1.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.Text1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Text1.ForeColor = System.Drawing.SystemColors.WindowText;
        this.Text1.Location = new System.Drawing.Point(112, 24);
        this.Text1.MaxLength = 0;
        this.Text1.Name = "Text1";
        this.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Text1.Size = new System.Drawing.Size(169, 20);
        this.Text1.TabIndex = 1;
        this.Text1.Tag = "";
        // 
        // Label2
        // 
        this.Label2.BackColor = System.Drawing.SystemColors.Control;
        this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
        this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Label2.Location = new System.Drawing.Point(40, 64);
        this.Label2.Name = "Label2";
        this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Label2.Size = new System.Drawing.Size(89, 25);
        this.Label2.TabIndex = 5;
        this.Label2.Tag = "id";
        this.Label2.Text = "Cuenta Citi:";
        // 
        // Label1
        // 
        this.Label1.BackColor = System.Drawing.SystemColors.Control;
        this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
        this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Label1.Location = new System.Drawing.Point(8, 24);
        this.Label1.Name = "Label1";
        this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Label1.Size = new System.Drawing.Size(104, 25);
        this.Label1.TabIndex = 0;
        this.Label1.Tag = "id";
        this.Label1.Text = "Cuenta Banamex:";
        // 
        // Command2
        // 
        this.Command2.BackColor = System.Drawing.SystemColors.Control;
        this.Command2.Cursor = System.Windows.Forms.Cursors.Default;
        this.Command2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.Command2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Command2.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Command2.Location = new System.Drawing.Point(215, 176);
        this.Command2.Name = "Command2";
        this.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Command2.Size = new System.Drawing.Size(73, 33);
        this.Command2.TabIndex = 3;
        this.Command2.Tag = "";
        this.Command2.Text = "Salir";
        this.Command2.UseVisualStyleBackColor = false;
        this.Command2.Click += new System.EventHandler(this.Command2_Click);
        // 
        // CORPROE
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(346, 242);
        this.Controls.Add(this.Command2);
        this.Controls.Add(this.Command3);
        this.Controls.Add(this.Check1);
        this.Controls.Add(this.Text2);
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.Command1);
        this.Controls.Add(this.Text1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Location = new System.Drawing.Point(4, 23);
        this.Name = "CORPROE";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Tag = "";
        this.Text = "Proceso Especial";
        this.ResumeLayout(false);
        this.PerformLayout();

	}
#endregion 

        public System.Windows.Forms.Button Command2;
}
}