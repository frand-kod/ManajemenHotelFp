using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Sistem_Manajemen_Hotel.Controller;
using Sistem_Manajemen_Hotel.Model.Context;
using Sistem_Manajemen_Hotel.Model.Entity;

namespace Sistem_Manajemen_Hotel.View
{

    public partial class Form_SignUp : Form
    {
        private LoginController _loginController;
        public Form_SignUp()
        {
            _loginController = new LoginController();
            InitializeComponent();
            txtUsernameSignUp.KeyDown += txtUsernameSignUp_KeyDown;
            txtPasswordSignUp.KeyDown += txtPasswordSignUp_KeyDown;
        }
        private void txtUsernameSignUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true; // Menghentikan suara 'ding' bawaan dari sistem
                e.Handled = true; // Menandai event sebagai sudah ditangani
                txtUsernameSignUp.Focus(); // Pindah fokus ke TextBox password
            }
        }
        private void txtPasswordSignUp_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                btnSignUp.PerformClick(); // Mensimulasikan klik pada tombol sign up
            }
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            string username = txtUsernameSignUp.Text;
            string password = txtPasswordSignUp.Text;

            var newSignUp = new LoginEntity
            {
                Username = username,
                Password = password,
            };

            // panggil controller login
            int result = _loginController.SignUp(newSignUp);

            MessageBox.Show(result == 1 ? "SignUp Berhasil.." : "SignUp Gagal", "Notifikasi Login", MessageBoxButtons.OK);

        }

        private void lkbRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_Login login = new Form_Login();
            login.Show();
            this.Hide();
        }

        private void pcbHide_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pcbHide, "Hide Password");
        }

        private void pcbShow_MouseHover(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pcbShow, "Show Password");
        }

        private void pcbHide_Click(object sender, EventArgs e)
        {
            txtPasswordSignUp.UseSystemPasswordChar = true;
            pcbHide.Hide();
            pcbShow.Show();
        }

        private void pcbShow_Click(object sender, EventArgs e)
        {
            txtPasswordSignUp.UseSystemPasswordChar = false;
            pcbShow.Hide();
            pcbHide.Show();
        }

        private void Form_SignUp_Load(object sender, EventArgs e)
        {
            txtPasswordSignUp.UseSystemPasswordChar = true;
            pcbHide.Hide();
        }
    }
}
