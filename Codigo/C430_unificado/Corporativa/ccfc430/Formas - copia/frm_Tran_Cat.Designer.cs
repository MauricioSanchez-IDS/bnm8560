using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frm_Tran_Cat
	{
	
#region "Upgrade Support "
		private static frm_Tran_Cat m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_Tran_Cat DefInstance
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
		public frm_Tran_Cat():base(){
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
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static frm_Tran_Cat CreateInstance()
	{
			frm_Tran_Cat theInstance = new frm_Tran_Cat();
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
	public  System.Windows.Forms.TextBox txt_name;
	public  System.Windows.Forms.Button cmd_cancel;
	public  System.Windows.Forms.Button cmd_buscar;
	public  System.Windows.Forms.ComboBox cmb_select;
	public  System.Windows.Forms.TextBox txt_acc_num;
	public  System.Windows.Forms.Label lbl_name;
	public  System.Windows.Forms.Label lbl_selection;
	public  System.Windows.Forms.Label lbl_acc_num;
	public  System.Windows.Forms.GroupBox fram_tran_cat;
	private Artinsoft.VB6.Gui.ListControlHelper ListBoxComboBoxHelper1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Tran_Cat));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color65635410204314675074", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text292635410204314755079", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fram_tran_cat = new System.Windows.Forms.GroupBox();
            this.cmd_buscar = new System.Windows.Forms.Button();
            this.cmd_cancel = new System.Windows.Forms.Button();            
            this.txt_name = new System.Windows.Forms.TextBox();
            this.cmb_select = new System.Windows.Forms.ComboBox();
            this.lbl_selection = new System.Windows.Forms.Label();
            this.lbl_acc_num = new System.Windows.Forms.Label();
            this.txt_acc_num = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.ListBoxComboBoxHelper1 = new Artinsoft.VB6.Gui.ListControlHelper(this.components);
            this.fpSpread1 = new FarPoint.Win.Spread.FpSpread();
            this.fpSpread1_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.fram_tran_cat.SuspendLayout();            
            ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // fram_tran_cat
            // 
            this.fram_tran_cat.BackColor = System.Drawing.SystemColors.Control;
            this.fram_tran_cat.Controls.Add(this.fpSpread1);
            this.fram_tran_cat.Controls.Add(this.cmd_buscar);
            this.fram_tran_cat.Controls.Add(this.cmd_cancel);            
            this.fram_tran_cat.Controls.Add(this.txt_name);
            this.fram_tran_cat.Controls.Add(this.cmb_select);
            this.fram_tran_cat.Controls.Add(this.lbl_selection);
            this.fram_tran_cat.Controls.Add(this.lbl_acc_num);
            this.fram_tran_cat.Controls.Add(this.txt_acc_num);
            this.fram_tran_cat.Controls.Add(this.lbl_name);
            this.fram_tran_cat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fram_tran_cat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fram_tran_cat.Location = new System.Drawing.Point(0, -2);
            this.fram_tran_cat.Name = "fram_tran_cat";
            this.fram_tran_cat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fram_tran_cat.Size = new System.Drawing.Size(757, 334);
            this.fram_tran_cat.TabIndex = 0;
            this.fram_tran_cat.TabStop = false;
            this.fram_tran_cat.Tag = "";
            // 
            // cmd_buscar
            // 
            this.cmd_buscar.BackColor = System.Drawing.SystemColors.Control;
            this.cmd_buscar.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmd_buscar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmd_buscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_buscar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmd_buscar.Location = new System.Drawing.Point(426, 50);
            this.cmd_buscar.Name = "cmd_buscar";
            this.cmd_buscar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmd_buscar.Size = new System.Drawing.Size(90, 28);
            this.cmd_buscar.TabIndex = 5;
            this.cmd_buscar.Tag = "";
            this.cmd_buscar.Text = "&Buscar";
            this.cmd_buscar.UseVisualStyleBackColor = false;
            // 
            // cmd_cancel
            // 
            this.cmd_cancel.BackColor = System.Drawing.SystemColors.Control;
            this.cmd_cancel.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmd_cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmd_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmd_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmd_cancel.Location = new System.Drawing.Point(530, 50);
            this.cmd_cancel.Name = "cmd_cancel";
            this.cmd_cancel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmd_cancel.Size = new System.Drawing.Size(90, 28);
            this.cmd_cancel.TabIndex = 6;
            this.cmd_cancel.Tag = "";
            this.cmd_cancel.Text = "&Cancelar";
            this.cmd_cancel.UseVisualStyleBackColor = false;
            this.cmd_cancel.Click += new System.EventHandler(this.cmd_cancel_Click);
          
            // 
            // txt_name
            // 
            this.txt_name.AcceptsReturn = true;
            this.txt_name.BackColor = System.Drawing.SystemColors.Window;
            this.txt_name.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_name.Location = new System.Drawing.Point(424, 22);
            this.txt_name.MaxLength = 0;
            this.txt_name.Name = "txt_name";
            this.txt_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_name.Size = new System.Drawing.Size(228, 20);
            this.txt_name.TabIndex = 8;
            this.txt_name.Tag = "";
            // 
            // cmb_select
            // 
            this.cmb_select.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_select.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmb_select.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_select.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ListBoxComboBoxHelper1.SetItemData(this.cmb_select, new int[] {
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0});
            this.cmb_select.Items.AddRange(new object[] {
            "C  --  CYCLE",
            "M  --  MONTH",
            "Q  --  QUARTER",
            "F  --  FISCAL QUARTER",
            "Y  --  YEAR",
            "P  --  PRIOR YEAR",
            "I  --  FISCAL YEAR",
            "R  --  PRIOR FISCAL YEAR"});
            this.cmb_select.Location = new System.Drawing.Point(160, 50);
            this.cmb_select.Name = "cmb_select";
            this.cmb_select.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmb_select.Size = new System.Drawing.Size(125, 21);
            this.cmb_select.TabIndex = 3;
            this.cmb_select.Tag = "";
            // 
            // lbl_selection
            // 
            this.lbl_selection.AutoSize = true;
            this.lbl_selection.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_selection.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_selection.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_selection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_selection.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_selection.Location = new System.Drawing.Point(91, 55);
            this.lbl_selection.Name = "lbl_selection";
            this.lbl_selection.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_selection.Size = new System.Drawing.Size(70, 13);
            this.lbl_selection.TabIndex = 4;
            this.lbl_selection.Tag = "";
            this.lbl_selection.Text = "SELECTION:";
            // 
            // lbl_acc_num
            // 
            this.lbl_acc_num.AutoSize = true;
            this.lbl_acc_num.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_acc_num.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_acc_num.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_acc_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_acc_num.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_acc_num.Location = new System.Drawing.Point(49, 26);
            this.lbl_acc_num.Name = "lbl_acc_num";
            this.lbl_acc_num.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_acc_num.Size = new System.Drawing.Size(112, 13);
            this.lbl_acc_num.TabIndex = 1;
            this.lbl_acc_num.Tag = "";
            this.lbl_acc_num.Text = "ACCOUNT NUMBER:";
            // 
            // txt_acc_num
            // 
            this.txt_acc_num.AcceptsReturn = true;
            this.txt_acc_num.BackColor = System.Drawing.SystemColors.Window;
            this.txt_acc_num.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txt_acc_num.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_acc_num.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_acc_num.Location = new System.Drawing.Point(160, 22);
            this.txt_acc_num.MaxLength = 0;
            this.txt_acc_num.Name = "txt_acc_num";
            this.txt_acc_num.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txt_acc_num.Size = new System.Drawing.Size(214, 20);
            this.txt_acc_num.TabIndex = 2;
            this.txt_acc_num.Tag = "";
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_name.Cursor = System.Windows.Forms.Cursors.Default;
            this.lbl_name.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbl_name.Location = new System.Drawing.Point(386, 26);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lbl_name.Size = new System.Drawing.Size(41, 13);
            this.lbl_name.TabIndex = 9;
            this.lbl_name.Tag = "";
            this.lbl_name.Text = "NAME:";
            // 
            // fpSpread1
            // 
            this.fpSpread1.AccessibleDescription = "";
            this.fpSpread1.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpSpread1.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpSpread1.HorizontalScrollBar.Name = "";
            this.fpSpread1.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpSpread1.HorizontalScrollBar.TabIndex = 6;
            this.fpSpread1.Location = new System.Drawing.Point(22, 89);
            this.fpSpread1.Name = "fpSpread1";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            this.fpSpread1.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2});
            this.fpSpread1.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpSpread1_Sheet1});
            this.fpSpread1.Size = new System.Drawing.Size(712, 226);
            this.fpSpread1.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpSpread1.TabIndex = 10;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpSpread1.TextTipAppearance = tipAppearance1;
            this.fpSpread1.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpSpread1.VerticalScrollBar.Name = "";
            this.fpSpread1.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpSpread1.VerticalScrollBar.TabIndex = 7;
            this.fpSpread1.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // fpSpread1_Sheet1
            // 
            this.fpSpread1_Sheet1.Reset();
            this.fpSpread1_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpSpread1_Sheet1.ColumnCount = 5;
            this.fpSpread1_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpSpread1_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread1_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread1_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "CATEGORY";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "DEBITS";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "CREDITS";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "#DEBT";
            this.fpSpread1_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "#CRDT";
            this.fpSpread1_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread1_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpSpread1_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpSpread1_Sheet1.Columns.Get(0).Label = "CATEGORY";
            this.fpSpread1_Sheet1.Columns.Get(0).Width = 227F;
            this.fpSpread1_Sheet1.Columns.Get(1).Label = "DEBITS";
            this.fpSpread1_Sheet1.Columns.Get(1).Width = 170F;
            this.fpSpread1_Sheet1.Columns.Get(2).Label = "CREDITS";
            this.fpSpread1_Sheet1.Columns.Get(2).Width = 165F;
            this.fpSpread1_Sheet1.DefaultStyleName = "Text292635410204314755079";
            this.fpSpread1_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread1_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpSpread1_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread1_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpSpread1_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread1_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpSpread1_Sheet1.RowHeader.Visible = false;
            this.fpSpread1_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpSpread1_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpSpread1_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frm_Tran_Cat
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(758, 333);
            this.Controls.Add(this.fram_tran_cat);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(102, 191);
            this.Name = "frm_Tran_Cat";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Account Category Totals Listing";
            this.Closed += new System.EventHandler(this.frm_Tran_Cat_Closed);
            this.fram_tran_cat.ResumeLayout(false);
            this.fram_tran_cat.PerformLayout();            
            ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpSpread1_Sheet1)).EndInit();
            this.ResumeLayout(false);

	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpSpread1;
    private FarPoint.Win.Spread.SheetView fpSpread1_Sheet1;
}
}