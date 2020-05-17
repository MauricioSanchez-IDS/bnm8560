using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class frm_cons_tarj_uni
	{
	
#region "Upgrade Support "
		private static frm_cons_tarj_uni m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_cons_tarj_uni DefInstance
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
		public frm_cons_tarj_uni():base(){
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
			InitializelblEtiqueta();
			InitializefrmFrame();
			InitializemkbMaskebox();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCc430.CORMDIBN.DefInstance;
			TCc430.CORMDIBN.DefInstance.Show();
		}
	public static frm_cons_tarj_uni CreateInstance()
	{
			frm_cons_tarj_uni theInstance = new frm_cons_tarj_uni();
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
	public  System.Windows.Forms.Button CM_CAN_MCC;
	public  System.Windows.Forms.ListBox ID_TARJ_UNI_LB;
	private  System.Windows.Forms.Label _SSPanel1_0Label_Text;
	private  AxThreed.AxSSPanel _SSPanel1_0;
	private  System.Windows.Forms.Label _SSPanel1_1Label_Text;
	private  AxThreed.AxSSPanel _SSPanel1_1;
	public  System.Windows.Forms.GroupBox Frame1;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_0;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_1;
	private  AxMSMask.AxMaskEdBox _mkbMaskebox_2;
	private  System.Windows.Forms.Label _lblEtiqueta_30;
	private  System.Windows.Forms.Label _lblEtiqueta_31;
	private  System.Windows.Forms.Label _lblEtiqueta_32;
	private  AxThreed.AxSSFrame _frmFrame_5;
	public AxThreed.AxSSPanel[] SSPanel1 = new AxThreed.AxSSPanel[2];
	public AxThreed.AxSSFrame[] frmFrame = new AxThreed.AxSSFrame[6];
	public System.Windows.Forms.Label[] lblEtiqueta = new System.Windows.Forms.Label[33];
	public AxMSMask.AxMaskEdBox[] mkbMaskebox = new AxMSMask.AxMaskEdBox[3];
	private Artinsoft.VB6.Gui.ListControlHelper ListBoxComboBoxHelper1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_cons_tarj_uni));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.CM_CAN_MCC = new System.Windows.Forms.Button();
        this.Frame1 = new System.Windows.Forms.GroupBox();
        this.ID_TARJ_UNI_LB = new System.Windows.Forms.ListBox();
        this._SSPanel1_1 = new AxThreed.AxSSPanel();
        this._SSPanel1_1Label_Text = new System.Windows.Forms.Label();
        this._SSPanel1_0 = new AxThreed.AxSSPanel();
        this._SSPanel1_0Label_Text = new System.Windows.Forms.Label();
        this._frmFrame_5 = new AxThreed.AxSSFrame();
        this._mkbMaskebox_2 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_1 = new AxMSMask.AxMaskEdBox();
        this._mkbMaskebox_0 = new AxMSMask.AxMaskEdBox();
        this._lblEtiqueta_30 = new System.Windows.Forms.Label();
        this._lblEtiqueta_32 = new System.Windows.Forms.Label();
        this._lblEtiqueta_31 = new System.Windows.Forms.Label();
        this.ListBoxComboBoxHelper1 = new Artinsoft.VB6.Gui.ListControlHelper(this.components);
        this.Frame1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_1)).BeginInit();
        this._SSPanel1_1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_0)).BeginInit();
        this._SSPanel1_0.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._frmFrame_5)).BeginInit();
        this._frmFrame_5.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_2)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_0)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).BeginInit();
        this.SuspendLayout();
        // 
        // CM_CAN_MCC
        // 
        this.CM_CAN_MCC.BackColor = System.Drawing.SystemColors.Control;
        this.CM_CAN_MCC.Cursor = System.Windows.Forms.Cursors.Default;
        this.CM_CAN_MCC.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.CM_CAN_MCC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.CM_CAN_MCC.ForeColor = System.Drawing.SystemColors.ControlText;
        this.CM_CAN_MCC.Location = new System.Drawing.Point(233, 250);
        this.CM_CAN_MCC.Name = "CM_CAN_MCC";
        this.CM_CAN_MCC.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.CM_CAN_MCC.Size = new System.Drawing.Size(81, 25);
        this.CM_CAN_MCC.TabIndex = 11;
        this.CM_CAN_MCC.Tag = "";
        this.CM_CAN_MCC.Text = "Cancelar";
        this.CM_CAN_MCC.UseVisualStyleBackColor = false;
        this.CM_CAN_MCC.Click += new System.EventHandler(this.CM_CAN_MCC_Click);
        // 
        // Frame1
        // 
        this.Frame1.BackColor = System.Drawing.SystemColors.Control;
        this.Frame1.Controls.Add(this.ID_TARJ_UNI_LB);
        this.Frame1.Controls.Add(this._SSPanel1_1);
        this.Frame1.Controls.Add(this._SSPanel1_0);
        this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Frame1.Location = new System.Drawing.Point(0, 48);
        this.Frame1.Name = "Frame1";
        this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Frame1.Size = new System.Drawing.Size(550, 193);
        this.Frame1.TabIndex = 7;
        this.Frame1.TabStop = false;
        this.Frame1.Tag = "";
        this.Frame1.Text = "Información TarjetaHabiente";
        // 
        // ID_TARJ_UNI_LB
        // 
        this.ID_TARJ_UNI_LB.BackColor = System.Drawing.Color.White;
        this.ID_TARJ_UNI_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_TARJ_UNI_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_TARJ_UNI_LB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ListBoxComboBoxHelper1.SetItemData(this.ID_TARJ_UNI_LB, new int[] {
            0});
        this.ID_TARJ_UNI_LB.Items.AddRange(new object[] {
            "ID_TARJ_UNI_LB"});
        this.ID_TARJ_UNI_LB.Location = new System.Drawing.Point(12, 43);
        this.ID_TARJ_UNI_LB.Name = "ID_TARJ_UNI_LB";
        this.ID_TARJ_UNI_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_TARJ_UNI_LB.Size = new System.Drawing.Size(524, 134);
        this.ID_TARJ_UNI_LB.Sorted = true;
        this.ID_TARJ_UNI_LB.TabIndex = 9;
        this.ID_TARJ_UNI_LB.Tag = "";
        // 
        // _SSPanel1_1
        // 
        this._SSPanel1_1.Controls.Add(this._SSPanel1_1Label_Text);
        this._SSPanel1_1.Location = new System.Drawing.Point(161, 23);
        this._SSPanel1_1.Name = "_SSPanel1_1";
        this._SSPanel1_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_SSPanel1_1.OcxState")));
        this._SSPanel1_1.Size = new System.Drawing.Size(375, 20);
        this._SSPanel1_1.TabIndex = 10;
        this._SSPanel1_1.Tag = "";
        // 
        // _SSPanel1_1Label_Text
        // 
        this._SSPanel1_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._SSPanel1_1Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._SSPanel1_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._SSPanel1_1Label_Text.Location = new System.Drawing.Point(0, 0);
        this._SSPanel1_1Label_Text.Name = "_SSPanel1_1Label_Text";
        this._SSPanel1_1Label_Text.Size = new System.Drawing.Size(375, 20);
        this._SSPanel1_1Label_Text.TabIndex = 0;
        this._SSPanel1_1Label_Text.Tag = "";
        this._SSPanel1_1Label_Text.Text = "Descripción";
        this._SSPanel1_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _SSPanel1_0
        // 
        this._SSPanel1_0.Controls.Add(this._SSPanel1_0Label_Text);
        this._SSPanel1_0.Location = new System.Drawing.Point(12, 23);
        this._SSPanel1_0.Name = "_SSPanel1_0";
        this._SSPanel1_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_SSPanel1_0.OcxState")));
        this._SSPanel1_0.Size = new System.Drawing.Size(149, 20);
        this._SSPanel1_0.TabIndex = 8;
        this._SSPanel1_0.Tag = "";
        // 
        // _SSPanel1_0Label_Text
        // 
        this._SSPanel1_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._SSPanel1_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._SSPanel1_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._SSPanel1_0Label_Text.Location = new System.Drawing.Point(0, 0);
        this._SSPanel1_0Label_Text.Name = "_SSPanel1_0Label_Text";
        this._SSPanel1_0Label_Text.Size = new System.Drawing.Size(149, 20);
        this._SSPanel1_0Label_Text.TabIndex = 0;
        this._SSPanel1_0Label_Text.Tag = "";
        this._SSPanel1_0Label_Text.Text = "Numero";
        this._SSPanel1_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _frmFrame_5
        // 
        this._frmFrame_5.Controls.Add(this._mkbMaskebox_2);
        this._frmFrame_5.Controls.Add(this._mkbMaskebox_1);
        this._frmFrame_5.Controls.Add(this._mkbMaskebox_0);
        this._frmFrame_5.Controls.Add(this._lblEtiqueta_30);
        this._frmFrame_5.Controls.Add(this._lblEtiqueta_32);
        this._frmFrame_5.Controls.Add(this._lblEtiqueta_31);
        this._frmFrame_5.Location = new System.Drawing.Point(0, 0);
        this._frmFrame_5.Name = "_frmFrame_5";
        this._frmFrame_5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_frmFrame_5.OcxState")));
        this._frmFrame_5.Size = new System.Drawing.Size(550, 46);
        this._frmFrame_5.TabIndex = 0;
        this._frmFrame_5.Tag = "";
        // 
        // _mkbMaskebox_2
        // 
        this._mkbMaskebox_2.Location = new System.Drawing.Point(494, 18);
        this._mkbMaskebox_2.Name = "_mkbMaskebox_2";
        this._mkbMaskebox_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_2.OcxState")));
        this._mkbMaskebox_2.Size = new System.Drawing.Size(41, 21);
        this._mkbMaskebox_2.TabIndex = 3;
        this._mkbMaskebox_2.Tag = "";
        // 
        // _mkbMaskebox_1
        // 
        this._mkbMaskebox_1.Location = new System.Drawing.Point(224, 18);
        this._mkbMaskebox_1.Name = "_mkbMaskebox_1";
        this._mkbMaskebox_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_1.OcxState")));
        this._mkbMaskebox_1.Size = new System.Drawing.Size(231, 21);
        this._mkbMaskebox_1.TabIndex = 2;
        this._mkbMaskebox_1.Tag = "";
        // 
        // _mkbMaskebox_0
        // 
        this._mkbMaskebox_0.Location = new System.Drawing.Point(56, 18);
        this._mkbMaskebox_0.Name = "_mkbMaskebox_0";
        this._mkbMaskebox_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_mkbMaskebox_0.OcxState")));
        this._mkbMaskebox_0.Size = new System.Drawing.Size(120, 21);
        this._mkbMaskebox_0.TabIndex = 1;
        this._mkbMaskebox_0.Tag = "";
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
        this._lblEtiqueta_30.TabIndex = 6;
        this._lblEtiqueta_30.Tag = "";
        this._lblEtiqueta_30.Text = "Nivel";
        // 
        // _lblEtiqueta_32
        // 
        this._lblEtiqueta_32.AutoSize = true;
        this._lblEtiqueta_32.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_32.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_32.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_32.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_32.Location = new System.Drawing.Point(180, 21);
        this._lblEtiqueta_32.Name = "_lblEtiqueta_32";
        this._lblEtiqueta_32.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_32.Size = new System.Drawing.Size(44, 13);
        this._lblEtiqueta_32.TabIndex = 4;
        this._lblEtiqueta_32.Tag = "";
        this._lblEtiqueta_32.Text = "Nombre";
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
        this._lblEtiqueta_31.TabIndex = 5;
        this._lblEtiqueta_31.Tag = "";
        this._lblEtiqueta_31.Text = "Unidad";
        // 
        // frm_cons_tarj_uni
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(550, 280);
        this.Controls.Add(this._frmFrame_5);
        this.Controls.Add(this.Frame1);
        this.Controls.Add(this.CM_CAN_MCC);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(164, 145);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frm_cons_tarj_uni";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "TarjetaHabientes Asignados a Unidades";
        this.Closed += new System.EventHandler(this.frm_cons_tarj_uni_Closed);
        this.Frame1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_1)).EndInit();
        this._SSPanel1_1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._SSPanel1_0)).EndInit();
        this._SSPanel1_0.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._frmFrame_5)).EndInit();
        this._frmFrame_5.ResumeLayout(false);
        this._frmFrame_5.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_2)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this._mkbMaskebox_0)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ListBoxComboBoxHelper1)).EndInit();
        this.ResumeLayout(false);

	}
	void  InitializeSSPanel1()
	{
			this.SSPanel1[0] = _SSPanel1_0;
			this.SSPanel1[1] = _SSPanel1_1;
	}
	void  InitializelblEtiqueta()
	{
			this.lblEtiqueta[30] = _lblEtiqueta_30;
			this.lblEtiqueta[31] = _lblEtiqueta_31;
			this.lblEtiqueta[32] = _lblEtiqueta_32;
	}
	void  InitializefrmFrame()
	{
			this.frmFrame[5] = _frmFrame_5;
	}
	void  InitializemkbMaskebox()
	{
			this.mkbMaskebox[0] = _mkbMaskebox_0;
			this.mkbMaskebox[1] = _mkbMaskebox_1;
			this.mkbMaskebox[2] = _mkbMaskebox_2;
	}
#endregion 
}
}