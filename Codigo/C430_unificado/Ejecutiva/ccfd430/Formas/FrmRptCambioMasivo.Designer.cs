using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class FrmRptCambioMasivo
	{
	
#region "Upgrade Support "
		private static FrmRptCambioMasivo m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static FrmRptCambioMasivo DefInstance
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
		public FrmRptCambioMasivo():base(){
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			InitializeHelp();
		}
	public static FrmRptCambioMasivo CreateInstance()
	{
			FrmRptCambioMasivo theInstance = new FrmRptCambioMasivo();
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
	public  System.Windows.Forms.ListBox LstReporte;
	public  System.Windows.Forms.Button BtnSalir;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.LstReporte = new System.Windows.Forms.ListBox();
        this.BtnSalir = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // LstReporte
        // 
        this.LstReporte.BackColor = System.Drawing.SystemColors.Window;
        this.LstReporte.Cursor = System.Windows.Forms.Cursors.Default;
        this.LstReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.LstReporte.ForeColor = System.Drawing.SystemColors.WindowText;
        this.LstReporte.Location = new System.Drawing.Point(16, 64);
        this.LstReporte.Name = "LstReporte";
        this.LstReporte.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.LstReporte.Size = new System.Drawing.Size(577, 407);
        this.LstReporte.TabIndex = 1;
        this.LstReporte.Tag = "";
        // 
        // BtnSalir
        // 
        this.BtnSalir.BackColor = System.Drawing.SystemColors.Control;
        this.BtnSalir.Cursor = System.Windows.Forms.Cursors.Default;
        this.BtnSalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.BtnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.BtnSalir.ForeColor = System.Drawing.SystemColors.ControlText;
        this.BtnSalir.Location = new System.Drawing.Point(0, 0);
        this.BtnSalir.Name = "BtnSalir";
        this.BtnSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.BtnSalir.Size = new System.Drawing.Size(65, 33);
        this.BtnSalir.TabIndex = 0;
        this.BtnSalir.Tag = "";
        this.BtnSalir.Text = "&Salir";
        this.BtnSalir.UseVisualStyleBackColor = false;
        this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
        // 
        // FrmRptCambioMasivo
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(609, 479);
        this.Controls.Add(this.BtnSalir);
        this.Controls.Add(this.LstReporte);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Location = new System.Drawing.Point(4, 23);
        this.MinimizeBox = false;
        this.Name = "FrmRptCambioMasivo";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Tag = "";
        this.Text = "Form2";
        this.Resize += new System.EventHandler(this.FrmRptCambioMasivo_Resize);
        this.ResumeLayout(false);

	}
#endregion 
}
}