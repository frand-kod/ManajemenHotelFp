namespace Sistem_Manajemen_Hotel.View
{
    partial class Client
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtFirstname = new System.Windows.Forms.TextBox();
            this.btnAdd_Client = new System.Windows.Forms.Button();
            this.lvwClient = new System.Windows.Forms.ListView();
            this.grbClient = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSearch_Client = new System.Windows.Forms.TextBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.txtLastname = new System.Windows.Forms.TextBox();
            this.btnDelete_Client = new System.Windows.Forms.Button();
            this.btnUpdate_Client = new System.Windows.Forms.Button();
            this.btnSearch_Client = new System.Windows.Forms.Button();
            this.grbClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(30, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Firstname :";
            // 
            // txtFirstname
            // 
            this.txtFirstname.Location = new System.Drawing.Point(126, 29);
            this.txtFirstname.Name = "txtFirstname";
            this.txtFirstname.Size = new System.Drawing.Size(539, 26);
            this.txtFirstname.TabIndex = 1;
            // 
            // btnAdd_Client
            // 
            this.btnAdd_Client.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.btnAdd_Client.FlatAppearance.BorderSize = 0;
            this.btnAdd_Client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd_Client.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd_Client.ForeColor = System.Drawing.Color.White;
            this.btnAdd_Client.Location = new System.Drawing.Point(38, 438);
            this.btnAdd_Client.Name = "btnAdd_Client";
            this.btnAdd_Client.Size = new System.Drawing.Size(134, 35);
            this.btnAdd_Client.TabIndex = 2;
            this.btnAdd_Client.Text = "Add";
            this.btnAdd_Client.UseVisualStyleBackColor = false;
            this.btnAdd_Client.Click += new System.EventHandler(this.btnAdd_Client_Click);
            // 
            // lvwClient
            // 
            this.lvwClient.HideSelection = false;
            this.lvwClient.Location = new System.Drawing.Point(38, 180);
            this.lvwClient.Name = "lvwClient";
            this.lvwClient.Size = new System.Drawing.Size(916, 252);
            this.lvwClient.TabIndex = 3;
            this.lvwClient.UseCompatibleStateImageBehavior = false;
            // 
            // grbClient
            // 
            this.grbClient.Controls.Add(this.label4);
            this.grbClient.Controls.Add(this.label3);
            this.grbClient.Controls.Add(this.label2);
            this.grbClient.Controls.Add(this.label1);
            this.grbClient.Controls.Add(this.lvwClient);
            this.grbClient.Controls.Add(this.txtSearch_Client);
            this.grbClient.Controls.Add(this.txtPhoneNo);
            this.grbClient.Controls.Add(this.txtLastname);
            this.grbClient.Controls.Add(this.txtFirstname);
            this.grbClient.Controls.Add(this.btnDelete_Client);
            this.grbClient.Controls.Add(this.btnUpdate_Client);
            this.grbClient.Controls.Add(this.btnSearch_Client);
            this.grbClient.Controls.Add(this.btnAdd_Client);
            this.grbClient.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.grbClient.Location = new System.Drawing.Point(3, 3);
            this.grbClient.Name = "grbClient";
            this.grbClient.Size = new System.Drawing.Size(987, 494);
            this.grbClient.TabIndex = 4;
            this.grbClient.TabStop = false;
            this.grbClient.Text = "[ Search Client : ]";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(52, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Search :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(33, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "Phone No :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(37, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lastname :";
            // 
            // txtSearch_Client
            // 
            this.txtSearch_Client.Location = new System.Drawing.Point(126, 147);
            this.txtSearch_Client.Name = "txtSearch_Client";
            this.txtSearch_Client.Size = new System.Drawing.Size(399, 26);
            this.txtSearch_Client.TabIndex = 1;
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(126, 108);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(539, 26);
            this.txtPhoneNo.TabIndex = 1;
            // 
            // txtLastname
            // 
            this.txtLastname.Location = new System.Drawing.Point(126, 68);
            this.txtLastname.Name = "txtLastname";
            this.txtLastname.Size = new System.Drawing.Size(539, 26);
            this.txtLastname.TabIndex = 1;
            // 
            // btnDelete_Client
            // 
            this.btnDelete_Client.BackColor = System.Drawing.Color.Red;
            this.btnDelete_Client.FlatAppearance.BorderSize = 0;
            this.btnDelete_Client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete_Client.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete_Client.ForeColor = System.Drawing.Color.White;
            this.btnDelete_Client.Location = new System.Drawing.Point(318, 438);
            this.btnDelete_Client.Name = "btnDelete_Client";
            this.btnDelete_Client.Size = new System.Drawing.Size(134, 35);
            this.btnDelete_Client.TabIndex = 2;
            this.btnDelete_Client.Text = "Delete";
            this.btnDelete_Client.UseVisualStyleBackColor = false;
            this.btnDelete_Client.Click += new System.EventHandler(this.btnDelete_Client_Click);
            // 
            // btnUpdate_Client
            // 
            this.btnUpdate_Client.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.btnUpdate_Client.FlatAppearance.BorderSize = 0;
            this.btnUpdate_Client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate_Client.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate_Client.ForeColor = System.Drawing.Color.White;
            this.btnUpdate_Client.Location = new System.Drawing.Point(178, 438);
            this.btnUpdate_Client.Name = "btnUpdate_Client";
            this.btnUpdate_Client.Size = new System.Drawing.Size(134, 35);
            this.btnUpdate_Client.TabIndex = 2;
            this.btnUpdate_Client.Text = "Update";
            this.btnUpdate_Client.UseVisualStyleBackColor = false;
            this.btnUpdate_Client.Click += new System.EventHandler(this.btnUpdate_Client_Click);
            // 
            // btnSearch_Client
            // 
            this.btnSearch_Client.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.btnSearch_Client.FlatAppearance.BorderSize = 0;
            this.btnSearch_Client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch_Client.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch_Client.ForeColor = System.Drawing.Color.White;
            this.btnSearch_Client.Location = new System.Drawing.Point(531, 147);
            this.btnSearch_Client.Name = "btnSearch_Client";
            this.btnSearch_Client.Size = new System.Drawing.Size(134, 27);
            this.btnSearch_Client.TabIndex = 2;
            this.btnSearch_Client.Text = "Search";
            this.btnSearch_Client.UseVisualStyleBackColor = false;
            this.btnSearch_Client.Click += new System.EventHandler(this.btnSearch_Client_Click);
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grbClient);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Client";
            this.Size = new System.Drawing.Size(993, 500);
            this.grbClient.ResumeLayout(false);
            this.grbClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFirstname;
        private System.Windows.Forms.Button btnAdd_Client;
        private System.Windows.Forms.ListView lvwClient;
        private System.Windows.Forms.GroupBox grbClient;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.TextBox txtLastname;
        private System.Windows.Forms.Button btnDelete_Client;
        private System.Windows.Forms.Button btnUpdate_Client;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSearch_Client;
        private System.Windows.Forms.Button btnSearch_Client;
    }
}
