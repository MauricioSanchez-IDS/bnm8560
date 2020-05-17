using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class frmEnvioLimCred
	{
	
#region "Upgrade Support "
		private static frmEnvioLimCred m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmEnvioLimCred DefInstance
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
		public frmEnvioLimCred():base(){
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
	public static frmEnvioLimCred CreateInstance()
	{
			frmEnvioLimCred theInstance = new frmEnvioLimCred();
			theInstance.Form_Load();
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
	public  System.Windows.Forms.Button cmdEliminar;
	public  AxMSComctlLib.AxListView LstvLimiteCredito;
	public  System.Windows.Forms.Button cmdImprCred;
	public  System.Windows.Forms.Button cmdSalirCred;
	public  System.Windows.Forms.Button cmdEnviaCred;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEnvioLimCred));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdEliminar = new System.Windows.Forms.Button();
            this.LstvLimiteCredito = new AxMSComctlLib.AxListView();
            this.cmdImprCred = new System.Windows.Forms.Button();
            this.cmdSalirCred = new System.Windows.Forms.Button();
            this.cmdEnviaCred = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.LstvLimiteCredito)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdEliminar
            // 
            this.cmdEliminar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEliminar.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdEliminar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEliminar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdEliminar.Location = new System.Drawing.Point(102, 232);
            this.cmdEliminar.Name = "cmdEliminar";
            this.cmdEliminar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdEliminar.Size = new System.Drawing.Size(105, 33);
            this.cmdEliminar.TabIndex = 4;
            this.cmdEliminar.Tag = "";
            this.cmdEliminar.Text = "Eliminar";
            this.cmdEliminar.UseVisualStyleBackColor = false;
            this.cmdEliminar.Click += new System.EventHandler(this.cmdEliminar_Click);
            // 
            // LstvLimiteCredito
            // 
            this.LstvLimiteCredito.Location = new System.Drawing.Point(8, 8);
            this.LstvLimiteCredito.Name = "LstvLimiteCredito";
            this.LstvLimiteCredito.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("LstvLimiteCredito.OcxState")));
            this.LstvLimiteCredito.Size = new System.Drawing.Size(745, 217);
            this.LstvLimiteCredito.TabIndex = 3;
            this.LstvLimiteCredito.Tag = "";
            this.LstvLimiteCredito.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.LstvLimiteCredito_KeyPress);
            // 
            // cmdImprCred
            // 
            this.cmdImprCred.BackColor = System.Drawing.SystemColors.Control;
            this.cmdImprCred.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdImprCred.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdImprCred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImprCred.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdImprCred.Location = new System.Drawing.Point(564, 232);
            this.cmdImprCred.Name = "cmdImprCred";
            this.cmdImprCred.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdImprCred.Size = new System.Drawing.Size(105, 33);
            this.cmdImprCred.TabIndex = 2;
            this.cmdImprCred.Tag = "";
            this.cmdImprCred.Text = "Imprimir";
            this.cmdImprCred.UseVisualStyleBackColor = false;
            this.cmdImprCred.Click += new System.EventHandler(this.cmdImprCred_Click);
            // 
            // cmdSalirCred
            // 
            this.cmdSalirCred.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSalirCred.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSalirCred.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSalirCred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalirCred.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSalirCred.Location = new System.Drawing.Point(410, 232);
            this.cmdSalirCred.Name = "cmdSalirCred";
            this.cmdSalirCred.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSalirCred.Size = new System.Drawing.Size(105, 33);
            this.cmdSalirCred.TabIndex = 1;
            this.cmdSalirCred.Tag = "";
            this.cmdSalirCred.Text = "Cancelar";
            this.cmdSalirCred.UseVisualStyleBackColor = false;
            this.cmdSalirCred.Click += new System.EventHandler(this.cmdSalirCred_Click);
            // 
            // cmdEnviaCred
            // 
            this.cmdEnviaCred.BackColor = System.Drawing.SystemColors.Control;
            this.cmdEnviaCred.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdEnviaCred.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdEnviaCred.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdEnviaCred.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdEnviaCred.Location = new System.Drawing.Point(256, 232);
            this.cmdEnviaCred.Name = "cmdEnviaCred";
            this.cmdEnviaCred.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdEnviaCred.Size = new System.Drawing.Size(105, 33);
            this.cmdEnviaCred.TabIndex = 0;
            this.cmdEnviaCred.Tag = "";
            this.cmdEnviaCred.Text = "Enviar";
            this.cmdEnviaCred.UseVisualStyleBackColor = false;
            this.cmdEnviaCred.Click += new System.EventHandler(this.cmdEnviaCred_Click);
            // 
            // frmEnvioLimCred
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(762, 283);
            this.Controls.Add(this.cmdEliminar);
            this.Controls.Add(this.LstvLimiteCredito);
            this.Controls.Add(this.cmdImprCred);
            this.Controls.Add(this.cmdSalirCred);
            this.Controls.Add(this.cmdEnviaCred);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(194, 296);
            this.Name = "frmEnvioLimCred";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Autorización en cambio de límite de crédito";
            this.Closed += new System.EventHandler(this.frmEnvioLimCred_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.LstvLimiteCredito)).EndInit();
            this.ResumeLayout(false);

	}
#endregion 
}
}