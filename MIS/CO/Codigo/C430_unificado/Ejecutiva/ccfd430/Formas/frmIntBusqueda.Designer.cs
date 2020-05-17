using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support;
//AIS-576 echasiquiza
namespace TCd430
{
	partial class frmIntBusqueda
	{
	
#region "Upgrade Support "
		private static frmIntBusqueda m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmIntBusqueda DefInstance
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
		public frmIntBusqueda():base(){
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
            InitializeComponent(); //AIS-1213 echasiquiza
            sprIntBusqueda= new Softtek.Util.Win.Spread.SpreadWrapper(fpsIntBusqueda);
            InitializeHelp();
			InitializelblIntBusqueda();
			InitializeframIntBusqueda();
			InitializecmbIntBusqueda();
			InitializecmdIntBusqueda();
			InitializeoptIntBusqueda();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static frmIntBusqueda CreateInstance()
	{
			frmIntBusqueda theInstance = new frmIntBusqueda();
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
	public System.Windows.Forms.ComboBox[] cmbIntBusqueda = new System.Windows.Forms.ComboBox[4];
	public System.Windows.Forms.Button[] cmdIntBusqueda = new System.Windows.Forms.Button[3];
	public AxThreed.AxSSFrame[] framIntBusqueda = new AxThreed.AxSSFrame[2];
	public System.Windows.Forms.Label[] lblIntBusqueda = new System.Windows.Forms.Label[5];
	public System.Windows.Forms.RadioButton[] optIntBusqueda = new System.Windows.Forms.RadioButton [3];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color65635410414677112211", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text329635410414677122211", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIntBusqueda));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fpsIntBusqueda = new FarPoint.Win.Spread.FpSpread();
            this.fpsIntBusqueda_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this._framIntBusqueda_0 = new AxThreed.AxSSFrame();
            this._cmbIntBusqueda_1 = new System.Windows.Forms.ComboBox();
            this._cmbIntBusqueda_3 = new System.Windows.Forms.ComboBox();
            this._lblIntBusqueda_1 = new System.Windows.Forms.Label();
            this._cmbIntBusqueda_2 = new System.Windows.Forms.ComboBox();
            this._cmdIntBusqueda_1 = new System.Windows.Forms.Button();
            this._cmdIntBusqueda_2 = new System.Windows.Forms.Button();
            this._cmdIntBusqueda_0 = new System.Windows.Forms.Button();
            this._framIntBusqueda_1 = new AxThreed.AxSSFrame();
            this._lblIntBusqueda_0 = new System.Windows.Forms.Label();
            this._lblIntBusqueda_2 = new System.Windows.Forms.Label();
            this._lblIntBusqueda_4 = new System.Windows.Forms.Label();
            this._cmbIntBusqueda_0 = new System.Windows.Forms.ComboBox();
            this._lblIntBusqueda_3 = new System.Windows.Forms.Label();
            this.chkIntBusqueda = new System.Windows.Forms.CheckBox();
            this._optIntBusqueda_2 = new System.Windows.Forms.RadioButton();
            this._optIntBusqueda_1 = new System.Windows.Forms.RadioButton();
            this._optIntBusqueda_0 = new System.Windows.Forms.RadioButton();
            this.mskIntBusqueda = new AxMSMask.AxMaskEdBox();
            ((System.ComponentModel.ISupportInitialize)(this.fpsIntBusqueda)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsIntBusqueda_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._framIntBusqueda_0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._framIntBusqueda_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mskIntBusqueda)).BeginInit();
            this.SuspendLayout();
            // 
            // fpsIntBusqueda
            // 
            this.fpsIntBusqueda.AccessibleDescription = "";
            this.fpsIntBusqueda.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpsIntBusqueda.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsIntBusqueda.HorizontalScrollBar.Name = "";
            this.fpsIntBusqueda.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpsIntBusqueda.HorizontalScrollBar.TabIndex = 4;
            this.fpsIntBusqueda.HorizontalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.Never;
            this.fpsIntBusqueda.Location = new System.Drawing.Point(0, 216);
            this.fpsIntBusqueda.Name = "fpsIntBusqueda";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            this.fpsIntBusqueda.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2});
            this.fpsIntBusqueda.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpsIntBusqueda_Sheet1});
            this.fpsIntBusqueda.Size = new System.Drawing.Size(777, 209);
            this.fpsIntBusqueda.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpsIntBusqueda.TabIndex = 66;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpsIntBusqueda.TextTipAppearance = tipAppearance1;
            this.fpsIntBusqueda.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsIntBusqueda.VerticalScrollBar.Name = "";
            this.fpsIntBusqueda.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpsIntBusqueda.VerticalScrollBar.TabIndex = 5;
            this.fpsIntBusqueda.VerticalScrollBarPolicy = FarPoint.Win.Spread.ScrollBarPolicy.AsNeeded;
            this.fpsIntBusqueda.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // fpsIntBusqueda_Sheet1
            // 
            this.fpsIntBusqueda_Sheet1.Reset();
            this.fpsIntBusqueda_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsIntBusqueda_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsIntBusqueda_Sheet1.ColumnCount = 6;
            this.fpsIntBusqueda_Sheet1.RowCount = 1;
            this.fpsIntBusqueda_Sheet1.ColumnFooter.Columns.Default.Resizable = false;
            this.fpsIntBusqueda_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsIntBusqueda_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsIntBusqueda_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpsIntBusqueda_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsIntBusqueda_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsIntBusqueda_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Empresa";
            this.fpsIntBusqueda_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Unidad";
            this.fpsIntBusqueda_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Reporte";
            this.fpsIntBusqueda_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Representante";
            this.fpsIntBusqueda_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Estatus";
            this.fpsIntBusqueda_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "Fecha";
            this.fpsIntBusqueda_Sheet1.ColumnHeader.Columns.Default.Resizable = false;
            this.fpsIntBusqueda_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsIntBusqueda_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsIntBusqueda_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpsIntBusqueda_Sheet1.Columns.Default.Resizable = false;
            this.fpsIntBusqueda_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsIntBusqueda_Sheet1.Columns.Get(0).Label = "Empresa";
            this.fpsIntBusqueda_Sheet1.Columns.Get(0).Width = 90F;
            this.fpsIntBusqueda_Sheet1.Columns.Get(1).Label = "Unidad";
            this.fpsIntBusqueda_Sheet1.Columns.Get(1).Width = 90F;
            this.fpsIntBusqueda_Sheet1.Columns.Get(2).Label = "Reporte";
            this.fpsIntBusqueda_Sheet1.Columns.Get(2).Width = 239F;
            this.fpsIntBusqueda_Sheet1.Columns.Get(3).Label = "Representante";
            this.fpsIntBusqueda_Sheet1.Columns.Get(3).Width = 103F;
            this.fpsIntBusqueda_Sheet1.Columns.Get(4).Label = "Estatus";
            this.fpsIntBusqueda_Sheet1.Columns.Get(4).Width = 124F;
            this.fpsIntBusqueda_Sheet1.Columns.Get(5).Label = "Fecha";
            this.fpsIntBusqueda_Sheet1.Columns.Get(5).Width = 108F;
            this.fpsIntBusqueda_Sheet1.DefaultStyleName = "Text329635410414677122211";
            this.fpsIntBusqueda_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsIntBusqueda_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpsIntBusqueda_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsIntBusqueda_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpsIntBusqueda_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.fpsIntBusqueda_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsIntBusqueda_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsIntBusqueda_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpsIntBusqueda_Sheet1.RowHeader.Rows.Default.Resizable = false;
            this.fpsIntBusqueda_Sheet1.RowHeader.Visible = false;
            this.fpsIntBusqueda_Sheet1.Rows.Default.Resizable = false;
            this.fpsIntBusqueda_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsIntBusqueda_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsIntBusqueda_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // _framIntBusqueda_0
            // 
            this._framIntBusqueda_0.Location = new System.Drawing.Point(112, 0);
            this._framIntBusqueda_0.Name = "_framIntBusqueda_0";
            this._framIntBusqueda_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_framIntBusqueda_0.OcxState")));
            this._framIntBusqueda_0.Size = new System.Drawing.Size(553, 209);
            this._framIntBusqueda_0.TabIndex = 47;
            this._framIntBusqueda_0.TabStop = false;
            this._framIntBusqueda_0.Tag = "";
            // 
            // _cmbIntBusqueda_1
            // 
            this._cmbIntBusqueda_1.BackColor = System.Drawing.SystemColors.Window;
            this._cmbIntBusqueda_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmbIntBusqueda_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbIntBusqueda_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._cmbIntBusqueda_1.Location = new System.Drawing.Point(438, 30);
            this._cmbIntBusqueda_1.Name = "_cmbIntBusqueda_1";
            this._cmbIntBusqueda_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmbIntBusqueda_1.Size = new System.Drawing.Size(208, 21);
            this._cmbIntBusqueda_1.TabIndex = 1;
            this._cmbIntBusqueda_1.Tag = "";
            this._cmbIntBusqueda_1.SelectedIndexChanged += new System.EventHandler(this.cmbIntBusqueda_SelectedIndexChanged);
            // 
            // _cmbIntBusqueda_3
            // 
            this._cmbIntBusqueda_3.BackColor = System.Drawing.SystemColors.Window;
            this._cmbIntBusqueda_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmbIntBusqueda_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbIntBusqueda_3.ForeColor = System.Drawing.SystemColors.WindowText;
            this._cmbIntBusqueda_3.Location = new System.Drawing.Point(438, 62);
            this._cmbIntBusqueda_3.Name = "_cmbIntBusqueda_3";
            this._cmbIntBusqueda_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmbIntBusqueda_3.Size = new System.Drawing.Size(208, 21);
            this._cmbIntBusqueda_3.TabIndex = 3;
            this._cmbIntBusqueda_3.Tag = "";
            this._cmbIntBusqueda_3.SelectedIndexChanged += new System.EventHandler(this.cmbIntBusqueda_SelectedIndexChanged);
            // 
            // _lblIntBusqueda_1
            // 
            this._lblIntBusqueda_1.AutoSize = true;
            this._lblIntBusqueda_1.BackColor = System.Drawing.SystemColors.Control;
            this._lblIntBusqueda_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblIntBusqueda_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblIntBusqueda_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblIntBusqueda_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblIntBusqueda_1.Location = new System.Drawing.Point(390, 30);
            this._lblIntBusqueda_1.Name = "_lblIntBusqueda_1";
            this._lblIntBusqueda_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblIntBusqueda_1.Size = new System.Drawing.Size(48, 13);
            this._lblIntBusqueda_1.TabIndex = 52;
            this._lblIntBusqueda_1.Tag = "";
            this._lblIntBusqueda_1.Text = "Empresa";
            // 
            // _cmbIntBusqueda_2
            // 
            this._cmbIntBusqueda_2.BackColor = System.Drawing.SystemColors.Window;
            this._cmbIntBusqueda_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmbIntBusqueda_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbIntBusqueda_2.ForeColor = System.Drawing.SystemColors.WindowText;
            this._cmbIntBusqueda_2.Location = new System.Drawing.Point(166, 62);
            this._cmbIntBusqueda_2.Name = "_cmbIntBusqueda_2";
            this._cmbIntBusqueda_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmbIntBusqueda_2.Size = new System.Drawing.Size(208, 21);
            this._cmbIntBusqueda_2.TabIndex = 2;
            this._cmbIntBusqueda_2.Tag = "";
            this._cmbIntBusqueda_2.SelectedIndexChanged += new System.EventHandler(this.cmbIntBusqueda_SelectedIndexChanged);
            // 
            // _cmdIntBusqueda_1
            // 
            this._cmdIntBusqueda_1.BackColor = System.Drawing.SystemColors.Control;
            this._cmdIntBusqueda_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmdIntBusqueda_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._cmdIntBusqueda_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmdIntBusqueda_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cmdIntBusqueda_1.Location = new System.Drawing.Point(470, 168);
            this._cmdIntBusqueda_1.Name = "_cmdIntBusqueda_1";
            this._cmdIntBusqueda_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmdIntBusqueda_1.Size = new System.Drawing.Size(89, 25);
            this._cmdIntBusqueda_1.TabIndex = 6;
            this._cmdIntBusqueda_1.Tag = "";
            this._cmdIntBusqueda_1.Text = "Cancelar";
            this._cmdIntBusqueda_1.UseVisualStyleBackColor = false;
            this._cmdIntBusqueda_1.Click += new System.EventHandler(this.cmdIntBusqueda_Click);
            // 
            // _cmdIntBusqueda_2
            // 
            this._cmdIntBusqueda_2.BackColor = System.Drawing.SystemColors.Control;
            this._cmdIntBusqueda_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmdIntBusqueda_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._cmdIntBusqueda_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmdIntBusqueda_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cmdIntBusqueda_2.Location = new System.Drawing.Point(349, 168);
            this._cmdIntBusqueda_2.Name = "_cmdIntBusqueda_2";
            this._cmdIntBusqueda_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmdIntBusqueda_2.Size = new System.Drawing.Size(89, 25);
            this._cmdIntBusqueda_2.TabIndex = 7;
            this._cmdIntBusqueda_2.Tag = "";
            this._cmdIntBusqueda_2.Text = "Iniciar Búsqueda";
            this._cmdIntBusqueda_2.UseVisualStyleBackColor = false;
            this._cmdIntBusqueda_2.Click += new System.EventHandler(this.cmdIntBusqueda_Click);
            // 
            // _cmdIntBusqueda_0
            // 
            this._cmdIntBusqueda_0.BackColor = System.Drawing.SystemColors.Control;
            this._cmdIntBusqueda_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmdIntBusqueda_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._cmdIntBusqueda_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmdIntBusqueda_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._cmdIntBusqueda_0.Location = new System.Drawing.Point(234, 167);
            this._cmdIntBusqueda_0.Name = "_cmdIntBusqueda_0";
            this._cmdIntBusqueda_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmdIntBusqueda_0.Size = new System.Drawing.Size(89, 25);
            this._cmdIntBusqueda_0.TabIndex = 5;
            this._cmdIntBusqueda_0.Tag = "";
            this._cmdIntBusqueda_0.Text = "Aceptar";
            this._cmdIntBusqueda_0.UseVisualStyleBackColor = false;
            this._cmdIntBusqueda_0.Click += new System.EventHandler(this.cmdIntBusqueda_Click);
            // 
            // _framIntBusqueda_1
            // 
            this._framIntBusqueda_1.Location = new System.Drawing.Point(276, 95);
            this._framIntBusqueda_1.Name = "_framIntBusqueda_1";
            this._framIntBusqueda_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_framIntBusqueda_1.OcxState")));
            this._framIntBusqueda_1.Size = new System.Drawing.Size(369, 57);
            this._framIntBusqueda_1.TabIndex = 57;
            this._framIntBusqueda_1.TabStop = false;
            this._framIntBusqueda_1.Tag = "";
            // 
            // _lblIntBusqueda_0
            // 
            this._lblIntBusqueda_0.AutoSize = true;
            this._lblIntBusqueda_0.BackColor = System.Drawing.SystemColors.Control;
            this._lblIntBusqueda_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblIntBusqueda_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblIntBusqueda_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblIntBusqueda_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblIntBusqueda_0.Location = new System.Drawing.Point(129, 29);
            this._lblIntBusqueda_0.Name = "_lblIntBusqueda_0";
            this._lblIntBusqueda_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblIntBusqueda_0.Size = new System.Drawing.Size(36, 13);
            this._lblIntBusqueda_0.TabIndex = 51;
            this._lblIntBusqueda_0.Tag = "";
            this._lblIntBusqueda_0.Text = "Grupo";
            // 
            // _lblIntBusqueda_2
            // 
            this._lblIntBusqueda_2.AutoSize = true;
            this._lblIntBusqueda_2.BackColor = System.Drawing.SystemColors.Control;
            this._lblIntBusqueda_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblIntBusqueda_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblIntBusqueda_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblIntBusqueda_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblIntBusqueda_2.Location = new System.Drawing.Point(126, 62);
            this._lblIntBusqueda_2.Name = "_lblIntBusqueda_2";
            this._lblIntBusqueda_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblIntBusqueda_2.Size = new System.Drawing.Size(41, 13);
            this._lblIntBusqueda_2.TabIndex = 53;
            this._lblIntBusqueda_2.Tag = "";
            this._lblIntBusqueda_2.Text = "Unidad";
            // 
            // _lblIntBusqueda_4
            // 
            this._lblIntBusqueda_4.AutoSize = true;
            this._lblIntBusqueda_4.BackColor = System.Drawing.SystemColors.Control;
            this._lblIntBusqueda_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblIntBusqueda_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblIntBusqueda_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblIntBusqueda_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblIntBusqueda_4.Location = new System.Drawing.Point(126, 98);
            this._lblIntBusqueda_4.Name = "_lblIntBusqueda_4";
            this._lblIntBusqueda_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblIntBusqueda_4.Size = new System.Drawing.Size(37, 13);
            this._lblIntBusqueda_4.TabIndex = 55;
            this._lblIntBusqueda_4.Tag = "";
            this._lblIntBusqueda_4.Text = "Fecha";
            // 
            // _cmbIntBusqueda_0
            // 
            this._cmbIntBusqueda_0.BackColor = System.Drawing.SystemColors.Window;
            this._cmbIntBusqueda_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._cmbIntBusqueda_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._cmbIntBusqueda_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._cmbIntBusqueda_0.Location = new System.Drawing.Point(167, 29);
            this._cmbIntBusqueda_0.Name = "_cmbIntBusqueda_0";
            this._cmbIntBusqueda_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._cmbIntBusqueda_0.Size = new System.Drawing.Size(206, 21);
            this._cmbIntBusqueda_0.TabIndex = 0;
            this._cmbIntBusqueda_0.Tag = "";
            this._cmbIntBusqueda_0.SelectedIndexChanged += new System.EventHandler(this.cmbIntBusqueda_SelectedIndexChanged);
            // 
            // _lblIntBusqueda_3
            // 
            this._lblIntBusqueda_3.AutoSize = true;
            this._lblIntBusqueda_3.BackColor = System.Drawing.SystemColors.Control;
            this._lblIntBusqueda_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblIntBusqueda_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblIntBusqueda_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblIntBusqueda_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblIntBusqueda_3.Location = new System.Drawing.Point(390, 62);
            this._lblIntBusqueda_3.Name = "_lblIntBusqueda_3";
            this._lblIntBusqueda_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblIntBusqueda_3.Size = new System.Drawing.Size(45, 13);
            this._lblIntBusqueda_3.TabIndex = 54;
            this._lblIntBusqueda_3.Tag = "";
            this._lblIntBusqueda_3.Text = "Reporte";
            // 
            // chkIntBusqueda
            // 
            this.chkIntBusqueda.BackColor = System.Drawing.SystemColors.Control;
            this.chkIntBusqueda.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkIntBusqueda.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIntBusqueda.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkIntBusqueda.Location = new System.Drawing.Point(166, 98);
            this.chkIntBusqueda.Name = "chkIntBusqueda";
            this.chkIntBusqueda.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkIntBusqueda.Size = new System.Drawing.Size(17, 13);
            this.chkIntBusqueda.TabIndex = 56;
            this.chkIntBusqueda.Tag = "";
            this.chkIntBusqueda.UseVisualStyleBackColor = false;
            this.chkIntBusqueda.CheckedChanged += new System.EventHandler(this.chkIntBusqueda_CheckStateChanged);
            // 
            // _optIntBusqueda_2
            // 
            this._optIntBusqueda_2.Checked = true;
            this._optIntBusqueda_2.Location = new System.Drawing.Point(547, 120);
            this._optIntBusqueda_2.Name = "_optIntBusqueda_2";
            this._optIntBusqueda_2.Size = new System.Drawing.Size(56, 17);
            this._optIntBusqueda_2.TabIndex = 4;
            this._optIntBusqueda_2.TabStop = true;
            this._optIntBusqueda_2.Tag = "";
            this._optIntBusqueda_2.Text = "Todos";
            // 
            // _optIntBusqueda_1
            // 
            this._optIntBusqueda_1.Location = new System.Drawing.Point(417, 120);
            this._optIntBusqueda_1.Name = "_optIntBusqueda_1";
            this._optIntBusqueda_1.Size = new System.Drawing.Size(101, 17);
            this._optIntBusqueda_1.TabIndex = 63;
            this._optIntBusqueda_1.Tag = "";
            this._optIntBusqueda_1.Text = "No Transmitidos";
            // 
            // _optIntBusqueda_0
            // 
            this._optIntBusqueda_0.Location = new System.Drawing.Point(300, 119);
            this._optIntBusqueda_0.Name = "_optIntBusqueda_0";
            this._optIntBusqueda_0.Size = new System.Drawing.Size(84, 17);
            this._optIntBusqueda_0.TabIndex = 62;
            this._optIntBusqueda_0.Tag = "";
            this._optIntBusqueda_0.Text = "Transmitidos";
            // 
            // mskIntBusqueda
            // 
            this.mskIntBusqueda.Location = new System.Drawing.Point(182, 94);
            this.mskIntBusqueda.Name = "mskIntBusqueda";
            this.mskIntBusqueda.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("mskIntBusqueda.OcxState")));
            this.mskIntBusqueda.Size = new System.Drawing.Size(84, 21);
            this.mskIntBusqueda.TabIndex = 65;
            this.mskIntBusqueda.Tag = "";
            // 
            // frmIntBusqueda
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(777, 426);
            this.Controls.Add(this.fpsIntBusqueda);
            this.Controls.Add(this.mskIntBusqueda);
            this.Controls.Add(this._optIntBusqueda_2);
            this.Controls.Add(this._optIntBusqueda_1);
            this.Controls.Add(this._optIntBusqueda_0);
            this.Controls.Add(this._cmbIntBusqueda_1);
            this.Controls.Add(this._cmbIntBusqueda_3);
            this.Controls.Add(this._lblIntBusqueda_1);
            this.Controls.Add(this._cmbIntBusqueda_2);
            this.Controls.Add(this._cmdIntBusqueda_1);
            this.Controls.Add(this._cmdIntBusqueda_2);
            this.Controls.Add(this._cmdIntBusqueda_0);
            this.Controls.Add(this._framIntBusqueda_1);
            this.Controls.Add(this._lblIntBusqueda_0);
            this.Controls.Add(this._lblIntBusqueda_2);
            this.Controls.Add(this._lblIntBusqueda_4);
            this.Controls.Add(this._cmbIntBusqueda_0);
            this.Controls.Add(this._lblIntBusqueda_3);
            this.Controls.Add(this.chkIntBusqueda);
            this.Controls.Add(this._framIntBusqueda_0);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(10, 87);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIntBusqueda";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Intelar Busqueda";
            this.Closed += new System.EventHandler(this.frmIntBusqueda_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.fpsIntBusqueda)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsIntBusqueda_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._framIntBusqueda_0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._framIntBusqueda_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mskIntBusqueda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

	}
	void  InitializelblIntBusqueda()
	{
			this.lblIntBusqueda[4] = _lblIntBusqueda_4;
			this.lblIntBusqueda[3] = _lblIntBusqueda_3;
			this.lblIntBusqueda[2] = _lblIntBusqueda_2;
			this.lblIntBusqueda[1] = _lblIntBusqueda_1;
			this.lblIntBusqueda[0] = _lblIntBusqueda_0;
	}
	void  InitializeframIntBusqueda()
	{
			this.framIntBusqueda[1] = _framIntBusqueda_1;
			this.framIntBusqueda[0] = _framIntBusqueda_0;
	}
	void  InitializecmbIntBusqueda()
	{
			this.cmbIntBusqueda[3] = _cmbIntBusqueda_3;
			this.cmbIntBusqueda[2] = _cmbIntBusqueda_2;
			this.cmbIntBusqueda[1] = _cmbIntBusqueda_1;
			this.cmbIntBusqueda[0] = _cmbIntBusqueda_0;
	}
	void  InitializecmdIntBusqueda()
	{
			this.cmdIntBusqueda[2] = _cmdIntBusqueda_2;
			this.cmdIntBusqueda[1] = _cmdIntBusqueda_1;
			this.cmdIntBusqueda[0] = _cmdIntBusqueda_0;
	}
	void  InitializeoptIntBusqueda()
	{
			this.optIntBusqueda[0] = _optIntBusqueda_0;
			this.optIntBusqueda[1] = _optIntBusqueda_1;
			this.optIntBusqueda[2] = _optIntBusqueda_2;
	}
