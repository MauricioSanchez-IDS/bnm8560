using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class CORSGACC
	{

    #region "Upgrade Support "
    private static CORSGACC m_vb6FormDefInstance;
    private static bool m_InitializingDefInstance;
    public static CORSGACC DefInstance
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
    public CORSGACC()
        : base()
    {
        if (m_vb6FormDefInstance == null)
        {
            if (m_InitializingDefInstance)
            {
                m_vb6FormDefInstance = this;
            }
            else
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
        //This form is an MDI child.
        //This code simulates the VB6 
        // functionality of automatically
        // loading and showing an MDI
        // child's parent.

        this.MdiParent = TCc430.CORMDIBN.DefInstance;
        TCc430.CORMDIBN.DefInstance.Show();
    }
    public static CORSGACC CreateInstance()
    {
        CORSGACC theInstance = new CORSGACC();
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
    protected void InitializeHelp()
    {
        Artinsoft.VB6.Help.HelpSupportClass.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.Index);
    }
    private void ReleaseResources(object eventSender, System.EventArgs eventArgs)
    {
        Dispose(true);
        m_vb6FormDefInstance = null;
    }
    //Form overrides dispose to clean up the component list.
    [System.Diagnostics.DebuggerNonUserCode]
    protected override void Dispose(bool Disposing)
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
	public  System.Windows.Forms.ComboBox ID_ACC_BAN_COB;
	public  System.Windows.Forms.Button ID_ACC_CAN_PB;
	public  System.Windows.Forms.Button ID_ACC_ACE_PB;
	public  System.Windows.Forms.TextBox ID_ACC_CVE_EB;
	public  System.Windows.Forms.TextBox ID_ACC_USU_EB;
	public  System.Windows.Forms.ComboBox ID_ACC_SER_COB;
	public  System.Windows.Forms.PictureBox Image1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORSGACC));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_ACC_BAN_COB = new System.Windows.Forms.ComboBox();
        this.ID_ACC_CAN_PB = new System.Windows.Forms.Button();
        this.ID_ACC_ACE_PB = new System.Windows.Forms.Button();
        this.ID_ACC_CVE_EB = new System.Windows.Forms.TextBox();
        this.ID_ACC_USU_EB = new System.Windows.Forms.TextBox();
        this.ID_ACC_SER_COB = new System.Windows.Forms.ComboBox();
        this.Image1 = new System.Windows.Forms.PictureBox();
        this.ID_ACC_TOK_EB = new System.Windows.Forms.TextBox();
        this.label1 = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_ACC_BAN_COB
        // 
        this.ID_ACC_BAN_COB.BackColor = System.Drawing.Color.White;
        this.ID_ACC_BAN_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACC_BAN_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_ACC_BAN_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_BAN_COB.ForeColor = System.Drawing.Color.Black;
        this.ID_ACC_BAN_COB.Location = new System.Drawing.Point(128, 127);
        this.ID_ACC_BAN_COB.Name = "ID_ACC_BAN_COB";
        this.ID_ACC_BAN_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_BAN_COB.Size = new System.Drawing.Size(280, 21);
        this.ID_ACC_BAN_COB.TabIndex = 7;
        // 
        // ID_ACC_CAN_PB
        // 
        this.ID_ACC_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACC_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACC_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_ACC_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACC_CAN_PB.Location = new System.Drawing.Point(330, 249);
        this.ID_ACC_CAN_PB.Name = "ID_ACC_CAN_PB";
        this.ID_ACC_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_CAN_PB.Size = new System.Drawing.Size(80, 25);
        this.ID_ACC_CAN_PB.TabIndex = 5;
        this.ID_ACC_CAN_PB.Text = "Cancelar";
        this.ID_ACC_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_ACC_CAN_PB.Click += new System.EventHandler(this.ID_ACC_CAN_PB_Click);
        // 
        // ID_ACC_ACE_PB
        // 
        this.ID_ACC_ACE_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_ACC_ACE_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACC_ACE_PB.Enabled = false;
        this.ID_ACC_ACE_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_ACE_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_ACC_ACE_PB.Location = new System.Drawing.Point(330, 210);
        this.ID_ACC_ACE_PB.Name = "ID_ACC_ACE_PB";
        this.ID_ACC_ACE_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_ACE_PB.Size = new System.Drawing.Size(80, 25);
        this.ID_ACC_ACE_PB.TabIndex = 4;
        this.ID_ACC_ACE_PB.Text = "Aceptar";
        this.ID_ACC_ACE_PB.UseVisualStyleBackColor = false;
        this.ID_ACC_ACE_PB.Click += new System.EventHandler(this.ID_ACC_ACE_PB_Click);
        // 
        // ID_ACC_CVE_EB
        // 
        this.ID_ACC_CVE_EB.AcceptsReturn = true;
        this.ID_ACC_CVE_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACC_CVE_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACC_CVE_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_CVE_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACC_CVE_EB.ImeMode = System.Windows.Forms.ImeMode.Disable;
        this.ID_ACC_CVE_EB.Location = new System.Drawing.Point(208, 252);
        this.ID_ACC_CVE_EB.MaxLength = 8;
        this.ID_ACC_CVE_EB.Name = "ID_ACC_CVE_EB";
        this.ID_ACC_CVE_EB.PasswordChar = '*';
        this.ID_ACC_CVE_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_CVE_EB.Size = new System.Drawing.Size(107, 20);
        this.ID_ACC_CVE_EB.TabIndex = 1;
        // 
        // ID_ACC_USU_EB
        // 
        this.ID_ACC_USU_EB.AcceptsReturn = true;
        this.ID_ACC_USU_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACC_USU_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACC_USU_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_USU_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACC_USU_EB.Location = new System.Drawing.Point(208, 216);
        this.ID_ACC_USU_EB.MaxLength = 8;
        this.ID_ACC_USU_EB.Name = "ID_ACC_USU_EB";
        this.ID_ACC_USU_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_USU_EB.Size = new System.Drawing.Size(107, 20);
        this.ID_ACC_USU_EB.TabIndex = 0;
        // 
        // ID_ACC_SER_COB
        // 
        this.ID_ACC_SER_COB.BackColor = System.Drawing.Color.White;
        this.ID_ACC_SER_COB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_ACC_SER_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.ID_ACC_SER_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_SER_COB.ForeColor = System.Drawing.Color.Black;
        this.ID_ACC_SER_COB.Location = new System.Drawing.Point(48, 32);
        this.ID_ACC_SER_COB.Name = "ID_ACC_SER_COB";
        this.ID_ACC_SER_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_SER_COB.Size = new System.Drawing.Size(339, 21);
        this.ID_ACC_SER_COB.TabIndex = 6;
        this.ID_ACC_SER_COB.Visible = false;
        // 
        // Image1
        // 
        this.Image1.Cursor = System.Windows.Forms.Cursors.Default;
        this.Image1.Image = ((System.Drawing.Image)(resources.GetObject("Image1.Image")));
        this.Image1.Location = new System.Drawing.Point(0, 0);
        this.Image1.Name = "Image1";
        this.Image1.Size = new System.Drawing.Size(425, 287);
        this.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.Image1.TabIndex = 6;
        this.Image1.TabStop = false;
        // 
        // ID_ACC_TOK_EB
        // 
        this.ID_ACC_TOK_EB.AcceptsReturn = true;
        this.ID_ACC_TOK_EB.BackColor = System.Drawing.Color.White;
        this.ID_ACC_TOK_EB.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_ACC_TOK_EB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_ACC_TOK_EB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_ACC_TOK_EB.ImeMode = System.Windows.Forms.ImeMode.Disable;
        this.ID_ACC_TOK_EB.Location = new System.Drawing.Point(208, 289);
        this.ID_ACC_TOK_EB.MaxLength = 6;
        this.ID_ACC_TOK_EB.Name = "ID_ACC_TOK_EB";
        this.ID_ACC_TOK_EB.PasswordChar = '*';
        this.ID_ACC_TOK_EB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_ACC_TOK_EB.Size = new System.Drawing.Size(107, 20);
        this.ID_ACC_TOK_EB.TabIndex = 3;
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.BackColor = System.Drawing.Color.Transparent;
        this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.label1.ForeColor = System.Drawing.Color.Black;
        this.label1.Location = new System.Drawing.Point(141, 290);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(63, 16);
        this.label1.TabIndex = 2;
        this.label1.Text = "TOKEN:";
        // 
        // CORSGACC
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.ClientSize = new System.Drawing.Size(428, 316);
        this.ControlBox = false;
        this.Controls.Add(this.label1);
        this.Controls.Add(this.ID_ACC_TOK_EB);
        this.Controls.Add(this.ID_ACC_BAN_COB);
        this.Controls.Add(this.ID_ACC_CAN_PB);
        this.Controls.Add(this.ID_ACC_ACE_PB);
        this.Controls.Add(this.ID_ACC_CVE_EB);
        this.Controls.Add(this.ID_ACC_USU_EB);
        this.Controls.Add(this.ID_ACC_SER_COB);
        this.Controls.Add(this.Image1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(239, 189);
        this.Name = "CORSGACC";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Text = "C430 - Tarjeta Ejecutiva";
        ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

	}
#endregion 

        public System.Windows.Forms.TextBox ID_ACC_TOK_EB;
        private System.Windows.Forms.Label label1;
}
}