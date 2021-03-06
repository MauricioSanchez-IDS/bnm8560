using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
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
            this.gridRegistros = new Softtek.Util.Win.Spread.SpreadWrapper(fpsgridRegistros);
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
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color65635410296677244946", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text292635410296677254947", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cmdConsMasivo = new System.Windows.Forms.Button();
            this.cmdConsIndividual = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.cmdReenvio = new System.Windows.Forms.Button();
            this.sspnlPorcentaje = new AxThreed.AxSSPanel();
            this.Frame1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.shpComplementaria = new System.Windows.Forms.PictureBox();
            this.shpC430 = new System.Windows.Forms.PictureBox();
            this.shpS111 = new System.Windows.Forms.PictureBox();
            this.shpS016 = new System.Windows.Forms.PictureBox();
            this.fpsgridRegistros = new FarPoint.Win.Spread.FpSpread();
            this.fpsgridRegistros_Sheet1 = new FarPoint.Win.Spread.SheetView();
            ((System.ComponentModel.ISupportInitialize)(this.sspnlPorcentaje)).BeginInit();
            this.Frame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shpComplementaria)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shpC430)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shpS111)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.shpS016)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsgridRegistros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsgridRegistros_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridRegistros
            // 
            this.fpsgridRegistros.CellClick += new FarPoint.Win.Spread.CellClickEventHandler(this.gridRegistros_Click);
            this.fpsgridRegistros.LeaveCell += new FarPoint.Win.Spread.LeaveCellEventHandler(this.gridRegistros_LeaveCell);
            // 
            // cmdConsMasivo
            // 
            this.cmdConsMasivo.BackColor = System.Drawing.SystemColors.Control;
            this.cmdConsMasivo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdConsMasivo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdConsMasivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdConsMasivo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdConsMasivo.Location = new System.Drawing.Point(576, 39);
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
            this.cmdSalir.Location = new System.Drawing.Point(576, 101);
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
            this.cmdReenvio.Location = new System.Drawing.Point(576, 71);
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
            // Frame1
            // 
            this.Frame1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Frame1.Controls.Add(this.label4);
            this.Frame1.Controls.Add(this.label3);
            this.Frame1.Controls.Add(this.label2);
            this.Frame1.Controls.Add(this.label1);
            this.Frame1.Controls.Add(this.shpComplementaria);
            this.Frame1.Controls.Add(this.shpC430);
            this.Frame1.Controls.Add(this.shpS111);
            this.Frame1.Controls.Add(this.shpS016);
            this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Frame1.Location = new System.Drawing.Point(578, 134);
            this.Frame1.Name = "Frame1";
            this.Frame1.Size = new System.Drawing.Size(106, 129);
            this.Frame1.TabIndex = 6;
            this.Frame1.TabStop = false;
            this.Frame1.Text = "Info. Status";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Complem.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "C430";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "S111";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "S016";
            // 
            // shpComplementaria
            // 
            this.shpComplementaria.BackColor = System.Drawing.SystemColors.Window;
            this.shpComplementaria.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shpComplementaria.Location = new System.Drawing.Point(12, 101);
            this.shpComplementaria.Name = "shpComplementaria";
            this.shpComplementaria.Size = new System.Drawing.Size(21, 20);
            this.shpComplementaria.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.shpComplementaria.TabIndex = 3;
            this.shpComplementaria.TabStop = false;
            // 
            // shpC430
            // 
            this.shpC430.BackColor = System.Drawing.SystemColors.Window;
            this.shpC430.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shpC430.Location = new System.Drawing.Point(12, 75);
            this.shpC430.Name = "shpC430";
            this.shpC430.Size = new System.Drawing.Size(21, 20);
            this.shpC430.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.shpC430.TabIndex = 2;
            this.shpC430.TabStop = false;
            // 
            // shpS111
            // 
            this.shpS111.BackColor = System.Drawing.SystemColors.Window;
            this.shpS111.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shpS111.Location = new System.Drawing.Point(12, 49);
            this.shpS111.Name = "shpS111";
            this.shpS111.Size = new System.Drawing.Size(21, 20);
            this.shpS111.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.shpS111.TabIndex = 1;
            this.shpS111.TabStop = false;
            // 
            // shpS016
            // 
            this.shpS016.BackColor = System.Drawing.SystemColors.Window;
            this.shpS016.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shpS016.Location = new System.Drawing.Point(12, 22);
            this.shpS016.Name = "shpS016";
            this.shpS016.Size = new System.Drawing.Size(21, 20);
            this.shpS016.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.shpS016.TabIndex = 0;
            this.shpS016.TabStop = false;
            // 
            // fpsgridRegistros
            // 
            this.fpsgridRegistros.AccessibleDescription = "";
            this.fpsgridRegistros.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpsgridRegistros.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsgridRegistros.HorizontalScrollBar.Name = "";
            this.fpsgridRegistros.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpsgridRegistros.HorizontalScrollBar.TabIndex = 4;
            this.fpsgridRegistros.Location = new System.Drawing.Point(8, 8);
            this.fpsgridRegistros.Name = "fpsgridRegistros";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            this.fpsgridRegistros.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2});
            this.fpsgridRegistros.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpsgridRegistros_Sheet1});
            this.fpsgridRegistros.Size = new System.Drawing.Size(561, 258);
            this.fpsgridRegistros.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpsgridRegistros.TabIndex = 7;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpsgridRegistros.TextTipAppearance = tipAppearance1;
            this.fpsgridRegistros.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsgridRegistros.VerticalScrollBar.Name = "";
            this.fpsgridRegistros.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpsgridRegistros.VerticalScrollBar.TabIndex = 5;
            this.fpsgridRegistros.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // fpsgridRegistros_Sheet1
            // 
            this.fpsgridRegistros_Sheet1.Reset();
            this.fpsgridRegistros_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsgridRegistros_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsgridRegistros_Sheet1.ColumnCount = 5;
            this.fpsgridRegistros_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsgridRegistros_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsgridRegistros_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpsgridRegistros_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsgridRegistros_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsgridRegistros_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Prefijo";
            this.fpsgridRegistros_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Banco";
            this.fpsgridRegistros_Sheet1.ColumnHeader.Cells.Get(0, 2).Value = "Empresa";
            this.fpsgridRegistros_Sheet1.ColumnHeader.Cells.Get(0, 3).Value = "Nombre";
            this.fpsgridRegistros_Sheet1.ColumnHeader.Cells.Get(0, 4).Value = "Estatus";
            this.fpsgridRegistros_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsgridRegistros_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsgridRegistros_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpsgridRegistros_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsgridRegistros_Sheet1.Columns.Get(4).Label = "Estatus";
            this.fpsgridRegistros_Sheet1.Columns.Get(4).Width = 64F;
            this.fpsgridRegistros_Sheet1.DefaultStyleName = "Text292635410296677254947";
            this.fpsgridRegistros_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsgridRegistros_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpsgridRegistros_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsgridRegistros_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpsgridRegistros_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsgridRegistros_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsgridRegistros_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpsgridRegistros_Sheet1.RowHeader.Visible = false;
            this.fpsgridRegistros_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsgridRegistros_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsgridRegistros_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // frmReenvEjecutivo
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(696, 299);
            this.Controls.Add(this.fpsgridRegistros);
            this.Controls.Add(this.Frame1);
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
            this.Frame1.ResumeLayout(false);
            this.Frame1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.shpComplementaria)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shpC430)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shpS111)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.shpS016)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsgridRegistros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsgridRegistros_Sheet1)).EndInit();
            this.ResumeLayout(false);

	}
#endregion 

        private System.Windows.Forms.GroupBox Frame1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox shpComplementaria;
        private System.Windows.Forms.PictureBox shpC430;
        private System.Windows.Forms.PictureBox shpS111;
        private System.Windows.Forms.PictureBox shpS016;
        private FarPoint.Win.Spread.FpSpread fpsgridRegistros;
        private FarPoint.Win.Spread.SheetView fpsgridRegistros_Sheet1;
        public Softtek.Util.Win.Spread.SpreadWrapper gridRegistros;

}
}