using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORCAMA
	{
	
#region "Upgrade Support "
		private static CORCAMA m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORCAMA DefInstance
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
		public CORCAMA():base(){
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
		}
	public static CORCAMA CreateInstance()
	{
			CORCAMA theInstance = new CORCAMA();
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
	public  System.Windows.Forms.ListBox ID_CAM_MEN_LIB;
	public  System.Windows.Forms.Panel picPicture;
	public  System.Windows.Forms.HScrollBar scrScroll;
	public  AxThreed.AxSSPanel SSPanel1;
	public  System.Windows.Forms.Button ID_CAM_CAN_PB;
	public  System.Windows.Forms.Button ID_CAM_ACE_PB;
	public  System.Windows.Forms.Label ID_CAM_CONT_LBL;
	public  System.Windows.Forms.Label ID_CAM_MEN_LBL;
	public  System.Windows.Forms.Label ID_CAM_GPO_LB;
	public  System.Windows.Forms.Label ID_CAM_NOM_LB;
	public  System.Windows.Forms.Label ID_CAM_EMP_LB;
	public  System.Windows.Forms.Label ID_CAM_CTA_LB;
	public  AxThreed.AxSSPanel ID_CAM_PRI_PNL;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORCAMA));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_CAM_PRI_PNL = new AxThreed.AxSSPanel();
        this.ID_CAM_MEN_LBL = new System.Windows.Forms.Label();
        this.ID_CAM_CAN_PB = new System.Windows.Forms.Button();
        this.ID_CAM_ACE_PB = new System.Windows.Forms.Button();
        this.ID_CAM_EMP_LB = new System.Windows.Forms.Label();
        this.ID_CAM_CTA_LB = new System.Windows.Forms.Label();
        this.ID_CAM_GPO_LB = new System.Windows.Forms.Label();
        this.ID_CAM_NOM_LB = new System.Windows.Forms.Label();
        this.SSPanel1 = new AxThreed.AxSSPanel();
        this.picPicture = new System.Windows.Forms.Panel();
        this.ID_CAM_MEN_LIB = new System.Windows.Forms.ListBox();
        this.scrScroll = new System.Windows.Forms.HScrollBar();
        this.ID_CAM_CONT_LBL = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)(this.ID_CAM_PRI_PNL)).BeginInit();
        this.ID_CAM_PRI_PNL.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.SSPanel1)).BeginInit();
        this.picPicture.SuspendLayout();
        this.SuspendLayout();
        // 
        // ID_CAM_PRI_PNL
        // 
        this.ID_CAM_PRI_PNL.Controls.Add(this.ID_CAM_MEN_LBL);
        this.ID_CAM_PRI_PNL.Controls.Add(this.ID_CAM_CAN_PB);
        this.ID_CAM_PRI_PNL.Controls.Add(this.ID_CAM_ACE_PB);
        this.ID_CAM_PRI_PNL.Controls.Add(this.ID_CAM_EMP_LB);
        this.ID_CAM_PRI_PNL.Controls.Add(this.ID_CAM_CTA_LB);
        this.ID_CAM_PRI_PNL.Controls.Add(this.ID_CAM_GPO_LB);
        this.ID_CAM_PRI_PNL.Controls.Add(this.ID_CAM_NOM_LB);
        this.ID_CAM_PRI_PNL.Controls.Add(this.SSPanel1);
        this.ID_CAM_PRI_PNL.Controls.Add(this.picPicture);
        this.ID_CAM_PRI_PNL.Controls.Add(this.scrScroll);
        this.ID_CAM_PRI_PNL.Controls.Add(this.ID_CAM_CONT_LBL);
        this.ID_CAM_PRI_PNL.Location = new System.Drawing.Point(0, 0);
        this.ID_CAM_PRI_PNL.Name = "ID_CAM_PRI_PNL";
        this.ID_CAM_PRI_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CAM_PRI_PNL.OcxState")));
        this.ID_CAM_PRI_PNL.Size = new System.Drawing.Size(700, 329);
        this.ID_CAM_PRI_PNL.TabIndex = 0;
        this.ID_CAM_PRI_PNL.Tag = "";
        // 
        // ID_CAM_MEN_LBL
        // 
        this.ID_CAM_MEN_LBL.AutoSize = true;
        this.ID_CAM_MEN_LBL.BackColor = System.Drawing.Color.Silver;
        this.ID_CAM_MEN_LBL.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAM_MEN_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAM_MEN_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAM_MEN_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAM_MEN_LBL.Location = new System.Drawing.Point(481, 8);
        this.ID_CAM_MEN_LBL.Name = "ID_CAM_MEN_LBL";
        this.ID_CAM_MEN_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAM_MEN_LBL.Size = new System.Drawing.Size(67, 16);
        this.ID_CAM_MEN_LBL.TabIndex = 7;
        this.ID_CAM_MEN_LBL.Tag = "";
        this.ID_CAM_MEN_LBL.Text = "Mensaje";
        // 
        // ID_CAM_CAN_PB
        // 
        this.ID_CAM_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CAM_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAM_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_CAM_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAM_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAM_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAM_CAN_PB.Location = new System.Drawing.Point(610, 290);
        this.ID_CAM_CAN_PB.Name = "ID_CAM_CAN_PB";
        this.ID_CAM_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAM_CAN_PB.Size = new System.Drawing.Size(79, 26);
        this.ID_CAM_CAN_PB.TabIndex = 2;
        this.ID_CAM_CAN_PB.Tag = "";
        this.ID_CAM_CAN_PB.Text = "Cancelar";
        this.ID_CAM_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_CAM_CAN_PB.Click += new System.EventHandler(this.ID_CAM_CAN_PB_Click);
        // 
        // ID_CAM_ACE_PB
        // 
        this.ID_CAM_ACE_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CAM_ACE_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAM_ACE_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAM_ACE_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAM_ACE_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAM_ACE_PB.Location = new System.Drawing.Point(524, 290);
        this.ID_CAM_ACE_PB.Name = "ID_CAM_ACE_PB";
        this.ID_CAM_ACE_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAM_ACE_PB.Size = new System.Drawing.Size(79, 26);
        this.ID_CAM_ACE_PB.TabIndex = 1;
        this.ID_CAM_ACE_PB.Tag = "";
        this.ID_CAM_ACE_PB.Text = "Enviar";
        this.ID_CAM_ACE_PB.UseVisualStyleBackColor = false;
        this.ID_CAM_ACE_PB.Click += new System.EventHandler(this.ID_CAM_ACE_PB_Click);
        // 
        // ID_CAM_EMP_LB
        // 
        this.ID_CAM_EMP_LB.AutoSize = true;
        this.ID_CAM_EMP_LB.BackColor = System.Drawing.Color.Silver;
        this.ID_CAM_EMP_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAM_EMP_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAM_EMP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAM_EMP_LB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAM_EMP_LB.Location = new System.Drawing.Point(330, 7);
        this.ID_CAM_EMP_LB.Name = "ID_CAM_EMP_LB";
        this.ID_CAM_EMP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAM_EMP_LB.Size = new System.Drawing.Size(70, 16);
        this.ID_CAM_EMP_LB.TabIndex = 4;
        this.ID_CAM_EMP_LB.Tag = "";
        this.ID_CAM_EMP_LB.Text = "Empresa";
        // 
        // ID_CAM_CTA_LB
        // 
        this.ID_CAM_CTA_LB.AutoSize = true;
        this.ID_CAM_CTA_LB.BackColor = System.Drawing.Color.Silver;
        this.ID_CAM_CTA_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAM_CTA_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAM_CTA_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAM_CTA_LB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAM_CTA_LB.Location = new System.Drawing.Point(201, 7);
        this.ID_CAM_CTA_LB.Name = "ID_CAM_CTA_LB";
        this.ID_CAM_CTA_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAM_CTA_LB.Size = new System.Drawing.Size(84, 16);
        this.ID_CAM_CTA_LB.TabIndex = 3;
        this.ID_CAM_CTA_LB.Tag = "";
        this.ID_CAM_CTA_LB.Text = "No. Cuenta";
        // 
        // ID_CAM_GPO_LB
        // 
        this.ID_CAM_GPO_LB.AutoSize = true;
        this.ID_CAM_GPO_LB.BackColor = System.Drawing.Color.Silver;
        this.ID_CAM_GPO_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAM_GPO_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAM_GPO_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAM_GPO_LB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAM_GPO_LB.Location = new System.Drawing.Point(410, 7);
        this.ID_CAM_GPO_LB.Name = "ID_CAM_GPO_LB";
        this.ID_CAM_GPO_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAM_GPO_LB.Size = new System.Drawing.Size(50, 16);
        this.ID_CAM_GPO_LB.TabIndex = 6;
        this.ID_CAM_GPO_LB.Tag = "";
        this.ID_CAM_GPO_LB.Text = "Grupo";
        // 
        // ID_CAM_NOM_LB
        // 
        this.ID_CAM_NOM_LB.AutoSize = true;
        this.ID_CAM_NOM_LB.BackColor = System.Drawing.Color.Silver;
        this.ID_CAM_NOM_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAM_NOM_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAM_NOM_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAM_NOM_LB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAM_NOM_LB.Location = new System.Drawing.Point(24, 8);
        this.ID_CAM_NOM_LB.Name = "ID_CAM_NOM_LB";
        this.ID_CAM_NOM_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAM_NOM_LB.Size = new System.Drawing.Size(63, 16);
        this.ID_CAM_NOM_LB.TabIndex = 5;
        this.ID_CAM_NOM_LB.Tag = "";
        this.ID_CAM_NOM_LB.Text = "Nombre";
        // 
        // SSPanel1
        // 
        this.SSPanel1.Location = new System.Drawing.Point(8, 260);
        this.SSPanel1.Name = "SSPanel1";
        this.SSPanel1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SSPanel1.OcxState")));
        this.SSPanel1.Size = new System.Drawing.Size(681, 25);
        this.SSPanel1.TabIndex = 9;
        this.SSPanel1.Tag = "";
        // 
        // picPicture
        // 
        this.picPicture.BackColor = System.Drawing.SystemColors.Control;
        this.picPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this.picPicture.Controls.Add(this.ID_CAM_MEN_LIB);
        this.picPicture.Cursor = System.Windows.Forms.Cursors.Default;
        this.picPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.picPicture.Location = new System.Drawing.Point(12, 31);
        this.picPicture.Name = "picPicture";
        this.picPicture.Size = new System.Drawing.Size(676, 205);
        this.picPicture.TabIndex = 11;
        this.picPicture.TabStop = true;
        this.picPicture.Tag = "";
        // 
        // ID_CAM_MEN_LIB
        // 
        this.ID_CAM_MEN_LIB.BackColor = System.Drawing.SystemColors.Window;
        this.ID_CAM_MEN_LIB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAM_MEN_LIB.Font = new System.Drawing.Font("Courier New", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAM_MEN_LIB.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
        this.ID_CAM_MEN_LIB.ItemHeight = 14;
        this.ID_CAM_MEN_LIB.Location = new System.Drawing.Point(-2, 1);
        this.ID_CAM_MEN_LIB.Name = "ID_CAM_MEN_LIB";
        this.ID_CAM_MEN_LIB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAM_MEN_LIB.Size = new System.Drawing.Size(676, 200);
        this.ID_CAM_MEN_LIB.TabIndex = 12;
        this.ID_CAM_MEN_LIB.Tag = "";
        // 
        // scrScroll
        // 
        this.scrScroll.Cursor = System.Windows.Forms.Cursors.Default;
        this.scrScroll.LargeChange = 1;
        this.scrScroll.Location = new System.Drawing.Point(12, 237);
        this.scrScroll.Maximum = 32767;
        this.scrScroll.Name = "scrScroll";
        this.scrScroll.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.scrScroll.Size = new System.Drawing.Size(676, 16);
        this.scrScroll.TabIndex = 10;
        this.scrScroll.TabStop = true;
        this.scrScroll.Tag = "";
        this.scrScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrScroll_Scroll);
        // 
        // ID_CAM_CONT_LBL
        // 
        this.ID_CAM_CONT_LBL.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CAM_CONT_LBL.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAM_CONT_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAM_CONT_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAM_CONT_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAM_CONT_LBL.Location = new System.Drawing.Point(13, 185);
        this.ID_CAM_CONT_LBL.Name = "ID_CAM_CONT_LBL";
        this.ID_CAM_CONT_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAM_CONT_LBL.Size = new System.Drawing.Size(84, 18);
        this.ID_CAM_CONT_LBL.TabIndex = 8;
        this.ID_CAM_CONT_LBL.Tag = "";
        // 
        // CORCAMA
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(699, 329);
        this.Controls.Add(this.ID_CAM_PRI_PNL);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Location = new System.Drawing.Point(49, 164);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORCAMA";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Cambios Pendientes S111";
        this.Closed += new System.EventHandler(this.CORCAMA_Closed);
        ((System.ComponentModel.ISupportInitialize)(this.ID_CAM_PRI_PNL)).EndInit();
        this.ID_CAM_PRI_PNL.ResumeLayout(false);
        this.ID_CAM_PRI_PNL.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.SSPanel1)).EndInit();
        this.picPicture.ResumeLayout(false);
        this.ResumeLayout(false);

	}
#endregion 
}
}