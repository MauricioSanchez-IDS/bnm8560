using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class MTCBRCCI
	{
	
#region "Upgrade Support "
		private static MTCBRCCI m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static MTCBRCCI DefInstance
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
		public MTCBRCCI():base(){
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
			//This form is an MDI child.
			//This code simulates the VB6 
			// functionality of automatically
			// loading and showing an MDI
			// child's parent.
			this.MdiParent = TCd430.CORMDIBN.DefInstance;
			TCd430.CORMDIBN.DefInstance.Show();
		}
	public static MTCBRCCI CreateInstance()
	{
			MTCBRCCI theInstance = new MTCBRCCI();
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
	public  System.Windows.Forms.CheckBox chkTodGrp;
	public  System.Windows.Forms.CheckBox chkTodEmp;
	public  System.Windows.Forms.ListBox lstEmpresas;
	public  System.Windows.Forms.ComboBox cboGrupo;
	public  System.Windows.Forms.Label SSPanel2;
        public System.Windows.Forms.Label SSPanel3;
        public System.Windows.Forms.Label SSPanel4;
	public  System.Windows.Forms.GroupBox SSFrame1;
	public  System.Windows.Forms.ListBox lstReportes;
        public System.Windows.Forms.Label SSPanel1;
        public System.Windows.Forms.Label SSPanel5;
        public System.Windows.Forms.Label SSPanel6;
	public  System.Windows.Forms.GroupBox SSFrame2;
	public  System.Windows.Forms.Button cmdNoGen;
	public  System.Windows.Forms.Button cmdSalir;
	public  System.Windows.Forms.Button cmdAceptar;
	public  System.Windows.Forms.Panel pnlPrincipal;
	private Artinsoft.VB6.Gui.ListBoxHelper listBoxHelper;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
            this.components = new System.ComponentModel.Container();
            this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlPrincipal = new System.Windows.Forms.Panel();
            this.cmdNoGen = new System.Windows.Forms.Button();
            this.SSFrame2 = new System.Windows.Forms.GroupBox();
            this.SSPanel1 = new System.Windows.Forms.Label();
            this.lstReportes = new System.Windows.Forms.ListBox();
            this.SSPanel6 = new System.Windows.Forms.Label();
            this.SSPanel5 = new System.Windows.Forms.Label();
            this.SSFrame1 = new System.Windows.Forms.GroupBox();
            this.lstEmpresas = new System.Windows.Forms.ListBox();
            this.cboGrupo = new System.Windows.Forms.ComboBox();
            this.chkTodEmp = new System.Windows.Forms.CheckBox();
            this.chkTodGrp = new System.Windows.Forms.CheckBox();
            this.SSPanel3 = new System.Windows.Forms.Label();
            this.SSPanel4 = new System.Windows.Forms.Label();
            this.SSPanel2 = new System.Windows.Forms.Label();
            this.cmdAceptar = new System.Windows.Forms.Button();
            this.cmdSalir = new System.Windows.Forms.Button();
            this.listBoxHelper = new Artinsoft.VB6.Gui.ListBoxHelper(this.components);
            this.pnlPrincipal.SuspendLayout();
            this.SSFrame2.SuspendLayout();
            this.SSFrame1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlPrincipal
            // 
            this.pnlPrincipal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrincipal.Controls.Add(this.cmdNoGen);
            this.pnlPrincipal.Controls.Add(this.SSFrame2);
            this.pnlPrincipal.Controls.Add(this.SSFrame1);
            this.pnlPrincipal.Controls.Add(this.cmdAceptar);
            this.pnlPrincipal.Controls.Add(this.cmdSalir);
            this.pnlPrincipal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPrincipal.Location = new System.Drawing.Point(0, 8);
            this.pnlPrincipal.Name = "pnlPrincipal";
            this.pnlPrincipal.Size = new System.Drawing.Size(530, 368);
            this.pnlPrincipal.TabIndex = 0;
            this.pnlPrincipal.Tag = "";
            // 
            // cmdNoGen
            // 
            this.cmdNoGen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdNoGen.Location = new System.Drawing.Point(207, 335);
            this.cmdNoGen.Name = "cmdNoGen";
            this.cmdNoGen.Size = new System.Drawing.Size(87, 26);
            this.cmdNoGen.TabIndex = 16;
            this.cmdNoGen.Tag = "";
            this.cmdNoGen.Text = "NO generar";
            this.cmdNoGen.Click += new System.EventHandler(this.cmdNoGen_Click);
            // 
            // SSFrame2
            // 
            this.SSFrame2.Controls.Add(this.SSPanel1);
            this.SSFrame2.Controls.Add(this.lstReportes);
            this.SSFrame2.Controls.Add(this.SSPanel6);
            this.SSFrame2.Controls.Add(this.SSPanel5);
            this.SSFrame2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSFrame2.Location = new System.Drawing.Point(13, 197);
            this.SSFrame2.Name = "SSFrame2";
            this.SSFrame2.Size = new System.Drawing.Size(506, 132);
            this.SSFrame2.TabIndex = 11;
            this.SSFrame2.TabStop = false;
            this.SSFrame2.Tag = "";
            this.SSFrame2.Text = "Seleccione los reportes que se deberán o no generar a través del CCI:";
            // 
            // SSPanel1
            // 
            this.SSPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.SSPanel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SSPanel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSPanel1.Location = new System.Drawing.Point(11, 25);
            this.SSPanel1.Name = "SSPanel1";
            this.SSPanel1.Size = new System.Drawing.Size(49, 21);
            this.SSPanel1.TabIndex = 13;
            this.SSPanel1.Tag = "";
            this.SSPanel1.Text = "No.";
            // 
            // lstReportes
            // 
            this.lstReportes.BackColor = System.Drawing.Color.White;
            this.lstReportes.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstReportes.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.lstReportes.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstReportes.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstReportes.Location = new System.Drawing.Point(10, 46);
            this.lstReportes.Name = "lstReportes";
            this.lstReportes.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBoxHelper.SetSelectionMode(this.lstReportes, System.Windows.Forms.SelectionMode.MultiSimple);
            this.lstReportes.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lstReportes.Size = new System.Drawing.Size(469, 69);
            this.lstReportes.TabIndex = 12;
            this.lstReportes.Tag = "";
            // 
            // SSPanel6
            // 
            this.SSPanel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.SSPanel6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SSPanel6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSPanel6.Location = new System.Drawing.Point(378, 25);
            this.SSPanel6.Name = "SSPanel6";
            this.SSPanel6.Size = new System.Drawing.Size(101, 22);
            this.SSPanel6.TabIndex = 15;
            this.SSPanel6.Tag = "";
            this.SSPanel6.Text = "Generar reporte:";
            // 
            // SSPanel5
            // 
            this.SSPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.SSPanel5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SSPanel5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSPanel5.Location = new System.Drawing.Point(60, 25);
            this.SSPanel5.Name = "SSPanel5";
            this.SSPanel5.Size = new System.Drawing.Size(318, 21);
            this.SSPanel5.TabIndex = 14;
            this.SSPanel5.Tag = "";
            this.SSPanel5.Text = "Reportes";
            this.SSPanel5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // SSFrame1
            // 
            this.SSFrame1.Controls.Add(this.lstEmpresas);
            this.SSFrame1.Controls.Add(this.cboGrupo);
            this.SSFrame1.Controls.Add(this.chkTodEmp);
            this.SSFrame1.Controls.Add(this.chkTodGrp);
            this.SSFrame1.Controls.Add(this.SSPanel3);
            this.SSFrame1.Controls.Add(this.SSPanel4);
            this.SSFrame1.Controls.Add(this.SSPanel2);
            this.SSFrame1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSFrame1.Location = new System.Drawing.Point(13, 4);
            this.SSFrame1.Name = "SSFrame1";
            this.SSFrame1.Size = new System.Drawing.Size(506, 183);
            this.SSFrame1.TabIndex = 3;
            this.SSFrame1.TabStop = false;
            this.SSFrame1.Tag = "";
            this.SSFrame1.Text = "Seleccione las empresas:";
            // 
            // lstEmpresas
            // 
            this.lstEmpresas.BackColor = System.Drawing.Color.White;
            this.lstEmpresas.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstEmpresas.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstEmpresas.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lstEmpresas.Location = new System.Drawing.Point(17, 75);
            this.lstEmpresas.Name = "lstEmpresas";
            this.lstEmpresas.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.listBoxHelper.SetSelectionMode(this.lstEmpresas, System.Windows.Forms.SelectionMode.One);
            this.lstEmpresas.Size = new System.Drawing.Size(275, 95);
            this.lstEmpresas.TabIndex = 8;
            this.lstEmpresas.Tag = "";
            this.lstEmpresas.SelectedIndexChanged += new System.EventHandler(this.lstEmpresas_SelectedIndexChanged);
            // 
            // cboGrupo
            // 
            this.cboGrupo.BackColor = System.Drawing.Color.White;
            this.cboGrupo.Cursor = System.Windows.Forms.Cursors.Default;
            this.cboGrupo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboGrupo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboGrupo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cboGrupo.Location = new System.Drawing.Point(68, 28);
            this.cboGrupo.Name = "cboGrupo";
            this.cboGrupo.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.cboGrupo.Size = new System.Drawing.Size(223, 21);
            this.cboGrupo.TabIndex = 4;
            this.cboGrupo.Tag = "";
            this.cboGrupo.SelectedIndexChanged += new System.EventHandler(this.cboGrupo_SelectedIndexChanged);
            // 
            // chkTodEmp
            // 
            this.chkTodEmp.BackColor = System.Drawing.SystemColors.Control;
            this.chkTodEmp.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkTodEmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodEmp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkTodEmp.Location = new System.Drawing.Point(309, 11);
            this.chkTodEmp.Name = "chkTodEmp";
            this.chkTodEmp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTodEmp.Size = new System.Drawing.Size(169, 18);
            this.chkTodEmp.TabIndex = 9;
            this.chkTodEmp.Tag = "";
            this.chkTodEmp.Text = "Todas las Empresas";
            this.chkTodEmp.UseVisualStyleBackColor = false;
            this.chkTodEmp.CheckStateChanged += new System.EventHandler(this.chkTodEmp_CheckStateChanged);
            // 
            // chkTodGrp
            // 
            this.chkTodGrp.BackColor = System.Drawing.SystemColors.Control;
            this.chkTodGrp.Cursor = System.Windows.Forms.Cursors.Default;
            this.chkTodGrp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTodGrp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkTodGrp.Location = new System.Drawing.Point(309, 33);
            this.chkTodGrp.Name = "chkTodGrp";
            this.chkTodGrp.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTodGrp.Size = new System.Drawing.Size(180, 17);
            this.chkTodGrp.TabIndex = 10;
            this.chkTodGrp.Tag = "";
            this.chkTodGrp.Text = "Todas las empresas del Grupo";
            this.chkTodGrp.UseVisualStyleBackColor = false;
            this.chkTodGrp.CheckStateChanged += new System.EventHandler(this.chkTodGrp_CheckStateChanged);
            // 
            // SSPanel3
            // 
            this.SSPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.SSPanel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SSPanel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSPanel3.Location = new System.Drawing.Point(17, 55);
            this.SSPanel3.Name = "SSPanel3";
            this.SSPanel3.Size = new System.Drawing.Size(53, 21);
            this.SSPanel3.TabIndex = 6;
            this.SSPanel3.Tag = "";
            this.SSPanel3.Text = "No.";
            this.SSPanel3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SSPanel4
            // 
            this.SSPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.SSPanel4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SSPanel4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSPanel4.Location = new System.Drawing.Point(71, 55);
            this.SSPanel4.Name = "SSPanel4";
            this.SSPanel4.Size = new System.Drawing.Size(220, 21);
            this.SSPanel4.TabIndex = 7;
            this.SSPanel4.Tag = "";
            this.SSPanel4.Text = "Empresa";
            this.SSPanel4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SSPanel2
            // 
            this.SSPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.SSPanel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SSPanel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SSPanel2.Location = new System.Drawing.Point(18, 29);
            this.SSPanel2.Name = "SSPanel2";
            this.SSPanel2.Size = new System.Drawing.Size(53, 21);
            this.SSPanel2.TabIndex = 5;
            this.SSPanel2.Tag = "";
            this.SSPanel2.Text = "Grupo";
            // 
            // cmdAceptar
            // 
            this.cmdAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdAceptar.Location = new System.Drawing.Point(305, 335);
            this.cmdAceptar.Name = "cmdAceptar";
            this.cmdAceptar.Size = new System.Drawing.Size(87, 26);
            this.cmdAceptar.TabIndex = 1;
            this.cmdAceptar.Tag = "";
            this.cmdAceptar.Text = "SI generar";
            this.cmdAceptar.Click += new System.EventHandler(this.cmdAceptar_Click);
            // 
            // cmdSalir
            // 
            this.cmdSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdSalir.Location = new System.Drawing.Point(403, 335);
            this.cmdSalir.Name = "cmdSalir";
            this.cmdSalir.Size = new System.Drawing.Size(88, 26);
            this.cmdSalir.TabIndex = 2;
            this.cmdSalir.Tag = "";
            this.cmdSalir.Text = "Salir";
            this.cmdSalir.Click += new System.EventHandler(this.cmdSalir_Click);
            // 
            // MTCBRCCI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(532, 373);
            this.Controls.Add(this.pnlPrincipal);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Location = new System.Drawing.Point(103, 129);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MTCBRCCI";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Activación y desactivación de reportes en el CCI";
            this.pnlPrincipal.ResumeLayout(false);
            this.SSFrame2.ResumeLayout(false);
            this.SSFrame1.ResumeLayout(false);
            this.ResumeLayout(false);

	}
#endregion 
}
}