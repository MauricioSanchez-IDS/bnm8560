using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORCTPGS
	{
	
#region "Upgrade Support "
		private static CORCTPGS m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORCTPGS DefInstance
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
		public CORCTPGS():base(){
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
			InitializecboCombo();
			InitializecmdBoton();
			InitializetxtTexto();
		}
	public static CORCTPGS CreateInstance()
	{
			CORCTPGS theInstance = new CORCTPGS();
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
	private  System.Windows.Forms.ComboBox _cboCombo_0;
	private  System.Windows.Forms.Button _cmdBoton_3;
	private  System.Windows.Forms.Button _cmdBoton_2;
	private  System.Windows.Forms.TextBox _txtTexto_5;
	private  System.Windows.Forms.Button _cmdBoton_1;
	private  System.Windows.Forms.Button _cmdBoton_0;
	private  System.Windows.Forms.TextBox _txtTexto_7;
	private  System.Windows.Forms.TextBox _txtTexto_6;
	public  System.Windows.Forms.Label Label10;
	public  System.Windows.Forms.Label Label9;
	public  System.Windows.Forms.GroupBox fraFrame;
	private  System.Windows.Forms.TextBox _txtTexto_4;
	private  System.Windows.Forms.TextBox _txtTexto_3;
	private  System.Windows.Forms.TextBox _txtTexto_2;
	private  System.Windows.Forms.TextBox _txtTexto_1;
	private  System.Windows.Forms.TextBox _txtTexto_0;
	public  System.Windows.Forms.Label Label2;
	public  System.Windows.Forms.Label ID_PAR_NOM_TXT;
	public  System.Windows.Forms.Label ID_PAR_NUM_TXT;
	public  System.Windows.Forms.Label ID_PAR_GRU_TXT;
	public  System.Windows.Forms.Label ID_PAR_PRE_TXT;
	public  System.Windows.Forms.Label ID_PAR_CON_TXT;
	public  AxThreed.AxSSPanel ID_PAR_BAN_PNL;
	public  System.Windows.Forms.Label Label1;
	public System.Windows.Forms.ComboBox[] cboCombo = new System.Windows.Forms.ComboBox[1];
	public System.Windows.Forms.Button[] cmdBoton = new System.Windows.Forms.Button[4];
	public System.Windows.Forms.TextBox[] txtTexto = new System.Windows.Forms.TextBox[8];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CORCTPGS));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this._cboCombo_0 = new System.Windows.Forms.ComboBox();
			this.ID_PAR_BAN_PNL = new AxThreed.AxSSPanel();
			this._cmdBoton_3 = new System.Windows.Forms.Button();
			this._cmdBoton_2 = new System.Windows.Forms.Button();
			this._txtTexto_5 = new System.Windows.Forms.TextBox();
			this._cmdBoton_1 = new System.Windows.Forms.Button();
			this._cmdBoton_0 = new System.Windows.Forms.Button();
			this.fraFrame = new System.Windows.Forms.GroupBox();
			this._txtTexto_7 = new System.Windows.Forms.TextBox();
			this._txtTexto_6 = new System.Windows.Forms.TextBox();
			this.Label10 = new System.Windows.Forms.Label();
			this.Label9 = new System.Windows.Forms.Label();
			this._txtTexto_4 = new System.Windows.Forms.TextBox();
			this._txtTexto_3 = new System.Windows.Forms.TextBox();
			this._txtTexto_2 = new System.Windows.Forms.TextBox();
			this._txtTexto_1 = new System.Windows.Forms.TextBox();
			this._txtTexto_0 = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.ID_PAR_NOM_TXT = new System.Windows.Forms.Label();
			this.ID_PAR_NUM_TXT = new System.Windows.Forms.Label();
			this.ID_PAR_GRU_TXT = new System.Windows.Forms.Label();
			this.ID_PAR_PRE_TXT = new System.Windows.Forms.Label();
			this.ID_PAR_CON_TXT = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) this.ID_PAR_BAN_PNL).BeginInit();
			this.ID_PAR_BAN_PNL.SuspendLayout();
			this.fraFrame.SuspendLayout();
			this.SuspendLayout();
			// 
			// _cboCombo_0
			// 
			this._cboCombo_0.BackColor = System.Drawing.SystemColors.Window;
			this._cboCombo_0.CausesValidation = true;
			this._cboCombo_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cboCombo_0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this._cboCombo_0.Enabled = true;
			this._cboCombo_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._cboCombo_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._cboCombo_0.IntegralHeight = true;
			this._cboCombo_0.Location = new System.Drawing.Point(66, 9);
			this._cboCombo_0.Name = "_cboCombo_0";
			this._cboCombo_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cboCombo_0.Size = new System.Drawing.Size(304, 21);
			this._cboCombo_0.Sorted = false;
			this._cboCombo_0.TabIndex = 12;
			this._cboCombo_0.TabStop = true;
			this._cboCombo_0.Tag = "";
			this._cboCombo_0.Visible = true;
			this._cboCombo_0.SelectedIndexChanged += new System.EventHandler(this.cboCombo_SelectedIndexChanged);
			// 
			// ID_PAR_BAN_PNL
			// 
			this.ID_PAR_BAN_PNL.Controls.Add(this._txtTexto_1);
			this.ID_PAR_BAN_PNL.Controls.Add(this._txtTexto_0);
			this.ID_PAR_BAN_PNL.Controls.Add(this._txtTexto_2);
			this.ID_PAR_BAN_PNL.Controls.Add(this._txtTexto_4);
			this.ID_PAR_BAN_PNL.Controls.Add(this._txtTexto_3);
			this.ID_PAR_BAN_PNL.Controls.Add(this.Label2);
			this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_PRE_TXT);
			this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_CON_TXT);
			this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_GRU_TXT);
			this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_NOM_TXT);
			this.ID_PAR_BAN_PNL.Controls.Add(this.ID_PAR_NUM_TXT);
			this.ID_PAR_BAN_PNL.Controls.Add(this.fraFrame);
			this.ID_PAR_BAN_PNL.Controls.Add(this._cmdBoton_2);
			this.ID_PAR_BAN_PNL.Controls.Add(this._cmdBoton_3);
			this.ID_PAR_BAN_PNL.Controls.Add(this._txtTexto_5);
			this.ID_PAR_BAN_PNL.Controls.Add(this._cmdBoton_0);
			this.ID_PAR_BAN_PNL.Controls.Add(this._cmdBoton_1);
			this.ID_PAR_BAN_PNL.Location = new System.Drawing.Point(6, 39);
			this.ID_PAR_BAN_PNL.Name = "ID_PAR_BAN_PNL";
			this.ID_PAR_BAN_PNL.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("ID_PAR_BAN_PNL.OcxState");
			this.ID_PAR_BAN_PNL.Size = new System.Drawing.Size(368, 268);
			this.ID_PAR_BAN_PNL.TabIndex = 0;
			this.ID_PAR_BAN_PNL.Tag = "";
			// 
			// _cmdBoton_3
			// 
			this._cmdBoton_3.BackColor = System.Drawing.SystemColors.Control;
			this._cmdBoton_3.CausesValidation = true;
			this._cmdBoton_3.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdBoton_3.Enabled = true;
			this._cmdBoton_3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._cmdBoton_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._cmdBoton_3.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdBoton_3.Location = new System.Drawing.Point(276, 222);
			this._cmdBoton_3.Name = "_cmdBoton_3";
			this._cmdBoton_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdBoton_3.Size = new System.Drawing.Size(82, 25);
			this._cmdBoton_3.TabIndex = 23;
			this._cmdBoton_3.TabStop = true;
			this._cmdBoton_3.Tag = "";
			this._cmdBoton_3.Text = "&Salir";
			this._cmdBoton_3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdBoton_3.Click += new System.EventHandler(this.cmdBoton_Click);
			// 
			// _cmdBoton_2
			// 
			this._cmdBoton_2.BackColor = System.Drawing.SystemColors.Control;
			this._cmdBoton_2.CausesValidation = true;
			this._cmdBoton_2.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdBoton_2.Enabled = true;
			this._cmdBoton_2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._cmdBoton_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._cmdBoton_2.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdBoton_2.Location = new System.Drawing.Point(276, 187);
			this._cmdBoton_2.Name = "_cmdBoton_2";
			this._cmdBoton_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdBoton_2.Size = new System.Drawing.Size(82, 25);
			this._cmdBoton_2.TabIndex = 22;
			this._cmdBoton_2.TabStop = true;
			this._cmdBoton_2.Tag = "";
			this._cmdBoton_2.Text = "&Cambios";
			this._cmdBoton_2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdBoton_2.Click += new System.EventHandler(this.cmdBoton_Click);
			// 
			// _txtTexto_5
			// 
			this._txtTexto_5.AcceptsReturn = true;
			this._txtTexto_5.AutoSize = false;
			this._txtTexto_5.BackColor = System.Drawing.SystemColors.Window;
			this._txtTexto_5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtTexto_5.CausesValidation = true;
			this._txtTexto_5.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtTexto_5.Enabled = true;
			this._txtTexto_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._txtTexto_5.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtTexto_5.HideSelection = true;
			this._txtTexto_5.Location = new System.Drawing.Point(141, 133);
			this._txtTexto_5.MaxLength = 0;
			this._txtTexto_5.Multiline = false;
			this._txtTexto_5.Name = "_txtTexto_5";
			this._txtTexto_5.ReadOnly = false;
			this._txtTexto_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtTexto_5.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtTexto_5.Size = new System.Drawing.Size(55, 21);
			this._txtTexto_5.TabIndex = 20;
			this._txtTexto_5.TabStop = true;
			this._txtTexto_5.Tag = "";
			this._txtTexto_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtTexto_5.Visible = true;
			// 
			// _cmdBoton_1
			// 
			this._cmdBoton_1.BackColor = System.Drawing.SystemColors.Control;
			this._cmdBoton_1.CausesValidation = true;
			this._cmdBoton_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdBoton_1.Enabled = true;
			this._cmdBoton_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._cmdBoton_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._cmdBoton_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdBoton_1.Location = new System.Drawing.Point(276, 152);
			this._cmdBoton_1.Name = "_cmdBoton_1";
			this._cmdBoton_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdBoton_1.Size = new System.Drawing.Size(82, 25);
			this._cmdBoton_1.TabIndex = 18;
			this._cmdBoton_1.TabStop = true;
			this._cmdBoton_1.Tag = "";
			this._cmdBoton_1.Text = "&Baja";
			this._cmdBoton_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdBoton_1.Click += new System.EventHandler(this.cmdBoton_Click);
			// 
			// _cmdBoton_0
			// 
			this._cmdBoton_0.BackColor = System.Drawing.SystemColors.Control;
			this._cmdBoton_0.CausesValidation = true;
			this._cmdBoton_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._cmdBoton_0.Enabled = true;
			this._cmdBoton_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._cmdBoton_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._cmdBoton_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._cmdBoton_0.Location = new System.Drawing.Point(276, 117);
			this._cmdBoton_0.Name = "_cmdBoton_0";
			this._cmdBoton_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._cmdBoton_0.Size = new System.Drawing.Size(82, 25);
			this._cmdBoton_0.TabIndex = 17;
			this._cmdBoton_0.TabStop = true;
			this._cmdBoton_0.Tag = "";
			this._cmdBoton_0.Text = "&Alta";
			this._cmdBoton_0.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this._cmdBoton_0.Click += new System.EventHandler(this.cmdBoton_Click);
			// 
			// fraFrame
			// 
			this.fraFrame.BackColor = System.Drawing.SystemColors.Control;
			this.fraFrame.Controls.Add(this._txtTexto_7);
			this.fraFrame.Controls.Add(this._txtTexto_6);
			this.fraFrame.Controls.Add(this.Label9);
			this.fraFrame.Controls.Add(this.Label10);
			this.fraFrame.Enabled = true;
			this.fraFrame.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.fraFrame.ForeColor = System.Drawing.SystemColors.ControlText;
			this.fraFrame.Location = new System.Drawing.Point(12, 162);
			this.fraFrame.Name = "fraFrame";
			this.fraFrame.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.fraFrame.Size = new System.Drawing.Size(232, 85);
			this.fraFrame.TabIndex = 13;
			this.fraFrame.Tag = "";
			this.fraFrame.Text = "Configuración";
			this.fraFrame.Visible = true;
			// 
			// _txtTexto_7
			// 
			this._txtTexto_7.AcceptsReturn = true;
			this._txtTexto_7.AutoSize = false;
			this._txtTexto_7.BackColor = System.Drawing.SystemColors.Window;
			this._txtTexto_7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtTexto_7.CausesValidation = true;
			this._txtTexto_7.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtTexto_7.Enabled = true;
			this._txtTexto_7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._txtTexto_7.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtTexto_7.HideSelection = true;
			this._txtTexto_7.Location = new System.Drawing.Point(129, 51);
			this._txtTexto_7.MaxLength = 0;
			this._txtTexto_7.Multiline = false;
			this._txtTexto_7.Name = "_txtTexto_7";
			this._txtTexto_7.ReadOnly = false;
			this._txtTexto_7.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtTexto_7.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtTexto_7.Size = new System.Drawing.Size(55, 21);
			this._txtTexto_7.TabIndex = 21;
			this._txtTexto_7.TabStop = true;
			this._txtTexto_7.Tag = "";
			this._txtTexto_7.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtTexto_7.Visible = true;
			// 
			// _txtTexto_6
			// 
			this._txtTexto_6.AcceptsReturn = true;
			this._txtTexto_6.AutoSize = false;
			this._txtTexto_6.BackColor = System.Drawing.SystemColors.Window;
			this._txtTexto_6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtTexto_6.CausesValidation = true;
			this._txtTexto_6.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtTexto_6.Enabled = true;
			this._txtTexto_6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._txtTexto_6.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtTexto_6.HideSelection = true;
			this._txtTexto_6.Location = new System.Drawing.Point(129, 18);
			this._txtTexto_6.MaxLength = 0;
			this._txtTexto_6.Multiline = false;
			this._txtTexto_6.Name = "_txtTexto_6";
			this._txtTexto_6.ReadOnly = false;
			this._txtTexto_6.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtTexto_6.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtTexto_6.Size = new System.Drawing.Size(55, 21);
			this._txtTexto_6.TabIndex = 16;
			this._txtTexto_6.TabStop = true;
			this._txtTexto_6.Tag = "";
			this._txtTexto_6.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtTexto_6.Visible = true;
			// 
			// Label10
			// 
			this.Label10.AutoSize = false;
			this.Label10.BackColor = System.Drawing.SystemColors.Control;
			this.Label10.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label10.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label10.Enabled = true;
			this.Label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Label10.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label10.Location = new System.Drawing.Point(9, 59);
			this.Label10.Name = "Label10";
			this.Label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label10.Size = new System.Drawing.Size(112, 17);
			this.Label10.TabIndex = 15;
			this.Label10.Tag = "";
			this.Label10.Text = "&Longitud de Ejecutivos:";
			this.Label10.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label10.UseMnemonic = true;
			this.Label10.Visible = true;
			// 
			// Label9
			// 
			this.Label9.AutoSize = false;
			this.Label9.BackColor = System.Drawing.SystemColors.Control;
			this.Label9.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label9.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label9.Enabled = true;
			this.Label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Label9.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label9.Location = new System.Drawing.Point(9, 20);
			this.Label9.Name = "Label9";
			this.Label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label9.Size = new System.Drawing.Size(112, 17);
			this.Label9.TabIndex = 14;
			this.Label9.Tag = "";
			this.Label9.Text = "&Longitud de Empresa:";
			this.Label9.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label9.UseMnemonic = true;
			this.Label9.Visible = true;
			// 
			// _txtTexto_4
			// 
			this._txtTexto_4.AcceptsReturn = true;
			this._txtTexto_4.AutoSize = false;
			this._txtTexto_4.BackColor = System.Drawing.SystemColors.Window;
			this._txtTexto_4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtTexto_4.CausesValidation = true;
			this._txtTexto_4.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtTexto_4.Enabled = false;
			this._txtTexto_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._txtTexto_4.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtTexto_4.HideSelection = true;
			this._txtTexto_4.Location = new System.Drawing.Point(141, 104);
			this._txtTexto_4.MaxLength = 0;
			this._txtTexto_4.Multiline = false;
			this._txtTexto_4.Name = "_txtTexto_4";
			this._txtTexto_4.ReadOnly = false;
			this._txtTexto_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtTexto_4.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtTexto_4.Size = new System.Drawing.Size(55, 21);
			this._txtTexto_4.TabIndex = 10;
			this._txtTexto_4.TabStop = true;
			this._txtTexto_4.Tag = "";
			this._txtTexto_4.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtTexto_4.Visible = true;
			// 
			// _txtTexto_3
			// 
			this._txtTexto_3.AcceptsReturn = true;
			this._txtTexto_3.AutoSize = false;
			this._txtTexto_3.BackColor = System.Drawing.SystemColors.Window;
			this._txtTexto_3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtTexto_3.CausesValidation = true;
			this._txtTexto_3.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtTexto_3.Enabled = false;
			this._txtTexto_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._txtTexto_3.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtTexto_3.HideSelection = true;
			this._txtTexto_3.Location = new System.Drawing.Point(141, 74);
			this._txtTexto_3.MaxLength = 0;
			this._txtTexto_3.Multiline = false;
			this._txtTexto_3.Name = "_txtTexto_3";
			this._txtTexto_3.ReadOnly = false;
			this._txtTexto_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtTexto_3.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtTexto_3.Size = new System.Drawing.Size(55, 21);
			this._txtTexto_3.TabIndex = 9;
			this._txtTexto_3.TabStop = true;
			this._txtTexto_3.Tag = "";
			this._txtTexto_3.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtTexto_3.Visible = true;
			// 
			// _txtTexto_2
			// 
			this._txtTexto_2.AcceptsReturn = true;
			this._txtTexto_2.AutoSize = false;
			this._txtTexto_2.BackColor = System.Drawing.SystemColors.Window;
			this._txtTexto_2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtTexto_2.CausesValidation = true;
			this._txtTexto_2.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtTexto_2.Enabled = true;
			this._txtTexto_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._txtTexto_2.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtTexto_2.HideSelection = true;
			this._txtTexto_2.Location = new System.Drawing.Point(303, 45);
			this._txtTexto_2.MaxLength = 0;
			this._txtTexto_2.Multiline = false;
			this._txtTexto_2.Name = "_txtTexto_2";
			this._txtTexto_2.ReadOnly = false;
			this._txtTexto_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtTexto_2.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtTexto_2.Size = new System.Drawing.Size(55, 21);
			this._txtTexto_2.TabIndex = 8;
			this._txtTexto_2.TabStop = true;
			this._txtTexto_2.Tag = "";
			this._txtTexto_2.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtTexto_2.Visible = true;
			// 
			// _txtTexto_1
			// 
			this._txtTexto_1.AcceptsReturn = true;
			this._txtTexto_1.AutoSize = false;
			this._txtTexto_1.BackColor = System.Drawing.SystemColors.Window;
			this._txtTexto_1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtTexto_1.CausesValidation = true;
			this._txtTexto_1.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtTexto_1.Enabled = true;
			this._txtTexto_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._txtTexto_1.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtTexto_1.HideSelection = true;
			this._txtTexto_1.Location = new System.Drawing.Point(141, 45);
			this._txtTexto_1.MaxLength = 0;
			this._txtTexto_1.Multiline = false;
			this._txtTexto_1.Name = "_txtTexto_1";
			this._txtTexto_1.ReadOnly = false;
			this._txtTexto_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtTexto_1.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtTexto_1.Size = new System.Drawing.Size(55, 21);
			this._txtTexto_1.TabIndex = 7;
			this._txtTexto_1.TabStop = true;
			this._txtTexto_1.Tag = "";
			this._txtTexto_1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtTexto_1.Visible = true;
			// 
			// _txtTexto_0
			// 
			this._txtTexto_0.AcceptsReturn = true;
			this._txtTexto_0.AutoSize = false;
			this._txtTexto_0.BackColor = System.Drawing.SystemColors.Window;
			this._txtTexto_0.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this._txtTexto_0.CausesValidation = true;
			this._txtTexto_0.Cursor = System.Windows.Forms.Cursors.IBeam;
			this._txtTexto_0.Enabled = true;
			this._txtTexto_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._txtTexto_0.ForeColor = System.Drawing.SystemColors.WindowText;
			this._txtTexto_0.HideSelection = true;
			this._txtTexto_0.Location = new System.Drawing.Point(63, 15);
			this._txtTexto_0.MaxLength = 0;
			this._txtTexto_0.Multiline = false;
			this._txtTexto_0.Name = "_txtTexto_0";
			this._txtTexto_0.ReadOnly = false;
			this._txtTexto_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._txtTexto_0.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this._txtTexto_0.Size = new System.Drawing.Size(295, 21);
			this._txtTexto_0.TabIndex = 6;
			this._txtTexto_0.TabStop = true;
			this._txtTexto_0.Tag = "";
			this._txtTexto_0.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this._txtTexto_0.Visible = true;
			// 
			// Label2
			// 
			this.Label2.AutoSize = false;
			this.Label2.BackColor = System.Drawing.SystemColors.Control;
			this.Label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label2.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label2.Enabled = true;
			this.Label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Label2.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label2.Location = new System.Drawing.Point(12, 135);
			this.Label2.Name = "Label2";
			this.Label2.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label2.Size = new System.Drawing.Size(133, 17);
			this.Label2.TabIndex = 19;
			this.Label2.Tag = "";
			this.Label2.Text = "Incremento";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label2.UseMnemonic = true;
			this.Label2.Visible = true;
			this.Label2.Click += new System.EventHandler(this.Label2_Click);
			// 
			// ID_PAR_NOM_TXT
			// 
			this.ID_PAR_NOM_TXT.AutoSize = false;
			this.ID_PAR_NOM_TXT.BackColor = System.Drawing.SystemColors.Control;
			this.ID_PAR_NOM_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ID_PAR_NOM_TXT.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_PAR_NOM_TXT.Enabled = true;
			this.ID_PAR_NOM_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_PAR_NOM_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_PAR_NOM_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_PAR_NOM_TXT.Location = new System.Drawing.Point(12, 20);
			this.ID_PAR_NOM_TXT.Name = "ID_PAR_NOM_TXT";
			this.ID_PAR_NOM_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_PAR_NOM_TXT.Size = new System.Drawing.Size(48, 14);
			this.ID_PAR_NOM_TXT.TabIndex = 5;
			this.ID_PAR_NOM_TXT.Tag = "";
			this.ID_PAR_NOM_TXT.Text = "&Banco:";
			this.ID_PAR_NOM_TXT.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ID_PAR_NOM_TXT.UseMnemonic = true;
			this.ID_PAR_NOM_TXT.Visible = true;
			// 
			// ID_PAR_NUM_TXT
			// 
			this.ID_PAR_NUM_TXT.AutoSize = false;
			this.ID_PAR_NUM_TXT.BackColor = System.Drawing.SystemColors.Control;
			this.ID_PAR_NUM_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ID_PAR_NUM_TXT.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_PAR_NUM_TXT.Enabled = true;
			this.ID_PAR_NUM_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_PAR_NUM_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_PAR_NUM_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_PAR_NUM_TXT.Location = new System.Drawing.Point(12, 48);
			this.ID_PAR_NUM_TXT.Name = "ID_PAR_NUM_TXT";
			this.ID_PAR_NUM_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_PAR_NUM_TXT.Size = new System.Drawing.Size(81, 14);
			this.ID_PAR_NUM_TXT.TabIndex = 4;
			this.ID_PAR_NUM_TXT.Tag = "";
			this.ID_PAR_NUM_TXT.Text = "N&o. de Banco";
			this.ID_PAR_NUM_TXT.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ID_PAR_NUM_TXT.UseMnemonic = true;
			this.ID_PAR_NUM_TXT.Visible = true;
			// 
			// ID_PAR_GRU_TXT
			// 
			this.ID_PAR_GRU_TXT.AutoSize = false;
			this.ID_PAR_GRU_TXT.BackColor = System.Drawing.SystemColors.Control;
			this.ID_PAR_GRU_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ID_PAR_GRU_TXT.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_PAR_GRU_TXT.Enabled = true;
			this.ID_PAR_GRU_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_PAR_GRU_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_PAR_GRU_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_PAR_GRU_TXT.Location = new System.Drawing.Point(12, 78);
			this.ID_PAR_GRU_TXT.Name = "ID_PAR_GRU_TXT";
			this.ID_PAR_GRU_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_PAR_GRU_TXT.Size = new System.Drawing.Size(129, 14);
			this.ID_PAR_GRU_TXT.TabIndex = 3;
			this.ID_PAR_GRU_TXT.Tag = "";
			this.ID_PAR_GRU_TXT.Text = "Consecutivo de &Grupo";
			this.ID_PAR_GRU_TXT.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ID_PAR_GRU_TXT.UseMnemonic = true;
			this.ID_PAR_GRU_TXT.Visible = true;
			// 
			// ID_PAR_PRE_TXT
			// 
			this.ID_PAR_PRE_TXT.AutoSize = false;
			this.ID_PAR_PRE_TXT.BackColor = System.Drawing.SystemColors.Control;
			this.ID_PAR_PRE_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ID_PAR_PRE_TXT.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_PAR_PRE_TXT.Enabled = true;
			this.ID_PAR_PRE_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_PAR_PRE_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_PAR_PRE_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_PAR_PRE_TXT.Location = new System.Drawing.Point(249, 49);
			this.ID_PAR_PRE_TXT.Name = "ID_PAR_PRE_TXT";
			this.ID_PAR_PRE_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_PAR_PRE_TXT.Size = new System.Drawing.Size(39, 13);
			this.ID_PAR_PRE_TXT.TabIndex = 2;
			this.ID_PAR_PRE_TXT.Tag = "";
			this.ID_PAR_PRE_TXT.Text = "&Prefijo";
			this.ID_PAR_PRE_TXT.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ID_PAR_PRE_TXT.UseMnemonic = true;
			this.ID_PAR_PRE_TXT.Visible = true;
			// 
			// ID_PAR_CON_TXT
			// 
			this.ID_PAR_CON_TXT.AutoSize = false;
			this.ID_PAR_CON_TXT.BackColor = System.Drawing.SystemColors.Control;
			this.ID_PAR_CON_TXT.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ID_PAR_CON_TXT.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_PAR_CON_TXT.Enabled = true;
			this.ID_PAR_CON_TXT.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_PAR_CON_TXT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_PAR_CON_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_PAR_CON_TXT.Location = new System.Drawing.Point(12, 107);
			this.ID_PAR_CON_TXT.Name = "ID_PAR_CON_TXT";
			this.ID_PAR_CON_TXT.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_PAR_CON_TXT.Size = new System.Drawing.Size(128, 15);
			this.ID_PAR_CON_TXT.TabIndex = 1;
			this.ID_PAR_CON_TXT.Tag = "";
			this.ID_PAR_CON_TXT.Text = "Consecutivo de &Empresa";
			this.ID_PAR_CON_TXT.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ID_PAR_CON_TXT.UseMnemonic = true;
			this.ID_PAR_CON_TXT.Visible = true;
			// 
			// Label1
			// 
			this.Label1.AutoSize = false;
			this.Label1.BackColor = System.Drawing.SystemColors.Control;
			this.Label1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.Label1.Cursor = System.Windows.Forms.Cursors.Default;
			this.Label1.Enabled = true;
			this.Label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.Label1.ForeColor = System.Drawing.SystemColors.ControlText;
			this.Label1.Location = new System.Drawing.Point(6, 12);
			this.Label1.Name = "Label1";
			this.Label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.Label1.Size = new System.Drawing.Size(46, 16);
			this.Label1.TabIndex = 11;
			this.Label1.Tag = "";
			this.Label1.Text = "Producto";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.Label1.UseMnemonic = true;
			this.Label1.Visible = true;
			// 
			// CORCTPGS
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(381, 311);
			this.ControlBox = true;
			this.Controls.Add(this.Label1);
			this.Controls.Add(this._cboCombo_0);
			this.Controls.Add(this.ID_PAR_BAN_PNL);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Enabled = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.HelpButton = false;
			this.KeyPreview = false;
			this.Location = new System.Drawing.Point(3, 22);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "CORCTPGS";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultLocation;
			this.Tag = "";
			this.Text = "Producto";
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			base.Closed += new System.EventHandler(this.CORCTPGS_Closed);
			((System.ComponentModel.ISupportInitialize) this.ID_PAR_BAN_PNL).EndInit();
			this.ID_PAR_BAN_PNL.ResumeLayout(false);
			this.fraFrame.ResumeLayout(false);
			this.ResumeLayout(false);
	}
	void  InitializecboCombo()
	{
			this.cboCombo[0] = _cboCombo_0;
	}
	void  InitializecmdBoton()
	{
			this.cmdBoton[3] = _cmdBoton_3;
			this.cmdBoton[2] = _cmdBoton_2;
			this.cmdBoton[1] = _cmdBoton_1;
			this.cmdBoton[0] = _cmdBoton_0;
	}
	void  InitializetxtTexto()
	{
			this.txtTexto[5] = _txtTexto_5;
			this.txtTexto[7] = _txtTexto_7;
			this.txtTexto[6] = _txtTexto_6;
			this.txtTexto[4] = _txtTexto_4;
			this.txtTexto[3] = _txtTexto_3;
			this.txtTexto[2] = _txtTexto_2;
			this.txtTexto[1] = _txtTexto_1;
			this.txtTexto[0] = _txtTexto_0;
	}
#endregion 
}
}