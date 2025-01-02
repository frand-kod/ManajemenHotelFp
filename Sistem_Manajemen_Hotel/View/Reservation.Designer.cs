namespace Sistem_Manajemen_Hotel.View
{
    partial class Reservation
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
            this.grbClient = new System.Windows.Forms.GroupBox();
            this.dtp_Out = new System.Windows.Forms.DateTimePicker();
            this.dtp_In = new System.Windows.Forms.DateTimePicker();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.RoomType = new System.Windows.Forms.Label();
            this.lvwReservation = new System.Windows.Forms.ListView();
            this.txtSearch_Reservation = new System.Windows.Forms.TextBox();
            this.txtIdClient = new System.Windows.Forms.TextBox();
            this.btnDelete_Reservation = new System.Windows.Forms.Button();
            this.btnUpdate_Reservation = new System.Windows.Forms.Button();
            this.btnSearch_Reservation = new System.Windows.Forms.Button();
            this.btnAdd_Reservation = new System.Windows.Forms.Button();
            this.grbClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbClient
            // 
            this.grbClient.Controls.Add(this.dtp_Out);
            this.grbClient.Controls.Add(this.dtp_In);
            this.grbClient.Controls.Add(this.cmbRoomType);
            this.grbClient.Controls.Add(this.label1);
            this.grbClient.Controls.Add(this.label4);
            this.grbClient.Controls.Add(this.label3);
            this.grbClient.Controls.Add(this.label2);
            this.grbClient.Controls.Add(this.RoomType);
            this.grbClient.Controls.Add(this.lvwReservation);
            this.grbClient.Controls.Add(this.txtSearch_Reservation);
            this.grbClient.Controls.Add(this.txtIdClient);
            this.grbClient.Controls.Add(this.btnDelete_Reservation);
            this.grbClient.Controls.Add(this.btnUpdate_Reservation);
            this.grbClient.Controls.Add(this.btnSearch_Reservation);
            this.grbClient.Controls.Add(this.btnAdd_Reservation);
            this.grbClient.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.grbClient.Location = new System.Drawing.Point(3, 3);
            this.grbClient.Name = "grbClient";
            this.grbClient.Size = new System.Drawing.Size(987, 494);
            this.grbClient.TabIndex = 5;
            this.grbClient.TabStop = false;
            this.grbClient.Text = "[ Search Reservation : ]";
            // 
            // dtp_Out
            // 
            this.dtp_Out.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_Out.Location = new System.Drawing.Point(587, 99);
            this.dtp_Out.Name = "dtp_Out";
            this.dtp_Out.Size = new System.Drawing.Size(367, 26);
            this.dtp_Out.TabIndex = 5;
            // 
            // dtp_In
            // 
            this.dtp_In.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtp_In.Location = new System.Drawing.Point(587, 48);
            this.dtp_In.Name = "dtp_In";
            this.dtp_In.Size = new System.Drawing.Size(367, 26);
            this.dtp_In.TabIndex = 5;
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Location = new System.Drawing.Point(133, 48);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(392, 26);
            this.cmbRoomType.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(539, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Out :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(31, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Search        :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(552, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "In :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(29, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 18);
            this.label2.TabIndex = 0;
            this.label2.Text = "ID Client      :";
            // 
            // RoomType
            // 
            this.RoomType.AutoSize = true;
            this.RoomType.ForeColor = System.Drawing.Color.Black;
            this.RoomType.Location = new System.Drawing.Point(29, 51);
            this.RoomType.Name = "RoomType";
            this.RoomType.Size = new System.Drawing.Size(98, 18);
            this.RoomType.TabIndex = 0;
            this.RoomType.Text = "Room Type :";
            // 
            // lvwReservation
            // 
            this.lvwReservation.HideSelection = false;
            this.lvwReservation.Location = new System.Drawing.Point(32, 180);
            this.lvwReservation.Name = "lvwReservation";
            this.lvwReservation.Size = new System.Drawing.Size(929, 252);
            this.lvwReservation.TabIndex = 3;
            this.lvwReservation.UseCompatibleStateImageBehavior = false;
            // 
            // txtSearch_Reservation
            // 
            this.txtSearch_Reservation.Location = new System.Drawing.Point(133, 147);
            this.txtSearch_Reservation.Name = "txtSearch_Reservation";
            this.txtSearch_Reservation.Size = new System.Drawing.Size(392, 26);
            this.txtSearch_Reservation.TabIndex = 1;
            // 
            // txtIdClient
            // 
            this.txtIdClient.Location = new System.Drawing.Point(133, 99);
            this.txtIdClient.Name = "txtIdClient";
            this.txtIdClient.Size = new System.Drawing.Size(392, 26);
            this.txtIdClient.TabIndex = 1;
            // 
            // btnDelete_Reservation
            // 
            this.btnDelete_Reservation.BackColor = System.Drawing.Color.Red;
            this.btnDelete_Reservation.FlatAppearance.BorderSize = 0;
            this.btnDelete_Reservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete_Reservation.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete_Reservation.ForeColor = System.Drawing.Color.White;
            this.btnDelete_Reservation.Location = new System.Drawing.Point(312, 438);
            this.btnDelete_Reservation.Name = "btnDelete_Reservation";
            this.btnDelete_Reservation.Size = new System.Drawing.Size(134, 35);
            this.btnDelete_Reservation.TabIndex = 2;
            this.btnDelete_Reservation.Text = "Delete";
            this.btnDelete_Reservation.UseVisualStyleBackColor = false;
            this.btnDelete_Reservation.Click += new System.EventHandler(this.btnDelete_Reservation_Click);
            // 
            // btnUpdate_Reservation
            // 
            this.btnUpdate_Reservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.btnUpdate_Reservation.FlatAppearance.BorderSize = 0;
            this.btnUpdate_Reservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate_Reservation.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate_Reservation.ForeColor = System.Drawing.Color.White;
            this.btnUpdate_Reservation.Location = new System.Drawing.Point(172, 438);
            this.btnUpdate_Reservation.Name = "btnUpdate_Reservation";
            this.btnUpdate_Reservation.Size = new System.Drawing.Size(134, 35);
            this.btnUpdate_Reservation.TabIndex = 2;
            this.btnUpdate_Reservation.Text = "Update";
            this.btnUpdate_Reservation.UseVisualStyleBackColor = false;
            this.btnUpdate_Reservation.Click += new System.EventHandler(this.btnUpdate_Reservation_Click);
            // 
            // btnSearch_Reservation
            // 
            this.btnSearch_Reservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.btnSearch_Reservation.FlatAppearance.BorderSize = 0;
            this.btnSearch_Reservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch_Reservation.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch_Reservation.ForeColor = System.Drawing.Color.White;
            this.btnSearch_Reservation.Location = new System.Drawing.Point(531, 147);
            this.btnSearch_Reservation.Name = "btnSearch_Reservation";
            this.btnSearch_Reservation.Size = new System.Drawing.Size(134, 27);
            this.btnSearch_Reservation.TabIndex = 2;
            this.btnSearch_Reservation.Text = "Search";
            this.btnSearch_Reservation.UseVisualStyleBackColor = false;
            this.btnSearch_Reservation.Click += new System.EventHandler(this.btnSearch_Reservation_Click);
            // 
            // btnAdd_Reservation
            // 
            this.btnAdd_Reservation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.btnAdd_Reservation.FlatAppearance.BorderSize = 0;
            this.btnAdd_Reservation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd_Reservation.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd_Reservation.ForeColor = System.Drawing.Color.White;
            this.btnAdd_Reservation.Location = new System.Drawing.Point(32, 438);
            this.btnAdd_Reservation.Name = "btnAdd_Reservation";
            this.btnAdd_Reservation.Size = new System.Drawing.Size(134, 35);
            this.btnAdd_Reservation.TabIndex = 2;
            this.btnAdd_Reservation.Text = "Add";
            this.btnAdd_Reservation.UseVisualStyleBackColor = false;
            this.btnAdd_Reservation.Click += new System.EventHandler(this.btnAdd_Reservation_Click);
            // 
            // Reservation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grbClient);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Reservation";
            this.Size = new System.Drawing.Size(993, 500);
            this.grbClient.ResumeLayout(false);
            this.grbClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbClient;
        private System.Windows.Forms.DateTimePicker dtp_Out;
        private System.Windows.Forms.DateTimePicker dtp_In;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label RoomType;
        private System.Windows.Forms.ListView lvwReservation;
        private System.Windows.Forms.TextBox txtSearch_Reservation;
        private System.Windows.Forms.TextBox txtIdClient;
        private System.Windows.Forms.Button btnDelete_Reservation;
        private System.Windows.Forms.Button btnUpdate_Reservation;
        private System.Windows.Forms.Button btnSearch_Reservation;
        private System.Windows.Forms.Button btnAdd_Reservation;
    }
}
