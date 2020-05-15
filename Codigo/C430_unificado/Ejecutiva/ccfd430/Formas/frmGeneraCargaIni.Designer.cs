using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class frmGeneraCargaIni
	{
	
#region "Upgrade Support "
		private static frmGeneraCargaIni m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frmGeneraCargaIni DefInstance
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
		public frmGeneraCargaIni():base(){
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
			InitializeoptOption();
		}
	public static frmGeneraCargaIni CreateInstance()
	{
			frmGeneraCargaIni theInstance = new frmGeneraCargaIni();
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
	private  System.Windows.Forms.RadioButton _optOption_1;
	private  System.Windows.Forms.RadioButton _optOption_0;
	public  System.Windows.Forms.Button cmdBoton;
	public  System.Windows.Forms.TextBox txtArchivo;
	public System.Windows.Forms.RadioButton[] optOption = new System.Windows.Forms.RadioButton[2];
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this._optOption_1 = new System.Windows.Forms.RadioButton();
        this._optOption_0 = new System.Windows.Forms.RadioButton();
        this.cmdBoton = new System.Windows.Forms.Button();
        this.txtArchivo = new System.Windows.Forms.TextBox();
        this.SuspendLayout();
        // 
        // _optOption_1
        // 
        this._optOption_1.BackColor = System.Drawing.SystemColors.Control;
        this._optOption_1.Cursor = System.Windows.Forms.Cursors.Default;
        this._optOption_1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._optOption_1.ForeColor = System.Drawing.SystemColors.ControlText;
        this._optOption_1.Location = new System.Drawing.Point(189, 12);
        this._optOption_1.Name = "_optOption_1";
        this._optOption_1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._optOption_1.Size = new System.Drawing.Size(121, 22);
        this._optOption_1.TabIndex = 3;
        this._optOption_1.TabStop = true;
        this._optOption_1.Tag = "";
        this._optOption_1.Text = "Relación de Cuentas ";
        this._optOption_1.UseVisualStyleBackColor = false;
        // 
        // _optOption_0
        // 
        this._optOption_0.BackColor = System.Drawing.SystemColors.Control;
        this._optOption_0.Cursor = System.Windows.Forms.Cursors.Default;
        this._optOption_0.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this._optOption_0.ForeColor = System.Drawing.SystemColors.ControlText;
        this._optOption_0.Location = new System.Drawing.Point(24, 12);
        this._optOption_0.Name = "_optOption_0";
        this._optOption_0.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this._optOption_0.Size = new System.Drawing.Size(136, 22);
        this._optOption_0.TabIndex = 2;
        this._optOption_0.TabStop = true;
        this._optOption_0.Tag = "";
        this._optOption_0.Text = "Cuentas Corporativas";
        this._optOption_0.UseVisualStyleBackColor = false;
        // 
        // cmdBoton
        // 
        this.cmdBoton.BackColor = System.Drawing.SystemColors.Control;
        this.cmdBoton.Cursor = System.Windows.Forms.Cursors.Default;
        this.cmdBoton.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.cmdBoton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.cmdBoton.ForeColor = System.Drawing.SystemColors.ControlText;
        this.cmdBoton.Location = new System.Drawing.Point(324, 42);
        this.cmdBoton.Name = "cmdBoton";
        this.cmdBoton.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.cmdBoton.Size = new System.Drawing.Size(82, 22);
        this.cmdBoton.TabIndex = 1;
        this.cmdBoton.Tag = "";
        this.cmdBoton.Text = "&Generar";
        this.cmdBoton.UseVisualStyleBackColor = false;
        this.cmdBoton.Click += new System.EventHandler(this.cmdBoton_Click);
        // 
        // txtArchivo
        // 
        this.txtArchivo.AcceptsReturn = true;
        this.txtArchivo.BackColor = System.Drawing.SystemColors.Window;
        this.txtArchivo.Cursor = System.Windows.Forms.Cursors.IBeam;
        this.txtArchivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.txtArchivo.ForeColor = System.Drawing.SystemColors.WindowText;
        this.txtArchivo.Location = new System.Drawing.Point(24, 42);
        this.txtArchivo.MaxLength = 0;
        this.txtArchivo.Name = "txtArchivo";
        this.txtArchivo.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.txtArchivo.Size = new System.Drawing.Size(286, 22);
        this.txtArchivo.TabIndex = 0;
        this.txtArchivo.Tag = "";
        // 
        // frmGeneraCargaIni
        // 
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.ClientSize = new System.Drawing.Size(419, 81);
        this.Controls.Add(this._optOption_1);
        this.Controls.Add(this.txtArchivo);
        this.Controls.Add(this.cmdBoton);
        this.Controls.Add(this._optOption_0);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        this.Location = new System.Drawing.Point(3, 19);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmGeneraCargaIni";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.Tag = "";
        this.Text = "Generación de Archivos";
        this.ResumeLayout(false);

	}
	void  InitializeoptOption()
	{
			this.optOption[1] = _optOption_1;
			this.optOption[0] = _optOption_0;
	}
#endregion 
}
}