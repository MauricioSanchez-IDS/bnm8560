using System;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORSGPRE
	{
	
#region "Upgrade Support "
		private static CORSGPRE m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORSGPRE DefInstance
		{
			get
			{
                //if (m_vb6FormDefInstance == null || m_vb6FormDefInstance.IsDisposed)
                //{
                //    m_InitializingDefInstance = true;
                //    m_vb6FormDefInstance = new CORSGPRE();
                //    m_InitializingDefInstance = false;
                //}
                //return m_vb6FormDefInstance;

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
		public CORSGPRE():base(){
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
            //isInitializingComponent = true;
            InitializeComponent();
            //isInitializingComponent = false;
            //InitializeHelp();
            //InitializeComponent();
			InitializeID_PRE_VER_TXT();

            //this.MdiParent = TCc430.CORMDIBN.DefInstance;
            //TCc430.CORMDIBN.DefInstance.Show();

		}

        public static CORSGPRE CreateInstance()
        {
            CORSGPRE theInstance = new CORSGPRE();
            theInstance.Form_Load();
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
	public  System.Windows.Forms.Timer ID_MDI_TIM_TMR;
	public  System.Windows.Forms.Label ID_PRE_DER_TXT;
	private  System.Windows.Forms.Label _ID_PRE_VER_TXT_0;
	public  System.Windows.Forms.PictureBox Image1;
	public System.Windows.Forms.Label[] ID_PRE_VER_TXT = new System.Windows.Forms.Label[1];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORSGPRE));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_MDI_TIM_TMR = new System.Windows.Forms.Timer(this.components);
        this.ID_PRE_DER_TXT = new System.Windows.Forms.Label();
        this._ID_PRE_VER_TXT_0 = new System.Windows.Forms.Label();
        this.Image1 = new System.Windows.Forms.PictureBox();
        ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
        this.SuspendLayout();
        // 
        // ID_MDI_TIM_TMR
        // 
        this.ID_MDI_TIM_TMR.Enabled = true;
        this.ID_MDI_TIM_TMR.Interval = 5;
        this.ID_MDI_TIM_TMR.Tick += new System.EventHandler(this.ID_MDI_TIM_TMR_Tick);
        // 
        // ID_PRE_DER_TXT
        // 
        this.ID_PRE_DER_TXT.BackColor = System.Drawing.Color.Transparent;
        this.ID_PRE_DER_TXT.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_PRE_DER_TXT.Font = new System.Drawing.Font("Arial", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_PRE_DER_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_PRE_DER_TXT.Location = new System.Drawing.Point(255, 227);
        this.ID_PRE_DER_TXT.Name = "ID_PRE_DER_TXT";
        this.ID_PRE_DER_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_PRE_DER_TXT.Size = new System.Drawing.Size(94, 13);
        this.ID_PRE_DER_TXT.TabIndex = 1;
        this.ID_PRE_DER_TXT.Text = "Derechos Reservados";
        // 
        // _ID_PRE_VER_TXT_0
        // 
        this._ID_PRE_VER_TXT_0.AutoSize = true;
        this._ID_PRE_VER_TXT_0.BackColor = System.Drawing.Color.Transparent;
        this._ID_PRE_VER_TXT_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._ID_PRE_VER_TXT_0.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_PRE_VER_TXT_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._ID_PRE_VER_TXT_0.Location = new System.Drawing.Point(127, 71);
        this._ID_PRE_VER_TXT_0.Name = "_ID_PRE_VER_TXT_0";
        this._ID_PRE_VER_TXT_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._ID_PRE_VER_TXT_0.Size = new System.Drawing.Size(33, 16);
        this._ID_PRE_VER_TXT_0.TabIndex = 0;
        this._ID_PRE_VER_TXT_0.Text = "1.00";
        // 
        // Image1
        // 
        this.Image1.Cursor = System.Windows.Forms.Cursors.Default;
        this.Image1.Image = ((System.Drawing.Image)(resources.GetObject("Image1.Image")));
        this.Image1.Location = new System.Drawing.Point(0, 0);
        this.Image1.Name = "Image1";
        this.Image1.Size = new System.Drawing.Size(353, 241);
        this.Image1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
        this.Image1.TabIndex = 2;
        this.Image1.TabStop = false;
        this.Image1.Validating += new System.ComponentModel.CancelEventHandler(this.CORSGPRE_Closing);
        // 
        // CORSGPRE
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.SystemColors.Window;
        this.ClientSize = new System.Drawing.Size(353, 241);
        this.ControlBox = false;
        this.Controls.Add(this.ID_PRE_DER_TXT);
        this.Controls.Add(this._ID_PRE_VER_TXT_0);
        this.Controls.Add(this.Image1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
        this.Location = new System.Drawing.Point(202, 144);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORSGPRE";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Presentación Banamex";
        this.Validating += new System.ComponentModel.CancelEventHandler(this.CORSGPRE_Closing);
        ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

	}
	void  InitializeID_PRE_VER_TXT()
	{
			this.ID_PRE_VER_TXT[0] = _ID_PRE_VER_TXT_0;
	}
#endregion 
}
}