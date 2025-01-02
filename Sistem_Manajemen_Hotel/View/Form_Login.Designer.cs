namespace Sistem_Manajemen_Hotel.View
{
    partial class Form_Login
    {
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
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lkbRegister = new System.Windows.Forms.LinkLabel();
            this.pcbHide = new System.Windows.Forms.PictureBox();
            this.pcbShow = new System.Windows.Forms.PictureBox();
            this.txtPasswordLogin = new System.Windows.Forms.TextBox();
            this.txtUsernameLogin = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbHide)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbShow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(500, 511);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.lkbRegister);
            this.groupBox1.Controls.Add(this.pcbHide);
            this.groupBox1.Controls.Add(this.pcbShow);
            this.groupBox1.Controls.Add(this.txtPasswordLogin);
            this.groupBox1.Controls.Add(this.txtUsernameLogin);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnLogin);
            this.groupBox1.Location = new System.Drawing.Point(40, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(421, 434);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Silahkan isi terlebih dahulu";
            // 
            // lkbRegister
            // 
            this.lkbRegister.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.lkbRegister.AutoSize = true;
            this.lkbRegister.BackColor = System.Drawing.Color.White;
            this.lkbRegister.DisabledLinkColor = System.Drawing.Color.White;
            this.lkbRegister.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkbRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.lkbRegister.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.lkbRegister.Location = new System.Drawing.Point(286, 375);
            this.lkbRegister.Name = "lkbRegister";
            this.lkbRegister.Size = new System.Drawing.Size(92, 16);
            this.lkbRegister.TabIndex = 7;
            this.lkbRegister.TabStop = true;
            this.lkbRegister.Text = "Register here";
            this.lkbRegister.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.lkbRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkbRegister_LinkClicked);
            // 
            // pcbHide
            // 
            this.pcbHide.Image = global::Sistem_Manajemen_Hotel.Properties.Resources.eye1;
            this.pcbHide.Location = new System.Drawing.Point(334, 215);
            this.pcbHide.Name = "pcbHide";
            this.pcbHide.Size = new System.Drawing.Size(29, 23);
            this.pcbHide.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbHide.TabIndex = 6;
            this.pcbHide.TabStop = false;
            this.pcbHide.Click += new System.EventHandler(this.pcbHide_Click);
            this.pcbHide.MouseHover += new System.EventHandler(this.pcbHide_MouseHover_1);
            // 
            // pcbShow
            // 
            this.pcbShow.Image = global::Sistem_Manajemen_Hotel.Properties.Resources.hidden;
            this.pcbShow.Location = new System.Drawing.Point(334, 215);
            this.pcbShow.Name = "pcbShow";
            this.pcbShow.Size = new System.Drawing.Size(29, 23);
            this.pcbShow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pcbShow.TabIndex = 6;
            this.pcbShow.TabStop = false;
            this.pcbShow.Click += new System.EventHandler(this.pcbShow_Click);
            this.pcbShow.MouseHover += new System.EventHandler(this.pcbShow_MouseHover_1);
            // 
            // txtPasswordLogin
            // 
            this.txtPasswordLogin.Location = new System.Drawing.Point(64, 215);
            this.txtPasswordLogin.Name = "txtPasswordLogin";
            this.txtPasswordLogin.Size = new System.Drawing.Size(270, 23);
            this.txtPasswordLogin.TabIndex = 5;
            // 
            // txtUsernameLogin
            // 
            this.txtUsernameLogin.Location = new System.Drawing.Point(63, 140);
            this.txtUsernameLogin.Name = "txtUsernameLogin";
            this.txtUsernameLogin.Size = new System.Drawing.Size(300, 23);
            this.txtUsernameLogin.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.label3.Location = new System.Drawing.Point(59, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Username :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.label4.Location = new System.Drawing.Point(58, 375);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(222, 16);
            this.label4.TabIndex = 4;
            this.label4.Text = "Don\'t have a registered account?";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.label2.Location = new System.Drawing.Point(59, 179);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password :";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(63, 294);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(300, 30);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Location = new System.Drawing.Point(490, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(10, 511);
            this.panel2.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.label1.Location = new System.Drawing.Point(604, 380);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 72);
            this.label1.TabIndex = 7;
            this.label1.Text = "SISTEM MANAJEMEN \r\nHOTEL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Sistem_Manajemen_Hotel.Properties.Resources._3386894_495179_PHT88F_519;
            this.pictureBox1.Location = new System.Drawing.Point(582, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(341, 311);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 511);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Login";
            this.Load += new System.EventHandler(this.Form_Login_Load_1);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pcbHide)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pcbShow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pcbShow;
        private System.Windows.Forms.PictureBox pcbHide;
        private System.Windows.Forms.TextBox txtPasswordLogin;
        private System.Windows.Forms.TextBox txtUsernameLogin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel lkbRegister;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}