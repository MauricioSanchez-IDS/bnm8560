using System; 
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCd430
{
	partial class frm_CCFSeleccion
	{
	
#region "Upgrade Support "
		private static frm_CCFSeleccion m_vb6FormDefInstance;
		private static bool m_InitializingDefInstance;
		public static frm_CCFSeleccion DefInstance
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
		public frm_CCFSeleccion():base(){
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
            InitializeComponent();//AIS-1213 echasiquiza
			InitializeHelp();
		}
	public static frm_CCFSeleccion CreateInstance()
	{
			frm_CCFSeleccion theInstance = new frm_CCFSeleccion();
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
	public  System.Windows.Forms.Button Command2;
	public  System.Windows.Forms.Button Command1;
	public  System.Windows.Forms.GroupBox fmr_boton;
	public  System.Windows.Forms.RadioButton opt_SBFc;
	public  System.Windows.Forms.RadioButton opt_SBF;
	public  System.Windows.Forms.RadioButton opt_CCF;
	public  System.Windows.Forms.GroupBox fmr_Envios;
	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.
	//Do not modify it using the code editor.
	[System.Diagnostics.DebuggerStepThrough]
	 private void  InitializeComponent()
	{
        this.components = new System.ComponentModel.Container();
        this.ToolTip1 = new System.Windows.Forms.ToolTip(this.components);
        this.fmr_boton = new System.Windows.Forms.GroupBox();
        this.Command2 = new System.Windows.Forms.Button();
        this.Command1 = new System.Windows.Forms.Button();
        this.fmr_Envios = new System.Windows.Forms.GroupBox();
        this.opt_SBFc = new System.Windows.Forms.RadioButton();
        this.opt_CCF = new System.Windows.Forms.RadioButton();
        this.opt_SBF = new System.Windows.Forms.RadioButton();
        this.fmr_boton.SuspendLayout();
        this.fmr_Envios.SuspendLayout();
        this.SuspendLayout();
        // 
        // fmr_boton
        // 
        this.fmr_boton.BackColor = System.Drawing.SystemColors.Control;
        this.fmr_boton.Controls.Add(this.Command2);
        this.fmr_boton.Controls.Add(this.Command1);
        this.fmr_boton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.fmr_boton.ForeColor = System.Drawing.SystemColors.ControlText;
        this.fmr_boton.Location = new System.Drawing.Point(6, 158);
        this.fmr_boton.Name = "fmr_boton";
        this.fmr_boton.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.fmr_boton.Size = new System.Drawing.Size(265, 51);
        this.fmr_boton.TabIndex = 4;
        this.fmr_boton.TabStop = false;
        this.fmr_boton.Tag = "";
        // 
        // Command2
        // 
        this.Command2.BackColor = System.Drawing.SystemColors.Control;
        this.Command2.Cursor = System.Windows.Forms.Cursors.Default;
        this.Command2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        this.Command2.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.Command2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Command2.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Command2.Location = new System.Drawing.Point(138, 18);
        this.Command2.Name = "Command2";
        this.Command2.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Command2.Size = new System.Drawing.Size(117, 27);
        this.Command2.TabIndex = 6;
        this.Command2.Tag = "";
        this.Command2.Text = "Cancelar";
        this.Command2.UseVisualStyleBackColor = false;
        this.Command2.Click += new System.EventHandler(this.Command2_Click);
        // 
        // Command1
        // 
        this.Command1.BackColor = System.Drawing.SystemColors.Control;
        this.Command1.Cursor = System.Windows.Forms.Cursors.Default;
        this.Command1.FlatStyle = System.Windows.Forms.FlatStyle.System;
        this.Command1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.Command1.ForeColor = System.Drawing.SystemColors.ControlText;
        this.Command1.Location = new System.Drawing.Point(18, 16);
        this.Command1.Name = "Command1";
        this.Command1.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.Command1.Size = new System.Drawing.Size(97, 29);
        this.Command1.TabIndex = 5;
        this.Command1.Tag = "";
        this.Command1.Text = "Aceptar";
        this.Command1.UseVisualStyleBackColor = false;
        this.Command1.Click += new System.EventHandler(this.Command1_Click);
        // 
        // fmr_Envios
        // 
        this.fmr_Envios.BackColor = System.Drawing.SystemColors.Control;
        this.fmr_Envios.Controls.Add(this.opt_SBFc);
        this.fmr_Envios.Controls.Add(this.opt_CCF);
        this.fmr_Envios.Controls.Add(this.opt_SBF);
        this.fmr_Envios.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.fmr_Envios.ForeColor = System.Drawing.SystemColors.ControlText;
        this.fmr_Envios.Location = new System.Drawing.Point(8, 10);
        this.fmr_Envios.Name = "fmr_Envios";
        this.fmr_Envios.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.fmr_Envios.Size = new System.Drawing.Size(259, 137);
        this.fmr_Envios.TabIndex = 0;
        this.fmr_Envios.TabStop = false;
        this.fmr_Envios.Tag = "";
        this.fmr_Envios.Text = "Envios...";
        // 
        // opt_SBFc
        // 
        this.opt_SBFc.BackColor = System.Drawing.SystemColors.Control;
        this.opt_SBFc.Cursor = System.Windows.Forms.Cursors.Default;
        this.opt_SBFc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.opt_SBFc.ForeColor = System.Drawing.SystemColors.ControlText;
        this.opt_SBFc.Location = new System.Drawing.Point(24, 96);
        this.opt_SBFc.Name = "opt_SBFc";
        this.opt_SBFc.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.opt_SBFc.Size = new System.Drawing.Size(93, 23);
        this.opt_SBFc.TabIndex = 3;
        this.opt_SBFc.TabStop = true;
        this.opt_SBFc.Tag = "";
        this.opt_SBFc.Text = "SBF Corte";
        this.opt_SBFc.UseVisualStyleBackColor = false;
        // 
        // opt_CCF
        // 
        this.opt_CCF.BackColor = System.Drawing.SystemColors.Control;
        this.opt_CCF.Checked = true;
        this.opt_CCF.Cursor = System.Windows.Forms.Cursors.Default;
        this.opt_CCF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.opt_CCF.ForeColor = System.Drawing.SystemColors.ControlText;
        this.opt_CCF.Location = new System.Drawing.Point(24, 34);
        this.opt_CCF.Name = "opt_CCF";
        this.opt_CCF.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.opt_CCF.Size = new System.Drawing.Size(83, 17);
        this.opt_CCF.TabIndex = 1;
        this.opt_CCF.TabStop = true;
        this.opt_CCF.Tag = "";
        this.opt_CCF.Text = "CCF Diaro";
        this.opt_CCF.UseVisualStyleBackColor = false;
        // 
        // opt_SBF
        // 
        this.opt_SBF.BackColor = System.Drawing.SystemColors.Control;
        this.opt_SBF.Cursor = System.Windows.Forms.Cursors.Default;
        this.opt_SBF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.opt_SBF.ForeColor = System.Drawing.SystemColors.ControlText;
        this.opt_SBF.Location = new System.Drawing.Point(24, 64);
        this.opt_SBF.Name = "opt_SBF";
        this.opt_SBF.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.opt_SBF.Size = new System.Drawing.Size(91, 23);
        this.opt_SBF.TabIndex = 2;
        this.opt_SBF.TabStop = true;
        this.opt_SBF.Tag = "";
        this.opt_SBF.Text = "SBF Diario";
        this.opt_SBF.UseVisualStyleBackColor = false;
        // 
        // frm_CCFSeleccion
        // 
        this.AcceptButton = this.Command1;
        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.BackColor = System.Drawing.SystemColors.Control;
        this.CancelButton = this.Command2;
        this.ClientSize = new System.Drawing.Size(277, 214);
        this.Controls.Add(this.fmr_Envios);
        this.Controls.Add(this.fmr_boton);
        this.Cursor = System.Windows.Forms.Cursors.Default;
        this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        this.Location = new System.Drawing.Point(3, 22);
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frm_CCFSeleccion";
        this.RightToLeft = System.Windows.Forms.RightToLeft.No;
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
        this.Tag = "";
        this.Text = "Seleccione el tipo de Operación a Realizar";
        this.fmr_boton.ResumeLayout(false);
        this.fmr_Envios.ResumeLayout(false);
        this.ResumeLayout(false);

	}
#endregion 
}
}