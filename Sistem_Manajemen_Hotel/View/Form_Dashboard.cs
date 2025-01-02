using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistem_Manajemen_Hotel.View
{
    public partial class Form_Dashboard : Form
    {
        public Form_Dashboard()
        {
            InitializeComponent();
        }

        private void lkbLogout_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Form_Login loginFrom = new Form_Login();
                loginFrom.Show();
                this.Hide();
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            Dashboard dashboard = dashboard1 as Dashboard;

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
            Reservation room = reservation1 as Reservation;

            dashboard1.Visible = false;
            client1.Visible = false;
            room1.Visible = false;
            reservation1.Visible = true;

            if (room != null)
            {
                room.RefreshData();
            }
        }
    }
}