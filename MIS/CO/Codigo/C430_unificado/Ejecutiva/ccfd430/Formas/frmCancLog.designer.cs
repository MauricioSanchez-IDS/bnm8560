using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class frmCancLog
	{
	
#region "Upgrade Support "
		private static frmCancLog m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmCancLog DefInstance
		{
			get
			{
				if (m_vb6FormDefInstance == null || m_vb6FormDefInstance.IsDisposed)
				{
					m_InitializingDefInstance = true;
					m_vb6FormDefInstance = new frmCancLog();
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
		public frmCancLog():base(){
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
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
			//The MDI form in the VB6 project had its
			//AutoShowChildren property set to True
			//To simulate the VB6 behavior, we need to
			//automatically Show the form whenever it
			//is loaded.  If you do not want this behavior
			//then delete the following line of code
			//UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing.
			this.Show();
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
	public  System.Windows.Forms.Button cmdCerrar;
	public  System.Windows.Forms.TextBox txtLog;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.cmdCerrar = new System.Windows.Forms.Button();
        this.txtLog = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // cmdCerrar
        // 
        this.cmdCerrar.BackColor = System.Drawing.SystemColors.Control;
        this.cmdCerrar.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdCerrar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cmdCerrar.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdCerrar.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdCerrar.Location = new System.Drawing.Point(132, 220);
        this.cmdCerrar.Name = "cmdCerrar";
        this.cmdCerrar.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdCerrar.Size = new System.Drawing.Size(117, 21);
        this.cmdCerrar.TabIndex = 1;
        this.cmdCerrar.Text = "&Cerrar";
        this.cmdCerrar.UseVisualStyleBackColor = false;
        this.cmdCerrar.Click += new System.EventHandler(this.cmdCerrar_Click);
        // 
        // txtLog
        // 
        this.txtLog.AcceptsReturn = true;
        this.txtLog.BackColor = System.Drawing.SystemColors.Window;
        this.txtLog.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtLog.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtLog.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtLog.Location = new System.Drawing.Point(8, 8);
        this.txtLog.MaxLength = 0;
        this.txtLog.Multiline = true;
        this.txtLog.Name = "txtLog";
        this.txtLog.ReadOnly = true;
        this.txtLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtLog.Size = new System.Drawing.Size(365, 205);
        this.txtLog.TabIndex = 0;
        // 
        // frmCancLog
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(386, 249);
        this.Controls.Add(this.cmdCerrar);
        this.Controls.Add(this.txtLog);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(3, 22);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmCancLog";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Visor de Salida de Cancelaciones";
        this.ResumeLayout(false);

	}
#endregion 
}
}