#endregion 

    private AxThreed.AxSSFrame _framIntBusqueda_0;
        private System.Windows.Forms.ComboBox _cmbIntBusqueda_1;
        private System.Windows.Forms.ComboBox _cmbIntBusqueda_3;
        private System.Windows.Forms.Label _lblIntBusqueda_1;
        private System.Windows.Forms.ComboBox _cmbIntBusqueda_2;
        private System.Windows.Forms.Button _cmdIntBusqueda_1;
        private System.Windows.Forms.Button _cmdIntBusqueda_2;
        private System.Windows.Forms.Button _cmdIntBusqueda_0;
        private AxThreed.AxSSFrame _framIntBusqueda_1;
        private System.Windows.Forms.Label _lblIntBusqueda_0;
        private System.Windows.Forms.Label _lblIntBusqueda_2;
        private System.Windows.Forms.Label _lblIntBusqueda_4;
        private System.Windows.Forms.ComboBox _cmbIntBusqueda_0;
        private System.Windows.Forms.Label _lblIntBusqueda_3;
        public System.Windows.Forms.CheckBox chkIntBusqueda;
        private System.Windows.Forms.RadioButton _optIntBusqueda_2;
        private System.Windows.Forms.RadioButton _optIntBusqueda_1;
        private System.Windows.Forms.RadioButton _optIntBusqueda_0;
        public AxMSMask.AxMaskEdBox mskIntBusqueda;
        private FarPoint.Win.Spread.FpSpread fpsIntBusqueda;
        private FarPoint.Win.Spread.SheetView fpsIntBusqueda_Sheet1;
        public Softtek.Util.Win.Spread.SpreadWrapper sprIntBusqueda;

}
}