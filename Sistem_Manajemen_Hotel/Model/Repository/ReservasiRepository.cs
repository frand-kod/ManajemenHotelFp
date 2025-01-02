using System;
using System.Collections.Generic;
using System.Data.SQLite;
using Sistem_Manajemen_Hotel.Model.Entity;
using Sistem_Manajemen_Hotel.Model.Context;
using Sistem_Manajemen_Hotel.View;
using System.Diagnostics;

namespace Sistem_Manajemen_Hotel.Model.Repository
{
    public class ReservasiRepository
    {
        private SQLiteConnection _conn;

        public ReservasiRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(ReservasiEntity reservation)
        {
            int result = 0;
            Random random = new Random();
            int randomNumber = random.Next(1000, 10000); // Menghasilkan angka acak antara 1000 dan 9999

            reservation.id_reservasi = Convert.ToInt32 (randomNumber);

            string sql = @"
                INSERT INTO reservasi (id_reservasi,id_client, id_room, masuk, keluar) 
                                VALUES (@id_reservasi, @id_client, @id_room, @masuk, @keluar)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_reservasi", reservation.id_reservasi);

                cmd.Parameters.AddWithValue("@id_client", reservation.id_client);
                cmd.Parameters.AddWithValue("@id_room", reservation.id_room);
                cmd.Parameters.AddWithValue("@masuk", reservation.masuk);
                cmd.Parameters.AddWithValue("@keluar", reservation.keluar);
                try
                {
                    Debug.WriteLine($"Repo Try --SQL Parameters: id_reservasi = {reservation.id_reservasi}, id_room = {reservation.id_room}, id_client = {reservation.id_client}, masuk = {reservation.masuk}, keluar = {reservation.keluar}");
                    result = cmd.ExecuteNonQuery();
                    System.Diagnostics.Debug.WriteLine($"Rows inserted: {result}");


                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Create error: {ex.Message}");
                    Debug.WriteLine($"Repo Catch --SQL Parameters: Id_reservasi = {reservation.id_reservasi}, id_client = {reservation.id_client}, masuk = {reservation.masuk}, keluar = {reservation.keluar}");

                }
            }
            return result;
        }
        public List<ReservasiEntity> ReadByIdReservasi(string IdReservasi)
        {
            List<ReservasiEntity> list = new List<ReservasiEntity>();
            try
            {

                string sql = @"SELECT id_reservasi, id_client, id_room, masuk,keluar FROM reservasi WHERE id_reservasi LIKE @id_reservasi";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@id_reservasi", string.Format("%{0}%", IdReservasi));

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            while (reader.Read())
                            {
                                ReservasiEntity reservation = new ReservasiEntity
                                {
                                    id_reservasi = Convert.ToInt32(reader["id_reservasi"]),
                                    id_client = Convert.ToInt32( reader["id_client"]),
                                    id_room = Convert.ToInt32(reader["room_type"]),
                                    masuk = reader["masuk"].ToString(),
                                    keluar = reader["keluar"].ToString()
                                };

                                list.Add(reservation);
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
        public List<ReservasiEntity> ReadAll()
        {
            List<ReservasiEntity> list = new List<ReservasiEntity>();
            string sql = "SELECT * From reservasi ";

            try
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReservasiEntity reservation = new ReservasiEntity
                            {
                                id_reservasi = Convert.ToInt32(reader["id_reservasi"]),
                                id_client = Convert.ToInt32(reader["id_client"]),
                                id_room = Convert.ToInt32(reader["id_room"]),
                                masuk = reader["masuk"].ToString(),
                                keluar = reader["keluar"].ToString()
                            };

                            list.Add(reservation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ReadAll error: {ex.Message}");
            }
            return list;
        }

        public int Update(ReservasiEntity reservation)
        {
            int result = 0;//id_reservasi,id_client, id_room, masuk, keluar
            string sql = @"
                UPDATE reservasi 
                SET id_client = @id_client,  id_room = @id_room, masuk = @masuk, keluar = @keluar 
                WHERE id_reservasi = @id_reservasi";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_reservasi", reservation.id_reservasi);
                cmd.Parameters.AddWithValue("@id_client", reservation.id_client);
                cmd.Parameters.AddWithValue("@id_room", reservation.  id_room);
                cmd.Parameters.AddWithValue("@masuk", reservation.masuk);
                cmd.Parameters.AddWithValue("@keluar", reservation.keluar);

                try
                {
                    result = cmd.ExecuteNonQuery();
                    System.Diagnostics.Debug.WriteLine($"Rows updated: {result}");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Update error: {ex.Message}");
                }
            }
            return result;
        }

        public int Delete(int id_reservasi)
        {
            int result = 0;
            string sql = "DELETE FROM reservasi WHERE id_reservasi = @id_reservasi";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id_reservasi", id_reservasi);

                try
                {
                    result = cmd.ExecuteNonQuery();
                    System.Diagnostics.Debug.WriteLine($"Rows deleted: {result}");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine($"Delete error: {ex.Message}");
                }
            }

            return result;
        }
    }
}
