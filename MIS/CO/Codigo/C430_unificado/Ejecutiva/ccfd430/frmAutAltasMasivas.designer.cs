using System;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frmAutAltasMasivas
	{
	
#region "Upgrade Support "
		private static frmAutAltasMasivas m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmAutAltasMasivas DefInstance
		{
			get
			{
				if (m_vb6FormDefInstance == null || m_vb6FormDefInstance.IsDisposed)
				{
					m_InitializingDefInstance = true;
                    //m_vb6FormDefInstance = new frmAutAltasMasivas();
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
		public frmAutAltasMasivas():base(){
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
            //This form is an MDI child.
            //This code simulates the VB6 
            // functionality of automatically
            // loading and showing an MDI
            // child's parent.
            this.MdiParent = TCc430.CORMDIBN.DefInstance;
            TCc430.CORMDIBN.DefInstance.Show();

            ////This call is required by the Windows Form Designer.
            //InitializeComponent();
            ////This form is an MDI child.
            ////This code simulates the VB6 
            //// functionality of automatically
            //// loading and showing an MDI
            //// child's parent.
            //this.MdiParent = TCc430.CORMDIBN.DefInstance;
            //TCc430.CORMDIBN.DefInstance.Show();
            ////The MDI form in the VB6 project had its
            ////AutoShowChildren property set to True
            ////To simulate the VB6 behavior, we need to
            ////automatically Show the form whenever it
            ////is loaded.  If you do not want this behavior
            ////then delete the following line of code
            ////UPGRADE_TODO: (2018) Remove the next line of code to stop form from automatically showing.
            //this.Show();
		}
        public static frmAutAltasMasivas CreateInstance()
        {
            frmAutAltasMasivas theInstance = new frmAutAltasMasivas();
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
	public  System.Windows.Forms.TextBox txtLog;
	public  AxMSComctlLib.AxStatusBar StatusBar1;
	public  AxMSComctlLib.AxToolbar tbrStandar;
	public  AxMSComctlLib.AxListView lvwCuentas;
	public  AxMSComCtl2.AxDTPicker dtpAux;
	public  AxMSComctlLib.AxImageList imlImagenes;
	public  AxMSComctlLib.AxImageList ImageList1;
	public  System.Windows.Forms.PictureBox Image1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	//[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAutAltasMasivas));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.txtLog = new System.Windows.Forms.TextBox();
        this.Image1 = new System.Windows.Forms.PictureBox();
        this.StatusBar1 = new AxMSComctlLib.AxStatusBar();
        this.tbrStandar = new AxMSComctlLib.AxToolbar();
        this.lvwCuentas = new AxMSComctlLib.AxListView();
        this.dtpAux = new AxMSComCtl2.AxDTPicker();
        this.imlImagenes = new AxMSComctlLib.AxImageList();
        this.ImageList1 = new AxMSComctlLib.AxImageList();
        ((System.ComponentModel.ISupportInitialize)(this.Image1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.StatusBar1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.tbrStandar)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.lvwCuentas)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.dtpAux)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.imlImagenes)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ImageList1)).BeginInit();
        this.SuspendLayout();
        // 
        // txtLog
        // 
        this.txtLog.AcceptsReturn = true;
        this.txtLog.BackColor = System.Drawing.SystemColors.Window;
        this.txtLog.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtLog.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtLog.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtLog.Location = new System.Drawing.Point(1, 295);
        this.txtLog.MaxLength = 0;
        this.txtLog.Multiline = true;
        this.txtLog.Name = "txtLog";
        this.txtLog.ReadOnly = true;
        this.txtLog.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
        this.txtLog.Size = new System.Drawing.Size(690, 110);
        this.txtLog.TabIndex = 2;
        // 
        // Image1
        // 
        this.Image1.Cursor = System.Windows.Forms.Cursors.Default;
        this.Image1.Location = new System.Drawing.Point(660, 252);
        this.Image1.Name = "Image1";
        this.Image1.Size = new System.Drawing.Size(9, 29);
        this.Image1.TabIndex = 7;
        this.Image1.TabStop = false;
        // 
        // StatusBar1
        // 
        this.StatusBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
        this.StatusBar1.Location = new System.Drawing.Point(0, 347);
        this.StatusBar1.Name = "StatusBar1";
        this.StatusBar1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("StatusBar1.OcxState")));
        this.StatusBar1.Size = new System.Drawing.Size(691, 25);
        this.StatusBar1.TabIndex = 0;
        // 
        // tbrStandar
        // 
        this.tbrStandar.Dock = System.Windows.Forms.DockStyle.Top;
        this.tbrStandar.Location = new System.Drawing.Point(0, 0);
        this.tbrStandar.Name = "tbrStandar";
        this.tbrStandar.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("tbrStandar.OcxState")));
        this.tbrStandar.Size = new System.Drawing.Size(691, 22);
        this.tbrStandar.TabIndex = 1;
        // 
        // lvwCuentas
        // 
        this.lvwCuentas.Location = new System.Drawing.Point(0, 32);
        this.lvwCuentas.Name = "lvwCuentas";
        this.lvwCuentas.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("lvwCuentas.OcxState")));
        this.lvwCuentas.Size = new System.Drawing.Size(691, 257);
        this.lvwCuentas.TabIndex = 3;
        // 
        // dtpAux
        // 
        this.dtpAux.Location = new System.Drawing.Point(0, 0);
        this.dtpAux.Name = "dtpAux";
        this.dtpAux.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("dtpAux.OcxState")));
        this.dtpAux.Size = new System.Drawing.Size(169, 21);
        this.dtpAux.TabIndex = 4;
        this.dtpAux.Visible = false;
        // 
        // imlImagenes
        // 
        this.imlImagenes.Enabled = true;
        this.imlImagenes.Location = new System.Drawing.Point(608, 0);
        this.imlImagenes.Name = "imlImagenes";
        this.imlImagenes.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("imlImagenes.OcxState")));
        this.imlImagenes.Size = new System.Drawing.Size(38, 38);
        this.imlImagenes.TabIndex = 5;
        // 
        // ImageList1
        // 
        this.ImageList1.Enabled = true;
        this.ImageList1.Location = new System.Drawing.Point(0, 0);
        this.ImageList1.Name = "ImageList1";
        this.ImageList1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ImageList1.OcxState")));
        this.ImageList1.Size = new System.Drawing.Size(38, 38);
        this.ImageList1.TabIndex = 6;
        // 
        // frmAutAltasMasivas
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(691, 372);
        this.Controls.Add(this.txtLog);
        this.Controls.Add(this.StatusBar1);
        this.Controls.Add(this.tbrStandar);
        this.Controls.Add(this.lvwCuentas);
        this.Controls.Add(this.dtpAux);
        this.Controls.Add(this.imlImagenes);
        this.Controls.Add(this.ImageList1);
        this.Controls.Add(this.Image1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Arial", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Location = new System.Drawing.Point(4, 23);
        this.Name = "frmAutAltasMasivas";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
        this.Text = "Confirmación Altas Masivas";
        ((System.ComponentModel.ISupportInitialize)(this.Image1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.StatusBar1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.tbrStandar)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.lvwCuentas)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.dtpAux)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.imlImagenes)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ImageList1)).EndInit();
        this.ResumeLayout(false);
        this.PerformLayout();

	}
#endregion 
}
}