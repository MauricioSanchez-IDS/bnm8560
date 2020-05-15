using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class COREXALT
	{
	
#region "Upgrade Support "
		private static COREXALT m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static COREXALT DefInstance
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
		public COREXALT():base(){
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
			InitializeID_EXP_ARC_OPB();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static COREXALT CreateInstance()
	{
			COREXALT theInstance = new COREXALT();
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
	public  System.Windows.Forms.Button ID_EXP_SAL_PB;
	public  System.Windows.Forms.Button ID_EXP_ACE_PB;
	public  System.Windows.Forms.PictureBox ID_EXP_COR_IMG;
	public  System.Windows.Forms.Button ID_EXP_CAN_PB;
	private  AxThreed.AxSSOption _ID_EXP_ARC_OPB_2;
	private  AxThreed.AxSSOption _ID_EXP_ARC_OPB_1;
	public  AxThreed.AxSSFrame ID_EXP_PRI_FRM;
	public  AxThreed.AxSSPanel ID_EXP_PORC_PNL;
	public  System.Windows.Forms.Label ID_DEB_BAN_LBL;
	public  System.Windows.Forms.PictureBox ID_DEB_LOG_IMG;
	public  AxThreed.AxSSPanel ID_EXP_PRI_PNL;
	public AxThreed.AxSSOption[] ID_EXP_ARC_OPB = new AxThreed.AxSSOption[3];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(COREXALT));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_EXP_PRI_PNL = new AxThreed.AxSSPanel();
            this.ID_EXP_CAN_PB = new System.Windows.Forms.Button();
            this.ID_EXP_COR_IMG = new System.Windows.Forms.PictureBox();
            this.ID_EXP_ACE_PB = new System.Windows.Forms.Button();
            this.ID_EXP_PRI_FRM = new AxThreed.AxSSFrame();
            this._ID_EXP_ARC_OPB_2 = new AxThreed.AxSSOption();
            this._ID_EXP_ARC_OPB_1 = new AxThreed.AxSSOption();
            this.ID_DEB_LOG_IMG = new System.Windows.Forms.PictureBox();
            this.ID_DEB_BAN_LBL = new System.Windows.Forms.Label();
            this.ID_EXP_PORC_PNL = new AxThreed.AxSSPanel();
            this.ID_EXP_SAL_PB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ID_EXP_PRI_PNL)).BeginInit();
            this.ID_EXP_PRI_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ID_EXP_COR_IMG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_EXP_PRI_FRM)).BeginInit();
            this.ID_EXP_PRI_FRM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_EXP_ARC_OPB_2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_EXP_ARC_OPB_1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_DEB_LOG_IMG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_EXP_PORC_PNL)).BeginInit();
            this.SuspendLayout();
            // 
            // ID_EXP_PRI_PNL
            // 
            this.ID_EXP_PRI_PNL.Controls.Add(this.ID_EXP_CAN_PB);
            this.ID_EXP_PRI_PNL.Controls.Add(this.ID_EXP_COR_IMG);
            this.ID_EXP_PRI_PNL.Controls.Add(this.ID_EXP_ACE_PB);
            this.ID_EXP_PRI_PNL.Controls.Add(this.ID_EXP_PRI_FRM);
            this.ID_EXP_PRI_PNL.Controls.Add(this.ID_DEB_LOG_IMG);
            this.ID_EXP_PRI_PNL.Controls.Add(this.ID_DEB_BAN_LBL);
            this.ID_EXP_PRI_PNL.Controls.Add(this.ID_EXP_PORC_PNL);
            this.ID_EXP_PRI_PNL.Controls.Add(this.ID_EXP_SAL_PB);
            this.ID_EXP_PRI_PNL.Location = new System.Drawing.Point(0, 0);
            this.ID_EXP_PRI_PNL.Name = "ID_EXP_PRI_PNL";
            this.ID_EXP_PRI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_EXP_PRI_PNL.OcxState")));
            this.ID_EXP_PRI_PNL.Size = new System.Drawing.Size(409, 209);
            this.ID_EXP_PRI_PNL.TabIndex = 0;
            this.ID_EXP_PRI_PNL.Tag = "";
            // 
            // ID_EXP_CAN_PB
            // 
            this.ID_EXP_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_EXP_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_EXP_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_EXP_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_EXP_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_EXP_CAN_PB.Location = new System.Drawing.Point(147, 164);
            this.ID_EXP_CAN_PB.Name = "ID_EXP_CAN_PB";
            this.ID_EXP_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_EXP_CAN_PB.Size = new System.Drawing.Size(73, 23);
            this.ID_EXP_CAN_PB.TabIndex = 7;
            this.ID_EXP_CAN_PB.Tag = "";
            this.ID_EXP_CAN_PB.Text = "Cancelar";
            this.ID_EXP_CAN_PB.UseVisualStyleBackColor = false;
            this.ID_EXP_CAN_PB.Visible = false;
            this.ID_EXP_CAN_PB.Click += new System.EventHandler(this.ID_EXP_CAN_PB_Click);
            // 
            // ID_EXP_COR_IMG
            // 
            this.ID_EXP_COR_IMG.BackColor = System.Drawing.Color.Gray;
            this.ID_EXP_COR_IMG.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_EXP_COR_IMG.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_EXP_COR_IMG.Image = ((System.Drawing.Image)(resources.GetObject("ID_EXP_COR_IMG.Image")));
            this.ID_EXP_COR_IMG.Location = new System.Drawing.Point(252, 24);
            this.ID_EXP_COR_IMG.Name = "ID_EXP_COR_IMG";
            this.ID_EXP_COR_IMG.Size = new System.Drawing.Size(131, 31);
            this.ID_EXP_COR_IMG.TabIndex = 1;
            this.ID_EXP_COR_IMG.TabStop = false;
            this.ID_EXP_COR_IMG.Tag = "";
            // 
            // ID_EXP_ACE_PB
            // 
            this.ID_EXP_ACE_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_EXP_ACE_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_EXP_ACE_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_EXP_ACE_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_EXP_ACE_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_EXP_ACE_PB.Location = new System.Drawing.Point(55, 164);
            this.ID_EXP_ACE_PB.Name = "ID_EXP_ACE_PB";
            this.ID_EXP_ACE_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_EXP_ACE_PB.Size = new System.Drawing.Size(73, 23);
            this.ID_EXP_ACE_PB.TabIndex = 2;
            this.ID_EXP_ACE_PB.Tag = "";
            this.ID_EXP_ACE_PB.Text = "Aceptar";
            this.ID_EXP_ACE_PB.UseVisualStyleBackColor = false;
            this.ID_EXP_ACE_PB.Click += new System.EventHandler(this.ID_EXP_ACE_PB_Click);
            // 
            // ID_EXP_PRI_FRM
            // 
            this.ID_EXP_PRI_FRM.Controls.Add(this._ID_EXP_ARC_OPB_2);
            this.ID_EXP_PRI_FRM.Controls.Add(this._ID_EXP_ARC_OPB_1);
            this.ID_EXP_PRI_FRM.Location = new System.Drawing.Point(29, 66);
            this.ID_EXP_PRI_FRM.Name = "ID_EXP_PRI_FRM";
            this.ID_EXP_PRI_FRM.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_EXP_PRI_FRM.OcxState")));
            this.ID_EXP_PRI_FRM.Size = new System.Drawing.Size(355, 85);
            this.ID_EXP_PRI_FRM.TabIndex = 3;
            this.ID_EXP_PRI_FRM.Tag = "";
            // 
            // _ID_EXP_ARC_OPB_2
            // 
            this._ID_EXP_ARC_OPB_2.Location = new System.Drawing.Point(114, 49);
            this._ID_EXP_ARC_OPB_2.Name = "_ID_EXP_ARC_OPB_2";
            this._ID_EXP_ARC_OPB_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_EXP_ARC_OPB_2.OcxState")));
            this._ID_EXP_ARC_OPB_2.Size = new System.Drawing.Size(135, 20);
            this._ID_EXP_ARC_OPB_2.TabIndex = 5;
            this._ID_EXP_ARC_OPB_2.Tag = "";
            // 
            // _ID_EXP_ARC_OPB_1
            // 
            this._ID_EXP_ARC_OPB_1.Location = new System.Drawing.Point(114, 25);
            this._ID_EXP_ARC_OPB_1.Name = "_ID_EXP_ARC_OPB_1";
            this._ID_EXP_ARC_OPB_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_EXP_ARC_OPB_1.OcxState")));
            this._ID_EXP_ARC_OPB_1.Size = new System.Drawing.Size(135, 20);
            this._ID_EXP_ARC_OPB_1.TabIndex = 4;
            this._ID_EXP_ARC_OPB_1.Tag = "";
            // 
            // ID_DEB_LOG_IMG
            // 
            this.ID_DEB_LOG_IMG.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DEB_LOG_IMG.Image = ((System.Drawing.Image)(resources.GetObject("ID_DEB_LOG_IMG.Image")));
            this.ID_DEB_LOG_IMG.Location = new System.Drawing.Point(28, 16);
            this.ID_DEB_LOG_IMG.Name = "ID_DEB_LOG_IMG";
            this.ID_DEB_LOG_IMG.Size = new System.Drawing.Size(45, 45);
            this.ID_DEB_LOG_IMG.TabIndex = 8;
            this.ID_DEB_LOG_IMG.TabStop = false;
            this.ID_DEB_LOG_IMG.Tag = "";
            // 
            // ID_DEB_BAN_LBL
            // 
            this.ID_DEB_BAN_LBL.BackColor = System.Drawing.Color.Silver;
            this.ID_DEB_BAN_LBL.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_DEB_BAN_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_DEB_BAN_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_DEB_BAN_LBL.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_DEB_BAN_LBL.Location = new System.Drawing.Point(80, 26);
            this.ID_DEB_BAN_LBL.Name = "ID_DEB_BAN_LBL";
            this.ID_DEB_BAN_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_DEB_BAN_LBL.Size = new System.Drawing.Size(118, 24);
            this.ID_DEB_BAN_LBL.TabIndex = 8;
            this.ID_DEB_BAN_LBL.Tag = "";
            this.ID_DEB_BAN_LBL.Text = "Banamex";
            // 
            // ID_EXP_PORC_PNL
            // 
            this.ID_EXP_PORC_PNL.Location = new System.Drawing.Point(28, 86);
            this.ID_EXP_PORC_PNL.Name = "ID_EXP_PORC_PNL";
            this.ID_EXP_PORC_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_EXP_PORC_PNL.OcxState")));
            this.ID_EXP_PORC_PNL.Size = new System.Drawing.Size(357, 35);
            this.ID_EXP_PORC_PNL.TabIndex = 9;
            this.ID_EXP_PORC_PNL.Tag = "";
            // 
            // ID_EXP_SAL_PB
            // 
            this.ID_EXP_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_EXP_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_EXP_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_EXP_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_EXP_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_EXP_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_EXP_SAL_PB.Location = new System.Drawing.Point(238, 164);
            this.ID_EXP_SAL_PB.Name = "ID_EXP_SAL_PB";
            this.ID_EXP_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_EXP_SAL_PB.Size = new System.Drawing.Size(73, 23);
            this.ID_EXP_SAL_PB.TabIndex = 6;
            this.ID_EXP_SAL_PB.Tag = "";
            this.ID_EXP_SAL_PB.Text = "Salir";
            this.ID_EXP_SAL_PB.UseVisualStyleBackColor = false;
            this.ID_EXP_SAL_PB.Click += new System.EventHandler(this.ID_EXP_SAL_PB_Click);
            // 
            // COREXALT
            // 
            this.AcceptButton = this.ID_EXP_ACE_PB;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.ID_EXP_SAL_PB;
            this.ClientSize = new System.Drawing.Size(402, 202);
            this.Controls.Add(this.ID_EXP_PRI_PNL);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Location = new System.Drawing.Point(179, 115);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "COREXALT";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Exportación";
            this.Activated += new System.EventHandler(this.COREXALT_Activated);
            this.Closed += new System.EventHandler(this.COREXALT_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.ID_EXP_PRI_PNL)).EndInit();
            this.ID_EXP_PRI_PNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ID_EXP_COR_IMG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_EXP_PRI_FRM)).EndInit();
            this.ID_EXP_PRI_FRM.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._ID_EXP_ARC_OPB_2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._ID_EXP_ARC_OPB_1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_DEB_LOG_IMG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ID_EXP_PORC_PNL)).EndInit();
            this.ResumeLayout(false);

	}
	void  InitializeID_EXP_ARC_OPB()
	{
			this.ID_EXP_ARC_OPB[2] = _ID_EXP_ARC_OPB_2;
			this.ID_EXP_ARC_OPB[1] = _ID_EXP_ARC_OPB_1;
	}
#endregion 
}
}