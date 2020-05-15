using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class CORCTREN
	{
	
#region "Upgrade Support "
		private static CORCTREN m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static CORCTREN DefInstance
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
		public CORCTREN():base(){
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
            InitializeComponent(); //AIS-1213 echasiquiza
			isInitializingComponent = false;
			InitializeHelp();
			InitializeoptEmpresas();
			InitializeoptPeriodo();
			InitializelblPeriodo();
			InitializepnlEtiqueta();
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static CORCTREN CreateInstance()
	{
			CORCTREN theInstance = new CORCTREN();
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
	public System.Windows.Forms.Label[] lblPeriodo = new System.Windows.Forms.Label[2];
	public System.Windows.Forms.RadioButton[] optEmpresas = new System.Windows.Forms.RadioButton[6];
	public System.Windows.Forms.RadioButton[] optPeriodo = new System.Windows.Forms.RadioButton[2];
	public AxThreed.AxSSPanel[] pnlEtiqueta = new AxThreed.AxSSPanel[8];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.pnlPrincipal = new System.Windows.Forms.Panel();
        this.fraOptiones = new System.Windows.Forms.GroupBox();
        this._optEmpresas_5 = new System.Windows.Forms.RadioButton();
        this._optEmpresas_4 = new System.Windows.Forms.RadioButton();
        this._optEmpresas_3 = new System.Windows.Forms.RadioButton();
        this._optEmpresas_2 = new System.Windows.Forms.RadioButton();
        this._optEmpresas_1 = new System.Windows.Forms.RadioButton();
        this._optEmpresas_0 = new System.Windows.Forms.RadioButton();
        this.frmPeriodo = new System.Windows.Forms.GroupBox();
        this.txtMaxima = new System.Windows.Forms.TextBox();
        this.cboFechaFin = new System.Windows.Forms.ComboBox();
        this._lblPeriodo_1 = new System.Windows.Forms.Label();
        this.cboFecha = new System.Windows.Forms.ComboBox();
        this._lblPeriodo_0 = new System.Windows.Forms.Label();
        this._optPeriodo_0 = new System.Windows.Forms.RadioButton();
        this._optPeriodo_1 = new System.Windows.Forms.RadioButton();
        this._pnlEtiqueta_0Label_Text = new System.Windows.Forms.Label();
        this.cboGrupo = new System.Windows.Forms.ComboBox();
        this._pnlEtiqueta_7Label_Text = new System.Windows.Forms.Label();
        this._pnlEtiqueta_6Label_Text = new System.Windows.Forms.Label();
        this._pnlEtiqueta_2Label_Text = new System.Windows.Forms.Label();
        this._pnlEtiqueta_3Label_Text = new System.Windows.Forms.Label();
        this.lstEmpresas = new System.Windows.Forms.ListBox();
        this.lstSeleccion = new System.Windows.Forms.ListBox();
        this.cmdAll = new System.Windows.Forms.Button();
        this.cmdAdd = new System.Windows.Forms.Button();
        this.cmdDelAll = new System.Windows.Forms.Button();
        this.cmdDel = new System.Windows.Forms.Button();
        this.cmdCalcular = new System.Windows.Forms.Button();
        this.cmdSalir = new System.Windows.Forms.Button();
        this.pnlPrincipal.SuspendLayout();
        this.fraOptiones.SuspendLayout();
        this.frmPeriodo.SuspendLayout();
        this.SuspendLayout();
        // 
        // pnlPrincipal
        // 
        this.pnlPrincipal.Controls.Add(this._pnlEtiqueta_7Label_Text);
        this.pnlPrincipal.Location = new System.Drawing.Point(2, 5);
        this.pnlPrincipal.Name = "pnlPrincipal";
        this.pnlPrincipal.Size = new System.Drawing.Size(582, 389);
        this.pnlPrincipal.TabIndex = 8;
        this.pnlPrincipal.Tag = "";
        // 
        // fraOptiones
        // 
        this.fraOptiones.BackColor = System.Drawing.SystemColors.Control;
        this.fraOptiones.Controls.Add(this._optEmpresas_5);
        this.fraOptiones.Controls.Add(this._optEmpresas_4);
        this.fraOptiones.Controls.Add(this._optEmpresas_3);
        this.fraOptiones.Controls.Add(this._optEmpresas_2);
        this.fraOptiones.Controls.Add(this._optEmpresas_1);
        this.fraOptiones.Controls.Add(this._optEmpresas_0);
        this.fraOptiones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.fraOptiones.ForeColor = System.Drawing.SystemColors.ControlText;
        this.fraOptiones.Location = new System.Drawing.Point(16, 18);
        this.fraOptiones.Name = "fraOptiones";
        this.fraOptiones.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.fraOptiones.Size = new System.Drawing.Size(257, 115);
        this.fraOptiones.TabIndex = 11;
        this.fraOptiones.TabStop = false;
        this.fraOptiones.Tag = "";
        this.fraOptiones.Text = "Rentabilidad para";
        // 
        // _optEmpresas_5
        // 
        this._optEmpresas_5.BackColor = System.Drawing.SystemColors.Control;
        this._optEmpresas_5.Cursor = System.Windows.Forms.Cursors.Default;
        this._optEmpresas_5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._optEmpresas_5.ForeColor = System.Drawing.SystemColors.ControlText;
        this._optEmpresas_5.Location = new System.Drawing.Point(41, 92);
        this._optEmpresas_5.Name = "_optEmpresas_5";
        this._optEmpresas_5.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._optEmpresas_5.Size = new System.Drawing.Size(197, 15);
        this._optEmpresas_5.TabIndex = 35;
        this._optEmpresas_5.TabStop = true;
        this._optEmpresas_5.Tag = "";
        this._optEmpresas_5.Text = "Detalle a un rango de fechas";
        this._optEmpresas_5.UseVisualStyleBackColor = false;
        this._optEmpresas_5.CheckedChanged += new System.EventHandler(this.optEmpresas_CheckedChanged);
        // 
        // _optEmpresas_4
        // 
        this._optEmpresas_4.BackColor = System.Drawing.SystemColors.Control;
        this._optEmpresas_4.Cursor = System.Windows.Forms.Cursors.Default;
        this._optEmpresas_4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._optEmpresas_4.ForeColor = System.Drawing.SystemColors.ControlText;
        this._optEmpresas_4.Location = new System.Drawing.Point(41, 77);
        this._optEmpresas_4.Name = "_optEmpresas_4";
        this._optEmpresas_4.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._optEmpresas_4.Size = new System.Drawing.Size(146, 15);
        this._optEmpresas_4.TabIndex = 34;
        this._optEmpresas_4.TabStop = true;
        this._optEmpresas_4.Tag = "";
        this._optEmpresas_4.Text = "Detalle a una fecha";
        this._optEmpresas_4.UseVisualStyleBackColor = false;
        this._optEmpresas_4.CheckedChanged += new System.EventHandler(this.optEmpresas_CheckedChanged);
        // 
        // _optEmpresas_3
        // 
        this._optEmpresas_3.BackColor = System.Drawing.SystemColors.Control;
        this._optEmpresas_3.Cursor = System.Windows.Forms.Cursors.Default;
        this._optEmpresas_3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._optEmpresas_3.ForeColor = System.Drawing.SystemColors.ControlText;
        this._optEmpresas_3.Location = new System.Drawing.Point(41, 62);
        this._optEmpresas_3.Name = "_optEmpresas_3";
        this._optEmpresas_3.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._optEmpresas_3.Size = new System.Drawing.Size(146, 15);
        this._optEmpresas_3.TabIndex = 33;
        this._optEmpresas_3.TabStop = true;
        this._optEmpresas_3.Tag = "";
        this._optEmpresas_3.Text = "Una empresa";
        this._optEmpresas_3.UseVisualStyleBackColor = false;
        this._optEmpresas_3.CheckedChanged += new System.EventHandler(this.optEmpresas_CheckedChanged);
        // 
        // _optEmpresas_2
        // 
        this._optEmpresas_2.BackColor = System.Drawing.SystemColors.Control;
        this._optEmpresas_2.Cursor = System.Windows.Forms.Cursors.Default;
        this._optEmpresas_2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._optEmpresas_2.ForeColor = System.Drawing.SystemColors.ControlText;
        this._optEmpresas_2.Location = new System.Drawing.Point(41, 47);
        this._optEmpresas_2.Name = "_optEmpresas_2";
        this._optEmpresas_2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._optEmpresas_2.Size = new System.Drawing.Size(146, 16);
        this._optEmpresas_2.TabIndex = 32;
        this._optEmpresas_2.TabStop = true;
        this._optEmpresas_2.Tag = "";
        this._optEmpresas_2.Text = "Tope";
        this._optEmpresas_2.UseVisualStyleBackColor = false;
        this._optEmpresas_2.CheckedChanged += new System.EventHandler(this.optEmpresas_CheckedChanged);
        // 
        // _optEmpresas_1
        // 
        this._optEmpresas_1.BackColor = System.Drawing.SystemColors.Control;
        this._optEmpresas_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._optEmpresas_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._optEmpresas_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._optEmpresas_1.Location = new System.Drawing.Point(41, 32);
        this._optEmpresas_1.Name = "_optEmpresas_1";
        this._optEmpresas_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._optEmpresas_1.Size = new System.Drawing.Size(146, 15);
        this._optEmpresas_1.TabIndex = 31;
        this._optEmpresas_1.TabStop = true;
        this._optEmpresas_1.Tag = "";
        this._optEmpresas_1.Text = "Selección de Empresas";
        this._optEmpresas_1.UseVisualStyleBackColor = false;
        this._optEmpresas_1.CheckedChanged += new System.EventHandler(this.optEmpresas_CheckedChanged);
        // 
        // _optEmpresas_0
        // 
        this._optEmpresas_0.BackColor = System.Drawing.SystemColors.Control;
        this._optEmpresas_0.Checked = true;
        this._optEmpresas_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._optEmpresas_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._optEmpresas_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._optEmpresas_0.Location = new System.Drawing.Point(41, 17);
        this._optEmpresas_0.Name = "_optEmpresas_0";
        this._optEmpresas_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._optEmpresas_0.Size = new System.Drawing.Size(146, 15);
        this._optEmpresas_0.TabIndex = 30;
        this._optEmpresas_0.TabStop = true;
        this._optEmpresas_0.Tag = "";
        this._optEmpresas_0.Text = "Todas las empresas";
        this._optEmpresas_0.UseVisualStyleBackColor = false;
        this._optEmpresas_0.CheckedChanged += new System.EventHandler(this.optEmpresas_CheckedChanged);
        // 
        // frmPeriodo
        // 
        this.frmPeriodo.BackColor = System.Drawing.SystemColors.Control;
        this.frmPeriodo.Controls.Add(this.txtMaxima);
        this.frmPeriodo.Controls.Add(this.cboFechaFin);
        this.frmPeriodo.Controls.Add(this._lblPeriodo_1);
        this.frmPeriodo.Controls.Add(this.cboFecha);
        this.frmPeriodo.Controls.Add(this._lblPeriodo_0);
        this.frmPeriodo.Controls.Add(this._optPeriodo_0);
        this.frmPeriodo.Controls.Add(this._optPeriodo_1);
        this.frmPeriodo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.frmPeriodo.ForeColor = System.Drawing.SystemColors.ControlText;
        this.frmPeriodo.Location = new System.Drawing.Point(306, 18);
        this.frmPeriodo.Name = "frmPeriodo";
        this.frmPeriodo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.frmPeriodo.Size = new System.Drawing.Size(257, 118);
        this.frmPeriodo.TabIndex = 19;
        this.frmPeriodo.TabStop = false;
        this.frmPeriodo.Tag = "";
        this.frmPeriodo.Text = "Período";
        // 
        // txtMaxima
        // 
        this.txtMaxima.AcceptsReturn = true;
        this.txtMaxima.BackColor = System.Drawing.SystemColors.Window;
        this.txtMaxima.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtMaxima.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtMaxima.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtMaxima.Location = new System.Drawing.Point(114, 82);
        this.txtMaxima.MaxLength = 2;
        this.txtMaxima.Multiline = true;
        this.txtMaxima.Name = "txtMaxima";
        this.txtMaxima.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtMaxima.Size = new System.Drawing.Size(61, 20);
        this.txtMaxima.TabIndex = 34;
        this.txtMaxima.Tag = "";
        this.txtMaxima.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
        this.txtMaxima.Visible = false;
        this.txtMaxima.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxima_KeyPress);
        // 
        // cboFechaFin
        // 
        this.cboFechaFin.BackColor = System.Drawing.Color.White;
        this.cboFechaFin.Cursor = System.Windows.Forms.Cursors.Default;
        this.cboFechaFin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboFechaFin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cboFechaFin.ForeColor = System.Drawing.SystemColors.WindowText;
        this.cboFechaFin.Location = new System.Drawing.Point(114, 81);
        this.cboFechaFin.Name = "cboFechaFin";
        this.cboFechaFin.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cboFechaFin.Size = new System.Drawing.Size(126, 21);
        this.cboFechaFin.TabIndex = 33;
        this.cboFechaFin.Tag = "";
        // 
        // _lblPeriodo_1
        // 
        this._lblPeriodo_1.AutoSize = true;
        this._lblPeriodo_1.BackColor = System.Drawing.SystemColors.Control;
        this._lblPeriodo_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblPeriodo_1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblPeriodo_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblPeriodo_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblPeriodo_1.Location = new System.Drawing.Point(35, 86);
        this._lblPeriodo_1.Name = "_lblPeriodo_1";
        this._lblPeriodo_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblPeriodo_1.Size = new System.Drawing.Size(54, 13);
        this._lblPeriodo_1.TabIndex = 32;
        this._lblPeriodo_1.Tag = "";
        this._lblPeriodo_1.Text = "Fecha Fin";
        // 
        // cboFecha
        // 
        this.cboFecha.BackColor = System.Drawing.Color.White;
        this.cboFecha.Cursor = System.Windows.Forms.Cursors.Default;
        this.cboFecha.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cboFecha.ForeColor = System.Drawing.SystemColors.WindowText;
        this.cboFecha.Location = new System.Drawing.Point(114, 55);
        this.cboFecha.Name = "cboFecha";
        this.cboFecha.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cboFecha.Size = new System.Drawing.Size(126, 21);
        this.cboFecha.TabIndex = 31;
        this.cboFecha.Tag = "";
        // 
        // _lblPeriodo_0
        // 
        this._lblPeriodo_0.AutoSize = true;
        this._lblPeriodo_0.BackColor = System.Drawing.SystemColors.Control;
        this._lblPeriodo_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._lblPeriodo_0.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._lblPeriodo_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._lblPeriodo_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._lblPeriodo_0.Location = new System.Drawing.Point(35, 61);
        this._lblPeriodo_0.Name = "_lblPeriodo_0";
        this._lblPeriodo_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._lblPeriodo_0.Size = new System.Drawing.Size(40, 13);
        this._lblPeriodo_0.TabIndex = 30;
        this._lblPeriodo_0.Tag = "";
        this._lblPeriodo_0.Text = "Fecha:";
        // 
        // _optPeriodo_0
        // 
        this._optPeriodo_0.BackColor = System.Drawing.SystemColors.Control;
        this._optPeriodo_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._optPeriodo_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._optPeriodo_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._optPeriodo_0.Location = new System.Drawing.Point(32, 14);
        this._optPeriodo_0.Name = "_optPeriodo_0";
        this._optPeriodo_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._optPeriodo_0.Size = new System.Drawing.Size(185, 22);
        this._optPeriodo_0.TabIndex = 29;
        this._optPeriodo_0.TabStop = true;
        this._optPeriodo_0.Tag = "";
        this._optPeriodo_0.Text = "Período Fechas";
        this._optPeriodo_0.UseVisualStyleBackColor = false;
        this._optPeriodo_0.CheckedChanged += new System.EventHandler(this.optPeriodo_CheckedChanged);
        // 
        // _optPeriodo_1
        // 
        this._optPeriodo_1.BackColor = System.Drawing.SystemColors.Control;
        this._optPeriodo_1.Checked = true;
        this._optPeriodo_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._optPeriodo_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._optPeriodo_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._optPeriodo_1.Location = new System.Drawing.Point(32, 34);
        this._optPeriodo_1.Name = "_optPeriodo_1";
        this._optPeriodo_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._optPeriodo_1.Size = new System.Drawing.Size(185, 22);
        this._optPeriodo_1.TabIndex = 28;
        this._optPeriodo_1.TabStop = true;
        this._optPeriodo_1.Tag = "";
        this._optPeriodo_1.Text = "Fecha";
        this._optPeriodo_1.UseVisualStyleBackColor = false;
        this._optPeriodo_1.CheckedChanged += new System.EventHandler(this.optEmpresas_CheckedChanged);
        // 
        // _pnlEtiqueta_0Label_Text
        // 
        this._pnlEtiqueta_0Label_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._pnlEtiqueta_0Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._pnlEtiqueta_0Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._pnlEtiqueta_0Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
        this._pnlEtiqueta_0Label_Text.Location = new System.Drawing.Point(17, 136);
        this._pnlEtiqueta_0Label_Text.Name = "_pnlEtiqueta_0Label_Text";
        this._pnlEtiqueta_0Label_Text.Size = new System.Drawing.Size(44, 21);
        this._pnlEtiqueta_0Label_Text.TabIndex = 20;
        this._pnlEtiqueta_0Label_Text.Tag = "";
        this._pnlEtiqueta_0Label_Text.Text = " &Grupo";
        this._pnlEtiqueta_0Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
        // 
        // cboGrupo
        // 
        this.cboGrupo.BackColor = System.Drawing.Color.White;
        this.cboGrupo.Cursor = System.Windows.Forms.Cursors.Default;
        this.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        this.cboGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cboGrupo.ForeColor = System.Drawing.SystemColors.WindowText;
        this.cboGrupo.Location = new System.Drawing.Point(63, 136);
        this.cboGrupo.Name = "cboGrupo";
        this.cboGrupo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cboGrupo.Size = new System.Drawing.Size(210, 21);
        this.cboGrupo.Sorted = true;
        this.cboGrupo.TabIndex = 22;
        this.cboGrupo.Tag = "";
        this.cboGrupo.SelectedIndexChanged += new System.EventHandler(this.cboGrupo_SelectedIndexChanged);
        // 
        // _pnlEtiqueta_7Label_Text
        // 
        this._pnlEtiqueta_7Label_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._pnlEtiqueta_7Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._pnlEtiqueta_7Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._pnlEtiqueta_7Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
        this._pnlEtiqueta_7Label_Text.Location = new System.Drawing.Point(15, 155);
        this._pnlEtiqueta_7Label_Text.Name = "_pnlEtiqueta_7Label_Text";
        this._pnlEtiqueta_7Label_Text.Size = new System.Drawing.Size(49, 21);
        this._pnlEtiqueta_7Label_Text.TabIndex = 23;
        this._pnlEtiqueta_7Label_Text.Tag = "";
        this._pnlEtiqueta_7Label_Text.Text = "No.";
        this._pnlEtiqueta_7Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _pnlEtiqueta_6Label_Text
        // 
        this._pnlEtiqueta_6Label_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._pnlEtiqueta_6Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._pnlEtiqueta_6Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._pnlEtiqueta_6Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
        this._pnlEtiqueta_6Label_Text.Location = new System.Drawing.Point(69, 162);
        this._pnlEtiqueta_6Label_Text.Name = "_pnlEtiqueta_6Label_Text";
        this._pnlEtiqueta_6Label_Text.Size = new System.Drawing.Size(207, 21);
        this._pnlEtiqueta_6Label_Text.TabIndex = 25;
        this._pnlEtiqueta_6Label_Text.Tag = "";
        this._pnlEtiqueta_6Label_Text.Text = "&Empresa";
        this._pnlEtiqueta_6Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _pnlEtiqueta_2Label_Text
        // 
        this._pnlEtiqueta_2Label_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._pnlEtiqueta_2Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._pnlEtiqueta_2Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._pnlEtiqueta_2Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
        this._pnlEtiqueta_2Label_Text.Location = new System.Drawing.Point(311, 160);
        this._pnlEtiqueta_2Label_Text.Name = "_pnlEtiqueta_2Label_Text";
        this._pnlEtiqueta_2Label_Text.Size = new System.Drawing.Size(49, 21);
        this._pnlEtiqueta_2Label_Text.TabIndex = 27;
        this._pnlEtiqueta_2Label_Text.Tag = "";
        this._pnlEtiqueta_2Label_Text.Text = "No.";
        this._pnlEtiqueta_2Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // _pnlEtiqueta_3Label_Text
        // 
        this._pnlEtiqueta_3Label_Text.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
        this._pnlEtiqueta_3Label_Text.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this._pnlEtiqueta_3Label_Text.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._pnlEtiqueta_3Label_Text.ForeColor = System.Drawing.SystemColors.WindowText;
        this._pnlEtiqueta_3Label_Text.Location = new System.Drawing.Point(364, 160);
        this._pnlEtiqueta_3Label_Text.Name = "_pnlEtiqueta_3Label_Text";
        this._pnlEtiqueta_3Label_Text.Size = new System.Drawing.Size(200, 21);
        this._pnlEtiqueta_3Label_Text.TabIndex = 0;
        this._pnlEtiqueta_3Label_Text.Tag = "";
        this._pnlEtiqueta_3Label_Text.Text = "&Empresa";
        this._pnlEtiqueta_3Label_Text.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
        // 
        // lstEmpresas
        // 
        this.lstEmpresas.BackColor = System.Drawing.Color.White;
        this.lstEmpresas.Cursor = System.Windows.Forms.Cursors.Default;
        this.lstEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lstEmpresas.ForeColor = System.Drawing.SystemColors.WindowText;
        this.lstEmpresas.Location = new System.Drawing.Point(16, 186);
        this.lstEmpresas.Name = "lstEmpresas";
        this.lstEmpresas.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lstEmpresas.Size = new System.Drawing.Size(256, 160);
        this.lstEmpresas.Sorted = true;
        this.lstEmpresas.TabIndex = 31;
        this.lstEmpresas.Tag = "";
        this.lstEmpresas.DoubleClick += new System.EventHandler(this.lstEmpresas_DoubleClick);
        // 
        // lstSeleccion
        // 
        this.lstSeleccion.BackColor = System.Drawing.Color.White;
        this.lstSeleccion.Cursor = System.Windows.Forms.Cursors.Default;
        this.lstSeleccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.lstSeleccion.ForeColor = System.Drawing.SystemColors.WindowText;
        this.lstSeleccion.Location = new System.Drawing.Point(311, 186);
        this.lstSeleccion.Name = "lstSeleccion";
        this.lstSeleccion.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.lstSeleccion.Size = new System.Drawing.Size(253, 160);
        this.lstSeleccion.Sorted = true;
        this.lstSeleccion.TabIndex = 32;
        this.lstSeleccion.Tag = "";
        this.lstSeleccion.DoubleClick += new System.EventHandler(this.lstSeleccion_DoubleClick);
        // 
        // cmdAll
        // 
        this.cmdAll.BackColor = System.Drawing.SystemColors.Control;
        this.cmdAll.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdAll.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdAll.Location = new System.Drawing.Point(276, 196);
        this.cmdAll.Name = "cmdAll";
        this.cmdAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdAll.Size = new System.Drawing.Size(25, 25);
        this.cmdAll.TabIndex = 33;
        this.cmdAll.Tag = "";
        this.cmdAll.Text = ">>";
        this.cmdAll.UseVisualStyleBackColor = false;
        this.cmdAll.Click += new System.EventHandler(this.cmdAll_Click);
        // 
        // cmdAdd
        // 
        this.cmdAdd.BackColor = System.Drawing.SystemColors.Control;
        this.cmdAdd.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdAdd.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdAdd.Location = new System.Drawing.Point(276, 230);
        this.cmdAdd.Name = "cmdAdd";
        this.cmdAdd.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdAdd.Size = new System.Drawing.Size(25, 23);
        this.cmdAdd.TabIndex = 34;
        this.cmdAdd.Tag = "";
        this.cmdAdd.Text = ">";
        this.cmdAdd.UseVisualStyleBackColor = false;
        this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
        // 
        // cmdDelAll
        // 
        this.cmdDelAll.BackColor = System.Drawing.SystemColors.Control;
        this.cmdDelAll.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdDelAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdDelAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdDelAll.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdDelAll.Location = new System.Drawing.Point(276, 264);
        this.cmdDelAll.Name = "cmdDelAll";
        this.cmdDelAll.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdDelAll.Size = new System.Drawing.Size(25, 25);
        this.cmdDelAll.TabIndex = 35;
        this.cmdDelAll.Tag = "";
        this.cmdDelAll.Text = "<<";
        this.cmdDelAll.UseVisualStyleBackColor = false;
        this.cmdDelAll.Click += new System.EventHandler(this.cmdDelAll_Click);
        // 
        // cmdDel
        // 
        this.cmdDel.BackColor = System.Drawing.SystemColors.Control;
        this.cmdDel.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdDel.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdDel.Location = new System.Drawing.Point(276, 298);
        this.cmdDel.Name = "cmdDel";
        this.cmdDel.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdDel.Size = new System.Drawing.Size(25, 25);
        this.cmdDel.TabIndex = 36;
        this.cmdDel.Tag = "";
        this.cmdDel.Text = "<";
        this.cmdDel.UseVisualStyleBackColor = false;
        this.cmdDel.Click += new System.EventHandler(this.cmdDel_Click);
        // 
        // cmdCalcular
        // 
        this.cmdCalcular.BackColor = System.Drawing.SystemColors.Control;
        this.cmdCalcular.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdCalcular.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdCalcular.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdCalcular.Location = new System.Drawing.Point(209, 357);
        this.cmdCalcular.Name = "cmdCalcular";
        this.cmdCalcular.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdCalcular.Size = new System.Drawing.Size(81, 28);
        this.cmdCalcular.TabIndex = 37;
        this.cmdCalcular.Tag = "";
        this.cmdCalcular.Text = "&Calcular...";
        this.cmdCalcular.UseVisualStyleBackColor = false;
        this.cmdCalcular.Click += new System.EventHandler(this.cmdCalcular_Click);
        // 
        // cmdSalir
        // 
        this.cmdSalir.BackColor = System.Drawing.SystemColors.Control;
        this.cmdSalir.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.cmdSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdSalir.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdSalir.Location = new System.Drawing.Point(296, 360);
        this.cmdSalir.Name = "cmdSalir";
        this.cmdSalir.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdSalir.Size = new System.Drawing.Size(81, 26);
        this.cmdSalir.TabIndex = 38;
        this.cmdSalir.Tag = "";
        this.cmdSalir.Text = "&Salir";
        this.cmdSalir.UseVisualStyleBackColor = false;
        this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
        // 
        // CORCTREN
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.Color.Silver;
        this.ClientSize = new System.Drawing.Size(587, 398);
        this.Controls.Add(this.cmdSalir);
        this.Controls.Add(this.cmdCalcular);
        this.Controls.Add(this.cmdDel);
        this.Controls.Add(this.cmdDelAll);
        this.Controls.Add(this.cmdAdd);
        this.Controls.Add(this.cmdAll);
        this.Controls.Add(this.lstSeleccion);
        this.Controls.Add(this.lstEmpresas);
        this.Controls.Add(this._pnlEtiqueta_3Label_Text);
        this.Controls.Add(this._pnlEtiqueta_2Label_Text);
        this.Controls.Add(this._pnlEtiqueta_6Label_Text);
        this.Controls.Add(this.cboGrupo);
        this.Controls.Add(this._pnlEtiqueta_0Label_Text);
        this.Controls.Add(this.frmPeriodo);
        this.Controls.Add(this.fraOptiones);
        this.Controls.Add(this.pnlPrincipal);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(92, 166);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "CORCTREN";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
        this.Tag = "";
        this.Text = "Rentabilidad";
        this.Closed += new System.EventHandler(this.CORCTREN_Closed);
        this.pnlPrincipal.ResumeLayout(false);
        this.fraOptiones.ResumeLayout(false);
        this.frmPeriodo.ResumeLayout(false);
        this.frmPeriodo.PerformLayout();
        this.ResumeLayout(false);

	}
	void  InitializeoptEmpresas()
	{
			this.optEmpresas[5] = _optEmpresas_5;
			this.optEmpresas[4] = _optEmpresas_4;
			this.optEmpresas[3] = _optEmpresas_3;
			this.optEmpresas[2] = _optEmpresas_2;
			this.optEmpresas[1] = _optEmpresas_1;
			this.optEmpresas[0] = _optEmpresas_0;
	}
	void  InitializeoptPeriodo()
	{
			this.optPeriodo[1] = _optPeriodo_1;
			this.optPeriodo[0] = _optPeriodo_0;
	}
	void  InitializelblPeriodo()
	{
			this.lblPeriodo[1] = _lblPeriodo_1;
			this.lblPeriodo[0] = _lblPeriodo_0;
	}
	void  InitializepnlEtiqueta()
	{
			/*this.pnlEtiqueta[0] = _pnlEtiqueta_0;
			this.pnlEtiqueta[7] = _pnlEtiqueta_7;
			this.pnlEtiqueta[6] = _pnlEtiqueta_6;
			this.pnlEtiqueta[2] = _pnlEtiqueta_2;
			this.pnlEtiqueta[3] = _pnlEtiqueta_3;*/
	}
#endregion 

        public System.Windows.Forms.Panel pnlPrincipal;
        public System.Windows.Forms.GroupBox fraOptiones;
        private System.Windows.Forms.RadioButton _optEmpresas_5;
        private System.Windows.Forms.RadioButton _optEmpresas_4;
        private System.Windows.Forms.RadioButton _optEmpresas_3;
        private System.Windows.Forms.RadioButton _optEmpresas_2;
        private System.Windows.Forms.RadioButton _optEmpresas_1;
        private System.Windows.Forms.RadioButton _optEmpresas_0;
        public System.Windows.Forms.GroupBox frmPeriodo;
        public System.Windows.Forms.TextBox txtMaxima;
        public System.Windows.Forms.ComboBox cboFechaFin;
        private System.Windows.Forms.Label _lblPeriodo_1;
        public System.Windows.Forms.ComboBox cboFecha;
        private System.Windows.Forms.Label _lblPeriodo_0;
        private System.Windows.Forms.RadioButton _optPeriodo_0;
        private System.Windows.Forms.RadioButton _optPeriodo_1;
        private System.Windows.Forms.Label _pnlEtiqueta_0Label_Text;
        private AxThreed.AxSSPanel _pnlEtiqueta_0;
        public System.Windows.Forms.ComboBox cboGrupo;
        private System.Windows.Forms.Label _pnlEtiqueta_7Label_Text;
        private AxThreed.AxSSPanel _pnlEtiqueta_7;
        private System.Windows.Forms.Label _pnlEtiqueta_6Label_Text;
        private AxThreed.AxSSPanel _pnlEtiqueta_6;
        private System.Windows.Forms.Label _pnlEtiqueta_2Label_Text;
        private AxThreed.AxSSPanel _pnlEtiqueta_2;
        private System.Windows.Forms.Label _pnlEtiqueta_3Label_Text;
        private AxThreed.AxSSPanel _pnlEtiqueta_3;
        public System.Windows.Forms.ListBox lstEmpresas;
        public System.Windows.Forms.ListBox lstSeleccion;
        public System.Windows.Forms.Button cmdAll;
        public System.Windows.Forms.Button cmdAdd;
        public System.Windows.Forms.Button cmdDelAll;
        public System.Windows.Forms.Button cmdDel;
        public System.Windows.Forms.Button cmdCalcular;
        public System.Windows.Forms.Button cmdSalir;
}
}