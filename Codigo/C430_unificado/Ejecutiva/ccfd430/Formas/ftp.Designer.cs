using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
	partial class FrmFtp
	{
	
#region "Upgrade Support "
		private static FrmFtp m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static FrmFtp DefInstance
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
		public FrmFtp():base(){
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
		}
	public static FrmFtp CreateInstance()
	{
			FrmFtp theInstance = new FrmFtp();
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
	public  AxThreed.AxSSCommand CmdDisconnect;
	public  AxThreed.AxSSCommand cmdConnect;
	public  AxMSComctlLib.AxStatusBar SbFTp;
	public  System.Windows.Forms.GroupBox Frm_Status;
	public  System.Windows.Forms.Timer Timer1;
	public  AxMSComctlLib.AxTreeView DirRemote;
	public  System.Windows.Forms.GroupBox Frm_Remote;
	public  System.Windows.Forms.Button BtnDirNuevo;
	public  System.Windows.Forms.TextBox txtDirNuevo;
	public  System.Windows.Forms.GroupBox Frame1;
	public  Microsoft.VisualBasic.Compatibility.VB6.DriveListBox DrvLocal;
	public  Microsoft.VisualBasic.Compatibility.VB6.FileListBox FilLocal;
	public  Microsoft.VisualBasic.Compatibility.VB6.DirListBox DirLocal;
	public  System.Windows.Forms.GroupBox Frm_Local;
	public  AxThreed.AxSSCommand BtnRecibir;
	public  System.Windows.Forms.ListBox List1;
	public  System.Windows.Forms.Panel FrmConectado;
	public  AxMSComctlLib.AxImageList ImageList1;
	public  AxInetCtlsObjects.AxInet Inet1;
	public  System.Windows.Forms.TextBox TxtDir;
	public  System.Windows.Forms.TextBox TxtPassword;
	public  System.Windows.Forms.TextBox TxtUserName;
	public  System.Windows.Forms.TextBox TxtUrl;
	public  System.Windows.Forms.Label Label3;
	public  System.Windows.Forms.Label Label2;
	public  System.Windows.Forms.Label Label1;
	private Artinsoft.VB6.Gui.CommandButtonHelper CommandButtonHelper1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFtp));
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.cmdConnect = new AxThreed.AxSSCommand();
        this.BtnDirNuevo = new System.Windows.Forms.Button();
        this.CmdDisconnect = new AxThreed.AxSSCommand();
        this.Frm_Status = new System.Windows.Forms.GroupBox();
        this.SbFTp = new AxMSComctlLib.AxStatusBar();
        this.Timer1 = new System.Windows.Forms.Timer(this.components);
        this.FrmConectado = new System.Windows.Forms.Panel();
        this.Frm_Remote = new System.Windows.Forms.GroupBox();
        this.DirRemote = new AxMSComctlLib.AxTreeView();
        this.Frm_Local = new System.Windows.Forms.GroupBox();
        this.Frame1 = new System.Windows.Forms.GroupBox();
        this.txtDirNuevo = new System.Windows.Forms.TextBox();
        this.DrvLocal = new Microsoft.VisualBasic.Compatibility.VB6.DriveListBox();
        this.DirLocal = new Microsoft.VisualBasic.Compatibility.VB6.DirListBox();
        this.FilLocal = new Microsoft.VisualBasic.Compatibility.VB6.FileListBox();
        this.List1 = new System.Windows.Forms.ListBox();
        this.BtnRecibir = new AxThreed.AxSSCommand();
        this.ImageList1 = new AxMSComctlLib.AxImageList();
        this.Inet1 = new AxInetCtlsObjects.AxInet();
        this.TxtDir = new System.Windows.Forms.TextBox();
        this.TxtPassword = new System.Windows.Forms.TextBox();
        this.TxtUserName = new System.Windows.Forms.TextBox();
        this.TxtUrl = new System.Windows.Forms.TextBox();
        this.Label3 = new System.Windows.Forms.Label();
        this.Label2 = new System.Windows.Forms.Label();
        this.Label1 = new System.Windows.Forms.Label();
        this.CommandButtonHelper1 = new Artinsoft.VB6.Gui.CommandButtonHelper(this.components);
        ((System.ComponentModel.ISupportInitialize)(this.cmdConnect)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.CmdDisconnect)).BeginInit();
        this.Frm_Status.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.SbFTp)).BeginInit();
        this.FrmConectado.SuspendLayout();
        this.Frm_Remote.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.DirRemote)).BeginInit();
        this.Frm_Local.SuspendLayout();
        this.Frame1.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.BtnRecibir)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.ImageList1)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.Inet1)).BeginInit();
        this.SuspendLayout();
        // 
        // cmdConnect
        // 
        this.cmdConnect.Location = new System.Drawing.Point(0, 0);
        this.cmdConnect.Name = "cmdConnect";
        this.cmdConnect.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cmdConnect.OcxState")));
        this.cmdConnect.Size = new System.Drawing.Size(57, 41);
        this.cmdConnect.TabIndex = 21;
        this.cmdConnect.Tag = "";
        this.ToolTip1.SetToolTip(this.cmdConnect, "Inicia Conexión con servidor de FTP");
        this.cmdConnect.ClickEvent += new System.EventHandler(this.cmdConnect_ClickEvent);
        // 
        // BtnDirNuevo
        // 
        this.BtnDirNuevo.BackColor = System.Drawing.SystemColors.Control;
        this.BtnDirNuevo.Cursor = System.Windows.Forms.Cursors.Default;
        this.CommandButtonHelper1.SetDisabledPicture(this.BtnDirNuevo, null);
        this.CommandButtonHelper1.SetDownPicture(this.BtnDirNuevo, null);
        this.BtnDirNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.BtnDirNuevo.ForeColor = System.Drawing.SystemColors.ControlText;
        this.BtnDirNuevo.Location = new System.Drawing.Point(192, 16);
        this.BtnDirNuevo.Name = "BtnDirNuevo";
        this.BtnDirNuevo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.BtnDirNuevo.Size = new System.Drawing.Size(25, 17);
        this.CommandButtonHelper1.SetStyle(this.BtnDirNuevo, 1);
        this.BtnDirNuevo.TabIndex = 20;
        this.BtnDirNuevo.Tag = "";
        this.ToolTip1.SetToolTip(this.BtnDirNuevo, "Crear directorio");
        this.BtnDirNuevo.UseVisualStyleBackColor = false;
        this.BtnDirNuevo.Click += new System.EventHandler(this.BtnDirNuevo_Click);
        // 
        // CmdDisconnect
        // 
        this.CmdDisconnect.Location = new System.Drawing.Point(56, 0);
        this.CmdDisconnect.Name = "CmdDisconnect";
        this.CmdDisconnect.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CmdDisconnect.OcxState")));
        this.CmdDisconnect.Size = new System.Drawing.Size(57, 41);
        this.CmdDisconnect.TabIndex = 22;
        this.CmdDisconnect.Tag = "";
        this.ToolTip1.SetToolTip(this.CmdDisconnect, "Termina la conexión con el servidor de FTP");
        this.CmdDisconnect.ClickEvent += new System.EventHandler(this.CmdDisconnect_ClickEvent);
        // 
        // Frm_Status
        // 
        this.Frm_Status.BackColor = System.Drawing.SystemColors.Control;
        this.Frm_Status.Controls.Add(this.SbFTp);
        this.Frm_Status.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Frm_Status.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Frm_Status.Location = new System.Drawing.Point(0, 512);
        this.Frm_Status.Name = "Frm_Status";
        this.Frm_Status.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Frm_Status.Size = new System.Drawing.Size(657, 60);
        this.Frm_Status.TabIndex = 16;
        this.Frm_Status.TabStop = false;
        this.Frm_Status.Tag = "";
        this.Frm_Status.Text = "Status";
        // 
        // SbFTp
        // 
        this.SbFTp.Location = new System.Drawing.Point(8, 16);
        this.SbFTp.Name = "SbFTp";
        this.SbFTp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("SbFTp.OcxState")));
        this.SbFTp.Size = new System.Drawing.Size(646, 24);
        this.SbFTp.TabIndex = 17;
        this.SbFTp.Tag = "";
        // 
        // Timer1
        // 
        this.Timer1.Interval = 65535;
        this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
        // 
        // FrmConectado
        // 
        this.FrmConectado.BackColor = System.Drawing.SystemColors.Control;
        this.FrmConectado.Controls.Add(this.Frm_Remote);
        this.FrmConectado.Controls.Add(this.Frm_Local);
        this.FrmConectado.Controls.Add(this.List1);
        this.FrmConectado.Controls.Add(this.BtnRecibir);
        this.FrmConectado.Cursor = System.Windows.Forms.Cursors.Default;
        this.FrmConectado.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FrmConectado.ForeColor = System.Drawing.SystemColors.ControlText;
        this.FrmConectado.Location = new System.Drawing.Point(0, 72);
        this.FrmConectado.Name = "FrmConectado";
        this.FrmConectado.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.FrmConectado.Size = new System.Drawing.Size(657, 433);
        this.FrmConectado.TabIndex = 7;
        this.FrmConectado.Tag = "";
        this.FrmConectado.Visible = false;
        // 
        // Frm_Remote
        // 
        this.Frm_Remote.BackColor = System.Drawing.SystemColors.Control;
        this.Frm_Remote.Controls.Add(this.DirRemote);
        this.Frm_Remote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Frm_Remote.ForeColor = System.Drawing.SystemColors.Highlight;
        this.Frm_Remote.Location = new System.Drawing.Point(336, 8);
        this.Frm_Remote.Name = "Frm_Remote";
        this.Frm_Remote.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Frm_Remote.Size = new System.Drawing.Size(313, 401);
        this.Frm_Remote.TabIndex = 13;
        this.Frm_Remote.TabStop = false;
        this.Frm_Remote.Tag = "";
        this.Frm_Remote.Text = " Pc Remoto (Host)  ";
        // 
        // DirRemote
        // 
        this.DirRemote.Location = new System.Drawing.Point(8, 24);
        this.DirRemote.Name = "DirRemote";
        this.DirRemote.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("DirRemote.OcxState")));
        this.DirRemote.Size = new System.Drawing.Size(297, 369);
        this.DirRemote.TabIndex = 14;
        this.DirRemote.Tag = "";
        this.DirRemote.NodeCheck += new AxMSComctlLib.ITreeViewEvents_NodeCheckEventHandler(this.DirRemote_NodeCheck);
        this.DirRemote.DblClick += new System.EventHandler(this.DirRemote_DblClick);
        // 
        // Frm_Local
        // 
        this.Frm_Local.BackColor = System.Drawing.SystemColors.Control;
        this.Frm_Local.Controls.Add(this.Frame1);
        this.Frm_Local.Controls.Add(this.DrvLocal);
        this.Frm_Local.Controls.Add(this.DirLocal);
        this.Frm_Local.Controls.Add(this.FilLocal);
        this.Frm_Local.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Frm_Local.ForeColor = System.Drawing.SystemColors.Highlight;
        this.Frm_Local.Location = new System.Drawing.Point(0, 8);
        this.Frm_Local.Name = "Frm_Local";
        this.Frm_Local.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Frm_Local.Size = new System.Drawing.Size(249, 409);
        this.Frm_Local.TabIndex = 9;
        this.Frm_Local.TabStop = false;
        this.Frm_Local.Tag = "";
        this.Frm_Local.Text = " Pc Local ";
        // 
        // Frame1
        // 
        this.Frame1.BackColor = System.Drawing.SystemColors.Control;
        this.Frame1.Controls.Add(this.BtnDirNuevo);
        this.Frame1.Controls.Add(this.txtDirNuevo);
        this.Frame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Frame1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Frame1.Location = new System.Drawing.Point(8, 48);
        this.Frame1.Name = "Frame1";
        this.Frame1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Frame1.Size = new System.Drawing.Size(233, 49);
        this.Frame1.TabIndex = 18;
        this.Frame1.TabStop = false;
        this.Frame1.Tag = "";
        this.Frame1.Text = "Crear Directorio";
        // 
        // txtDirNuevo
        // 
        this.txtDirNuevo.AcceptsReturn = true;
        this.txtDirNuevo.BackColor = System.Drawing.SystemColors.Window;
        this.txtDirNuevo.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtDirNuevo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtDirNuevo.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtDirNuevo.Location = new System.Drawing.Point(8, 16);
        this.txtDirNuevo.MaxLength = 0;
        this.txtDirNuevo.Name = "txtDirNuevo";
        this.txtDirNuevo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtDirNuevo.Size = new System.Drawing.Size(177, 19);
        this.txtDirNuevo.TabIndex = 19;
        this.txtDirNuevo.Tag = "";
        this.txtDirNuevo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDirNuevo_KeyPress);
        // 
        // DrvLocal
        // 
        this.DrvLocal.BackColor = System.Drawing.SystemColors.Window;
        this.DrvLocal.Cursor = System.Windows.Forms.Cursors.Default;
        this.DrvLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.DrvLocal.ForeColor = System.Drawing.SystemColors.WindowText;
        this.DrvLocal.FormattingEnabled = true;
        this.DrvLocal.Location = new System.Drawing.Point(8, 16);
        this.DrvLocal.Name = "DrvLocal";
        this.DrvLocal.Size = new System.Drawing.Size(217, 21);
        this.DrvLocal.TabIndex = 12;
        this.DrvLocal.Tag = "";
        this.DrvLocal.SelectedIndexChanged += new System.EventHandler(this.DrvLocal_SelectedIndexChanged);
        // 
        // DirLocal
        // 
        this.DirLocal.BackColor = System.Drawing.SystemColors.Window;
        this.DirLocal.Cursor = System.Windows.Forms.Cursors.Default;
        this.DirLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.DirLocal.ForeColor = System.Drawing.SystemColors.WindowText;
        this.DirLocal.FormattingEnabled = true;
        this.DirLocal.IntegralHeight = false;
        this.DirLocal.Location = new System.Drawing.Point(8, 104);
        this.DirLocal.Name = "DirLocal";
        this.DirLocal.Size = new System.Drawing.Size(225, 126);
        this.DirLocal.TabIndex = 10;
        this.DirLocal.Tag = "";
        this.DirLocal.Change += new System.EventHandler(this.DirLocal_Change);
        // 
        // FilLocal
        // 
        this.FilLocal.BackColor = System.Drawing.SystemColors.Window;
        this.FilLocal.Cursor = System.Windows.Forms.Cursors.Default;
        this.FilLocal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FilLocal.ForeColor = System.Drawing.SystemColors.WindowText;
        this.FilLocal.FormattingEnabled = true;
        this.FilLocal.Location = new System.Drawing.Point(8, 232);
        this.FilLocal.Name = "FilLocal";
        this.FilLocal.Pattern = "*.txt";
        this.FilLocal.Size = new System.Drawing.Size(225, 147);
        this.FilLocal.TabIndex = 11;
        this.FilLocal.Tag = "";
        this.FilLocal.DoubleClick += new System.EventHandler(this.FilLocal_DoubleClick);
        // 
        // List1
        // 
        this.List1.BackColor = System.Drawing.SystemColors.Window;
        this.List1.Cursor = System.Windows.Forms.Cursors.Default;
        this.List1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.List1.ForeColor = System.Drawing.SystemColors.WindowText;
        this.List1.Location = new System.Drawing.Point(16, 120);
        this.List1.Name = "List1";
        this.List1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.List1.Size = new System.Drawing.Size(57, 17);
        this.List1.TabIndex = 15;
        this.List1.Tag = "";
        this.List1.Visible = false;
        // 
        // BtnRecibir
        // 
        this.BtnRecibir.Location = new System.Drawing.Point(255, 175);
        this.BtnRecibir.Name = "BtnRecibir";
        this.BtnRecibir.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("BtnRecibir.OcxState")));
        this.BtnRecibir.Size = new System.Drawing.Size(81, 49);
        this.BtnRecibir.TabIndex = 8;
        this.BtnRecibir.Tag = "";
        this.BtnRecibir.ClickEvent += new System.EventHandler(this.BtnRecibir_ClickEvent);
        // 
        // ImageList1
        // 
        this.ImageList1.Enabled = true;
        this.ImageList1.Location = new System.Drawing.Point(128, 544);
        this.ImageList1.Name = "ImageList1";
        this.ImageList1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("ImageList1.OcxState")));
        this.ImageList1.Size = new System.Drawing.Size(38, 38);
        this.ImageList1.TabIndex = 0;
        this.ImageList1.Tag = "";
        // 
        // Inet1
        // 
        this.Inet1.Enabled = true;
        this.Inet1.Location = new System.Drawing.Point(704, 272);
        this.Inet1.Name = "Inet1";
        this.Inet1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("Inet1.OcxState")));
        this.Inet1.Size = new System.Drawing.Size(38, 38);
        this.Inet1.TabIndex = 23;
        this.Inet1.Tag = "";
        this.Inet1.StateChanged += new AxInetCtlsObjects.DInetEvents_StateChangedEventHandler(this.Inet1_StateChanged);
        // 
        // TxtDir
        // 
        this.TxtDir.AcceptsReturn = true;
        this.TxtDir.BackColor = System.Drawing.SystemColors.Window;
        this.TxtDir.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TxtDir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TxtDir.ForeColor = System.Drawing.SystemColors.WindowText;
        this.TxtDir.Location = new System.Drawing.Point(280, 104);
        this.TxtDir.MaxLength = 0;
        this.TxtDir.Name = "TxtDir";
        this.TxtDir.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TxtDir.Size = new System.Drawing.Size(129, 27);
        this.TxtDir.TabIndex = 3;
        this.TxtDir.Tag = "";
        this.TxtDir.Visible = false;
        // 
        // TxtPassword
        // 
        this.TxtPassword.AcceptsReturn = true;
        this.TxtPassword.BackColor = System.Drawing.SystemColors.Window;
        this.TxtPassword.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TxtPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TxtPassword.ForeColor = System.Drawing.SystemColors.WindowText;
        this.TxtPassword.ImeMode = System.Windows.Forms.ImeMode.Disable;
        this.TxtPassword.Location = new System.Drawing.Point(56, 152);
        this.TxtPassword.MaxLength = 0;
        this.TxtPassword.Name = "TxtPassword";
        this.TxtPassword.PasswordChar = '*';
        this.TxtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TxtPassword.Size = new System.Drawing.Size(209, 19);
        this.TxtPassword.TabIndex = 2;
        this.TxtPassword.Tag = "";
        this.TxtPassword.Visible = false;
        // 
        // TxtUserName
        // 
        this.TxtUserName.AcceptsReturn = true;
        this.TxtUserName.BackColor = System.Drawing.SystemColors.Window;
        this.TxtUserName.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TxtUserName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TxtUserName.ForeColor = System.Drawing.SystemColors.WindowText;
        this.TxtUserName.Location = new System.Drawing.Point(56, 128);
        this.TxtUserName.MaxLength = 0;
        this.TxtUserName.Name = "TxtUserName";
        this.TxtUserName.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TxtUserName.Size = new System.Drawing.Size(209, 19);
        this.TxtUserName.TabIndex = 1;
        this.TxtUserName.Tag = "";
        this.TxtUserName.Visible = false;
        // 
        // TxtUrl
        // 
        this.TxtUrl.AcceptsReturn = true;
        this.TxtUrl.BackColor = System.Drawing.SystemColors.Window;
        this.TxtUrl.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.TxtUrl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.TxtUrl.ForeColor = System.Drawing.SystemColors.WindowText;
        this.TxtUrl.Location = new System.Drawing.Point(56, 104);
        this.TxtUrl.MaxLength = 0;
        this.TxtUrl.Name = "TxtUrl";
        this.TxtUrl.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.TxtUrl.Size = new System.Drawing.Size(209, 19);
        this.TxtUrl.TabIndex = 0;
        this.TxtUrl.Tag = "";
        this.TxtUrl.Visible = false;
        // 
        // Label3
        // 
        this.Label3.BackColor = System.Drawing.SystemColors.Control;
        this.Label3.Cursor = System.Windows.Forms.Cursors.Default;
        this.Label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label3.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Label3.Location = new System.Drawing.Point(0, 152);
        this.Label3.Name = "Label3";
        this.Label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Label3.Size = new System.Drawing.Size(49, 17);
        this.Label3.TabIndex = 6;
        this.Label3.Tag = "";
        this.Label3.Text = "Password";
        this.Label3.Visible = false;
        // 
        // Label2
        // 
        this.Label2.BackColor = System.Drawing.SystemColors.Control;
        this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
        this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Label2.Location = new System.Drawing.Point(0, 128);
        this.Label2.Name = "Label2";
        this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Label2.Size = new System.Drawing.Size(49, 17);
        this.Label2.TabIndex = 5;
        this.Label2.Tag = "";
        this.Label2.Text = "UserId";
        this.Label2.Visible = false;
        // 
        // Label1
        // 
        this.Label1.BackColor = System.Drawing.SystemColors.Control;
        this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
        this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Label1.Location = new System.Drawing.Point(8, 104);
        this.Label1.Name = "Label1";
        this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Label1.Size = new System.Drawing.Size(33, 17);
        this.Label1.TabIndex = 4;
        this.Label1.Tag = "";
        this.Label1.Text = "URL";
        this.Label1.Visible = false;
        // 
        // FrmFtp
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(662, 564);
        this.Controls.Add(this.ImageList1);
        this.Controls.Add(this.cmdConnect);
        this.Controls.Add(this.CmdDisconnect);
        this.Controls.Add(this.FrmConectado);
        this.Controls.Add(this.Frm_Status);
        this.Controls.Add(this.Label3);
        this.Controls.Add(this.TxtUrl);
        this.Controls.Add(this.Label1);
        this.Controls.Add(this.Label2);
        this.Controls.Add(this.TxtDir);
        this.Controls.Add(this.Inet1);
        this.Controls.Add(this.TxtUserName);
        this.Controls.Add(this.TxtPassword);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.ForeColor = System.Drawing.SystemColors.Highlight;
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(10, 29);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "FrmFtp";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "FTP";
        this.Closed += new System.EventHandler(this.FrmFtp_Closed);
        this.Resize += new System.EventHandler(this.FrmFtp_Resize);
        this.Activated += new System.EventHandler(this.FrmFtp_Activated);
        this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FrmFtp_MouseDown);
        ((System.ComponentModel.ISupportInitialize)(this.cmdConnect)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.CmdDisconnect)).EndInit();
        this.Frm_Status.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.SbFTp)).EndInit();
        this.FrmConectado.ResumeLayout(false);
        this.Frm_Remote.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.DirRemote)).EndInit();
        this.Frm_Local.ResumeLayout(false);
        this.Frame1.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.BtnRecibir)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.ImageList1)).EndInit();
        ((System.ComponentModel.ISupportInitialize)(this.Inet1)).EndInit();
        this.ResumeLayout(false);

	}
#endregion 
}
}