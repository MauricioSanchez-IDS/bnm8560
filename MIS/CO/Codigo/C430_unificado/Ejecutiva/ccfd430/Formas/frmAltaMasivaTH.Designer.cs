using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class frmAltaMasivaTH
	{
	
#region "Upgrade Support "
		private static frmAltaMasivaTH m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmAltaMasivaTH DefInstance
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
		public frmAltaMasivaTH():base(){
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
			InitializelblEtiqueta();
			InitializeID_CAM_CTA_LB();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static frmAltaMasivaTH CreateInstance()
	{
			frmAltaMasivaTH theInstance = new frmAltaMasivaTH();
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
	public  System.Windows.Forms.ListBox lstLista;
	public  System.Windows.Forms.Panel picPicture;
	public  System.Windows.Forms.HScrollBar scrScroll;
	public  AxMSComDlg.AxCommonDialog cdlDialogo;
	public  System.Windows.Forms.TextBox txtArchivo;
	public  System.Windows.Forms.Button cmdArchivo;
	public  System.Windows.Forms.Button cmdEnviar;
	public  System.Windows.Forms.Button cmdCancelar;
	public  AxThreed.AxSSPanel sspAvance;
	private  System.Windows.Forms.Label _lblEtiqueta_1;
	private  System.Windows.Forms.Label _ID_CAM_CTA_LB_1;
	public  System.Windows.Forms.Label ID_CAM_EMP_LB;
	private  System.Windows.Forms.Label _lblEtiqueta_0;
	public  System.Windows.Forms.Label ID_CAM_GPO_LB;
	public  System.Windows.Forms.Label ID_CAM_MEN_LBL;
	public  AxThreed.AxSSPanel sspPanel;
	public System.Windows.Forms.Label[] ID_CAM_CTA_LB = new System.Windows.Forms.Label[2];
	public System.Windows.Forms.Label[] lblEtiqueta = new System.Windows.Forms.Label[2];
	private Artinsoft.VB6.Gui.ListControlHelper ListBoxComboBoxHelper1;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAltaMasivaTH));
			this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
			this.sspPanel = new AxThreed.AxSSPanel();
			this.picPicture = new System.Windows.Forms.Panel();
			this.lstLista = new System.Windows.Forms.ListBox();
			this.scrScroll = new System.Windows.Forms.HScrollBar();
			this.cdlDialogo = new AxMSComDlg.AxCommonDialog();
			this.txtArchivo = new System.Windows.Forms.TextBox();
			this.cmdArchivo = new System.Windows.Forms.Button();
			this.cmdEnviar = new System.Windows.Forms.Button();
			this.cmdCancelar = new System.Windows.Forms.Button();
			this.sspAvance = new AxThreed.AxSSPanel();
			this._lblEtiqueta_1 = new System.Windows.Forms.Label();
			this._ID_CAM_CTA_LB_1 = new System.Windows.Forms.Label();
			this.ID_CAM_EMP_LB = new System.Windows.Forms.Label();
			this._lblEtiqueta_0 = new System.Windows.Forms.Label();
			this.ID_CAM_GPO_LB = new System.Windows.Forms.Label();
			this.ID_CAM_MEN_LBL = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize) this.cdlDialogo).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.sspAvance).BeginInit();
			((System.ComponentModel.ISupportInitialize) this.sspPanel).BeginInit();
			this.sspPanel.SuspendLayout();
			this.picPicture.SuspendLayout();
			this.SuspendLayout();
			this.ListBoxComboBoxHelper1 = new Artinsoft.VB6.Gui.ListControlHelper(this.components);
			((System.ComponentModel.ISupportInitialize) this.ListBoxComboBoxHelper1).BeginInit();
			// 
			// sspPanel
			// 
			this.sspPanel.Controls.Add(this.sspAvance);
			this.sspPanel.Controls.Add(this._lblEtiqueta_1);
			this.sspPanel.Controls.Add(this.cmdCancelar);
			this.sspPanel.Controls.Add(this.cmdArchivo);
			this.sspPanel.Controls.Add(this.cmdEnviar);
			this.sspPanel.Controls.Add(this.ID_CAM_GPO_LB);
			this.sspPanel.Controls.Add(this.ID_CAM_MEN_LBL);
			this.sspPanel.Controls.Add(this._lblEtiqueta_0);
			this.sspPanel.Controls.Add(this._ID_CAM_CTA_LB_1);
			this.sspPanel.Controls.Add(this.ID_CAM_EMP_LB);
			this.sspPanel.Controls.Add(this.scrScroll);
			this.sspPanel.Controls.Add(this.picPicture);
			this.sspPanel.Controls.Add(this.txtArchivo);
			this.sspPanel.Controls.Add(this.cdlDialogo);
			this.sspPanel.Location = new System.Drawing.Point(2, 3);
			this.sspPanel.Name = "sspPanel";
			this.sspPanel.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("sspPanel.OcxState");
			this.sspPanel.Size = new System.Drawing.Size(658, 473);
			this.sspPanel.TabIndex = 0;
			this.sspPanel.Tag = "";
			// 
			// picPicture
			// 
			this.picPicture.BackColor = System.Drawing.SystemColors.Control;
			this.picPicture.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.picPicture.CausesValidation = true;
			this.picPicture.Controls.Add(this.lstLista);
			this.picPicture.Cursor = System.Windows.Forms.Cursors.Default;
			this.picPicture.Dock = System.Windows.Forms.DockStyle.None;
			this.picPicture.Enabled = true;
			this.picPicture.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.picPicture.Location = new System.Drawing.Point(9, 27);
			this.picPicture.Name = "picPicture";
			this.picPicture.Size = new System.Drawing.Size(637, 354);
			this.picPicture.TabIndex = 13;
			this.picPicture.TabStop = true;
			this.picPicture.Tag = "";
			this.picPicture.Visible = true;
			// 
			// lstLista
			// 
			this.lstLista.BackColor = System.Drawing.SystemColors.Window;
			this.lstLista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lstLista.CausesValidation = true;
			this.lstLista.ColumnWidth = 200;
			this.lstLista.Cursor = System.Windows.Forms.Cursors.Default;
			this.lstLista.Enabled = true;
			this.lstLista.Font = new System.Drawing.Font("Courier New", 8.25f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.lstLista.ForeColor = System.Drawing.Color.FromArgb(0, 0, 64);
			this.lstLista.IntegralHeight = true;
			this.lstLista.Items.AddRange(new object[]{"lstLista"});
			this.lstLista.Location = new System.Drawing.Point(-3, -3);
			this.lstLista.MultiColumn = true;
			this.lstLista.Name = "lstLista";
			this.lstLista.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.lstLista.SelectionMode = System.Windows.Forms.SelectionMode.One;
			this.lstLista.Size = new System.Drawing.Size(1000, 357);
			this.lstLista.Sorted = false;
			this.lstLista.TabIndex = 14;
			this.lstLista.TabStop = true;
			this.lstLista.Tag = "";
			this.lstLista.Visible = true;
			// 
			// scrScroll
			// 
			this.scrScroll.CausesValidation = true;
			this.scrScroll.Cursor = System.Windows.Forms.Cursors.Default;
			this.scrScroll.Enabled = true;
			this.scrScroll.LargeChange = 1;
			this.scrScroll.Location = new System.Drawing.Point(9, 381);
			this.scrScroll.Maximum = 32767;
			this.scrScroll.Minimum = 0;
			this.scrScroll.Name = "scrScroll";
			this.scrScroll.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.scrScroll.Size = new System.Drawing.Size(637, 16);
			this.scrScroll.SmallChange = 1;
			this.scrScroll.TabIndex = 12;
			this.scrScroll.TabStop = true;
			this.scrScroll.Tag = "";
			this.scrScroll.Value = 0;
			this.scrScroll.Visible = true;
			this.scrScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.scrScroll_Scroll);
			// 
			// cdlDialogo
			// 
			this.cdlDialogo.Location = new System.Drawing.Point(18, 432);
			this.cdlDialogo.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("cdlDialogo.OcxState");
			this.cdlDialogo.Tag = "";
			// 
			// txtArchivo
			// 
			this.txtArchivo.AcceptsReturn = true;
			this.txtArchivo.AutoSize = false;
			this.txtArchivo.BackColor = System.Drawing.SystemColors.Window;
			this.txtArchivo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.txtArchivo.CausesValidation = true;
			this.txtArchivo.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.txtArchivo.Enabled = true;
			this.txtArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.txtArchivo.ForeColor = System.Drawing.SystemColors.WindowText;
			this.txtArchivo.HideSelection = true;
			this.txtArchivo.Location = new System.Drawing.Point(76, 432);
			this.txtArchivo.MaxLength = 0;
			this.txtArchivo.Multiline = false;
			this.txtArchivo.Name = "txtArchivo";
			this.txtArchivo.ReadOnly = false;
			this.txtArchivo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.txtArchivo.ScrollBars = System.Windows.Forms.ScrollBars.None;
			this.txtArchivo.Size = new System.Drawing.Size(319, 21);
			this.txtArchivo.TabIndex = 10;
			this.txtArchivo.TabStop = true;
			this.txtArchivo.Tag = "";
			this.txtArchivo.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
			this.txtArchivo.Visible = true;
			// 
			// cmdArchivo
			// 
			this.cmdArchivo.BackColor = System.Drawing.SystemColors.Control;
			this.cmdArchivo.CausesValidation = true;
			this.cmdArchivo.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdArchivo.Enabled = true;
			this.cmdArchivo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmdArchivo.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdArchivo.Location = new System.Drawing.Point(399, 428);
			this.cmdArchivo.Name = "cmdArchivo";
			this.cmdArchivo.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdArchivo.Size = new System.Drawing.Size(79, 26);
			this.cmdArchivo.TabIndex = 9;
			this.cmdArchivo.TabStop = true;
			this.cmdArchivo.Tag = "";
			this.cmdArchivo.Text = "&Archivo";
			this.cmdArchivo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.cmdArchivo.Click += new System.EventHandler(this.cmdArchivo_Click);
			// 
			// cmdEnviar
			// 
			this.cmdEnviar.BackColor = System.Drawing.SystemColors.Control;
			this.cmdEnviar.CausesValidation = true;
			this.cmdEnviar.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdEnviar.Enabled = true;
			this.cmdEnviar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdEnviar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmdEnviar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdEnviar.Location = new System.Drawing.Point(486, 428);
			this.cmdEnviar.Name = "cmdEnviar";
			this.cmdEnviar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdEnviar.Size = new System.Drawing.Size(79, 26);
			this.cmdEnviar.TabIndex = 3;
			this.cmdEnviar.TabStop = true;
			this.cmdEnviar.Tag = "";
			this.cmdEnviar.Text = "Enviar";
			this.cmdEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// cmdCancelar
			// 
			this.cmdCancelar.BackColor = System.Drawing.SystemColors.Control;
			this.cmdCancelar.CausesValidation = true;
			this.cmdCancelar.Cursor = System.Windows.Forms.Cursors.Default;
			this.cmdCancelar.Enabled = true;
			this.cmdCancelar.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cmdCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.cmdCancelar.ForeColor = System.Drawing.SystemColors.ControlText;
			this.cmdCancelar.Location = new System.Drawing.Point(571, 428);
			this.cmdCancelar.Name = "cmdCancelar";
			this.cmdCancelar.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.cmdCancelar.Size = new System.Drawing.Size(79, 26);
			this.cmdCancelar.TabIndex = 2;
			this.cmdCancelar.TabStop = true;
			this.cmdCancelar.Tag = "";
			this.cmdCancelar.Text = "Cancelar";
			this.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// sspAvance
			// 
			this.sspAvance.Location = new System.Drawing.Point(8, 401);
			this.sspAvance.Name = "sspAvance";
			this.sspAvance.OcxState = (System.Windows.Forms.AxHost.State) resources.GetObject("sspAvance.OcxState");
			this.sspAvance.Size = new System.Drawing.Size(639, 25);
			this.sspAvance.TabIndex = 1;
			this.sspAvance.Tag = "";
			// 
			// _lblEtiqueta_1
			// 
			this._lblEtiqueta_1.AutoSize = true;
			this._lblEtiqueta_1.BackColor = System.Drawing.SystemColors.Control;
			this._lblEtiqueta_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblEtiqueta_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblEtiqueta_1.Enabled = true;
			this._lblEtiqueta_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._lblEtiqueta_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._lblEtiqueta_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblEtiqueta_1.Location = new System.Drawing.Point(12, 435);
			this._lblEtiqueta_1.Name = "_lblEtiqueta_1";
			this._lblEtiqueta_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblEtiqueta_1.Size = new System.Drawing.Size(57, 16);
			this._lblEtiqueta_1.TabIndex = 11;
			this._lblEtiqueta_1.Tag = "";
			this._lblEtiqueta_1.Text = "Archivo:";
			this._lblEtiqueta_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblEtiqueta_1.UseMnemonic = true;
			this._lblEtiqueta_1.Visible = true;
			// 
			// _ID_CAM_CTA_LB_1
			// 
			this._ID_CAM_CTA_LB_1.AutoSize = true;
			this._ID_CAM_CTA_LB_1.BackColor = System.Drawing.SystemColors.Control;
			this._ID_CAM_CTA_LB_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._ID_CAM_CTA_LB_1.Cursor = System.Windows.Forms.Cursors.Default;
			this._ID_CAM_CTA_LB_1.Enabled = true;
			this._ID_CAM_CTA_LB_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._ID_CAM_CTA_LB_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._ID_CAM_CTA_LB_1.ForeColor = System.Drawing.SystemColors.ControlText;
			this._ID_CAM_CTA_LB_1.Location = new System.Drawing.Point(201, 7);
			this._ID_CAM_CTA_LB_1.Name = "_ID_CAM_CTA_LB_1";
			this._ID_CAM_CTA_LB_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._ID_CAM_CTA_LB_1.Size = new System.Drawing.Size(77, 16);
			this._ID_CAM_CTA_LB_1.TabIndex = 8;
			this._ID_CAM_CTA_LB_1.Tag = "";
			this._ID_CAM_CTA_LB_1.Text = "No. Cuenta";
			this._ID_CAM_CTA_LB_1.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._ID_CAM_CTA_LB_1.UseMnemonic = true;
			this._ID_CAM_CTA_LB_1.Visible = true;
			// 
			// ID_CAM_EMP_LB
			// 
			this.ID_CAM_EMP_LB.AutoSize = true;
			this.ID_CAM_EMP_LB.BackColor = System.Drawing.SystemColors.Control;
			this.ID_CAM_EMP_LB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ID_CAM_EMP_LB.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_CAM_EMP_LB.Enabled = true;
			this.ID_CAM_EMP_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_CAM_EMP_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_CAM_EMP_LB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_CAM_EMP_LB.Location = new System.Drawing.Point(330, 7);
			this.ID_CAM_EMP_LB.Name = "ID_CAM_EMP_LB";
			this.ID_CAM_EMP_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_CAM_EMP_LB.Size = new System.Drawing.Size(63, 16);
			this.ID_CAM_EMP_LB.TabIndex = 7;
			this.ID_CAM_EMP_LB.Tag = "";
			this.ID_CAM_EMP_LB.Text = "Empresa";
			this.ID_CAM_EMP_LB.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ID_CAM_EMP_LB.UseMnemonic = true;
			this.ID_CAM_EMP_LB.Visible = true;
			// 
			// _lblEtiqueta_0
			// 
			this._lblEtiqueta_0.AutoSize = true;
			this._lblEtiqueta_0.BackColor = System.Drawing.SystemColors.Control;
			this._lblEtiqueta_0.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this._lblEtiqueta_0.Cursor = System.Windows.Forms.Cursors.Default;
			this._lblEtiqueta_0.Enabled = true;
			this._lblEtiqueta_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this._lblEtiqueta_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this._lblEtiqueta_0.ForeColor = System.Drawing.SystemColors.ControlText;
			this._lblEtiqueta_0.Location = new System.Drawing.Point(24, 8);
			this._lblEtiqueta_0.Name = "_lblEtiqueta_0";
			this._lblEtiqueta_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this._lblEtiqueta_0.Size = new System.Drawing.Size(56, 16);
			this._lblEtiqueta_0.TabIndex = 6;
			this._lblEtiqueta_0.Tag = "";
			this._lblEtiqueta_0.Text = "Nombre";
			this._lblEtiqueta_0.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this._lblEtiqueta_0.UseMnemonic = true;
			this._lblEtiqueta_0.Visible = true;
			// 
			// ID_CAM_GPO_LB
			// 
			this.ID_CAM_GPO_LB.AutoSize = true;
			this.ID_CAM_GPO_LB.BackColor = System.Drawing.SystemColors.Control;
			this.ID_CAM_GPO_LB.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ID_CAM_GPO_LB.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_CAM_GPO_LB.Enabled = true;
			this.ID_CAM_GPO_LB.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_CAM_GPO_LB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_CAM_GPO_LB.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_CAM_GPO_LB.Location = new System.Drawing.Point(410, 7);
			this.ID_CAM_GPO_LB.Name = "ID_CAM_GPO_LB";
			this.ID_CAM_GPO_LB.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_CAM_GPO_LB.Size = new System.Drawing.Size(43, 16);
			this.ID_CAM_GPO_LB.TabIndex = 5;
			this.ID_CAM_GPO_LB.Tag = "";
			this.ID_CAM_GPO_LB.Text = "Grupo";
			this.ID_CAM_GPO_LB.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ID_CAM_GPO_LB.UseMnemonic = true;
			this.ID_CAM_GPO_LB.Visible = true;
			// 
			// ID_CAM_MEN_LBL
			// 
			this.ID_CAM_MEN_LBL.AutoSize = true;
			this.ID_CAM_MEN_LBL.BackColor = System.Drawing.SystemColors.Control;
			this.ID_CAM_MEN_LBL.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.ID_CAM_MEN_LBL.Cursor = System.Windows.Forms.Cursors.Default;
			this.ID_CAM_MEN_LBL.Enabled = true;
			this.ID_CAM_MEN_LBL.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.ID_CAM_MEN_LBL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.ID_CAM_MEN_LBL.ForeColor = System.Drawing.SystemColors.ControlText;
			this.ID_CAM_MEN_LBL.Location = new System.Drawing.Point(481, 8);
			this.ID_CAM_MEN_LBL.Name = "ID_CAM_MEN_LBL";
			this.ID_CAM_MEN_LBL.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ID_CAM_MEN_LBL.Size = new System.Drawing.Size(60, 16);
			this.ID_CAM_MEN_LBL.TabIndex = 4;
			this.ID_CAM_MEN_LBL.Tag = "";
			this.ID_CAM_MEN_LBL.Text = "Mensaje";
			this.ID_CAM_MEN_LBL.TextAlign = System.Drawing.ContentAlignment.TopLeft;
			this.ID_CAM_MEN_LBL.UseMnemonic = true;
			this.ID_CAM_MEN_LBL.Visible = true;
			// 
			// frmAltaMasivaTH
			// 
			this.AcceptButton = this.cmdEnviar;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.SystemColors.Control;
			this.CancelButton = this.cmdArchivo;
			this.ClientSize = new System.Drawing.Size(663, 477);
			this.ControlBox = true;
			this.Controls.Add(this.sspPanel);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Enabled = true;
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
			this.HelpButton = false;
			this.KeyPreview = false;
			this.ListBoxComboBoxHelper1.SetItemData(this.lstLista, new int[]{0});
			this.Location = new System.Drawing.Point(4, 23);
			this.MaximizeBox = true;
			this.MinimizeBox = true;
			this.Name = "frmAltaMasivaTH";
			this.RightToLeft = System.Windows.Forms.RightToLeft.No;
			this.ShowInTaskbar = true;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Tag = "";
			this.Text = "Altas Masivas de Tarjetahabientes";
			this.WindowState = System.Windows.Forms.FormWindowState.Normal;
			base.Closed += new System.EventHandler(this.frmAltaMasivaTH_Closed);
			((System.ComponentModel.ISupportInitialize) this.ListBoxComboBoxHelper1).EndInit();
			((System.ComponentModel.ISupportInitialize) this.cdlDialogo).EndInit();
			((System.ComponentModel.ISupportInitialize) this.sspAvance).EndInit();
			((System.ComponentModel.ISupportInitialize) this.sspPanel).EndInit();
			this.sspPanel.ResumeLayout(false);
			this.picPicture.ResumeLayout(false);
			this.ResumeLayout(false);
	}
	void  InitializelblEtiqueta()
	{
			this.lblEtiqueta[1] = _lblEtiqueta_1;
			this.lblEtiqueta[0] = _lblEtiqueta_0;
	}
	void  InitializeID_CAM_CTA_LB()
	{
			this.ID_CAM_CTA_LB[1] = _ID_CAM_CTA_LB_1;
	}
#endregion 
}
}