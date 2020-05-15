using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class frmEmpNvas
	{
	
#region "Upgrade Support "
		private static frmEmpNvas m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmEmpNvas DefInstance
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
		public frmEmpNvas():base(){
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
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static frmEmpNvas CreateInstance()
	{
			frmEmpNvas theInstance = new frmEmpNvas();
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
	public  System.Windows.Forms.Button cmdReporte;
	public  AxMSComCtl2.AxDTPicker DTPicFinal;
	public  AxMSComCtl2.AxDTPicker DTPicInicial;
	public  System.Windows.Forms.Label Label1;
	public  System.Windows.Forms.Label lblInicial;
	public  System.Windows.Forms.Label lblRango;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEmpNvas));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.cmdReporte = new System.Windows.Forms.Button();
			this.DTPicFinal = new AxMSComCtl2.AxDTPicker();
			this.DTPicInicial = new AxMSComCtl2.AxDTPicker();
			this.Label1 = new System.Windows.Forms.Label();
			this.lblInicial = new System.Windows.Forms.Label();
			this.lblRango = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) this.DTPicFinal).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.DTPicInicial).BeginInit();
			this.SuspendLayout();
			// 
			// cmdReporte
			// 
			this.cmdReporte.BackColor = System.Drawing.SystemColors.Control;
			this.cmdReporte.CausesValidation = true;
			this.cmdReporte.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdReporte.Enabled = true;
			this.cmdReporte.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmdReporte.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdReporte.Location = new System.Drawing.Point(140, 44);
			this.cmdReporte.Name = "cmdReporte";
			this.cmdReporte.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdReporte.Size = new System.Drawing.Size(81, 29);
			this.cmdReporte.TabIndex = 5;
			this.cmdReporte.TabStop = true;
			this.cmdReporte.Tag = "";
			this.cmdReporte.Text = "Reporte";
			this.cmdReporte.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdReporte.Click += new System.EventHandler(this.cmdReporte_Click);
			// 
			// DTPicFinal
			// 
			this.DTPicFinal.Location = new System.Drawing.Point(254, 52);
			this.DTPicFinal.Name = "DTPicFinal";
			this.DTPicFinal.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("DTPicFinal.OcxState");
			this.DTPicFinal.Size = new System.Drawing.Size(75, 21);
			this.DTPicFinal.TabIndex = 1;
			this.DTPicFinal.Tag = "";
			// 
			// DTPicInicial
			// 
			this.DTPicInicial.Location = new System.Drawing.Point(36, 52);
			this.DTPicInicial.Name = "DTPicInicial";
			this.DTPicInicial.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("DTPicInicial.OcxState");
			this.DTPicInicial.Size = new System.Drawing.Size(75, 21);
			this.DTPicInicial.TabIndex = 0;
			this.DTPicInicial.Tag = "";
			// 
			// Label1
			// 
			this.Label1.AutoSize = false;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.Enabled = true;
			this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(271, 32);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(41, 13);
			this.Label1.TabIndex = 4;
			this.Label1.Tag = "";
			this.Label1.Text = "Final.";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			// 
			// lblInicial
			// 
			this.lblInicial.AutoSize = false;
			this.lblInicial.BackColor = System.Drawing.SystemColors.Control;
			this.lblInicial.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblInicial.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblInicial.Enabled = true;
			this.lblInicial.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblInicial.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblInicial.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblInicial.Location = new System.Drawing.Point(52, 32);
			this.lblInicial.Name = "lblInicial";
			this.lblInicial.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblInicial.Size = new System.Drawing.Size(41, 13);
			this.lblInicial.TabIndex = 3;
			this.lblInicial.Tag = "";
			this.lblInicial.Text = "Inicial.";
			this.lblInicial.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblInicial.UseMnemonic = true;
			this.lblInicial.Visible = true;
			// 
			// lblRango
			// 
			this.lblRango.AutoSize = true;
			this.lblRango.BackColor = System.Drawing.SystemColors.Control;
			this.lblRango.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.lblRango.Cursor = System.Windows.Forms.Cursors.Default;
			this.lblRango.Enabled = true;
			this.lblRango.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblRango.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lblRango.ForeColor = System.Drawing.SystemColors.ControlText;
			this.lblRango.Location = new System.Drawing.Point(14, 8);
			this.lblRango.Name = "lblRango";
			this.lblRango.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lblRango.Size = new System.Drawing.Size(340, 16);
			this.lblRango.TabIndex = 2;
			this.lblRango.Tag = "";
			this.lblRango.Text = "Seleccione el Rango de Fechas para el Reporte:";
			this.lblRango.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.lblRango.UseMnemonic = true;
			this.lblRango.Visible = true;
			// 
			// frmEmpNvas
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(359, 86);
			this.ControlBox = true;
			this.Controls.Add(this.cmdReporte);
			this.Controls.Add(this.DTPicFinal);
			this.Controls.Add(this.Label1);
			this.Controls.Add(this.lblRango);
			this.Controls.Add(this.lblInicial);
			this.Controls.Add(this.DTPicInicial);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Enabled = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.HelpButton = false;
			this.KeyPreview = false;
			this.Location = new System.Drawing.Point(4, 23);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmEmpNvas";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "";
			this.Text = "Reporte de Empresas Nuevas";
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			base.Closed += new System.EventHandler(this.frmEmpNvas_Closed);
			((System.ComponentModel.ISupportInitialize) this.DTPicFinal).EndInit();
			((System.ComponentModel.ISupportInitialize) this.DTPicInicial).EndInit();
			this.ResumeLayout(false);
	}
#endregion 
}
}