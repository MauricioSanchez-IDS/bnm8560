using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORCTESTRUCT2
	{
	
#region "Upgrade Support "
		private static CORCTESTRUCT2 m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORCTESTRUCT2 DefInstance
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
		public CORCTESTRUCT2():base(){
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
			Initializepanel_titulos();
			InitializeID_CEE_ETI_PNL();
			InitializetxtTexto();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORCTESTRUCT2 CreateInstance()
	{
			CORCTESTRUCT2 theInstance = new CORCTESTRUCT2();
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
	public  System.Windows.Forms.Button ID_SALIR_PB;
	public  System.Windows.Forms.Button ID_EST_ALT_PB;
	public  System.Windows.Forms.Button ID_EST_BAJ_PB;
	public  System.Windows.Forms.Button ID_EST_CAM_PB;
	public  System.Windows.Forms.Button ID_EST_CON_PB;
	public  System.Windows.Forms.ListBox ID_CEE_ESTRUCT_LB;
	private  System.Windows.Forms.Label _panel_titulos_0Label_Text;
	private  AxThreed.AxSSPanel _panel_titulos_0;
	private  System.Windows.Forms.TextBox _txtTexto_0;
	public  System.Windows.Forms.Button ID_EST_EMPA_PB;
	public  System.Windows.Forms.Button ID_EST_CAT_PB;
	private  System.Windows.Forms.Label _ID_CEE_ETI_PNL_0Label_Text;
	private  AxThreed.AxSSPanel _ID_CEE_ETI_PNL_0;
	private  System.Windows.Forms.Label _panel_titulos_1Label_Text;
	private  AxThreed.AxSSPanel _panel_titulos_1;
	public  System.Windows.Forms.GroupBox Frame1;
	public AxThreed.AxSSPanel[] ID_CEE_ETI_PNL = new AxThreed.AxSSPanel[1];
	public AxThreed.AxSSPanel[] panel_titulos = new AxThreed.AxSSPanel[2];
	public System.Windows.Forms.TextBox[] txtTexto = new System.Windows.Forms.TextBox[1];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORCTESTRUCT2));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.ID_SALIR_PB = new System.Windows.Forms.Button();
        this.ID_EST_ALT_PB = new System.Windows.Forms.Button();
        this.ID_EST_BAJ_PB = new System.Windows.Forms.Button();
        this.ID_EST_CAM_PB = new System.Windows.Forms.Button();
        this.ID_EST_CON_PB = new System.Windows.Forms.Button();
        this.ID_CEE_ESTRUCT_LB = new System.Windows.Forms.ListBox();
        this.Frame1 = new System.Windows.Forms.GroupBox();
        this.ID_EST_EMPA_PB = new System.Windows.Forms.Button();
        this._panel_titulos_0 = new AxThreed.AxSSPanel();
        this._panel_titulos_0Label_Text = new System.Windows.Forms.Label();
        this._txtTexto_0 = new System.Windows.Forms.TextBox();
        this._panel_titulos_1 = new AxThreed.AxSSPanel();
        this._panel_titulos_1Label_Text = new System.Windows.Forms.Label();
        this.ID_EST_CAT_PB = new System.Windows.Forms.Button();
        this._ID_CEE_ETI_PNL_0 = new AxThreed.AxSSPanel();
        this._ID_CEE_ETI_PNL_0Label_Text = new System.Windows.Forms.Label();
        this.Frame1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._panel_titulos_0)).BeginInit();
        this._panel_titulos_0.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._panel_titulos_1)).BeginInit();
        this._panel_titulos_1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_0)).BeginInit();
        this._ID_CEE_ETI_PNL_0.SuspendLayout();
        this.SuspendLayout();
        // 
        // ID_SALIR_PB
        // 
        this.ID_SALIR_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_SALIR_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_SALIR_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_SALIR_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_SALIR_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_SALIR_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_SALIR_PB.Location = new System.Drawing.Point(286, 210);
        this.ID_SALIR_PB.Name = "ID_SALIR_PB";
        this.ID_SALIR_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_SALIR_PB.Size = new System.Drawing.Size(80, 21);
        this.ID_SALIR_PB.TabIndex = 5;
        this.ID_SALIR_PB.Tag = "";
        this.ID_SALIR_PB.Text = "&Salir";
        this.ID_SALIR_PB.UseVisualStyleBackColor = false;
        this.ID_SALIR_PB.Click += new System.EventHandler(this.ID_SALIR_PB_Click);
        // 
        // ID_EST_ALT_PB
        // 
        this.ID_EST_ALT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_EST_ALT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_EST_ALT_PB.Enabled = false;
        this.ID_EST_ALT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_EST_ALT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_EST_ALT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_EST_ALT_PB.Location = new System.Drawing.Point(285, 53);
        this.ID_EST_ALT_PB.Name = "ID_EST_ALT_PB";
        this.ID_EST_ALT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_EST_ALT_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_EST_ALT_PB.TabIndex = 4;
        this.ID_EST_ALT_PB.Tag = "";
        this.ID_EST_ALT_PB.Text = "&Alta...";
        this.ID_EST_ALT_PB.UseVisualStyleBackColor = false;
        this.ID_EST_ALT_PB.Click += new System.EventHandler(this.ID_EST_ALT_PB_Click);
        // 
        // ID_EST_BAJ_PB
        // 
        this.ID_EST_BAJ_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_EST_BAJ_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_EST_BAJ_PB.Enabled = false;
        this.ID_EST_BAJ_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_EST_BAJ_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_EST_BAJ_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_EST_BAJ_PB.Location = new System.Drawing.Point(285, 77);
        this.ID_EST_BAJ_PB.Name = "ID_EST_BAJ_PB";
        this.ID_EST_BAJ_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_EST_BAJ_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_EST_BAJ_PB.TabIndex = 3;
        this.ID_EST_BAJ_PB.Tag = "";
        this.ID_EST_BAJ_PB.Text = "&Bajas...";
        this.ID_EST_BAJ_PB.UseVisualStyleBackColor = false;
        this.ID_EST_BAJ_PB.Click += new System.EventHandler(this.ID_EST_BAJ_PB_Click);
        // 
        // ID_EST_CAM_PB
        // 
        this.ID_EST_CAM_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_EST_CAM_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_EST_CAM_PB.Enabled = false;
        this.ID_EST_CAM_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_EST_CAM_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_EST_CAM_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_EST_CAM_PB.Location = new System.Drawing.Point(286, 102);
        this.ID_EST_CAM_PB.Name = "ID_EST_CAM_PB";
        this.ID_EST_CAM_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_EST_CAM_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_EST_CAM_PB.TabIndex = 2;
        this.ID_EST_CAM_PB.Tag = "";
        this.ID_EST_CAM_PB.Text = "&Cambio...";
        this.ID_EST_CAM_PB.UseVisualStyleBackColor = false;
        this.ID_EST_CAM_PB.Click += new System.EventHandler(this.ID_EST_CAM_PB_Click);
        // 
        // ID_EST_CON_PB
        // 
        this.ID_EST_CON_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_EST_CON_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_EST_CON_PB.Enabled = false;
        this.ID_EST_CON_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_EST_CON_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_EST_CON_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_EST_CON_PB.Location = new System.Drawing.Point(286, 127);
        this.ID_EST_CON_PB.Name = "ID_EST_CON_PB";
        this.ID_EST_CON_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_EST_CON_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_EST_CON_PB.TabIndex = 1;
        this.ID_EST_CON_PB.Tag = "";
        this.ID_EST_CON_PB.Text = "C&onsulta...";
        this.ID_EST_CON_PB.UseVisualStyleBackColor = false;
        this.ID_EST_CON_PB.Click += new System.EventHandler(this.ID_EST_CON_PB_Click);
        // 
        // ID_CEE_ESTRUCT_LB
        // 
        this.ID_CEE_ESTRUCT_LB.BackColor = System.Drawing.Color.White;
        this.ID_CEE_ESTRUCT_LB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_CEE_ESTRUCT_LB.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_CEE_ESTRUCT_LB.ForeColor = System.Drawing.SystemColors.WindowText;
        this.ID_CEE_ESTRUCT_LB.ItemHeight = 14;
        this.ID_CEE_ESTRUCT_LB.Location = new System.Drawing.Point(18, 71);
        this.ID_CEE_ESTRUCT_LB.Name = "ID_CEE_ESTRUCT_LB";
        this.ID_CEE_ESTRUCT_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_CEE_ESTRUCT_LB.Size = new System.Drawing.Size(250, 158);
        this.ID_CEE_ESTRUCT_LB.Sorted = true;
        this.ID_CEE_ESTRUCT_LB.TabIndex = 0;
        this.ID_CEE_ESTRUCT_LB.Tag = "";
        // 
        // Frame1
        // 
        this.Frame1.BackColor = System.Drawing.SystemColors.Control;
        this.Frame1.Controls.Add(this.ID_EST_EMPA_PB);
        this.Frame1.Controls.Add(this._panel_titulos_0);
        this.Frame1.Controls.Add(this._txtTexto_0);
        this.Frame1.Controls.Add(this._panel_titulos_1);
        this.Frame1.Controls.Add(this.ID_EST_CAT_PB);
        this.Frame1.Controls.Add(this._ID_CEE_ETI_PNL_0);
        this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Frame1.Location = new System.Drawing.Point(-1, -1);
        this.Frame1.Name = "Frame1";
        this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Frame1.Size = new System.Drawing.Size(385, 250);
        this.Frame1.TabIndex = 6;
        this.Frame1.TabStop = false;
        this.Frame1.Tag = "";
        this.Frame1.Text = "Información Estructuras";
        // 
        // ID_EST_EMPA_PB
        // 
        this.ID_EST_EMPA_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_EST_EMPA_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_EST_EMPA_PB.Enabled = false;
        this.ID_EST_EMPA_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_EST_EMPA_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_EST_EMPA_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_EST_EMPA_PB.Location = new System.Drawing.Point(287, 178);
        this.ID_EST_EMPA_PB.Name = "ID_EST_EMPA_PB";
        this.ID_EST_EMPA_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_EST_EMPA_PB.Size = new System.Drawing.Size(80, 30);
        this.ID_EST_EMPA_PB.TabIndex = 9;
        this.ID_EST_EMPA_PB.Tag = "";
        this.ID_EST_EMPA_PB.Text = "E&mpresas asignadas...";
        this.ID_EST_EMPA_PB.UseVisualStyleBackColor = false;
        this.ID_EST_EMPA_PB.Click += new System.EventHandler(this.ID_EST_EMPA_PB_Click);
        // 
        // _panel_titulos_0
        // 
        this._panel_titulos_0.Controls.Add(this._panel_titulos_0Label_Text);
        this._panel_titulos_0.Location = new System.Drawing.Point(19, 55);
        this._panel_titulos_0.Name = "_panel_titulos_0";
        this._panel_titulos_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_panel_titulos_0.OcxState")));
        this._panel_titulos_0.Size = new System.Drawing.Size(69, 17);
        this._panel_titulos_0.TabIndex = 11;
        this._panel_titulos_0.Tag = "";
        // 
        // _panel_titulos_0Label_Text
        // 
        this._panel_titulos_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._panel_titulos_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._panel_titulos_0Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._panel_titulos_0Label_Text.Location = new System.Drawing.Point(0, 0);
        this._panel_titulos_0Label_Text.Name = "_panel_titulos_0Label_Text";
        this._panel_titulos_0Label_Text.Size = new System.Drawing.Size(69, 17);
        this._panel_titulos_0Label_Text.TabIndex = 0;
        this._panel_titulos_0Label_Text.Tag = "";
        this._panel_titulos_0Label_Text.Text = "Clave";
        this._panel_titulos_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _txtTexto_0
        // 
        this._txtTexto_0.AcceptsReturn = true;
        this._txtTexto_0.BackColor = System.Drawing.SystemColors.Window;
        this._txtTexto_0.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_0.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_0.Location = new System.Drawing.Point(92, 23);
        this._txtTexto_0.MaxLength = 0;
        this._txtTexto_0.Name = "_txtTexto_0";
        this._txtTexto_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_0.Size = new System.Drawing.Size(168, 20);
        this._txtTexto_0.TabIndex = 10;
        this._txtTexto_0.Tag = "";
        // 
        // _panel_titulos_1
        // 
        this._panel_titulos_1.Controls.Add(this._panel_titulos_1Label_Text);
        this._panel_titulos_1.Location = new System.Drawing.Point(89, 55);
        this._panel_titulos_1.Name = "_panel_titulos_1";
        this._panel_titulos_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_panel_titulos_1.OcxState")));
        this._panel_titulos_1.Size = new System.Drawing.Size(181, 17);
        this._panel_titulos_1.TabIndex = 12;
        this._panel_titulos_1.Tag = "";
        // 
        // _panel_titulos_1Label_Text
        // 
        this._panel_titulos_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._panel_titulos_1Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._panel_titulos_1Label_Text.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
        this._panel_titulos_1Label_Text.Location = new System.Drawing.Point(0, 0);
        this._panel_titulos_1Label_Text.Name = "_panel_titulos_1Label_Text";
        this._panel_titulos_1Label_Text.Size = new System.Drawing.Size(181, 17);
        this._panel_titulos_1Label_Text.TabIndex = 0;
        this._panel_titulos_1Label_Text.Tag = "";
        this._panel_titulos_1Label_Text.Text = "Descripción";
        this._panel_titulos_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // ID_EST_CAT_PB
        // 
        this.ID_EST_CAT_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_EST_CAT_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_EST_CAT_PB.Enabled = false;
        this.ID_EST_CAT_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_EST_CAT_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_EST_CAT_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_EST_CAT_PB.Location = new System.Drawing.Point(287, 153);
        this.ID_EST_CAT_PB.Name = "ID_EST_CAT_PB";
        this.ID_EST_CAT_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_EST_CAT_PB.Size = new System.Drawing.Size(80, 22);
        this.ID_EST_CAT_PB.TabIndex = 8;
        this.ID_EST_CAT_PB.Tag = "";
        this.ID_EST_CAT_PB.Text = "Ca&tegorías...";
        this.ID_EST_CAT_PB.UseVisualStyleBackColor = false;
        this.ID_EST_CAT_PB.Click += new System.EventHandler(this.ID_EST_CAT_PB_Click);
        // 
        // _ID_CEE_ETI_PNL_0
        // 
        this._ID_CEE_ETI_PNL_0.Controls.Add(this._ID_CEE_ETI_PNL_0Label_Text);
        this._ID_CEE_ETI_PNL_0.Location = new System.Drawing.Point(27, 23);
        this._ID_CEE_ETI_PNL_0.Name = "_ID_CEE_ETI_PNL_0";
        this._ID_CEE_ETI_PNL_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_ID_CEE_ETI_PNL_0.OcxState")));
        this._ID_CEE_ETI_PNL_0.Size = new System.Drawing.Size(65, 21);
        this._ID_CEE_ETI_PNL_0.TabIndex = 7;
        this._ID_CEE_ETI_PNL_0.Tag = "";
        // 
        // _ID_CEE_ETI_PNL_0Label_Text
        // 
        this._ID_CEE_ETI_PNL_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._ID_CEE_ETI_PNL_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._ID_CEE_ETI_PNL_0Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
        this._ID_CEE_ETI_PNL_0Label_Text.Location = new System.Drawing.Point(0, 0);
        this._ID_CEE_ETI_PNL_0Label_Text.Name = "_ID_CEE_ETI_PNL_0Label_Text";
        this._ID_CEE_ETI_PNL_0Label_Text.Size = new System.Drawing.Size(65, 21);
        this._ID_CEE_ETI_PNL_0Label_Text.TabIndex = 0;
        this._ID_CEE_ETI_PNL_0Label_Text.Tag = "";
        this._ID_CEE_ETI_PNL_0Label_Text.Text = " &Producto";
        this._ID_CEE_ETI_PNL_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // CORCTESTRUCT2
        // 
        this.AcceptButton = this.ID_EST_ALT_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Menu;
        this.CancelButton = this.ID_SALIR_PB;
        this.ClientSize = new System.Drawing.Size(384, 248);
        this.Controls.Add(this.ID_EST_CAM_PB);
        this.Controls.Add(this.ID_SALIR_PB);
        this.Controls.Add(this.ID_EST_ALT_PB);
        this.Controls.Add(this.ID_EST_BAJ_PB);
        this.Controls.Add(this.ID_EST_CON_PB);
        this.Controls.Add(this.ID_CEE_ESTRUCT_LB);
        this.Controls.Add(this.Frame1);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(58, 201);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORCTESTRUCT2";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Estructuras ";
        this.Closed += new System.EventHandler(this.CORCTESTRUCT2_Closed);
        this.Load += new System.EventHandler(this.CORCTESTRUCT2_Load);
        this.Frame1.ResumeLayout(false);
        this.Frame1.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this._panel_titulos_0)).EndInit();
        this._panel_titulos_0.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._panel_titulos_1)).EndInit();
        this._panel_titulos_1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._ID_CEE_ETI_PNL_0)).EndInit();
        this._ID_CEE_ETI_PNL_0.ResumeLayout(false);
        this.ResumeLayout(false);

	}
	void  Initializepanel_titulos()
	{
			this.panel_titulos[0] = _panel_titulos_0;
			this.panel_titulos[1] = _panel_titulos_1;
	}
	void  InitializeID_CEE_ETI_PNL()
	{
			this.ID_CEE_ETI_PNL[0] = _ID_CEE_ETI_PNL_0;
	}
	void  InitializetxtTexto()
	{
			this.txtTexto[0] = _txtTexto_0;
	}
#endregion 
}
}