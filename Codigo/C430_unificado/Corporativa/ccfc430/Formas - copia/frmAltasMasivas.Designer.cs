using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmAltasMasivas
	{
	
#region "Upgrade Support "
		private static frmAltasMasivas m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmAltasMasivas DefInstance
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
		public frmAltasMasivas():base(){
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
			InitializeLabel1();
			InitializelblNumCampo();
			InitializelblNumRegistro();
			InitializepnlProgProceso();
		}
	public static frmAltasMasivas CreateInstance()
	{
			frmAltasMasivas theInstance = new frmAltasMasivas();
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
	private  AxThreed.AxSSPanel _pnlProgProceso_0;
	public  AxMSComDlg.AxCommonDialog cmnAltasMasivas;
	private  AxThreed.AxSSPanel _pnlProgProceso_1;
	public  System.Windows.Forms.Label lblMensaje;
	public  System.Windows.Forms.Label lblRegistro;
	public  System.Windows.Forms.Label lblCamp;
	private  System.Windows.Forms.Label _Label1_1;
	private  System.Windows.Forms.Label _Label1_0;
	private  System.Windows.Forms.Label _lblNumRegistro_1;
	private  System.Windows.Forms.Label _lblNumCampo_1;
	private  System.Windows.Forms.Label _lblNumCampo_0;
	private  System.Windows.Forms.Label _lblNumRegistro_0;
	public System.Windows.Forms.Label[] Label1 = new System.Windows.Forms.Label[2];
	public System.Windows.Forms.Label[] lblNumCampo = new System.Windows.Forms.Label[2];
	public System.Windows.Forms.Label[] lblNumRegistro = new System.Windows.Forms.Label[2];
	public AxThreed.AxSSPanel[] pnlProgProceso = new AxThreed.AxSSPanel[2];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltasMasivas));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this._pnlProgProceso_0 = new AxThreed.AxSSPanel();
        this.cmnAltasMasivas = new AxMSComDlg.AxCommonDialog();
        this._pnlProgProceso_1 = new AxThreed.AxSSPanel();
        this.lblMensaje = new System.Windows.Forms.Label();
        this.lblRegistro = new System.Windows.Forms.Label();
        this.lblCamp = new System.Windows.Forms.Label();
        this._Label1_1 = new System.Windows.Forms.Label();
        this._Label1_0 = new System.Windows.Forms.Label();
        this._lblNumRegistro_1 = new System.Windows.Forms.Label();
        this._lblNumCampo_1 = new System.Windows.Forms.Label();
        this._lblNumCampo_0 = new System.Windows.Forms.Label();
        this._lblNumRegistro_0 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this._pnlProgProceso_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.cmnAltasMasivas)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._pnlProgProceso_1)).BeginInit();
        this.SuspendLayout();
        // 
        // _pnlProgProceso_0
        // 
        this._pnlProgProceso_0.Location = new System.Drawing.Point(8, 48);
        this._pnlProgProceso_0.Name = "_pnlProgProceso_0";
        this._pnlProgProceso_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlProgProceso_0.OcxState")));
        this._pnlProgProceso_0.Size = new System.Drawing.Size(289, 17);
        this._pnlProgProceso_0.TabIndex = 0;
        this._pnlProgProceso_0.Tag = "";
        // 
        // cmnAltasMasivas
        // 
        this.cmnAltasMasivas.Enabled = true;
        this.cmnAltasMasivas.Location = new System.Drawing.Point(264, 16);
        this.cmnAltasMasivas.Name = "cmnAltasMasivas";
        this.cmnAltasMasivas.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cmnAltasMasivas.OcxState")));
        this.cmnAltasMasivas.Size = new System.Drawing.Size(32, 32);
        this.cmnAltasMasivas.TabIndex = 0;
        this.cmnAltasMasivas.Tag = "";
        // 
        // _pnlProgProceso_1
        // 
        this._pnlProgProceso_1.Location = new System.Drawing.Point(8, 152);
        this._pnlProgProceso_1.Name = "_pnlProgProceso_1";
        this._pnlProgProceso_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlProgProceso_1.OcxState")));
        this._pnlProgProceso_1.Size = new System.Drawing.Size(289, 17);
        this._pnlProgProceso_1.TabIndex = 1;
        this._pnlProgProceso_1.Tag = "";
        // 
        // lblMensaje
        // 
        this.lblMensaje.BackColor = System.Drawing.Color.Silver;
        this.lblMensaje.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.lblMensaje.Cursor = System.Windows.Forms.Cursors.Default;
        this.lblMensaje.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.lblMensaje.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblMensaje.ForeColor = System.Drawing.Color.Blue;
        this.lblMensaje.Location = new System.Drawing.Point(8, 80);
        this.lblMensaje.Name = "lblMensaje";
        this.lblMensaje.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lblMensaje.Size = new System.Drawing.Size(289, 25);
        this.lblMensaje.TabIndex = 10;
        this.lblMensaje.Tag = "";
        this.lblMensaje.Text = "Espere, leyendo archivo de datos";
        this.lblMensaje.TextAlign = System.Drawing.ContentAlignment.TopCenter;
        // 
        // lblRegistro
        // 
        this.lblRegistro.BackColor = System.Drawing.SystemColors.Control;
        this.lblRegistro.Cursor = System.Windows.Forms.Cursors.Default;
        this.lblRegistro.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.lblRegistro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblRegistro.ForeColor = System.Drawing.SystemColors.ControlText;
        this.lblRegistro.Location = new System.Drawing.Point(8, 120);
        this.lblRegistro.Name = "lblRegistro";
        this.lblRegistro.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lblRegistro.Size = new System.Drawing.Size(57, 25);
        this.lblRegistro.TabIndex = 9;
        this.lblRegistro.Tag = "";
        this.lblRegistro.Text = "Registro:";
        // 
        // lblCamp
        // 
        this.lblCamp.BackColor = System.Drawing.SystemColors.Control;
        this.lblCamp.Cursor = System.Windows.Forms.Cursors.Default;
        this.lblCamp.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.lblCamp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lblCamp.ForeColor = System.Drawing.SystemColors.ControlText;
        this.lblCamp.Location = new System.Drawing.Point(8, 16);
        this.lblCamp.Name = "lblCamp";
        this.lblCamp.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lblCamp.Size = new System.Drawing.Size(57, 17);
        this.lblCamp.TabIndex = 8;
        this.lblCamp.Tag = "";
        this.lblCamp.Text = "Campo:";
        // 
        // _Label1_1
        // 
        this._Label1_1.BackColor = System.Drawing.SystemColors.Control;
        this._Label1_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._Label1_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._Label1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._Label1_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._Label1_1.Location = new System.Drawing.Point(144, 120);
        this._Label1_1.Name = "_Label1_1";
        this._Label1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._Label1_1.Size = new System.Drawing.Size(25, 25);
        this._Label1_1.TabIndex = 7;
        this._Label1_1.Tag = "";
        this._Label1_1.Text = "de";
        // 
        // _Label1_0
        // 
        this._Label1_0.BackColor = System.Drawing.SystemColors.Control;
        this._Label1_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._Label1_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._Label1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._Label1_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._Label1_0.Location = new System.Drawing.Point(144, 16);
        this._Label1_0.Name = "_Label1_0";
        this._Label1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._Label1_0.Size = new System.Drawing.Size(25, 25);
        this._Label1_0.TabIndex = 6;
        this._Label1_0.Tag = "";
        this._Label1_0.Text = "de";
        // 
        // _lblNumRegistro_1
        // 
        this._lblNumRegistro_1.BackColor = System.Drawing.SystemColors.Control;
        this._lblNumRegistro_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblNumRegistro_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblNumRegistro_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblNumRegistro_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblNumRegistro_1.Location = new System.Drawing.Point(200, 120);
        this._lblNumRegistro_1.Name = "_lblNumRegistro_1";
        this._lblNumRegistro_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblNumRegistro_1.Size = new System.Drawing.Size(49, 17);
        this._lblNumRegistro_1.TabIndex = 5;
        this._lblNumRegistro_1.Tag = "";
        this._lblNumRegistro_1.Text = "0";
        // 
        // _lblNumCampo_1
        // 
        this._lblNumCampo_1.BackColor = System.Drawing.SystemColors.Control;
        this._lblNumCampo_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblNumCampo_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblNumCampo_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblNumCampo_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblNumCampo_1.Location = new System.Drawing.Point(200, 16);
        this._lblNumCampo_1.Name = "_lblNumCampo_1";
        this._lblNumCampo_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblNumCampo_1.Size = new System.Drawing.Size(49, 17);
        this._lblNumCampo_1.TabIndex = 4;
        this._lblNumCampo_1.Tag = "";
        this._lblNumCampo_1.Text = "0";
        // 
        // _lblNumCampo_0
        // 
        this._lblNumCampo_0.BackColor = System.Drawing.SystemColors.Control;
        this._lblNumCampo_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblNumCampo_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblNumCampo_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblNumCampo_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblNumCampo_0.Location = new System.Drawing.Point(80, 16);
        this._lblNumCampo_0.Name = "_lblNumCampo_0";
        this._lblNumCampo_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblNumCampo_0.Size = new System.Drawing.Size(41, 17);
        this._lblNumCampo_0.TabIndex = 3;
        this._lblNumCampo_0.Tag = "";
        this._lblNumCampo_0.Text = "0";
        // 
        // _lblNumRegistro_0
        // 
        this._lblNumRegistro_0.BackColor = System.Drawing.SystemColors.Control;
        this._lblNumRegistro_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblNumRegistro_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblNumRegistro_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblNumRegistro_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblNumRegistro_0.Location = new System.Drawing.Point(80, 120);
        this._lblNumRegistro_0.Name = "_lblNumRegistro_0";
        this._lblNumRegistro_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblNumRegistro_0.Size = new System.Drawing.Size(41, 17);
        this._lblNumRegistro_0.TabIndex = 2;
        this._lblNumRegistro_0.Tag = "";
        this._lblNumRegistro_0.Text = "0";
        // 
        // frmAltasMasivas
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(305, 184);
        this.ControlBox = false;
        this.Controls.Add(this.cmnAltasMasivas);
        this.Controls.Add(this._pnlProgProceso_0);
        this.Controls.Add(this._lblNumCampo_1);
        this.Controls.Add(this._lblNumRegistro_1);
        this.Controls.Add(this._Label1_0);
        this.Controls.Add(this.lblCamp);
        this.Controls.Add(this._Label1_1);
        this.Controls.Add(this.lblRegistro);
        this.Controls.Add(this._pnlProgProceso_1);
        this.Controls.Add(this.lblMensaje);
        this.Controls.Add(this._lblNumCampo_0);
        this.Controls.Add(this._lblNumRegistro_0);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Location = new System.Drawing.Point(84, 93);
        this.Name = "frmAltasMasivas";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Proceso Altas Masivas";
        this.Closed += new System.EventHandler(this.frmAltasMasivas_Closed);
        this.Shown += new System.EventHandler(this.frmAltasMasivas_Shown);
        ((System.ComponentModel.ISupportInitialize)(this._pnlProgProceso_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.cmnAltasMasivas)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._pnlProgProceso_1)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeLabel1()
	{
			this.Label1[1] = _Label1_1;
			this.Label1[0] = _Label1_0;
	}
	void  InitializelblNumCampo()
	{
			this.lblNumCampo[1] = _lblNumCampo_1;
			this.lblNumCampo[0] = _lblNumCampo_0;
	}
	void  InitializelblNumRegistro()
	{
			this.lblNumRegistro[1] = _lblNumRegistro_1;
			this.lblNumRegistro[0] = _lblNumRegistro_0;
	}
	void  InitializepnlProgProceso()
	{
			this.pnlProgProceso[0] = _pnlProgProceso_0;
			this.pnlProgProceso[1] = _pnlProgProceso_1;
	}
#endregion 
}
}