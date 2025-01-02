using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sistem_Manajemen_Hotel.Model.Entity;
using Sistem_Manajemen_Hotel.Model.Context;

namespace Sistem_Manajemen_Hotel.Model.Repository
{
    public class ReservationRepository
    {
        private SQLiteConnection _conn;
        public ReservationRepository(DbContext context)
        {
            _conn = context.Conn;
        }

        public int Create(ReservationEntity reservation)
        {
            int result = 0;
            string sql = @"INSERT INTO reservasi (id_reservasi, room_type, masuk, keluar) VALUES (@id_reservasi, @room_type, @masuk, @keluar)";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", reservation.id_reservation);
                cmd.Parameters.AddWithValue("@nama", reservation.room_type);
                cmd.Parameters.AddWithValue("@deskripsi", reservation.masuk);
                cmd.Parameters.AddWithValue("@harga", reservation.keluar);
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

        public List<ReservationEntity> ReadAll()
        {
            List<ReservationEntity> list = new List<ReservationEntity>();
            try
            {

                string sql = @"SELECT id_reservasi, room_type, masuk, keluar FROM reservasi";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ReservationEntity reservation = new ReservationEntity();
                            reservation.id_reservation = Convert.ToInt32(reader["id_reservasi"]);
                            reservation.room_type = reader["room_type"].ToString();
                            reservation.masuk = reader["masuk"].ToString();
                            reservation.keluar = reader["keluar"].ToString();

                            list.Add(reservation);
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

        public List<ReservationEntity> ReadByNama(string nama)
        {
            List<ReservationEntity> list = new List<ReservationEntity>();
            try
            {

                string sql = @"SELECT id_reservasi, room_type, masuk, keluar FROM reservasi WHERE room_type LIKE @room_type";

                using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
                {
                    cmd.Parameters.AddWithValue("@room_type", string.Format("%{0}%", nama));

                    using (SQLiteDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            while (reader.Read())
                            {
                                ReservationEntity reservation = new ReservationEntity();
                                reservation.id_reservation = Convert.ToInt32(reader["id_reservasi"]);
                                reservation.room_type = reader["room_"].ToString();
                                reservation.masuk = reader["Deskripsi"].ToString();
                                reservation.keluar = reader["Harga"].ToString();

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
        public int Update(ReservationEntity reservation)
        {
            int result = 0;
            string sql = @"UPDATE reservasi SET id_reservasi = @id_reservasi, room_type = @room_type, masuk = @masuk, keluar = @keluar WHERE id_reservasi = @id_reservasi";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@is_reservasi", reservation.id_reservation);
                cmd.Parameters.AddWithValue("@room_type", reservation.room_type);
                cmd.Parameters.AddWithValue("@masuk", reservation.masuk);
                cmd.Parameters.AddWithValue("@keluar", reservation.keluar);

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

        public int Delete(ReservationEntity reservation)
        {
            int result = 0;
            string sql = @"DELETE FROM reservasi WHERE is_reservasi = @id_reservasi";

            using (SQLiteCommand cmd = new SQLiteCommand(sql, _conn))
            {
                cmd.Parameters.AddWithValue("@id", reservation.id_reservation);

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
