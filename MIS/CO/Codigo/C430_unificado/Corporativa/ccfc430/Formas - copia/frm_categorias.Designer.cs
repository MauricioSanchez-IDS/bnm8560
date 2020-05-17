using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frm_categorias
	{
	
#region "Upgrade Support "
		private static frm_categorias m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_categorias DefInstance
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
		public frm_categorias():base(){
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
			InitializePAN_REP();
			InitializetxtTexto_Cat();
			InitializemkbMaskebox_Cat();
			InitializelblEtiqueta();
			InitializefrmFrame();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static frm_categorias CreateInstance()
	{
			frm_categorias theInstance = new frm_categorias();
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
	public  System.Windows.Forms.Button ID_MEE_ALT_PB;
	public  System.Windows.Forms.Button ID_MEE_CER_PB;
	public  System.Windows.Forms.ListBox LST_CAT;
	private  System.Windows.Forms.TextBox _txtTexto_Cat_1;
	private  System.Windows.Forms.TextBox _txtTexto_Cat_0;
	private  System.Windows.Forms.Label _lblEtiqueta_29;
	private  System.Windows.Forms.Label _lblEtiqueta_28;
	private  AxThreed.AxSSFrame _frmFrame_4;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Cat_0;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Cat_1;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Cat_2;
	private  System.Windows.Forms.Label _lblEtiqueta_32;
	private  System.Windows.Forms.Label _lblEtiqueta_31;
	private  System.Windows.Forms.Label _lblEtiqueta_30;
	private  AxThreed.AxSSFrame _frmFrame_5;
	public  System.Windows.Forms.Button CMD_ACT_CAT;
	public  System.Windows.Forms.ComboBox CMB_CAT;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Cat_3;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_Cat_4;
	private  System.Windows.Forms.Label _lblEtiqueta_36;
	private  System.Windows.Forms.Label _lblEtiqueta_35;
	private  System.Windows.Forms.Label _lblEtiqueta_33;
	public  AxThreed.AxSSFrame FRAM_CAT;
	private  System.Windows.Forms.Label _PAN_REP_5Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_5;
	private  System.Windows.Forms.Label _PAN_REP_6Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_6;
	private  System.Windows.Forms.Label _PAN_REP_7Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_7;
	private  System.Windows.Forms.Label _PAN_REP_9Label_Text;
	private  AxThreed.AxSSPanel _PAN_REP_9;
	public  AxThreed.AxSSPanel SSPanel1;
	public AxThreed.AxSSPanel[] PAN_REP = new AxThreed.AxSSPanel[10];
	public AxThreed.AxSSFrame[] frmFrame = new AxThreed.AxSSFrame[6];
	public System.Windows.Forms.Label[] lblEtiqueta = new System.Windows.Forms.Label[37];
	public AxMSMask.AxMaskEdBox[] mkbMaskebox_Cat = new AxMSMask.AxMaskEdBox[5];
	public System.Windows.Forms.TextBox[] txtTexto_Cat = new System.Windows.Forms.TextBox[2];
	private Artinsoft.VB6.Gui.ListControlHelper ListBoxComboBoxHelper1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_categorias));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.SSPanel1 = new AxThreed.AxSSPanel();
        this._frmFrame_5 = new AxThreed.AxSSFrame();
        this._mkbMaskebox_Cat_2 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_Cat_1 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_Cat_0 = new AxMSMask.AxMaskEdBox();
        this._lblEtiqueta_32 = new System.Windows.Forms.Label();
        this._lblEtiqueta_30 = new System.Windows.Forms.Label();
        this._lblEtiqueta_31 = new System.Windows.Forms.Label();
        this.FRAM_CAT = new AxThreed.AxSSFrame();
        this._mkbMaskebox_Cat_4 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_Cat_3 = new AxMSMask.AxMaskEdBox();
        this.CMB_CAT = new System.Windows.Forms.ComboBox();
        this._lblEtiqueta_33 = new System.Windows.Forms.Label();
        this._lblEtiqueta_35 = new System.Windows.Forms.Label();
        this._lblEtiqueta_36 = new System.Windows.Forms.Label();
        this.CMD_ACT_CAT = new System.Windows.Forms.Button();
        this.LST_CAT = new System.Windows.Forms.ListBox();
        this._frmFrame_4 = new AxThreed.AxSSFrame();
        this._txtTexto_Cat_0 = new System.Windows.Forms.TextBox();
        this._txtTexto_Cat_1 = new System.Windows.Forms.TextBox();
        this._lblEtiqueta_28 = new System.Windows.Forms.Label();
        this._lblEtiqueta_29 = new System.Windows.Forms.Label();
        this._PAN_REP_7 = new AxThreed.AxSSPanel();
        this._PAN_REP_7Label_Text = new System.Windows.Forms.Label();
        this._PAN_REP_9 = new AxThreed.AxSSPanel();
        this._PAN_REP_9Label_Text = new System.Windows.Forms.Label();
        this._PAN_REP_5 = new AxThreed.AxSSPanel();
        this._PAN_REP_5Label_Text = new System.Windows.Forms.Label();
        this._PAN_REP_6 = new AxThreed.AxSSPanel();
        this._PAN_REP_6Label_Text = new System.Windows.Forms.Label();
        this.ID_MEE_ALT_PB = new System.Windows.Forms.Button();
        this.ID_MEE_CER_PB = new System.Windows.Forms.Button();
        this.ListBoxComboBoxHelper1 = new Artinsoft.VB6.Gui.ListControlHelper(this.components);
        ((System.ComponentModel.ISupportInitialize)(this.SSPanel1)).BeginInit();
        this.SSPanel1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._frmFrame_5)).BeginInit();
        this._frmFrame_5.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.FRAM_CAT)).BeginInit();
        this.FRAM_CAT.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_4)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_3)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._frmFrame_4)).BeginInit();
        this._frmFrame_4.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_7)).BeginInit();
        this._PAN_REP_7.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_9)).BeginInit();
        this._PAN_REP_9.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_5)).BeginInit();
        this._PAN_REP_5.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_6)).BeginInit();
        this._PAN_REP_6.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).BeginInit();
        this.SuspendLayout();
        // 
        // SSPanel1
        // 
        this.SSPanel1.Controls.Add(this._frmFrame_5);
        this.SSPanel1.Controls.Add(this.FRAM_CAT);
        this.SSPanel1.Controls.Add(this.LST_CAT);
        this.SSPanel1.Controls.Add(this._frmFrame_4);
        this.SSPanel1.Controls.Add(this._PAN_REP_7);
        this.SSPanel1.Controls.Add(this._PAN_REP_9);
        this.SSPanel1.Controls.Add(this._PAN_REP_5);
        this.SSPanel1.Controls.Add(this._PAN_REP_6);
        this.SSPanel1.Controls.Add(this.ID_MEE_ALT_PB);
        this.SSPanel1.Controls.Add(this.ID_MEE_CER_PB);
        this.SSPanel1.Location = new System.Drawing.Point(1, 1);
        this.SSPanel1.Name = "SSPanel1";
        this.SSPanel1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SSPanel1.OcxState")));
        this.SSPanel1.Size = new System.Drawing.Size(573, 430);
        this.SSPanel1.TabIndex = 0;
        this.SSPanel1.Tag = "";
        // 
        // _frmFrame_5
        // 
        this._frmFrame_5.Controls.Add(this._mkbMaskebox_Cat_2);
        this._frmFrame_5.Controls.Add(this._mkbMaskebox_Cat_1);
        this._frmFrame_5.Controls.Add(this._mkbMaskebox_Cat_0);
        this._frmFrame_5.Controls.Add(this._lblEtiqueta_32);
        this._frmFrame_5.Controls.Add(this._lblEtiqueta_30);
        this._frmFrame_5.Controls.Add(this._lblEtiqueta_31);
        this._frmFrame_5.Location = new System.Drawing.Point(8, 53);
        this._frmFrame_5.Name = "_frmFrame_5";
        this._frmFrame_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_frmFrame_5.OcxState")));
        this._frmFrame_5.Size = new System.Drawing.Size(550, 46);
        this._frmFrame_5.TabIndex = 7;
        this._frmFrame_5.Tag = "";
        // 
        // _mkbMaskebox_Cat_2
        // 
        this._mkbMaskebox_Cat_2.Location = new System.Drawing.Point(494, 18);
        this._mkbMaskebox_Cat_2.Name = "_mkbMaskebox_Cat_2";
        this._mkbMaskebox_Cat_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Cat_2.OcxState")));
        this._mkbMaskebox_Cat_2.Size = new System.Drawing.Size(41, 21);
        this._mkbMaskebox_Cat_2.TabIndex = 10;
        this._mkbMaskebox_Cat_2.Tag = "";
        this._mkbMaskebox_Cat_2.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Cat_Validating);
        this._mkbMaskebox_Cat_2.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_Cat_KeyPressEvent);
        // 
        // _mkbMaskebox_Cat_1
        // 
        this._mkbMaskebox_Cat_1.Location = new System.Drawing.Point(212, 18);
        this._mkbMaskebox_Cat_1.Name = "_mkbMaskebox_Cat_1";
        this._mkbMaskebox_Cat_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Cat_1.OcxState")));
        this._mkbMaskebox_Cat_1.Size = new System.Drawing.Size(246, 21);
        this._mkbMaskebox_Cat_1.TabIndex = 9;
        this._mkbMaskebox_Cat_1.Tag = "";
        this._mkbMaskebox_Cat_1.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Cat_Validating);
        this._mkbMaskebox_Cat_1.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_Cat_KeyPressEvent);
        // 
        // _mkbMaskebox_Cat_0
        // 
        this._mkbMaskebox_Cat_0.Location = new System.Drawing.Point(51, 18);
        this._mkbMaskebox_Cat_0.Name = "_mkbMaskebox_Cat_0";
        this._mkbMaskebox_Cat_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Cat_0.OcxState")));
        this._mkbMaskebox_Cat_0.Size = new System.Drawing.Size(105, 21);
        this._mkbMaskebox_Cat_0.TabIndex = 8;
        this._mkbMaskebox_Cat_0.Tag = "";
        this._mkbMaskebox_Cat_0.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Cat_Validating);
        this._mkbMaskebox_Cat_0.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_Cat_KeyPressEvent);
        // 
        // _lblEtiqueta_32
        // 
        this._lblEtiqueta_32.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_32.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_32.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_32.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_32.Location = new System.Drawing.Point(164, 20);
        this._lblEtiqueta_32.Name = "_lblEtiqueta_32";
        this._lblEtiqueta_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_32.Size = new System.Drawing.Size(53, 17);
        this._lblEtiqueta_32.TabIndex = 13;
        this._lblEtiqueta_32.Tag = "";
        this._lblEtiqueta_32.Text = "Nombre";
        // 
        // _lblEtiqueta_30
        // 
        this._lblEtiqueta_30.AutoSize = true;
        this._lblEtiqueta_30.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_30.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_30.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_30.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_30.Location = new System.Drawing.Point(462, 22);
        this._lblEtiqueta_30.Name = "_lblEtiqueta_30";
        this._lblEtiqueta_30.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_30.Size = new System.Drawing.Size(31, 13);
        this._lblEtiqueta_30.TabIndex = 11;
        this._lblEtiqueta_30.Tag = "";
        this._lblEtiqueta_30.Text = "Nivel";
        // 
        // _lblEtiqueta_31
        // 
        this._lblEtiqueta_31.AutoSize = true;
        this._lblEtiqueta_31.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_31.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_31.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_31.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_31.Location = new System.Drawing.Point(11, 22);
        this._lblEtiqueta_31.Name = "_lblEtiqueta_31";
        this._lblEtiqueta_31.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_31.Size = new System.Drawing.Size(41, 13);
        this._lblEtiqueta_31.TabIndex = 12;
        this._lblEtiqueta_31.Tag = "";
        this._lblEtiqueta_31.Text = "Unidad";
        // 
        // FRAM_CAT
        // 
        this.FRAM_CAT.Controls.Add(this._mkbMaskebox_Cat_4);
        this.FRAM_CAT.Controls.Add(this._mkbMaskebox_Cat_3);
        this.FRAM_CAT.Controls.Add(this.CMB_CAT);
        this.FRAM_CAT.Controls.Add(this._lblEtiqueta_33);
        this.FRAM_CAT.Controls.Add(this._lblEtiqueta_35);
        this.FRAM_CAT.Controls.Add(this._lblEtiqueta_36);
        this.FRAM_CAT.Controls.Add(this.CMD_ACT_CAT);
        this.FRAM_CAT.Location = new System.Drawing.Point(8, 98);
        this.FRAM_CAT.Name = "FRAM_CAT";
        this.FRAM_CAT.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("FRAM_CAT.OcxState")));
        this.FRAM_CAT.Size = new System.Drawing.Size(550, 83);
        this.FRAM_CAT.TabIndex = 14;
        this.FRAM_CAT.Tag = "";
        // 
        // _mkbMaskebox_Cat_4
        // 
        this._mkbMaskebox_Cat_4.Location = new System.Drawing.Point(448, 29);
        this._mkbMaskebox_Cat_4.Name = "_mkbMaskebox_Cat_4";
        this._mkbMaskebox_Cat_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Cat_4.OcxState")));
        this._mkbMaskebox_Cat_4.Size = new System.Drawing.Size(47, 21);
        this._mkbMaskebox_Cat_4.TabIndex = 18;
        this._mkbMaskebox_Cat_4.Tag = "";
        this._mkbMaskebox_Cat_4.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Cat_Validating);
        this._mkbMaskebox_Cat_4.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_Cat_KeyPressEvent);
        // 
        // _mkbMaskebox_Cat_3
        // 
        this._mkbMaskebox_Cat_3.Location = new System.Drawing.Point(315, 30);
        this._mkbMaskebox_Cat_3.Name = "_mkbMaskebox_Cat_3";
        this._mkbMaskebox_Cat_3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_Cat_3.OcxState")));
        this._mkbMaskebox_Cat_3.Size = new System.Drawing.Size(95, 21);
        this._mkbMaskebox_Cat_3.TabIndex = 17;
        this._mkbMaskebox_Cat_3.Tag = "";
        this._mkbMaskebox_Cat_3.Validating += new System.ComponentModel.CancelEventHandler(this.mkbMaskebox_Cat_Validating);
        this._mkbMaskebox_Cat_3.KeyPressEvent += new AxMSMask.MaskEdBoxEvents_KeyPressEventHandler(this.mkbMaskebox_Cat_KeyPressEvent);
        // 
        // CMB_CAT
        // 
        this.CMB_CAT.BackColor = System.Drawing.SystemColors.Window;
        this.CMB_CAT.Cursor = System.Windows.Forms.Cursors.Default;
        this.CMB_CAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CMB_CAT.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ListBoxComboBoxHelper1.SetItemData(this.CMB_CAT, new int[0]);
        this.CMB_CAT.Location = new System.Drawing.Point(22, 31);
        this.CMB_CAT.Name = "CMB_CAT";
        this.CMB_CAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CMB_CAT.Size = new System.Drawing.Size(260, 21);
        this.CMB_CAT.TabIndex = 15;
        this.CMB_CAT.Tag = "";
        this.CMB_CAT.SelectionChangeCommitted += new System.EventHandler(this.CMB_CAT_SelectionChangeCommitted);
        // 
        // _lblEtiqueta_33
        // 
        this._lblEtiqueta_33.AutoSize = true;
        this._lblEtiqueta_33.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_33.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_33.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_33.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_33.Location = new System.Drawing.Point(102, 18);
        this._lblEtiqueta_33.Name = "_lblEtiqueta_33";
        this._lblEtiqueta_33.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_33.Size = new System.Drawing.Size(94, 13);
        this._lblEtiqueta_33.TabIndex = 19;
        this._lblEtiqueta_33.Tag = "";
        this._lblEtiqueta_33.Text = "Nombre Categoría";
        // 
        // _lblEtiqueta_35
        // 
        this._lblEtiqueta_35.AutoSize = true;
        this._lblEtiqueta_35.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_35.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_35.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_35.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_35.Location = new System.Drawing.Point(428, 16);
        this._lblEtiqueta_35.Name = "_lblEtiqueta_35";
        this._lblEtiqueta_35.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_35.Size = new System.Drawing.Size(95, 13);
        this._lblEtiqueta_35.TabIndex = 20;
        this._lblEtiqueta_35.Tag = "";
        this._lblEtiqueta_35.Text = "Porcentaje de Uso";
        // 
        // _lblEtiqueta_36
        // 
        this._lblEtiqueta_36.AutoSize = true;
        this._lblEtiqueta_36.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_36.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_36.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_36.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_36.Location = new System.Drawing.Point(324, 17);
        this._lblEtiqueta_36.Name = "_lblEtiqueta_36";
        this._lblEtiqueta_36.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_36.Size = new System.Drawing.Size(80, 13);
        this._lblEtiqueta_36.TabIndex = 21;
        this._lblEtiqueta_36.Tag = "";
        this._lblEtiqueta_36.Text = "Limite de Gasto";
        // 
        // CMD_ACT_CAT
        // 
        this.CMD_ACT_CAT.BackColor = System.Drawing.SystemColors.Control;
        this.CMD_ACT_CAT.Cursor = System.Windows.Forms.Cursors.Default;
        this.CMD_ACT_CAT.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.CMD_ACT_CAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CMD_ACT_CAT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.CMD_ACT_CAT.Location = new System.Drawing.Point(473, 56);
        this.CMD_ACT_CAT.Name = "CMD_ACT_CAT";
        this.CMD_ACT_CAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CMD_ACT_CAT.Size = new System.Drawing.Size(64, 20);
        this.CMD_ACT_CAT.TabIndex = 16;
        this.CMD_ACT_CAT.Tag = "";
        this.CMD_ACT_CAT.Text = "&Actualizar";
        this.CMD_ACT_CAT.UseVisualStyleBackColor = false;
        this.CMD_ACT_CAT.Click += new System.EventHandler(this.CMD_ACT_CAT_Click);
        // 
        // LST_CAT
        // 
        this.LST_CAT.BackColor = System.Drawing.SystemColors.Window;
        this.LST_CAT.Cursor = System.Windows.Forms.Cursors.Default;
        this.LST_CAT.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.LST_CAT.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ListBoxComboBoxHelper1.SetItemData(this.LST_CAT, new int[] {
            0});
        this.LST_CAT.ItemHeight = 14;
        this.LST_CAT.Items.AddRange(new object[] {
            "LST_CAT"});
        this.LST_CAT.Location = new System.Drawing.Point(9, 205);
        this.LST_CAT.Name = "LST_CAT";
        this.LST_CAT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.LST_CAT.Size = new System.Drawing.Size(548, 172);
        this.LST_CAT.TabIndex = 1;
        this.LST_CAT.Tag = "";
        // 
        // _frmFrame_4
        // 
        this._frmFrame_4.Controls.Add(this._txtTexto_Cat_0);
        this._frmFrame_4.Controls.Add(this._txtTexto_Cat_1);
        this._frmFrame_4.Controls.Add(this._lblEtiqueta_28);
        this._frmFrame_4.Controls.Add(this._lblEtiqueta_29);
        this._frmFrame_4.Location = new System.Drawing.Point(8, 5);
        this._frmFrame_4.Name = "_frmFrame_4";
        this._frmFrame_4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_frmFrame_4.OcxState")));
        this._frmFrame_4.Size = new System.Drawing.Size(550, 47);
        this._frmFrame_4.TabIndex = 2;
        this._frmFrame_4.Tag = "";
        // 
        // _txtTexto_Cat_0
        // 
        this._txtTexto_Cat_0.AcceptsReturn = true;
        this._txtTexto_Cat_0.BackColor = System.Drawing.Color.White;
        this._txtTexto_Cat_0.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_Cat_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_Cat_0.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_Cat_0.Location = new System.Drawing.Point(59, 17);
        this._txtTexto_Cat_0.MaxLength = 45;
        this._txtTexto_Cat_0.Name = "_txtTexto_Cat_0";
        this._txtTexto_Cat_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_Cat_0.Size = new System.Drawing.Size(317, 20);
        this._txtTexto_Cat_0.TabIndex = 3;
        this._txtTexto_Cat_0.TabStop = false;
        this._txtTexto_Cat_0.Tag = "";
        // 
        // _txtTexto_Cat_1
        // 
        this._txtTexto_Cat_1.AcceptsReturn = true;
        this._txtTexto_Cat_1.BackColor = System.Drawing.Color.White;
        this._txtTexto_Cat_1.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_Cat_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_Cat_1.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_Cat_1.Location = new System.Drawing.Point(430, 17);
        this._txtTexto_Cat_1.MaxLength = 45;
        this._txtTexto_Cat_1.Name = "_txtTexto_Cat_1";
        this._txtTexto_Cat_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_Cat_1.Size = new System.Drawing.Size(107, 20);
        this._txtTexto_Cat_1.TabIndex = 4;
        this._txtTexto_Cat_1.TabStop = false;
        this._txtTexto_Cat_1.Tag = "";
        // 
        // _lblEtiqueta_28
        // 
        this._lblEtiqueta_28.AutoSize = true;
        this._lblEtiqueta_28.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_28.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_28.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_28.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_28.Location = new System.Drawing.Point(385, 19);
        this._lblEtiqueta_28.Name = "_lblEtiqueta_28";
        this._lblEtiqueta_28.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_28.Size = new System.Drawing.Size(44, 13);
        this._lblEtiqueta_28.TabIndex = 5;
        this._lblEtiqueta_28.Tag = "";
        this._lblEtiqueta_28.Text = "&Número";
        // 
        // _lblEtiqueta_29
        // 
        this._lblEtiqueta_29.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_29.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_29.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_29.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_29.Location = new System.Drawing.Point(10, 19);
        this._lblEtiqueta_29.Name = "_lblEtiqueta_29";
        this._lblEtiqueta_29.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_29.Size = new System.Drawing.Size(49, 17);
        this._lblEtiqueta_29.TabIndex = 6;
        this._lblEtiqueta_29.Tag = "";
        this._lblEtiqueta_29.Text = "N&ombre";
        // 
        // _PAN_REP_7
        // 
        this._PAN_REP_7.Controls.Add(this._PAN_REP_7Label_Text);
        this._PAN_REP_7.Location = new System.Drawing.Point(444, 186);
        this._PAN_REP_7.Name = "_PAN_REP_7";
        this._PAN_REP_7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_7.OcxState")));
        this._PAN_REP_7.Size = new System.Drawing.Size(114, 20);
        this._PAN_REP_7.TabIndex = 24;
        this._PAN_REP_7.Tag = "";
        // 
        // _PAN_REP_7Label_Text
        // 
        this._PAN_REP_7Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._PAN_REP_7Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._PAN_REP_7Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._PAN_REP_7Label_Text.Location = new System.Drawing.Point(0, 0);
        this._PAN_REP_7Label_Text.Name = "_PAN_REP_7Label_Text";
        this._PAN_REP_7Label_Text.Size = new System.Drawing.Size(114, 20);
        this._PAN_REP_7Label_Text.TabIndex = 0;
        this._PAN_REP_7Label_Text.Tag = "";
        this._PAN_REP_7Label_Text.Text = "Porcentaje de Uso";
        this._PAN_REP_7Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _PAN_REP_9
        // 
        this._PAN_REP_9.Controls.Add(this._PAN_REP_9Label_Text);
        this._PAN_REP_9.Location = new System.Drawing.Point(9, 186);
        this._PAN_REP_9.Name = "_PAN_REP_9";
        this._PAN_REP_9.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_9.OcxState")));
        this._PAN_REP_9.Size = new System.Drawing.Size(25, 20);
        this._PAN_REP_9.TabIndex = 25;
        this._PAN_REP_9.Tag = "";
        // 
        // _PAN_REP_9Label_Text
        // 
        this._PAN_REP_9Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._PAN_REP_9Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._PAN_REP_9Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._PAN_REP_9Label_Text.Location = new System.Drawing.Point(0, 0);
        this._PAN_REP_9Label_Text.Name = "_PAN_REP_9Label_Text";
        this._PAN_REP_9Label_Text.Size = new System.Drawing.Size(25, 20);
        this._PAN_REP_9Label_Text.TabIndex = 0;
        this._PAN_REP_9Label_Text.Tag = "";
        this._PAN_REP_9Label_Text.Text = "ID";
        this._PAN_REP_9Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _PAN_REP_5
        // 
        this._PAN_REP_5.Controls.Add(this._PAN_REP_5Label_Text);
        this._PAN_REP_5.Location = new System.Drawing.Point(34, 186);
        this._PAN_REP_5.Name = "_PAN_REP_5";
        this._PAN_REP_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_5.OcxState")));
        this._PAN_REP_5.Size = new System.Drawing.Size(314, 20);
        this._PAN_REP_5.TabIndex = 22;
        this._PAN_REP_5.Tag = "";
        // 
        // _PAN_REP_5Label_Text
        // 
        this._PAN_REP_5Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._PAN_REP_5Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._PAN_REP_5Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._PAN_REP_5Label_Text.Location = new System.Drawing.Point(0, 0);
        this._PAN_REP_5Label_Text.Name = "_PAN_REP_5Label_Text";
        this._PAN_REP_5Label_Text.Size = new System.Drawing.Size(314, 20);
        this._PAN_REP_5Label_Text.TabIndex = 0;
        this._PAN_REP_5Label_Text.Tag = "";
        this._PAN_REP_5Label_Text.Text = "Nombre Categoria";
        this._PAN_REP_5Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _PAN_REP_6
        // 
        this._PAN_REP_6.Controls.Add(this._PAN_REP_6Label_Text);
        this._PAN_REP_6.Location = new System.Drawing.Point(348, 186);
        this._PAN_REP_6.Name = "_PAN_REP_6";
        this._PAN_REP_6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_PAN_REP_6.OcxState")));
        this._PAN_REP_6.Size = new System.Drawing.Size(96, 20);
        this._PAN_REP_6.TabIndex = 23;
        this._PAN_REP_6.Tag = "";
        // 
        // _PAN_REP_6Label_Text
        // 
        this._PAN_REP_6Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._PAN_REP_6Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._PAN_REP_6Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._PAN_REP_6Label_Text.Location = new System.Drawing.Point(0, 0);
        this._PAN_REP_6Label_Text.Name = "_PAN_REP_6Label_Text";
        this._PAN_REP_6Label_Text.Size = new System.Drawing.Size(96, 20);
        this._PAN_REP_6Label_Text.TabIndex = 0;
        this._PAN_REP_6Label_Text.Tag = "";
        this._PAN_REP_6Label_Text.Text = "Limite de Gasto";
        this._PAN_REP_6Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_MEE_ALT_PB
        // 
        this.ID_MEE_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_MEE_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_MEE_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_MEE_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_MEE_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_MEE_ALT_PB.Location = new System.Drawing.Point(184, 393);
        this.ID_MEE_ALT_PB.Name = "ID_MEE_ALT_PB";
        this.ID_MEE_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_MEE_ALT_PB.Size = new System.Drawing.Size(74, 22);
        this.ID_MEE_ALT_PB.TabIndex = 27;
        this.ID_MEE_ALT_PB.Tag = "";
        this.ID_MEE_ALT_PB.Text = "Aceptar";
        this.ID_MEE_ALT_PB.UseVisualStyleBackColor = false;
        this.ID_MEE_ALT_PB.Click += new System.EventHandler(this.ID_MEE_ALT_PB_Click);
        // 
        // ID_MEE_CER_PB
        // 
        this.ID_MEE_CER_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_MEE_CER_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_MEE_CER_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_MEE_CER_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_MEE_CER_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_MEE_CER_PB.Location = new System.Drawing.Point(302, 394);
        this.ID_MEE_CER_PB.Name = "ID_MEE_CER_PB";
        this.ID_MEE_CER_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_MEE_CER_PB.Size = new System.Drawing.Size(77, 22);
        this.ID_MEE_CER_PB.TabIndex = 26;
        this.ID_MEE_CER_PB.Tag = "Cancela";
        this.ID_MEE_CER_PB.Text = "Cancelar";
        this.ID_MEE_CER_PB.UseVisualStyleBackColor = false;
        this.ID_MEE_CER_PB.Click += new System.EventHandler(this.ID_MEE_CER_PB_Click);
        // 
        // frm_categorias
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(575, 432);
        this.Controls.Add(this.SSPanel1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(16, 129);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frm_categorias";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Categorias";
        this.Closed += new System.EventHandler(this.frm_categorias_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.SSPanel1)).EndInit();
        this.SSPanel1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._frmFrame_5)).EndInit();
        this._frmFrame_5.ResumeLayout(false);
        this._frmFrame_5.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.FRAM_CAT)).EndInit();
        this.FRAM_CAT.ResumeLayout(false);
        this.FRAM_CAT.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_4)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_Cat_3)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._frmFrame_4)).EndInit();
        this._frmFrame_4.ResumeLayout(false);
        this._frmFrame_4.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_7)).EndInit();
        this._PAN_REP_7.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_9)).EndInit();
        this._PAN_REP_9.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_5)).EndInit();
        this._PAN_REP_5.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._PAN_REP_6)).EndInit();
        this._PAN_REP_6.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializePAN_REP()
	{
			this.PAN_REP[5] = _PAN_REP_5;
			this.PAN_REP[6] = _PAN_REP_6;
			this.PAN_REP[7] = _PAN_REP_7;
			this.PAN_REP[9] = _PAN_REP_9;
	}
	void  InitializetxtTexto_Cat()
	{
			this.txtTexto_Cat[1] = _txtTexto_Cat_1;
			this.txtTexto_Cat[0] = _txtTexto_Cat_0;
	}
	void  InitializemkbMaskebox_Cat()
	{
			this.mkbMaskebox_Cat[0] = _mkbMaskebox_Cat_0;
			this.mkbMaskebox_Cat[1] = _mkbMaskebox_Cat_1;
			this.mkbMaskebox_Cat[2] = _mkbMaskebox_Cat_2;
			this.mkbMaskebox_Cat[3] = _mkbMaskebox_Cat_3;
			this.mkbMaskebox_Cat[4] = _mkbMaskebox_Cat_4;
	}
	void  InitializelblEtiqueta()
	{
			this.lblEtiqueta[29] = _lblEtiqueta_29;
			this.lblEtiqueta[28] = _lblEtiqueta_28;
			this.lblEtiqueta[32] = _lblEtiqueta_32;
			this.lblEtiqueta[31] = _lblEtiqueta_31;
			this.lblEtiqueta[30] = _lblEtiqueta_30;
			this.lblEtiqueta[36] = _lblEtiqueta_36;
			this.lblEtiqueta[35] = _lblEtiqueta_35;
			this.lblEtiqueta[33] = _lblEtiqueta_33;
	}
	void  InitializefrmFrame()
	{
			this.frmFrame[4] = _frmFrame_4;
			this.frmFrame[5] = _frmFrame_5;
	}
#endregion 
}
}