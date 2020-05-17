using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class frm_men_cat
	{
	
#region "Upgrade Support "
		private static frm_men_cat m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_men_cat DefInstance
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
		public frm_men_cat():base(){
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
			InitializeID_CEE_ETI_PNL();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static frm_men_cat CreateInstance()
	{
			frm_men_cat theInstance = new frm_men_cat();
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
	public  System.Windows.Forms.Button ID_CEE_CON_PB;
	public  System.Windows.Forms.Button ID_CEE_SAL_PB;
	public  System.Windows.Forms.Button ID_CEE_ALT_PB;
	public  System.Windows.Forms.Button ID_CEE_CAM_PB;
	public  System.Windows.Forms.ComboBox ID_CEE_GRU_COB;
	public  System.Windows.Forms.ComboBox ID_CEE_EMP_COB;
	public  System.Windows.Forms.ComboBox ID_CEE_UNI_COB;
	private  System.Windows.Forms.Label _ID_CEE_ETI_PNL_1Label_Text;
	private  AxThreed.AxSSPanel _ID_CEE_ETI_PNL_1;
	private  System.Windows.Forms.Label _ID_CEE_ETI_PNL_0Label_Text;
	private  AxThreed.AxSSPanel _ID_CEE_ETI_PNL_0;
	private  System.Windows.Forms.Label _ID_CEE_ETI_PNL_2Label_Text;
	private  AxThreed.AxSSPanel _ID_CEE_ETI_PNL_2;
	public  AxThreed.AxSSPanel ID_CEE_PPL_PNL;
	public AxThreed.AxSSPanel[] ID_CEE_ETI_PNL = new AxThreed.AxSSPanel[3];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_men_cat));
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ID_CEE_PPL_PNL = new AxThreed.AxSSPanel();
            this.ID_CEE_GRU_COB = new System.Windows.Forms.ComboBox();
            this.ID_CEE_EMP_COB = new System.Windows.Forms.ComboBox();
            this.ID_CEE_ALT_PB = new System.Windows.Forms.Button();
            this.ID_CEE_CAM_PB = new System.Windows.Forms.Button();
            this._ID_CEE_ETI_PNL_0 = new AxThreed.AxSSPanel();
            this._ID_CEE_ETI_PNL_0Label_Text = new System.Windows.Forms.Label();
            this._ID_CEE_ETI_PNL_2 = new AxThreed.AxSSPanel();
            this._ID_CEE_ETI_PNL_2Label_Text = new System.Windows.Forms.Label();
            this.ID_CEE_UNI_COB = new System.Windows.Forms.ComboBox();
            this._ID_CEE_ETI_PNL_1 = new AxThreed.AxSSPanel();
            this._ID_CEE_ETI_PNL_1Label_Text = new System.Windows.Forms.Label();
            this.ID_CEE_SAL_PB = new System.Windows.Forms.Button();
            this.ID_CEE_CON_PB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEE_PPL_PNL)).BeginInit();
            this.ID_CEE_PPL_PNL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_0)).BeginInit();
            this._ID_CEE_ETI_PNL_0.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_2)).BeginInit();
            this._ID_CEE_ETI_PNL_2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_1)).BeginInit();
            this._ID_CEE_ETI_PNL_1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ID_CEE_PPL_PNL
            // 
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_GRU_COB);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_EMP_COB);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_ALT_PB);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_CAM_PB);
            this.ID_CEE_PPL_PNL.Controls.Add(this._ID_CEE_ETI_PNL_0);
            this.ID_CEE_PPL_PNL.Controls.Add(this._ID_CEE_ETI_PNL_2);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_UNI_COB);
            this.ID_CEE_PPL_PNL.Controls.Add(this._ID_CEE_ETI_PNL_1);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_SAL_PB);
            this.ID_CEE_PPL_PNL.Controls.Add(this.ID_CEE_CON_PB);
            this.ID_CEE_PPL_PNL.Location = new System.Drawing.Point(0, 0);
            this.ID_CEE_PPL_PNL.Name = "ID_CEE_PPL_PNL";
            this.ID_CEE_PPL_PNL.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ID_CEE_PPL_PNL.OcxState")));
            this.ID_CEE_PPL_PNL.Size = new System.Drawing.Size(636, 144);
            this.ID_CEE_PPL_PNL.TabIndex = 0;
            this.ID_CEE_PPL_PNL.Tag = "";
            // 
            // ID_CEE_GRU_COB
            // 
            this.ID_CEE_GRU_COB.BackColor = System.Drawing.Color.White;
            this.ID_CEE_GRU_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_GRU_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_GRU_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEE_GRU_COB.Location = new System.Drawing.Point(113, 32);
            this.ID_CEE_GRU_COB.Name = "ID_CEE_GRU_COB";
            this.ID_CEE_GRU_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_GRU_COB.Size = new System.Drawing.Size(338, 21);
            this.ID_CEE_GRU_COB.Sorted = true;
            this.ID_CEE_GRU_COB.TabIndex = 3;
            this.ID_CEE_GRU_COB.Tag = "";
            this.ID_CEE_GRU_COB.Text = "ID_CEE_GRU_COB";
            this.ID_CEE_GRU_COB.SelectionChangeCommitted += new System.EventHandler(this.ID_CEE_GRU_COB_SelectionChangeCommitted);
            // 
            // ID_CEE_EMP_COB
            // 
            this.ID_CEE_EMP_COB.BackColor = System.Drawing.Color.White;
            this.ID_CEE_EMP_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_EMP_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_CEE_EMP_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_EMP_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEE_EMP_COB.Location = new System.Drawing.Point(114, 58);
            this.ID_CEE_EMP_COB.Name = "ID_CEE_EMP_COB";
            this.ID_CEE_EMP_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_EMP_COB.Size = new System.Drawing.Size(338, 21);
            this.ID_CEE_EMP_COB.Sorted = true;
            this.ID_CEE_EMP_COB.TabIndex = 2;
            this.ID_CEE_EMP_COB.Tag = "";
            this.ID_CEE_EMP_COB.SelectedIndexChanged += new System.EventHandler(this.ID_CEE_EMP_COB_SelectedIndexChanged);
            // 
            // ID_CEE_ALT_PB
            // 
            this.ID_CEE_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEE_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEE_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEE_ALT_PB.Location = new System.Drawing.Point(486, 23);
            this.ID_CEE_ALT_PB.Name = "ID_CEE_ALT_PB";
            this.ID_CEE_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_ALT_PB.Size = new System.Drawing.Size(111, 25);
            this.ID_CEE_ALT_PB.TabIndex = 5;
            this.ID_CEE_ALT_PB.Tag = "";
            this.ID_CEE_ALT_PB.Text = "&Altas...";
            this.ID_CEE_ALT_PB.UseVisualStyleBackColor = false;
            this.ID_CEE_ALT_PB.Click += new System.EventHandler(this.ID_CEE_ALT_PB_Click);
            // 
            // ID_CEE_CAM_PB
            // 
            this.ID_CEE_CAM_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEE_CAM_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_CAM_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEE_CAM_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_CAM_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEE_CAM_PB.Location = new System.Drawing.Point(486, 48);
            this.ID_CEE_CAM_PB.Name = "ID_CEE_CAM_PB";
            this.ID_CEE_CAM_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_CAM_PB.Size = new System.Drawing.Size(111, 25);
            this.ID_CEE_CAM_PB.TabIndex = 4;
            this.ID_CEE_CAM_PB.Tag = "";
            this.ID_CEE_CAM_PB.Text = "&Cambios...";
            this.ID_CEE_CAM_PB.UseVisualStyleBackColor = false;
            this.ID_CEE_CAM_PB.Click += new System.EventHandler(this.ID_CEE_CAM_PB_Click);
            // 
            // _ID_CEE_ETI_PNL_0
            // 
            this._ID_CEE_ETI_PNL_0.Controls.Add(this._ID_CEE_ETI_PNL_0Label_Text);
            this._ID_CEE_ETI_PNL_0.Location = new System.Drawing.Point(35, 58);
            this._ID_CEE_ETI_PNL_0.Name = "_ID_CEE_ETI_PNL_0";
            this._ID_CEE_ETI_PNL_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEE_ETI_PNL_0.OcxState")));
            this._ID_CEE_ETI_PNL_0.Size = new System.Drawing.Size(75, 24);
            this._ID_CEE_ETI_PNL_0.TabIndex = 9;
            this._ID_CEE_ETI_PNL_0.Tag = "";
            // 
            // _ID_CEE_ETI_PNL_0Label_Text
            // 
            this._ID_CEE_ETI_PNL_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEE_ETI_PNL_0Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEE_ETI_PNL_0Label_Text.Location = new System.Drawing.Point(0, 0);
            this._ID_CEE_ETI_PNL_0Label_Text.Name = "_ID_CEE_ETI_PNL_0Label_Text";
            this._ID_CEE_ETI_PNL_0Label_Text.Size = new System.Drawing.Size(73, 22);
            this._ID_CEE_ETI_PNL_0Label_Text.TabIndex = 0;
            this._ID_CEE_ETI_PNL_0Label_Text.Tag = "";
            this._ID_CEE_ETI_PNL_0Label_Text.Text = " &Empresa      ";
            this._ID_CEE_ETI_PNL_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _ID_CEE_ETI_PNL_2
            // 
            this._ID_CEE_ETI_PNL_2.Controls.Add(this._ID_CEE_ETI_PNL_2Label_Text);
            this._ID_CEE_ETI_PNL_2.Location = new System.Drawing.Point(35, 83);
            this._ID_CEE_ETI_PNL_2.Name = "_ID_CEE_ETI_PNL_2";
            this._ID_CEE_ETI_PNL_2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEE_ETI_PNL_2.OcxState")));
            this._ID_CEE_ETI_PNL_2.Size = new System.Drawing.Size(75, 24);
            this._ID_CEE_ETI_PNL_2.TabIndex = 10;
            this._ID_CEE_ETI_PNL_2.Tag = "";
            // 
            // _ID_CEE_ETI_PNL_2Label_Text
            // 
            this._ID_CEE_ETI_PNL_2Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEE_ETI_PNL_2Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEE_ETI_PNL_2Label_Text.Location = new System.Drawing.Point(0, 0);
            this._ID_CEE_ETI_PNL_2Label_Text.Name = "_ID_CEE_ETI_PNL_2Label_Text";
            this._ID_CEE_ETI_PNL_2Label_Text.Size = new System.Drawing.Size(73, 22);
            this._ID_CEE_ETI_PNL_2Label_Text.TabIndex = 0;
            this._ID_CEE_ETI_PNL_2Label_Text.Tag = "";
            this._ID_CEE_ETI_PNL_2Label_Text.Text = " &Unidad";
            this._ID_CEE_ETI_PNL_2Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ID_CEE_UNI_COB
            // 
            this.ID_CEE_UNI_COB.BackColor = System.Drawing.Color.White;
            this.ID_CEE_UNI_COB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_UNI_COB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ID_CEE_UNI_COB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_UNI_COB.ForeColor = System.Drawing.SystemColors.WindowText;
            this.ID_CEE_UNI_COB.Location = new System.Drawing.Point(114, 84);
            this.ID_CEE_UNI_COB.Name = "ID_CEE_UNI_COB";
            this.ID_CEE_UNI_COB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_UNI_COB.Size = new System.Drawing.Size(339, 21);
            this.ID_CEE_UNI_COB.Sorted = true;
            this.ID_CEE_UNI_COB.TabIndex = 1;
            this.ID_CEE_UNI_COB.Tag = "";
            // 
            // _ID_CEE_ETI_PNL_1
            // 
            this._ID_CEE_ETI_PNL_1.Controls.Add(this._ID_CEE_ETI_PNL_1Label_Text);
            this._ID_CEE_ETI_PNL_1.Location = new System.Drawing.Point(35, 33);
            this._ID_CEE_ETI_PNL_1.Name = "_ID_CEE_ETI_PNL_1";
            this._ID_CEE_ETI_PNL_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEE_ETI_PNL_1.OcxState")));
            this._ID_CEE_ETI_PNL_1.Size = new System.Drawing.Size(75, 24);
            this._ID_CEE_ETI_PNL_1.TabIndex = 8;
            this._ID_CEE_ETI_PNL_1.Tag = "";
            // 
            // _ID_CEE_ETI_PNL_1Label_Text
            // 
            this._ID_CEE_ETI_PNL_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._ID_CEE_ETI_PNL_1Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
            this._ID_CEE_ETI_PNL_1Label_Text.Location = new System.Drawing.Point(0, 0);
            this._ID_CEE_ETI_PNL_1Label_Text.Name = "_ID_CEE_ETI_PNL_1Label_Text";
            this._ID_CEE_ETI_PNL_1Label_Text.Size = new System.Drawing.Size(73, 22);
            this._ID_CEE_ETI_PNL_1Label_Text.TabIndex = 0;
            this._ID_CEE_ETI_PNL_1Label_Text.Tag = "";
            this._ID_CEE_ETI_PNL_1Label_Text.Text = " &Grupo";
            this._ID_CEE_ETI_PNL_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ID_CEE_SAL_PB
            // 
            this.ID_CEE_SAL_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEE_SAL_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_SAL_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.ID_CEE_SAL_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEE_SAL_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_SAL_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEE_SAL_PB.Location = new System.Drawing.Point(486, 98);
            this.ID_CEE_SAL_PB.Name = "ID_CEE_SAL_PB";
            this.ID_CEE_SAL_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_SAL_PB.Size = new System.Drawing.Size(111, 25);
            this.ID_CEE_SAL_PB.TabIndex = 6;
            this.ID_CEE_SAL_PB.Tag = "";
            this.ID_CEE_SAL_PB.Text = "&Salir";
            this.ID_CEE_SAL_PB.UseVisualStyleBackColor = false;
            this.ID_CEE_SAL_PB.Click += new System.EventHandler(this.ID_CEE_SAL_PB_Click);
            // 
            // ID_CEE_CON_PB
            // 
            this.ID_CEE_CON_PB.BackColor = System.Drawing.SystemColors.Control;
            this.ID_CEE_CON_PB.Cursor = System.Windows.Forms.Cursors.Default;
            this.ID_CEE_CON_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ID_CEE_CON_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CEE_CON_PB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ID_CEE_CON_PB.Location = new System.Drawing.Point(486, 73);
            this.ID_CEE_CON_PB.Name = "ID_CEE_CON_PB";
            this.ID_CEE_CON_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ID_CEE_CON_PB.Size = new System.Drawing.Size(111, 25);
            this.ID_CEE_CON_PB.TabIndex = 7;
            this.ID_CEE_CON_PB.Tag = "";
            this.ID_CEE_CON_PB.Text = "C&onsultas...";
            this.ID_CEE_CON_PB.UseVisualStyleBackColor = false;
            this.ID_CEE_CON_PB.Click += new System.EventHandler(this.ID_CEE_CON_PB_Click);
            // 
            // frm_men_cat
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.ID_CEE_SAL_PB;
            this.ClientSize = new System.Drawing.Size(635, 143);
            this.Controls.Add(this.ID_CEE_PPL_PNL);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(97, 360);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_men_cat";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Tag = "";
            this.Text = "Categorias";
            this.Closed += new System.EventHandler(this.frm_men_cat_Closed);
            ((System.ComponentModel.ISupportInitialize)(this.ID_CEE_PPL_PNL)).EndInit();
            this.ID_CEE_PPL_PNL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_0)).EndInit();
            this._ID_CEE_ETI_PNL_0.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_2)).EndInit();
            this._ID_CEE_ETI_PNL_2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_1)).EndInit();
            this._ID_CEE_ETI_PNL_1.ResumeLayout(false);
            this.ResumeLayout(false);

	}
	void  InitializeID_CEE_ETI_PNL()
	{
			this.ID_CEE_ETI_PNL[1] = _ID_CEE_ETI_PNL_1;
			this.ID_CEE_ETI_PNL[0] = _ID_CEE_ETI_PNL_0;
			this.ID_CEE_ETI_PNL[2] = _ID_CEE_ETI_PNL_2;
	}
#endregion 
}
}