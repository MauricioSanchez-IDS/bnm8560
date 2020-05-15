using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORCTBNX
	{
	
#region "Upgrade Support "
		private static CORCTBNX m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORCTBNX DefInstance
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
		public CORCTBNX():base(){
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
			isInitializingComponent = true;
			InitializeComponent();
			isInitializingComponent = false;
			InitializeHelp();
			InitializeoptNivel();
			InitializeoptTipo();
			InitializelblPeriodo();
			InitializepnlEtiqueta();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORCTBNX CreateInstance()
	{
			CORCTBNX theInstance = new CORCTBNX();
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
			Artinsoft.VB6.Help.HelpSupportClass.SetHelpContextId(_optNivel_4, 240);
			Artinsoft.VB6.Help.HelpSupportClass.SetHelpContextId(_optNivel_3, 240);
			Artinsoft.VB6.Help.HelpSupportClass.SetHelpContextId(_optNivel_2, 240);
			Artinsoft.VB6.Help.HelpSupportClass.SetHelpContextId(_optNivel_1, 240);
			Artinsoft.VB6.Help.HelpSupportClass.SetHelpContextId(_optNivel_0, 240);
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
    public Softtek.Util.Win.Spread.SpreadWrapper vspDatos;
	public  AxCrystal.AxCrystalReport crReporBnx;
	public  System.Windows.Forms.ListBox lstEmpresas;
	public  System.Windows.Forms.ListBox lstSeleccion;
	public  System.Windows.Forms.Button cmdDel;
	public  System.Windows.Forms.Button cmdDelAll;
	public  System.Windows.Forms.Button cmdAdd;
	public  System.Windows.Forms.Button cmdAll;
	public  System.Windows.Forms.Button cmdAceptar;
	public  System.Windows.Forms.Button cmdSalir;
	public  System.Windows.Forms.ComboBox cboGrupo;
	public  System.Windows.Forms.TextBox txtIdentificador;
	public  System.Windows.Forms.ComboBox cboFecha;
	public  System.Windows.Forms.CheckBox chkOpcion;
	private  System.Windows.Forms.RadioButton _optNivel_4;
	private  System.Windows.Forms.RadioButton _optNivel_3;
	private  System.Windows.Forms.RadioButton _optNivel_2;
	private  System.Windows.Forms.RadioButton _optNivel_1;
	private  System.Windows.Forms.RadioButton _optNivel_0;
	public  System.Windows.Forms.GroupBox fraReportes;
	private  System.Windows.Forms.RadioButton _optTipo_0;
	private  System.Windows.Forms.RadioButton _optTipo_1;
	public  System.Windows.Forms.GroupBox frmTipo;
	public  System.Windows.Forms.Label Label1;
	private  System.Windows.Forms.Label _lblPeriodo_0;
	public  AxThreed.AxSSPanel pnlPrincipal;
	private  System.Windows.Forms.Label _pnlEtiqueta_7Label_Text;
	private  AxThreed.AxSSPanel _pnlEtiqueta_7;
	private  System.Windows.Forms.Label _pnlEtiqueta_6Label_Text;
	private  AxThreed.AxSSPanel _pnlEtiqueta_6;
	private  System.Windows.Forms.Label _pnlEtiqueta_2Label_Text;
	private  AxThreed.AxSSPanel _pnlEtiqueta_2;
	private  System.Windows.Forms.Label _pnlEtiqueta_3Label_Text;
	private  AxThreed.AxSSPanel _pnlEtiqueta_3;
	private  System.Windows.Forms.Label _pnlEtiqueta_0Label_Text;
	private  AxThreed.AxSSPanel _pnlEtiqueta_0;
	public System.Windows.Forms.Label[] lblPeriodo = new System.Windows.Forms.Label[1];
	public System.Windows.Forms.RadioButton[] optNivel = new System.Windows.Forms.RadioButton[5];
	public System.Windows.Forms.RadioButton[] optTipo = new System.Windows.Forms.RadioButton[2];
	public AxThreed.AxSSPanel[] pnlEtiqueta = new AxThreed.AxSSPanel[8];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color36635412858487863930", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text268635412858489154059", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORCTBNX));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fpsDatos = new FarPoint.Win.Spread.FpSpread();
            this.fpsDatos_Sheet1 = new FarPoint.Win.Spread.SheetView();
            this.crReporBnx = new AxCrystal.AxCrystalReport();
            this.lstEmpresas = new System.Windows.Forms.ListBox();
            this.lstSeleccion = new System.Windows.Forms.ListBox();
            this.cmdDel = new System.Windows.Forms.Button();
            this.cmdDelAll = new System.Windows.Forms.Button();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdAll = new System.Windows.Forms.Button();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.pnlPrincipal = new AxThreed.AxSSPanel();
            this.fraReportes = new System.Windows.Forms.GroupBox();
            this._optNivel_3 = new System.Windows.Forms.RadioButton();
            this.chkOpcion = new System.Windows.Forms.CheckBox();
            this._optNivel_4 = new System.Windows.Forms.RadioButton();
            this._optNivel_2 = new System.Windows.Forms.RadioButton();
            this._optNivel_1 = new System.Windows.Forms.RadioButton();
            this._optNivel_0 = new System.Windows.Forms.RadioButton();
            this.cboFecha = new System.Windows.Forms.ComboBox();
            this.txtIdentificador = new System.Windows.Forms.TextBox();
            this._lblPeriodo_0 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.frmTipo = new System.Windows.Forms.GroupBox();
            this._optTipo_0 = new System.Windows.Forms.RadioButton();
            this._optTipo_1 = new System.Windows.Forms.RadioButton();
            this.cboGrupo = new System.Windows.Forms.ComboBox();
            this._pnlEtiqueta_7 = new AxThreed.AxSSPanel();
            this._pnlEtiqueta_7Label_Text = new System.Windows.Forms.Label();
            this._pnlEtiqueta_6 = new AxThreed.AxSSPanel();
            this._pnlEtiqueta_6Label_Text = new System.Windows.Forms.Label();
            this._pnlEtiqueta_2 = new AxThreed.AxSSPanel();
            this._pnlEtiqueta_2Label_Text = new System.Windows.Forms.Label();
            this._pnlEtiqueta_3 = new AxThreed.AxSSPanel();
            this._pnlEtiqueta_3Label_Text = new System.Windows.Forms.Label();
            this._pnlEtiqueta_0 = new AxThreed.AxSSPanel();
            this._pnlEtiqueta_0Label_Text = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.fpsDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsDatos_Sheet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.crReporBnx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPrincipal)).BeginInit();
            this.pnlPrincipal.SuspendLayout();
            this.fraReportes.SuspendLayout();
            this.frmTipo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEtiqueta_7)).BeginInit();
            this._pnlEtiqueta_7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEtiqueta_6)).BeginInit();
            this._pnlEtiqueta_6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEtiqueta_2)).BeginInit();
            this._pnlEtiqueta_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEtiqueta_3)).BeginInit();
            this._pnlEtiqueta_3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._pnlEtiqueta_0)).BeginInit();
            this._pnlEtiqueta_0.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpsDatos
            // 
            this.fpsDatos.AccessibleDescription = "";
            this.fpsDatos.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpsDatos.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsDatos.HorizontalScrollBar.Name = "";
            this.fpsDatos.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpsDatos.HorizontalScrollBar.TabIndex = 4;
            this.fpsDatos.Location = new System.Drawing.Point(197, 233);
            this.fpsDatos.Name = "fpsDatos";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            this.fpsDatos.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2});
            this.fpsDatos.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpsDatos_Sheet1});
            this.fpsDatos.Size = new System.Drawing.Size(75, 38);
            this.fpsDatos.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpsDatos.TabIndex = 30;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpsDatos.TextTipAppearance = tipAppearance1;
            this.fpsDatos.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsDatos.VerticalScrollBar.Name = "";
            this.fpsDatos.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpsDatos.VerticalScrollBar.TabIndex = 5;
            this.fpsDatos.Visible = false;
            this.fpsDatos.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // fpsDatos_Sheet1
            // 
            this.fpsDatos_Sheet1.Reset();
            this.fpsDatos_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsDatos_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsDatos_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsDatos_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsDatos_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpsDatos_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsDatos_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsDatos_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsDatos_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsDatos_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpsDatos_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsDatos_Sheet1.DefaultStyleName = "Text268635412858489154059";
            this.fpsDatos_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsDatos_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpsDatos_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsDatos_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpsDatos_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsDatos_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsDatos_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpsDatos_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsDatos_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsDatos_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // crReporBnx
            // 
            this.crReporBnx.Enabled = true;
            this.crReporBnx.Location = new System.Drawing.Point(264, 84);
            this.crReporBnx.Name = "crReporBnx";
            this.crReporBnx.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("crReporBnx.OcxState")));
            this.crReporBnx.Size = new System.Drawing.Size(28, 28);
            this.crReporBnx.TabIndex = 28;
            this.crReporBnx.Tag = "";
            // 
            // lstEmpresas
            // 
            this.lstEmpresas.BackColor = System.Drawing.Color.White;
            this.lstEmpresas.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEmpresas.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstEmpresas.Location = new System.Drawing.Point(8, 410);
            this.lstEmpresas.Name = "lstEmpresas";
            this.lstEmpresas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstEmpresas.Size = new System.Drawing.Size(223, 43);
            this.lstEmpresas.Sorted = true;
            this.lstEmpresas.TabIndex = 21;
            this.lstEmpresas.Tag = "";
            this.lstEmpresas.DoubleClick += new System.EventHandler(this.lstEmpresas_DoubleClick);
            // 
            // lstSeleccion
            // 
            this.lstSeleccion.BackColor = System.Drawing.Color.White;
            this.lstSeleccion.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstSeleccion.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstSeleccion.Location = new System.Drawing.Point(23, 401);
            this.lstSeleccion.Name = "lstSeleccion";
            this.lstSeleccion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstSeleccion.Size = new System.Drawing.Size(218, 43);
            this.lstSeleccion.Sorted = true;
            this.lstSeleccion.TabIndex = 20;
            this.lstSeleccion.Tag = "";
            this.lstSeleccion.DoubleClick += new System.EventHandler(this.lstSeleccion_DoubleClick);
            // 
            // cmdDel
            // 
            this.cmdDel.BackColor = System.Drawing.SystemColors.Control;
            this.cmdDel.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdDel.Location = new System.Drawing.Point(149, 430);
            this.cmdDel.Name = "cmdDel";
            this.cmdDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdDel.Size = new System.Drawing.Size(25, 25);
            this.cmdDel.TabIndex = 19;
            this.cmdDel.Tag = "";
            this.cmdDel.Text = "<";
            this.cmdDel.UseVisualStyleBackColor = false;
            this.cmdDel.Click += new System.EventHandler(this.cmdDel_Click);
            // 
            // cmdDelAll
            // 
            this.cmdDelAll.BackColor = System.Drawing.SystemColors.Control;
            this.cmdDelAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdDelAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdDelAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdDelAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdDelAll.Location = new System.Drawing.Point(78, 425);
            this.cmdDelAll.Name = "cmdDelAll";
            this.cmdDelAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdDelAll.Size = new System.Drawing.Size(25, 25);
            this.cmdDelAll.TabIndex = 18;
            this.cmdDelAll.Tag = "";
            this.cmdDelAll.Text = "<<";
            this.cmdDelAll.UseVisualStyleBackColor = false;
            this.cmdDelAll.Click += new System.EventHandler(this.cmdDelAll_Click);
            // 
            // cmdAdd
            // 
            this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdAdd.Location = new System.Drawing.Point(30, 425);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdAdd.Size = new System.Drawing.Size(25, 23);
            this.cmdAdd.TabIndex = 17;
            this.cmdAdd.Tag = "";
            this.cmdAdd.Text = ">";
            this.cmdAdd.UseVisualStyleBackColor = false;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdAll
            // 
            this.cmdAll.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAll.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdAll.Location = new System.Drawing.Point(146, 414);
            this.cmdAll.Name = "cmdAll";
            this.cmdAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdAll.Size = new System.Drawing.Size(25, 25);
            this.cmdAll.TabIndex = 16;
            this.cmdAll.Tag = "";
            this.cmdAll.Text = ">>";
            this.cmdAll.UseVisualStyleBackColor = false;
            this.cmdAll.Click += new System.EventHandler(this.cmdAll_Click);
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.BackColor = System.Drawing.SystemColors.Control;
            this.cmdAceptar.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdAceptar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAceptar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdAceptar.Location = new System.Drawing.Point(224, 185);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdAceptar.Size = new System.Drawing.Size(81, 28);
            this.cmdAceptar.TabIndex = 9;
            this.cmdAceptar.Tag = "";
            this.cmdAceptar.Text = "&Aceptar";
            this.cmdAceptar.UseVisualStyleBackColor = false;
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.BackColor = System.Drawing.SystemColors.Control;
            this.cmdSalir.Cursor = System.Windows.Forms.Cursors.Default;
            this.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdSalir.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmdSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalir.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdSalir.Location = new System.Drawing.Point(313, 187);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cmdSalir.Size = new System.Drawing.Size(81, 26);
            this.cmdSalir.TabIndex = 10;
            this.cmdSalir.Tag = "";
            this.cmdSalir.Text = "&Salir";
            this.cmdSalir.UseVisualStyleBackColor = false;
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.Controls.Add(this.fraReportes);
            this.pnlPrincipal.Controls.Add(this.cboFecha);
            this.pnlPrincipal.Controls.Add(this.txtIdentificador);
            this.pnlPrincipal.Controls.Add(this._lblPeriodo_0);
            this.pnlPrincipal.Controls.Add(this.Label1);
            this.pnlPrincipal.Controls.Add(this.frmTipo);
            this.pnlPrincipal.Controls.Add(this.cboGrupo);
            this.pnlPrincipal.Location = new System.Drawing.Point(6, 4);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("pnlPrincipal.OcxState")));
            this.pnlPrincipal.Size = new System.Drawing.Size(609, 173);
            this.pnlPrincipal.TabIndex = 11;
            this.pnlPrincipal.Tag = "";
            // 
            // fraReportes
            // 
            this.fraReportes.BackColor = System.Drawing.SystemColors.Control;
            this.fraReportes.Controls.Add(this._optNivel_3);
            this.fraReportes.Controls.Add(this.chkOpcion);
            this.fraReportes.Controls.Add(this._optNivel_4);
            this.fraReportes.Controls.Add(this._optNivel_2);
            this.fraReportes.Controls.Add(this._optNivel_1);
            this.fraReportes.Controls.Add(this._optNivel_0);
            this.fraReportes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fraReportes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.fraReportes.Location = new System.Drawing.Point(15, 10);
            this.fraReportes.Name = "fraReportes";
            this.fraReportes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fraReportes.Size = new System.Drawing.Size(350, 115);
            this.fraReportes.TabIndex = 13;
            this.fraReportes.TabStop = false;
            this.fraReportes.Tag = "";
            this.fraReportes.Text = "Nivel";
            // 
            // _optNivel_3
            // 
            this._optNivel_3.BackColor = System.Drawing.SystemColors.Control;
            this._optNivel_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._optNivel_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optNivel_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optNivel_3.Location = new System.Drawing.Point(16, 75);
            this._optNivel_3.Name = "_optNivel_3";
            this._optNivel_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optNivel_3.Size = new System.Drawing.Size(184, 16);
            this._optNivel_3.TabIndex = 3;
            this._optNivel_3.TabStop = true;
            this._optNivel_3.Tag = "";
            this._optNivel_3.Text = "Subdirección (Subdivisión)";
            this._optNivel_3.UseVisualStyleBackColor = false;
            this._optNivel_3.CheckedChanged += new System.EventHandler(this.optNivel_CheckedChanged);
            // 
            // chkOpcion
            // 
            this.chkOpcion.BackColor = System.Drawing.SystemColors.Control;
            this.chkOpcion.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkOpcion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOpcion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkOpcion.Location = new System.Drawing.Point(232, 22);
            this.chkOpcion.Name = "chkOpcion";
            this.chkOpcion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkOpcion.Size = new System.Drawing.Size(112, 17);
            this.chkOpcion.TabIndex = 28;
            this.chkOpcion.Tag = "";
            this.chkOpcion.Text = "Imprimir Todo";
            this.chkOpcion.UseVisualStyleBackColor = false;
            // 
            // _optNivel_4
            // 
            this._optNivel_4.BackColor = System.Drawing.SystemColors.Control;
            this._optNivel_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._optNivel_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optNivel_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optNivel_4.Location = new System.Drawing.Point(16, 93);
            this._optNivel_4.Name = "_optNivel_4";
            this._optNivel_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optNivel_4.Size = new System.Drawing.Size(79, 16);
            this._optNivel_4.TabIndex = 4;
            this._optNivel_4.TabStop = true;
            this._optNivel_4.Tag = "";
            this._optNivel_4.Text = "SIRH";
            this._optNivel_4.UseVisualStyleBackColor = false;
            this._optNivel_4.CheckedChanged += new System.EventHandler(this.optNivel_CheckedChanged);
            // 
            // _optNivel_2
            // 
            this._optNivel_2.BackColor = System.Drawing.SystemColors.Control;
            this._optNivel_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._optNivel_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optNivel_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optNivel_2.Location = new System.Drawing.Point(16, 57);
            this._optNivel_2.Name = "_optNivel_2";
            this._optNivel_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optNivel_2.Size = new System.Drawing.Size(152, 16);
            this._optNivel_2.TabIndex = 2;
            this._optNivel_2.TabStop = true;
            this._optNivel_2.Tag = "";
            this._optNivel_2.Text = "Dirección (División)";
            this._optNivel_2.UseVisualStyleBackColor = false;
            this._optNivel_2.CheckedChanged += new System.EventHandler(this.optNivel_CheckedChanged);
            // 
            // _optNivel_1
            // 
            this._optNivel_1.BackColor = System.Drawing.SystemColors.Control;
            this._optNivel_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._optNivel_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optNivel_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optNivel_1.Location = new System.Drawing.Point(16, 39);
            this._optNivel_1.Name = "_optNivel_1";
            this._optNivel_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optNivel_1.Size = new System.Drawing.Size(196, 16);
            this._optNivel_1.TabIndex = 1;
            this._optNivel_1.TabStop = true;
            this._optNivel_1.Tag = "";
            this._optNivel_1.Text = "Dirección General Adjunta (Area)";
            this._optNivel_1.UseVisualStyleBackColor = false;
            this._optNivel_1.CheckedChanged += new System.EventHandler(this.optNivel_CheckedChanged);
            // 
            // _optNivel_0
            // 
            this._optNivel_0.BackColor = System.Drawing.SystemColors.Control;
            this._optNivel_0.Checked = true;
            this._optNivel_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._optNivel_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optNivel_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optNivel_0.Location = new System.Drawing.Point(16, 21);
            this._optNivel_0.Name = "_optNivel_0";
            this._optNivel_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optNivel_0.Size = new System.Drawing.Size(79, 16);
            this._optNivel_0.TabIndex = 0;
            this._optNivel_0.TabStop = true;
            this._optNivel_0.Tag = "";
            this._optNivel_0.Text = "Banco";
            this._optNivel_0.UseVisualStyleBackColor = false;
            this._optNivel_0.CheckedChanged += new System.EventHandler(this.optNivel_CheckedChanged);
            // 
            // cboFecha
            // 
            this.cboFecha.BackColor = System.Drawing.Color.White;
            this.cboFecha.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboFecha.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboFecha.Location = new System.Drawing.Point(467, 88);
            this.cboFecha.Name = "cboFecha";
            this.cboFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboFecha.Size = new System.Drawing.Size(126, 21);
            this.cboFecha.TabIndex = 7;
            this.cboFecha.Tag = "";
            // 
            // txtIdentificador
            // 
            this.txtIdentificador.AcceptsReturn = true;
            this.txtIdentificador.BackColor = System.Drawing.Color.White;
            this.txtIdentificador.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtIdentificador.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdentificador.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txtIdentificador.Location = new System.Drawing.Point(466, 116);
            this.txtIdentificador.MaxLength = 10;
            this.txtIdentificador.Multiline = true;
            this.txtIdentificador.Name = "txtIdentificador";
            this.txtIdentificador.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtIdentificador.Size = new System.Drawing.Size(81, 21);
            this.txtIdentificador.TabIndex = 8;
            this.txtIdentificador.Tag = "";
            this.txtIdentificador.Text = "0\r\n";
            this.txtIdentificador.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtIdentificador.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtIdentificador_KeyPress);
            this.txtIdentificador.Leave += new System.EventHandler(this.txtIdentificador_Leave);
            // 
            // _lblPeriodo_0
            // 
            this._lblPeriodo_0.AutoSize = true;
            this._lblPeriodo_0.BackColor = System.Drawing.SystemColors.Control;
            this._lblPeriodo_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._lblPeriodo_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblPeriodo_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._lblPeriodo_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._lblPeriodo_0.Location = new System.Drawing.Point(383, 93);
            this._lblPeriodo_0.Name = "_lblPeriodo_0";
            this._lblPeriodo_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._lblPeriodo_0.Size = new System.Drawing.Size(83, 13);
            this._lblPeriodo_0.TabIndex = 14;
            this._lblPeriodo_0.Tag = "";
            this._lblPeriodo_0.Text = "Fecha de Corte:";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.BackColor = System.Drawing.SystemColors.Control;
            this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Label1.Location = new System.Drawing.Point(382, 123);
            this.Label1.Name = "Label1";
            this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Label1.Size = new System.Drawing.Size(71, 13);
            this.Label1.TabIndex = 15;
            this.Label1.Tag = "";
            this.Label1.Text = "Identificador :";
            // 
            // frmTipo
            // 
            this.frmTipo.BackColor = System.Drawing.SystemColors.Control;
            this.frmTipo.Controls.Add(this._optTipo_0);
            this.frmTipo.Controls.Add(this._optTipo_1);
            this.frmTipo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.frmTipo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.frmTipo.Location = new System.Drawing.Point(375, 12);
            this.frmTipo.Name = "frmTipo";
            this.frmTipo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.frmTipo.Size = new System.Drawing.Size(218, 68);
            this.frmTipo.TabIndex = 12;
            this.frmTipo.TabStop = false;
            this.frmTipo.Tag = "";
            this.frmTipo.Text = "Tipo";
            // 
            // _optTipo_0
            // 
            this._optTipo_0.BackColor = System.Drawing.SystemColors.Control;
            this._optTipo_0.Checked = true;
            this._optTipo_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._optTipo_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optTipo_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optTipo_0.Location = new System.Drawing.Point(29, 16);
            this._optTipo_0.Name = "_optTipo_0";
            this._optTipo_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optTipo_0.Size = new System.Drawing.Size(148, 22);
            this._optTipo_0.TabIndex = 5;
            this._optTipo_0.TabStop = true;
            this._optTipo_0.Tag = "";
            this._optTipo_0.Text = "Concentrado";
            this._optTipo_0.UseVisualStyleBackColor = false;
            this._optTipo_0.CheckedChanged += new System.EventHandler(this.optTipo_CheckedChanged);
            // 
            // _optTipo_1
            // 
            this._optTipo_1.BackColor = System.Drawing.SystemColors.Control;
            this._optTipo_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._optTipo_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._optTipo_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._optTipo_1.Location = new System.Drawing.Point(29, 36);
            this._optTipo_1.Name = "_optTipo_1";
            this._optTipo_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._optTipo_1.Size = new System.Drawing.Size(106, 22);
            this._optTipo_1.TabIndex = 6;
            this._optTipo_1.TabStop = true;
            this._optTipo_1.Tag = "";
            this._optTipo_1.Text = "Giros";
            this._optTipo_1.UseVisualStyleBackColor = false;
            this._optTipo_1.CheckedChanged += new System.EventHandler(this.optTipo_CheckedChanged);
            // 
            // cboGrupo
            // 
            this.cboGrupo.BackColor = System.Drawing.Color.White;
            this.cboGrupo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGrupo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboGrupo.Location = new System.Drawing.Point(18, 138);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboGrupo.Size = new System.Drawing.Size(218, 21);
            this.cboGrupo.Sorted = true;
            this.cboGrupo.TabIndex = 26;
            this.cboGrupo.Tag = "";
            this.cboGrupo.SelectedIndexChanged += new System.EventHandler(this.cboGrupo_SelectedIndexChanged);
            // 
            // _pnlEtiqueta_7
            // 
            this._pnlEtiqueta_7.Controls.Add(this._pnlEtiqueta_7Label_Text);
            this._pnlEtiqueta_7.Location = new System.Drawing.Point(9, 389);
            this._pnlEtiqueta_7.Name = "_pnlEtiqueta_7";
            this._pnlEtiqueta_7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlEtiqueta_7.OcxState")));
            this._pnlEtiqueta_7.Size = new System.Drawing.Size(49, 21);
            this._pnlEtiqueta_7.TabIndex = 22;
            this._pnlEtiqueta_7.Tag = "";
            // 
            // _pnlEtiqueta_7Label_Text
            // 
            this._pnlEtiqueta_7Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._pnlEtiqueta_7Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
            this._pnlEtiqueta_7Label_Text.Location = new System.Drawing.Point(0, 0);
            this._pnlEtiqueta_7Label_Text.Name = "_pnlEtiqueta_7Label_Text";
            this._pnlEtiqueta_7Label_Text.Size = new System.Drawing.Size(49, 21);
            this._pnlEtiqueta_7Label_Text.TabIndex = 0;
            this._pnlEtiqueta_7Label_Text.Tag = "";
            this._pnlEtiqueta_7Label_Text.Text = "No.";
            this._pnlEtiqueta_7Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _pnlEtiqueta_6
            // 
            this._pnlEtiqueta_6.Controls.Add(this._pnlEtiqueta_6Label_Text);
            this._pnlEtiqueta_6.Location = new System.Drawing.Point(58, 388);
            this._pnlEtiqueta_6.Name = "_pnlEtiqueta_6";
            this._pnlEtiqueta_6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlEtiqueta_6.OcxState")));
            this._pnlEtiqueta_6.Size = new System.Drawing.Size(174, 21);
            this._pnlEtiqueta_6.TabIndex = 23;
            this._pnlEtiqueta_6.Tag = "";
            // 
            // _pnlEtiqueta_6Label_Text
            // 
            this._pnlEtiqueta_6Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._pnlEtiqueta_6Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
            this._pnlEtiqueta_6Label_Text.Location = new System.Drawing.Point(0, 0);
            this._pnlEtiqueta_6Label_Text.Name = "_pnlEtiqueta_6Label_Text";
            this._pnlEtiqueta_6Label_Text.Size = new System.Drawing.Size(174, 21);
            this._pnlEtiqueta_6Label_Text.TabIndex = 0;
            this._pnlEtiqueta_6Label_Text.Tag = "";
            this._pnlEtiqueta_6Label_Text.Text = "&Subnivel";
            this._pnlEtiqueta_6Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _pnlEtiqueta_2
            // 
            this._pnlEtiqueta_2.Controls.Add(this._pnlEtiqueta_2Label_Text);
            this._pnlEtiqueta_2.Location = new System.Drawing.Point(57, 395);
            this._pnlEtiqueta_2.Name = "_pnlEtiqueta_2";
            this._pnlEtiqueta_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlEtiqueta_2.OcxState")));
            this._pnlEtiqueta_2.Size = new System.Drawing.Size(49, 21);
            this._pnlEtiqueta_2.TabIndex = 24;
            this._pnlEtiqueta_2.Tag = "";
            // 
            // _pnlEtiqueta_2Label_Text
            // 
            this._pnlEtiqueta_2Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._pnlEtiqueta_2Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
            this._pnlEtiqueta_2Label_Text.Location = new System.Drawing.Point(0, 0);
            this._pnlEtiqueta_2Label_Text.Name = "_pnlEtiqueta_2Label_Text";
            this._pnlEtiqueta_2Label_Text.Size = new System.Drawing.Size(49, 21);
            this._pnlEtiqueta_2Label_Text.TabIndex = 0;
            this._pnlEtiqueta_2Label_Text.Tag = "";
            this._pnlEtiqueta_2Label_Text.Text = "No.";
            this._pnlEtiqueta_2Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _pnlEtiqueta_3
            // 
            this._pnlEtiqueta_3.Controls.Add(this._pnlEtiqueta_3Label_Text);
            this._pnlEtiqueta_3.Location = new System.Drawing.Point(39, 390);
            this._pnlEtiqueta_3.Name = "_pnlEtiqueta_3";
            this._pnlEtiqueta_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlEtiqueta_3.OcxState")));
            this._pnlEtiqueta_3.Size = new System.Drawing.Size(168, 21);
            this._pnlEtiqueta_3.TabIndex = 25;
            this._pnlEtiqueta_3.Tag = "";
            // 
            // _pnlEtiqueta_3Label_Text
            // 
            this._pnlEtiqueta_3Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._pnlEtiqueta_3Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
            this._pnlEtiqueta_3Label_Text.Location = new System.Drawing.Point(0, 0);
            this._pnlEtiqueta_3Label_Text.Name = "_pnlEtiqueta_3Label_Text";
            this._pnlEtiqueta_3Label_Text.Size = new System.Drawing.Size(168, 21);
            this._pnlEtiqueta_3Label_Text.TabIndex = 0;
            this._pnlEtiqueta_3Label_Text.Tag = "";
            this._pnlEtiqueta_3Label_Text.Text = "&Subnivel";
            this._pnlEtiqueta_3Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _pnlEtiqueta_0
            // 
            this._pnlEtiqueta_0.Controls.Add(this._pnlEtiqueta_0Label_Text);
            this._pnlEtiqueta_0.Location = new System.Drawing.Point(21, 420);
            this._pnlEtiqueta_0.Name = "_pnlEtiqueta_0";
            this._pnlEtiqueta_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_pnlEtiqueta_0.OcxState")));
            this._pnlEtiqueta_0.Size = new System.Drawing.Size(44, 21);
            this._pnlEtiqueta_0.TabIndex = 27;
            this._pnlEtiqueta_0.Tag = "";
            // 
            // _pnlEtiqueta_0Label_Text
            // 
            this._pnlEtiqueta_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._pnlEtiqueta_0Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
            this._pnlEtiqueta_0Label_Text.Location = new System.Drawing.Point(0, 0);
            this._pnlEtiqueta_0Label_Text.Name = "_pnlEtiqueta_0Label_Text";
            this._pnlEtiqueta_0Label_Text.Size = new System.Drawing.Size(44, 21);
            this._pnlEtiqueta_0Label_Text.TabIndex = 0;
            this._pnlEtiqueta_0Label_Text.Tag = "";
            this._pnlEtiqueta_0Label_Text.Text = " &Nivel";
            this._pnlEtiqueta_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CORCTBNX
            // 
            this.AcceptButton = this.cmdAceptar;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.cmdSalir;
            this.ClientSize = new System.Drawing.Size(626, 220);
            this.Controls.Add(this.fpsDatos);
            this.Controls.Add(this.lstSeleccion);
            this.Controls.Add(this.lstEmpresas);
            this.Controls.Add(this.cmdDelAll);
            this.Controls.Add(this.cmdDel);
            this.Controls.Add(this._pnlEtiqueta_3);
            this.Controls.Add(this._pnlEtiqueta_0);
            this.Controls.Add(this.crReporBnx);
            this.Controls.Add(this._pnlEtiqueta_7);
            this.Controls.Add(this._pnlEtiqueta_6);
            this.Controls.Add(this.pnlPrincipal);
            this.Controls.Add(this.cmdSalir);
            this.Controls.Add(this.cmdAll);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this._pnlEtiqueta_2);
            this.Controls.Add(this.cmdAceptar);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(93, 172);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORCTBNX";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Reportes de Banamex";
            this.Closed += new System.EventHandler(this.CORCTBNX_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.fpsDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsDatos_Sheet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.crReporBnx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlPrincipal)).EndInit();
            this.pnlPrincipal.ResumeLayout(false);
            this.pnlPrincipal.PerformLayout();
            this.fraReportes.ResumeLayout(false);
            this.frmTipo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pnlEtiqueta_7)).EndInit();
            this._pnlEtiqueta_7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pnlEtiqueta_6)).EndInit();
            this._pnlEtiqueta_6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pnlEtiqueta_2)).EndInit();
            this._pnlEtiqueta_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pnlEtiqueta_3)).EndInit();
            this._pnlEtiqueta_3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._pnlEtiqueta_0)).EndInit();
            this._pnlEtiqueta_0.ResumeLayout(false);
            this.ResumeLayout(false);

	}
	void  InitializeoptNivel()
	{
			this.optNivel[4] = _optNivel_4;
			this.optNivel[3] = _optNivel_3;
			this.optNivel[2] = _optNivel_2;
			this.optNivel[1] = _optNivel_1;
			this.optNivel[0] = _optNivel_0;
	}
	void  InitializeoptTipo()
	{
			this.optTipo[0] = _optTipo_0;
			this.optTipo[1] = _optTipo_1;
	}
	void  InitializelblPeriodo()
	{
			this.lblPeriodo[0] = _lblPeriodo_0;
	}
	void  InitializepnlEtiqueta()
	{
			this.pnlEtiqueta[7] = _pnlEtiqueta_7;
			this.pnlEtiqueta[6] = _pnlEtiqueta_6;
			this.pnlEtiqueta[2] = _pnlEtiqueta_2;
			this.pnlEtiqueta[3] = _pnlEtiqueta_3;
			this.pnlEtiqueta[0] = _pnlEtiqueta_0;
	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpsDatos;
    private FarPoint.Win.Spread.SheetView fpsDatos_Sheet1;
}
}