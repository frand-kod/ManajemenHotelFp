using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SQLite;
using Sistem_Manajemen_Hotel.Model.Context;
using Sistem_Manajemen_Hotel.View;
using Dapper;

namespace Sistem_Manajemen_Hotel.View
{
    public partial class Form_Login : Form
    {
        private SQLiteConnection _conn;
        public SQLiteConnection Conn
        {
            get { return _conn ?? (_conn = GetOpenConnection()); }
        }
        private SQLiteConnection GetOpenConnection()
        {
            SQLiteConnection conn = null;
            try
            {
                string dbName = @"D:\SEMESTER 3\Pemrograman Lanjut\Final\Sistem_Manajemen_Hotel\Sistem_Manajemen_Hotel\bin\Debug\database.db";

                string connectionString = string.Format("Data Source={0};FailIfMissing=True", dbName);

                conn = new SQLiteConnection(connectionString);
                conn.Open();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("Open Connection Error: {0}", ex.Message);
            }
            return conn;
        }
        public Form_Login()
        {
            InitializeComponent();
            // Di konstruktor atau pada saat inisialisasi komponen
            txtUsernameLogin.KeyPress += new KeyPressEventHandler(txtUsername_Login_KeyPress);
            txtPasswordLogin.KeyPress += new KeyPressEventHandler(txtPassword_Login_KeyPress);
        }
        private void txtUsername_Login_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Menahan karakter 'Enter' agar tidak ditampilkan di TextBox username
                txtUsernameLogin.Focus(); // Pindah fokus ke TextBox password
            }
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
            try
            {
                using (SQLiteConnection _conn = new SQLiteConnection("Data Source=D:\\SEMESTER 3\\Pemrograman Lanjut\\Final\\Sistem_Manajemen_Hotel\\Sistem_Manajemen_Hotel\\bin\\Debug\\database.db"))
                {
                    if (string.IsNullOrWhiteSpace(txtUsernameLogin.Text) || string.IsNullOrWhiteSpace(txtPasswordLogin.Text))
                    {
                        MessageBox.Show("Username dan Password harus diisi.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string query = "SELECT COUNT(*) FROM login WHERE Username = @Username AND Password = @Password";
                    var parameters = new { Username = txtUsernameLogin.Text, Password = txtPasswordLogin.Text };

                    int count = _conn.QueryFirstOrDefault<int>(query, parameters);

                    if (count > 0)
                    {
                        MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Form_Dashboard dashboard = new Form_Dashboard();
                        dashboard.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Login Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

