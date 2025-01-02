using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dapper;
using Sistem_Manajemen_Hotel.Model.Context;

namespace Sistem_Manajemen_Hotel.View
{
    public partial class Form_SignUp : Form
    {
        private readonly Sistem_Manajemen_Hotel.Model.Context.DbContext dbContext;
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
        public Form_SignUp()
        {
            InitializeComponent();
            txtUsernameSignUp.KeyDown += txtUsernameSignUp_KeyDown;
            txtPasswordSignUp.KeyDown += txtPasswordSignUp_KeyDown;
            dbContext = new Sistem_Manajemen_Hotel.Model.Context.DbContext();
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

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter a username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (InsertUserData(username, password))
            {
                MessageBox.Show("Signup successful! You can now log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form_Login login = new Form_Login();
                login.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Data Sudah Ada", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool InsertUserData(string username, string password)
        {
            try
            {
                using (SQLiteConnection connection = Conn)
                {
                    int rowsAffected = connection.Execute("INSERT INTO login (Username, Password) VALUES (@Username, @Password)",
                        new { Username = username, Password = password });

                    return rowsAffected > 0;
                }
            }
            catch (Exception)
            {
                return false;
            }
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
