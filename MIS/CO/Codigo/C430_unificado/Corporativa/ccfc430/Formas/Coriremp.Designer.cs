using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORIREMP
	{
	
#region "Upgrade Support "
		private static CORIREMP m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORIREMP DefInstance
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
		public CORIREMP():base(){
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
			InitializesspEtiqueta();
			InitializesstFolder();
			InitializelblEtiqueta();
			InitializetxtTexto();
		}
	public static CORIREMP CreateInstance()
	{
			CORIREMP theInstance = new CORIREMP();
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
	public System.Windows.Forms.Label[] lblEtiqueta = new System.Windows.Forms.Label[1];
	public AxThreed.AxSSPanel[] sspEtiqueta = new AxThreed.AxSSPanel[2];
	public System.Windows.Forms.TabControl[] sstFolder = new System.Windows.Forms.TabControl[1];
	public System.Windows.Forms.TextBox[] txtTexto = new System.Windows.Forms.TextBox[2];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORIREMP));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._sspEtiqueta_0 = new AxThreed.AxSSPanel();
            this._sspEtiqueta_0Label_Text = new System.Windows.Forms.Label();
            this._sspEtiqueta_1 = new AxThreed.AxSSPanel();
            this._sspEtiqueta_1Label_Text = new System.Windows.Forms.Label();
            this.SSPanel3 = new AxThreed.AxSSPanel();
            this.SSPanel3Label_Text = new System.Windows.Forms.Label();
            this._sstFolder_0 = new System.Windows.Forms.TabControl();
            this.@__sstFolder_0_TabPage0 = new System.Windows.Forms.TabPage();
            this._txtTexto_1 = new System.Windows.Forms.TextBox();
            this._lblEtiqueta_0 = new System.Windows.Forms.Label();
            this.@__sstFolder_0_TabPage1 = new System.Windows.Forms.TabPage();
            this._txtTexto_0 = new System.Windows.Forms.TextBox();
            this.ID_IRA_TEX_TXT = new System.Windows.Forms.Label();
            this.lstLista = new System.Windows.Forms.ListBox();
            this.ID_IRA_OK_PB = new System.Windows.Forms.Button();
            this.ID_IRA_CAN_PB = new System.Windows.Forms.Button();
            this.cmdNuevo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._sspEtiqueta_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._sspEtiqueta_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSPanel3)).BeginInit();
            this._sstFolder_0.SuspendLayout();
            this.@__sstFolder_0_TabPage0.SuspendLayout();
            this.@__sstFolder_0_TabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // _sspEtiqueta_0
            // 
            this._sspEtiqueta_0.Location = new System.Drawing.Point(11, 130);
            this._sspEtiqueta_0.Name = "_sspEtiqueta_0";
            this._sspEtiqueta_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_sspEtiqueta_0.OcxState")));
            this._sspEtiqueta_0.Size = new System.Drawing.Size(81, 29);
            this._sspEtiqueta_0.TabIndex = 11;
            this._sspEtiqueta_0.Tag = "";
            // 
            // _sspEtiqueta_0Label_Text
            // 
            this._sspEtiqueta_0Label_Text.BackColor = System.Drawing.Color.Silver;
            this._sspEtiqueta_0Label_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._sspEtiqueta_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._sspEtiqueta_0Label_Text.ForeColor = System.Drawing.SystemColors.ControlText;
            this._sspEtiqueta_0Label_Text.Location = new System.Drawing.Point(11, 130);
            this._sspEtiqueta_0Label_Text.Name = "_sspEtiqueta_0Label_Text";
            this._sspEtiqueta_0Label_Text.Size = new System.Drawing.Size(54, 19);
            this._sspEtiqueta_0Label_Text.TabIndex = 13;
            this._sspEtiqueta_0Label_Text.Tag = "";
            this._sspEtiqueta_0Label_Text.Text = "Número";
            this._sspEtiqueta_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _sspEtiqueta_1
            // 
            this._sspEtiqueta_1.Location = new System.Drawing.Point(66, 131);
            this._sspEtiqueta_1.Name = "_sspEtiqueta_1";
            this._sspEtiqueta_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_sspEtiqueta_1.OcxState")));
            this._sspEtiqueta_1.Size = new System.Drawing.Size(76, 29);
            this._sspEtiqueta_1.TabIndex = 16;
            this._sspEtiqueta_1.Tag = "";
            // 
            // _sspEtiqueta_1Label_Text
            // 
            this._sspEtiqueta_1Label_Text.BackColor = System.Drawing.Color.Silver;
            this._sspEtiqueta_1Label_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this._sspEtiqueta_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._sspEtiqueta_1Label_Text.ForeColor = System.Drawing.SystemColors.ControlText;
            this._sspEtiqueta_1Label_Text.Location = new System.Drawing.Point(66, 130);
            this._sspEtiqueta_1Label_Text.Name = "_sspEtiqueta_1Label_Text";
            this._sspEtiqueta_1Label_Text.Size = new System.Drawing.Size(51, 19);
            this._sspEtiqueta_1Label_Text.TabIndex = 17;
            this._sspEtiqueta_1Label_Text.Tag = "";
            this._sspEtiqueta_1Label_Text.Text = "Grupo";
            this._sspEtiqueta_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SSPanel3
            // 
            this.SSPanel3.Location = new System.Drawing.Point(118, 131);
            this.SSPanel3.Name = "SSPanel3";
            this.SSPanel3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SSPanel3.OcxState")));
            this.SSPanel3.Size = new System.Drawing.Size(615, 29);
            this.SSPanel3.TabIndex = 18;
            this.SSPanel3.Tag = "";
            // 
            // SSPanel3Label_Text
            // 
            this.SSPanel3Label_Text.BackColor = System.Drawing.Color.Silver;
            this.SSPanel3Label_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SSPanel3Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.SSPanel3Label_Text.ForeColor = System.Drawing.SystemColors.ControlText;
            this.SSPanel3Label_Text.Location = new System.Drawing.Point(118, 130);
            this.SSPanel3Label_Text.Name = "SSPanel3Label_Text";
            this.SSPanel3Label_Text.Size = new System.Drawing.Size(410, 19);
            this.SSPanel3Label_Text.TabIndex = 19;
            this.SSPanel3Label_Text.Tag = "";
            this.SSPanel3Label_Text.Text = "Empresa";
            this.SSPanel3Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _sstFolder_0
            // 
            this._sstFolder_0.Controls.Add(this.@__sstFolder_0_TabPage0);
            this._sstFolder_0.Controls.Add(this.@__sstFolder_0_TabPage1);
            this._sstFolder_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._sstFolder_0.ItemSize = new System.Drawing.Size(79, 18);
            this._sstFolder_0.Location = new System.Drawing.Point(11, 8);
            this._sstFolder_0.Multiline = true;
            this._sstFolder_0.Name = "_sstFolder_0";
            this._sstFolder_0.SelectedIndex = 0;
            this._sstFolder_0.Size = new System.Drawing.Size(404, 116);
            this._sstFolder_0.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this._sstFolder_0.TabIndex = 20;
            this._sstFolder_0.Tag = "";
            // 
            // __sstFolder_0_TabPage0
            // 
            this.@__sstFolder_0_TabPage0.Controls.Add(this._txtTexto_1);
            this.@__sstFolder_0_TabPage0.Controls.Add(this._lblEtiqueta_0);
            this.@__sstFolder_0_TabPage0.Location = new System.Drawing.Point(4, 22);
            this.@__sstFolder_0_TabPage0.Name = "__sstFolder_0_TabPage0";
            this.@__sstFolder_0_TabPage0.Size = new System.Drawing.Size(396, 90);
            this.@__sstFolder_0_TabPage0.TabIndex = 4;
            this.@__sstFolder_0_TabPage0.Tag = "";
            this.@__sstFolder_0_TabPage0.Text = "Nombre de Empresa";
            // 
            // _txtTexto_1
            // 
            this._txtTexto_1.AcceptsReturn = true;
            this._txtTexto_1.BackColor = System.Drawing.SystemColors.Window;
            this._txtTexto_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtTexto_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTexto_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtTexto_1.Location = new System.Drawing.Point(13, 60);
            this._txtTexto_1.MaxLength = 0;
            this._txtTexto_1.Name = "_txtTexto_1";
            this._txtTexto_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtTexto_1.Size = new System.Drawing.Size(370, 20);
            this._txtTexto_1.TabIndex = 4;
            this._txtTexto_1.Tag = "";
            this._txtTexto_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
            this._txtTexto_1.Leave += new System.EventHandler(this.txtTexto_Leave);
            // 
            // _lblEtiqueta_0
            // 
            this._lblEtiqueta_0.BackColor = System.Drawing.SystemColors.Control;
            this._lblEtiqueta_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblEtiqueta_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblEtiqueta_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblEtiqueta_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblEtiqueta_0.Location = new System.Drawing.Point(13, 19);
            this._lblEtiqueta_0.Name = "_lblEtiqueta_0";
            this._lblEtiqueta_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblEtiqueta_0.Size = new System.Drawing.Size(370, 31);
            this._lblEtiqueta_0.TabIndex = 3;
            this._lblEtiqueta_0.Tag = "";
            this._lblEtiqueta_0.Text = "Teclee el nombre de la empresa o al menos un texto que contenga el nombre de la e" +
    "mprea";
            // 
            // __sstFolder_0_TabPage1
            // 
            this.@__sstFolder_0_TabPage1.Controls.Add(this._txtTexto_0);
            this.@__sstFolder_0_TabPage1.Controls.Add(this.ID_IRA_TEX_TXT);
            this.@__sstFolder_0_TabPage1.Location = new System.Drawing.Point(4, 22);
            this.@__sstFolder_0_TabPage1.Name = "__sstFolder_0_TabPage1";
            this.@__sstFolder_0_TabPage1.Size = new System.Drawing.Size(396, 90);
            this.@__sstFolder_0_TabPage1.TabIndex = 5;
            this.@__sstFolder_0_TabPage1.Tag = "";
            this.@__sstFolder_0_TabPage1.Text = "Número de Empresa";
            // 
            // _txtTexto_0
            // 
            this._txtTexto_0.AcceptsReturn = true;
            this._txtTexto_0.BackColor = System.Drawing.Color.White;
            this._txtTexto_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._txtTexto_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._txtTexto_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._txtTexto_0.Location = new System.Drawing.Point(229, 36);
            this._txtTexto_0.MaxLength = 5;
            this._txtTexto_0.Multiline = true;
            this._txtTexto_0.Name = "_txtTexto_0";
            this._txtTexto_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._txtTexto_0.Size = new System.Drawing.Size(67, 22);
            this._txtTexto_0.TabIndex = 13;
            this._txtTexto_0.Tag = "";
            this._txtTexto_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this._txtTexto_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
            this._txtTexto_0.Leave += new System.EventHandler(this.txtTexto_Leave);
            // 
            // ID_IRA_TEX_TXT
            // 
            this.ID_IRA_TEX_TXT.BackColor = System.Drawing.Color.Silver;
            this.ID_IRA_TEX_TXT.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_IRA_TEX_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_IRA_TEX_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_IRA_TEX_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_IRA_TEX_TXT.Location = new System.Drawing.Point(29, 40);
            this.ID_IRA_TEX_TXT.Name = "ID_IRA_TEX_TXT";
            this.ID_IRA_TEX_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_IRA_TEX_TXT.Size = new System.Drawing.Size(187, 16);
            this.ID_IRA_TEX_TXT.TabIndex = 12;
            this.ID_IRA_TEX_TXT.Tag = "";
            this.ID_IRA_TEX_TXT.Text = "Teclee el Número de la Empresa";
            // 
            // lstLista
            // 
            this.lstLista.BackColor = System.Drawing.SystemColors.Window;
            this.lstLista.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstLista.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstLista.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstLista.ItemHeight = 14;
            this.lstLista.Location = new System.Drawing.Point(12, 152);
            this.lstLista.Name = "lstLista";
            this.lstLista.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstLista.Size = new System.Drawing.Size(515, 130);
            this.lstLista.TabIndex = 21;
            this.lstLista.Tag = "";
            this.lstLista.DoubleClick += new System.EventHandler(this.lstLista_DoubleClick);
            // 
            // ID_IRA_OK_PB
            // 
            this.ID_IRA_OK_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_IRA_OK_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_IRA_OK_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_IRA_OK_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_IRA_OK_PB.Location = new System.Drawing.Point(420, 36);
            this.ID_IRA_OK_PB.Name = "ID_IRA_OK_PB";
            this.ID_IRA_OK_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_IRA_OK_PB.Size = new System.Drawing.Size(112, 23);
            this.ID_IRA_OK_PB.TabIndex = 22;
            this.ID_IRA_OK_PB.Tag = "";
            this.ID_IRA_OK_PB.Text = "&Buscar Ahora";
            this.ID_IRA_OK_PB.UseVisualStyleBackColor = false;
            this.ID_IRA_OK_PB.Click += new System.EventHandler(this.ID_IRA_OK_PB_Click);
            // 
            // ID_IRA_CAN_PB
            // 
            this.ID_IRA_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_IRA_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_IRA_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_IRA_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_IRA_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_IRA_CAN_PB.Location = new System.Drawing.Point(420, 65);
            this.ID_IRA_CAN_PB.Name = "ID_IRA_CAN_PB";
            this.ID_IRA_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_IRA_CAN_PB.Size = new System.Drawing.Size(112, 23);
            this.ID_IRA_CAN_PB.TabIndex = 23;
            this.ID_IRA_CAN_PB.Tag = "";
            this.ID_IRA_CAN_PB.Text = "&Cancelar";
            this.ID_IRA_CAN_PB.UseVisualStyleBackColor = false;
            this.ID_IRA_CAN_PB.Click += new System.EventHandler(this.ID_IRA_CAN_PB_Click);
            // 
            // cmdNuevo
            // 
            this.cmdNuevo.BackColor = System.Drawing.SystemColors.Control;
            this.cmdNuevo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNuevo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdNuevo.Location = new System.Drawing.Point(420, 94);
            this.cmdNuevo.Name = "cmdNuevo";
            this.cmdNuevo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdNuevo.Size = new System.Drawing.Size(112, 23);
            this.cmdNuevo.TabIndex = 24;
            this.cmdNuevo.Tag = "";
            this.cmdNuevo.Text = "&Nueva Búsqueda";
            this.cmdNuevo.UseVisualStyleBackColor = false;
            this.cmdNuevo.Click += new System.EventHandler(this.cmdNuevo_Click);
            // 
            // CORIREMP
            // 
            this.AcceptButton = this.ID_IRA_OK_PB;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(537, 318);
            this.Controls.Add(this.cmdNuevo);
            this.Controls.Add(this.ID_IRA_CAN_PB);
            this.Controls.Add(this.ID_IRA_OK_PB);
            this.Controls.Add(this.lstLista);
            this.Controls.Add(this._sstFolder_0);
            this.Controls.Add(this.SSPanel3Label_Text);
            this.Controls.Add(this.SSPanel3);
            this.Controls.Add(this._sspEtiqueta_1Label_Text);
            this.Controls.Add(this._sspEtiqueta_1);
            this.Controls.Add(this._sspEtiqueta_0Label_Text);
            this.Controls.Add(this._sspEtiqueta_0);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(190, 155);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORIREMP";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Buscar:  Empresas";
            this.Activated += new System.EventHandler(this.CORIREMP_Activated);
            this.Closed += new System.EventHandler(this.CORIREMP_Closed);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CORIREMP_Closing);
            ((System.ComponentModel.ISupportInitialize)(this._sspEtiqueta_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._sspEtiqueta_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SSPanel3)).EndInit();
            this._sstFolder_0.ResumeLayout(false);
            this.@__sstFolder_0_TabPage0.ResumeLayout(false);
            this.@__sstFolder_0_TabPage0.PerformLayout();
            this.@__sstFolder_0_TabPage1.ResumeLayout(false);
            this.@__sstFolder_0_TabPage1.PerformLayout();
            this.ResumeLayout(false);

	}
	void  InitializesspEtiqueta()
	{
			this.sspEtiqueta[0] = _sspEtiqueta_0;
			this.sspEtiqueta[1] = _sspEtiqueta_1;
	}
	void  InitializesstFolder()
	{
			this.sstFolder[0] = _sstFolder_0;
	}
	void  InitializelblEtiqueta()
	{
			this.lblEtiqueta[0] = _lblEtiqueta_0;
	}
	void  InitializetxtTexto()
	{
			this.txtTexto[1] = _txtTexto_1;
			this.txtTexto[0] = _txtTexto_0;
	}
#endregion 

        private AxThreed.AxSSPanel _sspEtiqueta_0;
        private System.Windows.Forms.Label _sspEtiqueta_0Label_Text;
        private AxThreed.AxSSPanel _sspEtiqueta_1;
        private System.Windows.Forms.Label _sspEtiqueta_1Label_Text;
        public AxThreed.AxSSPanel SSPanel3;
        public System.Windows.Forms.Label SSPanel3Label_Text;
        private System.Windows.Forms.TabControl _sstFolder_0;
        public System.Windows.Forms.ListBox lstLista;
        public System.Windows.Forms.Button ID_IRA_OK_PB;
        public System.Windows.Forms.Button ID_IRA_CAN_PB;
        public System.Windows.Forms.Button cmdNuevo;
        private System.Windows.Forms.TabPage __sstFolder_0_TabPage0;
        private System.Windows.Forms.TextBox _txtTexto_1;
        private System.Windows.Forms.Label _lblEtiqueta_0;
        private System.Windows.Forms.TabPage __sstFolder_0_TabPage1;
        private System.Windows.Forms.TextBox _txtTexto_0;
        public System.Windows.Forms.Label ID_IRA_TEX_TXT;
}
}