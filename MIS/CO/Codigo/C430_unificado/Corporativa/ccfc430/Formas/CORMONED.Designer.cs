using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;

namespace TCc430
{
	partial class CORMONE
	{
	
#region "Upgrade Support "
		private static CORMONE m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORMONE DefInstance
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
		public CORMONE():base(){
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
		}
	public static CORMONE CreateInstance()
	{
			CORMONE theInstance = new CORMONE();
			theInstance.Form_Load();
			return theInstance;
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
	public  AxMSMask.AxMaskEdBox MaskEdBox5;
	public  AxMSMask.AxMaskEdBox MaskEdBox4;
	public  AxMSMask.AxMaskEdBox MaskEdBox3;
	public  AxMSMask.AxMaskEdBox MaskEdBox2;
	public  System.Windows.Forms.CheckBox Check1;
	public  System.Windows.Forms.TextBox Text1;
	public  System.Windows.Forms.Button Command3;
	public  System.Windows.Forms.Button Command2;
	public  System.Windows.Forms.Button Command1;
	public  System.Windows.Forms.Label Label7;
	public  System.Windows.Forms.Label Label6;
	public  System.Windows.Forms.Label Label5;
	public  System.Windows.Forms.Label Label4;
	public  System.Windows.Forms.Label Label2;
	public  System.Windows.Forms.Label Label1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORMONE));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.MaskEdBox5 = new AxMSMask.AxMaskEdBox();
            this.MaskEdBox4 = new AxMSMask.AxMaskEdBox();
            this.MaskEdBox3 = new AxMSMask.AxMaskEdBox();
            this.MaskEdBox2 = new AxMSMask.AxMaskEdBox();
            this.Check1 = new System.Windows.Forms.CheckBox();
            this.Text1 = new System.Windows.Forms.TextBox();
            this.Command3 = new System.Windows.Forms.Button();
            this.Command2 = new System.Windows.Forms.Button();
            this.Command1 = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.MaskEdBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaskEdBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaskEdBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaskEdBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // MaskEdBox5
            // 
            this.MaskEdBox5.Location = new System.Drawing.Point(176, 148);
            this.MaskEdBox5.Name = "MaskEdBox5";
            this.MaskEdBox5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MaskEdBox5.OcxState")));
            this.MaskEdBox5.Size = new System.Drawing.Size(184, 30);
            this.MaskEdBox5.TabIndex = 14;
            this.MaskEdBox5.Tag = "";
            this.MaskEdBox5.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.MaskEdBox5_KeyPressEvent);
            // 
            // MaskEdBox4
            // 
            this.MaskEdBox4.Location = new System.Drawing.Point(176, 107);
            this.MaskEdBox4.Name = "MaskEdBox4";
            this.MaskEdBox4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MaskEdBox4.OcxState")));
            this.MaskEdBox4.Size = new System.Drawing.Size(184, 31);
            this.MaskEdBox4.TabIndex = 13;
            this.MaskEdBox4.Tag = "";
            this.MaskEdBox4.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.MaskEdBox4_KeyPressEvent);
            // 
            // MaskEdBox3
            // 
            this.MaskEdBox3.Location = new System.Drawing.Point(298, 66);
            this.MaskEdBox3.Name = "MaskEdBox3";
            this.MaskEdBox3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MaskEdBox3.OcxState")));
            this.MaskEdBox3.Size = new System.Drawing.Size(58, 31);
            this.MaskEdBox3.TabIndex = 12;
            this.MaskEdBox3.Tag = "";
            this.MaskEdBox3.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.MaskEdBox3_KeyPressEvent);
            // 
            // MaskEdBox2
            // 
            this.MaskEdBox2.Location = new System.Drawing.Point(134, 66);
            this.MaskEdBox2.Name = "MaskEdBox2";
            this.MaskEdBox2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MaskEdBox2.OcxState")));
            this.MaskEdBox2.Size = new System.Drawing.Size(59, 31);
            this.MaskEdBox2.TabIndex = 11;
            this.MaskEdBox2.Tag = "";
            this.MaskEdBox2.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.MaskEdBox2_KeyPressEvent);
            // 
            // Check1
            // 
            this.Check1.BackColor = System.Drawing.SystemColors.Control;
            this.Check1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Check1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Check1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Check1.Location = new System.Drawing.Point(197, 190);
            this.Check1.Name = "Check1";
            this.Check1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Check1.Size = new System.Drawing.Size(20, 20);
            this.Check1.TabIndex = 5;
            this.Check1.Tag = "";
            this.Check1.Text = "Check1";
            this.Check1.UseVisualStyleBackColor = false;
            // 
            // Text1
            // 
            this.Text1.AcceptsReturn = true;
            this.Text1.BackColor = System.Drawing.SystemColors.Window;
            this.Text1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.Text1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Text1.Location = new System.Drawing.Point(71, 25);
            this.Text1.MaxLength = 0;
            this.Text1.Name = "Text1";
            this.Text1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text1.Size = new System.Drawing.Size(288, 23);
            this.Text1.TabIndex = 3;
            this.Text1.Tag = "";
            // 
            // Command3
            // 
            this.Command3.BackColor = System.Drawing.SystemColors.Control;
            this.Command3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Command3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Command3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Command3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Command3.Location = new System.Drawing.Point(240, 230);
            this.Command3.Name = "Command3";
            this.Command3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Command3.Size = new System.Drawing.Size(97, 41);
            this.Command3.TabIndex = 2;
            this.Command3.Tag = "";
            this.Command3.Text = "Salir";
            this.Command3.UseVisualStyleBackColor = false;
            this.Command3.Click += new System.EventHandler(this.Command3_Click);
            // 
            // Command2
            // 
            this.Command2.BackColor = System.Drawing.SystemColors.Control;
            this.Command2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Command2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Command2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Command2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Command2.Location = new System.Drawing.Point(134, 230);
            this.Command2.Name = "Command2";
            this.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Command2.Size = new System.Drawing.Size(88, 41);
            this.Command2.TabIndex = 1;
            this.Command2.Tag = "";
            this.Command2.Text = "Actualiza";
            this.Command2.UseVisualStyleBackColor = false;
            this.Command2.Click += new System.EventHandler(this.Command2_Click);
            // 
            // Command1
            // 
            this.Command1.BackColor = System.Drawing.SystemColors.Control;
            this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Command1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Command1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Command1.Location = new System.Drawing.Point(29, 230);
            this.Command1.Name = "Command1";
            this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Command1.Size = new System.Drawing.Size(87, 41);
            this.Command1.TabIndex = 0;
            this.Command1.Tag = "";
            this.Command1.Text = "Consulta";
            this.Command1.UseVisualStyleBackColor = false;
            this.Command1.Click += new System.EventHandler(this.Command1_Click);
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.BackColor = System.Drawing.SystemColors.Control;
            this.Label7.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label7.Location = new System.Drawing.Point(28, 148);
            this.Label7.Name = "Label7";
            this.Label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label7.Size = new System.Drawing.Size(144, 17);
            this.Label7.TabIndex = 10;
            this.Label7.Tag = "";
            this.Label7.Text = "Tasa cambio maxima:";
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.BackColor = System.Drawing.SystemColors.Control;
            this.Label6.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label6.Location = new System.Drawing.Point(28, 107);
            this.Label6.Name = "Label6";
            this.Label6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label6.Size = new System.Drawing.Size(141, 17);
            this.Label6.TabIndex = 9;
            this.Label6.Tag = "";
            this.Label6.Text = "Tasa cambio minima:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.BackColor = System.Drawing.SystemColors.Control;
            this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label5.Location = new System.Drawing.Point(198, 66);
            this.Label5.Name = "Label5";
            this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label5.Size = new System.Drawing.Size(104, 17);
            this.Label5.TabIndex = 8;
            this.Label5.Tag = "";
            this.Label5.Text = "Moneda Num3:";
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.BackColor = System.Drawing.SystemColors.Control;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label4.Location = new System.Drawing.Point(28, 66);
            this.Label4.Name = "Label4";
            this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label4.Size = new System.Drawing.Size(99, 17);
            this.Label4.TabIndex = 7;
            this.Label4.Tag = "";
            this.Label4.Text = "Moneda Alfa3:";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(28, 191);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(177, 17);
            this.Label2.TabIndex = 6;
            this.Label2.Tag = "";
            this.Label2.Text = "Considerar tipo de cambio:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(28, 25);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(39, 17);
            this.Label1.TabIndex = 4;
            this.Label1.Tag = "";
            this.Label1.Text = "Pais:";
            // 
            // CORMONE
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 16);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(330, 242);
            this.Controls.Add(this.MaskEdBox5);
            this.Controls.Add(this.MaskEdBox4);
            this.Controls.Add(this.MaskEdBox3);
            this.Controls.Add(this.MaskEdBox2);
            this.Controls.Add(this.Check1);
            this.Controls.Add(this.Text1);
            this.Controls.Add(this.Command3);
            this.Controls.Add(this.Command2);
            this.Controls.Add(this.Command1);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(4, 183);
            this.Name = "CORMONE";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Form1";
            this.Closed += new System.EventHandler(this.CORMONE_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.MaskEdBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaskEdBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaskEdBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaskEdBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
#endregion 
}
}