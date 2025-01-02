using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistem_Manajemen_Hotel.Model.Context;
using Sistem_Manajemen_Hotel.Model.Entity;
using System.Windows.Forms;
using System.Diagnostics;

namespace Sistem_Manajemen_Hotel.Model.Repository
{
    public class ClientRepository
    {
        private SQLiteConnection _conn;

        public ClientRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(ClientEntity client)
        {
            int result = 0;
            string sql = @"INSERT INTO client (id_client, firstname, lastname, phone) VALUES (@id_client, @firstname, @lastname, @phone)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_client", client.Id);
                cmd.Parameters.AddWithValue("@firstname", client.Firstname);
                cmd.Parameters.AddWithValue("@lastname", client.Lastname);
                cmd.Parameters.AddWithValue("@phone", client.Phone);
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
        public List<ClientEntity> ReadAll()
        {
            List<ClientEntity> list = new List<ClientEntity>();
            try
            {

                string sql = @"SELECT id_client, firstname, lastname, phone FROM client";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ClientEntity client = new ClientEntity();
                            client.Id = reader["id_client"].ToString();
                            client.Firstname = reader["firstname"].ToString();
                            client.Lastname = reader["lastname"].ToString();
                            client.Phone = Convert.ToInt32(reader["phone"]);

                            list.Add(client);
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
        public List<ClientEntity> ReadByNama(string firstname)
        {
            List<ClientEntity> list = new List<ClientEntity>();
            try
            {

                string sql = @"SELECT id_client, firstname, lastname, phone FROM client WHERE firstname LIKE @firstname";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@firstname", string.Format("%{0}%", firstname));

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            while (reader.Read())
                            {
                                ClientEntity client = new ClientEntity();
                                client.Id = reader["id_client"].ToString();
                                client.Firstname = reader["firstname"].ToString();
                                client.Lastname = reader["lastname"].ToString();
                                client.Phone = Convert.ToInt32(reader["phone"]);

                                list.Add(client);
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

        public int Update(ClientEntity client)
        {
            int result = 0;
            string sql = @"UPDATE client SET firstname = @firstname, lastname = @lastname, phone = @phone WHERE id_client = @id_client";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_client", client.Id);
                cmd.Parameters.AddWithValue("@firstname", client.Firstname);
                cmd.Parameters.AddWithValue("@lastname", client.Lastname);
                cmd.Parameters.AddWithValue("@phone", client.Phone);

                Debug.WriteLine($"Query: {sql}");
                foreach (SQLiteParameter parameter in cmd.Parameters)
                {
                    Debug.WriteLine($" data dari client repo {parameter.ParameterName}: {parameter.Value}");
                }

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
        public int Delete(ClientEntity client)
        {
            int result = 0;
            string sql = @"DELETE FROM client WHERE id_client = @id_client";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_client", client.Id);

                try
                {
                    result = cmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.Print("Delete error: {0}", ex.Message);
                }
            }

            return result; // Tambahkan kembalikan nilai result di sini
        }
    }

}
