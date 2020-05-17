using System;
using VB6 = Microsoft.VisualBasic.Compatibility.VB6.Support; 

namespace TCc430
{
    partial class frmLogin
    {
        #region "Upgrade Support "
        private static frmLogin m_vb6FormDefInstance;
        private static bool m_InitializingDefInstance;
        public static frmLogin DefInstance
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
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// 
public frmLogin():base(){
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
	public static frmLogin CreateInstance()
	{
			frmLogin theInstance = new frmLogin();
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
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.panel1 = new System.Windows.Forms.Panel();
            this.ID_ACC_CAN_PB = new System.Windows.Forms.Button();
            this.ID_ACC_ACE_PB = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ID_ACC_TOKEN_EB = new System.Windows.Forms.TextBox();
            this.ID_ACC_CVE_EB = new System.Windows.Forms.TextBox();
            this.ID_ACC_USU_EB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ID_ACC_BAN_COB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.ID_ACC_CAN_PB);
            this.panel1.Controls.Add(this.ID_ACC_ACE_PB);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(337, 299);
            this.panel1.TabIndex = 3;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // ID_ACC_CAN_PB
            // 
            this.ID_ACC_CAN_PB.Location = new System.Drawing.Point(184, 264);
            this.ID_ACC_CAN_PB.Name = "ID_ACC_CAN_PB";
            this.ID_ACC_CAN_PB.Size = new System.Drawing.Size(80, 26);
            this.ID_ACC_CAN_PB.TabIndex = 6;
            this.ID_ACC_CAN_PB.Text = "Cancelar.";
            this.ID_ACC_CAN_PB.UseVisualStyleBackColor = true;
            this.ID_ACC_CAN_PB.Click += new System.EventHandler(this.ID_ACC_CAN_PB_Click);
            // 
            // ID_ACC_ACE_PB
            // 
            this.ID_ACC_ACE_PB.Location = new System.Drawing.Point(67, 264);
            this.ID_ACC_ACE_PB.Name = "ID_ACC_ACE_PB";
            this.ID_ACC_ACE_PB.Size = new System.Drawing.Size(80, 26);
            this.ID_ACC_ACE_PB.TabIndex = 5;
            this.ID_ACC_ACE_PB.Text = "Aceptar.";
            this.ID_ACC_ACE_PB.UseVisualStyleBackColor = true;
            this.ID_ACC_ACE_PB.Click += new System.EventHandler(this.ID_ACC_ACE_PB_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel3.Controls.Add(this.ID_ACC_TOKEN_EB);
            this.panel3.Controls.Add(this.ID_ACC_CVE_EB);
            this.panel3.Controls.Add(this.ID_ACC_USU_EB);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(68, 76);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 115);
            this.panel3.TabIndex = 1;
            // 
            // ID_ACC_TOKEN_EB
            // 
            this.ID_ACC_TOKEN_EB.Location = new System.Drawing.Point(67, 83);
            this.ID_ACC_TOKEN_EB.MaxLength = 6;
            this.ID_ACC_TOKEN_EB.Name = "ID_ACC_TOKEN_EB";
            this.ID_ACC_TOKEN_EB.PasswordChar = '*';
            this.ID_ACC_TOKEN_EB.Size = new System.Drawing.Size(98, 20);
            this.ID_ACC_TOKEN_EB.TabIndex = 3;
            this.ID_ACC_TOKEN_EB.TextChanged += new System.EventHandler(this.ID_ACC_TOKEN_EB_TextChanged);
            this.ID_ACC_TOKEN_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_ACC_TOKEN_EB_KeyPress);
            this.ID_ACC_TOKEN_EB.Leave += new System.EventHandler(this.ID_ACC_TOKEN_EB_Leave);
            // 
            // ID_ACC_CVE_EB
            // 
            this.ID_ACC_CVE_EB.Location = new System.Drawing.Point(67, 58);
            this.ID_ACC_CVE_EB.MaxLength = 20;
            this.ID_ACC_CVE_EB.Name = "ID_ACC_CVE_EB";
            this.ID_ACC_CVE_EB.PasswordChar = '*';
            this.ID_ACC_CVE_EB.Size = new System.Drawing.Size(98, 20);
            this.ID_ACC_CVE_EB.TabIndex = 2;
            this.ID_ACC_CVE_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_ACC_CVE_EB_KeyPress);
            // 
            // ID_ACC_USU_EB
            // 
            this.ID_ACC_USU_EB.Location = new System.Drawing.Point(67, 34);
            this.ID_ACC_USU_EB.MaxLength = 12;
            this.ID_ACC_USU_EB.Name = "ID_ACC_USU_EB";
            this.ID_ACC_USU_EB.Size = new System.Drawing.Size(98, 20);
            this.ID_ACC_USU_EB.TabIndex = 1;
            this.ID_ACC_USU_EB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_ACC_USU_EB_KeyPress);
            this.ID_ACC_USU_EB.Leave += new System.EventHandler(this.ID_ACC_USU_EB_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 83);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Token:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "SOEID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(13, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(186, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "TARJETA CORPORATIVA.";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.ID_ACC_BAN_COB);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(14, 213);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(301, 42);
            this.panel2.TabIndex = 2;
            // 
            // ID_ACC_BAN_COB
            // 
            this.ID_ACC_BAN_COB.FormattingEnabled = true;
            this.ID_ACC_BAN_COB.Location = new System.Drawing.Point(69, 9);
            this.ID_ACC_BAN_COB.Name = "ID_ACC_BAN_COB";
            this.ID_ACC_BAN_COB.Size = new System.Drawing.Size(209, 21);
            this.ID_ACC_BAN_COB.TabIndex = 4;
            this.ID_ACC_BAN_COB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ID_ACC_BAN_COB_KeyPress);
            this.ID_ACC_BAN_COB.Leave += new System.EventHandler(this.ID_ACC_BAN_COB_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Producto:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(14, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 199);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 300);
            this.ControlBox = false;
            this.Controls.Add(this.panel1);
            this.Location = new System.Drawing.Point(239, 189);
            this.Name = "frmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Activated += new System.EventHandler(this.frmLogin_Activated);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ID_ACC_CAN_PB;
        private System.Windows.Forms.Button ID_ACC_ACE_PB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ID_ACC_TOKEN_EB;
        private System.Windows.Forms.TextBox ID_ACC_CVE_EB;
        private System.Windows.Forms.TextBox ID_ACC_USU_EB;
        private System.Windows.Forms.ComboBox ID_ACC_BAN_COB;
    }
}