namespace Sistem_Manajemen_Hotel.View
{
    partial class Room
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
            this.btnAdd_Room = new System.Windows.Forms.Button();
            this.btnSearch_Client = new System.Windows.Forms.Button();
            this.btnUpdate_Room = new System.Windows.Forms.Button();
            this.btnDelete_Room = new System.Windows.Forms.Button();
            this.txtSearch_room = new System.Windows.Forms.TextBox();
            this.lvwRoom = new System.Windows.Forms.ListView();
            this.label4 = new System.Windows.Forms.Label();
            this.grbClient = new System.Windows.Forms.GroupBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.rdbNotAvail = new System.Windows.Forms.RadioButton();
            this.rdbAvailabe = new System.Windows.Forms.RadioButton();
            this.cmbRoomType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.RoomType = new System.Windows.Forms.Label();
            this.txtNumberRoom = new System.Windows.Forms.TextBox();
            this.grbClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAdd_Room
            // 
            this.btnAdd_Room.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.btnAdd_Room.FlatAppearance.BorderSize = 0;
            this.btnAdd_Room.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd_Room.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd_Room.ForeColor = System.Drawing.Color.White;
            this.btnAdd_Room.Location = new System.Drawing.Point(32, 438);
            this.btnAdd_Room.Name = "btnAdd_Room";
            this.btnAdd_Room.Size = new System.Drawing.Size(134, 35);
            this.btnAdd_Room.TabIndex = 2;
            this.btnAdd_Room.Text = "Add";
            this.btnAdd_Room.UseVisualStyleBackColor = false;
            this.btnAdd_Room.Click += new System.EventHandler(this.btnAdd_Room_Click);
            // 
            // btnSearch_Client
            // 
            this.btnSearch_Client.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.btnSearch_Client.FlatAppearance.BorderSize = 0;
            this.btnSearch_Client.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch_Client.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch_Client.ForeColor = System.Drawing.Color.White;
            this.btnSearch_Client.Location = new System.Drawing.Point(525, 147);
            this.btnSearch_Client.Name = "btnSearch_Client";
            this.btnSearch_Client.Size = new System.Drawing.Size(134, 27);
            this.btnSearch_Client.TabIndex = 2;
            this.btnSearch_Client.Text = "Search";
            this.btnSearch_Client.UseVisualStyleBackColor = false;
            // 
            // btnUpdate_Room
            // 
            this.btnUpdate_Room.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.btnUpdate_Room.FlatAppearance.BorderSize = 0;
            this.btnUpdate_Room.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate_Room.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate_Room.ForeColor = System.Drawing.Color.White;
            this.btnUpdate_Room.Location = new System.Drawing.Point(172, 438);
            this.btnUpdate_Room.Name = "btnUpdate_Room";
            this.btnUpdate_Room.Size = new System.Drawing.Size(134, 35);
            this.btnUpdate_Room.TabIndex = 2;
            this.btnUpdate_Room.Text = "Update";
            this.btnUpdate_Room.UseVisualStyleBackColor = false;
            // 
            // btnDelete_Room
            // 
            this.btnDelete_Room.BackColor = System.Drawing.Color.Red;
            this.btnDelete_Room.FlatAppearance.BorderSize = 0;
            this.btnDelete_Room.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete_Room.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete_Room.ForeColor = System.Drawing.Color.White;
            this.btnDelete_Room.Location = new System.Drawing.Point(312, 438);
            this.btnDelete_Room.Name = "btnDelete_Room";
            this.btnDelete_Room.Size = new System.Drawing.Size(134, 35);
            this.btnDelete_Room.TabIndex = 2;
            this.btnDelete_Room.Text = "Delete";
            this.btnDelete_Room.UseVisualStyleBackColor = false;
            // 
            // txtSearch_room
            // 
            this.txtSearch_room.Location = new System.Drawing.Point(126, 147);
            this.txtSearch_room.Name = "txtSearch_room";
            this.txtSearch_room.Size = new System.Drawing.Size(376, 26);
            this.txtSearch_room.TabIndex = 1;
            // 
            // lvwRoom
            // 
            this.lvwRoom.HideSelection = false;
            this.lvwRoom.Location = new System.Drawing.Point(32, 180);
            this.lvwRoom.Name = "lvwRoom";
            this.lvwRoom.Size = new System.Drawing.Size(929, 252);
            this.lvwRoom.TabIndex = 3;
            this.lvwRoom.UseCompatibleStateImageBehavior = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(31, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 18);
            this.label4.TabIndex = 0;
            this.label4.Text = "Search      :";
            // 
            // grbClient
            // 
            this.grbClient.Controls.Add(this.txtPrice);
            this.grbClient.Controls.Add(this.lblPrice);
            this.grbClient.Controls.Add(this.rdbNotAvail);
            this.grbClient.Controls.Add(this.rdbAvailabe);
            this.grbClient.Controls.Add(this.cmbRoomType);
            this.grbClient.Controls.Add(this.label2);
            this.grbClient.Controls.Add(this.label5);
            this.grbClient.Controls.Add(this.RoomType);
            this.grbClient.Controls.Add(this.label4);
            this.grbClient.Controls.Add(this.lvwRoom);
            this.grbClient.Controls.Add(this.txtNumberRoom);
            this.grbClient.Controls.Add(this.txtSearch_room);
            this.grbClient.Controls.Add(this.btnDelete_Room);
            this.grbClient.Controls.Add(this.btnUpdate_Room);
            this.grbClient.Controls.Add(this.btnSearch_Client);
            this.grbClient.Controls.Add(this.btnAdd_Room);
            this.grbClient.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbClient.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(146)))), ((int)(((byte)(255)))));
            this.grbClient.Location = new System.Drawing.Point(3, 3);
            this.grbClient.Name = "grbClient";
            this.grbClient.Size = new System.Drawing.Size(987, 494);
            this.grbClient.TabIndex = 5;
            this.grbClient.TabStop = false;
            this.grbClient.Text = "[ Search Room : ]";
            this.grbClient.Enter += new System.EventHandler(this.grbClient_Enter);
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(172, 117);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(329, 26);
            this.txtPrice.TabIndex = 17;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.ForeColor = System.Drawing.Color.Black;
            this.lblPrice.Location = new System.Drawing.Point(31, 117);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(92, 18);
            this.lblPrice.TabIndex = 16;
            this.lblPrice.Text = "Room Price";
            // 
            // rdbNotAvail
            // 
            this.rdbNotAvail.AutoSize = true;
            this.rdbNotAvail.Location = new System.Drawing.Point(730, 54);
            this.rdbNotAvail.Name = "rdbNotAvail";
            this.rdbNotAvail.Size = new System.Drawing.Size(47, 22);
            this.rdbNotAvail.TabIndex = 15;
            this.rdbNotAvail.TabStop = true;
            this.rdbNotAvail.Text = "No";
            this.rdbNotAvail.UseVisualStyleBackColor = true;
            // 
            // rdbAvailabe
            // 
            this.rdbAvailabe.AutoSize = true;
            this.rdbAvailabe.Location = new System.Drawing.Point(673, 54);
            this.rdbAvailabe.Name = "rdbAvailabe";
            this.rdbAvailabe.Size = new System.Drawing.Size(51, 22);
            this.rdbAvailabe.TabIndex = 14;
            this.rdbAvailabe.TabStop = true;
            this.rdbAvailabe.Text = "Yes";
            this.rdbAvailabe.UseVisualStyleBackColor = true;
            // 
            // cmbRoomType
            // 
            this.cmbRoomType.FormattingEnabled = true;
            this.cmbRoomType.Items.AddRange(new object[] {
            "Deluxe",
            "Standard",
            "Suite",
            "Family"});
            this.cmbRoomType.Location = new System.Drawing.Point(133, 48);
            this.cmbRoomType.Name = "cmbRoomType";
            this.cmbRoomType.Size = new System.Drawing.Size(369, 26);
            this.cmbRoomType.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(522, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 18);
            this.label2.TabIndex = 8;
            this.label2.Text = "Room Availability :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(29, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 18);
            this.label5.TabIndex = 9;
            this.label5.Text = "Room Number";
            // 
            // RoomType
            // 
            this.RoomType.AutoSize = true;
            this.RoomType.ForeColor = System.Drawing.Color.Black;
            this.RoomType.Location = new System.Drawing.Point(29, 51);
            this.RoomType.Name = "RoomType";
            this.RoomType.Size = new System.Drawing.Size(98, 18);
            this.RoomType.TabIndex = 9;
            this.RoomType.Text = "Room Type :";
            // 
            // txtNumberRoom
            // 
            this.txtNumberRoom.Location = new System.Drawing.Point(172, 85);
            this.txtNumberRoom.Name = "txtNumberRoom";
            this.txtNumberRoom.Size = new System.Drawing.Size(329, 26);
            this.txtNumberRoom.TabIndex = 1;
            // 
            // Room
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grbClient);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Room";
            this.Size = new System.Drawing.Size(993, 500);
            this.grbClient.ResumeLayout(false);
            this.grbClient.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd_Room;
        private System.Windows.Forms.Button btnSearch_Client;
        private System.Windows.Forms.Button btnUpdate_Room;
        private System.Windows.Forms.Button btnDelete_Room;
        private System.Windows.Forms.TextBox txtSearch_room;
        private System.Windows.Forms.ListView lvwRoom;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox grbClient;
        private System.Windows.Forms.RadioButton rdbNotAvail;
        private System.Windows.Forms.RadioButton rdbAvailabe;
        private System.Windows.Forms.ComboBox cmbRoomType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label RoomType;
        private System.Windows.Forms.TextBox txtNumberRoom;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label lblPrice;
    }
}
