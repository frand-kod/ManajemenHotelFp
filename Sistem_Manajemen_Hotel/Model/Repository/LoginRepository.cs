using System;
using Sistem_Manajemen_Hotel.Model.Entity;
using System.Data.SQLite;
using Sistem_Manajemen_Hotel.Model.Context;
using System.Diagnostics;
using System.Security.Cryptography;

namespace Sistem_Manajemen_Hotel.Model.Repository
{
    public class LoginRepository
    {
        private SQLiteConnection _conn;
        public LoginRepository(DbContext context)
        {
            _conn = context.Conn;
        }
        public int SignUp(LoginEntity login)
        {
            int result = 0;
            string sql = @"INSERT INTO login (username, password) VALUES (@username, @password)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                // ambil password dari form login untuk di kirim 
                string hashedPassword = HashPassword(login.Password);

                cmd.Parameters.AddWithValue("@username", login.Username);
                cmd.Parameters.AddWithValue("@password", hashedPassword);

                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    Debug.Print("Create error: {0}", ex.Message);
                    Debug.WriteLine(ex.StackTrace);
                }
            }
            return result;
        }

        public bool Login(LoginEntity login)
        {
            bool isAuthentificated = false;

            string sql = "SELECT password FROM login WHERE username = @username";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@username", login.Username);

                try
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {

                            // validasi password 
                            string storageHashedPass = reader["password"].ToString();

                            // bandingan hasi password yang telah di hash di Database login.password dengan hash dari login.Password

                            isAuthentificated = VerifyPassword(login.Password, storageHashedPass);
                        }
                    }
                }
                catch (Exception err)
                {
                    Debug.Print("-- Kesalahan Login {0}", err.Message);
                }
            }
            return isAuthentificated;
        }

        // hashing Method =============
        private string HashPassword(string password)
        {
            SHA256 hash = SHA256.Create();

            // buat hasing dengan SHA dengan hasil byte
            byte[] passwordHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            // kembalikan hasil hash yang telah di convert
            return Convert.ToBase64String(passwordHash);
        }

        private bool VerifyPassword(string password, string hashPassword)
        {
            string hashedInput = HashPassword(password);

            return hashedInput == hashPassword;
        }
    }
}
