using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frm_SBF_tarjetahab
	{
	
#region "Upgrade Support "
		private static frm_SBF_tarjetahab m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_SBF_tarjetahab DefInstance
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
		public frm_SBF_tarjetahab():base(){
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
            sprSBFtarjetahab = new Softtek.Util.Win.Spread.SpreadWrapper(fpSBFtarjetahab);
			InitializeHelp();
			Form_Initialize_Renamed();
		}
	public static frm_SBF_tarjetahab CreateInstance()
	{
			frm_SBF_tarjetahab theInstance = new frm_SBF_tarjetahab();
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
    public Softtek.Util.Win.Spread.SpreadWrapper sprSBFtarjetahab;
	private System.ComponentModel.IContainer components;
	public System.Windows.Forms.ToolTip ToolTip1;	
	public  System.Windows.Forms.Button cmdConsTran;
	public  System.Windows.Forms.Button cmdSBFsalir;
	public  System.Windows.Forms.Label Label1;
	private Artinsoft.VB6.Gui.CommandButtonHelper CommandButtonHelper1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SBF_tarjetahab));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color65635410257848957060", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text301635410257849657100", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);            
            this.cmdConsTran = new System.Windows.Forms.Button();
            this.cmdSBFsalir = new System.Windows.Forms.Button();
            this.Label1 = new System.Windows.Forms.Label();
            this.CommandButtonHelper1 = new Artinsoft.VB6.Gui.CommandButtonHelper(this.components);
            this.fpSBFtarjetahab = new FarPoint.Win.Spread.FpSpread();
            this.fpSBFtarjetahab_Sheet1 = new FarPoint.Win.Spread.SheetView();            
            ((System.ComponentModel.ISupportInitialize)(this.CommandButtonHelper1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSBFtarjetahab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSBFtarjetahab_Sheet1)).BeginInit();
            this.SuspendLayout();
           
            // 
            // cmdConsTran
            // 
            this.cmdConsTran.BackColor = System.Drawing.SystemColors.Control;
            this.CommandButtonHelper1.SetCorrectEventsBehavior(this.cmdConsTran, true);
            this.cmdConsTran.Cursor = System.Windows.Forms.Cursors.Default;
            this.CommandButtonHelper1.SetDisabledPicture(this.cmdConsTran, null);
            this.CommandButtonHelper1.SetDownPicture(this.cmdConsTran, null);
            this.cmdConsTran.Enabled = false;
            this.cmdConsTran.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsTran.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdConsTran.Location = new System.Drawing.Point(264, 192);
            this.CommandButtonHelper1.SetMaskColor(this.cmdConsTran, System.Drawing.Color.Silver);
            this.cmdConsTran.Name = "cmdConsTran";
            this.cmdConsTran.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdConsTran.Size = new System.Drawing.Size(97, 33);
            this.CommandButtonHelper1.SetStyle(this.cmdConsTran, 1);
            this.cmdConsTran.TabIndex = 2;
            this.cmdConsTran.Tag = "";
            this.cmdConsTran.Text = "Consultar Transacciones";
            this.cmdConsTran.UseVisualStyleBackColor = false;
            this.cmdConsTran.Click += new System.EventHandler(this.cmdConsTran_Click);
            // 
            // cmdSBFsalir
            // 
            this.cmdSBFsalir.BackColor = System.Drawing.SystemColors.Control;
            this.CommandButtonHelper1.SetCorrectEventsBehavior(this.cmdSBFsalir, true);
            this.cmdSBFsalir.Cursor = System.Windows.Forms.Cursors.Default;
            this.CommandButtonHelper1.SetDisabledPicture(this.cmdSBFsalir, null);
            this.CommandButtonHelper1.SetDownPicture(this.cmdSBFsalir, null);
            this.cmdSBFsalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSBFsalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSBFsalir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSBFsalir.Location = new System.Drawing.Point(400, 192);
            this.CommandButtonHelper1.SetMaskColor(this.cmdSBFsalir, System.Drawing.Color.Silver);
            this.cmdSBFsalir.Name = "cmdSBFsalir";
            this.cmdSBFsalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSBFsalir.Size = new System.Drawing.Size(97, 33);
            this.CommandButtonHelper1.SetStyle(this.cmdSBFsalir, 0);
            this.cmdSBFsalir.TabIndex = 1;
            this.cmdSBFsalir.Tag = "";
            this.cmdSBFsalir.Text = "Salir";
            this.cmdSBFsalir.UseVisualStyleBackColor = false;
            this.cmdSBFsalir.Click += new System.EventHandler(this.cmdSBFsalir_Click);
            // 
            // Label1
            // 
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(8, 184);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(249, 25);
            this.Label1.TabIndex = 3;
            this.Label1.Tag = "";
            this.Label1.Visible = false;
            // 
            // fpSBFtarjetahab
            // 
            this.fpSBFtarjetahab.AccessibleDescription = "";
            this.fpSBFtarjetahab.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpSBFtarjetahab.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpSBFtarjetahab.HorizontalScrollBar.Name = "";
            this.fpSBFtarjetahab.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpSBFtarjetahab.HorizontalScrollBar.TabIndex = 6;
            this.fpSBFtarjetahab.Location = new System.Drawing.Point(16, 24);
            this.fpSBFtarjetahab.Name = "fpSBFtarjetahab";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            this.fpSBFtarjetahab.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2});
            this.fpSBFtarjetahab.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;
            this.fpSBFtarjetahab.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSBFtarjetahab_Sheet1});
            this.fpSBFtarjetahab.Size = new System.Drawing.Size(697, 153);
            this.fpSBFtarjetahab.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpSBFtarjetahab.TabIndex = 4;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSBFtarjetahab.TextTipAppearance = tipAppearance1;
            this.fpSBFtarjetahab.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpSBFtarjetahab.VerticalScrollBar.Name = "";
            this.fpSBFtarjetahab.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpSBFtarjetahab.VerticalScrollBar.TabIndex = 7;
            this.fpSBFtarjetahab.VisualStyles = FarPoint.Win.VisualStyles.Off;
            this.fpSBFtarjetahab.Click += new System.EventHandler(this.fpSBFtarjetahab_Click);
            // 
            // fpSBFtarjetahab_Sheet1
            // 
            this.fpSBFtarjetahab_Sheet1.Reset();
            this.fpSBFtarjetahab_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSBFtarjetahab_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSBFtarjetahab_Sheet1.ColumnCount = 5;
            this.fpSBFtarjetahab_Sheet1.RowCount = 1000;
            this.fpSBFtarjetahab_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpSBFtarjetahab_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtarjetahab_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpSBFtarjetahab_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtarjetahab_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpSBFtarjetahab_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Origen";
            this.fpSBFtarjetahab_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Cta. Eje";
            this.fpSBFtarjetahab_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Nombre";
            this.fpSBFtarjetahab_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "S. Anterior";
            this.fpSBFtarjetahab_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "S. Actual";
            this.fpSBFtarjetahab_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpSBFtarjetahab_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtarjetahab_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSBFtarjetahab_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpSBFtarjetahab_Sheet1.Columns.Get(0).Label = "Origen";
            this.fpSBFtarjetahab_Sheet1.Columns.Get(0).Width = 44F;
            this.fpSBFtarjetahab_Sheet1.Columns.Get(1).Label = "Cta. Eje";
            this.fpSBFtarjetahab_Sheet1.Columns.Get(1).Width = 139F;
            this.fpSBFtarjetahab_Sheet1.Columns.Get(2).Label = "Nombre";
            this.fpSBFtarjetahab_Sheet1.Columns.Get(2).Width = 272F;
            this.fpSBFtarjetahab_Sheet1.Columns.Get(3).Label = "S. Anterior";
            this.fpSBFtarjetahab_Sheet1.Columns.Get(3).Width = 116F;
            this.fpSBFtarjetahab_Sheet1.Columns.Get(4).Label = "S. Actual";
            this.fpSBFtarjetahab_Sheet1.Columns.Get(4).Width = 109F;
            this.fpSBFtarjetahab_Sheet1.DefaultStyleName = "Text301635410257849657100";
            this.fpSBFtarjetahab_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtarjetahab_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpSBFtarjetahab_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtarjetahab_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpSBFtarjetahab_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSBFtarjetahab_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtarjetahab_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpSBFtarjetahab_Sheet1.RowHeader.Visible = false;
            this.fpSBFtarjetahab_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSBFtarjetahab_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpSBFtarjetahab_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frm_SBF_tarjetahab
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(726, 238);
            this.Controls.Add(this.fpSBFtarjetahab);            
            this.Controls.Add(this.cmdSBFsalir);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.cmdConsTran);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(4, 23);
            this.Name = "frm_SBF_tarjetahab";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "SBF - Nivel Tarjetahabiente";
            this.Activated += new System.EventHandler(this.frm_SBF_tarjetahab_Activated);
            this.Closed += new System.EventHandler(this.frm_SBF_tarjetahab_Closed);            
            ((System.ComponentModel.ISupportInitialize)(this.CommandButtonHelper1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSBFtarjetahab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSBFtarjetahab_Sheet1)).EndInit();
            this.ResumeLayout(false);

	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpSBFtarjetahab;
    private FarPoint.Win.Spread.SheetView fpSBFtarjetahab_Sheet1;
}
}