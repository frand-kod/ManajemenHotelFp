using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistem_Manajemen_Hotel.Controller;

namespace Sistem_Manajemen_Hotel.View
{
    public partial class Form_Dashboard : Form
    {
        public Form_Dashboard()
        {
            InitializeComponent();
        }
        public Form_Dashboard(string username)
        {
            InitializeComponent();
            lblUserNameLoginSuccesfully.Text = username;
        }

        private void lkbLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close(); // Tutup form dashboard
            }
        }
        private void MovePanel(Control btn)
        {
            pnlSlide.Top = btn.Top;
            pnlSlide.Height = btn.Height;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //lblDateTime.Text = DateTime.Now.ToString("dd-MM-yyy hh:mm");
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = dashboard1 as Dashboard;
            MovePanel(btnDashboard);
            dashboard1.Visible = true;
            client1.Visible = false;
            room1.Visible = false;
            reservation1.Visible = false;

            if (dashboard != null)
            {
                dashboard.RefreshData();
            }
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            Client client = client1 as Client;
            MovePanel(btnClient);
            dashboard1.Visible = false;
            client1.Visible = true;
            room1.Visible = false;
            reservation1.Visible = false;

            if (client != null)
            {
                client.RefreshData();
            }
        }

        private void btnRoom_Click(object sender, EventArgs e)
        {
            Room room = room1 as Room;
            MovePanel(btnRoom);
            dashboard1.Visible = false;
            client1.Visible = false;
            room1.Visible = true;
            reservation1.Visible = false;

            if (room != null)
            {
                room.RefreshData();
            }
        }

        private void btnReservation_Click(object sender, EventArgs e)
        {

            Reservation DashBoardreservation = reservation1 as Reservation;
            MovePanel(btnReservation);
            dashboard1.Visible = false;
            client1.Visible = false;
            room1.Visible = false;
            reservation1.Visible = true;

            if (DashBoardreservation != null)
            {
                reservation1.RefreshData();
            }
        }

        private void Form_Dashboard_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}