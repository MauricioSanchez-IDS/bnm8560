using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORMNREN
	{
	
#region "Upgrade Support "
		private static CORMNREN m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORMNREN DefInstance
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
		public CORMNREN():base(){
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
            sprRepRenta = new Softtek.Util.Win.Spread.SpreadWrapper(fpRepRenta);
			InitializeHelp();
		}
	public static CORMNREN CreateInstance()
	{
			CORMNREN theInstance = new CORMNREN();
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
    public Softtek.Util.Win.Spread.SpreadWrapper sprRepRenta;
	private System.ComponentModel.IContainer components;
	public System.Windows.Forms.ToolTip ToolTip1;	
	public  System.Windows.Forms.Button cmdSalir;
	public  System.Windows.Forms.Button cmdImprimir;
	public  System.Windows.Forms.Button cmdGraficar;
	public  System.Windows.Forms.PictureBox picCorporativa;
	public  System.Windows.Forms.PictureBox imgLogo;
	public  System.Windows.Forms.Label lblBanamex;
	public  AxThreed.AxSSPanel pnlSecundario;
	public  System.Windows.Forms.Label lblRenPromedio;
	public  System.Windows.Forms.Label lblRenPro;
	public  System.Windows.Forms.Label lblFecFinR;
	public  System.Windows.Forms.Label lblFecFin;
	public  System.Windows.Forms.Label lblTituloEmp;
	public  System.Windows.Forms.Label lblTitulo;
	public  System.Windows.Forms.Label lblMaxResp;
	public  System.Windows.Forms.Label lblMinResp;
	public  System.Windows.Forms.Label lblRentaMax;
	public  System.Windows.Forms.Label lblRentaMin;
	public  System.Windows.Forms.Label lblFechaRes;
	public  System.Windows.Forms.Label lblFecha;
	public  AxThreed.AxSSPanel pnlTercero;
	public  AxThreed.AxSSPanel pnlPrincipal;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORMNREN));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color50635406134526662993", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text327635406134529553159", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlPrincipal = new AxThreed.AxSSPanel();
            this.cmdImprimir = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdGraficar = new System.Windows.Forms.Button();
            this.pnlTercero = new AxThreed.AxSSPanel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMaxResp = new System.Windows.Forms.Label();
            this.lblFecFin = new System.Windows.Forms.Label();
            this.lblTituloEmp = new System.Windows.Forms.Label();
            this.lblMinResp = new System.Windows.Forms.Label();
            this.lblFechaRes = new System.Windows.Forms.Label();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblRentaMax = new System.Windows.Forms.Label();
            this.lblRentaMin = new System.Windows.Forms.Label();
            this.lblRenPromedio = new System.Windows.Forms.Label();
            this.lblRenPro = new System.Windows.Forms.Label();
            this.lblFecFinR = new System.Windows.Forms.Label();
            this.pnlSecundario = new AxThreed.AxSSPanel();
            this.picCorporativa = new System.Windows.Forms.PictureBox();
            this.imgLogo = new System.Windows.Forms.PictureBox();
            this.lblBanamex = new System.Windows.Forms.Label();
            this.fpRepRenta = new FarPoint.Win.Spread.FpSpread();
            this.fpRepRenta_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPrincipal)).BeginInit();
            this.pnlPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTercero)).BeginInit();
            this.pnlTercero.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSecundario)).BeginInit();
            this.pnlSecundario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCorporativa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpRepRenta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpRepRenta_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.cmdImprimir);
            this.pnlPrincipal.Controls.Add(this.cmdSalir);
            this.pnlPrincipal.Controls.Add(this.cmdGraficar);
            this.pnlPrincipal.Controls.Add(this.pnlTercero);
            this.pnlPrincipal.Controls.Add(this.pnlSecundario);
            this.pnlPrincipal.Location = new System.Drawing.Point(1, 1);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlPrincipal.OcxState")));
            this.pnlPrincipal.Size = new System.Drawing.Size(577, 392);
            this.pnlPrincipal.TabIndex = 0;
            this.pnlPrincipal.Tag = "";
            // 
            // cmdImprimir
            // 
            this.cmdImprimir.BackColor = System.Drawing.SystemColors.Control;
            this.cmdImprimir.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdImprimir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdImprimir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdImprimir.Location = new System.Drawing.Point(154, 356);
            this.cmdImprimir.Name = "cmdImprimir";
            this.cmdImprimir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdImprimir.Size = new System.Drawing.Size(73, 25);
            this.cmdImprimir.TabIndex = 14;
            this.cmdImprimir.Tag = "";
            this.cmdImprimir.Text = "&Imprimir";
            this.cmdImprimir.UseVisualStyleBackColor = false;
            this.cmdImprimir.Click += new System.EventHandler(this.cmdImprimir_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSalir.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSalir.Location = new System.Drawing.Point(336, 356);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSalir.Size = new System.Drawing.Size(73, 25);
            this.cmdSalir.TabIndex = 15;
            this.cmdSalir.Tag = "";
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = false;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdGraficar
            // 
            this.cmdGraficar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdGraficar.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdGraficar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdGraficar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdGraficar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdGraficar.Location = new System.Drawing.Point(246, 356);
            this.cmdGraficar.Name = "cmdGraficar";
            this.cmdGraficar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdGraficar.Size = new System.Drawing.Size(73, 25);
            this.cmdGraficar.TabIndex = 13;
            this.cmdGraficar.Tag = "";
            this.cmdGraficar.Text = "&Graficar";
            this.cmdGraficar.UseVisualStyleBackColor = false;
            this.cmdGraficar.Click += new System.EventHandler(this.cmdGraficar_Click);
            // 
            // pnlTercero
            // 
            this.pnlTercero.Controls.Add(this.lblTitulo);
            this.pnlTercero.Controls.Add(this.lblMaxResp);
            this.pnlTercero.Controls.Add(this.lblFecFin);
            this.pnlTercero.Controls.Add(this.lblTituloEmp);
            this.pnlTercero.Controls.Add(this.lblMinResp);
            this.pnlTercero.Controls.Add(this.lblFechaRes);
            this.pnlTercero.Controls.Add(this.lblFecha);
            this.pnlTercero.Controls.Add(this.lblRentaMax);
            this.pnlTercero.Controls.Add(this.lblRentaMin);
            this.pnlTercero.Controls.Add(this.lblRenPromedio);
            this.pnlTercero.Controls.Add(this.lblRenPro);
            this.pnlTercero.Controls.Add(this.lblFecFinR);
            this.pnlTercero.Location = new System.Drawing.Point(7, 57);
            this.pnlTercero.Name = "pnlTercero";
            this.pnlTercero.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlTercero.OcxState")));
            this.pnlTercero.Size = new System.Drawing.Size(559, 125);
            this.pnlTercero.TabIndex = 5;
            this.pnlTercero.Tag = "";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.Color.Silver;
            this.lblTitulo.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTitulo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 13.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitulo.Location = new System.Drawing.Point(119, 16);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTitulo.Size = new System.Drawing.Size(313, 21);
            this.lblTitulo.TabIndex = 12;
            this.lblTitulo.Tag = "";
            this.lblTitulo.Text = "Rentabilidad para todas las Empresas";
            // 
            // lblMaxResp
            // 
            this.lblMaxResp.BackColor = System.Drawing.Color.Silver;
            this.lblMaxResp.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMaxResp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMaxResp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxResp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMaxResp.Location = new System.Drawing.Point(438, 93);
            this.lblMaxResp.Name = "lblMaxResp";
            this.lblMaxResp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMaxResp.Size = new System.Drawing.Size(89, 17);
            this.lblMaxResp.TabIndex = 11;
            this.lblMaxResp.Tag = "";
            this.lblMaxResp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFecFin
            // 
            this.lblFecFin.AutoSize = true;
            this.lblFecFin.BackColor = System.Drawing.Color.Silver;
            this.lblFecFin.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFecFin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFecFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecFin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFecFin.Location = new System.Drawing.Point(15, 89);
            this.lblFecFin.Name = "lblFecFin";
            this.lblFecFin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFecFin.Size = new System.Drawing.Size(54, 13);
            this.lblFecFin.TabIndex = 17;
            this.lblFecFin.Tag = "";
            this.lblFecFin.Text = "FechaFin:";
            this.lblFecFin.Visible = false;
            // 
            // lblTituloEmp
            // 
            this.lblTituloEmp.AutoSize = true;
            this.lblTituloEmp.BackColor = System.Drawing.Color.Silver;
            this.lblTituloEmp.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblTituloEmp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblTituloEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloEmp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTituloEmp.Location = new System.Drawing.Point(12, 41);
            this.lblTituloEmp.Name = "lblTituloEmp";
            this.lblTituloEmp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTituloEmp.Size = new System.Drawing.Size(0, 13);
            this.lblTituloEmp.TabIndex = 16;
            this.lblTituloEmp.Tag = "";
            this.lblTituloEmp.Visible = false;
            // 
            // lblMinResp
            // 
            this.lblMinResp.BackColor = System.Drawing.Color.Silver;
            this.lblMinResp.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblMinResp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblMinResp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinResp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblMinResp.Location = new System.Drawing.Point(438, 77);
            this.lblMinResp.Name = "lblMinResp";
            this.lblMinResp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblMinResp.Size = new System.Drawing.Size(89, 16);
            this.lblMinResp.TabIndex = 10;
            this.lblMinResp.Tag = "";
            this.lblMinResp.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblFechaRes
            // 
            this.lblFechaRes.BackColor = System.Drawing.Color.Silver;
            this.lblFechaRes.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFechaRes.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFechaRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaRes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFechaRes.Location = new System.Drawing.Point(83, 73);
            this.lblFechaRes.Name = "lblFechaRes";
            this.lblFechaRes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFechaRes.Size = new System.Drawing.Size(88, 15);
            this.lblFechaRes.TabIndex = 7;
            this.lblFechaRes.Tag = "";
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.BackColor = System.Drawing.Color.Silver;
            this.lblFecha.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFecha.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecha.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFecha.Location = new System.Drawing.Point(13, 73);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 6;
            this.lblFecha.Tag = "";
            this.lblFecha.Text = "Fecha:";
            // 
            // lblRentaMax
            // 
            this.lblRentaMax.AutoSize = true;
            this.lblRentaMax.BackColor = System.Drawing.Color.Silver;
            this.lblRentaMax.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblRentaMax.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRentaMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentaMax.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRentaMax.Location = new System.Drawing.Point(317, 94);
            this.lblRentaMax.Name = "lblRentaMax";
            this.lblRentaMax.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRentaMax.Size = new System.Drawing.Size(105, 13);
            this.lblRentaMax.TabIndex = 9;
            this.lblRentaMax.Tag = "";
            this.lblRentaMax.Text = "Rentabilidad Máxima";
            // 
            // lblRentaMin
            // 
            this.lblRentaMin.AutoSize = true;
            this.lblRentaMin.BackColor = System.Drawing.Color.Silver;
            this.lblRentaMin.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblRentaMin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRentaMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRentaMin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRentaMin.Location = new System.Drawing.Point(317, 77);
            this.lblRentaMin.Name = "lblRentaMin";
            this.lblRentaMin.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRentaMin.Size = new System.Drawing.Size(105, 13);
            this.lblRentaMin.TabIndex = 8;
            this.lblRentaMin.Tag = "";
            this.lblRentaMin.Text = "Rentabilidad Minima:";
            // 
            // lblRenPromedio
            // 
            this.lblRenPromedio.BackColor = System.Drawing.Color.Silver;
            this.lblRenPromedio.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblRenPromedio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRenPromedio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenPromedio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRenPromedio.Location = new System.Drawing.Point(436, 63);
            this.lblRenPromedio.Name = "lblRenPromedio";
            this.lblRenPromedio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRenPromedio.Size = new System.Drawing.Size(89, 16);
            this.lblRenPromedio.TabIndex = 20;
            this.lblRenPromedio.Tag = "";
            this.lblRenPromedio.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblRenPro
            // 
            this.lblRenPro.AutoSize = true;
            this.lblRenPro.BackColor = System.Drawing.Color.Silver;
            this.lblRenPro.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblRenPro.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblRenPro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRenPro.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblRenPro.Location = new System.Drawing.Point(316, 63);
            this.lblRenPro.Name = "lblRenPro";
            this.lblRenPro.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblRenPro.Size = new System.Drawing.Size(116, 13);
            this.lblRenPro.TabIndex = 19;
            this.lblRenPro.Tag = "";
            this.lblRenPro.Text = "Rentabilidad Promedio:";
            // 
            // lblFecFinR
            // 
            this.lblFecFinR.BackColor = System.Drawing.Color.Silver;
            this.lblFecFinR.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblFecFinR.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblFecFinR.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFecFinR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblFecFinR.Location = new System.Drawing.Point(83, 90);
            this.lblFecFinR.Name = "lblFecFinR";
            this.lblFecFinR.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblFecFinR.Size = new System.Drawing.Size(88, 13);
            this.lblFecFinR.TabIndex = 18;
            this.lblFecFinR.Tag = "";
            this.lblFecFinR.Visible = false;
            // 
            // pnlSecundario
            // 
            this.pnlSecundario.Controls.Add(this.picCorporativa);
            this.pnlSecundario.Controls.Add(this.imgLogo);
            this.pnlSecundario.Controls.Add(this.lblBanamex);
            this.pnlSecundario.Location = new System.Drawing.Point(8, 5);
            this.pnlSecundario.Name = "pnlSecundario";
            this.pnlSecundario.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlSecundario.OcxState")));
            this.pnlSecundario.Size = new System.Drawing.Size(559, 51);
            this.pnlSecundario.TabIndex = 1;
            this.pnlSecundario.Tag = "";
            // 
            // picCorporativa
            // 
            this.picCorporativa.BackColor = System.Drawing.Color.Gray;
            this.picCorporativa.Cursor = System.Windows.Forms.Cursors.Default;
            this.picCorporativa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.picCorporativa.Image = ((System.Drawing.Image)(resources.GetObject("picCorporativa.Image")));
            this.picCorporativa.Location = new System.Drawing.Point(420, 9);
            this.picCorporativa.Name = "picCorporativa";
            this.picCorporativa.Size = new System.Drawing.Size(131, 31);
            this.picCorporativa.TabIndex = 2;
            this.picCorporativa.TabStop = false;
            this.picCorporativa.Tag = "";
            // 
            // imgLogo
            // 
            this.imgLogo.Cursor = System.Windows.Forms.Cursors.Default;
            this.imgLogo.Image = ((System.Drawing.Image)(resources.GetObject("imgLogo.Image")));
            this.imgLogo.Location = new System.Drawing.Point(11, 4);
            this.imgLogo.Name = "imgLogo";
            this.imgLogo.Size = new System.Drawing.Size(45, 45);
            this.imgLogo.TabIndex = 3;
            this.imgLogo.TabStop = false;
            this.imgLogo.Tag = "";
            // 
            // lblBanamex
            // 
            this.lblBanamex.BackColor = System.Drawing.Color.Silver;
            this.lblBanamex.Cursor = System.Windows.Forms.Cursors.Default;
            this.lblBanamex.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblBanamex.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBanamex.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblBanamex.Location = new System.Drawing.Point(63, 14);
            this.lblBanamex.Name = "lblBanamex";
            this.lblBanamex.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblBanamex.Size = new System.Drawing.Size(118, 24);
            this.lblBanamex.TabIndex = 3;
            this.lblBanamex.Tag = "";
            this.lblBanamex.Text = "Banamex";
            // 
            // fpRepRenta
            // 
            this.fpRepRenta.AccessibleDescription = "";
            this.fpRepRenta.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpRepRenta.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpRepRenta.HorizontalScrollBar.Name = "";
            this.fpRepRenta.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpRepRenta.HorizontalScrollBar.TabIndex = 0;
            this.fpRepRenta.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpRepRenta.Location = new System.Drawing.Point(9, 186);
            this.fpRepRenta.Name = "fpRepRenta";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            this.fpRepRenta.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2});
            this.fpRepRenta.ScrollBarShowMax = false;
            this.fpRepRenta.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpRepRenta_Sheet1});
            this.fpRepRenta.Size = new System.Drawing.Size(557, 160);
            this.fpRepRenta.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpRepRenta.TabIndex = 1;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpRepRenta.TextTipAppearance = tipAppearance1;
            this.fpRepRenta.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpRepRenta.VerticalScrollBar.Name = "";
            this.fpRepRenta.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpRepRenta.VerticalScrollBar.TabIndex = 5;
            this.fpRepRenta.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpRepRenta.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpRepRenta.SetViewportLeftColumn(0, 0, 2);
            this.fpRepRenta.SetActiveViewport(0, 0, -1);
            // 
            // fpRepRenta_Sheet1
            // 
            this.fpRepRenta_Sheet1.Reset();
            this.fpRepRenta_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpRepRenta_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpRepRenta_Sheet1.ColumnCount = 5;
            this.fpRepRenta_Sheet1.RowCount = 8;
            this.fpRepRenta_Sheet1.ColumnFooter.Columns.Default.Resizable = false;
            this.fpRepRenta_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpRepRenta_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpRepRenta_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpRepRenta_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpRepRenta_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpRepRenta_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
            this.fpRepRenta_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpRepRenta_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpRepRenta_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpRepRenta_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpRepRenta_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpRepRenta_Sheet1.Columns.Default.Resizable = false;
            this.fpRepRenta_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpRepRenta_Sheet1.DefaultStyleName = "Text327635406134529553159";
            this.fpRepRenta_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpRepRenta_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpRepRenta_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpRepRenta_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpRepRenta_Sheet1.FrozenColumnCount = 2;
            this.fpRepRenta_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))));
            this.fpRepRenta_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpRepRenta_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpRepRenta_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpRepRenta_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpRepRenta_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpRepRenta_Sheet1.RowHeader.Rows.Default.Resizable = true;
            this.fpRepRenta_Sheet1.RowHeader.Visible = false;
            this.fpRepRenta_Sheet1.Rows.Default.Resizable = true;
            this.fpRepRenta_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpRepRenta_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpRepRenta_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpRepRenta_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpRepRenta_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))));
            this.fpRepRenta_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // CORMNREN
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(584, 396);
            this.Controls.Add(this.fpRepRenta);
            this.Controls.Add(this.pnlPrincipal);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(175, 111);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORMNREN";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Rentabilidad";
            this.Activated += new System.EventHandler(this.CORMNREN_Activated);
            this.Closed += new System.EventHandler(this.CORMNREN_Closed);
            this.Deactivate += new System.EventHandler(this.CORMNREN_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CORMNREN_FormClosing);
            this.Shown += new System.EventHandler(this.CORMNREN_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORMNREN_KeyPress);
            ((System.ComponentModel.ISupportInitialize)(this.pnlPrincipal)).EndInit();
            this.pnlPrincipal.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTercero)).EndInit();
            this.pnlTercero.ResumeLayout(false);
            this.pnlTercero.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlSecundario)).EndInit();
            this.pnlSecundario.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCorporativa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpRepRenta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpRepRenta_Sheet1)).EndInit();
            this.ResumeLayout(false);

	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpRepRenta;
    private FarPoint.Win.Spread.SheetView fpRepRenta_Sheet1;
}
}