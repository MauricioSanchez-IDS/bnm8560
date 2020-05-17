using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class Corcntrancta
	{
	
#region "Upgrade Support "
		private static Corcntrancta m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static Corcntrancta DefInstance
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
		public Corcntrancta():base(){
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
			InitializeLine1();
			InitializeLine2();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static Corcntrancta CreateInstance()
	{
			Corcntrancta theInstance = new Corcntrancta();
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
	public  AxMSMask.AxMaskEdBox MskEmpEjeRollDigit;
	public  AxMSMask.AxMaskEdBox MskPrefBanc;
	public  System.Windows.Forms.TextBox txt_name;
    public  Softtek.Util.Win.Spread.SpreadWrapper  vaSpread;
	public  System.Windows.Forms.GroupBox frm_cons;
	public  System.Windows.Forms.Button cmd_cancel;
	public  System.Windows.Forms.Button cmd_buscar;
	private  System.Windows.Forms.Label _Line1_1;
	private  System.Windows.Forms.Label _Line2_1;
	private  System.Windows.Forms.Label _Line2_0;
	private  System.Windows.Forms.Label _Line1_0;
	public  System.Windows.Forms.Label lbl_name;
	public  System.Windows.Forms.Label lbl_acct_number;
	public  System.Windows.Forms.GroupBox fram_tran;
	public System.Windows.Forms.Label[] Line1 = new System.Windows.Forms.Label[2];
	public System.Windows.Forms.Label[] Line2 = new System.Windows.Forms.Label[2];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Corcntrancta));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color65635410395190045711", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text303635410395190065713", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("Currency643635410395190575764");
            FarPoint.Win.Spread.CellType.CurrencyCellType currencyCellType1 = new FarPoint.Win.Spread.CellType.CurrencyCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fram_tran = new System.Windows.Forms.GroupBox();
            this.cmd_cancel = new System.Windows.Forms.Button();
            this.cmd_buscar = new System.Windows.Forms.Button();
            this.MskPrefBanc = new AxMSMask.AxMaskEdBox();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.frm_cons = new System.Windows.Forms.GroupBox();
            this.fpsvaSpread = new FarPoint.Win.Spread.FpSpread();
            this.fpsvaSpread_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this._Line1_1 = new System.Windows.Forms.Label();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lbl_acct_number = new System.Windows.Forms.Label();
            this._Line1_0 = new System.Windows.Forms.Label();
            this._Line2_1 = new System.Windows.Forms.Label();
            this._Line2_0 = new System.Windows.Forms.Label();
            this.MskEmpEjeRollDigit = new AxMSMask.AxMaskEdBox();
            this.fram_tran.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MskPrefBanc)).BeginInit();
            this.frm_cons.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpsvaSpread)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsvaSpread_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MskEmpEjeRollDigit)).BeginInit();
            this.SuspendLayout();
            // 
            // fram_tran
            // 
            this.fram_tran.BackColor = System.Drawing.SystemColors.Control;
            this.fram_tran.Controls.Add(this.cmd_cancel);
            this.fram_tran.Controls.Add(this.cmd_buscar);
            this.fram_tran.Controls.Add(this.MskPrefBanc);
            this.fram_tran.Controls.Add(this.txt_name);
            this.fram_tran.Controls.Add(this.frm_cons);
            this.fram_tran.Controls.Add(this._Line1_1);
            this.fram_tran.Controls.Add(this.lbl_name);
            this.fram_tran.Controls.Add(this.lbl_acct_number);
            this.fram_tran.Controls.Add(this._Line1_0);
            this.fram_tran.Controls.Add(this._Line2_1);
            this.fram_tran.Controls.Add(this._Line2_0);
            this.fram_tran.Controls.Add(this.MskEmpEjeRollDigit);
            this.fram_tran.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fram_tran.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fram_tran.Location = new System.Drawing.Point(0, 0);
            this.fram_tran.Name = "fram_tran";
            this.fram_tran.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fram_tran.Size = new System.Drawing.Size(774, 303);
            this.fram_tran.TabIndex = 1;
            this.fram_tran.TabStop = false;
            this.fram_tran.Tag = "";
            // 
            // cmd_cancel
            // 
            this.cmd_cancel.BackColor = System.Drawing.SystemColors.Control;
            this.cmd_cancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmd_cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmd_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmd_cancel.Location = new System.Drawing.Point(638, 18);
            this.cmd_cancel.Name = "cmd_cancel";
            this.cmd_cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmd_cancel.Size = new System.Drawing.Size(90, 28);
            this.cmd_cancel.TabIndex = 3;
            this.cmd_cancel.Tag = "";
            this.cmd_cancel.Text = "&Cancelar";
            this.cmd_cancel.UseVisualStyleBackColor = false;
            this.cmd_cancel.Click += new System.EventHandler(this.cmd_cancel_Click);
            // 
            // cmd_buscar
            // 
            this.cmd_buscar.BackColor = System.Drawing.SystemColors.Control;
            this.cmd_buscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmd_buscar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmd_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_buscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmd_buscar.Location = new System.Drawing.Point(531, 19);
            this.cmd_buscar.Name = "cmd_buscar";
            this.cmd_buscar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmd_buscar.Size = new System.Drawing.Size(90, 28);
            this.cmd_buscar.TabIndex = 2;
            this.cmd_buscar.Tag = "";
            this.cmd_buscar.Text = "&Aceptar";
            this.cmd_buscar.UseVisualStyleBackColor = false;
            this.cmd_buscar.Click += new System.EventHandler(this.cmd_buscar_Click);
            // 
            // MskPrefBanc
            // 
            this.MskPrefBanc.Location = new System.Drawing.Point(138, 24);
            this.MskPrefBanc.Name = "MskPrefBanc";
            this.MskPrefBanc.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MskPrefBanc.OcxState")));
            this.MskPrefBanc.Size = new System.Drawing.Size(49, 17);
            this.MskPrefBanc.TabIndex = 9;
            this.MskPrefBanc.Tag = "";
            // 
            // txt_name
            // 
            this.txt_name.AcceptsReturn = true;
            this.txt_name.BackColor = System.Drawing.SystemColors.Window;
            this.txt_name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_name.Enabled = false;
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_name.Location = new System.Drawing.Point(137, 48);
            this.txt_name.MaxLength = 0;
            this.txt_name.Name = "txt_name";
            this.txt_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_name.Size = new System.Drawing.Size(373, 20);
            this.txt_name.TabIndex = 7;
            this.txt_name.Tag = "";
            // 
            // frm_cons
            // 
            this.frm_cons.BackColor = System.Drawing.SystemColors.Control;
            this.frm_cons.Controls.Add(this.fpsvaSpread);
            this.frm_cons.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frm_cons.ForeColor = System.Drawing.SystemColors.ControlText;
            this.frm_cons.Location = new System.Drawing.Point(9, 82);
            this.frm_cons.Name = "frm_cons";
            this.frm_cons.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.frm_cons.Size = new System.Drawing.Size(749, 203);
            this.frm_cons.TabIndex = 5;
            this.frm_cons.TabStop = false;
            this.frm_cons.Tag = "";
            this.frm_cons.Text = "ACCT TOTALS INQUIRY - REAL";
            // 
            // fpsvaSpread
            // 
            this.fpsvaSpread.AccessibleDescription = "";
            this.fpsvaSpread.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpsvaSpread.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsvaSpread.HorizontalScrollBar.Name = "";
            this.fpsvaSpread.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpsvaSpread.HorizontalScrollBar.TabIndex = 4;
            this.fpsvaSpread.Location = new System.Drawing.Point(8, 16);
            this.fpsvaSpread.Name = "fpsvaSpread";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            currencyCellType1.CurrencySymbol = "$";
            currencyCellType1.DecimalPlaces = 2;
            currencyCellType1.DecimalSeparator = ".";
            currencyCellType1.MaximumValue = new decimal(new int[] {
            1410065407,
            2,
            0,
            131072});
            currencyCellType1.MinimumValue = new decimal(new int[] {
            1410065407,
            2,
            0,
            -2147352576});
            currencyCellType1.Separator = ",";
            currencyCellType1.ShowSeparator = true;
            namedStyle3.CellType = currencyCellType1;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            namedStyle3.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle3.Renderer = currencyCellType1;
            namedStyle3.VerticalAlignment = FarPoint.Win.Spread.CellVerticalAlignment.Top;
            this.fpsvaSpread.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3});
            this.fpsvaSpread.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpsvaSpread_Sheet1});
            this.fpsvaSpread.Size = new System.Drawing.Size(733, 177);
            this.fpsvaSpread.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpsvaSpread.TabIndex = 9;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpsvaSpread.TextTipAppearance = tipAppearance1;
            this.fpsvaSpread.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsvaSpread.VerticalScrollBar.Name = "";
            this.fpsvaSpread.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpsvaSpread.VerticalScrollBar.TabIndex = 5;
            this.fpsvaSpread.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // fpsvaSpread_Sheet1
            // 
            this.fpsvaSpread_Sheet1.Reset();
            this.fpsvaSpread_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsvaSpread_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsvaSpread_Sheet1.ColumnCount = 6;
            this.fpsvaSpread_Sheet1.RowCount = 9;
            this.fpsvaSpread_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsvaSpread_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsvaSpread_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpsvaSpread_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsvaSpread_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsvaSpread_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.fpsvaSpread_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "MONTH";
            this.fpsvaSpread_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "CYCLE";
            this.fpsvaSpread_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "QUARTER";
            this.fpsvaSpread_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "FISCAL QUARTER";
            this.fpsvaSpread_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "YEAR";
            this.fpsvaSpread_Sheet1.ColumnHeader.Cells.Get(0, 5).Value = "FISCAL YEAR";
            this.fpsvaSpread_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsvaSpread_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsvaSpread_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpsvaSpread_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsvaSpread_Sheet1.Columns.Get(0).Label = "MONTH";
            this.fpsvaSpread_Sheet1.Columns.Get(0).StyleName = "Currency643635410395190575764";
            this.fpsvaSpread_Sheet1.Columns.Get(0).Width = 157F;
            this.fpsvaSpread_Sheet1.Columns.Get(1).Label = "CYCLE";
            this.fpsvaSpread_Sheet1.Columns.Get(1).StyleName = "Currency643635410395190575764";
            this.fpsvaSpread_Sheet1.Columns.Get(1).Width = 157F;
            this.fpsvaSpread_Sheet1.Columns.Get(2).Label = "QUARTER";
            this.fpsvaSpread_Sheet1.Columns.Get(2).StyleName = "Currency643635410395190575764";
            this.fpsvaSpread_Sheet1.Columns.Get(2).Width = 157F;
            this.fpsvaSpread_Sheet1.Columns.Get(3).Label = "FISCAL QUARTER";
            this.fpsvaSpread_Sheet1.Columns.Get(3).StyleName = "Currency643635410395190575764";
            this.fpsvaSpread_Sheet1.Columns.Get(3).Width = 157F;
            this.fpsvaSpread_Sheet1.Columns.Get(4).Label = "YEAR";
            this.fpsvaSpread_Sheet1.Columns.Get(4).StyleName = "Currency643635410395190575764";
            this.fpsvaSpread_Sheet1.Columns.Get(4).Width = 157F;
            this.fpsvaSpread_Sheet1.Columns.Get(5).Label = "FISCAL YEAR";
            this.fpsvaSpread_Sheet1.Columns.Get(5).StyleName = "Currency643635410395190575764";
            this.fpsvaSpread_Sheet1.Columns.Get(5).Width = 157F;
            this.fpsvaSpread_Sheet1.DefaultStyleName = "Text303635410395190065713";
            this.fpsvaSpread_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsvaSpread_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpsvaSpread_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsvaSpread_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpsvaSpread_Sheet1.RowHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Letters;
            this.fpsvaSpread_Sheet1.RowHeader.Cells.Get(0, 0).Value = "PURCHASE";
            this.fpsvaSpread_Sheet1.RowHeader.Cells.Get(1, 0).Value = "CASH BAL";
            this.fpsvaSpread_Sheet1.RowHeader.Cells.Get(2, 0).Value = "MISC DEB";
            this.fpsvaSpread_Sheet1.RowHeader.Cells.Get(3, 0).Value = "MISC CRE";
            this.fpsvaSpread_Sheet1.RowHeader.Cells.Get(4, 0).Value = "PAYMENTS";
            this.fpsvaSpread_Sheet1.RowHeader.Cells.Get(5, 0).Value = " ";
            this.fpsvaSpread_Sheet1.RowHeader.Cells.Get(6, 0).Value = "TAX ";
            this.fpsvaSpread_Sheet1.RowHeader.Cells.Get(7, 0).Value = "INTEREST";
            this.fpsvaSpread_Sheet1.RowHeader.Cells.Get(8, 0).Value = "FEES";
            this.fpsvaSpread_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsvaSpread_Sheet1.RowHeader.Columns.Get(0).Width = 83F;
            this.fpsvaSpread_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsvaSpread_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpsvaSpread_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsvaSpread_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsvaSpread_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // _Line1_1
            // 
            this._Line1_1.BackColor = System.Drawing.SystemColors.Window;
            this._Line1_1.Location = new System.Drawing.Point(265, 24);
            this._Line1_1.Name = "_Line1_1";
            this._Line1_1.Size = new System.Drawing.Size(1, 18);
            this._Line1_1.TabIndex = 10;
            this._Line1_1.Tag = "";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_name.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_name.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_name.Location = new System.Drawing.Point(100, 52);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_name.Size = new System.Drawing.Size(41, 13);
            this.lbl_name.TabIndex = 6;
            this.lbl_name.Tag = "";
            this.lbl_name.Text = "NAME:";
            // 
            // lbl_acct_number
            // 
            this.lbl_acct_number.AutoSize = true;
            this.lbl_acct_number.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_acct_number.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_acct_number.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_acct_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_acct_number.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_acct_number.Location = new System.Drawing.Point(53, 25);
            this.lbl_acct_number.Name = "lbl_acct_number";
            this.lbl_acct_number.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_acct_number.Size = new System.Drawing.Size(88, 13);
            this.lbl_acct_number.TabIndex = 4;
            this.lbl_acct_number.Tag = "";
            this.lbl_acct_number.Text = "ACCT NUMBER:";
            // 
            // _Line1_0
            // 
            this._Line1_0.BackColor = System.Drawing.SystemColors.WindowText;
            this._Line1_0.Location = new System.Drawing.Point(137, 24);
            this._Line1_0.Name = "_Line1_0";
            this._Line1_0.Size = new System.Drawing.Size(1, 18);
            this._Line1_0.TabIndex = 11;
            this._Line1_0.Tag = "";
            // 
            // _Line2_1
            // 
            this._Line2_1.BackColor = System.Drawing.SystemColors.Window;
            this._Line2_1.Location = new System.Drawing.Point(137, 41);
            this._Line2_1.Name = "_Line2_1";
            this._Line2_1.Size = new System.Drawing.Size(128, 1);
            this._Line2_1.TabIndex = 12;
            this._Line2_1.Tag = "";
            // 
            // _Line2_0
            // 
            this._Line2_0.BackColor = System.Drawing.SystemColors.WindowText;
            this._Line2_0.Location = new System.Drawing.Point(137, 23);
            this._Line2_0.Name = "_Line2_0";
            this._Line2_0.Size = new System.Drawing.Size(128, 1);
            this._Line2_0.TabIndex = 13;
            this._Line2_0.Tag = "";
            // 
            // MskEmpEjeRollDigit
            // 
            this.MskEmpEjeRollDigit.Location = new System.Drawing.Point(183, 24);
            this.MskEmpEjeRollDigit.Name = "MskEmpEjeRollDigit";
            this.MskEmpEjeRollDigit.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("MskEmpEjeRollDigit.OcxState")));
            this.MskEmpEjeRollDigit.Size = new System.Drawing.Size(82, 17);
            this.MskEmpEjeRollDigit.TabIndex = 0;
            this.MskEmpEjeRollDigit.Tag = "";
            // 
            // Corcntrancta
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(774, 303);
            this.Controls.Add(this.fram_tran);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(73, 148);
            this.Name = "Corcntrancta";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Account Transaction Totals Inquiry";
            this.Closed += new System.EventHandler(this.Corcntrancta_Closed);
            this.fram_tran.ResumeLayout(false);
            this.fram_tran.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MskPrefBanc)).EndInit();
            this.frm_cons.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpsvaSpread)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsvaSpread_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MskEmpEjeRollDigit)).EndInit();
            this.ResumeLayout(false);

	}
	void  InitializeLine1()
	{
			this.Line1[1] = _Line1_1;
			this.Line1[0] = _Line1_0;
	}
	void  InitializeLine2()
	{
			this.Line2[1] = _Line2_1;
			this.Line2[0] = _Line2_0;
	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpsvaSpread;
    private FarPoint.Win.Spread.SheetView fpsvaSpread_Sheet1;
}
}