using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class frmIntInicio
	{
	
#region "Upgrade Support "
		private static frmIntInicio m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmIntInicio DefInstance
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
		public frmIntInicio():base(){
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
            sprIntInicio = new Softtek.Util.Win.Spread.SpreadWrapper(fpsIntInicio);
			InitializeHelp();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static frmIntInicio CreateInstance()
	{
			frmIntInicio theInstance = new frmIntInicio();
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
	private System.ComponentModel.IContainer components;
	public System.Windows.Forms.ToolTip ToolTip1;
	public  System.Windows.Forms.Button cmdIntinicio;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color65635410418427629425", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text329635410418427659428", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdIntinicio = new System.Windows.Forms.Button();
            this.fpsIntInicio = new FarPoint.Win.Spread.FpSpread();
            this.fpsIntInicio_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fpsIntInicio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsIntInicio_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdIntinicio
            // 
            this.cmdIntinicio.BackColor = System.Drawing.SystemColors.Control;
            this.cmdIntinicio.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdIntinicio.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdIntinicio.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIntinicio.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdIntinicio.Location = new System.Drawing.Point(616, 234);
            this.cmdIntinicio.Name = "cmdIntinicio";
            this.cmdIntinicio.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdIntinicio.Size = new System.Drawing.Size(73, 25);
            this.cmdIntinicio.TabIndex = 0;
            this.cmdIntinicio.Tag = "";
            this.cmdIntinicio.Text = "Aceptar";
            this.cmdIntinicio.UseVisualStyleBackColor = false;
            this.cmdIntinicio.Click += new System.EventHandler(this.cmdIntinicio_Click);
            // 
            // fpsIntInicio
            // 
            this.fpsIntInicio.AccessibleDescription = "";
            this.fpsIntInicio.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpsIntInicio.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsIntInicio.HorizontalScrollBar.Name = "";
            this.fpsIntInicio.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpsIntInicio.HorizontalScrollBar.TabIndex = 8;
            this.fpsIntInicio.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsIntInicio.Location = new System.Drawing.Point(0, 0);
            this.fpsIntInicio.Name = "fpsIntInicio";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            this.fpsIntInicio.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2});
            this.fpsIntInicio.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpsIntInicio_Sheet1});
            this.fpsIntInicio.Size = new System.Drawing.Size(721, 227);
            this.fpsIntInicio.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpsIntInicio.TabIndex = 2;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpsIntInicio.TextTipAppearance = tipAppearance1;
            this.fpsIntInicio.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsIntInicio.VerticalScrollBar.Name = "";
            this.fpsIntInicio.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpsIntInicio.VerticalScrollBar.TabIndex = 9;
            this.fpsIntInicio.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpsIntInicio.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // fpsIntInicio_Sheet1
            // 
            this.fpsIntInicio_Sheet1.Reset();
            this.fpsIntInicio_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsIntInicio_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsIntInicio_Sheet1.ColumnCount = 4;
            this.fpsIntInicio_Sheet1.RowCount = 2;
            this.fpsIntInicio_Sheet1.ColumnFooter.Columns.Default.Resizable = false;
            this.fpsIntInicio_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsIntInicio_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsIntInicio_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpsIntInicio_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsIntInicio_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsIntInicio_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "IDEmpresa";
            this.fpsIntInicio_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Empresa";
            this.fpsIntInicio_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Pendientes por Enviar";
            this.fpsIntInicio_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "No Transmitidos";
            this.fpsIntInicio_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
            this.fpsIntInicio_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsIntInicio_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsIntInicio_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpsIntInicio_Sheet1.Columns.Default.Resizable = false;
            this.fpsIntInicio_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsIntInicio_Sheet1.Columns.Get(0).Label = "IDEmpresa";
            this.fpsIntInicio_Sheet1.Columns.Get(0).Width = 140F;
            this.fpsIntInicio_Sheet1.Columns.Get(1).Label = "Empresa";
            this.fpsIntInicio_Sheet1.Columns.Get(1).Width = 442F;
            this.fpsIntInicio_Sheet1.Columns.Get(2).Label = "Pendientes por Enviar";
            this.fpsIntInicio_Sheet1.Columns.Get(2).Width = 136F;
            this.fpsIntInicio_Sheet1.Columns.Get(3).Label = "No Transmitidos";
            this.fpsIntInicio_Sheet1.Columns.Get(3).Visible = false;
            this.fpsIntInicio_Sheet1.Columns.Get(3).Width = 0F;
            this.fpsIntInicio_Sheet1.DefaultStyleName = "Text329635410418427659428";
            this.fpsIntInicio_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsIntInicio_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpsIntInicio_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsIntInicio_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpsIntInicio_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.fpsIntInicio_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsIntInicio_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsIntInicio_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpsIntInicio_Sheet1.RowHeader.Rows.Default.Resizable = false;
            this.fpsIntInicio_Sheet1.RowHeader.Visible = false;
            this.fpsIntInicio_Sheet1.Rows.Default.Resizable = false;
            this.fpsIntInicio_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsIntInicio_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsIntInicio_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmIntInicio
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(723, 272);
            this.Controls.Add(this.fpsIntInicio);
            this.Controls.Add(this.cmdIntinicio);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(37, 146);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIntInicio";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Intelar Inicio";
            this.Closed += new System.EventHandler(this.frmIntInicio_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.fpsIntInicio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsIntInicio_Sheet1)).EndInit();
            this.ResumeLayout(false);

	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpsIntInicio;
    private FarPoint.Win.Spread.SheetView fpsIntInicio_Sheet1;
    public Softtek.Util.Win.Spread.SpreadWrapper sprIntInicio;

    }
}