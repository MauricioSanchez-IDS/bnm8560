using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class RangosCats
	{
	
#region "Upgrade Support "
		private static RangosCats m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static RangosCats DefInstance
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
		public RangosCats():base(){
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
			InitializeSSPanel1();
			InitializeTXT_CAT();
			InitializeFrame1();
			InitializeCMD_RAN_CAT();
			InitializeSSPanel2();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static RangosCats CreateInstance()
	{
			RangosCats theInstance = new RangosCats();
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
    public Softtek.Util.Win.Spread.SpreadWrapper ID_CEJ_PROD_SS;
	private  System.Windows.Forms.TextBox _TXT_CAT_1;
	private  System.Windows.Forms.Button _CMD_RAN_CAT_4;
	private  System.Windows.Forms.Button _CMD_RAN_CAT_5;
	private  System.Windows.Forms.Button _CMD_RAN_CAT_6;
	private  System.Windows.Forms.Label _SSPanel1_1Label_Text;
	private  AxThreed.AxSSPanel _SSPanel1_1;
	private  System.Windows.Forms.GroupBox _Frame1_1;
	private  System.Windows.Forms.Label _SSPanel2_0Label_Text;
	private  AxThreed.AxSSPanel _SSPanel2_0;
	public  System.Windows.Forms.ListBox LST_RAG;
	private  System.Windows.Forms.Button _CMD_RAN_CAT_3;
	private  System.Windows.Forms.Button _CMD_RAN_CAT_2;
	private  System.Windows.Forms.Button _CMD_RAN_CAT_1;
	private  System.Windows.Forms.Label _SSPanel1_0Label_Text;
	private  AxThreed.AxSSPanel _SSPanel1_0;
	private  System.Windows.Forms.Button _CMD_RAN_CAT_0;
	private  System.Windows.Forms.TextBox _TXT_CAT_0;
	private  System.Windows.Forms.Label _SSPanel2_1Label_Text;
	private  AxThreed.AxSSPanel _SSPanel2_1;
	private  System.Windows.Forms.GroupBox _Frame1_0;
	public System.Windows.Forms.Button[] CMD_RAN_CAT = new System.Windows.Forms.Button[7];
	public System.Windows.Forms.GroupBox[] Frame1 = new System.Windows.Forms.GroupBox[2];
	public AxThreed.AxSSPanel[] SSPanel1 = new AxThreed.AxSSPanel[2];
	public AxThreed.AxSSPanel[] SSPanel2 = new AxThreed.AxSSPanel[2];
	public System.Windows.Forms.TextBox[] TXT_CAT = new System.Windows.Forms.TextBox[2];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RangosCats));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color65635410410481039684", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text347635410410481049683", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.NamedStyle namedStyle3 = new FarPoint.Win.Spread.NamedStyle("Number675635410410481079680");
            FarPoint.Win.Spread.CellType.NumberCellType numberCellType1 = new FarPoint.Win.Spread.CellType.NumberCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.InputMap fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal;
            FarPoint.Win.Spread.InputMap fpsID_CEJ_PROD_SS_InputMapWhenFocusedReadOnly;
            FarPoint.Win.Spread.InputMap fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode;
            FarPoint.Win.Spread.InputMap fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal;
            FarPoint.Win.Spread.InputMap fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly;
            FarPoint.Win.Spread.InputMap fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode;
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this._Frame1_1 = new System.Windows.Forms.GroupBox();
            this._CMD_RAN_CAT_4 = new System.Windows.Forms.Button();
            this.ID_CEJ_PROD_SS = new Softtek.Util.Win.Spread.SpreadWrapper(fpsID_CEJ_PROD_SS);
            this._TXT_CAT_1 = new System.Windows.Forms.TextBox();
            this._SSPanel1_1 = new AxThreed.AxSSPanel();
            this._SSPanel1_1Label_Text = new System.Windows.Forms.Label();
            this._CMD_RAN_CAT_5 = new System.Windows.Forms.Button();
            this._CMD_RAN_CAT_6 = new System.Windows.Forms.Button();
            this._Frame1_0 = new System.Windows.Forms.GroupBox();
            this._SSPanel2_0 = new AxThreed.AxSSPanel();
            this._SSPanel2_0Label_Text = new System.Windows.Forms.Label();
            this._TXT_CAT_0 = new System.Windows.Forms.TextBox();
            this._CMD_RAN_CAT_0 = new System.Windows.Forms.Button();
            this.LST_RAG = new System.Windows.Forms.ListBox();
            this._CMD_RAN_CAT_1 = new System.Windows.Forms.Button();
            this._SSPanel1_0 = new AxThreed.AxSSPanel();
            this._SSPanel1_0Label_Text = new System.Windows.Forms.Label();
            this._CMD_RAN_CAT_3 = new System.Windows.Forms.Button();
            this._CMD_RAN_CAT_2 = new System.Windows.Forms.Button();
            this._SSPanel2_1 = new AxThreed.AxSSPanel();
            this._SSPanel2_1Label_Text = new System.Windows.Forms.Label();
            this.fpsID_CEJ_PROD_SS = new FarPoint.Win.Spread.FpSpread();
            this.fpsID_CEJ_PROD_SS_Sheet1 = new FarPoint.Win.Spread.SheetView();
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal = new FarPoint.Win.Spread.InputMap();
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Parent = new FarPoint.Win.Spread.InputMap();
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedReadOnly = new FarPoint.Win.Spread.InputMap();
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedReadOnly.Parent = new FarPoint.Win.Spread.InputMap();
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode = new FarPoint.Win.Spread.InputMap();
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Parent = new FarPoint.Win.Spread.InputMap();
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal = new FarPoint.Win.Spread.InputMap();
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent = new FarPoint.Win.Spread.InputMap();
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly = new FarPoint.Win.Spread.InputMap();
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Parent = new FarPoint.Win.Spread.InputMap();
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode = new FarPoint.Win.Spread.InputMap();
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent = new FarPoint.Win.Spread.InputMap();
            this._Frame1_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_1)).BeginInit();
            this._SSPanel1_1.SuspendLayout();
            this._Frame1_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SSPanel2_0)).BeginInit();
            this._SSPanel2_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_0)).BeginInit();
            this._SSPanel1_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SSPanel2_1)).BeginInit();
            this._SSPanel2_1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fpsID_CEJ_PROD_SS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsID_CEJ_PROD_SS_Sheet1)).BeginInit();
            this.SuspendLayout();
            // 
            // _Frame1_1
            // 
            this._Frame1_1.BackColor = System.Drawing.SystemColors.Control;
            this._Frame1_1.Controls.Add(this.fpsID_CEJ_PROD_SS);
            this._Frame1_1.Controls.Add(this._CMD_RAN_CAT_4);
            this._Frame1_1.Controls.Add(this._TXT_CAT_1);
            this._Frame1_1.Controls.Add(this._SSPanel1_1);
            this._Frame1_1.Controls.Add(this._CMD_RAN_CAT_5);
            this._Frame1_1.Controls.Add(this._CMD_RAN_CAT_6);
            this._Frame1_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Frame1_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Frame1_1.Location = new System.Drawing.Point(0, 203);
            this._Frame1_1.Name = "_Frame1_1";
            this._Frame1_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Frame1_1.Size = new System.Drawing.Size(353, 193);
            this._Frame1_1.TabIndex = 10;
            this._Frame1_1.TabStop = false;
            this._Frame1_1.Tag = "";
            this._Frame1_1.Text = "Rangos";
            // 
            // _CMD_RAN_CAT_4
            // 
            this._CMD_RAN_CAT_4.BackColor = System.Drawing.SystemColors.Control;
            this._CMD_RAN_CAT_4.Cursor = System.Windows.Forms.Cursors.Default;
            this._CMD_RAN_CAT_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._CMD_RAN_CAT_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CMD_RAN_CAT_4.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CMD_RAN_CAT_4.Location = new System.Drawing.Point(256, 57);
            this._CMD_RAN_CAT_4.Name = "_CMD_RAN_CAT_4";
            this._CMD_RAN_CAT_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CMD_RAN_CAT_4.Size = new System.Drawing.Size(92, 25);
            this._CMD_RAN_CAT_4.TabIndex = 4;
            this._CMD_RAN_CAT_4.Tag = "";
            this._CMD_RAN_CAT_4.Text = "Aceptar";
            this._CMD_RAN_CAT_4.UseVisualStyleBackColor = false;
            this._CMD_RAN_CAT_4.Click += new System.EventHandler(this.CMD_RAN_CAT_Click);
            // 
            // ID_CEJ_PROD_SS
            // 
            this.fpsID_CEJ_PROD_SS.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ID_CEJ_PROD_SS_KeyDown);
            // 
            // _TXT_CAT_1
            // 
            this._TXT_CAT_1.AcceptsReturn = true;
            this._TXT_CAT_1.BackColor = System.Drawing.SystemColors.Window;
            this._TXT_CAT_1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._TXT_CAT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TXT_CAT_1.ForeColor = System.Drawing.SystemColors.WindowText;
            this._TXT_CAT_1.Location = new System.Drawing.Point(96, 22);
            this._TXT_CAT_1.MaxLength = 0;
            this._TXT_CAT_1.Name = "_TXT_CAT_1";
            this._TXT_CAT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._TXT_CAT_1.Size = new System.Drawing.Size(153, 20);
            this._TXT_CAT_1.TabIndex = 13;
            this._TXT_CAT_1.Tag = "";
            // 
            // _SSPanel1_1
            // 
            this._SSPanel1_1.Controls.Add(this._SSPanel1_1Label_Text);
            this._SSPanel1_1.Location = new System.Drawing.Point(25, 23);
            this._SSPanel1_1.Name = "_SSPanel1_1";
            this._SSPanel1_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_SSPanel1_1.OcxState")));
            this._SSPanel1_1.Size = new System.Drawing.Size(68, 19);
            this._SSPanel1_1.TabIndex = 12;
            this._SSPanel1_1.Tag = "";
            // 
            // _SSPanel1_1Label_Text
            // 
            this._SSPanel1_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._SSPanel1_1Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._SSPanel1_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._SSPanel1_1Label_Text.Location = new System.Drawing.Point(0, 0);
            this._SSPanel1_1Label_Text.Name = "_SSPanel1_1Label_Text";
            this._SSPanel1_1Label_Text.Size = new System.Drawing.Size(68, 19);
            this._SSPanel1_1Label_Text.TabIndex = 0;
            this._SSPanel1_1Label_Text.Tag = "";
            this._SSPanel1_1Label_Text.Text = "Categoría";
            this._SSPanel1_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _CMD_RAN_CAT_5
            // 
            this._CMD_RAN_CAT_5.BackColor = System.Drawing.SystemColors.Control;
            this._CMD_RAN_CAT_5.Cursor = System.Windows.Forms.Cursors.Default;
            this._CMD_RAN_CAT_5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._CMD_RAN_CAT_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CMD_RAN_CAT_5.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CMD_RAN_CAT_5.Location = new System.Drawing.Point(255, 99);
            this._CMD_RAN_CAT_5.Name = "_CMD_RAN_CAT_5";
            this._CMD_RAN_CAT_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CMD_RAN_CAT_5.Size = new System.Drawing.Size(92, 25);
            this._CMD_RAN_CAT_5.TabIndex = 5;
            this._CMD_RAN_CAT_5.Tag = "";
            this._CMD_RAN_CAT_5.Text = "Listar MCC";
            this._CMD_RAN_CAT_5.UseVisualStyleBackColor = false;
            this._CMD_RAN_CAT_5.Click += new System.EventHandler(this.CMD_RAN_CAT_Click);
            // 
            // _CMD_RAN_CAT_6
            // 
            this._CMD_RAN_CAT_6.BackColor = System.Drawing.SystemColors.Control;
            this._CMD_RAN_CAT_6.Cursor = System.Windows.Forms.Cursors.Default;
            this._CMD_RAN_CAT_6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._CMD_RAN_CAT_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CMD_RAN_CAT_6.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CMD_RAN_CAT_6.Location = new System.Drawing.Point(255, 140);
            this._CMD_RAN_CAT_6.Name = "_CMD_RAN_CAT_6";
            this._CMD_RAN_CAT_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CMD_RAN_CAT_6.Size = new System.Drawing.Size(92, 25);
            this._CMD_RAN_CAT_6.TabIndex = 6;
            this._CMD_RAN_CAT_6.Tag = "";
            this._CMD_RAN_CAT_6.Text = "Cancelar";
            this._CMD_RAN_CAT_6.UseVisualStyleBackColor = false;
            this._CMD_RAN_CAT_6.Click += new System.EventHandler(this.CMD_RAN_CAT_Click);
            // 
            // _Frame1_0
            // 
            this._Frame1_0.BackColor = System.Drawing.SystemColors.Control;
            this._Frame1_0.Controls.Add(this._SSPanel2_0);
            this._Frame1_0.Controls.Add(this._TXT_CAT_0);
            this._Frame1_0.Controls.Add(this._CMD_RAN_CAT_0);
            this._Frame1_0.Controls.Add(this.LST_RAG);
            this._Frame1_0.Controls.Add(this._CMD_RAN_CAT_1);
            this._Frame1_0.Controls.Add(this._SSPanel1_0);
            this._Frame1_0.Controls.Add(this._CMD_RAN_CAT_3);
            this._Frame1_0.Controls.Add(this._CMD_RAN_CAT_2);
            this._Frame1_0.Controls.Add(this._SSPanel2_1);
            this._Frame1_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._Frame1_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._Frame1_0.Location = new System.Drawing.Point(0, 0);
            this._Frame1_0.Name = "_Frame1_0";
            this._Frame1_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._Frame1_0.Size = new System.Drawing.Size(353, 193);
            this._Frame1_0.TabIndex = 7;
            this._Frame1_0.TabStop = false;
            this._Frame1_0.Tag = "";
            this._Frame1_0.Text = "Rangos";
            // 
            // _SSPanel2_0
            // 
            this._SSPanel2_0.Controls.Add(this._SSPanel2_0Label_Text);
            this._SSPanel2_0.Location = new System.Drawing.Point(17, 55);
            this._SSPanel2_0.Name = "_SSPanel2_0";
            this._SSPanel2_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_SSPanel2_0.OcxState")));
            this._SSPanel2_0.Size = new System.Drawing.Size(111, 20);
            this._SSPanel2_0.TabIndex = 15;
            this._SSPanel2_0.Tag = "";
            // 
            // _SSPanel2_0Label_Text
            // 
            this._SSPanel2_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._SSPanel2_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._SSPanel2_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._SSPanel2_0Label_Text.Location = new System.Drawing.Point(0, 0);
            this._SSPanel2_0Label_Text.Name = "_SSPanel2_0Label_Text";
            this._SSPanel2_0Label_Text.Size = new System.Drawing.Size(111, 20);
            this._SSPanel2_0Label_Text.TabIndex = 0;
            this._SSPanel2_0Label_Text.Tag = "";
            this._SSPanel2_0Label_Text.Text = "Rango Inicial";
            this._SSPanel2_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _TXT_CAT_0
            // 
            this._TXT_CAT_0.AcceptsReturn = true;
            this._TXT_CAT_0.BackColor = System.Drawing.SystemColors.Window;
            this._TXT_CAT_0.Cursor = System.Windows.Forms.Cursors.IBeam;
            this._TXT_CAT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._TXT_CAT_0.ForeColor = System.Drawing.SystemColors.WindowText;
            this._TXT_CAT_0.Location = new System.Drawing.Point(94, 22);
            this._TXT_CAT_0.MaxLength = 0;
            this._TXT_CAT_0.Name = "_TXT_CAT_0";
            this._TXT_CAT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._TXT_CAT_0.Size = new System.Drawing.Size(152, 20);
            this._TXT_CAT_0.TabIndex = 8;
            this._TXT_CAT_0.Tag = "";
            // 
            // _CMD_RAN_CAT_0
            // 
            this._CMD_RAN_CAT_0.BackColor = System.Drawing.SystemColors.Control;
            this._CMD_RAN_CAT_0.Cursor = System.Windows.Forms.Cursors.Default;
            this._CMD_RAN_CAT_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._CMD_RAN_CAT_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CMD_RAN_CAT_0.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CMD_RAN_CAT_0.Location = new System.Drawing.Point(255, 57);
            this._CMD_RAN_CAT_0.Name = "_CMD_RAN_CAT_0";
            this._CMD_RAN_CAT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CMD_RAN_CAT_0.Size = new System.Drawing.Size(92, 25);
            this._CMD_RAN_CAT_0.TabIndex = 0;
            this._CMD_RAN_CAT_0.Tag = "";
            this._CMD_RAN_CAT_0.Text = "Altas...";
            this._CMD_RAN_CAT_0.UseVisualStyleBackColor = false;
            this._CMD_RAN_CAT_0.Click += new System.EventHandler(this.CMD_RAN_CAT_Click);
            // 
            // LST_RAG
            // 
            this.LST_RAG.BackColor = System.Drawing.SystemColors.Window;
            this.LST_RAG.Cursor = System.Windows.Forms.Cursors.Default;
            this.LST_RAG.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LST_RAG.ForeColor = System.Drawing.SystemColors.WindowText;
            this.LST_RAG.ItemHeight = 14;
            this.LST_RAG.Location = new System.Drawing.Point(16, 75);
            this.LST_RAG.Name = "LST_RAG";
            this.LST_RAG.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.LST_RAG.Size = new System.Drawing.Size(230, 102);
            this.LST_RAG.TabIndex = 14;
            this.LST_RAG.Tag = "";
            // 
            // _CMD_RAN_CAT_1
            // 
            this._CMD_RAN_CAT_1.BackColor = System.Drawing.SystemColors.Control;
            this._CMD_RAN_CAT_1.Cursor = System.Windows.Forms.Cursors.Default;
            this._CMD_RAN_CAT_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._CMD_RAN_CAT_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CMD_RAN_CAT_1.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CMD_RAN_CAT_1.Location = new System.Drawing.Point(255, 83);
            this._CMD_RAN_CAT_1.Name = "_CMD_RAN_CAT_1";
            this._CMD_RAN_CAT_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CMD_RAN_CAT_1.Size = new System.Drawing.Size(92, 25);
            this._CMD_RAN_CAT_1.TabIndex = 1;
            this._CMD_RAN_CAT_1.Tag = "";
            this._CMD_RAN_CAT_1.Text = "Bajas...";
            this._CMD_RAN_CAT_1.UseVisualStyleBackColor = false;
            this._CMD_RAN_CAT_1.Click += new System.EventHandler(this.CMD_RAN_CAT_Click);
            // 
            // _SSPanel1_0
            // 
            this._SSPanel1_0.Controls.Add(this._SSPanel1_0Label_Text);
            this._SSPanel1_0.Location = new System.Drawing.Point(23, 23);
            this._SSPanel1_0.Name = "_SSPanel1_0";
            this._SSPanel1_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_SSPanel1_0.OcxState")));
            this._SSPanel1_0.Size = new System.Drawing.Size(68, 19);
            this._SSPanel1_0.TabIndex = 9;
            this._SSPanel1_0.Tag = "";
            // 
            // _SSPanel1_0Label_Text
            // 
            this._SSPanel1_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._SSPanel1_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._SSPanel1_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._SSPanel1_0Label_Text.Location = new System.Drawing.Point(0, 0);
            this._SSPanel1_0Label_Text.Name = "_SSPanel1_0Label_Text";
            this._SSPanel1_0Label_Text.Size = new System.Drawing.Size(68, 19);
            this._SSPanel1_0Label_Text.TabIndex = 0;
            this._SSPanel1_0Label_Text.Tag = "";
            this._SSPanel1_0Label_Text.Text = "Categoría";
            this._SSPanel1_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // _CMD_RAN_CAT_3
            // 
            this._CMD_RAN_CAT_3.BackColor = System.Drawing.SystemColors.Control;
            this._CMD_RAN_CAT_3.Cursor = System.Windows.Forms.Cursors.Default;
            this._CMD_RAN_CAT_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._CMD_RAN_CAT_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CMD_RAN_CAT_3.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CMD_RAN_CAT_3.Location = new System.Drawing.Point(255, 153);
            this._CMD_RAN_CAT_3.Name = "_CMD_RAN_CAT_3";
            this._CMD_RAN_CAT_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CMD_RAN_CAT_3.Size = new System.Drawing.Size(92, 25);
            this._CMD_RAN_CAT_3.TabIndex = 3;
            this._CMD_RAN_CAT_3.Tag = "";
            this._CMD_RAN_CAT_3.Text = "Salir...";
            this._CMD_RAN_CAT_3.UseVisualStyleBackColor = false;
            this._CMD_RAN_CAT_3.Click += new System.EventHandler(this.CMD_RAN_CAT_Click);
            // 
            // _CMD_RAN_CAT_2
            // 
            this._CMD_RAN_CAT_2.BackColor = System.Drawing.SystemColors.Control;
            this._CMD_RAN_CAT_2.Cursor = System.Windows.Forms.Cursors.Default;
            this._CMD_RAN_CAT_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._CMD_RAN_CAT_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._CMD_RAN_CAT_2.ForeColor = System.Drawing.SystemColors.ControlText;
            this._CMD_RAN_CAT_2.Location = new System.Drawing.Point(255, 109);
            this._CMD_RAN_CAT_2.Name = "_CMD_RAN_CAT_2";
            this._CMD_RAN_CAT_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._CMD_RAN_CAT_2.Size = new System.Drawing.Size(92, 25);
            this._CMD_RAN_CAT_2.TabIndex = 2;
            this._CMD_RAN_CAT_2.Tag = "";
            this._CMD_RAN_CAT_2.Text = "Cambios...";
            this._CMD_RAN_CAT_2.UseVisualStyleBackColor = false;
            this._CMD_RAN_CAT_2.Click += new System.EventHandler(this.CMD_RAN_CAT_Click);
            // 
            // _SSPanel2_1
            // 
            this._SSPanel2_1.Controls.Add(this._SSPanel2_1Label_Text);
            this._SSPanel2_1.Location = new System.Drawing.Point(128, 55);
            this._SSPanel2_1.Name = "_SSPanel2_1";
            this._SSPanel2_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_SSPanel2_1.OcxState")));
            this._SSPanel2_1.Size = new System.Drawing.Size(119, 20);
            this._SSPanel2_1.TabIndex = 16;
            this._SSPanel2_1.Tag = "";
            // 
            // _SSPanel2_1Label_Text
            // 
            this._SSPanel2_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._SSPanel2_1Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._SSPanel2_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this._SSPanel2_1Label_Text.Location = new System.Drawing.Point(0, 0);
            this._SSPanel2_1Label_Text.Name = "_SSPanel2_1Label_Text";
            this._SSPanel2_1Label_Text.Size = new System.Drawing.Size(119, 20);
            this._SSPanel2_1Label_Text.TabIndex = 0;
            this._SSPanel2_1Label_Text.Tag = "";
            this._SSPanel2_1Label_Text.Text = "Rango Final";
            this._SSPanel2_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fpsID_CEJ_PROD_SS
            // 
            this.fpsID_CEJ_PROD_SS.AccessibleDescription = "";
            this.fpsID_CEJ_PROD_SS.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpsID_CEJ_PROD_SS.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsID_CEJ_PROD_SS.HorizontalScrollBar.Name = "";
            this.fpsID_CEJ_PROD_SS.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpsID_CEJ_PROD_SS.HorizontalScrollBar.TabIndex = 4;
            this.fpsID_CEJ_PROD_SS.Location = new System.Drawing.Point(23, 57);
            this.fpsID_CEJ_PROD_SS.Name = "fpsID_CEJ_PROD_SS";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            numberCellType1.MaximumValue = 99999999D;
            numberCellType1.MinimumValue = 0D;
            namedStyle3.CellType = numberCellType1;
            namedStyle3.HorizontalAlignment = FarPoint.Win.Spread.CellHorizontalAlignment.Right;
            namedStyle3.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle3.Renderer = numberCellType1;
            this.fpsID_CEJ_PROD_SS.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2,
            namedStyle3});
            this.fpsID_CEJ_PROD_SS.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpsID_CEJ_PROD_SS_Sheet1});
            this.fpsID_CEJ_PROD_SS.Size = new System.Drawing.Size(226, 122);
            this.fpsID_CEJ_PROD_SS.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpsID_CEJ_PROD_SS.TabIndex = 14;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpsID_CEJ_PROD_SS.TextTipAppearance = tipAppearance1;
            this.fpsID_CEJ_PROD_SS.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpsID_CEJ_PROD_SS.VerticalScrollBar.Name = "";
            this.fpsID_CEJ_PROD_SS.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpsID_CEJ_PROD_SS.VerticalScrollBar.TabIndex = 5;
            this.fpsID_CEJ_PROD_SS.VisualStyles = FarPoint.Win.VisualStyles.Off;
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Return, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.StartEditing);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Tab, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Tab, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToPreviousColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                    | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                    | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Back, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.StartEditing);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Return, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.StartEditing);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke('='), FarPoint.Win.Spread.SpreadActions.StartEditingFormula);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.C, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ClipboardCopy);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.V, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ClipboardPasteAll);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.X, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ClipboardCut);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Insert, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ClipboardCopy);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Delete, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ClipboardCut);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Insert, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ClipboardPasteAll);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.F4, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ShowSubEditor);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Space, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.SelectRow);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Z, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.Undo);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Y, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.Redo);
            this.fpsID_CEJ_PROD_SS.SetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, FarPoint.Win.Spread.OperationMode.Normal, fpsID_CEJ_PROD_SS_InputMapWhenFocusedNormal);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedReadOnly.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Tab, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedReadOnly.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Tab, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToPreviousColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.C, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ClipboardCopy);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Insert, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ClipboardCopy);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Z, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.Undo);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Y, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.Redo);
            this.fpsID_CEJ_PROD_SS.SetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, FarPoint.Win.Spread.OperationMode.ReadOnly, fpsID_CEJ_PROD_SS_InputMapWhenFocusedReadOnly);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Return, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.StartEditing);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                    | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                    | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.None);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Return, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.StartEditing);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke('='), FarPoint.Win.Spread.SpreadActions.StartEditingFormula);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Down, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ComboShowList);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Up, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ComboShowList);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.F4, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ShowSubEditor);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Z, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.Undo);
            fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Y, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.Redo);
            this.fpsID_CEJ_PROD_SS.SetInputMap(FarPoint.Win.Spread.InputMapMode.WhenFocused, FarPoint.Win.Spread.OperationMode.RowMode, fpsID_CEJ_PROD_SS_InputMapWhenFocusedRowMode);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Return, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.StopEditing);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToPreviousRow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Down, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextRow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToPreviousColumnVisual);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnVisual);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Up, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToPreviousRow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Down, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToNextRow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToPreviousColumnVisual);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToNextColumnVisual);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Up, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToPreviousRow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Down, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToNextRow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToPreviousColumnVisual);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnVisual);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Up, ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                    | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToPreviousRow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Down, ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                    | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToNextRow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                    | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToPreviousColumnVisual);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                    | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToNextColumnVisual);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.PageUp, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToPreviousPageOfRows);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Next, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextPageOfRows);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.PageUp, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToPreviousPageOfColumns);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Next, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToNextPageOfColumns);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.PageUp, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToPreviousPageOfRows);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Next, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToNextPageOfRows);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.PageUp, ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                    | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToPreviousPageOfColumns);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Next, ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                    | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToNextPageOfColumns);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Home, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToFirstColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.End, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToLastColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Home, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToFirstCell);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.End, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToLastCell);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Home, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToFirstColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.End, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToLastColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Home, ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                    | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToFirstCell);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.End, ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                    | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ExtendToLastCell);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Space, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.SelectColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Space, ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
                    | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.SelectSheet);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Escape, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.CancelEditing);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Return, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.StopEditing);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Tab, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Tab, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToPreviousColumnWrap);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ClearCell);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.F3, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.DateTimeNow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.F4, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ShowSubEditor);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Down, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ComboShowList);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Up, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ComboShowList);
            this.fpsID_CEJ_PROD_SS.SetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, FarPoint.Win.Spread.OperationMode.Normal, fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedNormal);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Tab, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Tab, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToPreviousColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ScrollToPreviousRow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Down, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ScrollToNextRow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ScrollToPreviousColumnVisual);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ScrollToNextColumnVisual);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.PageUp, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ScrollToPreviousPageOfRows);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Next, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ScrollToNextPageOfRows);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.PageUp, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ScrollToPreviousPageOfColumns);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Next, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ScrollToNextPageOfColumns);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Home, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ScrollToFirstColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.End, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ScrollToLastColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Home, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ScrollToFirstCell);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.End, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ScrollToLastCell);
            this.fpsID_CEJ_PROD_SS.SetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, FarPoint.Win.Spread.OperationMode.ReadOnly, fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedReadOnly);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Return, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.StopEditing);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Up, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToPreviousRow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Down, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextRow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToPreviousColumnVisual);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnVisual);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Up, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToPreviousRow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Down, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToNextRow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Left, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToPreviousColumnVisual);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Right, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnVisual);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.PageUp, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToPreviousPageOfRows);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Next, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextPageOfRows);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.PageUp, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToPreviousPageOfColumns);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Next, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToNextPageOfColumns);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Home, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToFirstColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.End, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToLastColumn);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Home, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToFirstCell);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.End, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToLastCell);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Escape, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.CancelEditing);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Return, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.StopEditing);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Tab, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.MoveToNextColumnWrap);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Tab, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Shift | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.MoveToPreviousColumnWrap);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.F2, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ClearCell);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.F3, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.DateTimeNow);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.F4, System.Windows.Forms.Keys.None), FarPoint.Win.Spread.SpreadActions.ShowSubEditor);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Down, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ComboShowList);
            fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode.Parent.Put(new FarPoint.Win.Spread.Keystroke(System.Windows.Forms.Keys.Up, ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.None)))), FarPoint.Win.Spread.SpreadActions.ComboShowList);
            this.fpsID_CEJ_PROD_SS.SetInputMap(FarPoint.Win.Spread.InputMapMode.WhenAncestorOfFocused, FarPoint.Win.Spread.OperationMode.RowMode, fpsID_CEJ_PROD_SS_InputMapWhenAncestorOfFocusedRowMode);
            this.fpsID_CEJ_PROD_SS.SetViewportLeftColumn(0, 0, 2);
            this.fpsID_CEJ_PROD_SS.SetActiveViewport(0, 0, -1);
            // 
            // fpsID_CEJ_PROD_SS_Sheet1
            // 
            this.fpsID_CEJ_PROD_SS_Sheet1.Reset();
            this.fpsID_CEJ_PROD_SS_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpsID_CEJ_PROD_SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnCount = 2;
            this.fpsID_CEJ_PROD_SS_Sheet1.RowCount = 25;
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnFooter.Columns.Default.Resizable = true;
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnHeader.Cells.Get(0, 0).Value = "Rango inicial";
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnHeader.Cells.Get(0, 1).Value = "Rango final";
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnHeader.Columns.Default.Resizable = true;
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpsID_CEJ_PROD_SS_Sheet1.ColumnHeader.Rows.Get(0).Height = 15F;
            this.fpsID_CEJ_PROD_SS_Sheet1.Columns.Default.Resizable = true;
            this.fpsID_CEJ_PROD_SS_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpsID_CEJ_PROD_SS_Sheet1.Columns.Get(0).Label = "Rango inicial";
            this.fpsID_CEJ_PROD_SS_Sheet1.Columns.Get(0).StyleName = "Number675635410410481079680";
            this.fpsID_CEJ_PROD_SS_Sheet1.Columns.Get(0).Width = 96F;
            this.fpsID_CEJ_PROD_SS_Sheet1.Columns.Get(1).Label = "Rango final";
            this.fpsID_CEJ_PROD_SS_Sheet1.Columns.Get(1).StyleName = "Number675635410410481079680";
            this.fpsID_CEJ_PROD_SS_Sheet1.Columns.Get(1).Width = 112F;
            this.fpsID_CEJ_PROD_SS_Sheet1.DefaultStyleName = "Text347635410410481049683";
            this.fpsID_CEJ_PROD_SS_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CEJ_PROD_SS_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpsID_CEJ_PROD_SS_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CEJ_PROD_SS_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpsID_CEJ_PROD_SS_Sheet1.FrozenColumnCount = 2;
            this.fpsID_CEJ_PROD_SS_Sheet1.HorizontalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))));
            this.fpsID_CEJ_PROD_SS_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpsID_CEJ_PROD_SS_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpsID_CEJ_PROD_SS_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpsID_CEJ_PROD_SS_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CEJ_PROD_SS_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpsID_CEJ_PROD_SS_Sheet1.RowHeader.Rows.Default.Resizable = false;
            this.fpsID_CEJ_PROD_SS_Sheet1.RowHeader.Visible = false;
            this.fpsID_CEJ_PROD_SS_Sheet1.Rows.Default.Resizable = false;
            this.fpsID_CEJ_PROD_SS_Sheet1.Rows.Get(0).Height = 14F;
            this.fpsID_CEJ_PROD_SS_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.fpsID_CEJ_PROD_SS_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fpsID_CEJ_PROD_SS_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpsID_CEJ_PROD_SS_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpsID_CEJ_PROD_SS_Sheet1.VerticalGridLine = new FarPoint.Win.Spread.GridLine(FarPoint.Win.Spread.GridLineType.Flat, System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))));
            this.fpsID_CEJ_PROD_SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // RangosCats
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(353, 397);
            this.Controls.Add(this._Frame1_1);
            this.Controls.Add(this._Frame1_0);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Location = new System.Drawing.Point(219, 129);
            this.Name = "RangosCats";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Rangos de Categorías";
            this.Activated += new System.EventHandler(this.RangosCats_Activated);
            this.Closed += new System.EventHandler(this.RangosCats_Closed);
            this._Frame1_1.ResumeLayout(false);
            this._Frame1_1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_1)).EndInit();
            this._SSPanel1_1.ResumeLayout(false);
            this._Frame1_0.ResumeLayout(false);
            this._Frame1_0.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._SSPanel2_0)).EndInit();
            this._SSPanel2_0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_0)).EndInit();
            this._SSPanel1_0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._SSPanel2_1)).EndInit();
            this._SSPanel2_1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fpsID_CEJ_PROD_SS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpsID_CEJ_PROD_SS_Sheet1)).EndInit();
            this.ResumeLayout(false);

	}
	void  InitializeSSPanel1()
	{
			this.SSPanel1[1] = _SSPanel1_1;
			this.SSPanel1[0] = _SSPanel1_0;
	}
	void  InitializeTXT_CAT()
	{
			this.TXT_CAT[1] = _TXT_CAT_1;
			this.TXT_CAT[0] = _TXT_CAT_0;
	}
	void  InitializeFrame1()
	{
			this.Frame1[1] = _Frame1_1;
			this.Frame1[0] = _Frame1_0;
	}
	void  InitializeCMD_RAN_CAT()
	{
			this.CMD_RAN_CAT[4] = _CMD_RAN_CAT_4;
			this.CMD_RAN_CAT[5] = _CMD_RAN_CAT_5;
			this.CMD_RAN_CAT[6] = _CMD_RAN_CAT_6;
			this.CMD_RAN_CAT[3] = _CMD_RAN_CAT_3;
			this.CMD_RAN_CAT[2] = _CMD_RAN_CAT_2;
			this.CMD_RAN_CAT[1] = _CMD_RAN_CAT_1;
			this.CMD_RAN_CAT[0] = _CMD_RAN_CAT_0;
	}
	void  InitializeSSPanel2()
	{
			this.SSPanel2[0] = _SSPanel2_0;
			this.SSPanel2[1] = _SSPanel2_1;
	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpsID_CEJ_PROD_SS;
    private FarPoint.Win.Spread.SheetView fpsID_CEJ_PROD_SS_Sheet1;
}
}