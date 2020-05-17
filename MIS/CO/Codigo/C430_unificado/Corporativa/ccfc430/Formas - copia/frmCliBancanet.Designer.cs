using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmCliBancanet
	{
	
#region "Upgrade Support "
		private static frmCliBancanet m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmCliBancanet DefInstance
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
		public frmCliBancanet():base(){
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
			InitializeID_CEM_ETI_PNL();
		}
	public static frmCliBancanet CreateInstance()
	{
			frmCliBancanet theInstance = new frmCliBancanet();
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
	public  System.Windows.Forms.TextBox txtmNumeroClienteCorrecto;
	public  System.Windows.Forms.CheckBox chkmBancanet;
	public  System.Windows.Forms.TextBox txtmNombreEmpresa;
	public  System.Windows.Forms.TextBox txtmNumeroCliente;
	public  System.Windows.Forms.TextBox txtmNumeroEmpresa;
	public  System.Windows.Forms.Button cmdmActualizar;
	public  System.Windows.Forms.Button cmdmSalir;
	private  System.Windows.Forms.Label _ID_CEM_ETI_PNL_0;
	private  System.Windows.Forms.Label _ID_CEM_ETI_PNL_7;

	private  System.Windows.Forms.Label _ID_CEM_ETI_PNL_1;

	private  System.Windows.Forms.Label _ID_CEM_ETI_PNL_2;

	private  System.Windows.Forms.Label _ID_CEM_ETI_PNL_3;

	public  System.Windows.Forms.Label Line1;
        public System.Windows.Forms.Label[] ID_CEM_ETI_PNL = new System.Windows.Forms.Label[8];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_CEM_PPL_PNL = new System.Windows.Forms.Panel();
        this.cmdmSalir = new System.Windows.Forms.Button();
        this._ID_CEM_ETI_PNL_0 = new System.Windows.Forms.Label();
        this.cmdmActualizar = new System.Windows.Forms.Button();
        this.txtmNumeroCliente = new System.Windows.Forms.TextBox();
        this.txtmNumeroEmpresa = new System.Windows.Forms.TextBox();
        this._ID_CEM_ETI_PNL_3 = new System.Windows.Forms.Label();
        this.Line1 = new System.Windows.Forms.Label();
        this._ID_CEM_ETI_PNL_2 = new System.Windows.Forms.Label();
        this._ID_CEM_ETI_PNL_7 = new System.Windows.Forms.Label();
        this._ID_CEM_ETI_PNL_1 = new System.Windows.Forms.Label();
        this.txtmNumeroClienteCorrecto = new System.Windows.Forms.TextBox();
        this.chkmBancanet = new System.Windows.Forms.CheckBox();
        this.txtmNombreEmpresa = new System.Windows.Forms.TextBox();
        this.ID_CEM_PPL_PNL.SuspendLayout();
        this.SuspendLayout();
        // 
        // ID_CEM_PPL_PNL
        // 
        this.ID_CEM_PPL_PNL.BackColor = System.Drawing.Color.Silver;
        this.ID_CEM_PPL_PNL.Controls.Add(this.cmdmSalir);
        this.ID_CEM_PPL_PNL.Controls.Add(this._ID_CEM_ETI_PNL_0);
        this.ID_CEM_PPL_PNL.Controls.Add(this.cmdmActualizar);
        this.ID_CEM_PPL_PNL.Controls.Add(this.txtmNumeroCliente);
        this.ID_CEM_PPL_PNL.Controls.Add(this.txtmNumeroEmpresa);
        this.ID_CEM_PPL_PNL.Controls.Add(this._ID_CEM_ETI_PNL_3);
        this.ID_CEM_PPL_PNL.Controls.Add(this.Line1);
        this.ID_CEM_PPL_PNL.Controls.Add(this._ID_CEM_ETI_PNL_2);
        this.ID_CEM_PPL_PNL.Controls.Add(this._ID_CEM_ETI_PNL_7);
        this.ID_CEM_PPL_PNL.Controls.Add(this._ID_CEM_ETI_PNL_1);
        this.ID_CEM_PPL_PNL.Controls.Add(this.txtmNumeroClienteCorrecto);
        this.ID_CEM_PPL_PNL.Controls.Add(this.chkmBancanet);
        this.ID_CEM_PPL_PNL.Controls.Add(this.txtmNombreEmpresa);
        this.ID_CEM_PPL_PNL.Location = new System.Drawing.Point(3, 3);
        this.ID_CEM_PPL_PNL.Name = "ID_CEM_PPL_PNL";
        this.ID_CEM_PPL_PNL.Size = new System.Drawing.Size(444, 191);
        this.ID_CEM_PPL_PNL.TabIndex = 0;
        this.ID_CEM_PPL_PNL.Tag = "";
        // 
        // cmdmSalir
        // 
        this.cmdmSalir.BackColor = System.Drawing.SystemColors.Control;
        this.cmdmSalir.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdmSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cmdmSalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdmSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdmSalir.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdmSalir.Location = new System.Drawing.Point(307, 146);
        this.cmdmSalir.Name = "cmdmSalir";
        this.cmdmSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdmSalir.Size = new System.Drawing.Size(124, 22);
        this.cmdmSalir.TabIndex = 7;
        this.cmdmSalir.Tag = "";
        this.cmdmSalir.Text = "&Salir";
        this.cmdmSalir.UseVisualStyleBackColor = false;
        this.cmdmSalir.Click += new System.EventHandler(this.cmdmSalir_Click);
        // 
        // _ID_CEM_ETI_PNL_0
        // 
        this._ID_CEM_ETI_PNL_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._ID_CEM_ETI_PNL_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CEM_ETI_PNL_0.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_CEM_ETI_PNL_0.Location = new System.Drawing.Point(19, 114);
        this._ID_CEM_ETI_PNL_0.Name = "_ID_CEM_ETI_PNL_0";
        this._ID_CEM_ETI_PNL_0.Size = new System.Drawing.Size(89, 21);
        this._ID_CEM_ETI_PNL_0.TabIndex = 0;
        this._ID_CEM_ETI_PNL_0.Tag = "";
        this._ID_CEM_ETI_PNL_0.Text = "Cliente";
        this._ID_CEM_ETI_PNL_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // cmdmActualizar
        // 
        this.cmdmActualizar.BackColor = System.Drawing.SystemColors.Control;
        this.cmdmActualizar.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdmActualizar.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdmActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdmActualizar.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdmActualizar.Location = new System.Drawing.Point(163, 146);
        this.cmdmActualizar.Name = "cmdmActualizar";
        this.cmdmActualizar.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdmActualizar.Size = new System.Drawing.Size(124, 22);
        this.cmdmActualizar.TabIndex = 6;
        this.cmdmActualizar.Tag = "A";
        this.cmdmActualizar.Text = "&Actualizar";
        this.cmdmActualizar.UseVisualStyleBackColor = false;
        this.cmdmActualizar.Click += new System.EventHandler(this.cmdmActualizar_Click);
        // 
        // txtmNumeroCliente
        // 
        this.txtmNumeroCliente.AcceptsReturn = true;
        this.txtmNumeroCliente.BackColor = System.Drawing.SystemColors.Window;
        this.txtmNumeroCliente.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtmNumeroCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtmNumeroCliente.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtmNumeroCliente.Location = new System.Drawing.Point(115, 114);
        this.txtmNumeroCliente.MaxLength = 0;
        this.txtmNumeroCliente.Name = "txtmNumeroCliente";
        this.txtmNumeroCliente.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtmNumeroCliente.Size = new System.Drawing.Size(313, 20);
        this.txtmNumeroCliente.TabIndex = 4;
        this.txtmNumeroCliente.Tag = "";
        this.txtmNumeroCliente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtmNumeroCliente_KeyPress);
        // 
        // txtmNumeroEmpresa
        // 
        this.txtmNumeroEmpresa.AcceptsReturn = true;
        this.txtmNumeroEmpresa.BackColor = System.Drawing.SystemColors.Control;
        this.txtmNumeroEmpresa.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtmNumeroEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtmNumeroEmpresa.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtmNumeroEmpresa.Location = new System.Drawing.Point(19, 42);
        this.txtmNumeroEmpresa.MaxLength = 0;
        this.txtmNumeroEmpresa.Name = "txtmNumeroEmpresa";
        this.txtmNumeroEmpresa.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtmNumeroEmpresa.Size = new System.Drawing.Size(89, 20);
        this.txtmNumeroEmpresa.TabIndex = 1;
        this.txtmNumeroEmpresa.Tag = "";
        this.txtmNumeroEmpresa.TextChanged += new System.EventHandler(this.txtmNumeroEmpresa_TextChanged);
        // 
        // _ID_CEM_ETI_PNL_3
        // 
        this._ID_CEM_ETI_PNL_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._ID_CEM_ETI_PNL_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CEM_ETI_PNL_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CEM_ETI_PNL_3.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_CEM_ETI_PNL_3.Location = new System.Drawing.Point(19, 73);
        this._ID_CEM_ETI_PNL_3.Name = "_ID_CEM_ETI_PNL_3";
        this._ID_CEM_ETI_PNL_3.Size = new System.Drawing.Size(89, 21);
        this._ID_CEM_ETI_PNL_3.TabIndex = 0;
        this._ID_CEM_ETI_PNL_3.Tag = "";
        this._ID_CEM_ETI_PNL_3.Text = "No. Cliente";
        this._ID_CEM_ETI_PNL_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // Line1
        // 
        this.Line1.BackColor = System.Drawing.SystemColors.WindowText;
        this.Line1.Location = new System.Drawing.Point(19, 106);
        this.Line1.Name = "Line1";
        this.Line1.Size = new System.Drawing.Size(408, 1);
        this.Line1.TabIndex = 12;
        this.Line1.Tag = "";
        // 
        // _ID_CEM_ETI_PNL_2
        // 
        this._ID_CEM_ETI_PNL_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._ID_CEM_ETI_PNL_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CEM_ETI_PNL_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CEM_ETI_PNL_2.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_CEM_ETI_PNL_2.Location = new System.Drawing.Point(19, 147);
        this._ID_CEM_ETI_PNL_2.Name = "_ID_CEM_ETI_PNL_2";
        this._ID_CEM_ETI_PNL_2.Size = new System.Drawing.Size(89, 21);
        this._ID_CEM_ETI_PNL_2.TabIndex = 0;
        this._ID_CEM_ETI_PNL_2.Tag = "";
        this._ID_CEM_ETI_PNL_2.Text = "Bancanet";
        this._ID_CEM_ETI_PNL_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _ID_CEM_ETI_PNL_7
        // 
        this._ID_CEM_ETI_PNL_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._ID_CEM_ETI_PNL_7.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CEM_ETI_PNL_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CEM_ETI_PNL_7.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_CEM_ETI_PNL_7.Location = new System.Drawing.Point(19, 11);
        this._ID_CEM_ETI_PNL_7.Name = "_ID_CEM_ETI_PNL_7";
        this._ID_CEM_ETI_PNL_7.Size = new System.Drawing.Size(89, 21);
        this._ID_CEM_ETI_PNL_7.TabIndex = 0;
        this._ID_CEM_ETI_PNL_7.Tag = "";
        this._ID_CEM_ETI_PNL_7.Text = "No.";
        this._ID_CEM_ETI_PNL_7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _ID_CEM_ETI_PNL_1
        // 
        this._ID_CEM_ETI_PNL_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._ID_CEM_ETI_PNL_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CEM_ETI_PNL_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CEM_ETI_PNL_1.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_CEM_ETI_PNL_1.Location = new System.Drawing.Point(115, 11);
        this._ID_CEM_ETI_PNL_1.Name = "_ID_CEM_ETI_PNL_1";
        this._ID_CEM_ETI_PNL_1.Size = new System.Drawing.Size(313, 21);
        this._ID_CEM_ETI_PNL_1.TabIndex = 0;
        this._ID_CEM_ETI_PNL_1.Tag = "";
        this._ID_CEM_ETI_PNL_1.Text = "Empresa";
        this._ID_CEM_ETI_PNL_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // txtmNumeroClienteCorrecto
        // 
        this.txtmNumeroClienteCorrecto.AcceptsReturn = true;
        this.txtmNumeroClienteCorrecto.BackColor = System.Drawing.SystemColors.Control;
        this.txtmNumeroClienteCorrecto.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtmNumeroClienteCorrecto.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtmNumeroClienteCorrecto.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtmNumeroClienteCorrecto.Location = new System.Drawing.Point(115, 74);
        this.txtmNumeroClienteCorrecto.MaxLength = 0;
        this.txtmNumeroClienteCorrecto.Name = "txtmNumeroClienteCorrecto";
        this.txtmNumeroClienteCorrecto.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtmNumeroClienteCorrecto.Size = new System.Drawing.Size(313, 20);
        this.txtmNumeroClienteCorrecto.TabIndex = 3;
        this.txtmNumeroClienteCorrecto.Tag = "";
        // 
        // chkmBancanet
        // 
        this.chkmBancanet.BackColor = System.Drawing.Color.Silver;
        this.chkmBancanet.Cursor = System.Windows.Forms.Cursors.Default;
        this.chkmBancanet.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.chkmBancanet.ForeColor = System.Drawing.SystemColors.ControlText;
        this.chkmBancanet.Location = new System.Drawing.Point(115, 146);
        this.chkmBancanet.Name = "chkmBancanet";
        this.chkmBancanet.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.chkmBancanet.Size = new System.Drawing.Size(17, 17);
        this.chkmBancanet.TabIndex = 5;
        this.chkmBancanet.Tag = "";
        this.chkmBancanet.UseVisualStyleBackColor = false;
        // 
        // txtmNombreEmpresa
        // 
        this.txtmNombreEmpresa.AcceptsReturn = true;
        this.txtmNombreEmpresa.BackColor = System.Drawing.SystemColors.Control;
        this.txtmNombreEmpresa.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtmNombreEmpresa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtmNombreEmpresa.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtmNombreEmpresa.Location = new System.Drawing.Point(115, 42);
        this.txtmNombreEmpresa.MaxLength = 0;
        this.txtmNombreEmpresa.Name = "txtmNombreEmpresa";
        this.txtmNombreEmpresa.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtmNombreEmpresa.Size = new System.Drawing.Size(313, 20);
        this.txtmNombreEmpresa.TabIndex = 2;
        this.txtmNombreEmpresa.Tag = "";
        // 
        // frmCliBancanet
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(447, 194);
        this.Controls.Add(this.ID_CEM_PPL_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(3, 22);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmCliBancanet";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Tag = "";
        this.Text = "BancaNet";
        this.Closed += new System.EventHandler(this.frmCliBancanet_Closed);
        this.Activated += new System.EventHandler(this.frmCliBancanet_Activated);
        this.ID_CEM_PPL_PNL.ResumeLayout(false);
        this.ID_CEM_PPL_PNL.PerformLayout();
        this.ResumeLayout(false);

	}
	void  InitializeID_CEM_ETI_PNL()
	{
			this.ID_CEM_ETI_PNL[0] = _ID_CEM_ETI_PNL_0;
			this.ID_CEM_ETI_PNL[7] = _ID_CEM_ETI_PNL_7;
			this.ID_CEM_ETI_PNL[1] = _ID_CEM_ETI_PNL_1;
			this.ID_CEM_ETI_PNL[2] = _ID_CEM_ETI_PNL_2;
			this.ID_CEM_ETI_PNL[3] = _ID_CEM_ETI_PNL_3;
	}
#endregion 

        private System.Windows.Forms.Panel ID_CEM_PPL_PNL;
}
}