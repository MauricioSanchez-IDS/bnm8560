using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORGRREN
	{
	
#region "Upgrade Support "
		private static CORGRREN m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORGRREN DefInstance
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
		public CORGRREN():base(){
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
			InitializegpbGraf();
		}
	public static CORGRREN CreateInstance()
	{
			CORGRREN theInstance = new CORGRREN();
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
	public  System.Windows.Forms.Button cbdMenos;
	public  System.Windows.Forms.Button cbdMas;
	public  System.Windows.Forms.Button cmdImprimir;
	public  System.Windows.Forms.Button cmdSalir;
	private  AxThreed.AxSSRibbon _gpbGraf_3;
	private  AxThreed.AxSSRibbon _gpbGraf_2;
	private  AxThreed.AxSSRibbon _gpbGraf_1;
	private  AxThreed.AxSSRibbon _gpbGraf_0;
	public  AxThreed.AxSSPanel pnlTercero;
	public  AxGraphLib.AxGraph gphGraficaRen;
	public  AxThreed.AxSSPanel pnlSegundo;
	public  AxThreed.AxSSPanel pnlPrincipal;
	public AxThreed.AxSSRibbon[] gpbGraf = new AxThreed.AxSSRibbon[4];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORGRREN));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.pnlSegundo = new AxThreed.AxSSPanel();
        this.cmdImprimir = new System.Windows.Forms.Button();
        this.cbdMas = new System.Windows.Forms.Button();
        this.cbdMenos = new System.Windows.Forms.Button();
        this.cmdSalir = new System.Windows.Forms.Button();
        this.gphGraficaRen = new AxGraphLib.AxGraph();
        this.pnlTercero = new AxThreed.AxSSPanel();
        this._gpbGraf_2 = new AxThreed.AxSSRibbon();
        this._gpbGraf_3 = new AxThreed.AxSSRibbon();
        this._gpbGraf_0 = new AxThreed.AxSSRibbon();
        this._gpbGraf_1 = new AxThreed.AxSSRibbon();
        this.pnlPrincipal = new AxThreed.AxSSPanel();
        ((System.ComponentModel.ISupportInitialize)(this.pnlSegundo)).BeginInit();
        this.pnlSegundo.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.gphGraficaRen)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pnlTercero)).BeginInit();
        this.pnlTercero.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._gpbGraf_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._gpbGraf_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._gpbGraf_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._gpbGraf_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.pnlPrincipal)).BeginInit();
        this.SuspendLayout();
        // 
        // pnlSegundo
        // 
        this.pnlSegundo.Controls.Add(this.cmdImprimir);
        this.pnlSegundo.Controls.Add(this.cbdMas);
        this.pnlSegundo.Controls.Add(this.cbdMenos);
        this.pnlSegundo.Controls.Add(this.cmdSalir);
        this.pnlSegundo.Controls.Add(this.gphGraficaRen);
        this.pnlSegundo.Controls.Add(this.pnlTercero);
        this.pnlSegundo.Location = new System.Drawing.Point(1, 14);
        this.pnlSegundo.Name = "pnlSegundo";
        this.pnlSegundo.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlSegundo.OcxState")));
        this.pnlSegundo.Size = new System.Drawing.Size(515, 293);
        this.pnlSegundo.TabIndex = 0;
        this.pnlSegundo.Tag = "";
        // 
        // cmdImprimir
        // 
        this.cmdImprimir.BackColor = System.Drawing.SystemColors.Control;
        this.cmdImprimir.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdImprimir.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdImprimir.Location = new System.Drawing.Point(356, 264);
        this.cmdImprimir.Name = "cmdImprimir";
        this.cmdImprimir.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdImprimir.Size = new System.Drawing.Size(74, 22);
        this.cmdImprimir.TabIndex = 2;
        this.cmdImprimir.Tag = "";
        this.cmdImprimir.Text = "Imprimir";
        this.cmdImprimir.UseVisualStyleBackColor = false;
        this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
        // 
        // cbdMas
        // 
        this.cbdMas.BackColor = System.Drawing.SystemColors.Control;
        this.cbdMas.Cursor = System.Windows.Forms.Cursors.Default;
        this.cbdMas.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cbdMas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cbdMas.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cbdMas.Location = new System.Drawing.Point(317, 264);
        this.cbdMas.Name = "cbdMas";
        this.cbdMas.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cbdMas.Size = new System.Drawing.Size(23, 22);
        this.cbdMas.TabIndex = 9;
        this.cbdMas.Tag = "";
        this.cbdMas.Text = ">";
        this.cbdMas.UseVisualStyleBackColor = false;
        this.cbdMas.Click += new System.EventHandler(this.cbdMas_Click);
        // 
        // cbdMenos
        // 
        this.cbdMenos.BackColor = System.Drawing.SystemColors.Control;
        this.cbdMenos.Cursor = System.Windows.Forms.Cursors.Default;
        this.cbdMenos.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cbdMenos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cbdMenos.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cbdMenos.Location = new System.Drawing.Point(291, 264);
        this.cbdMenos.Name = "cbdMenos";
        this.cbdMenos.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cbdMenos.Size = new System.Drawing.Size(23, 22);
        this.cbdMenos.TabIndex = 8;
        this.cbdMenos.Tag = "";
        this.cbdMenos.Text = "<";
        this.cbdMenos.UseVisualStyleBackColor = false;
        this.cbdMenos.Click += new System.EventHandler(this.cbdMenos_Click);
        // 
        // cmdSalir
        // 
        this.cmdSalir.BackColor = System.Drawing.SystemColors.Control;
        this.cmdSalir.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdSalir.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdSalir.Location = new System.Drawing.Point(428, 264);
        this.cmdSalir.Name = "cmdSalir";
        this.cmdSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdSalir.Size = new System.Drawing.Size(74, 22);
        this.cmdSalir.TabIndex = 1;
        this.cmdSalir.Tag = "";
        this.cmdSalir.Text = "Cerrar";
        this.cmdSalir.UseVisualStyleBackColor = false;
        this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
        // 
        // gphGraficaRen
        // 
        this.gphGraficaRen.Location = new System.Drawing.Point(8, 8);
        this.gphGraficaRen.Name = "gphGraficaRen";
        this.gphGraficaRen.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("gphGraficaRen.OcxState")));
        this.gphGraficaRen.Size = new System.Drawing.Size(500, 222);
        this.gphGraficaRen.TabIndex = 11;
        this.gphGraficaRen.Tag = "";
        this.gphGraficaRen.DblClick += new System.EventHandler(this.gphGraficaRen_DblClick);
        // 
        // pnlTercero
        // 
        this.pnlTercero.Controls.Add(this._gpbGraf_2);
        this.pnlTercero.Controls.Add(this._gpbGraf_3);
        this.pnlTercero.Controls.Add(this._gpbGraf_0);
        this.pnlTercero.Controls.Add(this._gpbGraf_1);
        this.pnlTercero.Location = new System.Drawing.Point(17, 243);
        this.pnlTercero.Name = "pnlTercero";
        this.pnlTercero.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlTercero.OcxState")));
        this.pnlTercero.Size = new System.Drawing.Size(153, 41);
        this.pnlTercero.TabIndex = 3;
        this.pnlTercero.Tag = "";
        // 
        // _gpbGraf_2
        // 
        this._gpbGraf_2.Location = new System.Drawing.Point(75, 4);
        this._gpbGraf_2.Name = "_gpbGraf_2";
        this._gpbGraf_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_gpbGraf_2.OcxState")));
        this._gpbGraf_2.Size = new System.Drawing.Size(37, 33);
        this._gpbGraf_2.TabIndex = 6;
        this._gpbGraf_2.Tag = "";
        this._gpbGraf_2.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.gpbGraf_ClickEvent);
        // 
        // _gpbGraf_3
        // 
        this._gpbGraf_3.Location = new System.Drawing.Point(112, 4);
        this._gpbGraf_3.Name = "_gpbGraf_3";
        this._gpbGraf_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_gpbGraf_3.OcxState")));
        this._gpbGraf_3.Size = new System.Drawing.Size(37, 33);
        this._gpbGraf_3.TabIndex = 7;
        this._gpbGraf_3.Tag = "";
        this._gpbGraf_3.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.gpbGraf_ClickEvent);
        // 
        // _gpbGraf_0
        // 
        this._gpbGraf_0.Location = new System.Drawing.Point(4, 4);
        this._gpbGraf_0.Name = "_gpbGraf_0";
        this._gpbGraf_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_gpbGraf_0.OcxState")));
        this._gpbGraf_0.Size = new System.Drawing.Size(37, 33);
        this._gpbGraf_0.TabIndex = 4;
        this._gpbGraf_0.Tag = "";
        this._gpbGraf_0.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.gpbGraf_ClickEvent);
        // 
        // _gpbGraf_1
        // 
        this._gpbGraf_1.Location = new System.Drawing.Point(39, 3);
        this._gpbGraf_1.Name = "_gpbGraf_1";
        this._gpbGraf_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_gpbGraf_1.OcxState")));
        this._gpbGraf_1.Size = new System.Drawing.Size(37, 33);
        this._gpbGraf_1.TabIndex = 5;
        this._gpbGraf_1.Tag = "";
        this._gpbGraf_1.ClickEvent += new AxThreed.ISSRICtrlEvents_ClickEventHandler(this.gpbGraf_ClickEvent);
        // 
        // pnlPrincipal
        // 
        this.pnlPrincipal.Location = new System.Drawing.Point(1, 0);
        this.pnlPrincipal.Name = "pnlPrincipal";
        this.pnlPrincipal.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlPrincipal.OcxState")));
        this.pnlPrincipal.Size = new System.Drawing.Size(515, 15);
        this.pnlPrincipal.TabIndex = 10;
        this.pnlPrincipal.Tag = "";
        // 
        // CORGRREN
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.CancelButton = this.cmdSalir;
        this.ClientSize = new System.Drawing.Size(518, 310);
        this.Controls.Add(this.pnlSegundo);
        this.Controls.Add(this.pnlPrincipal);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Location = new System.Drawing.Point(115, 169);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORGRREN";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Rentabilidad";
        this.Closed += new System.EventHandler(this.CORGRREN_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.pnlSegundo)).EndInit();
        this.pnlSegundo.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.gphGraficaRen)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pnlTercero)).EndInit();
        this.pnlTercero.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._gpbGraf_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._gpbGraf_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._gpbGraf_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._gpbGraf_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.pnlPrincipal)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializegpbGraf()
	{
			this.gpbGraf[3] = _gpbGraf_3;
			this.gpbGraf[2] = _gpbGraf_2;
			this.gpbGraf[1] = _gpbGraf_1;
			this.gpbGraf[0] = _gpbGraf_0;
	}
#endregion 
}
}