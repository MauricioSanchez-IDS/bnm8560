using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORCTCATS
	{
	
#region "Upgrade Support "
		private static CORCTCATS m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORCTCATS DefInstance
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
		public CORCTCATS():base(){
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
			Initializepanel_titulos();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORCTCATS CreateInstance()
	{
			CORCTCATS theInstance = new CORCTCATS();
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
        private System.Windows.Forms.Label _SSPanel1_0Label_Text;
	public  System.Windows.Forms.ListBox ID_CAT_LB;
	public  System.Windows.Forms.TextBox ID_PROD;
	public  System.Windows.Forms.TextBox ID_EST_TXT;
	public  System.Windows.Forms.Button ID_CAT_ALT_PB;
	public  System.Windows.Forms.Button ID_CAT_BAJ_PB;
	public  System.Windows.Forms.Button ID_CAT_RAPA_PB;
	public  System.Windows.Forms.Button ID_CAT_CON_PB;
	public  System.Windows.Forms.Button ID_CAT_CAM_PB;
	public  System.Windows.Forms.Button ID_CAT_UNPA_PB;
	public  System.Windows.Forms.Button ID_CAT_SAPA_PB;
        private System.Windows.Forms.Label _SSPanel1_1Label_Text;
        private System.Windows.Forms.Label _panel_titulos_0Label_Text;
        private System.Windows.Forms.Label _panel_titulos_1Label_Text;
	public  System.Windows.Forms.GroupBox Frame1;
	public AxThreed.AxSSPanel[] SSPanel1 = new AxThreed.AxSSPanel[2];
	public AxThreed.AxSSPanel[] panel_titulos = new AxThreed.AxSSPanel[2];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.Frame1 = new System.Windows.Forms.GroupBox();
        this._SSPanel1_0Label_Text = new System.Windows.Forms.Label();
        this._SSPanel1_1Label_Text = new System.Windows.Forms.Label();
        this._panel_titulos_1Label_Text = new System.Windows.Forms.Label();
        this._panel_titulos_0Label_Text = new System.Windows.Forms.Label();
        this.ID_CAT_RAPA_PB = new System.Windows.Forms.Button();
        this.ID_CAT_CON_PB = new System.Windows.Forms.Button();
        this.ID_CAT_BAJ_PB = new System.Windows.Forms.Button();
        this.ID_PROD = new System.Windows.Forms.TextBox();
        this.ID_EST_TXT = new System.Windows.Forms.TextBox();
        this.ID_CAT_ALT_PB = new System.Windows.Forms.Button();
        this.ID_CAT_CAM_PB = new System.Windows.Forms.Button();
        this.ID_CAT_UNPA_PB = new System.Windows.Forms.Button();
        this.ID_CAT_SAPA_PB = new System.Windows.Forms.Button();
        this.ID_CAT_LB = new System.Windows.Forms.ListBox();
        this.Frame1.SuspendLayout();
        this.SuspendLayout();
        // 
        // Frame1
        // 
        this.Frame1.BackColor = System.Drawing.SystemColors.Control;
        this.Frame1.Controls.Add(this._SSPanel1_0Label_Text);
        this.Frame1.Controls.Add(this._SSPanel1_1Label_Text);
        this.Frame1.Controls.Add(this._panel_titulos_1Label_Text);
        this.Frame1.Controls.Add(this._panel_titulos_0Label_Text);
        this.Frame1.Controls.Add(this.ID_CAT_RAPA_PB);
        this.Frame1.Controls.Add(this.ID_CAT_CON_PB);
        this.Frame1.Controls.Add(this.ID_CAT_BAJ_PB);
        this.Frame1.Controls.Add(this.ID_PROD);
        this.Frame1.Controls.Add(this.ID_EST_TXT);
        this.Frame1.Controls.Add(this.ID_CAT_ALT_PB);
        this.Frame1.Controls.Add(this.ID_CAT_CAM_PB);
        this.Frame1.Controls.Add(this.ID_CAT_UNPA_PB);
        this.Frame1.Controls.Add(this.ID_CAT_SAPA_PB);
        this.Frame1.Controls.Add(this.ID_CAT_LB);
        this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Frame1.Location = new System.Drawing.Point(0, 0);
        this.Frame1.Name = "Frame1";
        this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Frame1.Size = new System.Drawing.Size(373, 263);
        this.Frame1.TabIndex = 0;
        this.Frame1.TabStop = false;
        this.Frame1.Tag = "";
        this.Frame1.Text = "Información Categorías";
        // 
        // _SSPanel1_0Label_Text
        // 
        this._SSPanel1_0Label_Text.BackColor = System.Drawing.Color.Silver;
        this._SSPanel1_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._SSPanel1_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._SSPanel1_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._SSPanel1_0Label_Text.Location = new System.Drawing.Point(24, 22);
        this._SSPanel1_0Label_Text.Name = "_SSPanel1_0Label_Text";
        this._SSPanel1_0Label_Text.Size = new System.Drawing.Size(69, 21);
        this._SSPanel1_0Label_Text.TabIndex = 0;
        this._SSPanel1_0Label_Text.Tag = "";
        this._SSPanel1_0Label_Text.Text = "Producto";
        this._SSPanel1_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _SSPanel1_1Label_Text
        // 
        this._SSPanel1_1Label_Text.BackColor = System.Drawing.Color.Silver;
        this._SSPanel1_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._SSPanel1_1Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._SSPanel1_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._SSPanel1_1Label_Text.Location = new System.Drawing.Point(24, 46);
        this._SSPanel1_1Label_Text.Name = "_SSPanel1_1Label_Text";
        this._SSPanel1_1Label_Text.Size = new System.Drawing.Size(69, 29);
        this._SSPanel1_1Label_Text.TabIndex = 0;
        this._SSPanel1_1Label_Text.Tag = "";
        this._SSPanel1_1Label_Text.Text = "Estructura de Gastos";
        this._SSPanel1_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _panel_titulos_1Label_Text
        // 
        this._panel_titulos_1Label_Text.BackColor = System.Drawing.Color.Silver;
        this._panel_titulos_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._panel_titulos_1Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._panel_titulos_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._panel_titulos_1Label_Text.Location = new System.Drawing.Point(87, 84);
        this._panel_titulos_1Label_Text.Name = "_panel_titulos_1Label_Text";
        this._panel_titulos_1Label_Text.Size = new System.Drawing.Size(178, 17);
        this._panel_titulos_1Label_Text.TabIndex = 0;
        this._panel_titulos_1Label_Text.Tag = "";
        this._panel_titulos_1Label_Text.Text = "Descripción";
        this._panel_titulos_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _panel_titulos_0Label_Text
        // 
        this._panel_titulos_0Label_Text.BackColor = System.Drawing.Color.Silver;
        this._panel_titulos_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._panel_titulos_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._panel_titulos_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._panel_titulos_0Label_Text.Location = new System.Drawing.Point(14, 84);
        this._panel_titulos_0Label_Text.Name = "_panel_titulos_0Label_Text";
        this._panel_titulos_0Label_Text.Size = new System.Drawing.Size(67, 17);
        this._panel_titulos_0Label_Text.TabIndex = 0;
        this._panel_titulos_0Label_Text.Tag = "";
        this._panel_titulos_0Label_Text.Text = "Clave";
        this._panel_titulos_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_CAT_RAPA_PB
        // 
        this.ID_CAT_RAPA_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CAT_RAPA_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAT_RAPA_PB.Enabled = false;
        this.ID_CAT_RAPA_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAT_RAPA_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAT_RAPA_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAT_RAPA_PB.Location = new System.Drawing.Point(276, 206);
        this.ID_CAT_RAPA_PB.Name = "ID_CAT_RAPA_PB";
        this.ID_CAT_RAPA_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAT_RAPA_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_CAT_RAPA_PB.TabIndex = 5;
        this.ID_CAT_RAPA_PB.Tag = "";
        this.ID_CAT_RAPA_PB.Text = "&Rangos...";
        this.ID_CAT_RAPA_PB.UseVisualStyleBackColor = false;
        this.ID_CAT_RAPA_PB.Click += new System.EventHandler(this.ID_CAT_RAPA_PB_Click);
        // 
        // ID_CAT_CON_PB
        // 
        this.ID_CAT_CON_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CAT_CON_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAT_CON_PB.Enabled = false;
        this.ID_CAT_CON_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAT_CON_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAT_CON_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAT_CON_PB.Location = new System.Drawing.Point(276, 152);
        this.ID_CAT_CON_PB.Name = "ID_CAT_CON_PB";
        this.ID_CAT_CON_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAT_CON_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_CAT_CON_PB.TabIndex = 4;
        this.ID_CAT_CON_PB.Tag = "";
        this.ID_CAT_CON_PB.Text = "&Consultas...";
        this.ID_CAT_CON_PB.UseVisualStyleBackColor = false;
        this.ID_CAT_CON_PB.Click += new System.EventHandler(this.ID_CAT_CON_PB_Click);
        // 
        // ID_CAT_BAJ_PB
        // 
        this.ID_CAT_BAJ_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CAT_BAJ_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAT_BAJ_PB.Enabled = false;
        this.ID_CAT_BAJ_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAT_BAJ_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAT_BAJ_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAT_BAJ_PB.Location = new System.Drawing.Point(276, 106);
        this.ID_CAT_BAJ_PB.Name = "ID_CAT_BAJ_PB";
        this.ID_CAT_BAJ_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAT_BAJ_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_CAT_BAJ_PB.TabIndex = 6;
        this.ID_CAT_BAJ_PB.Tag = "";
        this.ID_CAT_BAJ_PB.Text = "&Bajas...";
        this.ID_CAT_BAJ_PB.UseVisualStyleBackColor = false;
        this.ID_CAT_BAJ_PB.Click += new System.EventHandler(this.ID_CAT_BAJ_PB_Click);
        // 
        // ID_PROD
        // 
        this.ID_PROD.AcceptsReturn = true;
        this.ID_PROD.BackColor = System.Drawing.SystemColors.Window;
        this.ID_PROD.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_PROD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_PROD.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_PROD.Location = new System.Drawing.Point(94, 22);
        this.ID_PROD.MaxLength = 0;
        this.ID_PROD.Name = "ID_PROD";
        this.ID_PROD.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_PROD.Size = new System.Drawing.Size(146, 20);
        this.ID_PROD.TabIndex = 9;
        this.ID_PROD.Tag = "";
        this.ID_PROD.Text = "PRODUCTO";
        // 
        // ID_EST_TXT
        // 
        this.ID_EST_TXT.AcceptsReturn = true;
        this.ID_EST_TXT.BackColor = System.Drawing.SystemColors.Window;
        this.ID_EST_TXT.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.ID_EST_TXT.Enabled = false;
        this.ID_EST_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_EST_TXT.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_EST_TXT.Location = new System.Drawing.Point(95, 51);
        this.ID_EST_TXT.MaxLength = 0;
        this.ID_EST_TXT.Name = "ID_EST_TXT";
        this.ID_EST_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_EST_TXT.Size = new System.Drawing.Size(146, 20);
        this.ID_EST_TXT.TabIndex = 8;
        this.ID_EST_TXT.Tag = "";
        this.ID_EST_TXT.Text = "ID_EST_TXT";
        // 
        // ID_CAT_ALT_PB
        // 
        this.ID_CAT_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CAT_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAT_ALT_PB.Enabled = false;
        this.ID_CAT_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAT_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAT_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAT_ALT_PB.Location = new System.Drawing.Point(276, 84);
        this.ID_CAT_ALT_PB.Name = "ID_CAT_ALT_PB";
        this.ID_CAT_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAT_ALT_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_CAT_ALT_PB.TabIndex = 7;
        this.ID_CAT_ALT_PB.Tag = "";
        this.ID_CAT_ALT_PB.Text = "&Alta...";
        this.ID_CAT_ALT_PB.UseVisualStyleBackColor = false;
        this.ID_CAT_ALT_PB.Click += new System.EventHandler(this.ID_CAT_ALT_PB_Click);
        // 
        // ID_CAT_CAM_PB
        // 
        this.ID_CAT_CAM_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CAT_CAM_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAT_CAM_PB.Enabled = false;
        this.ID_CAT_CAM_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAT_CAM_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAT_CAM_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAT_CAM_PB.Location = new System.Drawing.Point(276, 129);
        this.ID_CAT_CAM_PB.Name = "ID_CAT_CAM_PB";
        this.ID_CAT_CAM_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAT_CAM_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_CAT_CAM_PB.TabIndex = 3;
        this.ID_CAT_CAM_PB.Tag = "";
        this.ID_CAT_CAM_PB.Text = "Ca&mbio...";
        this.ID_CAT_CAM_PB.UseVisualStyleBackColor = false;
        this.ID_CAT_CAM_PB.Click += new System.EventHandler(this.ID_CAT_CAM_PB_Click);
        // 
        // ID_CAT_UNPA_PB
        // 
        this.ID_CAT_UNPA_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CAT_UNPA_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAT_UNPA_PB.Enabled = false;
        this.ID_CAT_UNPA_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAT_UNPA_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAT_UNPA_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAT_UNPA_PB.Location = new System.Drawing.Point(276, 175);
        this.ID_CAT_UNPA_PB.Name = "ID_CAT_UNPA_PB";
        this.ID_CAT_UNPA_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAT_UNPA_PB.Size = new System.Drawing.Size(80, 30);
        this.ID_CAT_UNPA_PB.TabIndex = 2;
        this.ID_CAT_UNPA_PB.Tag = "";
        this.ID_CAT_UNPA_PB.Text = "C&onsulta de unidades...";
        this.ID_CAT_UNPA_PB.UseVisualStyleBackColor = false;
        this.ID_CAT_UNPA_PB.Click += new System.EventHandler(this.ID_CAT_UNPA_PB_Click);
        // 
        // ID_CAT_SAPA_PB
        // 
        this.ID_CAT_SAPA_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_CAT_SAPA_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAT_SAPA_PB.Enabled = false;
        this.ID_CAT_SAPA_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_CAT_SAPA_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAT_SAPA_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_CAT_SAPA_PB.Location = new System.Drawing.Point(276, 229);
        this.ID_CAT_SAPA_PB.Name = "ID_CAT_SAPA_PB";
        this.ID_CAT_SAPA_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAT_SAPA_PB.Size = new System.Drawing.Size(80, 21);
        this.ID_CAT_SAPA_PB.TabIndex = 1;
        this.ID_CAT_SAPA_PB.Tag = "";
        this.ID_CAT_SAPA_PB.Text = "&Salir";
        this.ID_CAT_SAPA_PB.UseVisualStyleBackColor = false;
        this.ID_CAT_SAPA_PB.Click += new System.EventHandler(this.ID_CAT_SAPA_PB_Click);
        // 
        // ID_CAT_LB
        // 
        this.ID_CAT_LB.BackColor = System.Drawing.Color.White;
        this.ID_CAT_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CAT_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CAT_LB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CAT_LB.Location = new System.Drawing.Point(14, 101);
        this.ID_CAT_LB.Name = "ID_CAT_LB";
        this.ID_CAT_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CAT_LB.Size = new System.Drawing.Size(251, 147);
        this.ID_CAT_LB.Sorted = true;
        this.ID_CAT_LB.TabIndex = 10;
        this.ID_CAT_LB.Tag = "";
        // 
        // CORCTCATS
        // 
        this.AcceptButton = this.ID_CAT_ALT_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(373, 263);
        this.Controls.Add(this.Frame1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(315, 245);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORCTCATS";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Categorías ";
        this.Closed += new System.EventHandler(this.CORCTCATS_Closed);
        this.Frame1.ResumeLayout(false);
        this.Frame1.PerformLayout();
        this.ResumeLayout(false);

	}
	void  InitializeSSPanel1()
	{
            //this.SSPanel1[0] = _SSPanel1_0;
            //this.SSPanel1[1] = _SSPanel1_1;
	}
	void  Initializepanel_titulos()
	{
            //this.panel_titulos[0] = _panel_titulos_0;
            //this.panel_titulos[1] = _panel_titulos_1;
	}
#endregion 
}
}