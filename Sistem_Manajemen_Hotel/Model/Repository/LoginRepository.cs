using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistem_Manajemen_Hotel.Model.Entity;
using System.Data.SQLite;
using Sistem_Manajemen_Hotel.Model.Context;
using System.Windows.Forms;
using System.Drawing;

namespace Sistem_Manajemen_Hotel.Model.Repository
{
    public class LoginRepository
    {
        private SQLiteConnection _conn;
        public LoginRepository(DbContext context)
        {
            _conn = context.Conn;
        }
        public int Create(LoginEntity login)
        {
            int result = 0;
            string sql = @"INSERT INTO login (Username, Password) VALUES (@username, @password)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@username", login.Username);
                cmd.Parameters.AddWithValue("@password", login.Password);

                try
                {
                    // jalankan perintah INSERT dan tampung hasilnya ke dalam variabel result
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Create error: {0}", ex.Message);
                }

            }
            return result;
        }
        public List<LoginEntity> ReadAll()
        {
            List<LoginEntity> list = new List<LoginEntity>(); // Ganti List<Login> menjadi List<Masuk>
            try
            {
                string sql = @"SELECT Username, Password FROM Login";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LoginEntity login = new LoginEntity(); // Ganti Masuk login = new Masuk
                            login.Username = reader["Username"].ToString();
                            login.Password = reader["Password"].ToString();


                            list.Add(login); // Ubah Masuk menjadi login
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadAll error: {0}", ex.Message);
            }
            return list;
        }

        public List<LoginEntity> ReadByNama(string nama)
        {
            List<LoginEntity> list = new List<LoginEntity>();
            try
            {

                string sql = @"SELECT Username, Password FROM Login";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@nama", string.Format("%{0}%", nama));

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            while (reader.Read())
                            {
                                LoginEntity login = new LoginEntity(); // Ganti Masuk login = new Masuk
                                login.Username = reader["Username"].ToString();
                                login.Password = reader["Password"].ToString();


                                list.Add(login); // Ubah Masuk menjadi login
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print("ReadByNama error: {0}", ex.Message);
            }
            return list;
        }
        public int Update(LoginEntity login)
        {
            int result = 0;
            string sql = @"UPDATE Login SET Password = @password WHERE Username = @username";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@password", login.Password);
                cmd.Parameters.AddWithValue("@username", login.Username);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }

            }
            return result;
        }
        public int Delete(string username)
        {
            int result = 0;

            string sql = @"DELETE FROM login WHERE Username = @username";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@username", username);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Update error: {0}", ex.Message);
                }
            }
            return result;
        }
    }
}
