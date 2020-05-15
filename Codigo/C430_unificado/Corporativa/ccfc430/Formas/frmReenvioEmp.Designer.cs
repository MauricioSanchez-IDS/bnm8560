using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmReenvioEmp
	{
	
#region "Upgrade Support "
		private static frmReenvioEmp m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmReenvioEmp DefInstance
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
		public frmReenvioEmp():base(){
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
            vspmEmpresas = new Softtek.Util.Win.Spread.SpreadWrapper(fpvspmEmpresas);
			InitializeHelp();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static frmReenvioEmp CreateInstance()
	{
			frmReenvioEmp theInstance = new frmReenvioEmp();
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
    public Softtek.Util.Win.Spread.SpreadWrapper vspmEmpresas;
	private System.ComponentModel.IContainer components;
	public System.Windows.Forms.ToolTip ToolTip1;	
	public  AxThreed.AxSSPanel sspnlPorcentaje;
	public  System.Windows.Forms.Button cmdSalir;
	public  System.Windows.Forms.Button cmdReenvio;
	public  System.Windows.Forms.Button cmdConsIndividual;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReenvioEmp));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color65635410239021840210", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text292635410239021850211", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.sspnlPorcentaje = new AxThreed.AxSSPanel();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdReenvio = new System.Windows.Forms.Button();
            this.cmdConsIndividual = new System.Windows.Forms.Button();
            this.fpvspmEmpresas = new FarPoint.Win.Spread.FpSpread();
            this.fpvspmEmpresas_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.sspnlPorcentaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpvspmEmpresas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpvspmEmpresas_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // sspnlPorcentaje
            // 
            this.sspnlPorcentaje.Location = new System.Drawing.Point(8, 264);
            this.sspnlPorcentaje.Name = "sspnlPorcentaje";
            this.sspnlPorcentaje.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("sspnlPorcentaje.OcxState")));
            this.sspnlPorcentaje.Size = new System.Drawing.Size(681, 25);
            this.sspnlPorcentaje.TabIndex = 4;
            this.sspnlPorcentaje.Tag = "";
            // 
            // cmdSalir
            // 
            this.cmdSalir.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSalir.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSalir.Location = new System.Drawing.Point(576, 232);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSalir.Size = new System.Drawing.Size(113, 25);
            this.cmdSalir.TabIndex = 3;
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
            this.cmdReenvio.Location = new System.Drawing.Point(576, 40);
            this.cmdReenvio.Name = "cmdReenvio";
            this.cmdReenvio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdReenvio.Size = new System.Drawing.Size(113, 25);
            this.cmdReenvio.TabIndex = 1;
            this.cmdReenvio.Tag = "";
            this.cmdReenvio.Text = "&Reenvio";
            this.cmdReenvio.UseVisualStyleBackColor = false;
            this.cmdReenvio.Click += new System.EventHandler(this.cmdReenvio_Click);
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
            this.cmdConsIndividual.TabIndex = 0;
            this.cmdConsIndividual.Tag = "";
            this.cmdConsIndividual.Text = "&Individual";
            this.cmdConsIndividual.UseVisualStyleBackColor = false;
            this.cmdConsIndividual.Click += new System.EventHandler(this.cmdConsIndividual_Click);
            // 
            // fpvspmEmpresas
            // 
            this.fpvspmEmpresas.AccessibleDescription = "fpvspmEmpresas, Sheet1, Row 0, Column 0, ";
            this.fpvspmEmpresas.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpvspmEmpresas.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpvspmEmpresas.HorizontalScrollBar.Name = "";
            this.fpvspmEmpresas.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpvspmEmpresas.HorizontalScrollBar.TabIndex = 10;
            this.fpvspmEmpresas.Location = new System.Drawing.Point(8, 8);
            this.fpvspmEmpresas.Name = "fpvspmEmpresas";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            this.fpvspmEmpresas.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2});
            this.fpvspmEmpresas.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpvspmEmpresas_Sheet1});
            this.fpvspmEmpresas.Size = new System.Drawing.Size(561, 249);
            this.fpvspmEmpresas.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpvspmEmpresas.TabIndex = 5;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpvspmEmpresas.TextTipAppearance = tipAppearance1;
            this.fpvspmEmpresas.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpvspmEmpresas.VerticalScrollBar.Name = "";
            this.fpvspmEmpresas.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpvspmEmpresas.VerticalScrollBar.TabIndex = 11;
            this.fpvspmEmpresas.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // fpvspmEmpresas_Sheet1
            // 
            this.fpvspmEmpresas_Sheet1.Reset();
            this.fpvspmEmpresas_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpvspmEmpresas_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpvspmEmpresas_Sheet1.ColumnCount = 5;
            this.fpvspmEmpresas_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpvspmEmpresas_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpvspmEmpresas_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpvspmEmpresas_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpvspmEmpresas_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpvspmEmpresas_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Prefijo";
            this.fpvspmEmpresas_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Banco";
            this.fpvspmEmpresas_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Numero";
            this.fpvspmEmpresas_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Empresa";
            this.fpvspmEmpresas_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Status";
            this.fpvspmEmpresas_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpvspmEmpresas_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpvspmEmpresas_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpvspmEmpresas_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpvspmEmpresas_Sheet1.Columns.Get(3).Label = "Empresa";
            this.fpvspmEmpresas_Sheet1.Columns.Get(3).Width = 64F;
            this.fpvspmEmpresas_Sheet1.DefaultStyleName = "Text292635410239021850211";
            this.fpvspmEmpresas_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpvspmEmpresas_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpvspmEmpresas_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpvspmEmpresas_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpvspmEmpresas_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpvspmEmpresas_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpvspmEmpresas_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpvspmEmpresas_Sheet1.RowHeader.Visible = false;
            this.fpvspmEmpresas_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpvspmEmpresas_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpvspmEmpresas_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmReenvioEmp
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(694, 291);
            this.Controls.Add(this.fpvspmEmpresas);
            this.Controls.Add(this.cmdReenvio);
            this.Controls.Add(this.cmdConsIndividual);
            this.Controls.Add(this.sspnlPorcentaje);
            this.Controls.Add(this.cmdSalir);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(3, 22);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReenvioEmp";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Reenvio de Empresas";
            this.Closed += new System.EventHandler(this.frmReenvioEmp_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.sspnlPorcentaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpvspmEmpresas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpvspmEmpresas_Sheet1)).EndInit();
            this.ResumeLayout(false);

	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpvspmEmpresas;
    private FarPoint.Win.Spread.SheetView fpvspmEmpresas_Sheet1;
}
}