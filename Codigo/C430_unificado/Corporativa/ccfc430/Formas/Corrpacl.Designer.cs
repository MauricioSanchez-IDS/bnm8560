using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORRPACL
	{
	
#region "Upgrade Support "
		private static CORRPACL m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORRPACL DefInstance
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
		public CORRPACL():base(){
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
            ID_ACL_REP_SS = new Softtek.Util.Win.Spread.SpreadWrapper(fpID_ACL_REP_SS);
			InitializeHelp();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static CORRPACL CreateInstance()
	{
			CORRPACL theInstance = new CORRPACL();
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
    public Softtek.Util.Win.Spread.SpreadWrapper ID_ACL_REP_SS;
	private System.ComponentModel.IContainer components;
	public System.Windows.Forms.ToolTip ToolTip1;	
	public  System.Windows.Forms.Button ID_ACL_SAL_PB;
	public  System.Windows.Forms.Button ID_ACL_IMP_PB;
	public  System.Windows.Forms.PictureBox ID_ACL_COR_PIC;
	public  System.Windows.Forms.PictureBox ID_CEJ_LOG_IMG;
	public  System.Windows.Forms.Label ID_CEJ_BAN_LBL;
	public  System.Windows.Forms.Panel ID_CEJ_TIT_PNL;
	public  System.Windows.Forms.Button ID_ACL_REF_PB;
	public  AxMSMask.AxMaskEdBox ID_ACL_FEC_DTB;
	public  System.Windows.Forms.Label ID_ACL_FEC_PNLLabel_Text;
    public System.Windows.Forms.Panel ID_ACL_FEC_PNL;
	public  System.Windows.Forms.Label ID_DAT_CPM_LBL;
	public  System.Windows.Forms.Label ID_DAT_COL_LBL;
	public  System.Windows.Forms.Label ID_DAT_CAL_LBL;
	public  System.Windows.Forms.Label ID_DAT_EMP_LBL;
	public  System.Windows.Forms.Label ID_DAT_EJE_LBL;
	public  System.Windows.Forms.Panel ID_CEJ_IDE_PNL;
	public  AxMSComDlg.AxCommonDialog ID_REJ_ARC_CDG;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORRPACL));
            FarPoint.Win.Spread.DefaultFocusIndicatorRenderer defaultFocusIndicatorRenderer1 = new FarPoint.Win.Spread.DefaultFocusIndicatorRenderer();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer1 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            FarPoint.Win.Spread.NamedStyle namedStyle1 = new FarPoint.Win.Spread.NamedStyle("Color50635406140687975400", "DataAreaDefault");
            FarPoint.Win.Spread.NamedStyle namedStyle2 = new FarPoint.Win.Spread.NamedStyle("Text307635406140688015403", "DataAreaDefault");
            FarPoint.Win.Spread.CellType.TextCellType textCellType1 = new FarPoint.Win.Spread.CellType.TextCellType();
            FarPoint.Win.Spread.TipAppearance tipAppearance1 = new FarPoint.Win.Spread.TipAppearance();
            FarPoint.Win.Spread.DefaultScrollBarRenderer defaultScrollBarRenderer2 = new FarPoint.Win.Spread.DefaultScrollBarRenderer();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);            
            this.ID_ACL_SAL_PB = new System.Windows.Forms.Button();
            this.ID_ACL_IMP_PB = new System.Windows.Forms.Button();
            this.ID_CEJ_TIT_PNL = new System.Windows.Forms.Panel();
            this.ID_ACL_COR_PIC = new System.Windows.Forms.PictureBox();
            this.ID_CEJ_LOG_IMG = new System.Windows.Forms.PictureBox();
            this.ID_CEJ_BAN_LBL = new System.Windows.Forms.Label();
            this.ID_CEJ_IDE_PNL = new System.Windows.Forms.Panel();
            this.ID_DAT_COL_LBL = new System.Windows.Forms.Label();
            this.ID_DAT_CPM_LBL = new System.Windows.Forms.Label();
            this.ID_ACL_FEC_PNL = new System.Windows.Forms.Panel();
            this.ID_ACL_FEC_DTB = new AxMSMask.AxMaskEdBox();
            this.ID_ACL_FEC_PNLLabel_Text = new System.Windows.Forms.Label();
            this.ID_DAT_EJE_LBL = new System.Windows.Forms.Label();
            this.ID_DAT_EMP_LBL = new System.Windows.Forms.Label();
            this.ID_DAT_CAL_LBL = new System.Windows.Forms.Label();
            this.ID_ACL_REF_PB = new System.Windows.Forms.Button();
            this.ID_REJ_ARC_CDG = new AxMSComDlg.AxCommonDialog();
            this.fpID_ACL_REP_SS = new FarPoint.Win.Spread.FpSpread();
            this.fpID_ACL_REP_SS_Sheet1 = new FarPoint.Win.Spread.SheetView();            
            this.ID_CEJ_TIT_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_COR_PIC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEJ_LOG_IMG)).BeginInit();
            this.ID_CEJ_IDE_PNL.SuspendLayout();
            this.ID_ACL_FEC_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_FEC_DTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_REJ_ARC_CDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpID_ACL_REP_SS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpID_ACL_REP_SS_Sheet1)).BeginInit();
            this.SuspendLayout();
            
            // 
            // ID_ACL_SAL_PB
            // 
            this.ID_ACL_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_ACL_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_ACL_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_ACL_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_ACL_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_ACL_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_ACL_SAL_PB.Location = new System.Drawing.Point(519, 302);
            this.ID_ACL_SAL_PB.Name = "ID_ACL_SAL_PB";
            this.ID_ACL_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_ACL_SAL_PB.Size = new System.Drawing.Size(73, 25);
            this.ID_ACL_SAL_PB.TabIndex = 2;
            this.ID_ACL_SAL_PB.Tag = "";
            this.ID_ACL_SAL_PB.Text = "&Salir";
            this.ID_ACL_SAL_PB.UseVisualStyleBackColor = false;
            this.ID_ACL_SAL_PB.Click += new System.EventHandler(this.ID_ACL_SAL_PB_Click);
            // 
            // ID_ACL_IMP_PB
            // 
            this.ID_ACL_IMP_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_ACL_IMP_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_ACL_IMP_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_ACL_IMP_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_ACL_IMP_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_ACL_IMP_PB.Location = new System.Drawing.Point(438, 302);
            this.ID_ACL_IMP_PB.Name = "ID_ACL_IMP_PB";
            this.ID_ACL_IMP_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_ACL_IMP_PB.Size = new System.Drawing.Size(73, 25);
            this.ID_ACL_IMP_PB.TabIndex = 1;
            this.ID_ACL_IMP_PB.Tag = "";
            this.ID_ACL_IMP_PB.Text = "&Imprimir";
            this.ID_ACL_IMP_PB.UseVisualStyleBackColor = false;
            this.ID_ACL_IMP_PB.Click += new System.EventHandler(this.ID_ACL_IMP_PB_Click);
            // 
            // ID_CEJ_TIT_PNL
            // 
            this.ID_CEJ_TIT_PNL.Controls.Add(this.ID_ACL_COR_PIC);
            this.ID_CEJ_TIT_PNL.Controls.Add(this.ID_CEJ_LOG_IMG);
            this.ID_CEJ_TIT_PNL.Controls.Add(this.ID_CEJ_BAN_LBL);
            this.ID_CEJ_TIT_PNL.Location = new System.Drawing.Point(17, 6);
            this.ID_CEJ_TIT_PNL.Name = "ID_CEJ_TIT_PNL";
            this.ID_CEJ_TIT_PNL.Size = new System.Drawing.Size(577, 49);
            this.ID_CEJ_TIT_PNL.TabIndex = 0;
            this.ID_CEJ_TIT_PNL.Tag = "";
            // 
            // ID_ACL_COR_PIC
            // 
            this.ID_ACL_COR_PIC.BackColor = System.Drawing.Color.Gray;
            this.ID_ACL_COR_PIC.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_ACL_COR_PIC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_ACL_COR_PIC.Image = ((System.Drawing.Image)(resources.GetObject("ID_ACL_COR_PIC.Image")));
            this.ID_ACL_COR_PIC.Location = new System.Drawing.Point(395, 5);
            this.ID_ACL_COR_PIC.Name = "ID_ACL_COR_PIC";
            this.ID_ACL_COR_PIC.Size = new System.Drawing.Size(131, 31);
            this.ID_ACL_COR_PIC.TabIndex = 4;
            this.ID_ACL_COR_PIC.TabStop = false;
            this.ID_ACL_COR_PIC.Tag = "";
            // 
            // ID_CEJ_LOG_IMG
            // 
            this.ID_CEJ_LOG_IMG.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_LOG_IMG.Image = ((System.Drawing.Image)(resources.GetObject("ID_CEJ_LOG_IMG.Image")));
            this.ID_CEJ_LOG_IMG.Location = new System.Drawing.Point(10, 4);
            this.ID_CEJ_LOG_IMG.Name = "ID_CEJ_LOG_IMG";
            this.ID_CEJ_LOG_IMG.Size = new System.Drawing.Size(45, 43);
            this.ID_CEJ_LOG_IMG.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ID_CEJ_LOG_IMG.TabIndex = 5;
            this.ID_CEJ_LOG_IMG.TabStop = false;
            this.ID_CEJ_LOG_IMG.Tag = "";
            // 
            // ID_CEJ_BAN_LBL
            // 
            this.ID_CEJ_BAN_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_CEJ_BAN_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEJ_BAN_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEJ_BAN_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_BAN_LBL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEJ_BAN_LBL.Location = new System.Drawing.Point(61, 14);
            this.ID_CEJ_BAN_LBL.Name = "ID_CEJ_BAN_LBL";
            this.ID_CEJ_BAN_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEJ_BAN_LBL.Size = new System.Drawing.Size(118, 24);
            this.ID_CEJ_BAN_LBL.TabIndex = 5;
            this.ID_CEJ_BAN_LBL.Tag = "";
            this.ID_CEJ_BAN_LBL.Text = "Banamex";
            // 
            // ID_CEJ_IDE_PNL
            // 
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_DAT_COL_LBL);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_DAT_CPM_LBL);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_ACL_FEC_PNL);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_DAT_EJE_LBL);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_DAT_EMP_LBL);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_DAT_CAL_LBL);
            this.ID_CEJ_IDE_PNL.Controls.Add(this.ID_ACL_REF_PB);
            this.ID_CEJ_IDE_PNL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEJ_IDE_PNL.Location = new System.Drawing.Point(17, 56);
            this.ID_CEJ_IDE_PNL.Name = "ID_CEJ_IDE_PNL";
            this.ID_CEJ_IDE_PNL.Size = new System.Drawing.Size(577, 101);
            this.ID_CEJ_IDE_PNL.TabIndex = 3;
            this.ID_CEJ_IDE_PNL.Tag = "";
            // 
            // ID_DAT_COL_LBL
            // 
            this.ID_DAT_COL_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_DAT_COL_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DAT_COL_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_DAT_COL_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DAT_COL_LBL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_DAT_COL_LBL.Location = new System.Drawing.Point(25, 63);
            this.ID_DAT_COL_LBL.Name = "ID_DAT_COL_LBL";
            this.ID_DAT_COL_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DAT_COL_LBL.Size = new System.Drawing.Size(182, 14);
            this.ID_DAT_COL_LBL.TabIndex = 13;
            this.ID_DAT_COL_LBL.Tag = "";
            this.ID_DAT_COL_LBL.Text = "COL. BARRIO ACTIPAN";
            // 
            // ID_DAT_CPM_LBL
            // 
            this.ID_DAT_CPM_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_DAT_CPM_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DAT_CPM_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_DAT_CPM_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DAT_CPM_LBL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_DAT_CPM_LBL.Location = new System.Drawing.Point(25, 79);
            this.ID_DAT_CPM_LBL.Name = "ID_DAT_CPM_LBL";
            this.ID_DAT_CPM_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DAT_CPM_LBL.Size = new System.Drawing.Size(158, 15);
            this.ID_DAT_CPM_LBL.TabIndex = 14;
            this.ID_DAT_CPM_LBL.Tag = "";
            this.ID_DAT_CPM_LBL.Text = "03230 MEXICO, D.F.";
            // 
            // ID_ACL_FEC_PNL
            // 
            this.ID_ACL_FEC_PNL.Controls.Add(this.ID_ACL_FEC_DTB);
            this.ID_ACL_FEC_PNL.Controls.Add(this.ID_ACL_FEC_PNLLabel_Text);
            this.ID_ACL_FEC_PNL.Location = new System.Drawing.Point(328, 21);
            this.ID_ACL_FEC_PNL.Name = "ID_ACL_FEC_PNL";
            this.ID_ACL_FEC_PNL.Size = new System.Drawing.Size(175, 25);
            this.ID_ACL_FEC_PNL.TabIndex = 9;
            this.ID_ACL_FEC_PNL.Tag = "";
            // 
            // ID_ACL_FEC_DTB
            // 
            this.ID_ACL_FEC_DTB.Location = new System.Drawing.Point(80, 2);
            this.ID_ACL_FEC_DTB.Name = "ID_ACL_FEC_DTB";
            this.ID_ACL_FEC_DTB.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_ACL_FEC_DTB.OcxState")));
            this.ID_ACL_FEC_DTB.Size = new System.Drawing.Size(92, 22);
            this.ID_ACL_FEC_DTB.TabIndex = 10;
            this.ID_ACL_FEC_DTB.Tag = "";
            // 
            // ID_ACL_FEC_PNLLabel_Text
            // 
            this.ID_ACL_FEC_PNLLabel_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_ACL_FEC_PNLLabel_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_ACL_FEC_PNLLabel_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ID_ACL_FEC_PNLLabel_Text.Location = new System.Drawing.Point(0, 0);
            this.ID_ACL_FEC_PNLLabel_Text.Name = "ID_ACL_FEC_PNLLabel_Text";
            this.ID_ACL_FEC_PNLLabel_Text.Size = new System.Drawing.Size(175, 25);
            this.ID_ACL_FEC_PNLLabel_Text.TabIndex = 11;
            this.ID_ACL_FEC_PNLLabel_Text.Tag = "";
            this.ID_ACL_FEC_PNLLabel_Text.Text = " &Hasta el Día:";
            this.ID_ACL_FEC_PNLLabel_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ID_DAT_EJE_LBL
            // 
            this.ID_DAT_EJE_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_DAT_EJE_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DAT_EJE_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_DAT_EJE_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DAT_EJE_LBL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_DAT_EJE_LBL.Location = new System.Drawing.Point(25, 14);
            this.ID_DAT_EJE_LBL.Name = "ID_DAT_EJE_LBL";
            this.ID_DAT_EJE_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DAT_EJE_LBL.Size = new System.Drawing.Size(175, 16);
            this.ID_DAT_EJE_LBL.TabIndex = 7;
            this.ID_DAT_EJE_LBL.Tag = "";
            this.ID_DAT_EJE_LBL.Text = "APODERADO LEGAL";
            // 
            // ID_DAT_EMP_LBL
            // 
            this.ID_DAT_EMP_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_DAT_EMP_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DAT_EMP_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_DAT_EMP_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DAT_EMP_LBL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_DAT_EMP_LBL.Location = new System.Drawing.Point(25, 30);
            this.ID_DAT_EMP_LBL.Name = "ID_DAT_EMP_LBL";
            this.ID_DAT_EMP_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DAT_EMP_LBL.Size = new System.Drawing.Size(182, 18);
            this.ID_DAT_EMP_LBL.TabIndex = 8;
            this.ID_DAT_EMP_LBL.Tag = "";
            this.ID_DAT_EMP_LBL.Text = "BANAMEX, S.A.";
            // 
            // ID_DAT_CAL_LBL
            // 
            this.ID_DAT_CAL_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_DAT_CAL_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DAT_CAL_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_DAT_CAL_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DAT_CAL_LBL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_DAT_CAL_LBL.Location = new System.Drawing.Point(26, 45);
            this.ID_DAT_CAL_LBL.Name = "ID_DAT_CAL_LBL";
            this.ID_DAT_CAL_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DAT_CAL_LBL.Size = new System.Drawing.Size(155, 16);
            this.ID_DAT_CAL_LBL.TabIndex = 11;
            this.ID_DAT_CAL_LBL.Tag = "";
            this.ID_DAT_CAL_LBL.Text = "RIO MIXCOAC 108";
            // 
            // ID_ACL_REF_PB
            // 
            this.ID_ACL_REF_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_ACL_REF_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_ACL_REF_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_ACL_REF_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_ACL_REF_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_ACL_REF_PB.Location = new System.Drawing.Point(324, 62);
            this.ID_ACL_REF_PB.Name = "ID_ACL_REF_PB";
            this.ID_ACL_REF_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_ACL_REF_PB.Size = new System.Drawing.Size(69, 25);
            this.ID_ACL_REF_PB.TabIndex = 6;
            this.ID_ACL_REF_PB.Tag = "";
            this.ID_ACL_REF_PB.Text = "&Reporte";
            this.ID_ACL_REF_PB.UseVisualStyleBackColor = false;
            this.ID_ACL_REF_PB.Click += new System.EventHandler(this.ID_ACL_REF_PB_Click);
            // 
            // ID_REJ_ARC_CDG
            // 
            this.ID_REJ_ARC_CDG.Enabled = true;
            this.ID_REJ_ARC_CDG.Location = new System.Drawing.Point(25, 300);
            this.ID_REJ_ARC_CDG.Name = "ID_REJ_ARC_CDG";
            this.ID_REJ_ARC_CDG.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_REJ_ARC_CDG.OcxState")));
            this.ID_REJ_ARC_CDG.Size = new System.Drawing.Size(32, 32);
            this.ID_REJ_ARC_CDG.TabIndex = 13;
            this.ID_REJ_ARC_CDG.Tag = "";
            // 
            // fpID_ACL_REP_SS
            // 
            this.fpID_ACL_REP_SS.AccessibleDescription = "";
            this.fpID_ACL_REP_SS.FocusRenderer = defaultFocusIndicatorRenderer1;
            this.fpID_ACL_REP_SS.HorizontalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpID_ACL_REP_SS.HorizontalScrollBar.Name = "";
            this.fpID_ACL_REP_SS.HorizontalScrollBar.Renderer = defaultScrollBarRenderer1;
            this.fpID_ACL_REP_SS.HorizontalScrollBar.TabIndex = 6;
            this.fpID_ACL_REP_SS.Location = new System.Drawing.Point(17, 163);
            this.fpID_ACL_REP_SS.Name = "fpID_ACL_REP_SS";
            namedStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle1.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle1.Parent = "DataAreaDefault";
            textCellType1.MaxLength = 60;
            namedStyle2.CellType = textCellType1;
            namedStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold);
            namedStyle2.NoteIndicatorColor = System.Drawing.Color.Red;
            namedStyle2.Parent = "DataAreaDefault";
            namedStyle2.Renderer = textCellType1;
            this.fpID_ACL_REP_SS.NamedStyles.AddRange(new FarPoint.Win.Spread.NamedStyle[] {
            namedStyle1,
            namedStyle2});
            this.fpID_ACL_REP_SS.Sheets.AddRange(new FarPoint.Win.Spread.SheetView[] {
            this.fpID_ACL_REP_SS_Sheet1});
            this.fpID_ACL_REP_SS.Size = new System.Drawing.Size(577, 129);
            this.fpID_ACL_REP_SS.Skin = FarPoint.Win.Spread.DefaultSpreadSkins.Classic;
            this.fpID_ACL_REP_SS.TabIndex = 14;
            tipAppearance1.BackColor = System.Drawing.SystemColors.Info;
            tipAppearance1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            tipAppearance1.ForeColor = System.Drawing.SystemColors.InfoText;
            this.fpID_ACL_REP_SS.TextTipAppearance = tipAppearance1;
            this.fpID_ACL_REP_SS.VerticalScrollBar.Buttons = new FarPoint.Win.Spread.FpScrollBarButtonCollection("BackwardLineButton,ThumbTrack,ForwardLineButton");
            this.fpID_ACL_REP_SS.VerticalScrollBar.Name = "";
            this.fpID_ACL_REP_SS.VerticalScrollBar.Renderer = defaultScrollBarRenderer2;
            this.fpID_ACL_REP_SS.VerticalScrollBar.TabIndex = 7;
            this.fpID_ACL_REP_SS.VisualStyles = FarPoint.Win.VisualStyles.Off;
            // 
            // fpID_ACL_REP_SS_Sheet1
            // 
            this.fpID_ACL_REP_SS_Sheet1.Reset();
            this.fpID_ACL_REP_SS_Sheet1.SheetName = "Sheet1";
            // Formulas and custom names must be loaded with R1C1 reference style
            this.fpID_ACL_REP_SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.R1C1;
            this.fpID_ACL_REP_SS_Sheet1.ColumnCount = 6;
            this.fpID_ACL_REP_SS_Sheet1.RowCount = 7;
            this.fpID_ACL_REP_SS_Sheet1.ColumnFooter.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpID_ACL_REP_SS_Sheet1.ColumnFooter.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_ACL_REP_SS_Sheet1.ColumnFooter.DefaultStyle.Parent = "HeaderDefault";
            this.fpID_ACL_REP_SS_Sheet1.ColumnFooterSheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_ACL_REP_SS_Sheet1.ColumnFooterSheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpID_ACL_REP_SS_Sheet1.ColumnHeader.AutoText = FarPoint.Win.Spread.HeaderAutoText.Blank;
            this.fpID_ACL_REP_SS_Sheet1.ColumnHeader.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpID_ACL_REP_SS_Sheet1.ColumnHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.fpID_ACL_REP_SS_Sheet1.ColumnHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fpID_ACL_REP_SS_Sheet1.ColumnHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_ACL_REP_SS_Sheet1.ColumnHeader.DefaultStyle.Parent = "HeaderDefault";
            this.fpID_ACL_REP_SS_Sheet1.Columns.Default.SortIndicator = FarPoint.Win.Spread.Model.SortIndicator.None;
            this.fpID_ACL_REP_SS_Sheet1.DefaultStyleName = "Text307635406140688015403";
            this.fpID_ACL_REP_SS_Sheet1.FilterBar.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_ACL_REP_SS_Sheet1.FilterBar.DefaultStyle.Parent = "FilterBarDefault";
            this.fpID_ACL_REP_SS_Sheet1.FilterBarHeaderStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_ACL_REP_SS_Sheet1.FilterBarHeaderStyle.Parent = "RowHeaderDefault";
            this.fpID_ACL_REP_SS_Sheet1.RowHeader.Columns.Default.Resizable = false;
            this.fpID_ACL_REP_SS_Sheet1.RowHeader.DefaultStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.fpID_ACL_REP_SS_Sheet1.RowHeader.DefaultStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fpID_ACL_REP_SS_Sheet1.RowHeader.DefaultStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_ACL_REP_SS_Sheet1.RowHeader.DefaultStyle.Parent = "RowHeaderDefault";
            this.fpID_ACL_REP_SS_Sheet1.SheetCornerStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.fpID_ACL_REP_SS_Sheet1.SheetCornerStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.fpID_ACL_REP_SS_Sheet1.SheetCornerStyle.NoteIndicatorColor = System.Drawing.Color.Red;
            this.fpID_ACL_REP_SS_Sheet1.SheetCornerStyle.Parent = "RowHeaderDefault";
            this.fpID_ACL_REP_SS_Sheet1.ReferenceStyle = FarPoint.Win.Spread.Model.ReferenceStyle.A1;
            // 
            // CORRPACL
            // 
            this.AcceptButton = this.ID_ACL_REF_PB;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.Color.Silver;
            this.CancelButton = this.ID_ACL_SAL_PB;
            this.ClientSize = new System.Drawing.Size(610, 334);
            this.Controls.Add(this.fpID_ACL_REP_SS);            
            this.Controls.Add(this.ID_ACL_SAL_PB);
            this.Controls.Add(this.ID_CEJ_IDE_PNL);
            this.Controls.Add(this.ID_REJ_ARC_CDG);
            this.Controls.Add(this.ID_ACL_IMP_PB);
            this.Controls.Add(this.ID_CEJ_TIT_PNL);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(114, 102);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CORRPACL";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Aclaraciones Vencidas";
            this.Activated += new System.EventHandler(this.CORRPACL_Activated);
            this.Closed += new System.EventHandler(this.CORRPACL_Closed);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CORRPACL_KeyPress);            
            this.ID_CEJ_TIT_PNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_COR_PIC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEJ_LOG_IMG)).EndInit();
            this.ID_CEJ_IDE_PNL.ResumeLayout(false);
            this.ID_ACL_FEC_PNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ID_ACL_FEC_DTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_REJ_ARC_CDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpID_ACL_REP_SS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fpID_ACL_REP_SS_Sheet1)).EndInit();
            this.ResumeLayout(false);

	}
#endregion 

    private FarPoint.Win.Spread.FpSpread fpID_ACL_REP_SS;
    private FarPoint.Win.Spread.SheetView fpID_ACL_REP_SS_Sheet1;
}
}