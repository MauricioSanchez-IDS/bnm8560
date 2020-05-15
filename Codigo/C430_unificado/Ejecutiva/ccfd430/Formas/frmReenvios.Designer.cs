using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class frmReenvios
	{
	
#region "Upgrade Support "
		private static frmReenvios m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmReenvios DefInstance
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
		public frmReenvios():base(){
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
	public static frmReenvios CreateInstance()
	{
			frmReenvios theInstance = new frmReenvios();
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
	public  System.Windows.Forms.ListBox lstReenvios;
	public  AxThreed.AxSSFrame framReenvio;
	private Artinsoft.VB6.Gui.ListBoxHelper listBoxHelper;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReenvios));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.framReenvio = new AxThreed.AxSSFrame();
			this.lstReenvios = new System.Windows.Forms.ListBox();
			this.listBoxHelper = new Artinsoft.VB6.Gui.ListBoxHelper(this.components);
			((System.ComponentModel.ISupportInitialize) this.framReenvio).BeginInit();
			this.framReenvio.SuspendLayout();
			this.SuspendLayout();
			// 
			// framReenvio
			// 
			this.framReenvio.Controls.Add(this.lstReenvios);
			this.framReenvio.Location = new System.Drawing.Point(0, 0);
			this.framReenvio.Name = "framReenvio";
			this.framReenvio.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("framReenvio.OcxState");
			this.framReenvio.Size = new System.Drawing.Size(777, 369);
			this.framReenvio.TabIndex = 0;
			this.framReenvio.Tag = "";
			// 
			// lstReenvios
			// 
			this.lstReenvios.BackColor = System.Drawing.SystemColors.Window;
			this.lstReenvios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstReenvios.CausesValidation = true;
			this.lstReenvios.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstReenvios.Enabled = true;
			this.lstReenvios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lstReenvios.ForeColor = System.Drawing.SystemColors.WindowText;
			this.lstReenvios.IntegralHeight = true;
			this.lstReenvios.Location = new System.Drawing.Point(8, 64);
			this.lstReenvios.MultiColumn = false;
			this.lstReenvios.Name = "lstReenvios";
			this.lstReenvios.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstReenvios.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
			this.lstReenvios.Size = new System.Drawing.Size(761, 293);
			this.lstReenvios.Sorted = false;
			this.lstReenvios.TabIndex = 1;
			this.lstReenvios.TabStop = true;
			this.lstReenvios.Tag = "";
			this.lstReenvios.Visible = true;
			// 
			// listBoxHelper
			// 
			this.listBoxHelper.SetSelectionMode(this.lstReenvios, System.Windows.Forms.SelectionMode.MultiSimple);
			// 
			// frmReenvios
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(778, 431);
			this.ControlBox = true;
			this.Controls.Add(this.framReenvio);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Enabled = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.HelpButton = false;
			this.KeyPreview = false;
			this.Location = new System.Drawing.Point(129, 176);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmReenvios";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "";
			this.Text = "Reenvio Ejecutivos";
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			base.Closed += new System.EventHandler(this.frmReenvios_Closed);
			((System.ComponentModel.ISupportInitialize) this.framReenvio).EndInit();
			this.framReenvio.ResumeLayout(false);
			this.ResumeLayout(false);
	}
#endregion 
}
}