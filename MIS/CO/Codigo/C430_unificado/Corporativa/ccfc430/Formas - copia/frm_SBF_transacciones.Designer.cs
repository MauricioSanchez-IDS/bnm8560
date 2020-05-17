using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmSBFtransacciones
	{
	
#region "Upgrade Support "
		private static frmSBFtransacciones m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSBFtransacciones DefInstance
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
		public frmSBFtransacciones():base(){
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
            sprSBFtransacciones = new Softtek.Util.Win.Spread.SpreadWrapper(fpSBFtransacciones);
			InitializeHelp();
		}
	public static frmSBFtransacciones CreateInstance()
	{
			frmSBFtransacciones theInstance = new frmSBFtransacciones();
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
    public Softtek.Util.Win.Spread.SpreadWrapper sprSBFtransacciones;
	private System.ComponentModel.IContainer components;
	public System.Windows.Forms.ToolTip ToolTip1;	
	public  System.Windows.Forms.Button cmdSBFsalir;
	public  System.Windows.Forms.Label Label4;
	public  System.Windows.Forms.Label Label3;
	public  System.Windows.Forms.Label Label2;
	public  System.Windows.Forms.Label Label1;
	public  System.Windows.Forms.GroupBox Frame1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color65635410199256975790", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text301635410199257065795", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("Color559635410199257125799");
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdSBFsalir = new System.Windows.Forms.Button();
            this.Frame1 = new System.Windows.Forms.GroupBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.fpSBFtransacciones = new FarPoint.Win.Spread.FpSpread();
            this.fpSBFtransacciones_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.Frame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpSBFtransacciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSBFtransacciones_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdSBFsalir
            // 
            this.cmdSBFsalir.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSBFsalir.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSBFsalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSBFsalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSBFsalir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSBFsalir.Location = new System.Drawing.Point(312, 224);
            this.cmdSBFsalir.Name = "cmdSBFsalir";
            this.cmdSBFsalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSBFsalir.Size = new System.Drawing.Size(89, 33);
            this.cmdSBFsalir.TabIndex = 1;
            this.cmdSBFsalir.Tag = "";
            this.cmdSBFsalir.Text = "Salir";
            this.cmdSBFsalir.UseVisualStyleBackColor = false;
            this.cmdSBFsalir.Click += new System.EventHandler(this.cmdSBFsalir_Click);
            // 
            // Frame1
            // 
            this.Frame1.BackColor = System.Drawing.SystemColors.Control;
            this.Frame1.Controls.Add(this.Label3);
            this.Frame1.Controls.Add(this.Label4);
            this.Frame1.Controls.Add(this.Label1);
            this.Frame1.Controls.Add(this.Label2);
            this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Frame1.Location = new System.Drawing.Point(120, 8);
            this.Frame1.Name = "Frame1";
            this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Frame1.Size = new System.Drawing.Size(481, 57);
            this.Frame1.TabIndex = 2;
            this.Frame1.TabStop = false;
            this.Frame1.Tag = "";
            // 
            // Label3
            // 
            this.Label3.BackColor = System.Drawing.SystemColors.Control;
            this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label3.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label3.Location = new System.Drawing.Point(80, 32);
            this.Label3.Name = "Label3";
            this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label3.Size = new System.Drawing.Size(105, 17);
            this.Label3.TabIndex = 5;
            this.Label3.Tag = "";
            this.Label3.Text = "No. de Cuenta";
            // 
            // Label4
            // 
            this.Label4.BackColor = System.Drawing.SystemColors.Control;
            this.Label4.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label4.Location = new System.Drawing.Point(216, 32);
            this.Label4.Name = "Label4";
            this.Label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label4.Size = new System.Drawing.Size(257, 17);
            this.Label4.TabIndex = 6;
            this.Label4.Tag = "";
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(80, 16);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(105, 17);
            this.Label1.TabIndex = 3;
            this.Label1.Tag = "";
            this.Label1.Text = "Tarjetahabiente";
            // 
            // Label2
            // 
            this.Label2.BackColor = System.Drawing.SystemColors.Control;
            this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label2.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label2.Location = new System.Drawing.Point(216, 16);
            this.Label2.Name = "Label2";
            this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label2.Size = new System.Drawing.Size(257, 17);
            this.Label2.TabIndex = 4;
            this.Label2.Tag = "";
            // 
            // fpSBFtransacciones
            // 
            this.fpSBFtransacciones.AccessibleDescription = "";
            this.fpSBFtransacciones.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpSBFtransacciones.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpSBFtransacciones.HorizontalScrollBar.Name = "";
            this.fpSBFtransacciones.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpSBFtransacciones.HorizontalScrollBar.TabIndex = 4;
            this.fpSBFtransacciones.Location = new System.Drawing.Point(64, 72);
            this.fpSBFtransacciones.Name = "fpSBFtransacciones";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            namedStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            namedStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            namedStyle3.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtransacciones.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3});
            this.fpSBFtransacciones.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;
            this.fpSBFtransacciones.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSBFtransacciones_Sheet1});
            this.fpSBFtransacciones.Size = new System.Drawing.Size(593, 137);
            this.fpSBFtransacciones.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpSBFtransacciones.TabIndex = 3;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSBFtransacciones.TextTipAppearance = tipAppearance1;
            this.fpSBFtransacciones.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpSBFtransacciones.VerticalScrollBar.Name = "";
            this.fpSBFtransacciones.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpSBFtransacciones.VerticalScrollBar.TabIndex = 5;
            this.fpSBFtransacciones.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // fpSBFtransacciones_Sheet1
            // 
            this.fpSBFtransacciones_Sheet1.Reset();
            this.fpSBFtransacciones_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSBFtransacciones_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSBFtransacciones_Sheet1.ColumnCount = 6;
            this.fpSBFtransacciones_Sheet1.RowCount = 8000;
            this.fpSBFtransacciones_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpSBFtransacciones_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtransacciones_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpSBFtransacciones_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtransacciones_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpSBFtransacciones_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Origen";
            this.fpSBFtransacciones_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "F. Proceso";
            this.fpSBFtransacciones_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "F. Valor";
            this.fpSBFtransacciones_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Cve. Trans";
            this.fpSBFtransacciones_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Desc. Trans";
            this.fpSBFtransacciones_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Importe";
            this.fpSBFtransacciones_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpSBFtransacciones_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtransacciones_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSBFtransacciones_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpSBFtransacciones_Sheet1.Columns.Get(0).Label = "Origen";
            this.fpSBFtransacciones_Sheet1.Columns.Get(0).StyleName = "Color559635410199257125799";
            this.fpSBFtransacciones_Sheet1.Columns.Get(0).Width = 49F;
            this.fpSBFtransacciones_Sheet1.Columns.Get(1).Label = "F. Proceso";
            this.fpSBFtransacciones_Sheet1.Columns.Get(1).Width = 78F;
            this.fpSBFtransacciones_Sheet1.Columns.Get(2).Label = "F. Valor";
            this.fpSBFtransacciones_Sheet1.Columns.Get(2).Width = 75F;
            this.fpSBFtransacciones_Sheet1.Columns.Get(3).Label = "Cve. Trans";
            this.fpSBFtransacciones_Sheet1.Columns.Get(3).Width = 70F;
            this.fpSBFtransacciones_Sheet1.Columns.Get(4).Label = "Desc. Trans";
            this.fpSBFtransacciones_Sheet1.Columns.Get(4).Width = 209F;
            this.fpSBFtransacciones_Sheet1.Columns.Get(5).Label = "Importe";
            this.fpSBFtransacciones_Sheet1.Columns.Get(5).Width = 91F;
            this.fpSBFtransacciones_Sheet1.DefaultStyleName = "Text301635410199257065795";
            this.fpSBFtransacciones_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtransacciones_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpSBFtransacciones_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtransacciones_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpSBFtransacciones_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSBFtransacciones_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtransacciones_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpSBFtransacciones_Sheet1.RowHeader.Visible = false;
            this.fpSBFtransacciones_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtransacciones_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpSBFtransacciones_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmSBFtransacciones
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(687, 263);
            this.Controls.Add(this.fpSBFtransacciones);
            this.Controls.Add(this.cmdSBFsalir);
            this.Controls.Add(this.Frame1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(4, 23);
            this.Name = "frmSBFtransacciones";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "SBF - Nivel Transacción";
            this.Activated += new System.EventHandler(this.frmSBFtransacciones_Activated);
            this.Closed += new System.EventHandler(this.frmSBFtransacciones_Closed);
            this.Frame1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpSBFtransacciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSBFtransacciones_Sheet1)).EndInit();
            this.ResumeLayout(false);

	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpSBFtransacciones;
    private FarPoint.Win.Spread.SheetView fpSBFtransacciones_Sheet1;
}
}