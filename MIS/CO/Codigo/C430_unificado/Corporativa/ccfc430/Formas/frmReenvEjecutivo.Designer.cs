using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmReenvEjecutivo
	{
	
#region "Upgrade Support "
		private static frmReenvEjecutivo m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmReenvEjecutivo DefInstance
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
		public frmReenvEjecutivo():base(){
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
            gridRegistros = new Softtek.Util.Win.Spread.SpreadWrapper(fpgridRegistros);
			InitializeHelp();
		}
	public static frmReenvEjecutivo CreateInstance()
	{
			frmReenvEjecutivo theInstance = new frmReenvEjecutivo();
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
    public Softtek.Util.Win.Spread.SpreadWrapper gridRegistros;
	private System.ComponentModel.IContainer components;
	public System.Windows.Forms.ToolTip ToolTip1;	
	public  System.Windows.Forms.Button cmdConsMasivo;
	public  System.Windows.Forms.Button cmdConsIndividual;
	public  System.Windows.Forms.Button cmdSalir;
	public  System.Windows.Forms.Button cmdReenvio;
	public  AxThreed.AxSSPanel sspnlPorcentaje;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReenvEjecutivo));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color65635410232790763813", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text292635410232790843818", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdConsMasivo = new System.Windows.Forms.Button();
            this.cmdConsIndividual = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdReenvio = new System.Windows.Forms.Button();
            this.sspnlPorcentaje = new AxThreed.AxSSPanel();
            this.fpgridRegistros = new FarPoint.Win.Spread.FpSpread();
            this.fpgridRegistros_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.sspnlPorcentaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpgridRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpgridRegistros_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdConsMasivo
            // 
            this.cmdConsMasivo.BackColor = System.Drawing.SystemColors.Control;
            this.cmdConsMasivo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdConsMasivo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdConsMasivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsMasivo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdConsMasivo.Location = new System.Drawing.Point(576, 40);
            this.cmdConsMasivo.Name = "cmdConsMasivo";
            this.cmdConsMasivo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdConsMasivo.Size = new System.Drawing.Size(113, 25);
            this.cmdConsMasivo.TabIndex = 5;
            this.cmdConsMasivo.Tag = "";
            this.cmdConsMasivo.Text = "Masivo";
            this.cmdConsMasivo.UseVisualStyleBackColor = false;
            this.cmdConsMasivo.Click += new System.EventHandler(this.cmdConsMasivo_Click);
            // 
            // cmdConsIndividual
            // 
            this.cmdConsIndividual.BackColor = System.Drawing.SystemColors.Control;
            this.cmdConsIndividual.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdConsIndividual.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdConsIndividual.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsIndividual.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdConsIndividual.Location = new System.Drawing.Point(576, 8);
            this.cmdConsIndividual.Name = "cmdConsIndividual";
            this.cmdConsIndividual.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdConsIndividual.Size = new System.Drawing.Size(113, 25);
            this.cmdConsIndividual.TabIndex = 4;
            this.cmdConsIndividual.Tag = "";
            this.cmdConsIndividual.Text = "Individual";
            this.cmdConsIndividual.UseVisualStyleBackColor = false;
            this.cmdConsIndividual.Click += new System.EventHandler(this.cmdConsIndividual_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSalir.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSalir.Location = new System.Drawing.Point(576, 240);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSalir.Size = new System.Drawing.Size(113, 25);
            this.cmdSalir.TabIndex = 1;
            this.cmdSalir.Tag = "";
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = false;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // cmdReenvio
            // 
            this.cmdReenvio.BackColor = System.Drawing.SystemColors.Control;
            this.cmdReenvio.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdReenvio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdReenvio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdReenvio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdReenvio.Location = new System.Drawing.Point(576, 72);
            this.cmdReenvio.Name = "cmdReenvio";
            this.cmdReenvio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdReenvio.Size = new System.Drawing.Size(113, 25);
            this.cmdReenvio.TabIndex = 0;
            this.cmdReenvio.Tag = "";
            this.cmdReenvio.Text = "&Reenvio";
            this.cmdReenvio.UseVisualStyleBackColor = false;
            this.cmdReenvio.Click += new System.EventHandler(this.cmdReenvio_Click);
            // 
            // sspnlPorcentaje
            // 
            this.sspnlPorcentaje.Location = new System.Drawing.Point(8, 272);
            this.sspnlPorcentaje.Name = "sspnlPorcentaje";
            this.sspnlPorcentaje.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("sspnlPorcentaje.OcxState")));
            this.sspnlPorcentaje.Size = new System.Drawing.Size(681, 25);
            this.sspnlPorcentaje.TabIndex = 3;
            this.sspnlPorcentaje.Tag = "";
            // 
            // fpgridRegistros
            // 
            this.fpgridRegistros.AccessibleDescription = "";
            this.fpgridRegistros.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpgridRegistros.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpgridRegistros.HorizontalScrollBar.Name = "";
            this.fpgridRegistros.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpgridRegistros.HorizontalScrollBar.TabIndex = 4;
            this.fpgridRegistros.Location = new System.Drawing.Point(8, 8);
            this.fpgridRegistros.Name = "fpgridRegistros";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            this.fpgridRegistros.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2});
            this.fpgridRegistros.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpgridRegistros_Sheet1});
            this.fpgridRegistros.Size = new System.Drawing.Size(561, 257);
            this.fpgridRegistros.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpgridRegistros.TabIndex = 6;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpgridRegistros.TextTipAppearance = tipAppearance1;
            this.fpgridRegistros.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpgridRegistros.VerticalScrollBar.Name = "";
            this.fpgridRegistros.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpgridRegistros.VerticalScrollBar.TabIndex = 5;
            this.fpgridRegistros.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // fpgridRegistros_Sheet1
            // 
            this.fpgridRegistros_Sheet1.Reset();
            this.fpgridRegistros_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpgridRegistros_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpgridRegistros_Sheet1.ColumnCount = 5;
            this.fpgridRegistros_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpgridRegistros_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpgridRegistros_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpgridRegistros_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpgridRegistros_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpgridRegistros_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Prefijo";
            this.fpgridRegistros_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Banco";
            this.fpgridRegistros_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Empresa";
            this.fpgridRegistros_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Nombre";
            this.fpgridRegistros_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Estatus";
            this.fpgridRegistros_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpgridRegistros_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpgridRegistros_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpgridRegistros_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpgridRegistros_Sheet1.Columns.Get(4).Label = "Estatus";
            this.fpgridRegistros_Sheet1.Columns.Get(4).Width = 64F;
            this.fpgridRegistros_Sheet1.DefaultStyleName = "Text292635410232790843818";
            this.fpgridRegistros_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpgridRegistros_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpgridRegistros_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpgridRegistros_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpgridRegistros_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpgridRegistros_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpgridRegistros_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpgridRegistros_Sheet1.RowHeader.Visible = false;
            this.fpgridRegistros_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpgridRegistros_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpgridRegistros_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmReenvEjecutivo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(696, 299);
            this.Controls.Add(this.fpgridRegistros);
            this.Controls.Add(this.cmdConsMasivo);
            this.Controls.Add(this.cmdReenvio);
            this.Controls.Add(this.sspnlPorcentaje);
            this.Controls.Add(this.cmdConsIndividual);
            this.Controls.Add(this.cmdSalir);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(136, 275);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReenvEjecutivo";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Reenvio Ejecutivos";
            this.Activated += new System.EventHandler(this.frmReenvEjecutivo_Activated);
            this.Closed += new System.EventHandler(this.frmReenvEjecutivo_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.sspnlPorcentaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpgridRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpgridRegistros_Sheet1)).EndInit();
            this.ResumeLayout(false);

	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpgridRegistros;
    private FarPoint.Win.Spread.SheetView fpgridRegistros_Sheet1;
}
}