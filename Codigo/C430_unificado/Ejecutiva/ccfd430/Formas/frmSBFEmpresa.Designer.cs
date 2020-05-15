using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class frmSBFEmpresa
	{
	
#region "Upgrade Support "
		private static frmSBFEmpresa m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmSBFEmpresa DefInstance
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
		public frmSBFEmpresa():base(){
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
			InitializeLBL_FECHA();
			Form_Initialize_Renamed();
		}
	public static frmSBFEmpresa CreateInstance()
	{
			frmSBFEmpresa theInstance = new frmSBFEmpresa();
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
	public  Softtek.Util.Win.Spread.SpreadWrapper sprSBFEmpresa1;
	public  System.Windows.Forms.Button cmdConsultaTarj;
	public  System.Windows.Forms.Button cmdSBFerror;
	public  System.Windows.Forms.Button cmdSBFvobo;
	public  System.Windows.Forms.Button cmdSBFsalir;
	private  System.Windows.Forms.Label _LBL_FECHA_3;
	private  System.Windows.Forms.Label _LBL_FECHA_2;
	private  System.Windows.Forms.Label _LBL_FECHA_1;
	private  System.Windows.Forms.Label _LBL_FECHA_0;
	public  System.Windows.Forms.Label Label5;
	public System.Windows.Forms.Label[] LBL_FECHA = new System.Windows.Forms.Label[4];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSBFEmpresa));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color65635410422502356857", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text308635410422502386860", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.sprSBFEmpresa1 = new Softtek.Util.Win.Spread.SpreadWrapper(fpsSBFEmpresa1);
            this.cmdConsultaTarj = new System.Windows.Forms.Button();
            this.cmdSBFerror = new System.Windows.Forms.Button();
            this.cmdSBFvobo = new System.Windows.Forms.Button();
            this.cmdSBFsalir = new System.Windows.Forms.Button();
            this._LBL_FECHA_3 = new System.Windows.Forms.Label();
            this._LBL_FECHA_2 = new System.Windows.Forms.Label();
            this._LBL_FECHA_1 = new System.Windows.Forms.Label();
            this._LBL_FECHA_0 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.fpsSBFEmpresa1 = new FarPoint.Win.Spread.FpSpread();
            this.fpsSBFEmpresa1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.fpsSBFEmpresa1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsSBFEmpresa1_Sheet1)).BeginInit();
            this.SuspendLayout();

            this.fpsSBFEmpresa1.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.sprSBFEmpresa1_Click);
            // 
            // cmdConsultaTarj
            // 
            this.cmdConsultaTarj.BackColor = System.Drawing.SystemColors.Control;
            this.cmdConsultaTarj.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdConsultaTarj.Enabled = false;
            this.cmdConsultaTarj.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdConsultaTarj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsultaTarj.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdConsultaTarj.Location = new System.Drawing.Point(392, 288);
            this.cmdConsultaTarj.Name = "cmdConsultaTarj";
            this.cmdConsultaTarj.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdConsultaTarj.Size = new System.Drawing.Size(105, 33);
            this.cmdConsultaTarj.TabIndex = 5;
            this.cmdConsultaTarj.Tag = "";
            this.cmdConsultaTarj.Text = "Consultar Tarjetahabientes";
            this.cmdConsultaTarj.UseVisualStyleBackColor = false;
            this.cmdConsultaTarj.Click += new System.EventHandler(this.cmdConsultaTarj_Click);
            // 
            // cmdSBFerror
            // 
            this.cmdSBFerror.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSBFerror.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSBFerror.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSBFerror.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSBFerror.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSBFerror.Location = new System.Drawing.Point(232, 288);
            this.cmdSBFerror.Name = "cmdSBFerror";
            this.cmdSBFerror.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSBFerror.Size = new System.Drawing.Size(105, 33);
            this.cmdSBFerror.TabIndex = 3;
            this.cmdSBFerror.Tag = "";
            this.cmdSBFerror.Text = "Error";
            this.cmdSBFerror.UseVisualStyleBackColor = false;
            this.cmdSBFerror.Click += new System.EventHandler(this.cmdSBFerror_Click);
            // 
            // cmdSBFvobo
            // 
            this.cmdSBFvobo.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSBFvobo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSBFvobo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSBFvobo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSBFvobo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSBFvobo.Location = new System.Drawing.Point(96, 288);
            this.cmdSBFvobo.Name = "cmdSBFvobo";
            this.cmdSBFvobo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSBFvobo.Size = new System.Drawing.Size(89, 33);
            this.cmdSBFvobo.TabIndex = 2;
            this.cmdSBFvobo.Tag = "";
            this.cmdSBFvobo.Text = "Visto Bueno";
            this.cmdSBFvobo.UseVisualStyleBackColor = false;
            this.cmdSBFvobo.Click += new System.EventHandler(this.cmdSBFvobo_Click);
            // 
            // cmdSBFsalir
            // 
            this.cmdSBFsalir.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSBFsalir.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSBFsalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSBFsalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSBFsalir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSBFsalir.Location = new System.Drawing.Point(544, 288);
            this.cmdSBFsalir.Name = "cmdSBFsalir";
            this.cmdSBFsalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSBFsalir.Size = new System.Drawing.Size(81, 33);
            this.cmdSBFsalir.TabIndex = 0;
            this.cmdSBFsalir.Tag = "";
            this.cmdSBFsalir.Text = "Salir";
            this.cmdSBFsalir.UseVisualStyleBackColor = false;
            this.cmdSBFsalir.Click += new System.EventHandler(this.cmdSBFsalir_Click);
            // 
            // _LBL_FECHA_3
            // 
            this._LBL_FECHA_3.BackColor = System.Drawing.SystemColors.Control;
            this._LBL_FECHA_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._LBL_FECHA_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._LBL_FECHA_3.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LBL_FECHA_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LBL_FECHA_3.Location = new System.Drawing.Point(256, 48);
            this._LBL_FECHA_3.Name = "_LBL_FECHA_3";
            this._LBL_FECHA_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LBL_FECHA_3.Size = new System.Drawing.Size(161, 25);
            this._LBL_FECHA_3.TabIndex = 9;
            this._LBL_FECHA_3.Tag = "";
            this._LBL_FECHA_3.Visible = false;
            // 
            // _LBL_FECHA_2
            // 
            this._LBL_FECHA_2.BackColor = System.Drawing.SystemColors.Control;
            this._LBL_FECHA_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._LBL_FECHA_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._LBL_FECHA_2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LBL_FECHA_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LBL_FECHA_2.Location = new System.Drawing.Point(104, 48);
            this._LBL_FECHA_2.Name = "_LBL_FECHA_2";
            this._LBL_FECHA_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LBL_FECHA_2.Size = new System.Drawing.Size(145, 25);
            this._LBL_FECHA_2.TabIndex = 8;
            this._LBL_FECHA_2.Tag = "";
            this._LBL_FECHA_2.Visible = false;
            // 
            // _LBL_FECHA_1
            // 
            this._LBL_FECHA_1.BackColor = System.Drawing.SystemColors.Control;
            this._LBL_FECHA_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._LBL_FECHA_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._LBL_FECHA_1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LBL_FECHA_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LBL_FECHA_1.Location = new System.Drawing.Point(256, 24);
            this._LBL_FECHA_1.Name = "_LBL_FECHA_1";
            this._LBL_FECHA_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LBL_FECHA_1.Size = new System.Drawing.Size(161, 25);
            this._LBL_FECHA_1.TabIndex = 7;
            this._LBL_FECHA_1.Tag = "";
            // 
            // _LBL_FECHA_0
            // 
            this._LBL_FECHA_0.BackColor = System.Drawing.SystemColors.Control;
            this._LBL_FECHA_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._LBL_FECHA_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._LBL_FECHA_0.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._LBL_FECHA_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._LBL_FECHA_0.Location = new System.Drawing.Point(104, 24);
            this._LBL_FECHA_0.Name = "_LBL_FECHA_0";
            this._LBL_FECHA_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._LBL_FECHA_0.Size = new System.Drawing.Size(145, 25);
            this._LBL_FECHA_0.TabIndex = 6;
            this._LBL_FECHA_0.Tag = "";
            // 
            // Label5
            // 
            this.Label5.BackColor = System.Drawing.SystemColors.Control;
            this.Label5.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label5.Location = new System.Drawing.Point(152, 288);
            this.Label5.Name = "Label5";
            this.Label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label5.Size = new System.Drawing.Size(465, 25);
            this.Label5.TabIndex = 4;
            this.Label5.Tag = "";
            this.Label5.Visible = false;
            // 
            // fpsSBFEmpresa1
            // 
            this.fpsSBFEmpresa1.AccessibleDescription = "";
            this.fpsSBFEmpresa1.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpsSBFEmpresa1.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsSBFEmpresa1.HorizontalScrollBar.Name = "";
            this.fpsSBFEmpresa1.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpsSBFEmpresa1.HorizontalScrollBar.TabIndex = 4;
            this.fpsSBFEmpresa1.Location = new System.Drawing.Point(8, 88);
            this.fpsSBFEmpresa1.Name = "fpsSBFEmpresa1";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            this.fpsSBFEmpresa1.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2});
            this.fpsSBFEmpresa1.SelectionBlockOptions = FarPoint.Win.Spread.SelectionBlockOptions.None;
            this.fpsSBFEmpresa1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpsSBFEmpresa1_Sheet1});
            this.fpsSBFEmpresa1.Size = new System.Drawing.Size(713, 185);
            this.fpsSBFEmpresa1.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpsSBFEmpresa1.TabIndex = 10;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpsSBFEmpresa1.TextTipAppearance = tipAppearance1;
            this.fpsSBFEmpresa1.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsSBFEmpresa1.VerticalScrollBar.Name = "";
            this.fpsSBFEmpresa1.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpsSBFEmpresa1.VerticalScrollBar.TabIndex = 5;
            this.fpsSBFEmpresa1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // fpsSBFEmpresa1_Sheet1
            // 
            this.fpsSBFEmpresa1_Sheet1.Reset();
            this.fpsSBFEmpresa1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsSBFEmpresa1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsSBFEmpresa1_Sheet1.ColumnCount = 7;
            this.fpsSBFEmpresa1_Sheet1.RowCount = 100;
            this.fpsSBFEmpresa1_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsSBFEmpresa1_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsSBFEmpresa1_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpsSBFEmpresa1_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsSBFEmpresa1_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsSBFEmpresa1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Origen";
            this.fpsSBFEmpresa1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Empresa";
            this.fpsSBFEmpresa1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "S. Anterior";
            this.fpsSBFEmpresa1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "S. Actual";
            this.fpsSBFEmpresa1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "No. TH";
            this.fpsSBFEmpresa1_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "No. Tran";
            this.fpsSBFEmpresa1_Sheet1.ColumnHeader.Cells.Get(0, 6).Value = "Tipo Fact";
            this.fpsSBFEmpresa1_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsSBFEmpresa1_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsSBFEmpresa1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpsSBFEmpresa1_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsSBFEmpresa1_Sheet1.Columns.Get(0).Label = "Origen";
            this.fpsSBFEmpresa1_Sheet1.Columns.Get(0).Width = 49F;
            this.fpsSBFEmpresa1_Sheet1.Columns.Get(1).Label = "Empresa";
            this.fpsSBFEmpresa1_Sheet1.Columns.Get(1).Width = 280F;
            this.fpsSBFEmpresa1_Sheet1.Columns.Get(2).Label = "S. Anterior";
            this.fpsSBFEmpresa1_Sheet1.Columns.Get(2).Width = 96F;
            this.fpsSBFEmpresa1_Sheet1.Columns.Get(3).Label = "S. Actual";
            this.fpsSBFEmpresa1_Sheet1.Columns.Get(3).Width = 94F;
            this.fpsSBFEmpresa1_Sheet1.Columns.Get(4).Label = "No. TH";
            this.fpsSBFEmpresa1_Sheet1.Columns.Get(4).Width = 48F;
            this.fpsSBFEmpresa1_Sheet1.Columns.Get(5).Label = "No. Tran";
            this.fpsSBFEmpresa1_Sheet1.Columns.Get(5).Width = 58F;
            this.fpsSBFEmpresa1_Sheet1.Columns.Get(6).Label = "Tipo Fact";
            this.fpsSBFEmpresa1_Sheet1.Columns.Get(6).Width = 63F;
            this.fpsSBFEmpresa1_Sheet1.DefaultStyleName = "Text308635410422502386860";
            this.fpsSBFEmpresa1_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsSBFEmpresa1_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpsSBFEmpresa1_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsSBFEmpresa1_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpsSBFEmpresa1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsSBFEmpresa1_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsSBFEmpresa1_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpsSBFEmpresa1_Sheet1.RowHeader.Visible = false;
            this.fpsSBFEmpresa1_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsSBFEmpresa1_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsSBFEmpresa1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmSBFEmpresa
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(731, 334);
            this.Controls.Add(this.fpsSBFEmpresa1);
            this.Controls.Add(this.cmdSBFerror);
            this.Controls.Add(this.cmdConsultaTarj);
            this.Controls.Add(this.cmdSBFvobo);
            this.Controls.Add(this._LBL_FECHA_1);
            this.Controls.Add(this._LBL_FECHA_0);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.cmdSBFsalir);
            this.Controls.Add(this._LBL_FECHA_3);
            this.Controls.Add(this._LBL_FECHA_2);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(104, 249);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSBFEmpresa";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "SBF - Nivel Empresa";
            this.Activated += new System.EventHandler(this.frmSBFEmpresa_Activated);
            this.Closed += new System.EventHandler(this.frmSBFEmpresa_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.fpsSBFEmpresa1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsSBFEmpresa1_Sheet1)).EndInit();
            this.ResumeLayout(false);

	}
	void  InitializeLBL_FECHA()
	{
			this.LBL_FECHA[3] = _LBL_FECHA_3;
			this.LBL_FECHA[2] = _LBL_FECHA_2;
			this.LBL_FECHA[1] = _LBL_FECHA_1;
			this.LBL_FECHA[0] = _LBL_FECHA_0;
	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpsSBFEmpresa1;
    private FarPoint.Win.Spread.SheetView fpsSBFEmpresa1_Sheet1;
}
}