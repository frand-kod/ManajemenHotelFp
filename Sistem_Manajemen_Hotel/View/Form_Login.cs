using System;
using System.Windows.Forms;
using Sistem_Manajemen_Hotel.Model.Entity;
using Sistem_Manajemen_Hotel.Controller;
using System.Diagnostics;

namespace Sistem_Manajemen_Hotel.View
{
    public partial class Form_Login : Form
    {
        private LoginController _loginController;

        public Form_Login()
        {
            InitializeComponent();
            _loginController = new LoginController();
        }
        private void txtPassword_Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnLogin.PerformClick(); // Simulasikan klik pada tombol login
            }
        }

        private void lkbRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form_SignUp signUp = new Form_SignUp();
            signUp.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsernameLogin.Text;
            string password = txtPasswordLogin.Text;

            var newLogin = new LoginEntity
            {
                Username = username,
                Password = password,
            };

            bool isAuthentificated = _loginController.Login(newLogin);

            MessageBox.Show(isAuthentificated ? "Login Berhasil.." : "Login Gagal..", "Notifikasi Login", MessageBoxButtons.OK);

            // panggil controller login
            if (isAuthentificated)
            {                
                // inisialisasi formDashboard dan set usernamenya
                using (var dashboardForm = new Form_Dashboard(newLogin.Username))
                {
                    this.Hide(); // Sembunyikan form login
                    dashboardForm.ShowDialog(); // Tampilkan dashboard
                }

                this.Close(); // Tampilkan kembali form login jika logout
            }
            else
            {
            Debug.WriteLine($" Data dari login_Cick --username {newLogin.Username} password {newLogin.Password}");
            }
        }
        private void pcbHide_MouseHover_1(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pcbHide, "Hide Password");
        }
        private void pcbShow_MouseHover_1(object sender, EventArgs e)
        {
            toolTip1.SetToolTip(pcbShow, "Show Password");
        }
        private void pcbHide_Click(object sender, EventArgs e)
        {
            txtPasswordLogin.UseSystemPasswordChar = true;
            pcbHide.Hide();
            pcbShow.Show();
        }
        private void pcbShow_Click(object sender, EventArgs e)
        {
            txtPasswordLogin.UseSystemPasswordChar = false;
            pcbShow.Hide();
            pcbHide.Show();
        }

        private void Form_Login_Load_1(object sender, EventArgs e)
        {
            txtPasswordLogin.UseSystemPasswordChar = true;
            pcbHide.Hide();
        }
    }
}

