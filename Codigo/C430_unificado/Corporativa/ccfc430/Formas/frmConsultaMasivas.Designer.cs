using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmConsultaMasivas
	{
	
#region "Upgrade Support "
		private static frmConsultaMasivas m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmConsultaMasivas DefInstance
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
		public frmConsultaMasivas():base(){
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
            sprConsAltasMasivas = new Softtek.Util.Win.Spread.SpreadWrapper(fpsConsAltasMasivas);
			InitializeHelp();
		}
	public static frmConsultaMasivas CreateInstance()
	{
			frmConsultaMasivas theInstance = new frmConsultaMasivas();
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
    public Softtek.Util.Win.Spread.SpreadWrapper sprConsAltasMasivas;
	private System.ComponentModel.IContainer components;
	public System.Windows.Forms.ToolTip ToolTip1;	
	public  System.Windows.Forms.Button cmdSalir;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmConsultaMasivas));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("BorderEx73635410209962728124", "DataAreaDefault");
            FarPoint.Win.ComplexBorder complexBorder1 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))));
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text368635410209962768126", "DataAreaDefault");
            FarPoint.Win.ComplexBorder complexBorder2 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))));
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("BorderEx830635410209962798128");
            FarPoint.Win.ComplexBorder complexBorder3 = new FarPoint.Win.ComplexBorder(new FarPoint.Win.ComplexBorderSide(System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))))));
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);            
            this.cmdSalir = new System.Windows.Forms.Button();
            this.fpsConsAltasMasivas = new FarPoint.Win.Spread.FpSpread();
            this.fpsConsAltasMasivas_Sheet1 = new FarPoint.Win.Spread.SheetView();            
            ((System.ComponentModel.ISupportInitialize)(this.fpsConsAltasMasivas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsConsAltasMasivas_Sheet1)).BeginInit();
            this.SuspendLayout();
            
            // 
            // cmdSalir
            // 
            this.cmdSalir.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSalir.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSalir.Location = new System.Drawing.Point(280, 280);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSalir.Size = new System.Drawing.Size(129, 41);
            this.cmdSalir.TabIndex = 1;
            this.cmdSalir.Tag = "";
            this.cmdSalir.Text = "Salir Consulta";
            this.cmdSalir.UseVisualStyleBackColor = false;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // fpsConsAltasMasivas
            // 
            this.fpsConsAltasMasivas.AccessibleDescription = "";
            this.fpsConsAltasMasivas.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpsConsAltasMasivas.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsConsAltasMasivas.HorizontalScrollBar.Name = "";
            this.fpsConsAltasMasivas.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpsConsAltasMasivas.HorizontalScrollBar.TabIndex = 8;
            this.fpsConsAltasMasivas.Location = new System.Drawing.Point(0, 0);
            this.fpsConsAltasMasivas.Name = "fpsConsAltasMasivas";
            namedStyle1.Border = complexBorder1;
            namedStyle1.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            namedStyle1.Locked = true;
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            namedStyle2.Border = complexBorder2;
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            namedStyle2.Locked = true;
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            namedStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            namedStyle3.Border = complexBorder3;
            namedStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            namedStyle3.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsConsAltasMasivas.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3});
            this.fpsConsAltasMasivas.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpsConsAltasMasivas_Sheet1});
            this.fpsConsAltasMasivas.Size = new System.Drawing.Size(697, 265);
            this.fpsConsAltasMasivas.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpsConsAltasMasivas.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpsConsAltasMasivas.TextTipAppearance = tipAppearance1;
            this.fpsConsAltasMasivas.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsConsAltasMasivas.VerticalScrollBar.Name = "";
            this.fpsConsAltasMasivas.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpsConsAltasMasivas.VerticalScrollBar.TabIndex = 9;
            this.fpsConsAltasMasivas.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // fpsConsAltasMasivas_Sheet1
            // 
            this.fpsConsAltasMasivas_Sheet1.Reset();
            this.fpsConsAltasMasivas_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsConsAltasMasivas_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsConsAltasMasivas_Sheet1.ColumnCount = 5;
            this.fpsConsAltasMasivas_Sheet1.RowCount = 0;
            this.fpsConsAltasMasivas_Sheet1.ActiveColumnIndex = -1;
            this.fpsConsAltasMasivas_Sheet1.ActiveRowIndex = -1;
            this.fpsConsAltasMasivas_Sheet1.ColumnFooter.Columns.Default.Resizable = false;
            this.fpsConsAltasMasivas_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsConsAltasMasivas_Sheet1.ColumnFooter.Columns.Default.Width = 64F;
            this.fpsConsAltasMasivas_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsConsAltasMasivas_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpsConsAltasMasivas_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsConsAltasMasivas_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsConsAltasMasivas_Sheet1.ColumnHeader.Cells.Get(0, 0).StyleName = "BorderEx830635410209962798128";
            this.fpsConsAltasMasivas_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Prefijo";
            this.fpsConsAltasMasivas_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Banco";
            this.fpsConsAltasMasivas_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Empresa";
            this.fpsConsAltasMasivas_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Nombre";
            this.fpsConsAltasMasivas_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "R.F.C.";
            this.fpsConsAltasMasivas_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
            this.fpsConsAltasMasivas_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsConsAltasMasivas_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsConsAltasMasivas_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpsConsAltasMasivas_Sheet1.Columns.Default.Resizable = false;
            this.fpsConsAltasMasivas_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsConsAltasMasivas_Sheet1.Columns.Default.Width = 64F;
            this.fpsConsAltasMasivas_Sheet1.Columns.Get(3).Label = "Nombre";
            this.fpsConsAltasMasivas_Sheet1.Columns.Get(3).Width = 275F;
            this.fpsConsAltasMasivas_Sheet1.Columns.Get(4).Label = "R.F.C.";
            this.fpsConsAltasMasivas_Sheet1.Columns.Get(4).Width = 193F;
            this.fpsConsAltasMasivas_Sheet1.DefaultStyleName = "Text368635410209962768126";
            this.fpsConsAltasMasivas_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsConsAltasMasivas_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpsConsAltasMasivas_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsConsAltasMasivas_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpsConsAltasMasivas_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsConsAltasMasivas_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsConsAltasMasivas_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpsConsAltasMasivas_Sheet1.RowHeader.Rows.Default.Resizable = true;
            this.fpsConsAltasMasivas_Sheet1.Rows.Default.Resizable = true;
            this.fpsConsAltasMasivas_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsConsAltasMasivas_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsConsAltasMasivas_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmConsultaMasivas
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(698, 333);
            this.Controls.Add(this.fpsConsAltasMasivas);            
            this.Controls.Add(this.cmdSalir);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(41, 131);
            this.Name = "frmConsultaMasivas";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Consulta Altas Masivas";
            this.Activated += new System.EventHandler(this.frmConsultaMasivas_Activated);
            this.Closed += new System.EventHandler(this.frmConsultaMasivas_Closed);            
            ((System.ComponentModel.ISupportInitialize)(this.fpsConsAltasMasivas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsConsAltasMasivas_Sheet1)).EndInit();
            this.ResumeLayout(false);

	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpsConsAltasMasivas;
    private FarPoint.Win.Spread.SheetView fpsConsAltasMasivas_Sheet1;
}
}