using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORIREJE
	{
	
#region "Upgrade Support "
		private static CORIREJE m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORIREJE DefInstance
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
		public CORIREJE():base(){
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
			InitializesspEtiqueta();
			InitializesstFolder();
			InitializelblEtiqueta();
			InitializetxtTexto();
		}
	public static CORIREJE CreateInstance()
	{
			CORIREJE theInstance = new CORIREJE();
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
	public  System.Windows.Forms.Button cmdNuevo;
	public  System.Windows.Forms.ListBox lstLista;
	public  System.Windows.Forms.Button ID_IRA_OK_PB;
	public  System.Windows.Forms.Button ID_IRA_CAN_PB;
	private  System.Windows.Forms.Label _lblEtiqueta_1;
	private  System.Windows.Forms.Label _lblEtiqueta_0;
	private  System.Windows.Forms.TextBox _txtTexto_1;
	private  System.Windows.Forms.TextBox _txtTexto_0;
	private  System.Windows.Forms.TabPage __sstFolder_0_TabPage0;
	private  System.Windows.Forms.TextBox _txtTexto_3;
	private  System.Windows.Forms.TextBox _txtTexto_2;
	private  System.Windows.Forms.Label _lblEtiqueta_3;
	private  System.Windows.Forms.Label _lblEtiqueta_2;
	private  System.Windows.Forms.TabPage __sstFolder_0_TabPage1;
	private  System.Windows.Forms.TextBox _txtTexto_4;
	private  System.Windows.Forms.Label _lblEtiqueta_4;
	private  System.Windows.Forms.TabPage __sstFolder_0_TabPage2;
	private  System.Windows.Forms.TabControl _sstFolder_0;
	public  System.Windows.Forms.Label SSPanel3Label_Text;
	public  AxThreed.AxSSPanel SSPanel3;
	private  System.Windows.Forms.Label _sspEtiqueta_0Label_Text;
	private  AxThreed.AxSSPanel _sspEtiqueta_0;
	private  System.Windows.Forms.Label _sspEtiqueta_1Label_Text;
	private  AxThreed.AxSSPanel _sspEtiqueta_1;
	public System.Windows.Forms.Label[] lblEtiqueta = new System.Windows.Forms.Label[5];
	public AxThreed.AxSSPanel[] sspEtiqueta = new AxThreed.AxSSPanel[2];
	public System.Windows.Forms.TabControl[] sstFolder = new System.Windows.Forms.TabControl[1];
	public System.Windows.Forms.TextBox[] txtTexto = new System.Windows.Forms.TextBox[5];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	//[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORIREJE));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.cmdNuevo = new System.Windows.Forms.Button();
        this.lstLista = new System.Windows.Forms.ListBox();
        this.ID_IRA_OK_PB = new System.Windows.Forms.Button();
        this.ID_IRA_CAN_PB = new System.Windows.Forms.Button();
        this._sstFolder_0 = new System.Windows.Forms.TabControl();
        this.@__sstFolder_0_TabPage0 = new System.Windows.Forms.TabPage();
        this._lblEtiqueta_0 = new System.Windows.Forms.Label();
        this._txtTexto_1 = new System.Windows.Forms.TextBox();
        this._txtTexto_0 = new System.Windows.Forms.TextBox();
        this._lblEtiqueta_1 = new System.Windows.Forms.Label();
        this.@__sstFolder_0_TabPage1 = new System.Windows.Forms.TabPage();
        this._txtTexto_2 = new System.Windows.Forms.TextBox();
        this._lblEtiqueta_3 = new System.Windows.Forms.Label();
        this._lblEtiqueta_2 = new System.Windows.Forms.Label();
        this._txtTexto_3 = new System.Windows.Forms.TextBox();
        this.@__sstFolder_0_TabPage2 = new System.Windows.Forms.TabPage();
        this._txtTexto_4 = new System.Windows.Forms.TextBox();
        this._lblEtiqueta_4 = new System.Windows.Forms.Label();
        this.SSPanel3 = new AxThreed.AxSSPanel();
        this.SSPanel3Label_Text = new System.Windows.Forms.Label();
        this._sspEtiqueta_0 = new AxThreed.AxSSPanel();
        this._sspEtiqueta_0Label_Text = new System.Windows.Forms.Label();
        this._sspEtiqueta_1 = new AxThreed.AxSSPanel();
        this._sspEtiqueta_1Label_Text = new System.Windows.Forms.Label();
        this._sstFolder_0.SuspendLayout();
        this.@__sstFolder_0_TabPage0.SuspendLayout();
        this.@__sstFolder_0_TabPage1.SuspendLayout();
        this.@__sstFolder_0_TabPage2.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.SSPanel3)).BeginInit();
        this.SSPanel3.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._sspEtiqueta_0)).BeginInit();
        this._sspEtiqueta_0.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this._sspEtiqueta_1)).BeginInit();
        this._sspEtiqueta_1.SuspendLayout();
        this.SuspendLayout();
        // 
        // cmdNuevo
        // 
        this.cmdNuevo.BackColor = System.Drawing.SystemColors.Control;
        this.cmdNuevo.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdNuevo.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdNuevo.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdNuevo.Location = new System.Drawing.Point(418, 95);
        this.cmdNuevo.Name = "cmdNuevo";
        this.cmdNuevo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdNuevo.Size = new System.Drawing.Size(112, 23);
        this.cmdNuevo.TabIndex = 7;
        this.cmdNuevo.Tag = "";
        this.cmdNuevo.Text = "&Nueva Búsqueda";
        this.cmdNuevo.UseVisualStyleBackColor = false;
        this.cmdNuevo.Click += new System.EventHandler(this.cmdNuevo_Click);
        // 
        // lstLista
        // 
        this.lstLista.BackColor = System.Drawing.SystemColors.Window;
        this.lstLista.Cursor = System.Windows.Forms.Cursors.Default;
        this.lstLista.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lstLista.ForeColor = System.Drawing.SystemColors.WindowText;
        this.lstLista.ItemHeight = 14;
        this.lstLista.Location = new System.Drawing.Point(11, 149);
        this.lstLista.Name = "lstLista";
        this.lstLista.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lstLista.Size = new System.Drawing.Size(515, 158);
        this.lstLista.TabIndex = 11;
        this.lstLista.Tag = "";
        this.lstLista.DoubleClick += new System.EventHandler(this.lstLista_DoubleClick);
        // 
        // ID_IRA_OK_PB
        // 
        this.ID_IRA_OK_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_IRA_OK_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_IRA_OK_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_IRA_OK_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_IRA_OK_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_IRA_OK_PB.Location = new System.Drawing.Point(418, 33);
        this.ID_IRA_OK_PB.Name = "ID_IRA_OK_PB";
        this.ID_IRA_OK_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_IRA_OK_PB.Size = new System.Drawing.Size(112, 23);
        this.ID_IRA_OK_PB.TabIndex = 5;
        this.ID_IRA_OK_PB.Tag = " ";
        this.ID_IRA_OK_PB.Text = "&Buscar Ahora";
        this.ID_IRA_OK_PB.UseVisualStyleBackColor = false;
        this.ID_IRA_OK_PB.Click += new System.EventHandler(this.ID_IRA_OK_PB_Click);
        // 
        // ID_IRA_CAN_PB
        // 
        this.ID_IRA_CAN_PB.BackColor = System.Drawing.SystemColors.Control;
        this.ID_IRA_CAN_PB.Cursor = System.Windows.Forms.Cursors.Default;
        this.ID_IRA_CAN_PB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.ID_IRA_CAN_PB.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.ID_IRA_CAN_PB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ID_IRA_CAN_PB.ForeColor = System.Drawing.SystemColors.ControlText;
        this.ID_IRA_CAN_PB.Location = new System.Drawing.Point(418, 64);
        this.ID_IRA_CAN_PB.Name = "ID_IRA_CAN_PB";
        this.ID_IRA_CAN_PB.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ID_IRA_CAN_PB.Size = new System.Drawing.Size(112, 23);
        this.ID_IRA_CAN_PB.TabIndex = 6;
        this.ID_IRA_CAN_PB.Tag = "";
        this.ID_IRA_CAN_PB.Text = "&Cancelar";
        this.ID_IRA_CAN_PB.UseVisualStyleBackColor = false;
        this.ID_IRA_CAN_PB.Click += new System.EventHandler(this.ID_IRA_CAN_PB_Click);
        // 
        // _sstFolder_0
        // 
        this._sstFolder_0.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
        this._sstFolder_0.Controls.Add(this.@__sstFolder_0_TabPage0);
        this._sstFolder_0.Controls.Add(this.@__sstFolder_0_TabPage1);
        this._sstFolder_0.Controls.Add(this.@__sstFolder_0_TabPage2);
        this._sstFolder_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._sstFolder_0.ItemSize = new System.Drawing.Size(79, 18);
        this._sstFolder_0.Location = new System.Drawing.Point(9, 12);
        this._sstFolder_0.Multiline = true;
        this._sstFolder_0.Name = "_sstFolder_0";
        this._sstFolder_0.SelectedIndex = 0;
        this._sstFolder_0.Size = new System.Drawing.Size(404, 110);
        this._sstFolder_0.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
        this._sstFolder_0.TabIndex = 0;
        this._sstFolder_0.Tag = "";
        this._sstFolder_0.SelectedIndexChanged += new System.EventHandler(this.sstFolder_SelectedIndexChanged);
        // 
        // __sstFolder_0_TabPage0
        // 
        this.@__sstFolder_0_TabPage0.Controls.Add(this._lblEtiqueta_0);
        this.@__sstFolder_0_TabPage0.Controls.Add(this._txtTexto_1);
        this.@__sstFolder_0_TabPage0.Controls.Add(this._txtTexto_0);
        this.@__sstFolder_0_TabPage0.Controls.Add(this._lblEtiqueta_1);
        this.@__sstFolder_0_TabPage0.Location = new System.Drawing.Point(4, 22);
        this.@__sstFolder_0_TabPage0.Name = "__sstFolder_0_TabPage0";
        this.@__sstFolder_0_TabPage0.Size = new System.Drawing.Size(396, 84);
        this.@__sstFolder_0_TabPage0.TabIndex = 0;
        this.@__sstFolder_0_TabPage0.Tag = "";
        this.@__sstFolder_0_TabPage0.Text = "Nombre del Ejecutivo";
        this.@__sstFolder_0_TabPage0.UseVisualStyleBackColor = true;
        // 
        // _lblEtiqueta_0
        // 
        this._lblEtiqueta_0.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_0.Location = new System.Drawing.Point(12, 23);
        this._lblEtiqueta_0.Name = "_lblEtiqueta_0";
        this._lblEtiqueta_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_0.Size = new System.Drawing.Size(130, 13);
        this._lblEtiqueta_0.TabIndex = 1;
        this._lblEtiqueta_0.Tag = "";
        this._lblEtiqueta_0.Text = "Número de Empresa";
        // 
        // _txtTexto_1
        // 
        this._txtTexto_1.AcceptsReturn = true;
        this._txtTexto_1.BackColor = System.Drawing.SystemColors.Window;
        this._txtTexto_1.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_1.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_1.Location = new System.Drawing.Point(144, 52);
        this._txtTexto_1.MaxLength = 0;
        this._txtTexto_1.Name = "_txtTexto_1";
        this._txtTexto_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_1.Size = new System.Drawing.Size(244, 20);
        this._txtTexto_1.TabIndex = 4;
        this._txtTexto_1.Tag = "";
        this._txtTexto_1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
        // 
        // _txtTexto_0
        // 
        this._txtTexto_0.AcceptsReturn = true;
        this._txtTexto_0.BackColor = System.Drawing.SystemColors.Window;
        this._txtTexto_0.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_0.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_0.Location = new System.Drawing.Point(144, 19);
        this._txtTexto_0.MaxLength = 0;
        this._txtTexto_0.Name = "_txtTexto_0";
        this._txtTexto_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_0.Size = new System.Drawing.Size(103, 20);
        this._txtTexto_0.TabIndex = 2;
        this._txtTexto_0.Tag = "";
        this._txtTexto_0.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
        // 
        // _lblEtiqueta_1
        // 
        this._lblEtiqueta_1.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_1.Location = new System.Drawing.Point(12, 56);
        this._lblEtiqueta_1.Name = "_lblEtiqueta_1";
        this._lblEtiqueta_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_1.Size = new System.Drawing.Size(130, 13);
        this._lblEtiqueta_1.TabIndex = 3;
        this._lblEtiqueta_1.Tag = "";
        this._lblEtiqueta_1.Text = "Nombre del Ejecutivo";
        // 
        // __sstFolder_0_TabPage1
        // 
        this.@__sstFolder_0_TabPage1.Controls.Add(this._txtTexto_2);
        this.@__sstFolder_0_TabPage1.Controls.Add(this._lblEtiqueta_3);
        this.@__sstFolder_0_TabPage1.Controls.Add(this._lblEtiqueta_2);
        this.@__sstFolder_0_TabPage1.Controls.Add(this._txtTexto_3);
        this.@__sstFolder_0_TabPage1.Location = new System.Drawing.Point(4, 22);
        this.@__sstFolder_0_TabPage1.Name = "__sstFolder_0_TabPage1";
        this.@__sstFolder_0_TabPage1.Size = new System.Drawing.Size(396, 84);
        this.@__sstFolder_0_TabPage1.TabIndex = 2;
        this.@__sstFolder_0_TabPage1.Tag = "";
        this.@__sstFolder_0_TabPage1.Text = "Número de Empresa y Ejecutivo";
        this.@__sstFolder_0_TabPage1.UseVisualStyleBackColor = true;
        // 
        // _txtTexto_2
        // 
        this._txtTexto_2.AcceptsReturn = true;
        this._txtTexto_2.BackColor = System.Drawing.SystemColors.Window;
        this._txtTexto_2.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_2.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_2.Location = new System.Drawing.Point(153, 16);
        this._txtTexto_2.MaxLength = 0;
        this._txtTexto_2.Name = "_txtTexto_2";
        this._txtTexto_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_2.Size = new System.Drawing.Size(103, 20);
        this._txtTexto_2.TabIndex = 13;
        this._txtTexto_2.Tag = "";
        this._txtTexto_2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
        // 
        // _lblEtiqueta_3
        // 
        this._lblEtiqueta_3.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_3.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_3.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_3.Location = new System.Drawing.Point(21, 46);
        this._lblEtiqueta_3.Name = "_lblEtiqueta_3";
        this._lblEtiqueta_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_3.Size = new System.Drawing.Size(130, 16);
        this._lblEtiqueta_3.TabIndex = 14;
        this._lblEtiqueta_3.Tag = "";
        this._lblEtiqueta_3.Text = "Número de Ejecutivo:";
        // 
        // _lblEtiqueta_2
        // 
        this._lblEtiqueta_2.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_2.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_2.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_2.Location = new System.Drawing.Point(21, 19);
        this._lblEtiqueta_2.Name = "_lblEtiqueta_2";
        this._lblEtiqueta_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_2.Size = new System.Drawing.Size(118, 13);
        this._lblEtiqueta_2.TabIndex = 12;
        this._lblEtiqueta_2.Tag = "";
        this._lblEtiqueta_2.Text = "Número de Empresa";
        // 
        // _txtTexto_3
        // 
        this._txtTexto_3.AcceptsReturn = true;
        this._txtTexto_3.BackColor = System.Drawing.SystemColors.Window;
        this._txtTexto_3.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_3.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_3.Location = new System.Drawing.Point(153, 43);
        this._txtTexto_3.MaxLength = 0;
        this._txtTexto_3.Name = "_txtTexto_3";
        this._txtTexto_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_3.Size = new System.Drawing.Size(103, 20);
        this._txtTexto_3.TabIndex = 15;
        this._txtTexto_3.Tag = "";
        this._txtTexto_3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
        // 
        // __sstFolder_0_TabPage2
        // 
        this.@__sstFolder_0_TabPage2.Controls.Add(this._txtTexto_4);
        this.@__sstFolder_0_TabPage2.Controls.Add(this._lblEtiqueta_4);
        this.@__sstFolder_0_TabPage2.Location = new System.Drawing.Point(4, 22);
        this.@__sstFolder_0_TabPage2.Name = "__sstFolder_0_TabPage2";
        this.@__sstFolder_0_TabPage2.Size = new System.Drawing.Size(396, 84);
        this.@__sstFolder_0_TabPage2.TabIndex = 1;
        this.@__sstFolder_0_TabPage2.Tag = "";
        this.@__sstFolder_0_TabPage2.Text = "Cuenta";
        this.@__sstFolder_0_TabPage2.UseVisualStyleBackColor = true;
        // 
        // _txtTexto_4
        // 
        this._txtTexto_4.AcceptsReturn = true;
        this._txtTexto_4.BackColor = System.Drawing.SystemColors.Window;
        this._txtTexto_4.Cursor = System.Windows.Forms.Cursors.IBeam;
        this._txtTexto_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._txtTexto_4.ForeColor = System.Drawing.SystemColors.WindowText;
        this._txtTexto_4.Location = new System.Drawing.Point(174, 35);
        this._txtTexto_4.MaxLength = 16;
        this._txtTexto_4.Name = "_txtTexto_4";
        this._txtTexto_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._txtTexto_4.Size = new System.Drawing.Size(166, 20);
        this._txtTexto_4.TabIndex = 17;
        this._txtTexto_4.Tag = "";
        this._txtTexto_4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTexto_KeyPress);
        // 
        // _lblEtiqueta_4
        // 
        this._lblEtiqueta_4.BackColor = System.Drawing.SystemColors.Control;
        this._lblEtiqueta_4.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblEtiqueta_4.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblEtiqueta_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblEtiqueta_4.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblEtiqueta_4.Location = new System.Drawing.Point(51, 40);
        this._lblEtiqueta_4.Name = "_lblEtiqueta_4";
        this._lblEtiqueta_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblEtiqueta_4.Size = new System.Drawing.Size(118, 13);
        this._lblEtiqueta_4.TabIndex = 16;
        this._lblEtiqueta_4.Tag = "";
        this._lblEtiqueta_4.Text = "Número de Cuenta:";
        // 
        // SSPanel3
        // 
        this.SSPanel3.Controls.Add(this.SSPanel3Label_Text);
        this.SSPanel3.Location = new System.Drawing.Point(125, 129);
        this.SSPanel3.Name = "SSPanel3";
        this.SSPanel3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SSPanel3.OcxState")));
        this.SSPanel3.Size = new System.Drawing.Size(401, 19);
        this.SSPanel3.TabIndex = 10;
        this.SSPanel3.Tag = "";
        // 
        // SSPanel3Label_Text
        // 
        this.SSPanel3Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.SSPanel3Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.SSPanel3Label_Text.ForeColor = System.Drawing.SystemColors.ControlText;
        this.SSPanel3Label_Text.Location = new System.Drawing.Point(0, 0);
        this.SSPanel3Label_Text.Name = "SSPanel3Label_Text";
        this.SSPanel3Label_Text.Size = new System.Drawing.Size(401, 19);
        this.SSPanel3Label_Text.TabIndex = 0;
        this.SSPanel3Label_Text.Tag = "";
        this.SSPanel3Label_Text.Text = "Nombre del Ejecutivo";
        this.SSPanel3Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _sspEtiqueta_0
        // 
        this._sspEtiqueta_0.Controls.Add(this._sspEtiqueta_0Label_Text);
        this._sspEtiqueta_0.Location = new System.Drawing.Point(11, 129);
        this._sspEtiqueta_0.Name = "_sspEtiqueta_0";
        this._sspEtiqueta_0.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_sspEtiqueta_0.OcxState")));
        this._sspEtiqueta_0.Size = new System.Drawing.Size(54, 19);
        this._sspEtiqueta_0.TabIndex = 8;
        this._sspEtiqueta_0.Tag = "";
        // 
        // _sspEtiqueta_0Label_Text
        // 
        this._sspEtiqueta_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._sspEtiqueta_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._sspEtiqueta_0Label_Text.ForeColor = System.Drawing.SystemColors.ControlText;
        this._sspEtiqueta_0Label_Text.Location = new System.Drawing.Point(0, 0);
        this._sspEtiqueta_0Label_Text.Name = "_sspEtiqueta_0Label_Text";
        this._sspEtiqueta_0Label_Text.Size = new System.Drawing.Size(54, 19);
        this._sspEtiqueta_0Label_Text.TabIndex = 0;
        this._sspEtiqueta_0Label_Text.Tag = "";
        this._sspEtiqueta_0Label_Text.Text = "Empresa";
        this._sspEtiqueta_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _sspEtiqueta_1
        // 
        this._sspEtiqueta_1.Controls.Add(this._sspEtiqueta_1Label_Text);
        this._sspEtiqueta_1.Location = new System.Drawing.Point(65, 129);
        this._sspEtiqueta_1.Name = "_sspEtiqueta_1";
        this._sspEtiqueta_1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("_sspEtiqueta_1.OcxState")));
        this._sspEtiqueta_1.Size = new System.Drawing.Size(60, 19);
        this._sspEtiqueta_1.TabIndex = 9;
        this._sspEtiqueta_1.Tag = "";
        // 
        // _sspEtiqueta_1Label_Text
        // 
        this._sspEtiqueta_1Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._sspEtiqueta_1Label_Text.ForeColor = System.Drawing.SystemColors.ControlText;
        this._sspEtiqueta_1Label_Text.Location = new System.Drawing.Point(0, 0);
        this._sspEtiqueta_1Label_Text.Name = "_sspEtiqueta_1Label_Text";
        this._sspEtiqueta_1Label_Text.Size = new System.Drawing.Size(60, 19);
        this._sspEtiqueta_1Label_Text.TabIndex = 0;
        this._sspEtiqueta_1Label_Text.Tag = "";
        this._sspEtiqueta_1Label_Text.Text = "Ejecutivo";
        this._sspEtiqueta_1Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // CORIREJE
        // 
        this.AcceptButton = this.ID_IRA_OK_PB;
        this.AutoScaleBaseSize = new System.Drawing.Size(6, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.CancelButton = this.ID_IRA_CAN_PB;
        this.ClientSize = new System.Drawing.Size(537, 315);
        this.Controls.Add(this.lstLista);
        this.Controls.Add(this.cmdNuevo);
        this.Controls.Add(this.SSPanel3);
        this.Controls.Add(this._sspEtiqueta_0);
        this.Controls.Add(this._sspEtiqueta_1);
        this.Controls.Add(this.ID_IRA_OK_PB);
        this.Controls.Add(this.ID_IRA_CAN_PB);
        this.Controls.Add(this._sstFolder_0);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
        this.Location = new System.Drawing.Point(273, 118);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORIREJE";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Buscar: Ejecutivo";
        this.Closed += new System.EventHandler(this.CORIREJE_Closed);
        this.Activated += new System.EventHandler(this.CORIREJE_Activated);
        this._sstFolder_0.ResumeLayout(false);
        this.@__sstFolder_0_TabPage0.ResumeLayout(false);
        this.@__sstFolder_0_TabPage0.PerformLayout();
        this.@__sstFolder_0_TabPage1.ResumeLayout(false);
        this.@__sstFolder_0_TabPage1.PerformLayout();
        this.@__sstFolder_0_TabPage2.ResumeLayout(false);
        this.@__sstFolder_0_TabPage2.PerformLayout();
        ((System.ComponentModel.ISupportInitialize)(this.SSPanel3)).EndInit();
        this.SSPanel3.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._sspEtiqueta_0)).EndInit();
        this._sspEtiqueta_0.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this._sspEtiqueta_1)).EndInit();
        this._sspEtiqueta_1.ResumeLayout(false);
        this.ResumeLayout(false);

	}
	void  InitializesspEtiqueta()
	{
			this.sspEtiqueta[0] = _sspEtiqueta_0;
			this.sspEtiqueta[1] = _sspEtiqueta_1;
	}
	void  InitializesstFolder()
	{
			this.sstFolder[0] = _sstFolder_0;
	}
	void  InitializelblEtiqueta()
	{
			this.lblEtiqueta[4] = _lblEtiqueta_4;
			this.lblEtiqueta[3] = _lblEtiqueta_3;
			this.lblEtiqueta[2] = _lblEtiqueta_2;
			this.lblEtiqueta[0] = _lblEtiqueta_0;
			this.lblEtiqueta[1] = _lblEtiqueta_1;
	}
	void  InitializetxtTexto()
	{
			this.txtTexto[4] = _txtTexto_4;
			this.txtTexto[3] = _txtTexto_3;
			this.txtTexto[2] = _txtTexto_2;
			this.txtTexto[0] = _txtTexto_0;
			this.txtTexto[1] = _txtTexto_1;
	}
#endregion 
}
}