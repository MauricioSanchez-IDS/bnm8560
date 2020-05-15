using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmAccesoBancanet
	{
	
#region "Upgrade Support "
		private static frmAccesoBancanet m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmAccesoBancanet DefInstance
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
		public frmAccesoBancanet():base(){
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
	public static frmAccesoBancanet CreateInstance()
	{
			frmAccesoBancanet theInstance = new frmAccesoBancanet();
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
	public  System.Windows.Forms.Button cmdmSalir;
	public  System.Windows.Forms.Button cmdmAceptar;
	public  System.Windows.Forms.TextBox txtmUsuario;
	public  System.Windows.Forms.TextBox txtmPassword;
	public  System.Windows.Forms.Label pnlUsuarioLabel_Text;
	public  AxThreed.AxSSPanel pnlUsuario;
	public  System.Windows.Forms.Label pnlPasswordLabel_Text;
	public  AxThreed.AxSSPanel pnlPassword;
	public  System.Windows.Forms.Label Line1;
	public  AxThreed.AxSSPanel ID_CEM_PPL_PNL;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAccesoBancanet));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_CEM_PPL_PNL = new AxThreed.AxSSPanel();
        this.txtmUsuario = new System.Windows.Forms.TextBox();
        this.txtmPassword = new System.Windows.Forms.TextBox();
        this.cmdmAceptar = new System.Windows.Forms.Button();
        this.cmdmSalir = new System.Windows.Forms.Button();
        this.pnlPassword = new AxThreed.AxSSPanel();
        this.pnlPasswordLabel_Text = new System.Windows.Forms.Label();
        this.Line1 = new System.Windows.Forms.Label();
        this.pnlUsuario = new AxThreed.AxSSPanel();
        this.pnlUsuarioLabel_Text = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CEM_PPL_PNL)).BeginInit();
        this.ID_CEM_PPL_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pnlPassword)).BeginInit();
        this.pnlPassword.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.pnlUsuario)).BeginInit();
        this.pnlUsuario.SuspendLayout();
        this.SuspendLayout();
        // 
        // ID_CEM_PPL_PNL
        // 
        this.ID_CEM_PPL_PNL.Controls.Add(this.txtmUsuario);
        this.ID_CEM_PPL_PNL.Controls.Add(this.txtmPassword);
        this.ID_CEM_PPL_PNL.Controls.Add(this.cmdmAceptar);
        this.ID_CEM_PPL_PNL.Controls.Add(this.cmdmSalir);
        this.ID_CEM_PPL_PNL.Controls.Add(this.pnlPassword);
        this.ID_CEM_PPL_PNL.Controls.Add(this.Line1);
        this.ID_CEM_PPL_PNL.Controls.Add(this.pnlUsuario);
        this.ID_CEM_PPL_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_CEM_PPL_PNL.Name = "ID_CEM_PPL_PNL";
        this.ID_CEM_PPL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CEM_PPL_PNL.OcxState")));
        this.ID_CEM_PPL_PNL.Size = new System.Drawing.Size(388, 129);
        this.ID_CEM_PPL_PNL.TabIndex = 0;
        this.ID_CEM_PPL_PNL.Tag = "";
        // 
        // txtmUsuario
        // 
        this.txtmUsuario.AcceptsReturn = true;
        this.txtmUsuario.BackColor = System.Drawing.SystemColors.Window;
        this.txtmUsuario.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtmUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtmUsuario.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtmUsuario.Location = new System.Drawing.Point(136, 16);
        this.txtmUsuario.MaxLength = 0;
        this.txtmUsuario.Name = "txtmUsuario";
        this.txtmUsuario.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtmUsuario.Size = new System.Drawing.Size(233, 19);
        this.txtmUsuario.TabIndex = 1;
        this.txtmUsuario.Tag = "";
        this.txtmUsuario.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmUsuario_KeyPress);
        // 
        // txtmPassword
        // 
        this.txtmPassword.AcceptsReturn = true;
        this.txtmPassword.BackColor = System.Drawing.SystemColors.Window;
        this.txtmPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtmPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtmPassword.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtmPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
        this.txtmPassword.Location = new System.Drawing.Point(136, 48);
        this.txtmPassword.MaxLength = 0;
        this.txtmPassword.Name = "txtmPassword";
        this.txtmPassword.PasswordChar = '*';
        this.txtmPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtmPassword.Size = new System.Drawing.Size(233, 21);
        this.txtmPassword.TabIndex = 2;
        this.txtmPassword.Tag = "";
        this.txtmPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmPassword_KeyPress);
        // 
        // cmdmAceptar
        // 
        this.cmdmAceptar.BackColor = System.Drawing.SystemColors.Control;
        this.cmdmAceptar.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdmAceptar.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdmAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdmAceptar.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdmAceptar.Location = new System.Drawing.Point(216, 88);
        this.cmdmAceptar.Name = "cmdmAceptar";
        this.cmdmAceptar.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdmAceptar.Size = new System.Drawing.Size(68, 22);
        this.cmdmAceptar.TabIndex = 3;
        this.cmdmAceptar.Tag = "A";
        this.cmdmAceptar.Text = "Aceptar";
        this.cmdmAceptar.UseVisualStyleBackColor = false;
        this.cmdmAceptar.Click += new System.EventHandler(this.cmdmAceptar_Click);
        // 
        // cmdmSalir
        // 
        this.cmdmSalir.BackColor = System.Drawing.SystemColors.Control;
        this.cmdmSalir.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdmSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cmdmSalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdmSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdmSalir.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdmSalir.Location = new System.Drawing.Point(296, 88);
        this.cmdmSalir.Name = "cmdmSalir";
        this.cmdmSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdmSalir.Size = new System.Drawing.Size(71, 22);
        this.cmdmSalir.TabIndex = 4;
        this.cmdmSalir.Tag = "";
        this.cmdmSalir.Text = "Cancelar";
        this.cmdmSalir.UseVisualStyleBackColor = false;
        this.cmdmSalir.Click += new System.EventHandler(this.cmdmSalir_Click);
        // 
        // pnlPassword
        // 
        this.pnlPassword.Controls.Add(this.pnlPasswordLabel_Text);
        this.pnlPassword.Location = new System.Drawing.Point(16, 48);
        this.pnlPassword.Name = "pnlPassword";
        this.pnlPassword.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlPassword.OcxState")));
        this.pnlPassword.Size = new System.Drawing.Size(107, 23);
        this.pnlPassword.TabIndex = 6;
        this.pnlPassword.Tag = "";
        // 
        // pnlPasswordLabel_Text
        // 
        this.pnlPasswordLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.pnlPasswordLabel_Text.ForeColor = System.Drawing.SystemColors.WindowText;
        this.pnlPasswordLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.pnlPasswordLabel_Text.Name = "pnlPasswordLabel_Text";
        this.pnlPasswordLabel_Text.Size = new System.Drawing.Size(105, 21);
        this.pnlPasswordLabel_Text.TabIndex = 0;
        this.pnlPasswordLabel_Text.Tag = "";
        this.pnlPasswordLabel_Text.Text = "&Clave Personal";
        this.pnlPasswordLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Line1
        // 
        this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
        this.Line1.Location = new System.Drawing.Point(16, 80);
        this.Line1.Name = "Line1";
        this.Line1.Size = new System.Drawing.Size(352, 1);
        this.Line1.TabIndex = 7;
        this.Line1.Tag = "";
        // 
        // pnlUsuario
        // 
        this.pnlUsuario.Controls.Add(this.pnlUsuarioLabel_Text);
        this.pnlUsuario.Location = new System.Drawing.Point(16, 16);
        this.pnlUsuario.Name = "pnlUsuario";
        this.pnlUsuario.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlUsuario.OcxState")));
        this.pnlUsuario.Size = new System.Drawing.Size(105, 21);
        this.pnlUsuario.TabIndex = 5;
        this.pnlUsuario.Tag = "";
        // 
        // pnlUsuarioLabel_Text
        // 
        this.pnlUsuarioLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.pnlUsuarioLabel_Text.ForeColor = System.Drawing.SystemColors.WindowText;
        this.pnlUsuarioLabel_Text.Location = new System.Drawing.Point(0, 0);
        this.pnlUsuarioLabel_Text.Name = "pnlUsuarioLabel_Text";
        this.pnlUsuarioLabel_Text.Size = new System.Drawing.Size(105, 21);
        this.pnlUsuarioLabel_Text.TabIndex = 0;
        this.pnlUsuarioLabel_Text.Tag = "";
        this.pnlUsuarioLabel_Text.Text = "&Nomina";
        this.pnlUsuarioLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // frmAccesoBancanet
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.CancelButton = this.cmdmSalir;
        this.ClientSize = new System.Drawing.Size(384, 127);
        this.Controls.Add(this.ID_CEM_PPL_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Location = new System.Drawing.Point(4, 23);
        this.Name = "frmAccesoBancanet";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Tag = "";
        this.Text = "Acceso Bancanet";
        this.Closed += new System.EventHandler(this.frmAccesoBancanet_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.ID_CEM_PPL_PNL)).EndInit();
        this.ID_CEM_PPL_PNL.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pnlPassword)).EndInit();
        this.pnlPassword.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.pnlUsuario)).EndInit();
        this.pnlUsuario.ResumeLayout(false);
        this.ResumeLayout(false);

	}
#endregion 
}
}