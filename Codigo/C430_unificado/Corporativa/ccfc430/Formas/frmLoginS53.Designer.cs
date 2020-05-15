namespace TCc430
{
    partial class frmLoginS53
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>


        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoginS53));
            this.button1 = new System.Windows.Forms.Button();
            this.ID_ACC_ACE_PB = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ID_ACC_TOKEN_EB = new System.Windows.Forms.TextBox();
            this.ID_ACC_CVE_EB = new System.Windows.Forms.TextBox();
            this.ID_ACC_USU_EB = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(182, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(78, 26);
            this.button1.TabIndex = 19;
            this.button1.Text = "Cancelar.";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ID_ACC_ACE_PB
            // 
            this.ID_ACC_ACE_PB.Location = new System.Drawing.Point(53, 215);
            this.ID_ACC_ACE_PB.Name = "ID_ACC_ACE_PB";
            this.ID_ACC_ACE_PB.Size = new System.Drawing.Size(78, 26);
            this.ID_ACC_ACE_PB.TabIndex = 18;
            this.ID_ACC_ACE_PB.Text = "Aceptar.";
            this.ID_ACC_ACE_PB.UseVisualStyleBackColor = true;
            this.ID_ACC_ACE_PB.Click += new System.EventHandler(this.ID_ACC_ACE_PB_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(1, -7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(301, 258);
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(1, 1);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(301, 199);
            this.pictureBox2.TabIndex = 23;
            this.pictureBox2.TabStop = false;
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
            this.panel3.Location = new System.Drawing.Point(51, 61);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(209, 115);
            this.panel3.TabIndex = 24;
            // 
            // ID_ACC_TOKEN_EB
            // 
            this.ID_ACC_TOKEN_EB.Location = new System.Drawing.Point(67, 83);
            this.ID_ACC_TOKEN_EB.MaxLength = 6;
            this.ID_ACC_TOKEN_EB.Name = "ID_ACC_TOKEN_EB";
            this.ID_ACC_TOKEN_EB.PasswordChar = '*';
            this.ID_ACC_TOKEN_EB.Size = new System.Drawing.Size(98, 20);
            this.ID_ACC_TOKEN_EB.TabIndex = 3;
            // 
            // ID_ACC_CVE_EB
            // 
            this.ID_ACC_CVE_EB.Location = new System.Drawing.Point(67, 58);
            this.ID_ACC_CVE_EB.MaxLength = 20;
            this.ID_ACC_CVE_EB.Name = "ID_ACC_CVE_EB";
            this.ID_ACC_CVE_EB.PasswordChar = '*';
            this.ID_ACC_CVE_EB.Size = new System.Drawing.Size(98, 20);
            this.ID_ACC_CVE_EB.TabIndex = 2;
            // 
            // ID_ACC_USU_EB
            // 
            this.ID_ACC_USU_EB.Enabled = false;
            this.ID_ACC_USU_EB.Location = new System.Drawing.Point(67, 34);
            this.ID_ACC_USU_EB.MaxLength = 12;
            this.ID_ACC_USU_EB.Name = "ID_ACC_USU_EB";
            this.ID_ACC_USU_EB.Size = new System.Drawing.Size(98, 20);
            this.ID_ACC_USU_EB.TabIndex = 1;
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
            this.label1.Size = new System.Drawing.Size(182, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "TARJETA CORPORATIVA";
            // 
            // frmLoginS53
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(305, 250);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ID_ACC_ACE_PB);
            this.Controls.Add(this.pictureBox1);
            this.Location = new System.Drawing.Point(225, 265);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoginS53";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Firma SSS";
            this.Load += new System.EventHandler(this.frmLoginS53_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button ID_ACC_ACE_PB;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox ID_ACC_TOKEN_EB;
        private System.Windows.Forms.TextBox ID_ACC_CVE_EB;
        private System.Windows.Forms.TextBox ID_ACC_USU_EB;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;

    }
}